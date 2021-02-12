using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<BagItem> BagItems { get; set; }
        public CustomerInfo CustomerInfo { get; set; }
        public ShippingOption ShippingOption { get; set; }
        public int TotalPrice { get; set; }
        public Valuta Valuta { get; set; }
        public Status Status { get; set; }
        public string PIClientSecret { get; set; }
    }

    public enum Valuta
    {
        DKK = 1,
        USD = 2,
        EURO = 3
    }
    public enum Status
    {
        Created = 1,
        Processing = 2,
        Accepted = 3,
        Failed = 4
    }
}
