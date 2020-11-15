using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedditRipperWPF.RedditAPI.models
{
    public class SubRedditData
    {
        [JsonProperty("children")]
        public List<Post> Posts { get; set; }
    }
}
