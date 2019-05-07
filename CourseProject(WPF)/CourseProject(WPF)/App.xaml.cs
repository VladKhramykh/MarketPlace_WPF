using CourseProject_WPF_.View;
using System.Windows;

namespace CourseProject_WPF_
{
    public partial class App : Application
    {
        public static AuthWindow authWindow;          
        public static MainWindow mainWindow;          

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            authWindow = new AuthWindow();            
            authWindow.Show();
        }
    }
}
