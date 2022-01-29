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
    /// Interaction logic for UnitsMenuPage.xaml
    /// </summary>
    public partial class UnitsMenuPage : Page
    {
        private Frame _mainFrame;

        public UnitsMenuPage()
        {
            InitializeComponent();
        }

        public UnitsMenuPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new UnitsPage(_mainFrame));
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new FindUnitsPage(_mainFrame));
        }
    }
}
