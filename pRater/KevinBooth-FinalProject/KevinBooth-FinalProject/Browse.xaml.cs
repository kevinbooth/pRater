using KevinBooth_FinalProject.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
    public partial class Browse : Page
    {
        private ProfViewModel viewModel;
        public bool searchClick = false; //Remedies Runtime error when searching
        private GenericDepartments<string> departmentArr = new GenericDepartments<string>(8);

        public Browse()
        {
            InitializeComponent();
            viewModel = new ProfViewModel();
            this.DataContext = viewModel;

            //Calling viewmodel and appending data to datagrid in view
            browseData.ItemsSource = viewModel.DisplayProfessors();
            //Setting and populating combobox from generic array
            SetDepartmentValues();
            PopulateComboBox();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            searchClick = true;

            if (txtLastSearch.Text == "" && cmbDept.SelectedItem == null) //Validate search criteria
            {
                browseData.ItemsSource = viewModel.DisplayProfessors();
            }
            else
            {
                browseData.ItemsSource = viewModel.SearchProfessor(txtLastSearch.Text, cmbDept.Text);
            }
        }

        private void browseData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (searchClick == false && browseData.SelectedItem != null) //Validate if item is selected
            {
                //Taking data from datagrid and adding to professor detail view
                var data = browseData.SelectedItem;
                string fName = (browseData.SelectedCells[0].Column.GetCellContent(data) as TextBlock).Text;
                txtFirst.Text = fName;
                string lName = (browseData.SelectedCells[1].Column.GetCellContent(data) as TextBlock).Text;
                txtLast.Text = lName;
                string dept = (browseData.SelectedCells[2].Column.GetCellContent(data) as TextBlock).Text;
                txtDept.Text = dept;

                if (browseData.Items.Count -1 != browseData.SelectedIndex) //Make sure item has value
                {
                    int pid = int.Parse((browseData.SelectedCells[3].Column.GetCellContent(data) as TextBlock).Text);

                    //Gets rating table data based on selected professor
                    ratingData.ItemsSource = viewModel.UpdateRatingTable(pid);

                    //Appending professor image to view element
                    string imageFile = viewModel.GetImageFile(pid);
                    DisplayImage(imageFile);

                    //Calculating star rating
                    double avg = viewModel.GetRatingsAverage(pid, 1);
                    SetStarRating(avg, 1);

                    double avg2 = viewModel.GetRatingsAverage(pid, 2);
                    SetStarRating(avg2, 2);
                }
            }

            searchClick = false;
        }


        private void DisplayImage(string file)
        {
            //Creating path to append to view element
            string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", @"images\stocks\" + file));

            if (File.Exists(path)) //Make sure path to file exists
            {
                imgProf.Source = new BitmapImage(new Uri(@"/images/stocks/" + file, UriKind.Relative));
            }
            else
            {
                imgProf.Source = new BitmapImage(new Uri(@"/images/anon-prof.png", UriKind.Relative));
            }
        }
        private void UpdateRatingTable(int pid)
        {
            //Call view model
            ratingData.ItemsSource = viewModel.UpdateRatingTable(pid);
        }

        private void SetStarRating(double average, int ratingType)
        {
            //Very manual process of setting stars, would like to revisit
            if (ratingType != 2)
            {
                starOne.Source = new BitmapImage(new Uri(@"/images/rate-large-black.png", UriKind.Relative));
                starTwo.Source = new BitmapImage(new Uri(@"/images/rate-large-black.png", UriKind.Relative));
                starThree.Source = new BitmapImage(new Uri(@"/images/rate-large-black.png", UriKind.Relative));
                starFour.Source = new BitmapImage(new Uri(@"/images/rate-large-black.png", UriKind.Relative));
                starFive.Source = new BitmapImage(new Uri(@"/images/rate-large-black.png", UriKind.Relative));
            }

            difOne.Source = new BitmapImage(new Uri(@"/images/rate-large-black.png", UriKind.Relative));
            difTwo.Source = new BitmapImage(new Uri(@"/images/rate-large-black.png", UriKind.Relative));
            difThree.Source = new BitmapImage(new Uri(@"/images/rate-large-black.png", UriKind.Relative));
            difFour.Source = new BitmapImage(new Uri(@"/images/rate-large-black.png", UriKind.Relative));
            difFive.Source = new BitmapImage(new Uri(@"/images/rate-large-black.png", UriKind.Relative));

            if (ratingType == 1)
            {
                if (average >= 5 || average >= 4.5)
                {
                    starFive.Source = new BitmapImage(new Uri(@"/images/red-star-fill.png", UriKind.Relative));
                }
                if (average >= 4 || average >= 3.5)
                {
                    starFour.Source = new BitmapImage(new Uri(@"/images/red-star-fill.png", UriKind.Relative));
                }
                if (average >= 3 || average >= 2.5)
                {
                    starThree.Source = new BitmapImage(new Uri(@"/images/red-star-fill.png", UriKind.Relative));
                }
                if (average >= 2 || average >= 1.5)
                {
                    starTwo.Source = new BitmapImage(new Uri(@"/images/red-star-fill.png", UriKind.Relative));
                }
                if (average >= 1)
                {
                    starOne.Source = new BitmapImage(new Uri(@"/images/red-star-fill.png", UriKind.Relative));
                }
                else { /* No rating average from table */ }
            } 
            else if (ratingType == 2)
            {
                if (average >= 5)
                {
                    difFive.Source = new BitmapImage(new Uri(@"/images/red-star-fill.png", UriKind.Relative));
                }
                if (average >= 4)
                {

                    difFour.Source = new BitmapImage(new Uri(@"/images/red-star-fill.png", UriKind.Relative));
                }
                if (average >= 3)
                {
                    difThree.Source = new BitmapImage(new Uri(@"/images/red-star-fill.png", UriKind.Relative));
                }
                if (average >= 2)
                {
                    difTwo.Source = new BitmapImage(new Uri(@"/images/red-star-fill.png", UriKind.Relative));
                }
                if (average >= 1)
                {
                    difOne.Source = new BitmapImage(new Uri(@"/images/red-star-fill.png", UriKind.Relative));
                }
                else { /* No rating average from table */ }
            }
        } // end SetStarRating

        private void SetDepartmentValues()
        {
            //Adding departments to generic array
            departmentArr.setItem(0, "");
            departmentArr.setItem(1, "Biology");
            departmentArr.setItem(2, "Business Administration");
            departmentArr.setItem(3, "Chemistry");
            departmentArr.setItem(4, "Computer Engineering");
            departmentArr.setItem(5, "Human Service");
            departmentArr.setItem(6, "Information Technology");
            departmentArr.setItem(7, "Mechanical Engineering");
        }

        private void PopulateComboBox()
        {
            for (int i = 0; i < 8; i++)
            {
                //appending items to view element
                cmbDept.Items.Add(departmentArr.getItem(i));
            }

            //cmbDept.Items.Add("");
            //cmbDept.Items.Add("Biology");
            //cmbDept.Items.Add("Business Administration");
            //cmbDept.Items.Add("Chemistry");
            //cmbDept.Items.Add("Computer Engineering");
            //cmbDept.Items.Add("Chemistry");
            //cmbDept.Items.Add("Human Service");
            //cmbDept.Items.Add("Information Technology");
            //cmbDept.Items.Add("Mechanical Engineering");
        }
    }
}
