﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using DownloaderModel;

namespace DownloaderViewModel
{
   public class DownloadItemProvider
    {
        public List<DownloadInfo> GetDownloadItems()
        {
            List<DownloadInfo> downloadInfos = new List<DownloadInfo>();

            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            string str = null;
            FileStream fs = new FileStream("DownloadInfo.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("Item");

            for (i = 0; i <= xmlnode.Count - 1; i++)
            {

                downloadInfos.Add(new DownloadInfo()
                {
                    Title = xmlnode[i].ChildNodes.Item(0).InnerText.Trim(),
                    Link = xmlnode[i].ChildNodes.Item(1).InnerText.Trim(),
                    IsComplete = false,
                    Label = "Download",
                    Progress = 0
                });


            }
            return downloadInfos;
        }

       
    }
}
