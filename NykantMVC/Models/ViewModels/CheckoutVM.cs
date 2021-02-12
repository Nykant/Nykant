using NykantMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models.ViewModels
{
    public class CheckoutVM
    {
        public string Subject { get; set; }
        public int PriceSum { get; set; }
        public List<BagItem> BagItems { get; set; }
        public CustomerInfo CustomerInfo { get; set; }
        public ShippingOption ShippingOption { get; set; }
    }
}
