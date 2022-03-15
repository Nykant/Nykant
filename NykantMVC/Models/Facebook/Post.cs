using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models.Facebook
{
    public class Post
    {
        [JsonProperty("created_time")]
        public string CreatedTime { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("story")]
        public string Story { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
