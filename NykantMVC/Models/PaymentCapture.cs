using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models
{
    public class PaymentCapture
    {
        public int Id { get; set; }
        public List<Order> Orders { get; set; }
        public string PaymentIntent_Id { get; set; }
        public bool Captured { get; set; }
        public Invoice Invoice { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
