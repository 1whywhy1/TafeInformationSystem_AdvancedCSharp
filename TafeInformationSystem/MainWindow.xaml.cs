﻿using System;
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
using System.Windows.Shapes;
using TafeInformationSystem.Pages;

namespace TafeInformationSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new LoginWindow());
        }

        private void PersonalPageButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new PersonalPage());
        }

        private void TeachersButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new TeacherMenuPage());
        }

        private void CoursesButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new CourseMenuPage(_mainFrame));
        }

        private void StudentsButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new StudentMenuPage());
        }

        private void UnitsButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new UnitsMenuPage());
        }

        private void EnrollmentsButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new EnrollmentMenuPage());
        }
    }
}
