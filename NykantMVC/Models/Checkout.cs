using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models
{
    public class Checkout
    {
        public Customer Customer { get; set; }
        public Shipping Shipping { get; set; }
        public Order Order { get; set; }
        public List<BagItem> BagItems { get; set; }
        public int TotalPrice { get; set; }
        public Stage Stage { get; set; }
    }
    public enum Stage
    {
        customer = 1,
        shipping = 2,
        payment = 3,
        completed = 4,
        cancelled = 5
    }
}
