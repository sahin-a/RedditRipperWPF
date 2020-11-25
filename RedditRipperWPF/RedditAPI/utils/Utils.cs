using HtmlAgilityPack;
using RedditRipperWPF.RedditAPI.enums;
using RedditRipperWPF.RedditAPI.exceptions;
using RedditRipperWPF.RedditAPI.models;
using System;
using System.Net;
using System.Text.RegularExpressions;

namespace RedditRipperWPF.RedditAPI.utils
{
    public static class Utils
    {
        private static Regex regex = new Regex(@"^(http|https):\/\/www.(reddit).com\/r\/([a-zA-Z0-9]{0,21})(\/|)$");

        public static string BuildUrl(string subReddit, PostStatus postStatus)
        {
            return $"https://www.reddit.com/r/{subReddit}/{postStatus.ToString().ToLower()}/.json";
        }

        public static bool IsValidSubRedditUrl(string uri)
        {
            if (regex.Match(uri).Success)
                return true;

            return false;
        }

        public static string ParseUri(string uri)
        {
            Match match = regex.Match(uri);

            if (match.Success)
            {
                string subReddit = match.Groups[3].Value;

                return subReddit;
            }

            return null;
        }

        private static string GetImageUrlFromGfycat(string url)
        {
            using (WebClient wc = new WebClient())
            {
                string html = wc.DownloadString(url);

                HtmlDocument doc = new HtmlDocument();

                doc.LoadHtml(html);

                HtmlNodeCollection links = doc.DocumentNode.SelectNodes("//source[@src]");

                if (links == null)
                    throw new GfycatImageUrlNotFoundException();

                foreach (HtmlNode link in links)
                {
                    string value = link.Attributes["src"].Value;

                    if (!value.Contains("-mobile"))
                    {
                        return value;
                    }
                }
            }

            return null;
        }
    }
}
