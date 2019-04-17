using CourseProject_WPF_.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CourseProject_WPF_.View
{
    public partial class MainWindow : Window
    {
        User User = CurrentUser.User;

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
            this.MaxHeight = SystemParameters.WorkArea.Height+10;

            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else
                WindowState = WindowState.Maximized;
        }

        private void minScreenButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }        

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
        }       

        private void personalAreaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainContent.Width = GridPage.Width;
            MainContent.Height = GridPage.Height;
            MainContent.MaxWidth = GridPage.MaxWidth;
            MainContent.MaxHeight = GridPage.MaxHeight;

            if (personalAreaComboBox.SelectedIndex == 0)
                MainContent.Content = new AllAnnouncement();
            if (personalAreaComboBox.SelectedIndex == 1)
                MainContent.Content = new PersonAreaPage();
            if (personalAreaComboBox.SelectedIndex == 2)
                MainContent.Content = new MyAnnouncementPage();
            if (personalAreaComboBox.SelectedIndex == 3)
                MainContent.Content = new PersonAreaPage();
        }
    }
    
}
