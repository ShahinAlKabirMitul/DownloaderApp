using System;
using System.Collections.Generic;
using System.Text;

namespace DownloaderModel
{
   public class DownloadInfo
    {
        private string _label;
        public string Link { get; set; }
        public string Title { get; set; }
        public bool IsComplete { get; set; }
        public int Progress { get; set; }

        public string Label
        {
            get => _label;
            set
            {
                _label = value;
                if (IsComplete)
                {
                    _label = "OPen";
                }
                else
                {
                    _label = "Download";
                }
            }
        }
    }
}
