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

namespace KevinBooth_FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        public MainWindow()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            pageFrame.NavigationService.Navigate(new Home());
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void txtName_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new System.Windows.Media.BrushConverter();
            
            txtName.Foreground = (Brush)converter.ConvertFromString("#990033");
        }

        private void txtName_MouseLeave(object sender, MouseEventArgs e)
        {
            txtName.Foreground = Brushes.White;
        }

        private void imgNHTI_MouseEnter(object sender, MouseEventArgs e)
        {
            imgNHTI.Source = new BitmapImage(new Uri(@"images/nhti-logo-red.png", UriKind.Relative));
        }

        private void imgNHTI_MouseLeave(object sender, MouseEventArgs e)
        {
            imgNHTI.Source = new BitmapImage(new Uri(@"images/nhti-logo.png", UriKind.Relative));
        }

        public void navBtn_Click(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(btnHome))
            {
                pageFrame.NavigationService.Navigate(new Home());
                txtTab.Text = "Home";
            }
            else if (sender.Equals(btnBrowse))
            {
                pageFrame.NavigationService.Navigate(new Browse());
                txtTab.Text = "Browse";
            }
            else if (sender.Equals(btnRate))
            {
                pageFrame.NavigationService.Navigate(new Rate());
                txtTab.Text = "Rate";
            }
            else if (sender.Equals(btnAdmininster))
            {
                pageFrame.NavigationService.Navigate(new Admin());
                txtTab.Text = "Admin";
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Allows window to be dragged when clicking on red nav

            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void imgSettings_Click(object sender, RoutedEventArgs e)
        {
            if (gridSettings.IsVisible)
            {
                gridSettings.Visibility = Visibility.Hidden;
            }
            else
            {
                gridSettings.Visibility = Visibility.Visible;
            }
        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToString(btnAdmin.Content) == "Admin Login")
            {
                gridSettings.Visibility = Visibility.Hidden;

                var adminWindow = new AdminLogin();

                adminWindow.Show();
            }
            else
            {
                btnAdmininster.Visibility = Visibility.Hidden;
                imgAdmin.Visibility = Visibility.Hidden;
                gridSettings.Visibility = Visibility.Hidden;

                pageFrame.NavigationService.Navigate(new Home());

                btnAdmin.Content = "Admin Login";
            }
        }

        private void btnDev_Click(object sender, RoutedEventArgs e)
        {
            gridSettings.Visibility = Visibility.Hidden;

            var devInfo = new DevInfo();
            devInfo.Show();
        }
    }
}
