using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        public BillingAddress BillingAddress { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        [Required]
        public string PrivacyPolicyConsent { get; set; }
    }
}

