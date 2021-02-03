using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Models.DTO
{
    public class CheckoutDTO
    {
        public string Subject { get; set; }
        public int PriceSum { get; set; }
        public List<BagItem> BagItems { get; set; }
        public CustomerInfo CustomerInfo { get; set; }
        public string ShippingMethod { get; set; }
    }
}
