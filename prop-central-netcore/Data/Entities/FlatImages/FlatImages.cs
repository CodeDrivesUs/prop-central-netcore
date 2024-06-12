using System;
using prop_central_netcore.Shared.Enums;

namespace prop_central_netcore.Data.Entities.FlatImages
{
    public class FlatImages : BasePrimaryKey
    {
        public Guid FlatId { get; set; }
        public Guid FlatRoomtypeId { get; set; }
        public FlatImagesEnum StatusId { get; set; }
        public string ImageUrl { get; set; }
    }
}

