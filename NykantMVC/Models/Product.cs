﻿using System;
using System.Collections.Generic;

namespace NykantMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public DateTime LastModified { get; set; }
        public string Path { get; set; }
        public string ImageSource { get; set; }
        public string ImageSource2 { get; set; }
        public string TypeOfWood { get; set; }
        public string ItemType { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Alt { get; set; }
        public IEnumerable<Image> Images { get; set; }
        public List<ProductCategory> ProductCategory { get; set; }
    }
}
