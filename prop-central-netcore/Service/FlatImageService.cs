using System;
using prop_central_netcore.Data;
using prop_central_netcore.Data.Entities.FlatImages;
using prop_central_netcore.Data.Interfaces;
using prop_central_netcore.Dto.FlatImage;
using prop_central_netcore.Service.Interfaces;
using prop_central_netcore.Shared.Enums;

namespace prop_central_netcore.Service
{
	public class FlatImageService : IFlatImageService
    {
        private readonly IFlatImageRepository _flatImageRepository;

        public FlatImageService(IFlatImageRepository flatImageRepository)
        {
            _flatImageRepository = flatImageRepository;
        }

        public async Task AddImage(FlatImageDto model)
        {
            model.StatusId = FlatImagesEnum.Gallery;
            await _flatImageRepository.AddImage(ObjectMapper.Mapper.Map<FlatImages>(model));
        }

        public async Task AddRoomImage(FlatImageDto model)
        {
            await _flatImageRepository.AddImage(ObjectMapper.Mapper.Map<FlatImages>(model));
        }

        public async Task AddProfilePicture(FlatImageDto model)
        {
            model.StatusId = FlatImagesEnum.ProfilePicture;
            await _flatImageRepository.AddImage(ObjectMapper.Mapper.Map<FlatImages>(model));
        }

        public async Task<FlatImageDto> GetProfilePicture(Guid flatId)
        {
            return ObjectMapper.Mapper.Map<FlatImageDto>(await _flatImageRepository.GetFlatProfilePicture(flatId));
        }

        public void AddRoomImage(FlatImageDto model, string[] ImageUrl)
        {
            Parallel.ForEach(ImageUrl, async Image => await AddRoomImage(new FlatImageDto
            {
                ImageUrl = Image,
                StatusId = FlatImagesEnum.Room,
                FlatId = model.FlatId,
                FlatRoomtypeId = model.FlatRoomtypeId
            }));
        }

        public async Task<List<FlatImageDto>> GetAllFlatImagesExcludeProfilePicture(Guid FlatId)
        {
            return ObjectMapper.Mapper.Map<List<FlatImageDto>>(await _flatImageRepository.GetAllFlatImagesExcludeProfilePicture(FlatId));
        }

        public async Task<List<FlatImageDto>> GetAllImagesForARoom(Guid RoomtypeId)
        {
            return ObjectMapper.Mapper.Map<List<FlatImageDto>>(await _flatImageRepository.GetAllImagesForARoom(RoomtypeId));
        }

        public async Task<List<FlatImageDto>> GetGalleryImagesForAFlat(Guid FlatId)
        {
            return await GetAllFlatImagesExcludeProfilePicture(FlatId);
        }
    }
}

