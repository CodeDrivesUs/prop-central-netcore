using System;
namespace prop_central_netcore.Dto.PopularPlaces
{
	public class PopularPlacesDto : BaseImageUrlDto
	{
        public string PlaceName { get; set; }
        public int NumberOfFlats { get; set; }
    }
}

