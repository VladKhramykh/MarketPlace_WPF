using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CourseProject_WPF_
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static View.AuthWindow authWindow;
        public static View.MainWindow mainWindow;
        public static View.RegistrationWindow registrationWindow;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            authWindow = new View.AuthWindow();
            mainWindow = new View.MainWindow();
            registrationWindow = new View.RegistrationWindow();

            //authWindow.Show();
            mainWindow.Show();
            //registrationWindow.Show();
        }
    }
}
