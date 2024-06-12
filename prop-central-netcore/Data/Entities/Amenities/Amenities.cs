using System;
namespace prop_central_netcore.Data.Entities.Amenities
{
    public class Amenities : BasePrimaryKey
    {
        public required string Name { get; set; }

        public required string ImageUrl { get; set; }
    }
}

