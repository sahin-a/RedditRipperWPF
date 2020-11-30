using RedditRipperWPF.RedditAPI;
using RedditRipperWPF.RedditAPI.enums;
using RedditRipperWPF.RedditAPI.models;
using RedditRipperWPF.Web;
using RedditRipperWPF.Web.models;
using System;
using System.IO;
using System.Linq;
using System.Net;
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
            Directory.CreateDirectory("Downloads");

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

            RedditRipper ripper = new RedditRipper(subRedditName, postStatus);
            SubReddit subReddit = await ripper.GetSubReddit();

            foreach (Post post in subReddit.Data.Posts.Skip(2))
            {
                DownloadItem item = new DownloadItem();
                item.Title = post.Data.Title;
                item.Url = post.Data.Url;

                // test
                if (item.Url.Contains("gfycat.com"))
                    item.Url = RedditAPI.utils.Utils.GetImageUrlFromGfycat(item.Url);
                else
                    if (!item.Url.Contains("i.imgur.com") && !item.Url.Contains("i.redd.it"))
                    return;

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
            if (Int32.TryParse(PostCountTBox.Text, out int result))
            {
                if (result > 100)
                {
                    PostCountTBox.Text = "100";
                } 
                else if (result < 1)
                {
                    PostCountTBox.Text = "1";
                }
            }
        }
    }
}
