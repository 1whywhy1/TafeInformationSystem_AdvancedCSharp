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
using TafeInformationSystem.Classes;
using TafeInformationSystem.Enums;

namespace TafeInformationSystem.Pages
{
    /// <summary>
    /// Interaction logic for PersonalPage.xaml
    /// </summary>
    /// 

    public partial class PersonalPage : Page
    {

        #region Variables
        private string _id;
        private ClsPerson _user;
        private UserType _userType = UserType.DEFAULT;
        private Control[] _userInfoCntrls = new Control[13];
        private Frame _mainFrame;

        private UIState _state = UIState.Default;
        private UIState _passwordState = UIState.Default;
        #endregion


        #region Constructors
        public PersonalPage()
        {
            InitializeComponent();
            SetUp();
        }

        // To bring up the user profile
        public PersonalPage(string id)
        {
            InitializeComponent();
            _id = id;
            SetUp();
        }

        public PersonalPage(Frame mainFrame, ClsPerson user, UIState state)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
            _user = user;
            _state = state;
            SetUp();
        }

        #endregion

        #region Buttons      

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // _user = (_user is ClsStudent) ? new ClsStudent(firstNameTxt.Text, lastNameTxt.Text, (DateTime)dobPicker.SelectedDate, new ClsAddress(streetTxt.Text , a) : new ClsTeacher();
            if (_user is ClsStudent)
            {
                _user = new ClsStudent(firstNameTxt.Text, lastNameTxt.Text, (DateTime)dobPicker.SelectedDate,
                    new ClsAddress(streetTxt.Text, aptTxt.Text, postcodeTxt.Text, cityTxt.Text, stateCmb.SelectedItem.ToString()),
                    emailTxt.Text, homePhoneTxt.Text, mobilePhoneTxt.Text, genderCmb.SelectedIndex + 1);
            }
            else if (_user is ClsTeacher)
            {
                _user = new ClsTeacher(firstNameTxt.Text, lastNameTxt.Text, (DateTime)dobPicker.SelectedDate,
                    new ClsAddress(streetTxt.Text, aptTxt.Text, postcodeTxt.Text, cityTxt.Text, stateCmb.SelectedItem.ToString()),
                    emailTxt.Text, homePhoneTxt.Text, mobilePhoneTxt.Text, genderCmb.SelectedIndex + 1);
            }

            int id = _user.Add();

            if(id > 0)
            {
                idTxt.Text = _user.ID.ToString();
                ClsMessenger.ShowMessage($"User with ID = {_user.ID} has been added!");
                ClearButton_Click(this, e);
            }           

        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            if(_user is ClsStudent)
            {
                _user = new ClsStudent();
            }
            else if(_user is ClsTeacher)
            {
                _user = new ClsTeacher();
            }

            idTxt.Text = "";
            firstNameTxt.Text = "";
            lastNameTxt.Text = "";
            genderCmb.SelectedValue = 0;
            emailTxt.Text = "";
            homePhoneTxt.Text = "";
            mobilePhoneTxt.Text = "";
            streetTxt.Text = "";
            suburbTxt.Text = "";
            stateCmb.SelectedValue = 0;
            postcodeTxt.Text = "";
            aptTxt.Text = "";
            cityTxt.Text = "";
            dobPicker.Text = "";

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            ClsUtils.SetActiveControls(_userInfoCntrls, true);
            //editButton.Visibility = Visibility.Hidden;
            //updateButton.Visibility = Visibility.Visible;
            //cancelButton.Visibility = Visibility.Visible;
            SetUIState(UIState.Edit);

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            ClsUtils.SetActiveControls(_userInfoCntrls, false);

            _user.ID = idTxt.Text;
            _user.FName = firstNameTxt.Text;
            _user.LName = lastNameTxt.Text;
            _user.Dob = dobPicker.DisplayDate;           
            _user.Gender = genderCmb.SelectedIndex + 1;
            _user.Email = emailTxt.Text;
            _user.Hphone = homePhoneTxt.Text;
            _user.Mphone = mobilePhoneTxt.Text;
            _user.Address.StreetAddress = streetTxt.Text;
            _user.Address.Apt = aptTxt.Text;
            _user.Address.Postcode = suburbTxt.Text;
            _user.Address.State = stateCmb.Text;
            _user.Address.Postcode = postcodeTxt.Text;
            _user.Address.City = cityTxt.Text;

            _user.Update();
            SetUIState(UIState.View);
            ClsMessenger.ShowMessage("Record updated!");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ClsUtils.SetActiveControls(_userInfoCntrls, false);
            PopulateFieldsFromObject();
            SetUIState(UIState.View);
        }

        private void ChangePassButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshPasswordFields();
            SetPasswordUIState(UIState.Edit);
        }

        private void SavePassButton_Click(object sender, RoutedEventArgs e)
        {
            if(_user.Login(idTxt.Text,oldPasswordTxt.Password) && 
                newPasswordTxt.Password == repeatNewPasswordTxt.Password)
            {
                _user.UpdatePassword(oldPasswordTxt.Password, newPasswordTxt.Password);
                RefreshPasswordFields();
                SetPasswordUIState(UIState.Default);
            }
            else
            { 
                ClsMessenger.ShowMessage("Wrong password, try again"); 
            }
            RefreshPasswordFields();
        }

        private void CancelChangePassButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshPasswordFields();
            SetPasswordUIState(UIState.Default);
        }

        private void RefreshPasswordFields()
        {
            oldPasswordTxt.Password = "";
            newPasswordTxt.Password = "";
            repeatNewPasswordTxt.Password = "";
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.GoBack();
        }
        #endregion

        private void SetUp()
        {
            // Set page name at the bottom
            if (_user is ClsStudent)
            {
                pageNameTxt.Text = "Student ";
            }
            else if (_user is ClsTeacher)
            {
                pageNameTxt.Text = "Teacher ";
            }

            // Populating personal info text array to trigger editing mode
            _userInfoCntrls[0] = firstNameTxt;
            _userInfoCntrls[1] = lastNameTxt;
            _userInfoCntrls[2] = dobPicker;
            _userInfoCntrls[3] = genderCmb;
            _userInfoCntrls[4] = emailTxt;
            _userInfoCntrls[5] = homePhoneTxt;
            _userInfoCntrls[6] = mobilePhoneTxt;
            _userInfoCntrls[7] = streetTxt;
            _userInfoCntrls[8] = suburbTxt;
            _userInfoCntrls[9] = stateCmb;
            _userInfoCntrls[10] = postcodeTxt;
            _userInfoCntrls[11] = aptTxt;
            _userInfoCntrls[12] = cityTxt;

            RefreshPasswordFields();

            SetUIState(_state);
            if(_state == UIState.Default)
            {
                SetPasswordUIState(UIState.Default);
            }
            else
            {
                SetPasswordUIState(UIState.Add);
            }

            // Set state combobox values
            stateCmb.ItemsSource = Enum.GetValues(typeof(AustralianStates)).Cast<AustralianStates>();

            // Set controls not active
            ClsUtils.SetActiveControls(_userInfoCntrls, (_state == UIState.Add));

            if (_state != UIState.Add)
            {
                try
                {
                    // Populate controls data ClsPerson
                    _user.RetrieveUser();
                    PopulateFieldsFromObject();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {

                }
            }          

        }

        #region UIState Settings
        public void SetUIState(UIState state)
        {
            _state = state;

            // Buttons Visibility
            addButton.Visibility = (_state == UIState.Add) ? Visibility.Visible : Visibility.Hidden;
            editButton.Visibility = (_state == UIState.View || _state == UIState.Default) ? Visibility.Visible : Visibility.Hidden;           
            updateButton.Visibility = (_state == UIState.Edit) ? Visibility.Visible : Visibility.Hidden;
            clearButton.Visibility = (_state == UIState.Add) ? Visibility.Visible : Visibility.Hidden;
            cancelButton.Visibility = (_state == UIState.Edit) ? Visibility.Visible : Visibility.Hidden;
            backButton.Visibility = (_state != UIState.Default) ? Visibility.Visible : Visibility.Hidden;

            // InfoControls set active depending on state
            bool isEditable = (_state != UIState.Default) ? true : false;
        }

        public void SetPasswordUIState(UIState state)
        {
            _passwordState = state;
            changePassButton.Visibility = (_passwordState == UIState.Default && _passwordState != UIState.Add) ? Visibility.Visible : Visibility.Hidden;
            cancelChangePassButton.Visibility = (_passwordState != UIState.Default && _passwordState != UIState.Add) ? Visibility.Visible : Visibility.Hidden;
            savePassButton.Visibility = (_passwordState != UIState.Default && _passwordState != UIState.Add) ? Visibility.Visible : Visibility.Hidden;
            changePassBrdr.Visibility = (_passwordState != UIState.Default && _passwordState != UIState.Add) ? Visibility.Visible : Visibility.Hidden;
        }

        #endregion

        private void PopulateFieldsFromObject()
        {
            if (_user != null)
            {
                idTxt.Text = _user.ID;
                firstNameTxt.Text = _user.FName;
                lastNameTxt.Text = _user.LName;
                dobPicker.DisplayDate = _user.Dob;
                dobPicker.Text = _user.Dob.ToString();
                genderCmb.SelectedIndex = _user.Gender - 1;
                emailTxt.Text = _user.Email;
                homePhoneTxt.Text = _user.Hphone;
                mobilePhoneTxt.Text = _user.Mphone;
                streetTxt.Text = _user.Address.StreetAddress;
                aptTxt.Text = _user.Address.Apt;
                suburbTxt.Text = _user.Address.Postcode;
                stateCmb.Text = _user.Address.State;
                postcodeTxt.Text = _user.Address.Postcode;
                cityTxt.Text = _user.Address.City;
            }

        }     
    }
}
