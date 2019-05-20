using CourseProject_WPF_.Repositories;
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
using System.Windows.Shapes;
using CourseProject_WPF_.ViewModel;
using CourseProject_WPF_.Model;

namespace CourseProject_WPF_.View
{
    public partial class RegistrationWindow : Window
    {
        
        RegistrationViewModel registrationViewModel = new RegistrationViewModel();        
        
        public RegistrationWindow()
        {
            InitializeComponent();           
            DataContext = registrationViewModel;
            Title = "Регистрация";
        }

        private void collapseClose_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void registrationButton_Click(object sender, RoutedEventArgs e)
        {
            if (registrationViewModel.registration(User.getHash(pass1NameTextBox.Password),User.getHash(pass2NameTextBox.Password)))
                infoLabel.Foreground = Brushes.LimeGreen;
            else           
                infoLabel.Foreground = Brushes.DarkRed;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            
        }

        private void firstNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(firstNameTextBox.Text))
                firstNameTextBox.BorderBrush = Brushes.LimeGreen;
            else
                firstNameTextBox.BorderBrush = Brushes.DarkRed;

            compare();
        }

        private void secondNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(secondNameTextBox.Text))
                secondNameTextBox.BorderBrush = Brushes.LimeGreen;
            else
                secondNameTextBox.BorderBrush = Brushes.DarkRed;
            compare();
        }

        private void mailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(mailTextBox.Text))
                mailTextBox.BorderBrush = Brushes.LimeGreen;
            else
                mailTextBox.BorderBrush = Brushes.DarkRed;
            compare();
        }

        private void pass1NameTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

            if (pass2NameTextBox.Password.Equals(pass1NameTextBox.Password))
            {
                pass1NameTextBox.BorderBrush = Brushes.LimeGreen;
                pass2NameTextBox.BorderBrush = Brushes.LimeGreen;                
            }
            else
            {
                pass1NameTextBox.BorderBrush = Brushes.DarkRed;
                pass2NameTextBox.BorderBrush = Brushes.DarkRed;                
            }

            compare();
            
        }

        private void pass2NameTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

            if (pass2NameTextBox.Password.Equals(pass1NameTextBox.Password))
            {
                pass1NameTextBox.BorderBrush = Brushes.LimeGreen;
                pass2NameTextBox.BorderBrush = Brushes.LimeGreen;               
            }
            else
            {
                pass1NameTextBox.BorderBrush = Brushes.DarkRed;
                pass2NameTextBox.BorderBrush = Brushes.DarkRed;                
            }

            compare();
             
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        void compare()
        {
            if (pass2NameTextBox.Password.Equals(pass1NameTextBox.Password) &&
                !String.IsNullOrEmpty(pass1NameTextBox.Password) &&
                !String.IsNullOrEmpty(firstNameTextBox.Text) &&
                !String.IsNullOrEmpty(secondNameTextBox.Text) &&
                !String.IsNullOrEmpty(mailTextBox.Text))
            {               
                registrationButton.IsEnabled = true;
            }
            else
            {                
                registrationButton.IsEnabled = false;
            }
        }
    }
}
