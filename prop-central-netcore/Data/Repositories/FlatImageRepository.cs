using System;
using NuGet.Protocol.Core.Types;
using prop_central_netcore.Shared.Enums;
using System.Data;
using prop_central_netcore.Data.Entities.FlatImages;
using Microsoft.Data.SqlClient;
using prop_central_netcore.Data.Entities.Flat;
using prop_central_netcore.Data.EntityFrameworkCore;
using prop_central_netcore.Data.Interfaces;

namespace prop_central_netcore.Data.Repositories
{
	public class FlatImageRepository : IFlatImageRepository
    {
        public async Task AddImage(FlatImages flatImages, CancellationToken cancellationToken = default)
        {
            var query = string.Format(@"INSERT INTO [dbo].[FlatImages]  ([FlatId],[StatusId],[ImageUrl]) VALUES ('{0}','{1}','{2}')", flatImages.FlatId, (int)flatImages.StatusId, flatImages.ImageUrl);

            using (var command = await DbCommandsAndConnection.CreateCommandAsync(query, CommandType.Text))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                }
            }
        }

        public async Task AddRoomImage(FlatImages flatImages, CancellationToken cancellationToken = default)
        {

            var parameters = new SqlParameter[]
            {
                 new SqlParameter("@flatroomtypid", flatImages.FlatRoomtypeId.ToString()),
            new SqlParameter("@imageUrl", flatImages.ImageUrl),
            new SqlParameter("@statusId", (int)FlatImagesEnum.Room)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("AddFlatRoomImage", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                }
            }
        }

        public async Task<List<FlatImages>> GetAllImagesForARoom(Guid roomId, CancellationToken cancellationToken = default)
        {

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@roomId", roomId)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("GetAllRoomImagesByRoomId", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToList<FlatImages>();
                }
            }
        }

        public async Task<FlatImages> GetFlatProfilePicture(Guid flatId, CancellationToken cancellationToken = default)
        {
            var query = string.Format(@"SELECT [Id], [FlatId],[StatusId],[ImageUrl] FROM [dbo].[FlatImages]  WHERE FlatId='{0}' and StatusId='{1}'", flatId, (int)FlatImagesEnum.ProfilePicture);

            using (var command = await DbCommandsAndConnection.CreateCommandAsync(query, CommandType.Text))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToObject<FlatImages>();
                }
            }
        }

        public async Task<List<FlatImages>> GetAllFlatImagesExcludeProfilePicture(Guid flatId, CancellationToken cancellationToken = default)
        {

            var query = string.Format(@"SELECT [Id], [FlatId],[StatusId],[ImageUrl] FROM [dbo].[FlatImages]  WHERE FlatId='{0}' and StatusId !='{1}'", flatId, (int)FlatImagesEnum.ProfilePicture);

            using (var command = await DbCommandsAndConnection.CreateCommandAsync(query, CommandType.Text))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToList<FlatImages>();
                }
            }
        }
    }
}


