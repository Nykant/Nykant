using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string Subject { get; set; }
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public int Stars { get; set; }
    }
}
