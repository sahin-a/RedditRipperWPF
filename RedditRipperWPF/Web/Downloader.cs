using RedditRipperWPF.Web.models;
using RedditRipperWPF.Web.utils;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;

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

            string fileName = Utils.Instance.GetFileNameFromUrl(item.Url);
            fileName = string.IsNullOrEmpty(fileName) ? $"{item.Title}.png" : fileName;

            Debug.WriteLine($"File Name: {fileName}");

            await wc.DownloadFileTaskAsync(item.Url, $"{downloadDir}\\{Utils.Instance.ReplaceInvalidChars(fileName)}");
        }
    }
}
