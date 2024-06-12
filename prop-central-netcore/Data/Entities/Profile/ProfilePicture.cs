using System;
namespace prop_central_netcore.Data.Entities.Profile
{
    public class ProfilePicture : BasePrimaryKey
    {
        public Guid ProfileId { get; set; }
        public DateTime DateAdded { get; set; }
        public string ImageUrl { get; set; }
    }
}

