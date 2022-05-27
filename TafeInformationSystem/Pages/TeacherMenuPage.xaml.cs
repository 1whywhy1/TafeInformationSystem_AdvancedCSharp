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

namespace TafeInformationSystem.Pages
{
    /// <summary>
    /// Interaction logic for TeacherMenuPage.xaml
    /// </summary>
    public partial class TeacherMenuPage : Page
    {
        private Frame _mainFrame;

        public TeacherMenuPage()
        {
            InitializeComponent();          
        }
        public TeacherMenuPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

        
        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new PersonPage(_mainFrame, UserType.teacher));
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
           _mainFrame.Navigate(new FindTeacherPage(_mainFrame));
        }

        private void AssignCourseButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
