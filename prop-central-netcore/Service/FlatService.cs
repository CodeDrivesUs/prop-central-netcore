using System;
using prop_central_netcore.Data.Interfaces;
using prop_central_netcore.Shared.Enums;

namespace prop_central_netcore.Service
{
	public class FlatService
	{
		private readonly IFlatRepository _flatRepository;

        public FlatService(IFlatRepository flatRepository )
		{
			_flatRepository = flatRepository;
		}

        //public List<FlatSharedModel> GetAllSubmittedApllications()
        //{
        //    return _dataMapping.GetAllFlatsByStatusId((int)FlatStatusEnum.ApplicationSubmitted).ToList();
        //}

        //public bool ValidateFlatImages(Guid flatId)
        //{

        //    var flatProfilePicture = _flatImageBusiness.GetProfilePicture(flatId);

        //    if (flatProfilePicture == null)
        //    {
        //        return false;
        //    }

        //    var roomTypes = GetFlatRoomTypesByFlatId(flatId);
        //    foreach (var room in roomTypes)
        //    {
        //        if (string.IsNullOrEmpty(room.ImageUrl))
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}

        //public List<FlatSharedModel> GetAllApllicationsSubmittedForFlatActivation()
        //{
        //    return _dataMapping.GetAllFlatsByStatusId((int)FlatStatusEnum.ApplicationSubmitedForActivation).ToList();
        //}

        //public List<FlatSharedModel> GetAllApprovedApllications()
        //{
        //    return _dataMapping.GetAllFlatsByStatusId((int)FlatStatusEnum.ApplicationAccepted).ToList();
        //}
        //public List<FlatSharedModel> GetFlatsToAddRooms()
        //{
        //    return _dataMapping.GetAllFlatsExeptStatusId((int)FlatStatusEnum.ApplicationSubmitted).ToList();
        //}

        //public void AddAmenitie(Guid flatId, Guid amenityId)
        //{
        //    _dataMapping.AddRoomOrAmenitie(new FlatAmenitiesRoomsModel { FlatId = flatId, AmenityId = amenityId, Type = 1 });
        //}

        //public CreateUpdateFlatSharedModel GetFlatApplication(Guid FlatId)
        //{
        //    return _dataMapping.GetFlatApplication(FlatId);
        //}
        //public void ProcessApplication(CreateUpdateFlatSharedModel createUpdateFlatSharedModel, Guid[] Amenities, Guid[] RoomTypes)
        //{
        //    Parallel.ForEach(Amenities, amenity => AddAmenitie(createUpdateFlatSharedModel.Id, amenity));
        //    _dataMapping.AcceptFlat(createUpdateFlatSharedModel);
        //}
        //public void SubmitApplicationForActivation(CreateUpdateFlatSharedModel createUpdateFlatSharedModel)
        //{
        //    _dataMapping.SubmitApplicationForActivation(createUpdateFlatSharedModel);
        //    var email = new FlatSubmittedForActivationEmail(createUpdateFlatSharedModel.Name, _profileBusiness.GetFullProfileByUserId(createUpdateFlatSharedModel.UserId));
        //    email.SendMail();
        //}
        //public Guid GetApplicantUserId(Guid FlatId)
        //{
        //    return _dataMapping.GetApplicantUserId(FlatId);
        //}
        //public void AddLandLord(AddLandLordSharedModel addLandLord)
        //{
        //    _dataMapping.AddLandLord(addLandLord);
        //    AddToFlatHistory(addLandLord.FlatId, addLandLord.UserId, (int)FlatStatusEnum.AddLandLord);
        //}

        //public void ActivateFlat(CreateUpdateFlatSharedModel model)
        //{
        //    _dataMapping.ActivateFlat(model);
        //    var currentAmenities = _amenitiesBusiness.GetAmenitiesByFlatId(model.Id);
        //    var currentRoomTypes = _roomTypeBusiness.GetRoomTypeByFlatId(model.Id);
        //    Parallel.ForEach(model.Amenities, amenity => ProcessAmenitiesandRoomTypesTobeAdded(amenity, currentAmenities, null, model.Id));
        //    Parallel.ForEach(currentAmenities, amenity => ProcessAmenitiesAndRoomTypesTobeDeleted(amenity, null, model.Amenities, model.Id));
        //    Parallel.ForEach(model.RoomTypes, roomtype => ProcessAmenitiesandRoomTypesTobeAdded(roomtype, null, currentRoomTypes, model.Id));
        //    Parallel.ForEach(currentRoomTypes, roomtype => ProcessAmenitiesAndRoomTypesTobeDeleted(null, roomtype, model.RoomTypes, model.Id));
        //    var email = new FlatActivationEmail(model, GetFlatDetails(model.Id), _profileBusiness.GetFullProfileByUserId(GetApplicantUserId(model.Id)), _profileBusiness.GetFullProfileByUserId(model.LandLord));
        //    try
        //    {
        //        email.SendMail();
        //    }
        //    catch { }
        //}

        //public void AddToFlatHistory(Guid FlatId, Guid UserId, int status)
        //{
        //    _dataMapping.AddToFlatHistory(new AddToFlatHistorySharedModel { FlatId = FlatId, statusId = status, UserId = UserId });
        //}
        //public List<FlatViewModel> GetPaginatedListFlats(int page, string keyword)
        //{
        //    return _dataMapping.GetPaginatedListFlats(GetStartRow(page), rowsperpage, keyword).ToList();
        //}
        //public List<FlatViewModel> GetLatestFlats()
        //{
        //    return _dataMapping.GetLatestFlat().ToList();
        //}
        //public int GetStartRow(int page)
        //{
        //    int capture = page - 1;
        //    if (page == 1)
        //    {
        //        return 0;
        //    }
        //    return capture * rowsperpage;
        //}

        //public int CalcTotalPages(string Keyword)
        //{
        //    int totalnews = _dataMapping.GetCountPaginatedListFlats(Keyword);
        //    int valu = totalnews / rowsperpage;
        //    int modulas = totalnews % rowsperpage;
        //    if (modulas != 0)
        //    {
        //        ++valu;
        //    }
        //    return valu;
        //}

        //public Pagination PopulatePagination(string keyword, int page)
        //{
        //    int total = GetPaginatedListFlats(page, keyword).ToList().Count;
        //    int _to = GetStartRow(page) + total;
        //    int _from = GetStartRow(page) + 1;
        //    return new Pagination { _count = _dataMapping.GetCountPaginatedListFlats(keyword), _current = page, _final = CalcTotalPages(keyword), _from = _from, _to = _to };
        //}

        //public CreateUpdateFlatSharedModel GetFlatPopulatedWithRommtypesAndAmenities(Guid FlatId)
        //{
        //    var model = GetFlatApplication(FlatId);
        //    model.ListAmenities = _amenitiesBusiness.GetAmenitiesByFlatId(FlatId);
        //    model.ListRoomTypes = _roomTypeBusiness.GetRoomTypeByFlatId(FlatId);
        //    return model;
        //}

        //public int GetCountPaginatedListFlats(string keyword)
        //{
        //    return _dataMapping.GetCountPaginatedListFlats(keyword);
        //}

        //public void AddFlatRoomType(FlatAmenitiesRoomsModel model)
        //{
        //    _dataMapping.AddRoomOrAmenitie(model);
        //}

        //public Guid AddFlatApplication(FullFlatApplicationSharedModel model)
        //{
        //    model.Id = _dataMapping.CreateFlat(new CreateUpdateFlatSharedModel { Address = model.Address, Deposit = model.Deposit, Email = model.Email, Name = model.FlatName, RentingPrice = model.Rent, PhoneNumber = model.PhoneNumber, UserId = model.UserId });
        //    Parallel.ForEach(model.Amenities, amenity => AddAmenitie(model.Id, amenity));
        //    Parallel.ForEach(model._listflatroomtypes, roomtype => AddFlatRoomType(new FlatAmenitiesRoomsModel { FlatId = model.Id, RoomTypeId = roomtype.RoomTypeId, Rent = roomtype.Rent, Deposit = roomtype.Deposit, Type = 2 }));

        //    var email = new FlatApplicationCreatedEmail(model, _profileBusiness.GetFullProfileByUserId(model.UserId));
        //    email.SendMail();
        //    return model.Id;
        //}

        //public List<FlatRoomTypesSharedModel> GetFlatRoomTypesByFlatId(Guid FlatId)
        //{
        //    return _dataMapping.GetFlatRoomTypesByFlatId(FlatId).ToList();
        //}

        //public ManageRoom InitializeManageRoom(Guid roomId, Guid flatId)
        //{
        //    return new ManageRoom { room = _dataMapping.GetFlatRoomByRoomId(roomId), RoomImages = _flatImageBusiness.GetAllImagesForARoom(roomId), flatId = flatId };
        //}

        //public List<CreateUpdateFlatSharedModel> GetAllUserFlats(Guid userId)
        //{
        //    var submitted = _dataMapping.GetUserFlatListByStatusId(userId, (int)FlatStatusEnum.ApplicationSubmitted).ToList();
        //    var submittedForActivation = _dataMapping.GetUserFlatListByStatusId(userId, (int)FlatStatusEnum.ApplicationSubmitedForActivation);
        //    var Active = _dataMapping.GetAllFlatsForLAndLordByUserId(userId).ToList();
        //    if (submittedForActivation != null)
        //    {
        //        submitted.AddRange(submittedForActivation);
        //    }
        //    if (Active != null)
        //    {
        //        submitted.AddRange(Active);
        //    }
        //    return submitted;
        //}

        //public List<FlatViewModel> GetAllFlatsForPlaceName(string placeName)
        //{
        //    return _dataMapping.GetAllFlatsForPlaceName(placeName).ToList();
        //}

        //public FlatDetails GetFlatDetails(Guid flatId)
        //{
        //    return new FlatDetails
        //    {
        //        ListAmenities = _amenitiesBusiness.GetAmenitiesByFlatId(flatId),
        //        ListRoomTypes = GetFlatRoomTypesByFlatId(flatId)
        //    };
        //}

        //public void UpdateFlatRoomType(FlatRoomTypesSharedModel model)
        //{
        //    _dataMapping.UpdateFlatRoomType(model);
        //}

        //public List<FlatViewModel> GetAllFlatsForFindFlats(SearchFlatModel model)
        //{
        //    return _dataMapping.GetAllFlatsForFindFlats(model).ToList();
        //}


        //#region private
        //private void ProcessAmenitiesandRoomTypesTobeAdded(Guid amenityOrRoomtype, List<AmenitiesSharedModel> amenities, List<RoomTypeSharedModel> roomTypes, Guid flatId)
        //{
        //    if (roomTypes == null)
        //    {
        //        if (!amenities.Exists(x => x.Id == amenityOrRoomtype))
        //        {
        //            AddAmenitie(flatId, amenityOrRoomtype);
        //        }
        //    }
        //    else
        //    {
        //        if (!roomTypes.Exists(x => x.Id == amenityOrRoomtype))
        //        {
        //            AddFlatRoomType(new FlatAmenitiesRoomsModel { RoomTypeId = amenityOrRoomtype, FlatId = flatId, Type = 2 });
        //        }
        //    }
        //}

        //private void ProcessAmenitiesAndRoomTypesTobeDeleted(AmenitiesSharedModel amenity, RoomTypeSharedModel roomType, Guid[] amenitiesOrRoomtypes, Guid flatId)
        //{
        //    if (roomType == null)
        //    {
        //        if (!amenitiesOrRoomtypes.ToList().Exists(x => x == amenity.Id))
        //        {
        //            _amenitiesBusiness.DeleteAmenitiy(amenity.Id, flatId);
        //        }
        //    }
        //    else
        //    {
        //        if (!amenitiesOrRoomtypes.ToList().Exists(x => x == roomType.Id))
        //        {
        //            _roomTypeBusiness.DeleteRoomTypeForAFlat(roomType.Id, flatId);
        //        }
        //    }
        //}
        //#endregion
    }
}

