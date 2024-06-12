using System;
namespace prop_central_netcore.Data.Entities.Flat
{
    public class Flat : BasePrimaryKey
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal RentingPrice { get; set; }

        public decimal Deposit { get; set; }
        public string Email { get; set; }

        public DateTime Date { get; set; }
        public string PhoneNumber { get; set; }
        public string ShortDescription { get; set; }
    }
}

