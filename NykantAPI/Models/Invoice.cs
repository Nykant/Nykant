using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int PaymentCaptureId { get; set; }
        public PaymentCapture PaymentCapture { get; set; }
        public string TotalPrice { get; set; }
        public string Taxes { get; set; }
        public string TaxLessPrice { get; set; }
    }
}
