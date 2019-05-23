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

namespace CourseProject_WPF_.View
{
    /// <summary>
    /// Логика взаимодействия для QuickViewWindow.xaml
    /// </summary>
    public partial class QuickViewWindow : Window
    {
        QuickWindowViewModel quickWindowViewModel;

        public QuickViewWindow(object item)
        {
            InitializeComponent();
            quickWindowViewModel = new QuickWindowViewModel(item);
            DataContext = quickWindowViewModel;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();            
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
