using CourseProject_WPF_.DataBase;
using CourseProject_WPF_.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_WPF_.ViewModel
{
    public class AuthWindowViewModel
    {

        IEnumerable<User> users;        
        EFUserRepository eFUser = new EFUserRepository();

        IEnumerable<Announcement> announcements;
        EFAnnouncementRepository eFAnnouncement = new EFAnnouncementRepository();

        public AuthWindowViewModel()
        {
            users = eFUser.getUsers();
            announcements = eFAnnouncement.getAnnouncements();
        }

        public bool registration(string firstName, string secondName, string mail, string password1, string password2)
        {
            if ((firstName!=null && firstName != String.Empty) && (secondName!=null && secondName!=String.Empty) && (mail!=null && mail!=String.Empty) && (password1!=null && password1!=String.Empty) && (password1 != null && password1 != String.Empty))
            {
                if (password1.Equals(password2))
                {
                    eFUser.addUser(new User(firstName, secondName, mail, User.getHash(password1)));
                    return true;
                }
                else
                    return false;
            }
            return false;
        }

        public User compareDataOfUser(string mail, string password)
        {
            users = eFUser.getUsers();

            if (!String.IsNullOrEmpty(mail) && !String.IsNullOrEmpty(password))
            {
                User tmp = eFUser.getUserByMail(mail);                
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
            eFUser.changeUserData(oldUser, newUser);
        }
    }
}
