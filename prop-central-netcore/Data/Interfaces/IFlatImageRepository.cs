using System;
using prop_central_netcore.Data.Entities.FlatImages;

namespace prop_central_netcore.Data.Interfaces
{
	public interface IFlatImageRepository
	{
        Task AddImage(FlatImages flatImages, CancellationToken cancellationToken = default);
        Task<FlatImages> GetFlatProfilePicture(Guid FlatId, CancellationToken cancellationToken = default);
        Task AddRoomImage(FlatImages flatImages, CancellationToken cancellationToken = default);
        Task<List<FlatImages>> GetAllFlatImagesExcludeProfilePicture(Guid FlatId, CancellationToken cancellationToken = default);
        Task<List<FlatImages>> GetAllImagesForARoom(Guid RoomTypeId, CancellationToken cancellationToken = default);
    }
}

