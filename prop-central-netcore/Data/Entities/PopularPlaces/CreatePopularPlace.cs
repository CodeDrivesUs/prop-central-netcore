using System;
namespace prop_central_netcore.Data.Entities.PopularPlaces
{
    public class CreatePopularPlace : BasePrimaryKey
    {
        public string ImageUrl { get; set; }
        public string PlaceName { get; set; }
    }
}

