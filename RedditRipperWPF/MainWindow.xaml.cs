using RedditRipperWPF.models;
using RedditRipperWPF.RedditAPI;
using RedditRipperWPF.RedditAPI.models;
using RedditRipperWPF.RedditAPI.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        }

        private async void Test()
        {
            RedditRipper ripper = new RedditRipper("memes", RedditAPI.enums.PostStatus.Hot);
            SubReddit subReddit = await ripper.GetSubReddit();

            Console.WriteLine(subReddit.Name);
            subReddit.Data.Posts.ForEach(post => Console.WriteLine(post.Data.Url));
        }

        private async void DownloadBtn_Click(object sender, RoutedEventArgs e)
        {
            string subRedditName = this.SubredditTBox.Text;

            if (String.IsNullOrEmpty(subRedditName) || String.IsNullOrWhiteSpace(subRedditName))
                return;

            RedditRipper ripper = new RedditRipper(subRedditName, RedditAPI.enums.PostStatus.Hot);
            SubReddit subReddit = await ripper.GetSubReddit();
            
            foreach (Post post in subReddit.Data.Posts)
            {
                DownloadItem item = new DownloadItem();
                item.Title = post.Data.Title;
                item.Progress = 50;
                item.SubReddit = subRedditName;

                this.DownloadLogBox.Items.Add(item);
            }
        }
    }
}
