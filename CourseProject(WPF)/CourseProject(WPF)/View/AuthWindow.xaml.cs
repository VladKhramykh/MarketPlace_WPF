using CourseProject_WPF_.Model;
using CourseProject_WPF_.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CourseProject_WPF_.View
{

    public partial class AuthWindow : Window
    {
        AuthWindowViewModel authWindowViewModel;
        public AuthWindow()
        {
            InitializeComponent();
            authWindowViewModel = new AuthWindowViewModel();
            DataContext = authWindowViewModel;
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();            
        }

        private void GridBarTitle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void collapseClose_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void authButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (authWindowViewModel.compareDataOfUser(passwordBox.Password))
                Close();

            //for Design
            // ...

        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            
            //for Design
            //...

        }

        private void mailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(mailTextBox.Text))           
                mailTextBox.BorderBrush = Brushes.Red; 
            else           
                mailTextBox.BorderBrush = Brushes.LimeGreen;
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(passwordBox.Password))
                passwordBox.BorderBrush= Brushes.Red;
            else
                passwordBox.BorderBrush= Brushes.LimeGreen;           
        }
    }
}
