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
    public partial class MyAnnouncementPage : Page
    {
        User User = CurrentUser.User;

        MarketPlaceEntities entities = new MarketPlaceEntities();
        EFUserRepository userRepository = new EFUserRepository();
        EFAnnouncementRepository announcementRepository = new EFAnnouncementRepository();    
        
        ObservableCollection<Announcement> tmpAnnouncement = new ObservableCollection<Announcement>();        
        
        public ObservableCollection<Announcement> Announcements
        {
            get { return tmpAnnouncement; }
        }

        public MyAnnouncementPage()
        {            
            InitializeComponent();
            DataContext = this;
            listView.DataContext = this;

            var announcements = entities.Announcements.ToList();
            tmpAnnouncement.Clear();
            foreach (Announcement a in announcements)
                tmpAnnouncement.Add(a);
        }    

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            var announcements = entities.Announcements.ToList();
            tmpAnnouncement.Clear();
            foreach (Announcement a in announcements)
                tmpAnnouncement.Add(a);           
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {

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
