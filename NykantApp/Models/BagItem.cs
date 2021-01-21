using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantApp.Models
{
    public class BagItem
    {
        public string BagId { get; set; }
        public Bag Bag { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
