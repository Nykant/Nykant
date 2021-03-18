using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace NykantMVC.Models
{
    public class CustomerInf
    {
        public int Id { get; set; }
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
        [Display(Name = "Addresse linje 1")]
        public string Address1 { get; set; }
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
        [Required]
        [Phone]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }
    }
}
