using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Models
{
    public class Shipping : Customer
    {
        [Key]
        public int ShippingId { get; set; }
        public ShippingDelivery ShippingDelivery { get; set; }
    }
}
