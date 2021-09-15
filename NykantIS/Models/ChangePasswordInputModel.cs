using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NykantIS.Models
{
    public class ChangePasswordInputModel
    {
        [Required(ErrorMessage = "The old password field is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Nuværende password")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Nyt password feltet skal udfyldes.")]
        [StringLength(100, ErrorMessage = "{0} skal mindst være {2} og maks {1} tegn langt.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nyt password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bekræft nyt password")]
        [Compare("NewPassword", ErrorMessage = "det nye password og det bekræftende nye password, passer ikke.")]
        public string ConfirmPassword { get; set; }
    }
}
