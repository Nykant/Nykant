using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Subject { get; set; }
        [Required]
        public int CustomerInfId { get; set; }
        public CustomerInf CustomerInf { get; set; }
        [Required]
        public int ShippingDeliveryId { get; set; }
        public ShippingDelivery ShippingDelivery { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public string TotalPrice { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public string PaymentIntent_Id { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }

    public enum Status
    {
        Unset = 0,
        Accepted = 1,
        Processed = 2,
        Received = 3,
        Cancelled = 4
    }
}
