using System.ComponentModel.DataAnnotations;

namespace NykantMVC.Models
{
    public class CardInfo
    {
        [Required]
        [Display(Name = "Kort indehaverens navn")]
        public string Card_OwnerName { get; set; }
    }
}
