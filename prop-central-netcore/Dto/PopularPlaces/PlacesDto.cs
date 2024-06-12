using System;
namespace prop_central_netcore.Dto.PopularPlaces
{
	public class PlacesDto
	{
        public List<CityDto> Cities { get; set; }
        public List<ProvinceDto> Provinces { get; set; }
        public List<SurbubDto> Surbubs { get; set; }
    }
}

