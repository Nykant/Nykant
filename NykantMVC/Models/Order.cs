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
        public string CustomerEmail { get; set; }
        public Customer Customer { get; set; }
        public int ShippingId { get; set; }
        public Shipping Shipping { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TotalPrice { get; set; }
        public string Currency { get; set; }
        public Status Status { get; set; }
        public string PaymentIntent_Id { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
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
