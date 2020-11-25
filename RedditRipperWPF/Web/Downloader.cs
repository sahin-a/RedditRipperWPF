using RedditRipperWPF.Web.models;
using RedditRipperWPF.Web.utils;
using System.Diagnostics;
using System.Net;

namespace RedditRipperWPF.Web
{
    public class Downloader
    {
        private WebClient wc = new WebClient();
        private string downloadDir;

        public Downloader(string downloadDir)
        {
            this.downloadDir = downloadDir;
        }

        public async void DownloadAsync(DownloadItem item)
        {
            wc.DownloadProgressChanged += (sender, e) =>
            {
                item.Progress = e.ProgressPercentage;
            };

            Debug.WriteLine($"Url: {item.Url} File Name: {item.FileName}");

            await wc.DownloadFileTaskAsync(item.Url, $"{downloadDir}\\{Utils.Instance.ReplaceInvalidChars(item.FileName)}");
        }
    }
}
