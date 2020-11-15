using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedditRipperWPF.RedditAPI.models
{
    public class PostData
    {
        [JsonProperty("author_fullname")]
        public string Author { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
