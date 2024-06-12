using System;
namespace prop_central_netcore.Data.Entities.Flat
{
    public class AddToFlatHistory
    {
        public Guid FlatId { get; set; }
        public Guid UserId { get; set; }
        public int statusId { get; set; }
    }
}

