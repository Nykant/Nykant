using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Models
{
    public class BillingAddress
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Postal { get; set; }
        [Required]
        public string Region { get; set; }
    }
}
