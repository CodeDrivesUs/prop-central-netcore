using System;
using prop_central_netcore.Data.Entities.RoomType;

namespace prop_central_netcore.Data.Interfaces
{
	public interface IRoomTypeRepository
	{
        Task<List<RoomType>> GetAll(CancellationToken cancellationToken = default);
        Task<List<RoomType>> GetRoomTypeByFlatId(Guid flatId, CancellationToken cancellationToken = default);
        Task CreateRoomType(RoomType model, CancellationToken cancellationToken = default);
        Task DeleteRoomType(Guid Id, CancellationToken cancellationToken = default);
        Task DeleteRoomTypeForAFlat(Guid Id, Guid flatId, CancellationToken cancellationToken = default);
        Task<RoomType> Get(Guid id, CancellationToken cancellationToken = default);
    }
}

