using RedditRipperWPF.Web.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
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

        // TODO: Replace invalid characters
        public async Task DownloadAsyncTask(DownloadItem item)
        {
            wc.DownloadProgressChanged += (sender, e) =>
            {
                item.Progress = (e.BytesReceived / e.TotalBytesToReceive) * 100;
            };

            await wc.DownloadFileTaskAsync(item.Url, $"{downloadDir}\\{item.Title}");
        }
    }
}
