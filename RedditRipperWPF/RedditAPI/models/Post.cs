using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedditRipperWPF.RedditAPI.models
{
    public class Post
    {
        [JsonProperty("data")]
        public PostData Data { get; set; }
    }
}
