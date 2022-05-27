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
        private static MainWindow mainWindow_instance = null;
        private UserType _userType;
        private string _userID = "1";

        #region Constructors
        public MainWindow()
        {
            InitializeComponent();
           
        }

        public MainWindow(UserType userType)
        {
            InitializeComponent();
            _userType = userType;

        }

        public MainWindow(string userID)
        {
            InitializeComponent();
            _userID = userID;

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
        public UserType UserType { get { return _userType; } }
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
            _mainFrame.Navigate(new PersonalPage(_userID));
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

        private void locationsButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new LocationsMenuPage(_mainFrame));
        }


        private void SemestersButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new SemesterMenuPage(_mainFrame));
        }

        #endregion

    }
}
