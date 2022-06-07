using DLLDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TafeInformationSystem.Classes;

namespace TafeInformationSystem.Pages
{
    /// <summary>
    /// Interaction logic for CourseUnitPage.xaml
    /// </summary>
    public partial class CourseUnitPage : Page
    {
        public enum UIState
        {
            Edit,
            Save,
            Default
        }

        #region Fields
        private UIState _state = UIState.Default;
        Frame _mainFrame;

        #endregion

        #region Properties
        public UIState CurrentState
        {
            get; private set;
        }

        #endregion


        #region Constructor
        public CourseUnitPage()
        {
            InitializeComponent();
        }
        public CourseUnitPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
            SetUp();
        }
        #endregion


        #region Buttons      
        private void AddUnitBtn_Click(object sender, RoutedEventArgs e)
        {
            if(unitsListView.SelectedItems is not null)
            {
                //courseUnitsListView.ItemsSource.
            }
        }

        private void DeleteFromCourseBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

            SetUIState(UIState.Default);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.GoBack();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

            SetUIState(UIState.Edit);
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            SetUIState(UIState.Default);
        } 
        #endregion

        #region SetUp
        private void SetUp()
        {
            DataContext = new ClsCourseUnit();
            
            SetUIState(UIState.Default);
            PopulateAllUnitsView();
            courseCmb.SelectedIndex = 0;
        }
        #endregion

        #region UIStateSettings
        public void SetUIState(UIState state)
        {
            _state = state;

            editButton.Visibility = (_state == UIState.Default) ? Visibility.Visible : Visibility.Hidden;
            updateButton.Visibility = (_state == UIState.Edit) ? Visibility.Visible : Visibility.Hidden;
            cancelButton.Visibility = (_state == UIState.Edit) ? Visibility.Visible : Visibility.Hidden;            
            editPnl.Visibility = (_state == UIState.Edit) ? Visibility.Visible : Visibility.Hidden;

        }
        #endregion

        // On courseCmb Seletion change refresh View of assigned units
        private void courseCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string str = courseCmb.SelectedValue.ToString().Substring(0, 4);
            
            courseUnitsListView.ItemsSource = ClsCourseUnit.RefreshUnitsForCourse(str).DefaultView;
            
        }

        private void PopulateAllUnitsView()
        {
            unitsListView.ItemsSource = ClsCourseUnit.RetrieveUnits(Enums.SearchCriteria.UnitSearchBy.All).DefaultView;
        }

      
    }
}
