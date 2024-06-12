using System;
using AutoMapper;
using prop_central_netcore.Data;
using prop_central_netcore.Data.Entities.Amenities;
using prop_central_netcore.Data.Interfaces;
using prop_central_netcore.Dto.Amenities;
using prop_central_netcore.Service.Interfaces;

namespace prop_central_netcore.Service
{
	public class AmenitiesService: IAmenitiesService
    {
        private readonly IAmenitiesRepository _amenitiesRepository;

        public AmenitiesService(IAmenitiesRepository amenitiesRepository)
		{
            _amenitiesRepository = amenitiesRepository;
		}

        public async Task Add(AmenitiesDto model)
        {
            await _amenitiesRepository.Add(ObjectMapper.Mapper.Map<Amenities>(model));
        }

        public async Task Delete(Guid id)
        {
            await _amenitiesRepository.Delete(id);
        }

        public async Task DeleteAmenitiy(Guid id, Guid flatId)
        {
            await _amenitiesRepository.DeleteAmenitiy(id, flatId);
        }

        public async Task<AmenitiesDto> Get(Guid id)
        {
            return ObjectMapper.Mapper.Map<AmenitiesDto>(await _amenitiesRepository.Get(id));
        }

        public async Task<List<AmenitiesDto>> GetAll()
        {
            return ObjectMapper.Mapper.Map<List<AmenitiesDto>>(await _amenitiesRepository.GetAll());
        }

        public async Task<List<AmenitiesDto>> GetAmenitiesByFlatId(Guid flatId)
        {
            return ObjectMapper.Mapper.Map<List<AmenitiesDto>>(await _amenitiesRepository.GetAmenitiesByFlatId(flatId));
        }

        public async Task Update(AmenitiesDto model)
        {
            await _amenitiesRepository.Update(ObjectMapper.Mapper.Map<Amenities>(model));
        }
    }
}

