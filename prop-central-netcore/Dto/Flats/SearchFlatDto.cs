using System;
namespace prop_central_netcore.Dto.Flats
{
	public class SearchFlatDto
	{
        public string City { get; set; }
        public string Surbub { get; set; }
        public string KeyWord { get; set; }
        public bool IsSearch { get; set; }
        public Guid RoomTypeId { get; set; }
    }
}

