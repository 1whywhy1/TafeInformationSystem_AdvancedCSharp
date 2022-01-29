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
    /// Interaction logic for FindEnrolmentPage.xaml
    /// </summary>
    public partial class FindEnrolmentPage : Page
    {
        private Frame _mainFrame;

        public FindEnrolmentPage()
        {
            InitializeComponent();
        }

        public FindEnrolmentPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            enrolmentListView.Items.Clear();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.GoBack();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new EnrolmentPage(_mainFrame));
        }
    }
}
