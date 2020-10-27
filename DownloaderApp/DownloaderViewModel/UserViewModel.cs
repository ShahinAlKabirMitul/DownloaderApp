using System;
using System.Collections.Generic;
using System.Text;
using DownloaderModel;

namespace DownloaderViewModel
{
   public class UserViewModel
   {
       private User _user;

       public UserViewModel()
       {
           _user = new User();
       }

       public string txtUserName
       {
           get { return _user.UserName; }
           set { _user.UserName = value; }
       }

       public string txtPassword
       {
           get { return _user.Password; }
           set { _user.Password = value; }
       }
    }
}
