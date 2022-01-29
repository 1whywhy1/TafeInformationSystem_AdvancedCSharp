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
    /// Interaction logic for LocationsMenuPage.xaml
    /// </summary>
    public partial class LocationsMenuPage : Page
    {
        private Frame _mainFrame;

        public LocationsMenuPage()
        {
            InitializeComponent();
        }

        public LocationsMenuPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new LocationPage(_mainFrame));
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new FindLocationsPage(_mainFrame));
        }
    }
}
