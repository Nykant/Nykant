using System.Collections.Generic;

namespace NykantMVC.Models.ViewModels
{
    public class DataVM
    {
        public List<Image> Images { get; set; } = new List<Image>();
        public List<Color> Colors { get; set; } = new List<Color>();
        public List<ProductLength> Lengths { get; set; } = new List<ProductLength>();
    }
}
