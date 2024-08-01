using System;
using prop_central_netcore.Data.Entities.Profile;

namespace prop_central_netcore.Data.Interfaces
{
	public interface IProfileRepository
	{
        Task<List<Profile>> SearchUser(string keyword, CancellationToken cancellationToken = default);
        Task AddProFile(Guid UserId, CancellationToken cancellationToken = default);
        Task AddProFilePicture(ProfilePicture model, CancellationToken cancellationToken = default);
        Task UpdateProFile(Profile model, CancellationToken cancellationToken = default);
        Task<Profile> GetFullProfileByUserId(Guid UserId, CancellationToken cancellationToken = default);
        Task<string> GetProfilePicture(Guid profileId, CancellationToken cancellationToken = default);

    }
}

