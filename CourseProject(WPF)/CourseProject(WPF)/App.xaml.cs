using CourseProject_WPF_.View;
using System.Windows;

namespace CourseProject_WPF_
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static AuthWindow authWindow;          

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            authWindow = new View.AuthWindow();            
            authWindow.Show();
        }
    }
}
