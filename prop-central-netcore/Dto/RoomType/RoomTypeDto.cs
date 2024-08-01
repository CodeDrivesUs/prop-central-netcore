using System;
namespace prop_central_netcore.Dto.RoomType
{
	public class RoomTypeDto : BasePrimaryKeyDto
	{
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfPeople { get; set; }
    }
}

