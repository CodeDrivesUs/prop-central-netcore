using System;
using prop_central_netcore.Dto.Amenities;

namespace prop_central_netcore.Dto.Flats
{
	public class FullFlatApplicationDto: BasePrimaryKeyDto
	{
        public Guid UserId { get; set; }
        public string FlatName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public decimal Rent { get; set; }
        public decimal Deposit { get; set; }
        public Guid[] Amenities { get; set; }
        public Guid[] RoomTypes { get; set; }
        public string[] RentWithIds { get; set; }
        public string[] DepositWithIds { get; set; }
        public List<FlatRoomTypesDto> _listflatroomtypes { get; set; }
        public List<AmenitiesDto> _listamenities { get; set; }
    }
}

