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
    /// Interaction logic for UnitsPage.xaml
    /// </summary>
    public partial class UnitsPage : Page
    {
        private Frame _mainFrame;

        public UnitsPage()
        {
            InitializeComponent();
        }
        public UnitsPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

        public UnitsPage(Frame mainFrame, TafeInformationSystem.Enums.EntityPageType entityPageType)
        {
            InitializeComponent();
            _mainFrame = mainFrame;

            switch (entityPageType)
            {
                case Enums.EntityPageType.Add:
                    newButton.Visibility = Visibility.Visible;
                    editButton.Visibility = Visibility.Hidden;
                    updateButton.Visibility = Visibility.Hidden;
                    deleteButton.Visibility = Visibility.Visible;
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

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.GoBack();
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClsUnit unit = new ClsUnit(unitNameText.Text, unitDescriptionText.Text, unitPointValueText.Text, unitPriceText.Text);
                unit.Add();
                unitIdText.Text = unit.UnitID;
                MessageBox.Show("Unit added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {


            newButton.Visibility = Visibility.Hidden;
            editButton.Visibility = Visibility.Hidden;
            updateButton.Visibility = Visibility.Visible;
            deleteButton.Visibility = Visibility.Visible;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClsUnit unit = new ClsUnit(unitIdText.Text,unitNameText.Text, unitDescriptionText.Text, unitPointValueText.Text, unitPriceText.Text);
                unit.Update();             
                MessageBox.Show("Unit updated!");

                newButton.Visibility = Visibility.Hidden;
                editButton.Visibility = Visibility.Visible;
                updateButton.Visibility = Visibility.Hidden;
                deleteButton.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            unitNameText.Text = "";
            unitIdText.Text = "";
            unitPointValueText.Text = "";
            unitPriceText.Text = "";
            unitDescriptionText.Text = "";

            newButton.Visibility = Visibility.Visible;
            editButton.Visibility = Visibility.Hidden;
            updateButton.Visibility = Visibility.Hidden;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ClsUnit unit = new ClsUnit("1002", Enums.SearchCriteria.UnitSearchBy.ID);
            unit.Search(Enums.SearchCriteria.UnitSearchBy.ID);
            unitIdText.Text = unit.UnitID;
            unitNameText.Text = unit.Name;
        }
    }
}
