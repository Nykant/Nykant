using Newtonsoft.Json;

namespace NykantMVC.Models.Google
{
    public class ProductDimension
    {
        [JsonProperty("value")]
        public int Value { get; set; }
        [JsonProperty("unit")]
        public string Unit { get; set; }
    }
}
