using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models.JsonModels
{
    public class Customer
    {
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Address")]
        public string Address { get; set; }
        [JsonProperty("City")]
        public string City { get; set; }
        [JsonProperty("Country")]
        public string Country { get; set; }
        [JsonProperty("Postal")]
        public string Postal { get; set; }

        [JsonProperty("Phone")]
        public string Phone { get; set; }
    }
}
