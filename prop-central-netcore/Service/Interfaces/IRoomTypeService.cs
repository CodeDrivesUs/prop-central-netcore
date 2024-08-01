using System;
using prop_central_netcore.Dto.RoomType;

namespace prop_central_netcore.Service.Interfaces
{
	public interface IRoomTypeService
	{
        Task<List<RoomTypeDto>> GetAllRoomTypes();
        Task<List<RoomTypeDto>> GetRoomTypeByFlatId(Guid FlatId);
        Task CreateRoomType(RoomTypeDto model);
        Task<RoomTypeDto> Get(Guid Id);
        Task DeleteRoomType(Guid Id);
        Task DeleteRoomTypeForAFlat(Guid Id, Guid flatId);

    }
}

