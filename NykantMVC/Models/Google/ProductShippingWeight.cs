using Newtonsoft.Json;

namespace NykantMVC.Models.Google
{
    public class ProductShippingWeight
    {
        [JsonProperty("value")]
        public int Value { get; set; }
        [JsonProperty("unit")]
        public string Unit { get; set; }
    }
}
