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
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            View.AuthWindow authWindow = new View.AuthWindow();
            View.MainWindow mainWindow = new View.MainWindow();
            //authWindow.Show();
            mainWindow.Show();
        }
    }
}
