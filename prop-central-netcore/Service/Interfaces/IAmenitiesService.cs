using System;
using prop_central_netcore.Dto.Amenities;

namespace prop_central_netcore.Service.Interfaces
{
	public interface IAmenitiesService
	{
        Task<List<AmenitiesDto>> GetAll();
        Task Add(AmenitiesDto model);
        Task Delete(Guid id);
        Task Update(AmenitiesDto model);
        Task<AmenitiesDto> Get(Guid id);
        Task<List<AmenitiesDto>> GetAmenitiesByFlatId(Guid flatId);
        Task DeleteAmenitiy(Guid id, Guid flatId);
    }
}

