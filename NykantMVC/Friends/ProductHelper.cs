using NykantMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Friends
{
    public static class ProductHelper
    {
        public static long GetPrice(Product product, Coupon coupon = null)
        {
            if(coupon == null)
            {
                if(product.Discount == 0)
                {
                    return product.Price;
                }
                else
                {
                    return product.Price - Convert.ToInt64(Math.Round(Convert.ToDouble(product.Price) * (Convert.ToDouble(product.Discount) / 100)));
                }

            }
            else
            {
                if (product.Discount == 0)
                {
                    return product.Price - Convert.ToInt64(Math.Round(Convert.ToDouble(product.Price) * (Convert.ToDouble(coupon.Discount) / 100)));
                }
                else
                {
                    return product.Price - Convert.ToInt64(Math.Round(Convert.ToDouble(product.Price) * (Convert.ToDouble(product.Discount) / 100)));
                }
            }
        }
    }
}
