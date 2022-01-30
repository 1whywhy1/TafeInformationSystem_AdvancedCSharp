using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for FindUnitsPage.xaml
    /// </summary>
    public partial class FindUnitsPage : Page
    {
        private Frame _mainFrame;

        public FindUnitsPage()
        {
            InitializeComponent();
        }

        public FindUnitsPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.GoBack();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt;
            ClsUnit unit;

            switch (searchBycmb.SelectedIndex)
            {
                case 0:
                    unit = new ClsUnit(searchCriteriaText.Text, Enums.SearchCriteria.UnitSearchBy.ID);
                    dt = unit.SearchDataTable(Enums.SearchCriteria.UnitSearchBy.ID);
                    break;
                case 1:
                    unit = new ClsUnit(searchCriteriaText.Text, Enums.SearchCriteria.UnitSearchBy.Name);
                    dt = unit.SearchDataTable(Enums.SearchCriteria.UnitSearchBy.Name);
                    break;
                case 2:
                    unit = new ClsUnit(searchCriteriaText.Text, Enums.SearchCriteria.UnitSearchBy.AllForCourse);
                    dt = unit.SearchDataTable(Enums.SearchCriteria.UnitSearchBy.AllForCourse);
                    break;
                case 3:
                    unit = new ClsUnit(searchCriteriaText.Text, Enums.SearchCriteria.UnitSearchBy.NotAllocated);
                    dt = unit.SearchDataTable(Enums.SearchCriteria.UnitSearchBy.NotAllocated);
                    break;

                default:
                    dt = null;
                    break;
            }

            if (dt == null)
            {
                _ = MessageBox.Show("No record");
            }
            else
            {
                unitsDataGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            unitsDataGrid.ItemsSource = null;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
