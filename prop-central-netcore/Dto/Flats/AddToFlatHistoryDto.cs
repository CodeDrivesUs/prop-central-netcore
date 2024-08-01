using System;
namespace prop_central_netcore.Dto.Flats
{
	public class AddToFlatHistoryDto
	{
        public Guid FlatId { get; set; }
        public Guid UserId { get; set; }
        public int statusId { get; set; }
    }
}

