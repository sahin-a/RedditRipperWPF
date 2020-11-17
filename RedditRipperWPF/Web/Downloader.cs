using RedditRipperWPF.Web.models;
using RedditRipperWPF.Web.utils;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace RedditRipperWPF.Web
{
    public class Downloader
    {
        private WebClient wc = new WebClient();
        private string downloadDir;

        public Downloader(string downloadDir = "Downloads")
        {
            this.downloadDir = downloadDir;
            Directory.CreateDirectory(downloadDir);
        }

        public async Task DownloadAsyncTask(DownloadItem item)
        {
            wc.DownloadProgressChanged += (sender, e) =>
            {
                item.Progress = e.ProgressPercentage;
            };

            // TODO: remove test code

            string extension = ".png";
            string fileName = Utils.Instance.ReplaceInvalidCharsAsync(item.Title) + extension;

            await wc.DownloadFileTaskAsync(item.Url, $"{downloadDir}\\{fileName}");
        }

        public async void DownloadAsync(DownloadItem item)
        {
            wc.DownloadProgressChanged += (sender, e) =>
            {
                item.Progress = e.ProgressPercentage;
            };

            // TODO: remove test code

            string extension = ".png";
            string fileName = Utils.Instance.ReplaceInvalidCharsAsync(item.Title) + extension;

            await wc.DownloadFileTaskAsync(item.Url, $"{downloadDir}\\{fileName}");
        }
    }
}
