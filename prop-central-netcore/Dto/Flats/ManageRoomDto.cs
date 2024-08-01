using System;
using prop_central_netcore.Dto.FlatImage;

namespace prop_central_netcore.Dto.Flats
{
	public class ManageRoomDto
	{
        public FlatRoomTypesDto room { get; set; }
        public List<FlatImageDto> RoomImages { get; set; }
        public Guid flatId { get; set; }
    }
}

