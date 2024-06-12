using System;
using prop_central_netcore.Dto.PopularPlaces;

namespace prop_central_netcore.Service.Interfaces
{
	public interface IPopularPlacesService
    {
		Task AddPopularPlace(CreatePopularPlaceDto model);
        Task<List<PopularPlacesDto>> GetAllPopularPlaces();
        Task<PopularPlacesDto> GetPopularPlaceByIdAsync(Guid placeId);
        Task<PlacesDto> GetAllPlacesAsync();
    }
}

