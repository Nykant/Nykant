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
        public DateTime CreatedAt { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
        public string CustomerInfoEmail { get; set; }
        public CustomerInfo CustomerInfo { get; set; }
        public string ShippingOptionName { get; set; }
        public int TotalPrice { get; set; }
        public string Valuta { get; set; }
        public Status Status { get; set; }
        public string PIClientSecret { get; set; }
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
