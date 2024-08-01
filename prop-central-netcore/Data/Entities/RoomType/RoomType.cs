using System;
namespace prop_central_netcore.Data.Entities.RoomType
{
	public class RoomType: BasePrimaryKey
	{
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfPeople { get; set; }
    }
}

