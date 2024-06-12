using System;
namespace prop_central_netcore.Data.Entities.PopularPlaces
{
    public class PopularPlaces : BasePrimaryKey
    {
        public string ImageUrl { get; set; }
        public string PlaceName { get; set; }
        public int NumberOfFlats { get; set; }
    }
}

