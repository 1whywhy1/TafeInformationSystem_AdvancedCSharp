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
    /// Interaction logic for EnrollmentMenuPage.xaml
    /// </summary>
    public partial class EnrollmentMenuPage : Page
    {
        private Frame _mainFrame;

        public EnrollmentMenuPage()
        {
            InitializeComponent();
        }
        public EnrollmentMenuPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

       

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (_mainFrame != null)
            {
                _mainFrame.Navigate(new FindEnrolmentPage(_mainFrame));
            }
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            if (_mainFrame != null)
            {
                _mainFrame.Navigate(new StudentEnrollmentPage(_mainFrame));
            }
        }
    }
}
