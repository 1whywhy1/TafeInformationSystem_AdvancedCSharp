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
        #region Fields
        private Frame _mainFrame;
        private Control[] _infoCntls = new Control[6];
        private ClsLocationViewModel _locationVM;

        // For UI
        private UIState _state;

        #endregion

        #region Constructors
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

        #endregion

        #region Properties
  
        #endregion

        #region Buttons
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _locationVM.Add(locationNameText.Text, phoneText.Text,
                streetText.Text, postcodeText.Text, cityText.Text, stateCmb.SelectedItem.ToString());
        }
        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            ClearButton_Click(sender, e);
            SetUIState(UIState.Add);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {           
            SetUIState(UIState.Edit);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ClsMessenger.ShowMessage(stateCmb.SelectedItem.ToString());
            SetUIState(UIState.View);
            ClearButton_Click(this, e);
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            _locationVM.Update(idText.Text, locationNameText.Text, phoneText.Text,
                streetText.Text, postcodeText.Text, cityText.Text, stateCmb.SelectedItem.ToString());
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            idText.Text = "";
            locationNameText.Text = "";
            phoneText.Text = "";
            streetText.Text = "";
            cityText.Text = "";
            stateCmb.Text = "";
            postcodeText.Text = "";
            stateCmb.SelectedItem = null;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            _locationVM.Delete(idText.Text);
           
            ClsMessenger.ShowMessage($"College {locationNameText.Text} has been deleted!");
            ClearButton_Click(sender, e);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.GoBack();
        }

        #endregion

        #region SetUp
        public void SetUp()
        {
            _infoCntls[0] = locationNameText;
            _infoCntls[1] = phoneText;
            _infoCntls[2] = streetText;
            _infoCntls[3] = cityText;
            _infoCntls[4] = stateCmb;
            _infoCntls[5] = postcodeText;

            SetUIState(UIState.View);

            _locationVM = new ClsLocationViewModel();
            DataContext = _locationVM;

            // Set state combobox values
            stateCmb.ItemsSource = Enum.GetValues(typeof(AustralianStates)).Cast<AustralianStates>();


        }

        #endregion

        #region SelectionChanged
        private void collegesLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClsCollege college = (ClsCollege)collegesLV.SelectedItem;
            locationNameText.Text = college.CollegeName;
            idText.Text = college.CollegeID.ToString();
            phoneText.Text = college.PhoneNumber;
            streetText.Text = college.StreetAddress;
            cityText.Text = college.City;
            postcodeText.Text = college.Postcode;
            stateCmb.Text = college.State;

        }

        #endregion

        #region SetUIState
        private void SetUIState(UIState state)
        {
            _state = state;
            addButton.Visibility = (_state == UIState.Add) ? Visibility.Visible : Visibility.Hidden;
            newButton.Visibility = (_state == UIState.View) ? Visibility.Visible : Visibility.Hidden;
            editButton.Visibility = (_state == UIState.View) ? Visibility.Visible : Visibility.Hidden;
            updateButton.Visibility = (_state == UIState.Edit) ? Visibility.Visible : Visibility.Hidden;
            cancelButton.Visibility = (_state == UIState.Add || _state == UIState.Edit) ? Visibility.Visible : Visibility.Hidden;
            clearButton.Visibility = (_state == UIState.Add || _state == UIState.Edit) ? Visibility.Visible : Visibility.Hidden;
            ClsUtils.SetActiveControls(_infoCntls, (_state == UIState.Add || _state == UIState.Edit));
        }

        #endregion

     
    }
}
