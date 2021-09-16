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
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Address1")]
        public string Address1 { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Address2")]
        public string Address2 { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Country")]
        public string Country { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Postal")]
        public string Postal { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Telephone")]
        public string Phone { get; set; }
        [Required]
        public string AcceptPrivacyPolicy { get; set; }
    }
}
