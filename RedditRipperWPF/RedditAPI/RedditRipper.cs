using RedditRipperWPF.RedditAPI.enums;
using RedditRipperWPF.RedditAPI.models;
using RedditRipperWPF.RedditAPI.utils;
using RedditRipperWPF.Web;
using System.Threading.Tasks;

namespace RedditRipperWPF.RedditAPI
{
    public class RedditRipper
    {
        private string subReddit;
        private PostStatus postStatus;
        private int maxPosts;

        public RedditRipper(string subReddit, PostStatus postStatus, int maxPosts = 100)
        {
            this.subReddit = subReddit;
            this.postStatus = postStatus;
            this.maxPosts = maxPosts;
        }

        public async Task<SubReddit> GetSubReddit()
        {
            string url = Utils.BuildUrl(this.subReddit, this.postStatus, this.maxPosts);
            string json = await WebRequest.GetAsyncTask(url);

            SubReddit subReddit = SubReddit.ConvertToSubReddit(json);
            subReddit.Name = this.subReddit;

            // TODO: add gfycat support + get filename and right extension
            // TODO: loop through the collection and delete the elements that contain domains that are not on the support list.

            return subReddit;
        }
    }
}
