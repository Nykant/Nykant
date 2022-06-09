using System;
using System.Collections.Generic;

namespace NykantMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string UrlName { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public string GalleryImage1 { get; set; }
        public string GalleryImage2 { get; set; }
        public int Pieces { get; set; }
        public string AssemblyPath { get; set; }
        public string Path { get; set; }
        public DateTime ExpectedDelivery { get; set; }
        public int Amount { get; set; }
        public EColor EColor { get; set; }
        public string Length { get; set; }
        public int Discount { get; set; } = 0;
        public string Oil { get; set; }
        public string Alt { get; set; }
        public double WeightInKg { get; set; }
        public string Size { get; set; }
        public string Materials { get; set; }
        public string Package { get; set; }
        public string Note { get; set; }
        public IEnumerable<Image> Images { get; set; }
        public IEnumerable<Color> Colors { get; set; }
        public IEnumerable<ProductLength> ProductLengths { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public IEnumerable<CouponForProduct> CouponForProducts { get; set; }
    }
}
