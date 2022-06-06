using System;
using System.Collections.Generic;
using System.Data;
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
using TafeInformationSystem.Classes;
using TafeInformationSystem.Enums;

namespace TafeInformationSystem.Pages
{
    /// <summary>
    /// Interaction logic for StudentsPage.xaml
    /// </summary>
    public partial class StudentsPage : Page
    {
        private Frame _mainFrame;

        public StudentsPage()
        {
            InitializeComponent();
        }

        public StudentsPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

        private void SearchNameButton_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            studentsListView.ItemsSource = null;
            searchCriteriaText.Text = string.Empty;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenSelectedButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (studentsListView.SelectedItem != null)
                {
                    DataRowView row = (DataRowView)studentsListView.SelectedItem;

                    ClsStudent student = new ClsStudent(row.Row[0].ToString());
                    student.Search(SearchCriteria.StudentSearchBy.ID);
                    _mainFrame.Navigate(new PersonalPage(_mainFrame, student));
                }

            }
            catch (NullReferenceException nex) { }
            catch (Exception ex) { }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.GoBack();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt;
            ClsStudent student;

            switch (searchBycmb.SelectedIndex)
            {
                case 0:
                    student = new ClsStudent(searchCriteriaText.Text, Enums.SearchCriteria.StudentSearchBy.ID);
                    dt = student.Search(SearchCriteria.StudentSearchBy.ID);
                    break;
                case 1:
                    student = new ClsStudent(searchCriteriaText.Text, Enums.SearchCriteria.StudentSearchBy.FirstName);
                    dt = student.Search(SearchCriteria.StudentSearchBy.FirstName);
                    break;
                case 2:
                    student = new ClsStudent(searchCriteriaText.Text, SearchCriteria.StudentSearchBy.LastName);
                    dt = student.Search(SearchCriteria.StudentSearchBy.LastName);
                    break;
                case 3:
                    student = new ClsStudent(searchCriteriaText.Text, Enums.SearchCriteria.StudentSearchBy.NotPaid);
                    dt = student.Search(SearchCriteria.StudentSearchBy.NotPaid);
                    break;
                case 4:
                //searchCriteriaText.Text = "";
                //student = new ClsStudent(searchCriteriaText.Text, Enums.SearchCriteria.StudentSearchBy.PartTime);
                //dt = student.Search(SearchCriteria.StudentSearchBy.PartTime);
                //break;
                default:
                    dt = null;
                    break;
            }
            if (dt == null)
            {
                _ = MessageBox.Show("No record");
            }
            else
            {
                // Populate DataGrid from SQL
                studentsListView.ItemsSource = dt.DefaultView;
            }
        }
    }
}
