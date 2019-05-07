using CourseProject_WPF_.Repositories;
using CourseProject_WPF_.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using CourseProject_WPF_.View;

namespace CourseProject_WPF_.ViewModel
{
    public class PersonAreaViewModel:INotifyPropertyChanged
    {
        User user = CurrentUser.User;
        EFUserRepository userRepository = new EFUserRepository();
        EFAnnouncementRepository announcementRepository = new EFAnnouncementRepository();
        EFTmpAnnouncementRepository tmpAnnouncementRepository = new EFTmpAnnouncementRepository();

        string firstName;
        string secondName;
        string mail;
        string telNumber;
        string about;

        public PersonAreaViewModel()
        {
            firstName = user.firstName;
            secondName = user.secondName;
            mail = user.mail;
            telNumber = user.telNumber;
            about = user.about;
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string SecondName
        {
            get { return secondName; }
            set { secondName = value; }
        }

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
        public string TelNumber
        {
            get { return telNumber; }
            set { telNumber = value; }
        }
        public string About
        {
            get { return about; }
            set { about = value; }
        }

        public void changeDataOfUser()
        {
            User tmp = new User(FirstName, SecondName, Mail, TelNumber, About, user.privilege);
            userRepository.update(user, tmp);
            CurrentUser.User = userRepository.getByMail(Mail);            
        }

        public void deleteUser()
        {
            foreach (TmpAnnouncement announcement in tmpAnnouncementRepository.getBySellerId(user.id))
                tmpAnnouncementRepository.delete(announcement);
            foreach (Announcement announcement in announcementRepository.getBySellerId(user.id))
                announcementRepository.delete(announcement);

            App.mainWindow.Close();
            userRepository.delete(CurrentUser.User);
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
