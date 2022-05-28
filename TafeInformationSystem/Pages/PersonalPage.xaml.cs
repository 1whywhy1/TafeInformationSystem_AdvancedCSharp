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
        private UserType _userType;
        private Control[] userInfoControls = new Control[11];
        private Control[] passwordChangeCtrls = new Control[4];
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
            MessageBox.Show(_id);
            SetUp();
        }

        #endregion

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            TafeInformationSystem.Classes.ClsUtils.SetActiveControls(userInfoControls, true);

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            TafeInformationSystem.Classes.ClsUtils.SetActiveControls(userInfoControls, false);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

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
        }

        private void RefreshPasswordFields( Visibility visibility)
        {
            changePassBrdr.Visibility = visibility;
            newPasswordTxt.Password = "";
            repeatNewPasswordTxt.Password = "";
        }

        private void SetUp()
        {
            savePassButton.Visibility = Visibility.Hidden;
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

            // Set state combobox values
            stateCmb.ItemsSource = Enum.GetValues(typeof(AustralianStates)).Cast<AustralianStates>();

            try
            {
                _userType = MainWindow.getInstance().UserType;
                switch (_userType)
                {
                    case UserType.student:
                        _user = new ClsStudent(_id);                       
                        break;
                    case UserType.teacher:
                        _user = new ClsTeacher(_id);
                        break;
                    default:
                        break;                       
                }

                idTxt.Text = _user.ID;
                firstNameTxt.Text = _user.FName;
                lastNameTxt.Text = _user.LName;
                dp1.DisplayDate = _user.Dob;
                dp1.Text = _user.Dob.ToString();
                genderCmb.SelectedIndex = _user.Gender;
                emailTxt.Text = _user.Email;
                homePhoneTxt.Text = _user.Hphone;
                mobilePhoneTxt.Text = _user.Mphone;
                streetTxt.Text = _user.Address.StreetAddress;
                suburbTxt.Text = _user.Address.Postcode;
                //stateCmb.Text = _user.Address.;
                postcodeTxt.Text = _user.Address.Postcode;
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
}
