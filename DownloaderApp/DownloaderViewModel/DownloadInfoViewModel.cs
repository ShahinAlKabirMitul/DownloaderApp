using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
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
               if (value != _downloadInfos)
               {
                   _downloadInfos = value;
                   OnPropertyChanged("DownloadInfos");
               }
           }
       }

        private DownloadItemProvider _provider;


        public DownloadInfoViewModel()
        {
            _downloadInfo = new DownloadInfo();
            _provider= new DownloadItemProvider();
            DownloadInfos = _provider.GetDownloadItems();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
    
            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
