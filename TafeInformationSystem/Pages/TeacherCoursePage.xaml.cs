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

namespace TafeInformationSystem.Pages
{
    /// <summary>
    /// Interaction logic for TeacherCoursePage.xaml
    /// </summary>
    public partial class TeacherCoursePage : Page
    {
        #region Fields
        Frame _mainFrame;
        private ClsTeacherCourseViewModel _teacherCourseVM;

        #endregion

        #region Constructors
        public TeacherCoursePage()
        {
            InitializeComponent();
            SetUp();
        }
        public TeacherCoursePage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
            SetUp();
        }
            
        #endregion


        #region Buttons
        private void AssignButton_Click(object sender, RoutedEventArgs e)
        {
            if (teachersLV.SelectedItem != null && semestersLV.SelectedItem != null &&
                collegesLV.SelectedItem != null && coursesLV.SelectedItem != null )
            {
                // Grab selected items
                ClsTeacher t = (ClsTeacher)teachersLV.SelectedItem;
                ClsSemester sem = (ClsSemester)semestersLV.SelectedItem;
                ClsCollege col = (ClsCollege)collegesLV.SelectedItem;
                ClsCourse crs = (ClsCourse)coursesLV.SelectedItem;

                try
                {
                    //Insert into SQL
                    int result = _teacherCourseVM.Add(t.ID.ToString(), sem.SemesterID.ToString(), col.CollegeID, crs.CourseID);
                    if (result > 0)
                    {
                        ClsMessenger.ShowMessage($"Teacher {t.ID} is assigned to Course {crs.Name} at {col.CollegeName}");
                    }
                }
                catch (Exception ex)
                {
                    ClsMessenger.ShowMessage(ex.Message);
                }

                CollectionViewSource.GetDefaultView(_teacherCourseVM.TeacherCourseInfo).Refresh();
            }
            else
            {
                ClsMessenger.ShowMessage("Select Teacher, Semester College and Course please");
            }
  
        }

        private void DeassignButton_Click(object sender, RoutedEventArgs e)
        {
            if (teacherCourseLV.SelectedItem != null)
            {
                ClsTeacherCourse tc = (ClsTeacherCourse)teacherCourseLV.SelectedItem;
                try
                {
                    //Delete from SQL
                    _teacherCourseVM.Delete(tc.TeacherID, tc.CCSID);
                   
                    ClsMessenger.ShowMessage($"Teacher {tc.TeacherFName} {tc.TeacherLName} " +
                        $"is de-assigned from Course {tc.CourseName} at {tc.CollegeName}");
                }
                catch (Exception ex)
                {
                    ClsMessenger.ShowMessage(ex.Message);
                }

                CollectionViewSource.GetDefaultView(_teacherCourseVM.TeacherCourseInfo).Refresh();

            }
            
        }     

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.GoBack();
        }

        #endregion

        #region SetUp
        private void SetUp()
        {
            _teacherCourseVM = new ClsTeacherCourseViewModel();
            DataContext = _teacherCourseVM;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(_teacherCourseVM.TeacherCourseInfo);
            view.Filter = UserFilter;
        }
        #endregion



        #region Filters
        private bool UserFilter(object record)
        {
            return SemesterFilter(record) && CollegeFilter(record) && CourseFilter(record) && TeacherFilter(record);
        }

        private bool SemesterFilter(object record)
        {
            if (semestersLV.SelectedItem == null)
            {
                return true;
            }
            else
            {
                return (record as ClsTeacherCourse)
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
                return (record as ClsTeacherCourse)
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
                return (record as ClsTeacherCourse)
                    .CourseID.Equals(((ClsCourse)coursesLV.SelectedItem).CourseID);

            }
        }

        private bool TeacherFilter(object record)
        {
            if (teachersLV.SelectedItem == null)
            {
                return true;
            }
            else
            {
                return (record as ClsTeacherCourse)
                    .TeacherID.Equals(((ClsTeacher)teachersLV.SelectedItem).ID);

            }
        }

        #endregion

        #region FiltersSelection
        private void semestersLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(_teacherCourseVM.TeacherCourseInfo).Refresh();
        }

        private void collegesLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(_teacherCourseVM.TeacherCourseInfo).Refresh();
        }

        private void coursesLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(_teacherCourseVM.TeacherCourseInfo).Refresh();
        }


        private void teachersLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(_teacherCourseVM.TeacherCourseInfo).Refresh();
        }

        #endregion

        #region Clear Filters Buttons

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

        private void clearTeacherBtn_Click(object sender, RoutedEventArgs e)
        {
            teachersLV.SelectedItem = null;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            clearTeacherBtn_Click(sender, e);
            clearSemesterBtn_Click(sender, e);
            clearCollegeBtn_Click(sender, e);
            clearCourseBtn_Click(sender, e);
        }

        #endregion

    }
}
