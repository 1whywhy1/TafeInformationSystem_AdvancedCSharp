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
using TafeInformationSystem.Classes;
using TafeInformationSystem.Enums;
using TafeInformationSystem.Pages;

namespace TafeInformationSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields
        private static MainWindow mainWindow_instance;
        private UserType _userType = UserType.student;
        private string _userID = "1";
        #endregion

        #region Constructors
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(UserType userType, string userID)
        {
            InitializeComponent();
            _userType = userType;

        }

        #endregion

        #region Singleton
        public static MainWindow getInstance()
        {
            if (mainWindow_instance == null)
                mainWindow_instance = new MainWindow();

            return mainWindow_instance;
        }
        #endregion

        #region Properties
        public UserType UserType { get { return _userType; } set { _userType = value; } }
        public string UserID { get { return _userID; } set { _userID = value; } }

        #endregion

        #region Navigation Buttons
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow lw = new LoginWindow();
            lw.Show();
            this.Close();
        }

        private void PersonalPageButton_Click(object sender, RoutedEventArgs e)
        {   
            switch (_userType)
            {
                case UserType.student:
                    _mainFrame.Navigate(new PersonalPage(_mainFrame, new ClsStudent(_userID), UIState.Default));
                    break;
                case UserType.teacher:
                    _mainFrame.Navigate(new PersonalPage(_mainFrame, new ClsTeacher(_userID), UIState.Default));
                    break;
                case UserType.DEFAULT:
                    break;
                default:
                    break;
            }
        }

        private void TeachersButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new TeacherMenuPage(_mainFrame));
        }

        private void CoursesButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new CourseMenuPage(_mainFrame));
        }

        private void StudentsButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new StudentMenuPage(_mainFrame));
        }

        private void UnitsButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new UnitsMenuPage(_mainFrame));
        }

        private void EnrollmentsButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new EnrollmentMenuPage(_mainFrame));
        }

        private void LocationsButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new LocationPage(_mainFrame));
        }


        private void SemestersButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new SemesterPage(_mainFrame));
        }

        #endregion

    }
}
