using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models.Facebook
{
    public class Likes
    {
        [JsonProperty("data")]
        public List<Like> List { get; set; }
        [JsonProperty("summary")]
        public Summary Summary { get; set; }
    }
}
