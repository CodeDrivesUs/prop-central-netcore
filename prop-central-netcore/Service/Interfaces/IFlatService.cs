using System;
using prop_central_netcore.Dto.Flats;

namespace prop_central_netcore.Service.Interfaces
{
	public interface IFlatService
	{
        Task<List<FlatDto>> GetAllSubmittedApllicationsAsync();
        Task<bool> ValidateFlatImages(Guid flatId);
        Task<List<FlatDto>> GetAllApllicationsSubmittedForFlatActivation();
        Task<List<FlatDto>> GetAllApprovedApllications();
        Task<List<FlatDto>> GetFlatsToAddRooms();
        Task AddAmenitie(Guid flatId, Guid amenityId);
        Task<CreateUpdateFlatDto> GetFlatApplication(Guid FlatId);
        Task ProcessApplication(CreateUpdateFlatDto model, Guid[] Amenities);
        Task SubmitApplicationForActivation(CreateUpdateFlatDto model);
        Task<Guid> GetApplicantUserId(Guid FlatId);
        Task AddLandLord(AddLandLordDto addLandLord);
        Task ActivateFlat(CreateUpdateFlatDto model);
        Task AddToFlatHistory(Guid FlatId, Guid UserId, int status);
        Task<List<FlatViewDto>> GetPaginatedListFlats(int page, string keyword);
        Task<List<FlatViewDto>> GetLatestFlats();
        int GetStartRow(int page);
        Task<int> CalcTotalPages(string Keyword);
        Task<CreateUpdateFlatDto> GetFlatPopulatedWithRommtypesAndAmenities(Guid FlatId);
        Task<int> GetCountPaginatedListFlats(string keyword);
        Task AddFlatRoomType(FlatAmenitiesRoomsDto model);
        Task<Guid> AddFlatApplication(FullFlatApplicationDto model);
        Task<List<FlatRoomTypesDto>> GetFlatRoomTypesByFlatId(Guid FlatId);
        Task<ManageRoomDto> InitializeManageRoom(Guid roomId, Guid flatId);
        Task<List<CreateUpdateFlatDto>> GetAllUserFlats(Guid userId);
        Task<List<FlatViewDto>> GetAllFlatsForPlaceName(string placeName);
        Task<FlatDetailsDto> GetFlatDetails(Guid flatId);
        Task<List<FlatViewDto>> GetAllFlatsForFindFlats(SearchFlatDto model);

    }
}

