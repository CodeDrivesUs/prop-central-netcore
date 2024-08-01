using System;
using prop_central_netcore.Data;
using prop_central_netcore.Data.Entities.RoomType;
using prop_central_netcore.Data.Interfaces;
using prop_central_netcore.Dto.PopularPlaces;
using prop_central_netcore.Dto.RoomType;
using prop_central_netcore.Service.Interfaces;

namespace prop_central_netcore.Service
{
	public class RoomTypeService : IRoomTypeService
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomTypeService(IRoomTypeRepository roomTypeRepository)
		{
            _roomTypeRepository = roomTypeRepository;
		}

        public async Task<List<RoomTypeDto>> GetAllRoomTypes()
        {
            return ObjectMapper.Mapper.Map<List<RoomTypeDto>>( await _roomTypeRepository.GetAll());
        }

        public async Task<List<RoomTypeDto>> GetRoomTypeByFlatId(Guid FlatId)
        {
            return ObjectMapper.Mapper.Map<List<RoomTypeDto>>( await _roomTypeRepository.GetRoomTypeByFlatId(FlatId));
        }

        public async Task CreateRoomType(RoomTypeDto model)
        {
            await _roomTypeRepository.CreateRoomType(ObjectMapper.Mapper.Map<RoomType>(model));
        }

        public async Task<RoomTypeDto> Get(Guid Id)
        {
            return ObjectMapper.Mapper.Map<RoomTypeDto>( await _roomTypeRepository.Get(Id));
        }

        public async Task DeleteRoomType(Guid Id)
        {
           await _roomTypeRepository.DeleteRoomType(Id);
        }

        public async Task DeleteRoomTypeForAFlat(Guid Id, Guid flatId)
        {
           await _roomTypeRepository.DeleteRoomTypeForAFlat(Id, flatId);
        }
    }
}

