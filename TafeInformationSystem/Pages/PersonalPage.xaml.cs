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

namespace TafeInformationSystem.Pages
{
    /// <summary>
    /// Interaction logic for PersonalPage.xaml
    /// </summary>
    /// 

    public partial class PersonalPage : Page
    {

        #region Variables
        private Control[] userInfoControls = new Control[11];
        private Control[] passwordChangeCtrls = new Control[4];
        #endregion

        public PersonalPage()
        {
            InitializeComponent();
            SetUp();
        }

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


        }
   
    }
}
