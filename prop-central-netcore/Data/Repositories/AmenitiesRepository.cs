using System;
using Microsoft.Data.SqlClient;
using System.Data;
using prop_central_netcore.Data.Entities.Amenities;
using prop_central_netcore.Data.EntityFrameworkCore;
using prop_central_netcore.Data.Interfaces;

namespace prop_central_netcore.Data.Repositories
{
	public class AmenitiesRepository: IAmenitiesRepository
    {

        public async Task Add(Amenities model, CancellationToken cancellationToken = default)
        {
            var query = string.Format(@"INSERT INTO [dbo].[Amenities]  ([Name],[ImageUrl]) VALUES ('{0}','{1}')", model.Name, model.ImageUrl);

            using var command = await DbCommandsAndConnection.CreateCommandAsync(query, CommandType.Text);
            using var dataReader = await command.ExecuteReaderAsync(cancellationToken);
        }

        public async Task Update(Amenities model, CancellationToken cancellationToken = default)
        {
            var query = string.Format(@"UPDATE [dbo].[Amenities]  SET [Name] = '{0}'  ,[ImageUrl] = '{1}'WHERE  AmenitieID= {2}", model.Name, model.ImageUrl, model.Id);

            using var command = await DbCommandsAndConnection.CreateCommandAsync(query, CommandType.Text);
            using var dataReader = await command.ExecuteReaderAsync(cancellationToken);
        }

        public async Task DeleteAmenitiy(Guid id, Guid flatId, CancellationToken cancellationToken = default)
        {
            var query = string.Format($"DELETE  FROM  [dbo].[FlatAmenities] WHERE [AmenitieId]='{id}' AND [FlatId]='{flatId}'");
            using (var command = await DbCommandsAndConnection.CreateCommandAsync(query, CommandType.Text))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken)) { }
            }
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken = default)
        {
            var query = string.Format(@"DELETE  FROM  [dbo].[Amenities] WHERE [Id] = '{0}'", id);

            using (var command = await DbCommandsAndConnection.CreateCommandAsync(query, CommandType.Text))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken)) { }
            }
        }

        public async Task<Amenities> Get(Guid id, CancellationToken cancellationToken = default)
        {
            var query = string.Format(@"SELECT * FROM  [dbo].[Amenities] WHERE [Id] = '{0}'", id);

            using (var command = await DbCommandsAndConnection.CreateCommandAsync(query, CommandType.Text ))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToObject<Amenities>();
                }
            }
        }

        public async Task<List<Amenities>> GetAmenitiesByFlatId(Guid flatId, CancellationToken cancellationToken = default)
        {

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@flatId", flatId)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("GetAllAmenitiesByFlatId", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToList<Amenities>();
                }
            }
        }

        public async Task<List<Amenities>> GetAll(CancellationToken cancellationToken = default)
        {
            var query = @"SELECT * FROM [dbo].[Amenities] ORDER BY Id";

            using (var command = await DbCommandsAndConnection.CreateCommandAsync(query, CommandType.Text))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToList<Amenities>();
                }
            }
        }

       
    }
}

