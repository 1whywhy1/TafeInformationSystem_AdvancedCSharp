using DLLDatabase;
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
using TafeInformationSystem.Enums;

namespace TafeInformationSystem
{
    /// <summary>
    /// Interaction logic for TeacherLogin.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public UserType _userType = UserType.student;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            bool loginSuccess = false;

            switch (_userType)
            {
                case UserType.student:
                    loginSuccess = clsDatabase.Login(_userType, 
                        loginText.Text, passwordText.Password);
                    break;
                case UserType.teacher:
                    loginSuccess = clsDatabase.Login(_userType, 
                        loginText.Text, passwordText.Password); 
                    break;
                default:
                    break;
            }

            if (loginSuccess)
            {
                MainWindow mainWindow = MainWindow.getInstance();
                mainWindow.UserType = _userType;
                mainWindow.UserID = loginText.Text;
                mainWindow.SetLandingPage();
                mainWindow.Show();
                Close();
            }

        }

        private void StudentButton_Click(object sender, RoutedEventArgs e)
        {
            _userType = UserType.student;
        }

        private void TeacherButton_Click(object sender, RoutedEventArgs e)
        {
            _userType= UserType.teacher;
        }
    }
}
