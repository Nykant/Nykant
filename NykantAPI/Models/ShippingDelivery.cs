using NykantMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Models
{
    public class ShippingDelivery
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public string Type { get; set; }
        public string NotHomeNote { get; set; }
        public ParcelshopData ParcelshopData { get; set; }
    }
}
