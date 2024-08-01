using System;
namespace prop_central_netcore.Dto.Flats
{
	public class FlatRoomTypesDto : BaseImageUrlDto
	{
        public string Name { get; set; }
        public Guid FlatId { get; set; }
        public Guid RoomTypeId { get; set; }
        public string Description { get; set; }
        public int NumberOfPeople { get; set; }
        public decimal Deposit { get; set; }
        public decimal Rent { get; set; }
    }
}

