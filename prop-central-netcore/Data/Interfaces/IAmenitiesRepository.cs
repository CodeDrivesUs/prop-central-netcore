using System;
using prop_central_netcore.Data.Entities.Amenities;

namespace prop_central_netcore.Data.Interfaces
{
    public interface IAmenitiesRepository
    {
        Task<List<Amenities>> GetAll(CancellationToken cancellationToken = default);
        Task Add(Amenities model,CancellationToken cancellationToken = default);
        Task Delete(Guid id, CancellationToken cancellationToken = default);
        Task Update(Amenities model, CancellationToken cancellationToken = default);
        Task<Amenities> Get(Guid id, CancellationToken cancellationToken = default);
        Task<List<Amenities>> GetAmenitiesByFlatId(Guid flatId, CancellationToken cancellationToken = default);
        Task DeleteAmenitiy(Guid id, Guid flatId, CancellationToken cancellationToken = default);
    }
}

