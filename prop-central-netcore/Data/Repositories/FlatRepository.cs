using System.Data;
using Microsoft.Data.SqlClient;
using prop_central_netcore.Data.Entities.Flat;
using prop_central_netcore.Data.EntityFrameworkCore;
using prop_central_netcore.Data.Interfaces;
using prop_central_netcore.Shared.Enums;

namespace prop_central_netcore.Data.Repositories
{
    public class FlatRepository : IFlatRepository
    {

        public async Task<Guid> CreateFlat(CreateUpdateFlat createUpdateFlat, CancellationToken cancellationToken = default)
        {

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", createUpdateFlat.Name),
                new SqlParameter("@PhoneNumber", createUpdateFlat.PhoneNumber),
                new SqlParameter("@Address", createUpdateFlat.Address),
                new SqlParameter("@Email", createUpdateFlat.Email),
                new SqlParameter("@userid", createUpdateFlat.UserId),
                new SqlParameter("@statusId", (int)FlatStatusEnum.ApplicationSubmitted),
                new SqlParameter("@Rent", createUpdateFlat.RentingPrice),
                new SqlParameter("@Deposit", createUpdateFlat.Deposit)

            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("CreateFlatAndHistory", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToObject<Guid>();
                }
            }
        }

        public async Task AcceptFlat(CreateUpdateFlat createUpdateFlat, CancellationToken cancellationToken = default)
        {

            var parameters = new SqlParameter[]
            {
                 new SqlParameter("@Name", createUpdateFlat.Name),
                new SqlParameter("@PhoneNumber", createUpdateFlat.PhoneNumber),
            new SqlParameter("@Address", createUpdateFlat.Address),
            new SqlParameter("@Email", createUpdateFlat.Email),
            new SqlParameter("@userid", createUpdateFlat.UserId),
            new SqlParameter("@statusId", (int)FlatStatusEnum.ApplicationAccepted),
            new SqlParameter("@Rent", createUpdateFlat.RentingPrice),
            new SqlParameter("@Deposit", createUpdateFlat.Deposit),
            new SqlParameter("@FlatId", createUpdateFlat.Id)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("AcceptFlatAndHistory", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                }
            }
        }

        public async Task SubmitApplicationForActivation(CreateUpdateFlat createUpdateFlat, CancellationToken cancellationToken = default)
        {

            var parameters = new SqlParameter[]
            {
               new SqlParameter("@userid", createUpdateFlat.UserId),
               new SqlParameter("@statusId", (int)FlatStatusEnum.ApplicationSubmitedForActivation),
               new SqlParameter("@FlatId", createUpdateFlat.Id)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("AccapetPhotosAndHistory", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                }
            }
        }

        public async Task AddRoomOrAmenitie(FlatRoomsAmenities flatRoomsAmenities, CancellationToken cancellationToken = default)
        {

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@flatId", flatRoomsAmenities.FlatId),
             new SqlParameter("@AmenitieId", flatRoomsAmenities.AmenityId),
             new SqlParameter("@RoomTypeId", flatRoomsAmenities.RoomTypeId),
             new SqlParameter("@Type", flatRoomsAmenities.Type),
             new SqlParameter("@Deposit", flatRoomsAmenities.Deposit),
             new SqlParameter("@Rent", flatRoomsAmenities.Rent)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("AddRoomsOrAmenities", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                }
            }
        }

        public async Task<List<Flat>> GetAllFlatsByStatusId(int statusId, CancellationToken cancellationToken = default)
        {

            var parameters = new SqlParameter[]
            {
               new SqlParameter("@statusId", statusId)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("GetAllFlatsByStatusId", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToList<Flat>();
                }
            }
        }

        public async Task<List<Flat>> GetAllFlatsExeptStatusId(int statusId, CancellationToken cancellationToken = default)
        {

            var parameters = new SqlParameter[]
            {
               new SqlParameter("@statusId", statusId)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("GetAllFlatsExeptStatusId", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToList<Flat>();
                }
            }
        }

        public async Task<List<FlatView>> GetLatestFlat(CancellationToken cancellationToken = default)
        {

            var parameters = new SqlParameter[]
            {
               new SqlParameter("@flatStatusId", (int)FlatStatusEnum.Active),
            new SqlParameter("@imageStatusId", (int)FlatImagesEnum.Gallery)
        };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("GetLatestFlats", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToList<FlatView>();
                }
            }
        }

        public async Task<CreateUpdateFlat> GetFlatApplication(Guid flatId, CancellationToken cancellationToken = default)
        {

            var parameters = new SqlParameter[]
            {
               new SqlParameter("@flatId", flatId)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("GetFlatApplication", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToObject<CreateUpdateFlat>();
                }
            }
        }

        public async Task<Guid> GetApplicantUserId(Guid flatId, CancellationToken cancellationToken = default)
        {

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@statusId", (int)FlatStatusEnum.ApplicationSubmitted),
             new SqlParameter("@flatId", flatId)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("GeFlatApplicantUserId", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToObject<Guid>();
                }
            }
        }

        public async Task AddToFlatHistory(AddToFlatHistory addToFlatHistory, CancellationToken cancellationToken = default)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@statusId", addToFlatHistory.statusId),
             new SqlParameter("@flatId", addToFlatHistory.FlatId),
             new SqlParameter("@userId", addToFlatHistory.UserId.ToString())
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("AddToFlatHistory", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                }
            }
        }

        public async Task AddLandLord(AddLandLord addLandLord, CancellationToken cancellationToken = default)
        {
            var parameters = new SqlParameter[]
            {
               new SqlParameter("@userId", addLandLord.UserId.ToString()),
            new SqlParameter("@flatId", addLandLord.FlatId)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("AddLandLord", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                }
            }
        }

        public async Task<List<FlatView>> GetPaginatedListFlats(int startrow, int rowsperpage, string keyword, CancellationToken cancellationToken = default)
        {

            var parameters = new SqlParameter[]
            {
             new SqlParameter("@startRow", startrow),
             new SqlParameter("@rowsPerPage", rowsperpage),
             new SqlParameter("@isCount", false),
             new SqlParameter("@keyword", keyword),
             new SqlParameter("@imageStatusId", (int)FlatImagesEnum.ProfilePicture),
             new SqlParameter("@statusId", (int)FlatStatusEnum.Active)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("GetPaginatedFlats", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToList<FlatView>();
                }
            }
        }

        public async Task<List<FlatView>> GetAllFlatsForFindFlats(SearchFlat model, CancellationToken cancellationToken = default)
        {

            var parameters = new SqlParameter[]
            {
             new SqlParameter("@surbub", model.Surbub),
             new SqlParameter("@city", model.City),
             new SqlParameter("@roomtypeId", model.RoomTypeId),
             new SqlParameter("@isSearched", model.IsSearch),
             new SqlParameter("@keyword", model.KeyWord),
             new SqlParameter("@statusId", (int)FlatImagesEnum.ProfilePicture)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("GetAllFlatsForFindFlats", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToList<FlatView>();
                }
            }
        }

        public async Task<int> GetCountPaginatedListFlats(string keyword, CancellationToken cancellationToken = default)
        {

            var parameters = new SqlParameter[]
            {
                 new SqlParameter("@isCount", true),
             new SqlParameter("@keyword", keyword),
             new SqlParameter("@statusId", (int)FlatStatusEnum.Active),
             new SqlParameter("@imageStatusId", (int)FlatImagesEnum.ProfilePicture),
             new SqlParameter("@startRow", 0),
             new SqlParameter("@rowsPerPage", 0)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("GetPaginatedFlats", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToObject<int>();
                }
            }
        }

        public async Task<List<FlatRoomTypes>> GetFlatRoomTypesByFlatId(Guid flatId, CancellationToken cancellationToken = default)
        {

            var parameters = new SqlParameter[]
            {
              new SqlParameter("@flatId", flatId)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("GetFlatRoomTypes", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToList<FlatRoomTypes>();
                }
            }
        }

        public async Task<FlatRoomTypes> GetFlatRoomByRoomId(Guid roomId, CancellationToken cancellationToken = default)
        {

            var parameters = new SqlParameter[]
            {
               new SqlParameter("@roomId", roomId)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("GetFlatRoomByRoomId", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToObject<FlatRoomTypes>();
                }
            }
        }

        public async Task UpdateFlateRoomType(FlatRoomTypes model, CancellationToken cancellationToken = default)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@roomId", model.Id),
             new SqlParameter("@rent", model.Rent),
             new SqlParameter("@deposit", model.Deposit),
             new SqlParameter("@description", model.Description)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("UpdateFlateRoomType", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                }
            }
        }

        public async Task ActivateFlat(CreateUpdateFlat model, CancellationToken cancellationToken = default)
        {
            var parameters = new SqlParameter[]
            {
                 new SqlParameter("@flatId", model.Id),
             new SqlParameter("@Name", model.Name),
             new SqlParameter("@PhoneNumber", model.PhoneNumber),
             new SqlParameter("@Address", model.Address),
             new SqlParameter("@Email", model.Email),
             new SqlParameter("@userid", model.UserId),
             new SqlParameter("@statusId", (int)FlatStatusEnum.Active),
             new SqlParameter("@city", model.City),
             new SqlParameter("@surbub", model.Surbub),
             new SqlParameter("@aliasName", model.AliasName),
             new SqlParameter("@landLord", model.LandLord)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("FlatActivation", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                }
            }
        }

        public async Task<List<CreateUpdateFlat>> GetUserFlatListByStatusId(Guid UserId, int statusId, CancellationToken cancellationToken = default)
        {

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@userId", UserId),
             new SqlParameter("@statusId", statusId)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("GetUserFlatByStatusId", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToList<CreateUpdateFlat>();
                }
            }
        }

        public async Task<List<CreateUpdateFlat>> GetAllFlatsForLAndLordByUserId(Guid UserId, CancellationToken cancellationToken = default)
        {

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@userId", UserId),
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("GetAllFlatsForLAndLordByUserId", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToList<CreateUpdateFlat>();
                }
            }
        }
  
        public async Task<List<CreateUpdateFlat>> GetAllUserFlatList(Guid UserId, int statusId, CancellationToken cancellationToken = default)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@userId", UserId),
             new SqlParameter("@statusId", statusId)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("GetUserFlatByStatusId", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToList<CreateUpdateFlat>();
                }
            }
        }

        public async Task<List<FlatView>> GetAllFlatsForPlaceName(string placeName, CancellationToken cancellationToken = default)
        {
            var parameters = new SqlParameter[]
            {
               new SqlParameter("@placeName", placeName),
             new SqlParameter("@flatStatusId", (int)FlatStatusEnum.Active),
             new SqlParameter("@imageStatusId", (int)FlatImagesEnum.ProfilePicture)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("GetAllFlatsForPlaceName", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToList<FlatView>();
                }
            }
        }
   
    }
}

