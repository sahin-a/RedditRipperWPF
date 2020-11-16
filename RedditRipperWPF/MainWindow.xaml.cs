﻿using RedditRipperWPF.models;
using RedditRipperWPF.RedditAPI;
using RedditRipperWPF.RedditAPI.enums;
using RedditRipperWPF.RedditAPI.models;
using RedditRipperWPF.RedditAPI.utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Init();
        }

        private void Init()
        {
            Array postStatusValues = Enum.GetValues(typeof(PostStatus));

            foreach (PostStatus postStatus in postStatusValues)
            {
                PostStatusComboBox.Items.Add(postStatus);
            }
        }

        private async void DownloadBtn_Click(object sender, RoutedEventArgs e)
        {
            string subRedditName = this.SubredditTBox.Text;
            PostStatus postStatus = (PostStatus) this.PostStatusComboBox.SelectedItem;

            if (string.IsNullOrEmpty(subRedditName) || string.IsNullOrWhiteSpace(subRedditName))
                return;

            RedditRipper ripper = new RedditRipper(subRedditName, postStatus);
            SubReddit subReddit = await ripper.GetSubReddit();
            
            foreach (Post post in subReddit.Data.Posts)
            {
                DownloadItem item = new DownloadItem();
                item.Title = post.Data.Title;
                item.Progress = 50; // TODO: write a download method that reports progress
                item.SubReddit = subRedditName;

                this.DownloadLogBox.Items.Add(item);
            }
        }
    }
}
