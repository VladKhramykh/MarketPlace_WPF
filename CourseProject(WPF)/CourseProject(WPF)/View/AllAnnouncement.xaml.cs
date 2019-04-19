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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseProject_WPF_.View
{  
    public partial class AllAnnouncement : Page
    {
        User User = CurrentUser.User;

        EFUserRepository userRepository = new EFUserRepository();
        EFAnnouncementRepository announcementRepository = new EFAnnouncementRepository();

        ObservableCollection<User> tmpUser = new ObservableCollection<User>();
        ObservableCollection<Announcement> tmpAnnouncement = new ObservableCollection<Announcement>();        

        public ObservableCollection<User> Users
        {
            get { return tmpUser; }
        }
        public ObservableCollection<Announcement> Announcements
        {
            get { return tmpAnnouncement; }
        }

        public AllAnnouncement()
        {            
            InitializeComponent();
            DataContext = this;
            listView.DataContext = this;

            var announcements = announcementRepository.getAnnouncements().ToList();
            tmpAnnouncement.Clear();
            foreach (Announcement a in announcements)
                tmpAnnouncement.Add(a);
        }

        private void listItemButton_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(listView.SelectedItem.ToString());
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            var announcements = announcementRepository.getAnnouncements().ToList();
            tmpAnnouncement.Clear();
            foreach (Announcement a in announcements)
                tmpAnnouncement.Add(a);           

        }
    }
}
