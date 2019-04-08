using CourseProject_WPF_.DataBase;
using CourseProject_WPF_.Model;
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
using System.Windows.Shapes;

namespace CourseProject_WPF_.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EFUserRepository eF = new EFUserRepository();

        IEnumerable<User> users = new ObservableCollection<User>();
        ObservableCollection<User> tmp = new ObservableCollection<User>();

        public ObservableCollection<User> Users
        {
            get { return tmp; }
        }
     

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            personalAreaComboBox.Items.Add("Все объявления");
            personalAreaComboBox.Items.Add("Мой кабинет");
            personalAreaComboBox.Items.Add("Мои объявления");
            personalAreaComboBox.Items.Add("Админ");
            personalAreaComboBox.SelectedIndex = 0;

            
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GridBarTitle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void fullScreenButton_Click(object sender, RoutedEventArgs e)
        {
            this.MaxHeight = SystemParameters.WorkArea.Height+20;

            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else
                WindowState = WindowState.Maximized;
        }

        private void minScreenButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            
            users = eF.getUsers();
            tmp.Clear();
            foreach (User user in users)
                tmp.Add(user);
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            App.authWindow.Show();
        }
    }
    
}
