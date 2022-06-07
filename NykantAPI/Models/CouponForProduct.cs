using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Models
{
    public class CouponForProduct
    {
        public int Id { get; set; }
        public string CouponCode { get; set; }
        public Coupon Coupon { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
