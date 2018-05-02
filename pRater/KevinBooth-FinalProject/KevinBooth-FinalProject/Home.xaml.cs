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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void navBtn_Click(object sender, RoutedEventArgs e)
        {
            //Routes pages based on what x:Name of element is
            if (sender.Equals(btnHome2))
            {
                //Opening new window
                var devInfo = new DevInfo();

                devInfo.Show();
            }
            else if (sender.Equals(btnBrowse2))
            {
                //Inserts page into pageFrame on MainWindow
                ((MainWindow)System.Windows.Application.Current.MainWindow).pageFrame.NavigationService.Navigate(new Browse());
                ((MainWindow)System.Windows.Application.Current.MainWindow).txtTab.Text = "Browse";
            }
            else
            {
                //Inserts page into pageFrame on MainWindow
                ((MainWindow)System.Windows.Application.Current.MainWindow).pageFrame.NavigationService.Navigate(new Rate());
                ((MainWindow)System.Windows.Application.Current.MainWindow).txtTab.Text = "Rate";
            }
        }
    }
}
