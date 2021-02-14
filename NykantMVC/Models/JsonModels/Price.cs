using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
