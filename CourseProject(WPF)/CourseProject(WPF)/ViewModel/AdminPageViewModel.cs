using CourseProject_WPF_.Repositories;
using CourseProject_WPF_.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using CourseProject_WPF_.View;

namespace CourseProject_WPF_.ViewModel
{
    public class AdminPageViewModel : INotifyPropertyChanged
    {
        EFUserRepository eFUser = new EFUserRepository();
        EFAnnouncementRepository eFAnnouncement = new EFAnnouncementRepository();
        EFTmpAnnouncementRepository eFTmpAnnouncement = new EFTmpAnnouncementRepository();

        ObservableCollection<User> tmpUsers = new ObservableCollection<User>(); 
        ObservableCollection<Announcement> tmpAnnouncements = new ObservableCollection<Announcement>(); 
        ObservableCollection<TmpAnnouncement> tmpTmpAnnouncements = new ObservableCollection<TmpAnnouncement>();

        object selectedItem;

        public object SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (value != null)
                    selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public ObservableCollection<User> Users
        {
            get { return tmpUsers; }
        }
        public ObservableCollection<Announcement> Announcements
        {
            get { return tmpAnnouncements; }
        }
        public ObservableCollection<TmpAnnouncement> TmpAnnouncements
        {
            get { return tmpTmpAnnouncements; }
        }

        public AdminPageViewModel()
        {
            update();
        }

        public void update()
        {
            tmpUsers.Clear();
            tmpAnnouncements.Clear();
            tmpTmpAnnouncements.Clear();

            foreach (User user in eFUser.getAll())
            {
                if(user.id != CurrentUser.User.id)
                    tmpUsers.Add(user);
            }
                
            foreach (Announcement announcement in eFAnnouncement.getAll())
                tmpAnnouncements.Add(announcement);
            foreach (TmpAnnouncement announcement in eFTmpAnnouncement.getAll())
                tmpTmpAnnouncements.Add(announcement);
        }

        public void transferToAnnouncemet(TmpAnnouncement tmp)
        {
            if (tmp is TmpAnnouncement && tmp != null)
            {
                Announcement announcement = new Announcement();
                announcement.name = tmp.name;
                announcement.seller = tmp.seller;
                announcement.category = tmp.category;
                announcement.about = tmp.about;
                announcement.cost = tmp.cost;
                eFAnnouncement.add(announcement);
                eFTmpAnnouncement.delete(tmp);

                update();
            }
        }

        public void accept()
        {
            if (SelectedItem is User)
            {
                if (!eFUser.changePrivelege((SelectedItem as User), "admin"))
                   eFUser.changePrivelege((SelectedItem as User), "user");

                AlertWindow alertWindow = new AlertWindow($"Пользователь {(SelectedItem as User).firstName} {(SelectedItem as User).secondName} теперь {(SelectedItem as User).privilege}");
                alertWindow.ShowDialog();
            }                     
            else if (SelectedItem is TmpAnnouncement)
                transferToAnnouncemet(SelectedItem as TmpAnnouncement);
            else
            {
                AlertWindow alertWindow = new AlertWindow($"Ошибочка какая-то");
                alertWindow.ShowDialog();
            }            

            update();
        }

        void deleteUser(User user)
        {
            foreach (TmpAnnouncement announcement in eFTmpAnnouncement.getBySellerId(user.id))
                eFTmpAnnouncement.delete(announcement);
            foreach (Announcement announcement in eFAnnouncement.getBySellerId(user.id))
                eFAnnouncement.delete(announcement);

            eFUser.delete(user);
        }

        public void delete()
        {
            if (SelectedItem is User)
                deleteUser(SelectedItem as User);                

            if (SelectedItem is Announcement)           
                eFAnnouncement.delete(SelectedItem as Announcement);

            if (SelectedItem is TmpAnnouncement)           
                eFTmpAnnouncement.delete(SelectedItem as TmpAnnouncement);
           
            update();

        }


        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
