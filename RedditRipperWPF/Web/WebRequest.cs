using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RedditRipperWPF.Web
{
    public static class WebRequest
    {
        private static HttpClient client = new HttpClient();

        public static async Task<string> Get(string url)
        {
            return await client.GetStringAsync(url);
        }

        public static async Task<string> Post(string url, Dictionary<string, string> data)
        {
            HttpContent content = new FormUrlEncodedContent(data);
            HttpResponseMessage response = await client.PostAsync(url, content);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
