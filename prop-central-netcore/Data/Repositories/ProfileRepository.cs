using prop_central_netcore.Data.Entities.Profile;
using System.Data;
using Microsoft.Data.SqlClient;
using prop_central_netcore.Data.EntityFrameworkCore;
using prop_central_netcore.Data.Interfaces;

namespace prop_central_netcore.Data.Repositories
{
	public class ProfileRepository : IProfileRepository
    {

        public async Task AddProFile(Guid UserId, CancellationToken cancellationToken = default)
        {
            var parameters = new SqlParameter[]
            {
               new SqlParameter("@userId", UserId)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("AddProfile", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {

                }
            }
        }

        public async Task AddProFilePicture(ProfilePicture model, CancellationToken cancellationToken = default)
        {
            var parameters = new SqlParameter[]
            {
               new SqlParameter("@profileId", model.ProfileId),
            new SqlParameter("@imageUrl", model.ImageUrl)
        };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("AddProfilePicture", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {

                }
            }
        }

        public async Task UpdateProFile(Profile model, CancellationToken cancellationToken = default)
        {
            var parameters = new SqlParameter[]
            {
               new SqlParameter("@profileId", model.Id),
            new SqlParameter("@bio", model.Bio),
            new SqlParameter("@homeTown", model.HomeTown)
        };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("UpdateProfile", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {

                }
            }
        }

        public async Task<Profile> GetFullProfileByUserId(Guid UserId, CancellationToken cancellationToken = default)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@userId", UserId)
        };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("GetFullProfileByUserId", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToObject<Profile>();
                }
            }
        }

        public async Task<List<Profile>> SearchUser(string keyword,CancellationToken cancellationToken = default)
        {
            var parameters = new SqlParameter[]
            {
               new SqlParameter("@keyWord", keyword)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("SearchUser", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToList<Profile>();
                }
            }
        }

        public async Task<string> GetProfilePicture(Guid profileId, CancellationToken cancellationToken = default)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@profileId", profileId)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("GetProfilePicture", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToObject<string>();
                }
            }
        }

    }
}

