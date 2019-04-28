using CourseProject_WPF_.DataBase;
using CourseProject_WPF_.Model;
using System.Collections.ObjectModel;
using CourseProject_WPF_.ViewModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CourseProject_WPF_.View
{
    public partial class AllAnnouncement : Page
    {
        User User = CurrentUser.User;
        AnnouncementViewModel viewModel;

        public AllAnnouncement()
        {            
            InitializeComponent();
            viewModel = new AnnouncementViewModel();
            DataContext = viewModel;
        }

        //private void updateButton_Click(object sender, RoutedEventArgs e)
        //{
            
        //}

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //AddWindow addWindow = new AddWindow();
            //addWindow.Show();
            //AlertWindow alert = new AlertWindow(listView.SelectedItem.ToString());
            //alert.Show();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.search();
        }
    }
}
