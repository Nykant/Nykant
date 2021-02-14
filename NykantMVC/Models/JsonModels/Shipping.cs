using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
