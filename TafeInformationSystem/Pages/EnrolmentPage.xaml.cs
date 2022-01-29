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
    /// Interaction logic for EnrolmentPage.xaml
    /// </summary>
    public partial class EnrolmentPage : Page
    {
        private Frame _mainFrame;

        public EnrolmentPage()
        {
            InitializeComponent();
        }

        public EnrolmentPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }
        private void UpdateStatusButton_Click(object sender, RoutedEventArgs e)
        {
            saveButton.Visibility = Visibility.Visible;
            updateStatusButton.Visibility = Visibility.Hidden;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            updateStatusButton.Visibility = Visibility.Visible;
            saveButton.Visibility = Visibility.Hidden;
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.GoBack();
        }
    }
}
