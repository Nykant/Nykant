﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public InvoiceAddress InvoiceAddress { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
    }
}

