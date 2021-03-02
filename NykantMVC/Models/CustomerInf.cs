using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models
{
    public class CustomerInf
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Kontakt Email Addresse")]
        public string Email { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Modtagers Fornavn")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Modtagers Efternavn")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Modtagers Addresse linje 1")]
        public string Address1 { get; set; }
        [StringLength(50)]
        [Display(Name = "Modtagers Addresse linje 2")]
        public string Address2 { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Modtagers By")]
        public string City { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Modtagers Land")]
        public string Country { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Modtagers Post nummer")]
        public string Postal { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Kontakt Telefon")]
        public string Phone { get; set; }
    }
}
