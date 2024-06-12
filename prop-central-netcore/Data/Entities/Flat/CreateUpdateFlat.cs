using System;
namespace prop_central_netcore.Data.Entities.Flat
{
    public class CreateUpdateFlat : BasePrimaryKey
    {

        public string Name { get; set; }
        public string AliasName { get; set; }

        public string Address { get; set; }
        public string Description { get; set; }

        public decimal RentingPrice { get; set; }

        public decimal Deposit { get; set; }
        public int Status { get; set; }
        public string StatusDescription { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Guid UserId { get; set; }
        public Guid LandLord { get; set; }

        public string City { get; set; }
        public string Surbub { get; set; }
    }
}

