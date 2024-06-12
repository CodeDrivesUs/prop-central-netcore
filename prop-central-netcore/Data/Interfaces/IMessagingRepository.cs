using System;
using prop_central_netcore.Data.Entities.Messaging;

namespace prop_central_netcore.Data.Interfaces
{
	public interface IMessagingRepository
	{
        Task<List<ChatView>> GetAllChatViewByUserId(Guid userId, CancellationToken cancellationToken = default);
        Task AddMessage(Message model, CancellationToken cancellationToken = default);
        Task CreateChat(ChatView model, CancellationToken cancellationToken = default);
        Task<List<Message>> GetAllMessagesByChatViewId(Guid chatviewId, CancellationToken cancellationToken = default);
        Task<ChatView> GetChatViewByBookingId(Guid Id, CancellationToken cancellationToken = default);
    }
}

