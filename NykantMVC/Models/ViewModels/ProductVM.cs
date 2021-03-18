using System.Collections.Generic;

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
