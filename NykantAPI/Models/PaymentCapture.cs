using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Models
{
    public class PaymentCapture
    {
        [Key]
        public int Id { get; set; }
        public Order Order { get; set; }
        public string PaymentIntent_Id { get; set; }
        public bool Captured { get; set; }
        public Invoice Invoice { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
