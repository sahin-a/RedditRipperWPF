using RedditRipperWPF.Web.models;
using RedditRipperWPF.Web.utils;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Media.Imaging;

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

            string fileDest = $"{downloadDir}\\{Utils.Instance.ReplaceInvalidChars(item.FileName)}";

            wc.DownloadFileCompleted += (sender, e) =>
            {
                item.Image = new FileInfo(fileDest).FullName;
            };

            Debug.WriteLine($"Url: {item.Url} File Name: {item.FileName}");

            try
            {
                Directory.CreateDirectory(this.downloadDir);
                await wc.DownloadFileTaskAsync(item.Url, fileDest);
            }
            catch (WebException we)
            {
                item.Title = we.Message;
            }
        }
    }
}
