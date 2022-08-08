using Newtonsoft.Json;

namespace NykantMVC.Models.Google
{
    public class Installment
    {
        [JsonProperty("months")]
        public string Months { get; set; }
        [JsonProperty("amount")]
        public Price Amount { get; set; }
    }
}
