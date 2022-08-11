using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string H1 { get; set; }
        public string H2 { get; set; }
        public string Alt { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string ImgSource { get; set; }
        public List<Product> Products { get; set; }
    }
}
