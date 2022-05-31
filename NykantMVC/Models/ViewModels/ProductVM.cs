using System.Collections.Generic;

namespace NykantMVC.Models.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public List<Product> RelatedProducts { get; set; }
    }
}
