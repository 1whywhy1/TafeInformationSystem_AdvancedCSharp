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
using TafeInformationSystem.Enums;

namespace TafeInformationSystem.Pages
{
    /// <summary>
    /// Interaction logic for CourseUnitPage.xaml
    /// </summary>
    public partial class CourseUnitPage : Page
    {        
        #region Fields
        private UIState _state = UIState.Default;
        Frame _mainFrame;

        private ClsCourseUnit _courseUnit;
        private string _selectedCourse;

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
            if (courseUnitsListView.Items.Count < 4)
            {
                if (unitsListView.SelectedItems is not null )
                {
                    bool unitAssigned = false;
                    foreach (ClsUnit selectedUnit in unitsListView.SelectedItems)
                    {
                        foreach (ClsUnit courseUnit in courseUnitsListView.Items)
                        {
                            if(selectedUnit.UnitID == courseUnit.UnitID)
                            {
                                unitAssigned = true;
                                MessageBox.Show($"Unit {selectedUnit.UnitID} is already assigned to Course {_selectedCourse}");
                                break;
                            }

                        }
                        if (!unitAssigned && courseUnitsListView.Items.Count < 4)
                        {
                            _courseUnit.UnitCourseInfo.Add(selectedUnit);
                        }

                        unitAssigned = false;
                    }
                    
                    //DataRowView row = (DataRowView)unitsListView.SelectedItem;
                    //{
                    //    _courseUnit.UnitCourseInfo.Add(new ClsUnit(row.Row[0].ToString(), row.Row[1].ToString()));
                    //}
                }
            }
            else
            { 
                MessageBox.Show("Maximum of 4 units can be assigned to a course"); 
            }
            
        }

        private void DeleteFromCourseBtn_Click(object sender, RoutedEventArgs e)
        {
            _courseUnit.UnitCourseInfo.Remove(courseUnitsListView.SelectedItem as ClsUnit);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _courseUnit.DiscardEdit();
            SetUIState(UIState.Default);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.GoBack();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            _courseUnit.PrepareEdit();
            SetUIState(UIState.Edit);
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            _courseUnit.UpdateUnitCourse(_selectedCourse);
            SetUIState(UIState.Default);
        } 
        #endregion

        #region SetUp
        private void SetUp()
        {
            _courseUnit = new ClsCourseUnit();
            DataContext = _courseUnit;
            
            SetUIState(UIState.Default);
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
            _selectedCourse = courseCmb.SelectedValue.ToString().Substring(0, 4);           
            _courseUnit.RetrieveUnitsForCourse(_selectedCourse);           
            
        }   
      
    }
}
