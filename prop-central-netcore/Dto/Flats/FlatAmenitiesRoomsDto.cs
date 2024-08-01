using System;
namespace prop_central_netcore.Dto.Flats
{
	public class FlatAmenitiesRoomsDto
	{
        public Guid FlatId { get; set; }
        public Guid AmenityId { get; set; }
        public Guid RoomTypeId { get; set; }
        public int Type { get; set; }
        public decimal Deposit { get; set; }
        public decimal Rent { get; set; }
    }
}

