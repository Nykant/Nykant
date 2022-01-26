using System.ComponentModel.DataAnnotations;

namespace NykantMVC.Models
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
