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
    /// Interaction logic for SemesterPage.xaml
    /// </summary>
    public partial class SemesterPage : Page
    {
        #region Fields
        private Frame _mainFrame;
        private ClsSemesterViewModel _semesterVM;
        private Control[] controls = new Control[3];
        private UIState _state = UIState.View;

        #endregion

        #region Constructors
        public SemesterPage()
        {
            InitializeComponent();
            SetUp();
        }
        public SemesterPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
            SetUp();
        }

        #endregion

        #region Buttons
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            int id = _semesterVM.Add((DateTime)startDP.SelectedDate, (DateTime)endDP.SelectedDate);
            if(id >= 0 && id < 2)
            {
                semesterIDTxt.Text = id.ToString();
            }

            ClearButton_Click(this, e);
            SetUp();
            SetUIState(UIState.View);

        }
        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            SetUIState(UIState.Add);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            SetUIState(UIState.Edit);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            SetUIState(UIState.View); 
            ClearButton_Click(this, e);
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            _semesterVM.Update(semesterNameTxt.Text, (DateTime)startDP.SelectedDate, (DateTime)endDP.SelectedDate);
            ClsMessenger.ShowMessage($"Semester {semesterNameTxt.Text} has been updated!");

            SetUIState(UIState.View);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            semesterIDTxt.Text = "";
            semesterNameTxt.Text = "";
            startDP.SelectedDate = DateTime.Today;
            endDP.SelectedDate = DateTime.Today;
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.GoBack();
        }

        #endregion

        #region SetUp
        private void SetUp()
        {
            _semesterVM = new ClsSemesterViewModel();
            DataContext = _semesterVM;

            controls[0] = semesterNameTxt;
            controls[1] = startDP;
            controls[2] = endDP;

            SetUIState(UIState.View);

        }
        #endregion

        private void semestersLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClsSemester semester = (ClsSemester)semestersLV.SelectedItem;
            semesterIDTxt.Text = semester.SemesterID.ToString();
            semesterNameTxt.Text = semester.SemesterName;
            startDP.Text = semester.StartDate.ToString("dd-MM-YYYY");
            startDP.SelectedDate = semester.StartDate;
            endDP.Text = semester.EndDate.ToString("dd-MM-YYYY");
            endDP.SelectedDate = semester.EndDate;
        }

     

        private void startDP_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime dt = (DateTime)startDP.SelectedDate;
            endDP.SelectedDate = dt.AddDays(1);
        }

      

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
            ClsUtils.SetActiveControls(controls, (_state == UIState.Add || _state == UIState.Edit));
        }


        #endregion

   
    }
}
