using Newtonsoft.Json;

namespace NykantMVC.Models.Google
{
    public class CustomAttribute
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("groupValues")]
        public CustomAttribute[] GroupValues { get; set; }
    }
}
