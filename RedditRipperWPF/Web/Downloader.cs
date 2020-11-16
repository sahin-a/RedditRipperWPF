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

            string title = Utils.Instance.ReplaceInvalidCharsAsync(item.Title);
            string fileName = item.Url.Remove(0, title.LastIndexOf('/') + 1);

            await wc.DownloadFileTaskAsync(item.Url, $"{downloadDir}\\{fileName}");
        }
    }
}
