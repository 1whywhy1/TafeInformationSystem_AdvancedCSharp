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
    /// Interaction logic for CoursesPage.xaml
    /// </summary>
    public partial class CoursesPage : Page
    {
        private Frame _mainFrame;


        #region Constructors
        public CoursesPage()
        {
            InitializeComponent();
        }

        public CoursesPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

        public CoursesPage(Frame mainFrame, TafeInformationSystem.Enums.EntityPageType entityPageType)
        {
            InitializeComponent();
            _mainFrame = mainFrame;

            switch (entityPageType)
            {
                case Enums.EntityPageType.Add:
                    newButton.Visibility = Visibility.Visible;
                    editButton.Visibility = Visibility.Hidden;
                    updateButton.Visibility = Visibility.Hidden;
                    deleteButton.Visibility = Visibility.Hidden;
                    break;
                case Enums.EntityPageType.Edit:
                    newButton.Visibility = Visibility.Hidden;
                    editButton.Visibility = Visibility.Visible;
                    updateButton.Visibility = Visibility.Hidden;
                    deleteButton.Visibility = Visibility.Hidden;
                    break;
                default:
                    break;
            }
        }
        #endregion

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.GoBack();
        }
    }
}
