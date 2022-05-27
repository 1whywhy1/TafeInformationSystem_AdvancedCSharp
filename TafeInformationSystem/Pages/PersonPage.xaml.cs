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
using TafeInformationSystem.Enums;

namespace TafeInformationSystem.Pages
{
    /// <summary>
    /// Interaction logic for PersonPage.xaml
    /// </summary>
    public partial class PersonPage : Page
    {
        #region Fields
        private Frame _mainFrame;
        private UserType _userType;

        #endregion

        #region Constructors
        public PersonPage()
        {
            InitializeComponent();          
        }

        public PersonPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

        public PersonPage(Frame mainFrame, UserType userType)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }


        #endregion

        #region Buttons
        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.GoBack();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

    }
}
