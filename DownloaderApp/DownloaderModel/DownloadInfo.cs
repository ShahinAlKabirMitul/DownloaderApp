using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DownloaderModel
{
   public class DownloadInfo : INotifyPropertyChanged
    {
        
        private string title;
        private string link;
        private string label;
        private int  progress;
        private bool isComplete;
        private bool isCancel;

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Link
        {
            get
            {
                return link;
            }
            set
            {
                link = value;
                OnPropertyChanged("Link");
            }
        }
        public string Label
        {
            get
            {
                return label;
            }
            set
            {
                
                label = value;
                OnPropertyChanged("Label");
            }
        }


        public int Progress
        {
            get
            {
                return progress;
            }
            set
            {
                progress = value;
                OnPropertyChanged("Progress");
            }
        }

        public bool IsComplete
        {
            get
            {
                return isComplete;
            }
            set
            {
                isComplete = value;
                OnPropertyChanged("IsComplete");
            }
        }

        public bool IsCancel
        {
            get
            {
                return isCancel;
            }
            set
            {
                isCancel = value;
                OnPropertyChanged("IsCancel");
            }
        }

        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
