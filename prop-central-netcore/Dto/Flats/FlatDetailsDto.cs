using System;
using prop_central_netcore.Dto.Amenities;

namespace prop_central_netcore.Dto.Flats
{
	public class FlatDetailsDto
	{
        public List<AmenitiesDto> ListAmenities { get; set; }
        public List<FlatRoomTypesDto> ListRoomTypes { get; set; }
    }
}

