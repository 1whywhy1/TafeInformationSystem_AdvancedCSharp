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
    /// Interaction logic for SemesterMenuPage.xaml
    /// </summary>
    public partial class SemesterMenuPage : Page
    {
        private Frame _mainFrame;

        public SemesterMenuPage()
        {
            InitializeComponent();
        }

        public SemesterMenuPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new UpdateSemesterPage(_mainFrame));
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new SemesterPage(_mainFrame));
        }
    }
}
