using System;
namespace prop_central_netcore.Data.Entities.Messaging
{
    public class Message : BasePrimaryKey
    {
        public Guid From { get; set; }
        public Guid To { get; set; }
        public Guid ChatViewId { get; set; }
        public string Body { get; set; }
        public DateTime DateCreated { get; set; }
        public int StatusId { get; set; }
        public bool IsFromInternal { get; set; }
    }
}

