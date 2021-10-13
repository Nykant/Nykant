using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NykantMVC.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Subject { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public string TotalPrice { get; set; }
        [Required]
        public string SubtotalPrice { get; set; }
        [Required]
        public string Taxes { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public string PaymentIntent_Id { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public ShippingDelivery ShippingDelivery { get; set; }
    }

    public enum Status
    {
        Unset = 0,
        Pending = 1,
        Sent = 2,
        Received = 3,
        Cancelled = 4
    }
}
