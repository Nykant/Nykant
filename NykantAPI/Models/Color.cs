using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Models
{
    public class Color
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string ImgSrc { get; set; }
        public string Alt { get; set; }
        public int ProductSourceId { get; set; }
        public string ProductSourceUrlName { get; set; }
        public EColor EColor { get; set; }
    }

    public enum EColor
    {
        Nature,
        White,
        Black
    }
}
