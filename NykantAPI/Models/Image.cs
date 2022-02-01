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
        public ImageType ImageType { get; set; }
        public Size Size { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }

    public enum ImageType
    {
        DetailsSlide,
        DetailsButton,
        DetailsFullscreen
    }

    public enum Size
    {
        Phone,
        Tablet,
        Desktop
    }
}
