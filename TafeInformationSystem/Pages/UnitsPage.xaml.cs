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
    /// Interaction logic for UnitsPage.xaml
    /// </summary>
    public partial class UnitsPage : Page
    {

        private Frame _mainFrame;
        Control[] txtBoxes = new Control[4];

        #region Constructors

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
            SetUp(entityPageType);
        }

        public UnitsPage(Frame mainFrame, TafeInformationSystem.Enums.EntityPageType entityPageType, DataRowView unitRow)
        {
            InitializeComponent();
            _mainFrame = mainFrame;

            SetUp(entityPageType);
            ClsUtils.SetActiveControls(txtBoxes, false);

            unitIdText.Text = unitRow.Row[0].ToString();
            unitNameText.Text = unitRow.Row[1].ToString();
            unitDescriptionText.Text = unitRow.Row[2].ToString();
            unitPointValueText.Text = unitRow.Row[3].ToString();
            unitPriceText.Text = unitRow.Row[4].ToString();
        }

        #endregion

        #region Buttons
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

            ClsUtils.SetActiveControls(txtBoxes, true);
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

                ClsUtils.SetActiveControls(txtBoxes, false);
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

            ClsUtils.SetActiveControls(txtBoxes, true);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ClsUnit unit = new ClsUnit(unitIdText.Text, Enums.SearchCriteria.UnitSearchBy.ID);
            try
            {
                if (unit.Delete() > 0)
                {
                    MessageBox.Show($"Unit with ID {unitIdText.Text} is deleted!");
                    ClearButton_Click(sender, e); 
                }
                else
                {
                    MessageBox.Show("Unit not found");
                }

            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
            //MessageBox.Show($"Unit with ID {unitIdText.Text} has been deleted!");
        }
        #endregion

        private void SetUp(TafeInformationSystem.Enums.EntityPageType entityPageType)
        {
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
            txtBoxes[0] = unitNameText;
            txtBoxes[1] = unitDescriptionText;
            txtBoxes[2] = unitPointValueText;
            txtBoxes[3] = unitPriceText;
        }
    }
}
