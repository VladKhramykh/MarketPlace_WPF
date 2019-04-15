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
    /// <summary>
    /// Логика взаимодействия для AllAnnouncement.xaml
    /// </summary>
    public partial class AllAnnouncement : Page
    {

        EFUserRepository userRepository = new EFUserRepository();
        EFAnnouncementRepository announcementRepository = new EFAnnouncementRepository();

        IEnumerable<User> users = new ObservableCollection<User>();
        IEnumerable<Announcement> announcements = new ObservableCollection<Announcement>();

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
        }

        private void listItemButton_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(listView.SelectedItem.ToString());
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            users = userRepository.getUsers();
            tmpUser.Clear();
            foreach (User user in users)
                tmpUser.Add(user);

            announcements = announcementRepository.getAnnouncements();            
            users = userRepository.getUsers();
            tmpUser.Clear();
            tmpAnnouncement.Clear();

            foreach (Announcement announcement in announcements)
                tmpAnnouncement.Add(announcement);
        }
    }
}
