using System;
namespace prop_central_netcore.Data.Entities.Flat
{
    public class SearchFlat
    {
        public string City { get; set; }
        public string Surbub { get; set; }
        public string KeyWord { get; set; }
        public bool IsSearch { get; set; }
        public Guid RoomTypeId { get; set; }
    }
}

