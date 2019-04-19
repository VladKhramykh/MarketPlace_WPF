using CourseProject_WPF_.DataBase;
using CourseProject_WPF_.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace CourseProject_WPF_.View
{
    public partial class MyAnnouncementPage : Page
    {
        User User = CurrentUser.User;         
        
        EFAnnouncementRepository announcementRepository = new EFAnnouncementRepository();        
        EFTmpAnnouncementRepository tmpAnnouncementRepository = new EFTmpAnnouncementRepository();        
        ObservableCollection<Announcement> tmpAnnouncement = new ObservableCollection<Announcement>();
        ObservableCollection<TmpAnnouncement> tmpTmpAnnouncement = new ObservableCollection<TmpAnnouncement>();

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
            var announcements = announcementRepository.getAnnouncementsBySellerId(User.id);

            tmpAnnouncement.Clear();
            foreach (Announcement a in announcements)
                tmpAnnouncement.Add(a);
        }    

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            var announcements = tmpAnnouncementRepository.getAnnouncementsBySellerId(User.id);
            tmpTmpAnnouncement.Clear();
            foreach (TmpAnnouncement a in announcements)
                tmpTmpAnnouncement.Add(a);
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            tmpAnnouncementRepository.addAnnouncement(new TmpAnnouncement("asda", User.id, "sasdasd", "askdfmasdf", 442));
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
    }
}
