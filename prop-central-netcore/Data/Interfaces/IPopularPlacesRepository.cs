using System;
using prop_central_netcore.Data.Entities.PopularPlaces;

namespace prop_central_netcore.Data.Interfaces
{
	public interface IPopularPlacesRepository
	{
        Task AddPopularPlaces(CreatePopularPlace model, CancellationToken cancellationToken = default);
        Task<List<PopularPlaces>> GetAllPopularPlaces(CancellationToken cancellationToken = default);
        Task<PopularPlaces> GetPopularPlacesById(Guid placeId, CancellationToken cancellationToken = default);
        Task<List<Province>> GetAllProvinces(CancellationToken cancellationToken = default);
        Task<List<City>> GetAllCities(CancellationToken cancellationToken = default);
        Task<List<Surbub>> GetAllSurbubs(CancellationToken cancellationToken = default);
    }
}

