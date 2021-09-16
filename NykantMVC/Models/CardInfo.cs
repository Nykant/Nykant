using System.ComponentModel.DataAnnotations;

namespace NykantMVC.Models
{
    public class CardInfo
    {
        [Required]
        [Display(Name = "Card holders name")]
        public string Card_OwnerName { get; set; }
    }
}
