using CourseProject_WPF_.Repositories;
using CourseProject_WPF_.Model;
using CourseProject_WPF_.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace CourseProject_WPF_.View
{
    public partial class MyAnnouncementPage : Page
    {
        MyAnnouncementPageViewModel myAnnouncementPageViewModel = new MyAnnouncementPageViewModel();

        public MyAnnouncementPage()
        {
            InitializeComponent();
            DataContext = myAnnouncementPageViewModel;
            radio1.IsChecked = true;
        }    

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            myAnnouncementPageViewModel.addAnnouncement();
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            myAnnouncementPageViewModel.deleteAnnouncement();
        }
        public void infoButton_Click(object sender, RoutedEventArgs e)
        {
            myAnnouncementPageViewModel.showInfo();
        }
        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            myAnnouncementPageViewModel.editAnnouncement();
        }
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            myAnnouncementPageViewModel.update();
        }

        private void radio1_Checked(object sender, RoutedEventArgs e)
        {
            listView.ItemsSource = myAnnouncementPageViewModel.Announcements;
        }

        private void radio2_Checked(object sender, RoutedEventArgs e)
        {
            listView.ItemsSource = myAnnouncementPageViewModel.TmpAnnouncements;
        }
    }
}
