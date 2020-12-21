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
        [Timestamp]
        [Required]
        public DateTime LastModified { get; set; } 
        public int ImageId { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }

    }
}
