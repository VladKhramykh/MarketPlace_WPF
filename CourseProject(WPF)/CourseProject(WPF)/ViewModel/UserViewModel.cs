using CourseProject_WPF_.Repositories;
using CourseProject_WPF_.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CourseProject_WPF_.ViewModel
{
    public class UserViewModel 
    {

        EFUserRepository eFUser = new EFUserRepository();        
        EFAnnouncementRepository eFAnnouncement = new EFAnnouncementRepository();
        EFTmpAnnouncementRepository eFTmpAnnouncement = new EFTmpAnnouncementRepository();        

        ObservableCollection<User> tmpUser = new ObservableCollection<User>();
        
        ObservableCollection<User> Users
        {
            get { return tmpUser; }
        }      

        public UserViewModel()
        {
            foreach (User user in eFUser.getAll())           
                tmpUser.Add(user);
        }

        public bool registration(string firstName, string secondName, string mail, string password1, string password2)
        {
            if ((firstName!=null && firstName != String.Empty) && (secondName!=null && secondName!=String.Empty) && (mail!=null && mail!=String.Empty) && (password1!=null && password1!=String.Empty) && (password1 != null && password1 != String.Empty))
            {
                if (password1.Equals(password2))
                {
                    eFUser.add(new User(firstName, secondName, mail, User.getHash(password1)));
                    return true;
                }
                else
                    return false;
            }
            return false;
        }

        public User compareDataOfUser(string mail, string password)
        {
            if (!String.IsNullOrEmpty(mail) && !String.IsNullOrEmpty(password))
            {
                User tmp = eFUser.getByMail(mail);                
                if (tmp != null)
                {
                    if (User.getHash(password).Equals(tmp.password))
                        return tmp;
                }
                else
                    return null;
            }
            return null;
        }

        public void changeDataOfUser(User oldUser, User newUser)
        {
            eFUser.update(oldUser, newUser);
        }

        public IEnumerable<User> getUsers()
        {
            return eFUser.getAll();
        }

        public IEnumerable<Announcement> getAnnouncements()
        {
            return eFAnnouncement.getAll();
        }

        public IEnumerable<TmpAnnouncement> getTmpAnnouncements()
        {
            return eFTmpAnnouncement.getAll();
        }

        public void deleteUser(User user)
        {
            if(user != null)
            {
                foreach (TmpAnnouncement announcement in eFTmpAnnouncement.getBySellerId(user.id))
                    eFTmpAnnouncement.delete(announcement);
                foreach (Announcement announcement in eFAnnouncement.getBySellerId(user.id))
                    eFAnnouncement.delete(announcement);

                eFUser.delete(user);
            }
                        
        }

        public void addUser(User user)
        {
            eFUser.add(user);
        }
    }
}
