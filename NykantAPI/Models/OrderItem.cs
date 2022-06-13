using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Models
{
    public class OrderItem
    {
        [Required]
        public int OrderId { get; set; }
        public long Price { get; set; }
        public Order Order { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
