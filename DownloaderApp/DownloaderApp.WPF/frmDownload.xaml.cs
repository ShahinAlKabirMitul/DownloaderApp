using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DownloaderModel;
using DownloaderViewModel;

namespace DownloaderApp.WPF
{
    /// <summary>
    /// Interaction logic for frmDownload.xaml
    /// </summary>
    public partial class frmDownload : Window
    {
        DownloadInfoViewModel _downloadInfoViewModel;
        public frmDownload()
        {
            InitializeComponent();
            _downloadInfoViewModel= new DownloadInfoViewModel();
            DataContext = _downloadInfoViewModel;
        }

        private void btnDownload_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            var dataObject = btn.DataContext as DownloadInfo;
            _downloadInfoViewModel.SelectedItem = dataObject;
          
           
        }
        public void Extract(object sender, AsyncCompletedEventArgs e)
        {
            Console.WriteLine("File has been downloaded.");
        }
        public void ProgessChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine($"Download status: {e.ProgressPercentage}%.");
        }
    }
}
