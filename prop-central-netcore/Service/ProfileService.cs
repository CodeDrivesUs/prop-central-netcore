using System;
using prop_central_netcore.Data;
using prop_central_netcore.Data.Entities.Flat;
using prop_central_netcore.Data.Entities.Profile;
using prop_central_netcore.Data.Interfaces;
using prop_central_netcore.Data.Repositories;
using prop_central_netcore.Dto.Profile;
using prop_central_netcore.Dto.RoomType;
using prop_central_netcore.Service.Interfaces;

namespace prop_central_netcore.Service
{
	public class ProfileService: IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository)
		{
            _profileRepository = profileRepository;
		}

        public async Task AddProfile(Guid UserId)
        {
           await _profileRepository.AddProFile(UserId);
        }

        public async Task<ProfileDto> GetFullProfileByUserId(Guid UserId)
        {
            return ObjectMapper.Mapper.Map<ProfileDto>(await _profileRepository.GetFullProfileByUserId(UserId));
        }

        public async Task<List<ProfileDto>> SearchUser(string Keyword)
        {
            return ObjectMapper.Mapper.Map<List<ProfileDto>>(await _profileRepository.SearchUser(Keyword));
        }

        public async Task UpdateProFile(ProfileDto model)
        {
            await _profileRepository.UpdateProFile(ObjectMapper.Mapper.Map<Profile>(model));
            if (model.ImageUrl != null)
              await  _profileRepository.AddProFilePicture(new ProfilePicture { ImageUrl = model.ImageUrl, ProfileId = model.Id });
        }
    }
}

