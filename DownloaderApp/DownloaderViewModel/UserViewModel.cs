using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Xml;
using System.Xml.Serialization;

using DownloaderModel;

namespace DownloaderViewModel
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private User _user;
        private List<User> _users;
        private readonly DelegateCommand _loginCommand;
        public ICommand LoginCommand => _loginCommand;

        public UserViewModel()
        {
            _user = new User();
            _loginCommand = new DelegateCommand(OnLogIn);

            _users = GetUsers();
        }

        public string txtUserName
        {
            get { return _user.UserName; }
            set { _user.UserName = value; Changed("txtUserName"); }
        }

        public string txtPassword
        {
            get { return _user.Password; }
            set { _user.Password = value; Changed("txtPassword"); }
        }
        public bool IsLoggedIn
        {
            get { return CanLogIn(); }
            set { CanLogIn(); Changed("IsLoggedIn"); }
        }

        public bool CanLogIn()
        {
            var isFound = _users.FirstOrDefault(s => s.UserName == txtUserName && s.Password == txtPassword);
            if (isFound == null)
                return false;
            return true;
        }
        public void OnLogIn(object commandParameter)
        {


        }
        public List<User> GetUsers()
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            string str = null;
            FileStream fs = new FileStream("UserInfo.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("User");
            List<User> users = new List<User>();


            for (i = 0; i <= xmlnode.Count - 1; i++)
            {

                users.Add(new User()
                {
                    UserName = xmlnode[i].ChildNodes.Item(0).InnerText.Trim(),
                    Password = xmlnode[i].ChildNodes.Item(1).InnerText.Trim()
                });


            }
            return users;
        }
        public void Changed(string Name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
