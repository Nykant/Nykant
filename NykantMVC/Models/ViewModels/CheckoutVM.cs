using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models.ViewModels
{
    public class CheckoutVM
    {
        public Checkout Checkout { get; set; }
        public List<ShippingDelivery> ShippingDeliveries { get; set; }
        public CustomerInf CustomerInf { get; set; }
        public CardInfo CardInfo { get; set; }
    }
}
