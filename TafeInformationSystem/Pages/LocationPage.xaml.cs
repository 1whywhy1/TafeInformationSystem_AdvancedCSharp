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
using TafeInformationSystem.Enums;

namespace TafeInformationSystem.Pages
{
    /// <summary>
    /// Interaction logic for LocationPage.xaml
    /// </summary>
    public partial class LocationPage : Page
    {
        private Frame _mainFrame;

        private Control[] _infoCntls = new Control[6];

        // For UI
        private UIState _state;

        public LocationPage()
        {
            InitializeComponent();
            SetUp();
        }

        public LocationPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
            SetUp();
        }
        public LocationPage(Frame mainFrame, UIState state)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
            _state = state;
            SetUp();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {           
            SetUIState(UIState.Edit);
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {           
            locationNameText.Text = "";
            phoneText.Text = "";
            streetText.Text = "";
            suburbText.Text = "";
            stateCmb.Text = "";
            postcodeText.Text = "";
            stateCmb.SelectedItem = null;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.GoBack();
        }

        #region SetUp
        public void SetUp()
        {
            _infoCntls[0] = locationNameText;
            _infoCntls[1] = phoneText;
            _infoCntls[2] = streetText;
            _infoCntls[3] = suburbText;
            _infoCntls[4] = stateCmb;
            _infoCntls[5] = postcodeText;

            SetUIState(_state);

            // Set state combobox values
            stateCmb.ItemsSource = Enum.GetValues(typeof(AustralianStates)).Cast<AustralianStates>();
        }

        #endregion

        #region UIStateSettings
        public void SetUIState(UIState state)
        {
            _state = state;
            
            // Buttons Visibility

            //editButton.Visibility = (_state == UIState.Default) ? Visibility.Visible : Visibility.Hidden;
            deleteButton.Visibility = (_state == UIState.Edit) ? Visibility.Visible : Visibility.Hidden;
            updateButton.Visibility = (_state == UIState.Edit) ? Visibility.Visible : Visibility.Hidden;
            clearButton.Visibility = (_state == UIState.Default) ? Visibility.Visible : Visibility.Hidden;
            cancelButton.Visibility = (_state == UIState.Edit) ? Visibility.Visible : Visibility.Hidden;
            //editPnl.Visibility = (_state == UIState.Edit) ? Visibility.Visible : Visibility.Hidden;

            // InfoControls set active depending on state
            bool isEditable = (_state != UIState.Default) ? true : false;
            ClsUtils.SetActiveControls(_infoCntls, false);
            

        }
        #endregion

       
    }
}
