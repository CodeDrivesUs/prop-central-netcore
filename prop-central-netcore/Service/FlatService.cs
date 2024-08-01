using System;
using System.Collections.Generic;
using prop_central_netcore.Data;
using prop_central_netcore.Data.Entities.Flat;
using prop_central_netcore.Data.Interfaces;
using prop_central_netcore.Data.Repositories;
using prop_central_netcore.Dto.Amenities;
using prop_central_netcore.Dto.FlatImage;
using prop_central_netcore.Dto.Flats;
using prop_central_netcore.Dto.PopularPlaces;
using prop_central_netcore.Dto.Profile;
using prop_central_netcore.Dto.RoomType;
using prop_central_netcore.Service.Interfaces;
using prop_central_netcore.Shared.Enums;

namespace prop_central_netcore.Service
{
	public class FlatService: IFlatService
    {
		private readonly IFlatRepository _flatRepository;
        private readonly IFlatImageService _flatImageService;
        private readonly IAmenitiesService _amenitiesService;
        private readonly IRoomTypeService _roomTypeService;
        private readonly IProfileService _profileService;
        private int rowsperpage = 9;

        public FlatService(IFlatRepository flatRepository, IFlatImageService flatImageService,
            IAmenitiesService amenitiesService, IRoomTypeService roomTypeService, IProfileService profileService )
		{
			_flatRepository = flatRepository;
            _amenitiesService = amenitiesService;
            _flatImageService = flatImageService;
            _roomTypeService = roomTypeService;
            _profileService = profileService;
		}

        public async Task<List<FlatDto>> GetAllSubmittedApllicationsAsync()
        {
            return ObjectMapper.Mapper.Map<List<FlatDto>>(await _flatRepository.GetAllFlatsByStatusId((int)FlatStatusEnum.ApplicationSubmitted));
    
        }

        public async Task<bool> ValidateFlatImages(Guid flatId)
        {
            var flatProfilePicture = await _flatImageService.GetProfilePicture(flatId);

            if (flatProfilePicture == null)
                return false;

            var roomTypes = await GetFlatRoomTypesByFlatId(flatId);
            foreach (var room in roomTypes)
                if (string.IsNullOrEmpty(room.ImageUrl))
                    return false;
            return true;
        }

        public async Task<List<FlatDto>> GetAllApllicationsSubmittedForFlatActivation()
        {
            return ObjectMapper.Mapper.Map<List<FlatDto>>(await _flatRepository.GetAllFlatsByStatusId((int)FlatStatusEnum.ApplicationSubmitedForActivation));
        }

        public async Task<List<FlatDto>> GetAllApprovedApllications()
        {
            return ObjectMapper.Mapper.Map<List<FlatDto>>(await _flatRepository.GetAllFlatsByStatusId((int)FlatStatusEnum.ApplicationAccepted));
        }

        public async Task<List<FlatDto>> GetFlatsToAddRooms()
        {
            return ObjectMapper.Mapper.Map<List<FlatDto>>(await _flatRepository.GetAllFlatsByStatusId((int)FlatStatusEnum.ApplicationSubmitted));
        }

        public async Task AddAmenitie(Guid flatId, Guid amenityId)
        {
           await _flatRepository.AddRoomOrAmenitie(new FlatRoomsAmenities { FlatId = flatId, AmenityId = amenityId, Type = 1 });
        }

        public async Task<CreateUpdateFlatDto> GetFlatApplication(Guid FlatId)
        {
            return ObjectMapper.Mapper.Map<CreateUpdateFlatDto>(await _flatRepository.GetFlatApplication(FlatId));
        }


        public async Task ProcessApplication(CreateUpdateFlatDto model, Guid[] Amenities)
        {
            Parallel.ForEach(Amenities, async amenity => await AddAmenitie(model.Id, amenity));
            await _flatRepository.AcceptFlat(ObjectMapper.Mapper.Map<CreateUpdateFlat>(model));
        }

        public async Task SubmitApplicationForActivation(CreateUpdateFlatDto model)
        {
             await _flatRepository.SubmitApplicationForActivation(ObjectMapper.Mapper.Map<CreateUpdateFlat>(model));
            //var email = new FlatSubmittedForActivationEmail(createUpdateFlatSharedModel.Name, _profileBusiness.GetFullProfileByUserId(createUpdateFlatSharedModel.UserId));
            //email.SendMail();
        }

        public async Task<Guid> GetApplicantUserId(Guid FlatId)
        {
            return await _flatRepository.GetApplicantUserId(FlatId);
        }

        public async Task AddLandLord(AddLandLordDto addLandLord)
        {
            await _flatRepository.AddLandLord(ObjectMapper.Mapper.Map<AddLandLord>(addLandLord));
            await AddToFlatHistory(addLandLord.FlatId, addLandLord.UserId, (int)FlatStatusEnum.AddLandLord);
        }

        public async Task ActivateFlat(CreateUpdateFlatDto model)
        {
            await _flatRepository.ActivateFlat(ObjectMapper.Mapper.Map<CreateUpdateFlat>(model));
            var currentAmenities = await _amenitiesService.GetAmenitiesByFlatId(model.Id);
            var currentRoomTypes = await _roomTypeService.GetRoomTypeByFlatId(model.Id);
            Parallel.ForEach(model.Amenities, async amenity => await ProcessAmenitiesandRoomTypesTobeAdded(amenity, currentAmenities, null, model.Id));
            Parallel.ForEach(currentAmenities, async amenity => await ProcessAmenitiesAndRoomTypesTobeDeleted(amenity, null, model.Amenities, model.Id));
            Parallel.ForEach(model.RoomTypes, roomtype => ProcessAmenitiesandRoomTypesTobeAdded(roomtype, null, currentRoomTypes, model.Id));
            Parallel.ForEach(currentRoomTypes, roomtype => ProcessAmenitiesAndRoomTypesTobeDeleted(null, roomtype, model.RoomTypes, model.Id));
            //var email = new FlatActivationEmail(model, GetFlatDetails(model.Id), _profileService.GetFullProfileByUserId(await GetApplicantUserId(model.Id)), _profileService.GetFullProfileByUserId(model.LandLord));
            //try
            //{
            //    email.SendMail();
            //}
            //catch { }
        }

        public async Task AddToFlatHistory(Guid FlatId, Guid UserId, int status)
        {
            await _flatRepository.AddToFlatHistory(new AddToFlatHistory { FlatId = FlatId, statusId = status, UserId = UserId });
        }

        public async Task<List<FlatViewDto>> GetPaginatedListFlats(int page, string keyword)
        {
            return ObjectMapper.Mapper.Map<List<FlatViewDto>>(await _flatRepository.GetPaginatedListFlats(GetStartRow(page), rowsperpage, keyword));
        }

        public async  Task<List<FlatViewDto>> GetLatestFlats()
        {
            return ObjectMapper.Mapper.Map<List<FlatViewDto>>(await _flatRepository.GetLatestFlat());
        }

        public int GetStartRow(int page)
        {
            return (page == 1) ? 0 : (page - 1) * rowsperpage;
        }

        public async Task<int> CalcTotalPages(string Keyword)
        {
            int totalnews = await _flatRepository.GetCountPaginatedListFlats(Keyword);
            int valu = totalnews / rowsperpage;
            int modulas = totalnews % rowsperpage;
            return (modulas != 0) ? ++valu :  valu;
        }

        //public Pagination PopulatePagination(string keyword, int page)
        //{
        //    int total = GetPaginatedListFlats(page, keyword).ToList().Count;
        //    int _to = GetStartRow(page) + total;
        //    int _from = GetStartRow(page) + 1;
        //    return new Pagination { _count = _dataMapping.GetCountPaginatedListFlats(keyword), _current = page, _final = CalcTotalPages(keyword), _from = _from, _to = _to };
        //}

        public async Task<CreateUpdateFlatDto> GetFlatPopulatedWithRommtypesAndAmenities(Guid FlatId)
        {
            var model = await GetFlatApplication(FlatId);
            model.ListAmenities = await _amenitiesService.GetAmenitiesByFlatId(FlatId);
            model.ListRoomTypes = await _roomTypeService.GetRoomTypeByFlatId(FlatId);
            return model;
        }

        public async Task<int> GetCountPaginatedListFlats(string keyword)
        {
            return await _flatRepository.GetCountPaginatedListFlats(keyword);
        }

        public async Task AddFlatRoomType(FlatAmenitiesRoomsDto model)
        {
            await _flatRepository.AddRoomOrAmenitie(ObjectMapper.Mapper.Map<FlatRoomsAmenities>(model));
        }

        public async Task<Guid> AddFlatApplication(FullFlatApplicationDto model)
        {
            model.Id = await _flatRepository.CreateFlat(new CreateUpdateFlat { Address = model.Address, Deposit = model.Deposit, Email = model.Email, Name = model.FlatName, RentingPrice = model.Rent, PhoneNumber = model.PhoneNumber, UserId = model.UserId });
            Parallel.ForEach(model.Amenities, async amenity => await AddAmenitie(model.Id, amenity));
            Parallel.ForEach(model._listflatroomtypes, async roomtype => await AddFlatRoomType(new FlatAmenitiesRoomsDto { FlatId = model.Id, RoomTypeId = roomtype.RoomTypeId, Rent = roomtype.Rent, Deposit = roomtype.Deposit, Type = 2 }));

            //var email = new FlatApplicationCreatedEmail(model, _profileService.GetFullProfileByUserId(model.UserId));
            //email.SendMail();
            return model.Id;
        }

        public async Task<List<FlatRoomTypesDto>> GetFlatRoomTypesByFlatId(Guid FlatId)
        {
            return ObjectMapper.Mapper.Map<List<FlatRoomTypesDto>>( await _flatRepository.GetFlatRoomTypesByFlatId(FlatId));
        }

        public async Task<ManageRoomDto> InitializeManageRoom(Guid roomId, Guid flatId)
        {
            return new ManageRoomDto {
                room = ObjectMapper.Mapper.Map<FlatRoomTypesDto>(await _flatRepository.GetFlatRoomByRoomId(roomId)),
                RoomImages = await _flatImageService.GetAllImagesForARoom(roomId),
                flatId = flatId
            };
        }

        public async Task<List<CreateUpdateFlatDto>> GetAllUserFlats(Guid userId)
        {
            var submitted = await _flatRepository.GetUserFlatListByStatusId(userId, (int)FlatStatusEnum.ApplicationSubmitted);
            var submittedForActivation = await _flatRepository.GetUserFlatListByStatusId(userId, (int)FlatStatusEnum.ApplicationSubmitedForActivation);
            var Active = await _flatRepository.GetAllFlatsForLAndLordByUserId(userId);
            if (submittedForActivation != null)
                submitted.AddRange(submittedForActivation);
            if (Active != null)
                submitted.AddRange(Active);
            return ObjectMapper.Mapper.Map<List<CreateUpdateFlatDto>>(submitted);
        }

        public async Task<List<FlatViewDto>> GetAllFlatsForPlaceName(string placeName)
        {
            return ObjectMapper.Mapper.Map<List<FlatViewDto>>(await _flatRepository.GetAllFlatsForPlaceName(placeName));
        }

        public async Task<FlatDetailsDto> GetFlatDetails(Guid flatId)
        {
            return new FlatDetailsDto
            {
                ListAmenities = await _amenitiesService.GetAmenitiesByFlatId(flatId),
                ListRoomTypes = await GetFlatRoomTypesByFlatId(flatId)
            };
        }

        //public async Task UpdateFlatRoomType(FlatRoomTypesDto model)
        //{
        //    await _flatRepository.UpdateFlatRoomType(ObjectMapper.Mapper.Map<FlatRoomTypes>(model));
        //}

        public async Task<List<FlatViewDto>> GetAllFlatsForFindFlats(SearchFlatDto model)
        {
            return ObjectMapper.Mapper.Map<List<FlatViewDto>>( await _flatRepository.GetAllFlatsForFindFlats(ObjectMapper.Mapper.Map<SearchFlat>(model)));
        }


        #region private
        private async Task ProcessAmenitiesandRoomTypesTobeAdded(Guid amenityOrRoomtype, List<AmenitiesDto> amenities, List<RoomTypeDto> roomTypes, Guid flatId)
        {
            if (roomTypes == null)
            {
                if (!amenities.Exists(x => x.Id == amenityOrRoomtype))
                   await AddAmenitie(flatId, amenityOrRoomtype);
            }
            else
            {
                if (!roomTypes.Exists(x => x.Id == amenityOrRoomtype))
                   await AddFlatRoomType(new FlatAmenitiesRoomsDto { RoomTypeId = amenityOrRoomtype, FlatId = flatId, Type = 2 });
            }
        }

        private async Task ProcessAmenitiesAndRoomTypesTobeDeleted(AmenitiesDto amenity, RoomTypeDto roomType, Guid[] amenitiesOrRoomtypes, Guid flatId)
        {
            if (roomType == null)
                if (!amenitiesOrRoomtypes.ToList().Exists(x => x == amenity.Id))  await _amenitiesService.DeleteAmenitiy(amenity.Id, flatId);
            else
               if (!amenitiesOrRoomtypes.ToList().Exists(x => x == roomType.Id))  await _roomTypeService.DeleteRoomTypeForAFlat(roomType.Id, flatId);
        }
        #endregion
    }
}

