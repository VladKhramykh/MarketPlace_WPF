using CourseProject_WPF_.Repositories;
using CourseProject_WPF_.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CourseProject_WPF_.ViewModel
{
    public class AdminPageViewModel
    {
        EFUserRepository eFUser = new EFUserRepository();
        EFAnnouncementRepository eFAnnouncement = new EFAnnouncementRepository();
        EFTmpAnnouncementRepository eFTmpAnnouncement = new EFTmpAnnouncementRepository();

        ObservableCollection<User> tmpUsers = new ObservableCollection<User>(); 
        ObservableCollection<Announcement> tmpAnnouncements = new ObservableCollection<Announcement>(); 
        ObservableCollection<TmpAnnouncement> tmpTmpAnnouncements = new ObservableCollection<TmpAnnouncement>();

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

        public void accept(object obj)
        {
            if (obj is User)
                eFUser.changePrivelege((User)obj, "admin");         
            if (obj is TmpAnnouncement)
                transferToAnnouncemet((TmpAnnouncement)obj);
        }

        void deleteUser(User user)
        {
            foreach (TmpAnnouncement announcement in eFTmpAnnouncement.getBySellerId(user.id))
                eFTmpAnnouncement.delete(announcement);
            foreach (Announcement announcement in eFAnnouncement.getBySellerId(user.id))
                eFAnnouncement.delete(announcement);

            eFUser.delete(user);
        }

        public void delete(object obj)
        {
            if (obj is User)
                deleteUser((User)obj);
                //eFUser.changePrivelege((User)obj, "user");

            if (obj is Announcement)           
                eFAnnouncement.delete((Announcement)obj);

            if (obj is TmpAnnouncement)           
                eFTmpAnnouncement.delete((TmpAnnouncement)obj);
           
            update();

        }
    }
}
