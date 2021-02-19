using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media.Imaging;
using Image = RedditRipperWPF.ImageViewer.models.Image;

namespace RedditRipperWPF.ImageViewer
{
    /// <summary>
    /// Interaktionslogik für ImageViewerWindow.xaml
    /// </summary>
    public partial class ImageViewerWindow : Window
    {
        public ImageViewerWindow(Image image)
        {
            InitializeComponent();

            try
            {
                SetImage(image.Path);
            } 
            catch (InvalidOperationException e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        private void SetImage(string path)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(path);
            bitmap.EndInit();
            ImageBox.Source = bitmap;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
