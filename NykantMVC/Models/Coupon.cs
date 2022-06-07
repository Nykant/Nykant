using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models
{
    public class Coupon
    {
        public string Code { get; set; }
        public int Discount { get; set; }
        public bool Enabled { get; set; }
        public bool ForAllProducts { get; set; }
        public IEnumerable<CouponForProduct> CouponForProducts { get; set; }
    }
}
