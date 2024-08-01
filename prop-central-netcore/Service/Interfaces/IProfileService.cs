using System;
using prop_central_netcore.Dto.Profile;

namespace prop_central_netcore.Service.Interfaces
{
	public interface IProfileService
	{
        Task AddProfile(Guid UserId);
        Task<ProfileDto> GetFullProfileByUserId(Guid UserId);
        Task<List<ProfileDto>> SearchUser(string Keyword);
        Task UpdateProFile(ProfileDto model);
    }
}

