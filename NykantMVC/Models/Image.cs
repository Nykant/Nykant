﻿namespace NykantMVC.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public string Source2 { get; set; }
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
