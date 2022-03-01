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
        public int PaymentCaptureId { get; set; }
        public PaymentCapture PaymentCapture { get; set; }
        public ShippingType Type { get; set; }
        //public string NotHomeNote { get; set; }
        //public ParcelshopData ParcelshopData { get; set; }
    }

    public enum ShippingType
    {
        Home,
        HomePallegods
    }
}
