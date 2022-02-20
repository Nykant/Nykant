using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models
{
    public class BillingAddress
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Fulde Navn eller Firma")]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Addresse")]
        public string Address { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "By")]
        public string City { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Land")]
        public string Country { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Postnummer")]
        public string Postal { get; set; }
    }
}
