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
        Frame mainFrame;
        public CourseMenuPage()
        {
            InitializeComponent();
        }

        public CourseMenuPage(Frame mainFrame)
        {
            InitializeComponent();
            this.mainFrame = mainFrame;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainFrame != null)
                mainFrame.Navigate(new FindCoursesPage());
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainFrame != null)
                mainFrame.Navigate(new CoursesPage());
        }
    }
}
