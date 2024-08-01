using System;
using System.ComponentModel.DataAnnotations;

namespace prop_central_netcore.Dto.Flats
{
	public class FlatDto: BaseImageUrlDto
	{
        public string Name { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Renting Price")]
        public decimal RentingPrice { get; set; }
        [Display(Name = "Deposite Price")]

        public decimal Deposit { get; set; }
        public string Email { get; set; }

        public DateTime Date { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public string ShortDescription { get; set; }
    }
}

