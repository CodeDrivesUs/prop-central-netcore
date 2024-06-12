using System;
namespace prop_central_netcore.Data.Entities.Flat
{
    public class FlatView : BasePrimaryKey
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal RentingPrice { get; set; }
        public string City { get; set; }
        public string Surbub { get; set; }
        public string AliasName { get; set; }
        public decimal Deposit { get; set; }
    }

}
