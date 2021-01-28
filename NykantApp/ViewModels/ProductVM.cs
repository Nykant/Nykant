using NykantMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Image> Images { get; set; }
        public int BagId { get; set; }
    }
}
