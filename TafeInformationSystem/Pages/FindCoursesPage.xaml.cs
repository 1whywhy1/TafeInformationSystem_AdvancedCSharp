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

namespace TafeInformationSystem.Pages
{
    /// <summary>
    /// Interaction logic for FindCoursesPage.xaml
    /// </summary>
    public partial class FindCoursesPage : Page
    {
        private Frame _mainFrame;

        public FindCoursesPage()
        {
            InitializeComponent();
        }
        public FindCoursesPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.GoBack();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {

            searchCriteriaText.Text = "";
            coursesListView.ItemsSource = null;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt;
            ClsCourse course;

            switch (searchBycmb.SelectedIndex)
            {
                case 0:
                    course = new ClsCourse(searchCriteriaText.Text, Enums.SearchCriteria.CourseSearchBy.ID);
                    dt = course.Search(Enums.SearchCriteria.CourseSearchBy.ID);
                    break;
                case 1:
                    course = new ClsCourse(searchCriteriaText.Text, Enums.SearchCriteria.CourseSearchBy.Name);
                    dt = course.Search(Enums.SearchCriteria.CourseSearchBy.Name);
                    break;
                //case 2:
                //    course = new ClsCourse(searchCriteriaText.Text, Enums.SearchCriteria.CourseSearchBy.Location);
                //    dt = course.Search(Enums.SearchCriteria.CourseSearchBy.Location);
                //    break;
                //case 3:
                //    course = new ClsCourse(searchCriteriaText.Text, Enums.SearchCriteria.CourseSearchBy.Teacher);
                //    dt = course.Search(Enums.SearchCriteria.CourseSearchBy.Teacher);
                //    break;
                case 4:
                    searchCriteriaText.Text = "";
                    course = new ClsCourse(searchCriteriaText.Text, Enums.SearchCriteria.CourseSearchBy.NoLocation);
                    dt = course.Search(Enums.SearchCriteria.CourseSearchBy.NoLocation);
                    break;

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
                coursesListView.ItemsSource = dt.DefaultView;
                //coursesDataGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void openButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView row = (DataRowView)coursesListView.SelectedItem;

                ClsCourse course = new ClsCourse(row.Row[0].ToString(), row.Row[1].ToString(),
                row.Row[2].ToString());
                _mainFrame.Navigate(new CoursesPage(_mainFrame, Enums.EntityPageType.Edit, row));
            }
            catch (NullReferenceException nex) { }
            catch (Exception ex) { }
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                SearchButton_Click(sender, e);
            }
        }

    }
}
