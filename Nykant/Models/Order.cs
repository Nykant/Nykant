using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Nykant.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        [Required]
        public string Session { get; set; }
    }
}
