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
    /// Interaction logic for CourseUnitPage.xaml
    /// </summary>
    public partial class CourseUnitPage : Page
    {
        Frame _mainFrame;

        public CourseUnitPage()
        {
            InitializeComponent();
        }
        public CourseUnitPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }
      
        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.GoBack();
        }

        private void DeassignButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AssignButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
