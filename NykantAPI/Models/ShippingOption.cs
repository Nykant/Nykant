using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Models
{
    public class ShippingOption
    {
        [Key]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
