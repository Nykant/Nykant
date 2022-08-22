using System.Collections.Generic;

namespace NykantMVC.Models.DTO
{
    public class FrontpageDTO
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
