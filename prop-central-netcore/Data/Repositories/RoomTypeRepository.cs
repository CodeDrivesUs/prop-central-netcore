using System;
using NuGet.Protocol.Core.Types;
using System.Data;
using prop_central_netcore.Data.Entities.RoomType;
using Microsoft.Data.SqlClient;
using prop_central_netcore.Data.Entities.Amenities;
using prop_central_netcore.Data.EntityFrameworkCore;
using prop_central_netcore.Data.Entities.Flat;
using prop_central_netcore.Data.Interfaces;

namespace prop_central_netcore.Data.Repositories
{
	public class RoomTypeRepository : IRoomTypeRepository
    {

        public async Task<List<RoomType>> GetAll( CancellationToken cancellationToken = default)
        {
            var query = @"SELECT * FROM [dbo].[RoomTypes]";
            using (var command = await DbCommandsAndConnection.CreateCommandAsync(query, CommandType.Text))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToList<RoomType>();
                }
            }
        }

        public async Task<List<RoomType>> GetRoomTypeByFlatId(Guid flatId, CancellationToken cancellationToken = default)
        {
            var parameters = new SqlParameter[]
          {
                new SqlParameter("@flatId", flatId)
          };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("GetFlatRoomTypes", CommandType.StoredProcedure,parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToList<RoomType>();
                }
            }
        }

        public async Task CreateRoomType(RoomType model, CancellationToken cancellationToken = default)
        {
            var query = string.Format($"INSERT INTO [dbo].[RoomTypes] ([Name],[Description],[NumberOfPeople]) VALUES('{model.Name}','{model.Description}',{model.NumberOfPeople})");

            using var command = await DbCommandsAndConnection.CreateCommandAsync(query, CommandType.Text);
            using var dataReader = await command.ExecuteReaderAsync(cancellationToken);
        }

        public async Task DeleteRoomType(Guid Id, CancellationToken cancellationToken = default)
        {
            var query = string.Format(@"DELETE  FROM  [dbo].[RoomTypes] WHERE [Id] = '{0}'", Id);

            using var command = await DbCommandsAndConnection.CreateCommandAsync(query, CommandType.Text);
            using var dataReader = await command.ExecuteReaderAsync(cancellationToken);
        }

        public async Task DeleteRoomTypeForAFlat(Guid Id, Guid flatId, CancellationToken cancellationToken = default)
        {
            var query = string.Format($"DELETE  FROM  [dbo].[FlatRoomTypes] WHERE [Id]='{Id}' AND [FlatId]='{flatId}'");

            using var command = await DbCommandsAndConnection.CreateCommandAsync(query, CommandType.Text);
            using var dataReader = await command.ExecuteReaderAsync(cancellationToken);
        }

        public async Task<RoomType> Get(Guid id, CancellationToken cancellationToken = default)
        {
            var query = string.Format(@"SELECT * FROM  [dbo].[FlatRoomTypes] WHERE [Id] = '{0}'", id);

            using (var command = await DbCommandsAndConnection.CreateCommandAsync(query, CommandType.Text))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToObject<RoomType>();
                }
            }
        }

    }
}

