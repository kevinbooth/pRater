using KevinBooth_FinalProject.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    public partial class Rate : Page
    {
        private ProfViewModel viewModel;
        public bool searchClick = false; //Remedies Runtime error when searching
        private GenericDepartments<string> departmentArr = new GenericDepartments<string>(8);

        public Rate()
        {
            InitializeComponent();
            viewModel = new ProfViewModel();
            rateData.ItemsSource = viewModel.DisplayProfessors(); //Calling view model

            //Setting all combo boxes
            PopulateGrades();
            SetDepartmentValues(); //Generic array
            PopulateDept();
        }

        private void rateData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (searchClick == false && rateData.SelectedItem != null) //Validates item is selected
            {
                //Appending professor data from selected table to professor detail section
                var data = rateData.SelectedItem;
                string fName = (rateData.SelectedCells[0].Column.GetCellContent(data) as TextBlock).Text;
                txtFirst.Text = fName;
                string lName = (rateData.SelectedCells[1].Column.GetCellContent(data) as TextBlock).Text;
                txtLast.Text = lName;
                string dept = (rateData.SelectedCells[2].Column.GetCellContent(data) as TextBlock).Text;
                txtDept.Text = dept;

                if (rateData.Items.Count - 1 != rateData.SelectedIndex) // Validates index isn't null
                {
                    int pid = int.Parse((rateData.SelectedCells[3].Column.GetCellContent(data) as TextBlock).Text);
                    txtPid.Content = pid;

                    string imageFile = viewModel.GetImageFile(pid);

                    DisplayImage(imageFile);
                }
            }

            searchClick = false;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (txtFirst.Text == "" || txtLast.Text == "" | txtDept.Text == "" ) //Validates if professor was selected
            {
                lblValidate.Foreground = new SolidColorBrush(Colors.Red);
                lblValidate.Content = "Please choose a Professor.";
            }
            else
            {
                if (txtClassTaken.Text == "" || txtComment.Text == "" | cmbGrades.Text == "") //Validates form is filled properly
                {
                    lblValidate.Foreground = new SolidColorBrush(Colors.Red);
                    lblValidate.Content = "Your are missing an entry. Please fill out the entire form.";
                }
                else
                {
                    int pid = Convert.ToInt32(txtPid.Content);
                    string classTaken = txtClassTaken.Text;
                    string comment = txtComment.Text;
                    bool book;

                    if (chkBook.IsChecked == true)
                    {
                        book = true;
                    }
                    else
                    {
                        book = false;
                    }

                    string gradeReceived = cmbGrades.Text;
                    int profRating = ValidateProfRating();
                    int diffRating = ValidateDiffRating();

                    //Creating form from view model
                    var status = viewModel.CreateNewRating(pid, classTaken, comment, book, gradeReceived, profRating, diffRating);

                    if (status == true)
                    {
                        lblValidate.Foreground = new SolidColorBrush(Colors.Green);
                        //Refreshes page to create another rating
                        ((MainWindow)System.Windows.Application.Current.MainWindow).pageFrame.NavigationService.Navigate(new Rate());
                        ((MainWindow)System.Windows.Application.Current.MainWindow).txtTab.Text = "Rate";

                    }
                    else
                    {
                        lblValidate.Foreground = new SolidColorBrush(Colors.Red);
                        lblValidate.Content = "Error adding rating";
                    }

                }
            }
        }

        public int ValidateProfRating()
        {
            // Very manual evaluation of professor rating. would like to revisit this, but it works for now
            int _profRating;
            Style redStyle = (Style)FindResource("starHoverStyleRed");

            if (starFive.Style == redStyle)
            {
                _profRating = 5;
            }
            else if (starFour.Style == redStyle)
            {
                _profRating = 4;
            }
            else if (starThree.Style == redStyle)
            {
                _profRating = 3;
            }
            else if (starTwo.Style == redStyle)
            {
                _profRating = 2;
            }
            else if (starOne.Style == redStyle)
            {
                _profRating = 1;
            }
            else
            {
                _profRating = 0;
            }

            return _profRating;
        }
        public int ValidateDiffRating()
        {
            // Very manual evaluation of professor rating. would like to revisit this, but it works for now
            int _difRating;
            Style redStyle = (Style)FindResource("starHoverStyleRed");
            if (difFive.Style == redStyle)
            {
                _difRating = 5;
            }
            else if (difFour.Style == redStyle)
            {
                _difRating = 4;
            }
            else if (difThree.Style == redStyle)
            {
                _difRating = 3;
            }
            else if (difTwo.Style == redStyle)
            {
                _difRating = 2;
            }
            else if (difOne.Style == redStyle)
            {
                _difRating = 1;
            }
            else
            {
                _difRating = 0;
            }

            return _difRating;
        }
        public void DisplayImage(string file)
        {
            //Sets file path for professor image
            string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", @"images\stocks\" + file));

            if (File.Exists(path)) //Validates path to file exists, then appends to view
            {
                imgProf.Source = new BitmapImage(new Uri(@"/images/stocks/" + file, UriKind.Relative));
            }
            else
            {
                imgProf.Source = new BitmapImage(new Uri(@"/images/anon-prof.png", UriKind.Relative));
            }
        }

        private void PopulateGrades()
        {
            cmbGrades.Items.Add("A");
            cmbGrades.Items.Add("B");
            cmbGrades.Items.Add("C");
            cmbGrades.Items.Add("D");
            cmbGrades.Items.Add("F");
        }

        private void SetDepartmentValues()
        {
            departmentArr.setItem(0, "");
            departmentArr.setItem(1, "Biology");
            departmentArr.setItem(2, "Business Administration");
            departmentArr.setItem(3, "Chemistry");
            departmentArr.setItem(4, "Computer Engineering");
            departmentArr.setItem(5, "Human Service");
            departmentArr.setItem(6, "Information Technology");
            departmentArr.setItem(7, "Mechanical Engineering");
        }
        private void PopulateDept()
        {
            for (int i = 0; i < 8; i++)
            {
                cmbDept.Items.Add(departmentArr.getItem(i));
            }
        }

        private void star_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Image star = (Image)(sender as Image);

            ShowStars(star);

        }

        private void ShowStars(Image star)
        {
            //Very bad solution, but it works for now. would like to revisit this.
            if (star.Source.ToString().Contains("/images/gray-star-fill.png") || star.Source.ToString().Contains("/images/rate-large-black.png"))
            {
                if (star.Name.Equals("starOne"))
                {
                    star.Style = (Style)FindResource("starHoverStyleRed");
                }
                else if (star.Name.Equals("starTwo"))
                {
                    starOne.Style = (Style)FindResource("starHoverStyleRed");
                    star.Style = (Style)FindResource("starHoverStyleRed");
                }
                else if (star.Name.Equals("starThree"))
                {
                    starOne.Style = (Style)FindResource("starHoverStyleRed");
                    starTwo.Style = (Style)FindResource("starHoverStyleRed");
                    star.Style = (Style)FindResource("starHoverStyleRed");
                }
                else if (star.Name.Equals("starFour"))
                {
                    starOne.Style = (Style)FindResource("starHoverStyleRed");
                    starTwo.Style = (Style)FindResource("starHoverStyleRed");
                    starThree.Style = (Style)FindResource("starHoverStyleRed");
                    star.Style = (Style)FindResource("starHoverStyleRed");
                }
                else if (star.Name.Equals("starFive"))
                {
                    starOne.Style = (Style)FindResource("starHoverStyleRed");
                    starTwo.Style = (Style)FindResource("starHoverStyleRed");
                    starThree.Style = (Style)FindResource("starHoverStyleRed");
                    starFour.Style = (Style)FindResource("starHoverStyleRed");
                    star.Style = (Style)FindResource("starHoverStyleRed");
                }
            }
            else if (star.Source.ToString().Contains("/images/red-star-fill.png"))
            {
                if (star.Name.Equals("starOne"))
                {
                    star.Style = (Style)FindResource("starHoverStyle");
                    starTwo.Style = (Style)FindResource("starHoverStyle");
                    starThree.Style = (Style)FindResource("starHoverStyle");
                    starFour.Style = (Style)FindResource("starHoverStyle");
                    starFive.Style = (Style)FindResource("starHoverStyle");
                }
                else if (star.Name.Equals("starTwo"))
                {
                    star.Style = (Style)FindResource("starHoverStyle");
                    starThree.Style = (Style)FindResource("starHoverStyle");
                    starFour.Style = (Style)FindResource("starHoverStyle");
                    starFive.Style = (Style)FindResource("starHoverStyle");
                }
                else if (star.Name.Equals("starThree"))
                {
                    star.Style = (Style)FindResource("starHoverStyle");
                    starFour.Style = (Style)FindResource("starHoverStyle");
                    starFive.Style = (Style)FindResource("starHoverStyle");
                }
                else if (star.Name.Equals("starFour"))
                {
                    star.Style = (Style)FindResource("starHoverStyle");
                    starFive.Style = (Style)FindResource("starHoverStyle");
                }
                else if (star.Name.Equals("starFive"))
                {
                    star.Style = (Style)FindResource("starHoverStyle");
                }
            }

            if (star.Source.ToString().Contains("/images/gray-star-fill.png") || star.Source.ToString().Contains("/images/rate-large-black.png"))
            {
                //star.Style = (Style)FindResource("starHoverStyleRed");
                //star.Source = new BitmapImage(new Uri(@"/images/red-star-fill.png", UriKind.Relative));

                if (star.Name.Equals("difOne"))
                {
                    star.Style = (Style)FindResource("starHoverStyleRed");
                }
                else if (star.Name.Equals("difTwo"))
                {
                    difOne.Style = (Style)FindResource("starHoverStyleRed");
                    star.Style = (Style)FindResource("starHoverStyleRed");
                }
                else if (star.Name.Equals("difThree"))
                {
                    difOne.Style = (Style)FindResource("starHoverStyleRed");
                    difTwo.Style = (Style)FindResource("starHoverStyleRed");
                    star.Style = (Style)FindResource("starHoverStyleRed");
                }
                else if (star.Name.Equals("difFour"))
                {
                    difOne.Style = (Style)FindResource("starHoverStyleRed");
                    difTwo.Style = (Style)FindResource("starHoverStyleRed");
                    difThree.Style = (Style)FindResource("starHoverStyleRed");
                    star.Style = (Style)FindResource("starHoverStyleRed");
                }
                else if (star.Name.Equals("difFive"))
                {
                    difOne.Style = (Style)FindResource("starHoverStyleRed");
                    difTwo.Style = (Style)FindResource("starHoverStyleRed");
                    difThree.Style = (Style)FindResource("starHoverStyleRed");
                    difFour.Style = (Style)FindResource("starHoverStyleRed");
                    star.Style = (Style)FindResource("starHoverStyleRed");
                }
            }
            else if (star.Source.ToString().Contains("/images/red-star-fill.png"))
            {
                if (star.Name.Equals("difOne"))
                {
                    star.Style = (Style)FindResource("starHoverStyle");
                    difTwo.Style = (Style)FindResource("starHoverStyle");
                    difThree.Style = (Style)FindResource("starHoverStyle");
                    difFour.Style = (Style)FindResource("starHoverStyle");
                    difFive.Style = (Style)FindResource("starHoverStyle");
                }
                else if (star.Name.Equals("difTwo"))
                {
                    star.Style = (Style)FindResource("starHoverStyle");
                    difThree.Style = (Style)FindResource("starHoverStyle");
                    difFour.Style = (Style)FindResource("starHoverStyle");
                    difFive.Style = (Style)FindResource("starHoverStyle");
                }
                else if (star.Name.Equals("difThree"))
                {
                    star.Style = (Style)FindResource("starHoverStyle");
                    difFour.Style = (Style)FindResource("starHoverStyle");
                    difFive.Style = (Style)FindResource("starHoverStyle");
                }
                else if (star.Name.Equals("difFour"))
                {
                    star.Style = (Style)FindResource("starHoverStyle");
                    difFive.Style = (Style)FindResource("starHoverStyle");
                }
                else if (star.Name.Equals("difFive"))
                {
                    star.Style = (Style)FindResource("starHoverStyle");
                }
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            searchClick = true;

            if (txtLastSearch.Text == "" && cmbDept.SelectedItem == null) //Deciphers what textboxes have data or not
            {
                rateData.ItemsSource = viewModel.DisplayProfessors();
            }
            else
            {
                rateData.ItemsSource = viewModel.SearchProfessor(txtLastSearch.Text, cmbDept.Text);
            }
        }
    }
}
