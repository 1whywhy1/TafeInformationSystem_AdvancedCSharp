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
    /// Interaction logic for CoursesPage.xaml
    /// </summary>
    public partial class CoursesPage : Page
    {
        private Frame _mainFrame;
        Control[] txtBoxes = new Control[2];

        #region Constructors
        public CoursesPage()
        {
            InitializeComponent();
        }

        public CoursesPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

        public CoursesPage(Frame mainFrame, TafeInformationSystem.Enums.EntityPageType entityPageType)
        {
            InitializeComponent();
            _mainFrame = mainFrame;

            SetUp(entityPageType);
          
        }


        // MAke this alike Units Page with SetUp maybe and assign the right values to the boxes

        public CoursesPage(Frame mainFrame, TafeInformationSystem.Enums.EntityPageType entityPageType, DataRowView courseRow)
        {

            InitializeComponent();
            _mainFrame = mainFrame;

            SetUp(entityPageType);

            ClsUtils.SetActiveControls(txtBoxes, false);

            idText.Text = courseRow.Row[0].ToString();
            courseNameText.Text = courseRow.Row[1].ToString();
            descriptionText.Text = courseRow.Row[2].ToString();

        }

        #endregion

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClsCourse course = new ClsCourse(courseNameText.Text, descriptionText.Text);
                course.Add();
                idText.Text = course.CourseID;
                MessageBox.Show("Course added!");
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
                ClsCourse course = new ClsCourse(idText.Text, courseNameText.Text, descriptionText.Text);
                course.Update();
                MessageBox.Show("Course updated!");

                newButton.Visibility = Visibility.Hidden;
                editButton.Visibility = Visibility.Visible;
                updateButton.Visibility = Visibility.Hidden;
                deleteButton.Visibility = Visibility.Hidden;

                ClsUtils.SetActiveControls(txtBoxes, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            courseNameText.Clear();
            idText.Clear();
            descriptionText.Clear();

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ClsCourse course = new ClsCourse(idText.Text, Enums.SearchCriteria.CourseSearchBy.ID);
            try
            {
                if (course.Delete() > 0)
                {
                    MessageBox.Show($"Course with ID {idText.Text} is deleted!");
                    ClearButton_Click(sender, e); 
                }
                else
                {
                    MessageBox.Show("Course not found");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.GoBack();
        }

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
            txtBoxes[0] = courseNameText;            
            txtBoxes[1] = descriptionText;
        }

  
    }
}
