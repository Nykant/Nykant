using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models.ViewModels
{
    public class FrontPageVM
    {
        public List<Category> Categories { get; set; }
        public List<Product> RandomDiscountProducts { get; set; }
        public Product Nora { get; set; }
        public Product Filippa { get; set; }
        public Product Thyra { get; set; }
        public Product Dagmar { get; set; }
        public Image NoraImg { get; set; }
        public Image FilippaImg { get; set; }
        public Image ThyraImg { get; set; }
        public Image DagmarImg { get; set; }
    }
}
