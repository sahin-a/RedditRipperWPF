using RedditRipperWPF.RedditAPI.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedditRipperWPF.RedditAPI.utils
{
    public static class Utils
    {
        public static string BuildUrl(string subReddit, PostStatus postStatus)
        {
            return $"https://www.reddit.com/r/{subReddit}/hot/.json"; //return $"https://www.reddit.com/r/{subReddit}/{postStatus}/.json";
        }
    }
}
