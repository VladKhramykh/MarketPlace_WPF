using CourseProject_WPF_.DataBase;
using CourseProject_WPF_.Model;
using CourseProject_WPF_.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace CourseProject_WPF_.View
{
    public partial class MyAnnouncementPage : Page
    {
        User User = CurrentUser.User;

        TmpAnnouncementViewModel tmpAnnouncementViewModel = new TmpAnnouncementViewModel();
        AnnouncementViewModel announcementViewModel = new AnnouncementViewModel();

        ObservableCollection<TmpAnnouncement> tmpTmpAnnouncement = new ObservableCollection<TmpAnnouncement>();
        ObservableCollection<Announcement> tmpAnnouncement = new ObservableCollection<Announcement>();

        public ObservableCollection<TmpAnnouncement> TmpAnnouncements
        {
            get { return tmpTmpAnnouncement; }
        }

        public ObservableCollection<Announcement> Announcements
        {
            get { return tmpAnnouncement; }
        }

        public MyAnnouncementPage()
        {
            InitializeComponent();
            DataContext = this;
            
            foreach (TmpAnnouncement a in tmpAnnouncementViewModel.getAnnouncementsBySellerId(User.id))
                TmpAnnouncements.Add(a);

            foreach (Announcement a in announcementViewModel.getAnnouncementsBySellerId(User.id))           
                Announcements.Add(a);            

            radio1.IsChecked = true;
        }    

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            var tmpAnnouncements = tmpAnnouncementViewModel.getAnnouncementsBySellerId(User.id);
            var announcements = announcementViewModel.getAnnouncementsBySellerId(User.id);
            TmpAnnouncements.Clear();
            Announcements.Clear();
            foreach (TmpAnnouncement a in tmpAnnouncements)
                TmpAnnouncements.Add(a);
            foreach (Announcement a in announcements)
                Announcements.Add(a);            
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.Show();
        }

        private void viewItemButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteItemButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void changeItemButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void radio1_Checked(object sender, RoutedEventArgs e)
        {
            listView.ItemsSource = Announcements;
        }

        private void radio2_Checked(object sender, RoutedEventArgs e)
        {
            listView.ItemsSource = TmpAnnouncements;
        }
    }
}
