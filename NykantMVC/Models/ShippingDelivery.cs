using System.ComponentModel.DataAnnotations;

namespace NykantMVC.Models
{
    public class ShippingDelivery
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
