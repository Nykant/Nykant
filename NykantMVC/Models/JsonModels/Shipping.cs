using Newtonsoft.Json;

namespace NykantMVC.Models.JsonModels
{
    public class Shipping
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Address")]
        public string Address { get; set; }
    }
}
