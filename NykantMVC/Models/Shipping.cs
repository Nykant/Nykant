using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models
{
    public class Shipping : Customer
    {
       public int ShippingId { get; set; }
       public ShippingDelivery ShippingDelivery { get; set; }
    }
}
