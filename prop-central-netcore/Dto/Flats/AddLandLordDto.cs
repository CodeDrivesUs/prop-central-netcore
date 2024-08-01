using System;
using prop_central_netcore.Data;

namespace prop_central_netcore.Dto.Flats
{
	public class AddLandLordDto
	{
        public ApplicationUser? User { get; set; }
        public Guid FlatId { get; set; }
        public Guid UserId { get; set; }
        public Guid AdminId { get; set; }
    }
}

