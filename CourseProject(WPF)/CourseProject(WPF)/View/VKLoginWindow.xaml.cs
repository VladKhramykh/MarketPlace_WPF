using CourseProject_WPF_.ViewModel;
using System.Windows;
using System.Windows.Input;

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

        private void authButton_Click(object sender, RoutedEventArgs e)
        {
            if (vkLoginViewModel.auth(password.Password))
                Close();                                  
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
