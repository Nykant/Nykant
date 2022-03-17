using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models.Facebook
{
    public class LikesData
    {
        [JsonProperty("likes")]
        public Likes Likes { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
