using Newtonsoft.Json;

namespace NykantMVC.Models.Google
{
    public class ProductTax
    {
        [JsonProperty("rate")]
        public int Rate { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("region")]
        public string Region { get; set; }
        [JsonProperty("taxShip")]
        public bool TaxShip { get; set; }
        [JsonProperty("locationId")]
        public string LocationId { get; set; }
        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }
    }
}
