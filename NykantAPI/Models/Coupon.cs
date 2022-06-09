using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Models
{
    public class Coupon
    {
        [Key]
        public string Code { get; set; }
        public int Discount { get; set; }
        public bool Enabled { get; set; }
        public bool ForAllProducts { get; set; }
        public IEnumerable<CouponForProduct> CouponForProducts { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
