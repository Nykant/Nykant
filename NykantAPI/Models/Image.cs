using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public string Source2 { get; set; }
        public string Path { get; set; }
        public ImageType ImageType { get; set; }
        public string Alt { get; set; }
        public Size Size { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }

    public enum ImageType
    {
        DetailsSlide,
        DetailsButton,
        DetailsFullscreen,
        Color,
        Gallery,
        Category
    }

    public enum Size
    {
        Phone,
        Tablet,
        Desktop
    }
}
