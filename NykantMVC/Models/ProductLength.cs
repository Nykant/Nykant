using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models
{
    public class ProductLength
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ProductReferenceId { get; set; }
        public string ProductReferenceUrlName { get; set; }
        public string Length { get; set; }
    }
}
