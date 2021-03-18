using Newtonsoft.Json;

namespace NykantMVC.Models.JsonModels
{
    public class Price
    {
        //[JsonProperty("Currency")]
        //public string Currency { get; set; }
        [JsonProperty("Amount")]
        public int Amount { get; set; }
    }
}
