using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedditRipperWPF.RedditAPI.models
{
    public class SubReddit
    {
        [JsonIgnore]
        public string Name { get; set; }

        [JsonProperty("data")]
        public SubRedditData Data { get; set; }

        public static SubReddit ConvertToSubReddit(string json)
        {
            return JsonConvert.DeserializeObject<SubReddit>(json);
        }
    }
}
