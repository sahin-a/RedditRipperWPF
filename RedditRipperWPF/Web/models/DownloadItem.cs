using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;

namespace RedditRipperWPF.Web.models
{
    public class DownloadItem : INotifyPropertyChanged
    {
        private string image;
        public string Image
        {
            get { return image; }
            set { image = value; NotifyPropertyChanged(); }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; NotifyPropertyChanged(); }
        }

        private string url;
        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        private string size;
        public string Size
        {
            get { return size; }
            set { size = value; NotifyPropertyChanged(); }
        }

        private double progress;
        public double Progress
        {
            get { return progress; }
            set { progress = value; NotifyPropertyChanged(); }
        }

        private string fileName;
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
