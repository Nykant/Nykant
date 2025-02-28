﻿using System.ComponentModel.DataAnnotations;

namespace NykantMVC.Models
{
    public class ShippingDelivery
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public ShippingType Type { get; set; } = 0;
        //public string NotHomeNote { get; set; }
        //public ParcelshopData ParcelshopData { get; set; }
    }

    public enum ShippingType
    {
        Home,
        HomePallegods
    }
}
