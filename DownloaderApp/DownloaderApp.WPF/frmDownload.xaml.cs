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
using Microsoft.Win32;

namespace DownloaderApp.WPF
{
    /// <summary>
    /// Interaction logic for frmDownload.xaml
    /// </summary>
    public partial class frmDownload : Window
    {
        DownloadInfoViewModel _downloadInfoViewModel;
        string filePath = Directory.GetCurrentDirectory() + @"\tepdownload";
        public frmDownload()
        {
            try
            {
                InitializeComponent();
                _downloadInfoViewModel = new DownloadInfoViewModel();
                DataContext = _downloadInfoViewModel;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "~~" + ex.InnerException);
            }
        }

        private void btnDownload_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                var dataObject = btn.DataContext as DownloadInfo;
                _downloadInfoViewModel.SelectedItem = dataObject;
                if (_downloadInfoViewModel.SelectedItem.IsComplete)
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.InitialDirectory = filePath;
                    if (openFileDialog.ShowDialog() == true)
                        File.ReadAllText(filePath);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "~~" + ex.InnerException);
            }

            
          
        }
        
    }
}
