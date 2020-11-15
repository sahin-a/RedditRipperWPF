using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;

namespace RedditRipperWPF.models
{
    class DownloadItem : INotifyPropertyChanged
    {
        private BitmapImage image;
        public BitmapImage Image
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


        private string subReddit;
        public string SubReddit
        {
            get { return subReddit; }
            set { subReddit = value; NotifyPropertyChanged(); }
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


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
