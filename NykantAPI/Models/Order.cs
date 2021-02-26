using NykantAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Models
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
        public int TotalPrice { get; set; }
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
        Created = 1,
        Accepted = 2,
        Processed = 3,
        Failed = 4
    }
}
