using System;
using prop_central_netcore.Dto.FlatImage;

namespace prop_central_netcore.Service.Interfaces
{
	public interface IFlatImageService
	{
        Task AddImage(FlatImageDto model);
        Task AddRoomImage(FlatImageDto model);
        Task AddProfilePicture(FlatImageDto model);
        Task<FlatImageDto> GetProfilePicture(Guid flatId);
        Task<List<FlatImageDto>> GetAllFlatImagesExcludeProfilePicture(Guid FlatId);
        Task<List<FlatImageDto>> GetAllImagesForARoom(Guid RoomtypeId);
        Task<List<FlatImageDto>> GetGalleryImagesForAFlat(Guid FlatId);
    }
}

