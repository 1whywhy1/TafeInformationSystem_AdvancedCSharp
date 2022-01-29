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

namespace TafeInformationSystem.Pages
{
    /// <summary>
    /// Interaction logic for CourseMenuPage.xaml
    /// </summary>
    public partial class CourseMenuPage : Page
    {
        Frame _mainFrame;

        public CourseMenuPage()
        {
            InitializeComponent();
        }
        public CourseMenuPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (_mainFrame != null)
            {
                _mainFrame.Navigate(new FindCoursesPage(_mainFrame));
            }
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            if (_mainFrame != null)
            {
                _mainFrame.Navigate(new CoursesPage(_mainFrame));
            }
        }

        private void AssignUnitsButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
