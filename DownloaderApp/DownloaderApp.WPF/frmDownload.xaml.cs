using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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
    }
}
