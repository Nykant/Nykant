using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models
{
    public class Refund
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int ReturnFee { get; set; }
        public int QualityFee { get; set; }
        public string Products { get; set; }
        public int PaymentCaptureId { get; set; }
        public PaymentCapture PaymentCapture { get; set; }
    }
}
