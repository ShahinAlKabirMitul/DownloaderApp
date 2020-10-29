using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using DownloaderModel;
using DownloaderViewModel.Annotations;

namespace DownloaderViewModel
{
   public class DownloadInfoViewModel : INotifyPropertyChanged
   {
       private DownloadInfo _downloadInfo;
       

       private ObservableCollection<DownloadInfo> _downloadInfos;
       
       public ObservableCollection<DownloadInfo> DownloadInfos
        {
           get { return _downloadInfos; }
           set
           {
               _downloadInfos = value;
               OnPropertyChanged("DownloadInfos");
           }
       }

        private DownloadItemProvider _provider;

        public ICommand DownloadAllCommand => _downloadAllCommand;
        private readonly DelegateCommand _downloadAllCommand;

        public ICommand DownloadCommand => _downloadCommand;

        public DownloadInfo SelectedItem { get; set; }

        private readonly DelegateCommand _downloadCommand;

        public DownloadInfoViewModel()
        {
            _downloadInfo = new DownloadInfo();
            _provider= new DownloadItemProvider();
            DownloadInfos = new ObservableCollection<DownloadInfo>(_provider.GetDownloadItems()); 
            _downloadAllCommand = new DelegateCommand(DownloadAll);
            _downloadCommand = new DelegateCommand(DownloadSingle);
        }

        private void DownloadAll(object obj)
        {
            int i = 0;

            Thread mainThread = new Thread(new ThreadStart(DownloadMain));
            // Start secondary thread  
            mainThread.Start();

        }

        private void DownloadMain()
        {
            foreach (var item in DownloadInfos)
            {
                SelectedItem = item;
                bool ok = false;
                //StartDownload(SelectedItem.Link);

                Thread subThread = new Thread(new ThreadStart(StartDownload));
                // Start secondary thread  
                subThread.Start();

                while (SelectedItem.IsComplete == false)
                {

                }

            }
        }

        private void DownloadSingle(object obj)
        {

            if (SelectedItem.Label == "Cancel")
            {
                client.CancelAsync();
                SelectedItem.IsCancel = true;
            }
            if (!SelectedItem.IsComplete && SelectedItem.IsCancel==false)
            {
                StartDownload();
            }
            

        }
        WebClient client;
        string filePath = Directory.GetCurrentDirectory() + "/tepdownload/";
        public void StartDownload()
        {
            string remoteUri = SelectedItem.Link;
            var  path = filePath+ Path.GetFileName(remoteUri);
            try
            {
                client = new WebClient();
                if (!Directory.Exists("tepdownload"))
                {
                    Directory.CreateDirectory("tepdownload");
                }
                Uri uri = new Uri(remoteUri);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);
             
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgessChanged);
                client.DownloadFileAsync(uri, path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetFilenameFromUrl(string url)
        {
            return String.IsNullOrEmpty(url.Trim()) || !url.Contains(".") ? string.Empty : Path.GetFileName(new Uri(url).AbsolutePath);
        }

        public void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                //cleanup delete partial file
                var fileName = GetFilenameFromUrl(SelectedItem.Link);
                string path = Directory.GetCurrentDirectory() + @"\tepdownload\"+ fileName;

                
               
                System.IO.File.Delete(path);
                SelectedItem.IsCancel = false;
                SelectedItem.Label = "Download";
                SelectedItem.Progress = 0;
                return;
            }
            SelectedItem.Label = "Open";
            SelectedItem.IsComplete = true;
            
            //SelectedItem.Progress = 100;
        }
        public void ProgessChanged(object sender, DownloadProgressChangedEventArgs e)
        {

            SelectedItem.Progress = e.ProgressPercentage;
            SelectedItem.Label = "Cancel";
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
    
            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
