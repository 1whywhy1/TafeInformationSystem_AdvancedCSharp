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
using TafeInformationSystem.Classes;
using TafeInformationSystem.Enums;

namespace TafeInformationSystem.Pages
{
    /// <summary>
    /// Interaction logic for CourseCollegeSemesterPage.xaml
    /// </summary>
    public partial class CourseCollegeSemesterPage : Page
    {
        #region Fields
        private Frame _mainFrame;
        private UIState _state;
        private ClsCourseCollegeSemesterViewModel _viewModel;

        #endregion

        #region Constructors
        public CourseCollegeSemesterPage()
        {
            InitializeComponent();
            SetUp();
        }

        public CourseCollegeSemesterPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
            SetUp();
        }

        #endregion

        #region Properties

        #endregion

        #region Buttons
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Grab selected items
            ClsSemester sem = (ClsSemester)semestersLV.SelectedItem;
            ClsCollege col = (ClsCollege)collegesLV.SelectedItem;
            ClsCourse crs = (ClsCourse)coursesLV.SelectedItem;

            // Insert into SQL
            _viewModel.Add(sem.SemesterID, sem.SemesterName, col.CollegeID, 
                col.CollegeName, crs.CourseID, crs.Name);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            SetUIState(UIState.Edit);
        }
        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            ClsMessenger.ShowMessage("Select 1 from Semester, College and Semester then press Add to add combination");
            SetUIState(UIState.Add);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            SetUIState(UIState.View);
        } 

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ClsCourseCollegeSemester ccs = (ClsCourseCollegeSemester)courseCollegeSemesterLV.SelectedItem;
            int result = _viewModel.Delete(ccs);
            if(result.ToString() == ccs.CCSID)
            {
                ClsMessenger.ShowMessage($"Course {ccs.CourseName} College {ccs.CollegeName} Semester {ccs.SemesterName} has been deleted!");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.GoBack();
        }
        #endregion

        #region Set Up
        public void SetUp()
        {
            SetUIState(UIState.View);
            _viewModel = new ClsCourseCollegeSemesterViewModel();
            DataContext = _viewModel;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(_viewModel.CourseCollegeSemesterInfo);
            view.Filter = UserFilter;
        }

        #endregion

        #region SetUIState
        private void SetUIState(UIState state)
        {
            _state = state;
            addButton.Visibility = (_state == UIState.Add) ? Visibility.Visible : Visibility.Hidden;
            newButton.Visibility = (_state == UIState.View) ? Visibility.Visible : Visibility.Hidden;
            editButton.Visibility = (_state == UIState.View) ? Visibility.Visible : Visibility.Hidden;
            deleteButton.Visibility = (_state == UIState.Edit) ? Visibility.Visible : Visibility.Hidden;
            cancelButton.Visibility = (_state == UIState.Add || _state == UIState.Edit) ? Visibility.Visible : Visibility.Hidden;
            
            if(_state == UIState.View)
            {
                pageTxt.Text = "View Course College Semeser";
            }
            else if (_state == UIState.Add)
            {
                pageTxt.Text = "Add Course College Semeser";
            }
            else if (_state == UIState.Edit)
            {
                pageTxt.Text = "Edit Course College Semeser";
            }

        }

        #endregion
              

        #region Filters
        private bool UserFilter(object record)
        {           
             return SemesterFilter(record) && CollegeFilter(record) && CourseFilter(record);                    
        }

        private bool SemesterFilter(object record)
        {
            if (semestersLV.SelectedItem == null)
            {
                return true;
            }
            else
            {
                return (record as ClsCourseCollegeSemester)
                    .SemesterName.Equals(((ClsSemester)semestersLV.SelectedItem).SemesterName);

            }
        }

        private bool CollegeFilter(object record)
        {
            if (collegesLV.SelectedItem == null)
            {
                return true;
            }
            else
            {
                return (record as ClsCourseCollegeSemester)
                    .CollegeID.Equals(((ClsCollege)collegesLV.SelectedItem).CollegeID);

            }
        }

        private bool CourseFilter(object record)
        {
            if (coursesLV.SelectedItem == null)
            {
                return true;
            }
            else
            {
                return (record as ClsCourseCollegeSemester)
                    .CourseID.Equals(((ClsCourse)coursesLV.SelectedItem).CourseID);

            }
        }

        #endregion

        #region FilterSelection
        private void semestersLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(_viewModel.CourseCollegeSemesterInfo).Refresh();
        }

        private void collegesLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(_viewModel.CourseCollegeSemesterInfo).Refresh();
        }

        private void coursesLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(_viewModel.CourseCollegeSemesterInfo).Refresh();
        }

        #endregion

        #region Clear Filter Buttons
        private void clearSemesterBtn_Click(object sender, RoutedEventArgs e)
        {
            semestersLV.SelectedItem = null;
        }

        private void clearCollegeBtn_Click(object sender, RoutedEventArgs e)
        {
            collegesLV.SelectedItem = null;
        }

        private void clearCourseBtn_Click(object sender, RoutedEventArgs e)
        {
            coursesLV.SelectedItem = null;
        }
        #endregion
    }
}
