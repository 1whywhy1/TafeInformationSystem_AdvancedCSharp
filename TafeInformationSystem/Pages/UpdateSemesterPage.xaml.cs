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
    /// Interaction logic for UpdateSemesterPage.xaml
    /// </summary>
    public partial class UpdateSemesterPage : Page
    {
        private Frame _mainFrame;

        public UpdateSemesterPage()
        {
            InitializeComponent();
        }

        public UpdateSemesterPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            updateButton.Visibility = Visibility.Visible;
            editButton.Visibility = Visibility.Hidden;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            updateButton.Visibility = Visibility.Hidden;
            editButton.Visibility = Visibility.Visible;
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.GoBack();
        }
    }
}
