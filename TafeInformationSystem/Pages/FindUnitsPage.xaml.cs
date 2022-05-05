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
        #region Variables
        private Frame _mainFrame;

        #endregion

        #region Constructors 
        public FindUnitsPage()
        {
            InitializeComponent();
        }
  

        public FindUnitsPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }
        #endregion

        #region Buttons
        // Navigates to prev page
        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.GoBack();
        }

        // Depending on SearchBy creates unit object and sends call to retrieve information
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt;
            ClsUnit unit;

            switch (searchBycmb.SelectedIndex)
            {
                case 0:
                    unit = new ClsUnit(searchCriteriaText.Text, Enums.SearchCriteria.UnitSearchBy.ID);
                    dt = unit.Search(Enums.SearchCriteria.UnitSearchBy.ID);
                    break;
                case 1:
                    unit = new ClsUnit(searchCriteriaText.Text, Enums.SearchCriteria.UnitSearchBy.Name);
                    dt = unit.Search(Enums.SearchCriteria.UnitSearchBy.Name);
                    break;
                case 2:
                    unit = new ClsUnit(searchCriteriaText.Text, Enums.SearchCriteria.UnitSearchBy.AllForCourse);
                    dt = unit.Search(Enums.SearchCriteria.UnitSearchBy.AllForCourse);
                    break;
                case 3:
                    searchCriteriaText.Text = "";
                    unit = new ClsUnit(searchCriteriaText.Text, Enums.SearchCriteria.UnitSearchBy.NotAllocated);
                    dt = unit.Search(Enums.SearchCriteria.UnitSearchBy.NotAllocated);
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
                // Populate DataGrid from SQL
                unitsDataGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e) 
        {
            searchCriteriaText.Text = "";
            unitsDataGrid.ItemsSource = null;
        }
      
        // Opens selected row to be able to edit
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView row = (DataRowView)unitsDataGrid.SelectedItem;

                ClsUnit unit = new ClsUnit(row.Row[0].ToString(), row.Row[1].ToString(),
                row.Row[2].ToString(), row.Row[3].ToString(), row.Row[4].ToString());
                _mainFrame.Navigate(new UnitsPage(_mainFrame, Enums.EntityPageType.Edit, row));
            }
            catch (NullReferenceException nex){ }
            catch (Exception ex){}
        }
        #endregion

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                SearchButton_Click(sender, e);
            }
        }

    }
}
