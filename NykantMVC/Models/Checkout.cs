using NykantMVC.Models.XmlModels;
using System.Collections.Generic;

namespace NykantMVC.Models
{
    public class Checkout
    {
        public int CustomerInfId { get; set; }
        public ShippingDelivery ShippingDelivery { get; set; }
        public List<BagItem> BagItems { get; set; }
        public string TotalPrice { get; set; }
        public string SubTotalPrice { get; set; }
        public string Taxes { get; set; }
        public Stage Stage { get; set; }
        public ParcelShopSearchResult ParcelShopSearchResult { get; set; }
    }
    public enum Stage
    {
        unset = 0,
        customerInf = 1,
        shipping = 2,
        payment = 3,
        completed = 4
    }
}
