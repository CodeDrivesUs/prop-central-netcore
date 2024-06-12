using System;
using prop_central_netcore.Data.Entities.Flat;

namespace prop_central_netcore.Data.Interfaces
{
	public interface IFlatRepository
	{
		Task<Guid> CreateFlat(CreateUpdateFlat createUpdateFlat, CancellationToken cancellationToken = default);
        Task<List<Flat>> GetAllFlatsExeptStatusId(int statusId, CancellationToken cancellationToken = default);
        Task<List<Flat>> GetAllFlatsByStatusId(int statusId, CancellationToken cancellationToken = default);
        Task AddRoomOrAmenitie(FlatRoomsAmenities flatRoomsAmenities, CancellationToken cancellationToken = default);
        Task<CreateUpdateFlat> GetFlatApplication(Guid FlatId, CancellationToken cancellationToken = default);
        Task AcceptFlat(CreateUpdateFlat createUpdateFlat, CancellationToken cancellationToken = default);
        Task AddLandLord(AddLandLord addLandLord, CancellationToken cancellationToken = default);
        Task<Guid> GetApplicantUserId(Guid flatId, CancellationToken cancellationToken = default);
        Task AddToFlatHistory(AddToFlatHistory addToFlatHistory, CancellationToken cancellationToken = default);
        Task SubmitApplicationForActivation(CreateUpdateFlat createUpdateFlat, CancellationToken cancellationToken = default);
        Task<List<FlatView>> GetLatestFlat(CancellationToken cancellationToken = default);
        Task<List<FlatView>> GetPaginatedListFlats(int startrow, int rowsperpage, string keyword, CancellationToken cancellationToken = default);
        Task<int> GetCountPaginatedListFlats(string keyword, CancellationToken cancellationToken = default);
        Task<List<FlatRoomTypes>> GetFlatRoomTypesByFlatId(Guid FlatId, CancellationToken cancellationToken = default);
        Task<List<CreateUpdateFlat>> GetUserFlatListByStatusId(Guid UserId, int statusId, CancellationToken cancellationToken = default);
        Task<List<CreateUpdateFlat>> GetAllUserFlatList(Guid UserId, int statusId, CancellationToken cancellationToken = default);
        Task<List<FlatView>> GetAllFlatsForPlaceName(string placeName, CancellationToken cancellationToken = default);
        Task<FlatRoomTypes> GetFlatRoomByRoomId(Guid roomId, CancellationToken cancellationToken = default);
        Task UpdateFlateRoomType(FlatRoomTypes model, CancellationToken cancellationToken = default);
        Task<List<FlatView>> GetAllFlatsForFindFlats(SearchFlat model, CancellationToken cancellationToken = default);
        Task ActivateFlat(CreateUpdateFlat model, CancellationToken cancellationToken = default);
        Task<List<CreateUpdateFlat>> GetAllFlatsForLAndLordByUserId(Guid UserId, CancellationToken cancellationToken = default);
	}
}

