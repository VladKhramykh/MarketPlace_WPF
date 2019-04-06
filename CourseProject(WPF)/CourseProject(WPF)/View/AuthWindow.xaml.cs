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
        public AuthWindow()
        {
            InitializeComponent();
            DataContext = new AuthWindowViewModel();
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
            
        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {

        }

       
    }
}
