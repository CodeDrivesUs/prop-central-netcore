using System;
using NuGet.Protocol.Core.Types;
using prop_central_netcore.Data.Entities.Flat;
using prop_central_netcore.Shared.Enums;
using System.Data;
using prop_central_netcore.Data.Entities.Messaging;
using Microsoft.Data.SqlClient;
using prop_central_netcore.Data.EntityFrameworkCore;

namespace prop_central_netcore.Data.Repositories
{
	public class MessagingRepository
	{

        public async Task CreateChat(ChatView model, CancellationToken cancellationToken = default)
        {
            var parameters = new SqlParameter[]
            {
               new SqlParameter("@user1", model.User1),
           new SqlParameter("@user2", model.User2),
           new SqlParameter("@bookingId", model.BookingId),
           new SqlParameter("@type", model.Type),
           new SqlParameter("@bookingType", (int)ChatViewEnum.Booking),
           new SqlParameter("@statusId", (int)ChatStatuses.Active)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("CreateChat", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                  
                }
            }
        }

        public async Task<List<ChatView>> GetAllChatViewByUserId(Guid userId, CancellationToken cancellationToken = default)
        {
            var parameters = new SqlParameter[]
            {
               new SqlParameter("@userId", userId)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("GetAllChatViewsByUserId", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToList<ChatView>();
                }
            }
        }

        public async Task<ChatView> GetChatViewByBookingId(Guid Id, CancellationToken cancellationToken = default)
        {
            var parameters = new SqlParameter[]
            {
               new SqlParameter("@bookingId", Id)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("GetChatviewByBookingid", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToObject<ChatView>();
                }
            }
        }

        public async Task<List<Message>> GetAllMessagesByChatViewId(Guid chatviewId, CancellationToken cancellationToken = default)
        {
            var parameters = new SqlParameter[]
            {
               new SqlParameter("@chatViewId", chatviewId)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("GetAllMessagesByChatViewId", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await dataReader.MapToList<Message>();
                }
            }
        }

        public async Task AddMessage(Message model, CancellationToken cancellationToken = default)
        {
            var parameters = new SqlParameter[]
            {
               new SqlParameter("@body", model.Body),
           new SqlParameter("@chatViewId", model.ChatViewId),
           new SqlParameter("@from", model.From),
           new SqlParameter("@to", model.To),
           new SqlParameter("@isFromInternal", model.IsFromInternal),
           new SqlParameter("@statusId", (int)MessaginEnums.Submitted)
            };

            using (var command = await DbCommandsAndConnection.CreateCommandAsync("AddMessage", CommandType.StoredProcedure, parameters))
            {
                using (var dataReader = await command.ExecuteReaderAsync(cancellationToken))
                {

                }
            }
        }
    }
}

