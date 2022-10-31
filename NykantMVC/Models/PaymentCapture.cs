using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models
{
    public class PaymentCapture
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public string PaymentIntent_Id { get; set; }
        public bool Captured { get; set; }
        public bool Refunded { get; set; }
        public bool MobilePay { get; set; }
        public Refund Refund { get; set; }
        public bool Test { get; set; } = false;
        public Invoice Invoice { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
