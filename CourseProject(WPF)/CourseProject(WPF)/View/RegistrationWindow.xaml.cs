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
                infoLabel.Foreground = Brushes.Red;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            
        }

        private void firstNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(firstNameTextBox.Text))
                firstNameTextBox.BorderBrush = Brushes.Red;
            else
                firstNameTextBox.BorderBrush = Brushes.LimeGreen;
        }

        private void secondNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(secondNameTextBox.Text))
                secondNameTextBox.BorderBrush = Brushes.Red;
            else
                secondNameTextBox.BorderBrush = Brushes.LimeGreen;
        }

        private void mailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(mailTextBox.Text))
                mailTextBox.BorderBrush = Brushes.Red;
            else
                mailTextBox.BorderBrush = Brushes.LimeGreen;
        }

        private void pass1NameTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

            if (pass2NameTextBox.Password.Equals(pass1NameTextBox.Password) &&
                !String.IsNullOrEmpty(pass1NameTextBox.Password) &&
                !String.IsNullOrEmpty(firstNameTextBox.Text) &&
                !String.IsNullOrEmpty(secondNameTextBox.Text) &&
                !String.IsNullOrEmpty(mailTextBox.Text))
            {
                pass1NameTextBox.BorderBrush = Brushes.LimeGreen;
                pass2NameTextBox.BorderBrush = Brushes.LimeGreen;
                registrationButton.IsEnabled = true;
            }
            else
            {
                pass1NameTextBox.BorderBrush = Brushes.Red;
                pass2NameTextBox.BorderBrush = Brushes.Red;
                registrationButton.IsEnabled = false;
            }
            
        }

        private void pass2NameTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

            if (pass2NameTextBox.Password.Equals(pass1NameTextBox.Password) &&
                !String.IsNullOrEmpty(pass1NameTextBox.Password) &&
                !String.IsNullOrEmpty(firstNameTextBox.Text) &&
                !String.IsNullOrEmpty(secondNameTextBox.Text) &&
                !String.IsNullOrEmpty(mailTextBox.Text))
            {
                pass1NameTextBox.BorderBrush = Brushes.LimeGreen;
                pass2NameTextBox.BorderBrush = Brushes.LimeGreen;
                registrationButton.IsEnabled = true;
            }
            else
            {
                pass1NameTextBox.BorderBrush = Brushes.Red;
                pass2NameTextBox.BorderBrush = Brushes.Red;
                registrationButton.IsEnabled = false;
            }
             
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
