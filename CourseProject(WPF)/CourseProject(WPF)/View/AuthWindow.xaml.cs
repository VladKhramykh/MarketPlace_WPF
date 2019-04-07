using CourseProject_WPF_.ViewModel;
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

namespace CourseProject_WPF_.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        AuthWindowViewModel authWindowViewModel;
        public AuthWindow()
        {
            InitializeComponent();
            authWindowViewModel = new AuthWindowViewModel();
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
            if (!String.IsNullOrEmpty(passwordBox.Password) && !String.IsNullOrEmpty(mailTextBox.Text) && authWindowViewModel.compareDataOfUser(mailTextBox.Text, passwordBox.Password))
            {
                Hide();
                App.mainWindow.Show();
            }
            else
                infoLabel.Content = "Проверьте введённые данные!";
        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            App.registrationWindow.Show();
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
