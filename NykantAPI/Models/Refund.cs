using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Models
{
    public class Refund
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }
        public int ReturnFee { get; set; }
        public int QualityFee { get; set; }
        public string Products { get; set; }
        public int PaymentCaptureId { get; set; }
        public PaymentCapture PaymentCapture { get; set; }
    }
}
