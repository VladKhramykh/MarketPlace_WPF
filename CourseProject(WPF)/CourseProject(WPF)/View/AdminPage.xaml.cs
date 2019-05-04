using CourseProject_WPF_.Repositories;
using CourseProject_WPF_.Model;
using CourseProject_WPF_.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    
    public partial class AdminPage : Page
    {
        User User = CurrentUser.User;

        AdminPageViewModel adminPageViewModel = new AdminPageViewModel();
        
        public AdminPage()
        {
            InitializeComponent();
            DataContext = adminPageViewModel;
            radio1.IsChecked = true;

        }

        
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            adminPageViewModel.accept(listBox.SelectedItem);            
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null)            
                adminPageViewModel.delete(listBox.SelectedItem);
            else
            {
                AlertWindow alert = new AlertWindow("Выберите пользователя :)");
                alert.Show();
            }
                          
        }      

        private void radio1_Checked(object sender, RoutedEventArgs e)
        {
            listBox.ItemsSource = adminPageViewModel.Users;
            NoButton.Content = "Удалить";
            OkButton.Content = "Сделать админом";
            OkButton.IsEnabled = true;
        }

        private void radio2_Checked(object sender, RoutedEventArgs e)
        {
            listBox.ItemsSource = adminPageViewModel.Announcements;
            OkButton.Content = "Принять";
            OkButton.IsEnabled = false;
        }

        private void radio3_Checked(object sender, RoutedEventArgs e)
        {
            listBox.ItemsSource = adminPageViewModel.TmpAnnouncements;
            OkButton.Content = "Принять";
            OkButton.IsEnabled = true;
            
        }

    }
}
