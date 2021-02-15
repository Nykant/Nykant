using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Models
{
    public class ShippingDelivery
    {
        [Key]
        public int Id { get; set; }
        public int ShippingId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
