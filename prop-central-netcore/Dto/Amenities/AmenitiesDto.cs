using System;
using System.ComponentModel.DataAnnotations;

namespace prop_central_netcore.Dto.Amenities
{
	public class AmenitiesDto:BaseImageUrlDto
	{
        [Required]
        public string Name { get; set; }
    }
}

