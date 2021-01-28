using NykantMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.ViewModels
{
    public class CheckoutVM
    {
        public int PriceSum { get; set; }
        public IEnumerable<BagItem> BagItems { get; set; }
        public CustomerInfo CustomerInfo { get; set; }
        public string ShippingMethod { get; set; }
    }
}
