using CourseProject_WPF_.ViewModel.Instagram;
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

namespace CourseProject_WPF_.View
{
    /// <summary>
    /// Логика взаимодействия для InstagramWindow.xaml
    /// </summary>
    public partial class InstagramWindow : Window
    {
        InstagramLoginViewModel instagramLoginViewModel = new InstagramLoginViewModel();
        public InstagramWindow()
        {
            InitializeComponent();
            DataContext = instagramLoginViewModel;
        }

        private void authButton_Click(object sender, RoutedEventArgs e)
        {
            instagramLoginViewModel.auth(password.Password);
                
        }
        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
