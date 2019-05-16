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
using System.Windows.Shapes;

namespace CourseProject_WPF_.View
{
    /// <summary>
    /// Логика взаимодействия для VKLoginWindow.xaml
    /// </summary>
    public partial class VKLoginWindow : Window
    {
        VkLoginViewModel vkLoginViewModel = new VkLoginViewModel();

        public VKLoginWindow()
        {
            InitializeComponent();
            DataContext = vkLoginViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (vkLoginViewModel.auth(password.Password))
                Close();
                                  
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
