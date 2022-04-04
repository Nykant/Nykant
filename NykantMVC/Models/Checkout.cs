using NykantMVC.Models.XmlModels;
using System.Collections.Generic;

namespace NykantMVC.Models
{
    public class Checkout
    {
        public Customer Customer { get; set; }
        //public ShippingDelivery ShippingDelivery { get; set; }
        public List<BagItem> BagItems { get; set; }
        public string TotalPrice { get; set; }
        public string Taxes { get; set; }
        public string TaxlessPrice { get; set; }
        public Stage Stage { get; set; }
        //public ParcelShopSearchResult ParcelShopSearchResult { get; set; }
    }
    public enum Stage
    {
        unset = 0,
        customerInf = 1,
        payment = 2,
        completed = 3
    }
}
