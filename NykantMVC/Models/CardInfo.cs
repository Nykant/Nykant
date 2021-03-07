using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models
{
    public class CardInfo
    {
        [Required]
        [Display(Name = "Kort indehaverens navn")]
        public string Card_OwnerName { get; set; }
    }
}
