using System;
using System.ComponentModel.DataAnnotations;
using prop_central_netcore.Dto.Amenities;
using prop_central_netcore.Dto.Profile;
using prop_central_netcore.Dto.RoomType;

namespace prop_central_netcore.Dto.Flats
{
	public class CreateUpdateFlatDto : BasePrimaryKeyDto
	{
        [Display(Name = "Flat Name")]
        public string? Name { get; set; }
        public string? AliasName { get; set; }
        [Display(Name = "Address")]
        public string? Address { get; set; }
        [Display(Name = "Description")]
        public string? Description { get; set; }
        [Display(Name = "Renting Price")]
        public decimal RentingPrice { get; set; }
        [Display(Name = "Deposite Price")]

        public decimal Deposit { get; set; }
        public int Status { get; set; }

        [Display(Name = "Flat PhoneNumber")]
        public string? PhoneNumber { get; set; }
        [Display(Name = "Status")]
        public string? StatusDescription { get; set; }
        [Display(Name = "Flat Email")]
        public string? Email { get; set; }
        public Guid UserId { get; set; }
        public Guid[] Amenities { get; set; }
        public Guid[] RoomTypes { get; set; }
        public Guid LandLord { get; set; }

        public string? City { get; set; }
        public string? Surbub { get; set; }
        public List<AmenitiesDto> ListAmenities { get; set; }
        public List<RoomTypeDto> ListRoomTypes { get; set; }
        public ProfileDto UserProfile { get; set; }
    }
}

