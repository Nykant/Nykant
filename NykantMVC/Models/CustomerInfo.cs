using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models
{
    public class CustomerInfo
    {
        public int Id { get; set; }
        public string Subject { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Addresse")]
        public string Email { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Fornavn")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Efternavn")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
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
        [Display(Name = "Post nummer")]
        public string Postal { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }
    }
}
