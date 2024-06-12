using System;
using NuGet.Protocol.Core.Types;
using prop_central_netcore.Data.Entities.PopularPlaces;
using prop_central_netcore.Shared.Enums;
using System.Data;
using Microsoft.Data.SqlClient;
using prop_central_netcore.Data.EntityFrameworkCore;
using prop_central_netcore.Data.Interfaces;

namespace prop_central_netcore.Data.Repositories
{
	public class PopularPlacesRepository : IPopularPlacesRepository
    {


        public async Task AddPopularPlaces(CreatePopularPlace model, CancellationToken cancellationToken = default)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@imageUrl", model.ImageUrl),
                new SqlParameter("@placeName", model.PlaceName)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("AddPopularPlace", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {

                }
            }
        }

        public async Task<PopularPlaces> GetPopularPlacesById(Guid placeId, CancellationToken cancellationToken = default)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@placeId", placeId),
                new SqlParameter("@stausId", (int)FlatStatusEnum.Active)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("GetPopularPlaceById", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToObject<PopularPlaces>();
                }
            }
        }

        public async Task<List<Province>> GetAllProvinces( CancellationToken cancellationToken = default)
        {
            using (var command = await DbCommandsAndConnection.CreateCommandAsync("GetAllProvinces", CommandType.StoredProcedure))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToList<Province>();
                }
            }
        }

        public async Task<List<City>> GetAllCities(CancellationToken cancellationToken = default)
        {
            using (var command = await DbCommandsAndConnection.CreateCommandAsync("GetAllCity", CommandType.StoredProcedure))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToList<City>();
                }
            }
        }

        public async Task<List<Surbub>> GetAllSurbubs(CancellationToken cancellationToken = default)
        {
            using (var command = await DbCommandsAndConnection.CreateCommandAsync("GetAllSurbubs", CommandType.StoredProcedure))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToList<Surbub>();
                }
            }
        }

        public async Task<List<PopularPlaces>> GetAllPopularPlaces(CancellationToken cancellationToken = default)
        {
            using (var command = await DbCommandsAndConnection.CreateCommandAsync("GetAllPopularPlace", CommandType.StoredProcedure))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToList<PopularPlaces>();
                }
            }
        }

    }
}

