using System;
using prop_central_netcore.Shared.Enums;

namespace prop_central_netcore.Dto.FlatImage
{
	public class FlatImageDto : BaseImageUrlDto
	{
        public Guid FlatId { get; set; }
        public Guid FlatRoomtypeId { get; set; }
        public FlatImagesEnum StatusId { get; set; }
    }
}

