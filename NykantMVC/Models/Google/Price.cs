using Newtonsoft.Json;

namespace NykantMVC.Models.Google
{
    public class Price
    {
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
