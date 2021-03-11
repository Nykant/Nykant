using NykantMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public bool ItemAdded { get; set; }
        public bool ReviewSent { get; set; }
        public List<Review> Reviews { get; set; }
        public Review Review { get; set; }
    }
}
