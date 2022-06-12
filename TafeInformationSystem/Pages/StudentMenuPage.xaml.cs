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
using TafeInformationSystem.Classes;
using TafeInformationSystem.Enums;

namespace TafeInformationSystem.Pages
{
    /// <summary>
    /// Interaction logic for StudentMenuPage.xaml
    /// </summary>
    public partial class StudentMenuPage : Page
    {
        private Frame _mainFrame;

        public StudentMenuPage()
        {
            InitializeComponent();
        }

        public StudentMenuPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new PersonalPage(_mainFrame, new ClsStudent(), UIState.Add));
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new StudentsPage(_mainFrame));
        }

        private void ManageEnrollmentsButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new FindEnrolmentPage(_mainFrame));
        }
    }
}
