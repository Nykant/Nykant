using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NykantMVC.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
