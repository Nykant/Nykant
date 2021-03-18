using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NykantMVC.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductCategory> ProductCategory { get; set; }
    }
}
