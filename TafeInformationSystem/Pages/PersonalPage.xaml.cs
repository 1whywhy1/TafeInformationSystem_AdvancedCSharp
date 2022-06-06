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
        private Control[] userInfoControls = new Control[11];
        private Control[] passwordChangeCtrls = new Control[4];
        private Frame _mainFrame;
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

        public PersonalPage(Frame mainFrame, ClsPerson user)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
            _user = user;
            _id = user.ID;
            SetUp();
        }

        #endregion

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            ClsUtils.SetActiveControls(userInfoControls, true);
            editButton.Visibility = Visibility.Hidden;
            saveButton.Visibility = Visibility.Visible;
            cancelButton.Visibility = Visibility.Visible;

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            ClsUtils.SetActiveControls(userInfoControls, false);
            cancelChangePassButton.Visibility = Visibility.Hidden;
            saveButton.Visibility = Visibility.Hidden;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ClsUtils.SetActiveControls(userInfoControls, false);
            PopulateFieldsFromObject();
            editButton.Visibility = Visibility.Visible;
            cancelButton.Visibility = Visibility.Hidden;
            saveButton.Visibility = Visibility.Hidden;
        }

        private void ChangePassButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshPasswordFields(Visibility.Visible);
            changePassButton.Visibility = Visibility.Hidden;
            savePassButton.Visibility = Visibility.Visible;
        }

        private void SavePassButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshPasswordFields(Visibility.Hidden);
            savePassButton.Visibility = Visibility.Hidden;
            changePassButton.Visibility = Visibility.Visible;
        }

        private void CancelChangePassButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshPasswordFields(Visibility.Hidden);
            savePassButton.Visibility = Visibility.Hidden;
            changePassButton.Visibility = Visibility.Visible;
            cancelChangePassButton.Visibility = Visibility.Hidden;
        }

        private void RefreshPasswordFields(Visibility visibility)
        {
            changePassBrdr.Visibility = visibility;
            newPasswordTxt.Password = "";
            repeatNewPasswordTxt.Password = "";
        }

        private void SetUp()
        {
            saveButton.Visibility = Visibility.Hidden;
            savePassButton.Visibility = Visibility.Hidden;
            cancelButton.Visibility = Visibility.Hidden;
            cancelChangePassButton.Visibility = Visibility.Hidden;
            if (_userType == UserType.DEFAULT)
            {
                changePassButton.Visibility = Visibility.Hidden;

            }
            else
            {
                changePassBrdr.Visibility = Visibility.Hidden;
            }    

            // Populating personal info text array to trigger editing mode
            userInfoControls[0] = firstNameTxt;
            userInfoControls[1] = lastNameTxt;
            userInfoControls[2] = dp1;
            userInfoControls[3] = genderCmb;
            userInfoControls[4] = emailTxt;
            userInfoControls[5] = homePhoneTxt;
            userInfoControls[6] = mobilePhoneTxt;
            userInfoControls[7] = streetTxt;
            userInfoControls[8] = suburbTxt;
            userInfoControls[9] = stateCmb;
            userInfoControls[10] = postcodeTxt;

            ClsUtils.SetActiveControls(userInfoControls, false);

            RefreshPasswordFields(Visibility.Hidden);


            // Set state combobox values
            stateCmb.ItemsSource = Enum.GetValues(typeof(AustralianStates)).Cast<AustralianStates>();

            try
            {
                //_userType = MainWindow.getInstance().UserType;
                if (_user is ClsTeacher)
                {
                    _user = new ClsTeacher(_id);
                }

                if (_user is ClsStudent)
                {
                    _user = new ClsStudent(_id);
                }

                //switch (_userType)
                //{
                //    case UserType.student:
                //        _user = new ClsStudent(_id);                       
                //        break;
                //    case UserType.teacher:
                //        _user = new ClsTeacher(_id);
                //        break;
                //    default:
                //        break;                       
                //}

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

        private void PopulateFieldsFromObject()
        {
            if (_user != null)
            {
                idTxt.Text = _user.ID;
                firstNameTxt.Text = _user.FName;
                lastNameTxt.Text = _user.LName;
                dp1.DisplayDate = _user.Dob;
                dp1.Text = _user.Dob.ToString();
                genderCmb.SelectedIndex = _user.Gender - 1;
                emailTxt.Text = _user.Email;
                homePhoneTxt.Text = _user.Hphone;
                mobilePhoneTxt.Text = _user.Mphone;
                streetTxt.Text = _user.Address.StreetAddress;
                suburbTxt.Text = _user.Address.Postcode;
                stateCmb.Text = _user.Address.State;
                postcodeTxt.Text = _user.Address.Postcode;
            }

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // need to fix, says navigation backlog is empty
            _mainFrame.NavigationService.GoBack();
        }
    }
}
