using DownloaderViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DownloaderApp.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new UserViewModel();
            DataContext = vm;
           
        }

        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //ImgShowHide.Source = new BitmapImage(new Uri(@"\image\show.png", UriKind.Relative));


        }
        public void ShowPassword()
        {
            ImgShowHide.Source = new BitmapImage(new Uri(@"\Images\hide.png", UriKind.Relative));
            txtVisiblePasswordbox.Visibility = Visibility.Visible;
            txtPasswordbox.Visibility = Visibility.Hidden;
            txtVisiblePasswordbox.Text = txtPasswordbox.Password;
        }

        public void HidePassword()
        {
            ImgShowHide.Source = new BitmapImage(new Uri(@"\Images\show.png", UriKind.Relative));
            txtVisiblePasswordbox.Visibility = Visibility.Hidden;
            txtPasswordbox.Visibility = Visibility.Visible;
            txtPasswordbox.Focus();
        }

        private void ImgShowHide_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            HidePassword();
        }

        private void ImgShowHide_MouseLeave(object sender, MouseEventArgs e)
        {
            HidePassword();
        }

        private void ImgShowHide_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowPassword();
        }

        private void txtPasswordbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txtPasswordbox.Password.Length > 0)
            {
                ImgShowHide.Visibility = Visibility.Visible;
            }
            else
            {
                ImgShowHide.Visibility = Visibility.Hidden;
            }
            vm.txtPassword = txtPasswordbox.Password;
            
        }


    }
}
