using NykantAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models
{
    public class ParcelshopData
    {
        [Key]
        public int Id { get; set; }
        public int ShippingDeliveryId { get; set; }
        public ShippingDelivery ShippingDelivery { get; set; }
        public string Number { get; set; }
        public string CompanyName { get; set; }
        public string Streetname { get; set; }
        public string Streetname2 { get; set; }
        public string ZipCode { get; set; }
        public string CityName { get; set; }
        public string CountryCode { get; set; }
        public string CountryCodeISO3166A2 { get; set; }
        public string Telephone { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public int DistanceMetersAsTheCrowFlies { get; set; }
    }
}
