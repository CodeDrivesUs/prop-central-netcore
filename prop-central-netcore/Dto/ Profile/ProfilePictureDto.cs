using System;
namespace prop_central_netcore.Dto.Profile
{
	public class ProfilePictureDto:BaseImageUrlDto
	{
        public Guid ProfileId { get; set; }
        public DateTime DateAdded { get; set; }
    }
}

