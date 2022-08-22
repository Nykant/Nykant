using System.Collections.Generic;

namespace NykantAPI.Models.DTO
{
    public class FrontpageDTO
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
