using System;
namespace prop_central_netcore.Data.Entities.Messaging
{
    public class ChatView : BasePrimaryKey
    {
        public Guid User1 { get; set; }
        public Guid User2 { get; set; }
        public Guid BookingId { get; set; }
        public int Type { get; set; }
        public DateTime DateCreated { get; set; }
        public int StatusId { get; set; }
    }
}

