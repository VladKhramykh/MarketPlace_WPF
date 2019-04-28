using CourseProject_WPF_.DataBase;
using CourseProject_WPF_.Model;
using CourseProject_WPF_.ViewModel;
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
    
    public partial class AdminPage : Page
    {
        User User = CurrentUser.User;

        UserViewModel userViewModel = new UserViewModel();
        TmpAnnouncementViewModel tmpAnnouncementViewModel = new TmpAnnouncementViewModel();
        AnnouncementViewModel announcementViewModel = new AnnouncementViewModel();

        ObservableCollection<TmpAnnouncement> tmpTmpAnnouncements = new ObservableCollection<TmpAnnouncement>();
        ObservableCollection<Announcement> tmpAnnouncements = new ObservableCollection<Announcement>();
        ObservableCollection<User> tmpUsers = new ObservableCollection<User>();

        public ObservableCollection<TmpAnnouncement> TmpAnnouncements
        {
            get { return tmpTmpAnnouncements; }
        }

        public ObservableCollection<Announcement> Announcements
        {
            get { return tmpAnnouncements; }
        }

        public ObservableCollection<User> Users
        {
            get { return tmpUsers; }
        }

        public AdminPage()
        {
            InitializeComponent();
            DataContext = this;

            var tmpannouncements = tmpAnnouncementViewModel.getAnnouncements();
            tmpTmpAnnouncements.Clear();
            foreach (TmpAnnouncement a in tmpannouncements)
                tmpTmpAnnouncements.Add(a);

            var announcements = userViewModel.getAnnouncements();
            tmpAnnouncements.Clear();
            foreach (Announcement a in announcements)
                tmpAnnouncements.Add(a);

            var users = userViewModel.getUsers();
            tmpUsers.Clear();
            foreach (User a in users)
                tmpUsers.Add(a);

            radio1.IsChecked = true;

        }

        
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null && tmpAnnouncementViewModel.transferToAnnouncemet((TmpAnnouncement)listBox.SelectedItem))
            {
                Announcements.Add((Announcement)listBox.SelectedItem);
                TmpAnnouncements.Remove((TmpAnnouncement)listBox.SelectedItem);               
            }                
            else
            {
                AlertWindow alert = new AlertWindow("Ошибочка :)");
                alert.Show();
            }
            
        }

        private void NOButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem == null)
            {
                AlertWindow alert = new AlertWindow("Ошибочка :)");
                alert.Show();
            }                
            else
            {
                if(listBox.SelectedItem is User)
                {
                    userViewModel.deleteUser((User)listBox.SelectedItem);
                    Users.Remove((User)listBox.SelectedItem);
                    
                }
                else if(listBox.SelectedItem is Announcement)
                {
                    Announcements.Remove((Announcement)listBox.SelectedItem);
                    announcementViewModel.deleteAnnouncement((Announcement)listBox.SelectedItem);
                    
                }
                else if (listBox.SelectedItem is TmpAnnouncement)
                {
                    tmpAnnouncementViewModel.deleteAnnouncement((TmpAnnouncement)listBox.SelectedItem);
                    TmpAnnouncements.Remove((TmpAnnouncement)listBox.SelectedItem);                    
                }
                else
                {
                    AlertWindow alert = new AlertWindow("Ошибочка :)");
                    alert.Show();
                }
            }
                          
        }      

        private void radio1_Checked(object sender, RoutedEventArgs e)
        {
            listBox.ItemsSource = Users;
            OkButton.IsEnabled = false;
        }

        private void radio2_Checked(object sender, RoutedEventArgs e)
        {
            listBox.ItemsSource = Announcements;
            OkButton.IsEnabled = false;
        }

        private void radio3_Checked(object sender, RoutedEventArgs e)
        {
            listBox.ItemsSource = TmpAnnouncements;
            OkButton.IsEnabled = true;
            
        }

    }
}
