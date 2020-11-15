using Newtonsoft.Json;
using RedditRipperWPF.RedditAPI.enums;
using RedditRipperWPF.RedditAPI.models;
using RedditRipperWPF.RedditAPI.utils;
using RedditRipperWPF.Web;
using System;
using System.Threading.Tasks;

namespace RedditRipperWPF.RedditAPI
{
    public class RedditRipper
    {
        private string subReddit;
        private PostStatus postStatus;

        public RedditRipper(string subReddit, PostStatus postStatus)
        {
            this.subReddit = subReddit;
            this.postStatus = postStatus;
        }

        public async Task<SubReddit> GetSubReddit()
        {
            string url = Utils.BuildUrl(this.subReddit, postStatus);
            string json = await WebRequest.Get(url);

            SubReddit subReddit = SubReddit.ConvertToSubReddit(json);
            subReddit.Name = this.subReddit;

            return subReddit;
        }
    }
}
