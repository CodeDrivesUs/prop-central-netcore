using System;
using prop_central_netcore.Data;
using prop_central_netcore.Data.Entities.Amenities;
using prop_central_netcore.Data.Entities.PopularPlaces;
using prop_central_netcore.Data.Interfaces;
using prop_central_netcore.Dto.PopularPlaces;
using prop_central_netcore.Service.Interfaces;

namespace prop_central_netcore.Service
{
	public class PopularPlacesService : IPopularPlacesService
    { 
        private readonly IPopularPlacesRepository _popularPlacesRepository;

        public PopularPlacesService(IPopularPlacesRepository popularPlacesRepository)
        {
            _popularPlacesRepository = popularPlacesRepository;
        }

        public async Task AddPopularPlace(CreatePopularPlaceDto model)
        {
            await _popularPlacesRepository.AddPopularPlaces(ObjectMapper.Mapper.Map<CreatePopularPlace>(model));
        }

        public async Task<List<PopularPlacesDto>> GetAllPopularPlaces()
        {
            return  ObjectMapper.Mapper.Map<List<PopularPlacesDto>>( await _popularPlacesRepository.GetAllPopularPlaces());
        }

        public async Task<PopularPlacesDto> GetPopularPlaceByIdAsync(Guid placeId)
        {
            return ObjectMapper.Mapper.Map<PopularPlacesDto>(await _popularPlacesRepository.GetPopularPlacesById(placeId));
        }

        public async Task<PlacesDto> GetAllPlacesAsync()
        {
            return new PlacesDto
            {
                Cities = ObjectMapper.Mapper.Map<List<CityDto>>(await _popularPlacesRepository.GetAllCities()),
                Provinces = ObjectMapper.Mapper.Map<List<ProvinceDto>>(await _popularPlacesRepository.GetAllProvinces()),
                Surbubs = ObjectMapper.Mapper.Map<List<SurbubDto>>(await _popularPlacesRepository.GetAllSurbubs())
            };
        }

      
    }
}

