using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Models
{
    public class ProductLength
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ProductReferenceId { get; set; }
        public string ProductReferenceUrlName { get; set; }
        public string Length { get; set; }
    }
}
