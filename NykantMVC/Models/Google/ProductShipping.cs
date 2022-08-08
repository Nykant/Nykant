using Newtonsoft.Json;

namespace NykantMVC.Models.Google
{
    public class ProductShipping
    {
        [JsonProperty("price")]
        public Price Price { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("region")]
        public string Region { get; set; }
        [JsonProperty("service")]
        public string Service { get; set; }
        [JsonProperty("locationId")]
        public string LocationId { get; set; }
        [JsonProperty("locationGroupName")]
        public string LocationGroupName { get; set; }
        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }
        [JsonProperty("minHandlingTime")]
        public string MinHandlingTime { get; set; }
        [JsonProperty("maxHandlingTime")]
        public string MaxHandlingTime { get; set; }
        [JsonProperty("minTransitTime")]
        public string MinTransitTime { get; set; }
        [JsonProperty("maxTransitTime")]
        public string MaxTransitTime { get; set; }
    }
}
