using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Nykant.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime LastModified { get; set; } 
        public string ImageSource { get; set; }
        public string TypeOfWood { get; set; }
        public string ItemType { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
    }
}
