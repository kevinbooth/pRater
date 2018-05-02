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
using System.Windows.Shapes;

namespace KevinBooth_FinalProject
{
    /// <summary>
    /// Interaction logic for AdminLogin.xaml
    /// </summary>
    public partial class AdminLogin : Window
    {
        public AdminLogin()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            txtUser.Focus();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Allows window to be dragged when clicking on red nav

            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUser.Text == "" || txtUser.Text == "") // Validates if user inputted both fields
            {
                txtError.Content = "Please enter a username and password";
            }
            else
            {
                // DOESN'T USE TABLE FROM DATABASE, WOULD LIKE TO USE REVISIT THIS AND CREATE A USERS TABLE
                //CURRENTLY ONE LOGIN FOR ADMIN - Username: admin Password: admin
                if (txtUser.Text == "admin" && txtPass.Password.ToString() == "admin") //Compares credentials to key
                {
                    //Sets visibility on administrator view elements
                    ((MainWindow)System.Windows.Application.Current.MainWindow).btnAdmininster.Visibility = Visibility.Visible;
                    ((MainWindow)System.Windows.Application.Current.MainWindow).imgAdmin.Visibility = Visibility.Visible;
                    ((MainWindow)System.Windows.Application.Current.MainWindow).btnAdmin.Content = "Log out Admin";

                    this.Close();
                }
                else
                {
                    txtError.Content = "Wrong username and password";
                }
            }
        }
    }
}
