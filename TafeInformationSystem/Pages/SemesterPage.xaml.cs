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

namespace TafeInformationSystem.Pages
{
    /// <summary>
    /// Interaction logic for SemesterPage.xaml
    /// </summary>
    public partial class SemesterPage : Page
    {
        #region Fields
        private Frame _mainFrame;
        private ClsSemester _semester;

        #endregion

        #region Constructors
        public SemesterPage()
        {
            InitializeComponent();
        }
        public SemesterPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

        #endregion

        #region Buttons
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.GoBack();
        }

        #endregion

        #region SetUp
        private void SetUp()
        {
            _semester = new ClsSemester();
            DataContext = _semester;
        }
        #endregion
    }
}
