﻿using NykantAPI.Models.DTO;
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
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
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
        public double WeightInKg { get; set; }
        public DateTime EstimatedDelivery { get; set; }
        [Required]
        public string PaymentIntent_Id { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public ShippingDelivery ShippingDelivery { get; set; }
        public Invoice Invoice { get; set; }
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
