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
        public List<Order> Orders { get; set; }
        public string PaymentIntent_Id { get; set; }
        public bool Captured { get; set; }
    }
}
