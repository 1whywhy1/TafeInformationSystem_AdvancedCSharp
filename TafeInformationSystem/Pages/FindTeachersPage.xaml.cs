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
    /// Interaction logic for FindTeacherPage.xaml
    /// </summary>
    public partial class FindTeacherPage : Page
    {
        private Frame _mainFrame;

        public FindTeacherPage()
        {
            InitializeComponent();
        }

        public FindTeacherPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt;
            ClsTeacher teacher;

            switch (searchBycmb.SelectedIndex)
            {
                case 0:
                    teacher = new ClsTeacher(searchCriteriaText.Text, Enums.SearchCriteria.TeacherSearchBy.ID);
                    dt = teacher.Search(Enums.SearchCriteria.TeacherSearchBy.ID);
                    break;
                case 1:
                    teacher = new ClsTeacher(searchCriteriaText.Text, Enums.SearchCriteria.TeacherSearchBy.FirstName);
                    dt = teacher.Search(Enums.SearchCriteria.TeacherSearchBy.FirstName);
                    break;
                //case 2:
                //    course = new ClsTeacher(searchCriteriaText.Text, Enums.SearchCriteria.CourseSearchBy.Location);
                //    dt = course.Search(Enums.SearchCriteria.CourseSearchBy.Location);
                //    break;
                case 3:
                    teacher = new ClsTeacher(searchCriteriaText.Text, Enums.SearchCriteria.TeacherSearchBy.LastName);
                    dt = teacher.Search(Enums.SearchCriteria.TeacherSearchBy.LastName);
                    break;
                case 4:
                    searchCriteriaText.Text = "";
                    teacher = new ClsTeacher(searchCriteriaText.Text, Enums.SearchCriteria.TeacherSearchBy.Location);
                    dt = teacher.Search(Enums.SearchCriteria.TeacherSearchBy.Location);
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
                teachersListView.ItemsSource = dt.DefaultView;
            }
        }


        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            teachersListView.ItemsSource = null;
            searchCriteriaText.Text = string.Empty;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.GoBack();
        }

        private void OpenSelectedButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (teachersListView.SelectedItem != null)
                {
                    DataRowView row = (DataRowView)teachersListView.SelectedItem;

                    ClsTeacher teacher = new ClsTeacher(row.Row[0].ToString());
                    teacher.Search(Enums.SearchCriteria.TeacherSearchBy.ID);
                    _mainFrame.Navigate(new PersonalPage(_mainFrame, teacher));
                }

            }
            catch (NullReferenceException nex) { }
            catch (Exception ex) { }
        }
    }
}
