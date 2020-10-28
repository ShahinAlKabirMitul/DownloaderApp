using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
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
            get;
            set;
          
       }

        private DownloadItemProvider _provider;

        public ICommand DownloadAllCommand => _downloadAllCommand;
        private readonly DelegateCommand _downloadAllCommand;

        public ICommand DownloadCommand => _downloadCommand;

        public DownloadInfo SelectedItem { get; set; }

        private readonly DelegateCommand _downloadCommand;
        //private DelegateCommand<DownloadInfo> _downloadInfoSelectedCommand;


        public DownloadInfoViewModel()
        {
            _downloadInfo = new DownloadInfo();
            _provider= new DownloadItemProvider();
            DownloadInfos = _provider.GetDownloadItems();
            _downloadAllCommand = new DelegateCommand(DownloadAll);
            _downloadCommand = new DelegateCommand(DownloadSingle);
        }

        private void DownloadAll(object obj)
        {
            var ddd = obj;
            var dd = DownloadInfos;
        }

        private void DownloadSingle(object obj)
        {
            var isFound = DownloadInfos.FirstOrDefault(s => s.Title == SelectedItem.Title);
            DownloadInfos.Remove(isFound);

            SelectedItem.Progress = 100;
            SelectedItem.IsComplete = true;

            DownloadInfos.Add(SelectedItem);


        }

        public void Download1(string remoteUri)
        {
            string FilePath = Directory.GetCurrentDirectory() + "/tepdownload/" + Path.GetFileName(remoteUri); // path where download file to be saved, with filename, here I have taken file name from supplied remote url
            using (WebClient client = new WebClient())
            {
                try
                {
                    if (!Directory.Exists("tepdownload"))
                    {
                        Directory.CreateDirectory("tepdownload");
                    }
                    Uri uri = new Uri(remoteUri);
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(Extract);
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgessChanged);
                    client.DownloadFileAsync(uri, FilePath);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public void Extract(object sender, AsyncCompletedEventArgs e)
        {
            SelectedItem.IsComplete = true;
        }
        public void ProgessChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            SelectedItem.Progress = e.ProgressPercentage;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
    
            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
