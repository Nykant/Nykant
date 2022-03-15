using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models.Facebook
{
    public class Feed
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }
}
