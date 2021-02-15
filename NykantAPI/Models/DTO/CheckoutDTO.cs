using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Models.DTO
{
    public class CheckoutDTO
    {
        public BagDTO BagDTO { get; set; }
        public Customer Customer { get; set; }
        public Shipping Shipping { get; set; }
        public Order Order { get; set; }
    }
}
