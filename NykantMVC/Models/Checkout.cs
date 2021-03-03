using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models
{
    public class Checkout
    {
        public int CustomerInfId { get; set; }
        public CardInfo CardInfo { get; set; }
        public int ShippingDeliveryId { get; set; }
        public List<BagItem> BagItems { get; set; }
        public string TotalPrice { get; set; }
        public Stage Stage { get; set; }
    }
    public enum Stage
    {
        unset = 0,
        customerInf = 1,
        shippingDel = 2,
        payment = 3,
        completed = 4,
        cancelled = 5
    }
}
