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

        AnnouncementViewModel announcementViewModel = new AnnouncementViewModel();
                
        EFAnnouncementRepository announcementRepository = new EFAnnouncementRepository();
        
        ObservableCollection<Announcement> tmpAnnouncement = new ObservableCollection<Announcement>();        

       
        public ObservableCollection<Announcement> Announcements
        {
            get { return tmpAnnouncement; }            
        }

        public AllAnnouncement()
        {            
            InitializeComponent();
            DataContext = this;            

            var announcements = announcementViewModel.getAnnouncements().ToList();
            Announcements.Clear();
            foreach (Announcement a in announcements)
                tmpAnnouncement.Add(a);
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            var announcements = announcementViewModel.getAnnouncements();
            Announcements.Clear();
            foreach (Announcement a in announcements)
                tmpAnnouncement.Add(a);
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.Show();

            AlertWindow alert = new AlertWindow(listView.SelectedItem.ToString());
            alert.Show();
        }       
    }
}
