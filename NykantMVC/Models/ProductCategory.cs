using System.ComponentModel.DataAnnotations;

namespace NykantMVC.Models
{
    public class ProductCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Key]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
