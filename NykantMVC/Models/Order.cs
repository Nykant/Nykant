using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NykantMVC.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public string TotalPrice { get; set; }
        [Required]
        public string Taxes { get; set; }
        [Required]
        public string TaxLessPrice { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public Status Status { get; set; }
        public string Discount { get; set; }
        [ForeignKey("Code")]
        public string CouponCode { get; set; }
        public Coupon Coupon { get; set; }
        public double WeightInKg { get; set; }
        public DateTime EstimatedDelivery { get; set; }
        //public bool IsBackOrder { get; set; } = false;
        [Required]
        public int PaymentCaptureId { get; set; }
        public PaymentCapture PaymentCapture { get; set; }
        public ShippingDelivery ShippingDelivery { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public List<BagItem> BagItems { get; set; }
    }

    public enum Status
    {
        Unset = 0,
        Pending = 1,
        Sent = 2,
        Received = 3,
        Cancelled = 4,
        Error = 5
    }
}
