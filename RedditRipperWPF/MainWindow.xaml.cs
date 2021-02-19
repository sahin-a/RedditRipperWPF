using RedditRipperWPF.ImageViewer;
using RedditRipperWPF.ImageViewer.models;
using RedditRipperWPF.RedditAPI;
using RedditRipperWPF.RedditAPI.enums;
using RedditRipperWPF.RedditAPI.models;
using RedditRipperWPF.Web;
using RedditRipperWPF.Web.models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;

namespace RedditRipperWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            ServicePointManager.DefaultConnectionLimit = 10;

            Array postStatusValues = Enum.GetValues(typeof(PostStatus));

            foreach (PostStatus postStatus in postStatusValues)
            {
                PostStatusComboBox.Items.Add(postStatus);
            }
        }

        private async void DownloadBtn_Click(object sender, RoutedEventArgs e)
        {
            string subRedditName = this.SubredditTBox.Text;
            PostStatus postStatus = (PostStatus)this.PostStatusComboBox.SelectedItem;
            int maxPosts = Int32.Parse(PostCountTBox.Text);

            RedditRipper ripper = new RedditRipper(subRedditName, postStatus, maxPosts);
            SubReddit subReddit = await ripper.GetSubReddit();

            foreach (Post post in subReddit.Data.Posts)
            {
                DownloadItem item = new DownloadItem();
                item.Title = post.Data.Title;
                item.Url = post.Data.Url;

                if (item.Url.Contains("gfycat.com"))
                    item.Url = RedditAPI.utils.Utils.GetImageUrlFromGfycat(item.Url);

                item.FileName = Web.utils.Utils.Instance.GetFileNameFromUrl(item.Url);
                item.FileName = string.IsNullOrEmpty(item.FileName) || string.IsNullOrWhiteSpace(item.FileName)
                    ? $"{item.Title}.png" : item.FileName;

                this.DownloadLogBox.Items.Add(item);

                Downloader downloader = new Downloader("Downloads");
                downloader.DownloadAsync(item);
            }
        }

        private void PostCountTBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                uint result = (uint)Int32.Parse(PostCountTBox.Text);

                if (result > 100)
                {
                    PostCountTBox.Text = "100";
                }
                else if (result == 0)
                {
                    PostCountTBox.Text = "1";
                }
            }
            catch (Exception)
            {
                PostCountTBox.Text = "1";
            }
        }

        private void SingleDownloadBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Image_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                DownloadItem selectedItem = (DownloadItem)DownloadLogBox.SelectedItem;

                Image image = new Image();
                image.FileName = selectedItem.FileName;
                image.Path = selectedItem.Image;

                new ImageViewerWindow(image).ShowDialog();
            }
        }
    }
}
