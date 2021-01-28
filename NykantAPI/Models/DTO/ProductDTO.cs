using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Models.DTO
{
    public class ProductDTO
    {
        public Product Product { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Image> Images { get; set; }
        public int BagId { get; set; }
        public int ProductQuantity { get; set; }
    
    }
}
