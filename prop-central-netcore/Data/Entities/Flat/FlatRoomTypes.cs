using System;
namespace prop_central_netcore.Data.Entities.Flat
{
    public class FlatRoomTypes : BasePrimaryKey
    {
        public string Name { get; set; }
        public Guid RoomTypeId { get; set; }
        public string Description { get; set; }
        public int NumberOfPeople { get; set; }
        public decimal Deposit { get; set; }
        public decimal Rent { get; set; }
        public string ImageUrl { get; set; }
    }
}

