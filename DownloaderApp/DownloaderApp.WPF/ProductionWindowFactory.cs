using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace DownloaderApp.WPF
{
    class ProductionWindowFactory : IWindowFactory
    {
        public void CreateNewWindow()
        {
            Window window = new Window
            {
               
            };
            window.Show();
        }
    }
}
