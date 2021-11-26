using System;
using System.Collections.Generic;

namespace NykantMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string ImageSource { get; set; }
        public string ImageSource2 { get; set; }
        public string Path { get; set; }
        public string TypeOfWood { get; set; }
        public string Oil { get; set; }
        public string Alt { get; set; }
        public double WeightInKg { get; set; }
        public IEnumerable<Image> Images { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
