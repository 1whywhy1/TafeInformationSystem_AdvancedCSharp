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
    /// Interaction logic for StudentEnrollmentPage.xaml
    /// </summary>
    public partial class StudentEnrollmentPage : Page
    {
        private Frame _mainFrame;

        public StudentEnrollmentPage()
        {
            InitializeComponent();
        }

        public StudentEnrollmentPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }


        private void EnrolButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UnenrolButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.GoBack();
        }
    }
}
