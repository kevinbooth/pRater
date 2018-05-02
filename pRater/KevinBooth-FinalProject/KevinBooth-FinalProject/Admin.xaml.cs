using KevinBooth_FinalProject.ViewModel;
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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        private ProfViewModel viewModel;
        private GenericDepartments<string> departmentArr = new GenericDepartments<string>(7);

        public Admin()
        {
            InitializeComponent();
            viewModel = new ProfViewModel();
            this.DataContext = viewModel;
            //Populate comboboxes with Generics
            SetDepartmentValues();
            AddDepartments();
        }

        //These next four event handlers perform the navigation
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            lblAddStatus.Content = "";
            gridAdd.Visibility = Visibility.Visible;
            gridUpdate.Visibility = Visibility.Hidden;
            gridDelete.Visibility = Visibility.Hidden;
            GridDelReview.Visibility = Visibility.Hidden;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            lblUpStatus.Content = "";
            txtUpFirst.Text = "";
            txtUpLast.Text = "";
            cmbUpDept.Text = "";

            browseData.ItemsSource = viewModel.DisplayProfessors();

            gridAdd.Visibility = Visibility.Hidden;
            gridUpdate.Visibility = Visibility.Visible;
            gridDelete.Visibility = Visibility.Hidden;
            GridDelReview.Visibility = Visibility.Hidden;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            browseDataDelete.ItemsSource = viewModel.DisplayProfessors();

            lblDelStatus.Text = "";
            gridAdd.Visibility = Visibility.Hidden;
            gridUpdate.Visibility = Visibility.Hidden;
            gridDelete.Visibility = Visibility.Visible;
            GridDelReview.Visibility = Visibility.Hidden;

            gridDelValidation.Visibility = Visibility.Hidden;

        }

        private void btnDelReviews_Click(object sender, RoutedEventArgs e)
        {
            ratingData.ItemsSource = viewModel.DisplayRatings();
            lblDelRevStatus.Text = "";
            gridAdd.Visibility = Visibility.Hidden;
            gridUpdate.Visibility = Visibility.Hidden;
            gridDelete.Visibility = Visibility.Hidden;
            GridDelReview.Visibility = Visibility.Visible;

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (txtAddFirst.Text != "" && txtAddLast.Text != "" && cmbAddDept.Text != "") //Validates form was filled our properly
            {
                //Passes data to view model to create professor
                var status = viewModel.AddProfessor(txtAddFirst.Text, txtAddLast.Text, cmbAddDept.Text);

                if (status == true)
                {
                    lblAddStatus.Foreground = new SolidColorBrush(Colors.Green);
                    lblAddStatus.Content = "Professor successfully added";
                    txtAddFirst.Text = "";
                    txtAddLast.Text = "";
                    cmbAddDept.Text = "";
                }
                else
                {
                    lblAddStatus.Foreground = new SolidColorBrush(Colors.Red);
                    lblAddStatus.Content = "There was an error adding the professor";
                }
            }
            else
            {
                lblAddStatus.Foreground = new SolidColorBrush(Colors.Red);
                lblAddStatus.Content = "You are missing one or more fields";
            }
        }

        private void SetDepartmentValues()
        {
            //setting departments with generics
            departmentArr.setItem(0, "Biology");
            departmentArr.setItem(1, "Business Administration");
            departmentArr.setItem(2, "Chemistry");
            departmentArr.setItem(3, "Computer Engineering");
            departmentArr.setItem(4, "Human Service");
            departmentArr.setItem(5, "Information Technology");
            departmentArr.setItem(6, "Mechanical Engineering");
        }

        private void AddDepartments()
        {
            //Adding generic array to view
            for (int i = 0; i < 7; i++)
            {
                cmbAddDept.Items.Add(departmentArr.getItem(i));
                cmbUpDept.Items.Add(departmentArr.getItem(i));
            }
        }

        private void browseData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (browseData.SelectedItem != null) //Makes sure item is actually selected and isn't null
            {
                lblUpStatus.Content = "";

                var data = browseData.SelectedItem;
                string fName = (browseData.SelectedCells[0].Column.GetCellContent(data) as TextBlock).Text;
                txtUpFirst.Text = fName;
                string lName = (browseData.SelectedCells[1].Column.GetCellContent(data) as TextBlock).Text;
                txtUpLast.Text = lName;
                string dept = (browseData.SelectedCells[2].Column.GetCellContent(data) as TextBlock).Text;
                cmbUpDept.Text = dept;
            }
        }

        private void btnUpSubmit_Click(object sender, RoutedEventArgs e)
        {
            var data = browseData.SelectedItem;

            if(data != null) //Makes sure a professor was selected
            {
                if (txtUpFirst.Text != "" && txtUpLast.Text != "" && cmbUpDept.Text != "") //Makes sure professor update still has data in it
                {
                    int pid = int.Parse((browseData.SelectedCells[3].Column.GetCellContent(data) as TextBlock).Text);
                    var status = viewModel.UpdateProfessor(pid, txtUpFirst.Text, txtUpLast.Text, cmbUpDept.Text); //Updates professor
                    browseData.ItemsSource = viewModel.DisplayProfessors(); //Reloads list

                    txtUpFirst.Text = "";
                    txtUpLast.Text = "";
                    cmbUpDept.Text = "";

                    if (status == true)
                    {
                        lblUpStatus.Foreground = new SolidColorBrush(Colors.Green);
                        lblUpStatus.Content = "Success";
                    }
                    else
                    {
                        lblUpStatus.Foreground = new SolidColorBrush(Colors.Red);
                        lblUpStatus.Content = "Error";
                    }
                }
                else
                {
                    lblUpStatus.Foreground = new SolidColorBrush(Colors.Red);
                    lblUpStatus.Content = "One or more fields are empty";
                }
            }
            else
            {
                lblUpStatus.Foreground = new SolidColorBrush(Colors.Red);
                lblUpStatus.Content = "Please select a professor";
            }
        }

        private void browseDataDelete_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gridDelValidation.Visibility == Visibility.Visible)
            {
                var data = browseDataDelete.SelectedItem;

                if (data != null) // Setting second step of validation to make sure user wants to delete item selected
                {
                    string fName = (browseDataDelete.SelectedCells[0].Column.GetCellContent(data) as TextBlock).Text;
                    string lName = (browseDataDelete.SelectedCells[1].Column.GetCellContent(data) as TextBlock).Text;

                    lblDelStatus.Foreground = new SolidColorBrush(Colors.Black);
                    lblDelStatus.Text = "Are you sure you want to delete " + fName + " " + lName + "?";
                }
            }
        }

        private void btnDelSubmit_Click(object sender, RoutedEventArgs e)
        {
            var data = browseDataDelete.SelectedItem;

            if (data != null) // Setting second step of validation to make sure user wants to delete item selected
            {
                string fName = (browseDataDelete.SelectedCells[0].Column.GetCellContent(data) as TextBlock).Text;
                string lName = (browseDataDelete.SelectedCells[1].Column.GetCellContent(data) as TextBlock).Text;

                gridDelValidation.Visibility = Visibility.Visible;
                lblDelStatus.Foreground = new SolidColorBrush(Colors.Black);
                lblDelStatus.Text = "Are you sure you want to delete " + fName + " " + lName + "?";

            }
            else
            {
                lblDelStatus.Foreground = new SolidColorBrush(Colors.Red);
                lblDelStatus.Text = "Please select a professor";
            }


        }

        private void btnDelYes_Click(object sender, RoutedEventArgs e)
        {
            var data = browseDataDelete.SelectedItem;

            if (data != null) //Final step to delete professor
            {
                int pid = int.Parse((browseDataDelete.SelectedCells[3].Column.GetCellContent(data) as TextBlock).Text);
                var status = viewModel.DeleteProfessor(pid); //Deletion of professor in view model

                browseDataDelete.ItemsSource = viewModel.DisplayProfessors(); //Refresh data
                lblDelStatus.Text = "";
                gridDelValidation.Visibility = Visibility.Hidden;

            }
            else
            {
                lblUpStatus.Foreground = new SolidColorBrush(Colors.Red);
                lblDelStatus.Text = "Please select a professor";
            }
        }

        private void btnDelNo_Click(object sender, RoutedEventArgs e)
        {
            gridDelValidation.Visibility = Visibility.Hidden;
            lblDelStatus.Text = "";
        }

        private void btnDelReview_Click(object sender, RoutedEventArgs e)
        {
            var data = ratingData.SelectedItem;

            if (data != null) //Makes sure item is selected
            {
                int rid = int.Parse((ratingData.SelectedCells[3].Column.GetCellContent(data) as TextBlock).Text);

                var status = viewModel.DeleteRating(rid); //Deletes rating in view model

                if (status == true) //Deciphers how it was deleted and displays to user
                {
                    ratingData.ItemsSource = viewModel.DisplayRatings();
                    lblDelRevStatus.Foreground = new SolidColorBrush(Colors.Green);
                    lblDelRevStatus.Text = "Rating successfully deleted";
                }
                else
                {
                    lblDelRevStatus.Foreground = new SolidColorBrush(Colors.Red);
                    lblDelRevStatus.Text = "Error";
                }
            } 
            else
            {
                lblDelRevStatus.Foreground = new SolidColorBrush(Colors.Red);
                lblDelRevStatus.Text = "Please select a rating";
            }
        }
    }
}
