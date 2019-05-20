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
        EFUserRepository userRepository = new EFUserRepository();
        EFAnnouncementRepository announcementRepository = new EFAnnouncementRepository();
        EFTmpAnnouncementRepository tmpAnnouncementRepository = new EFTmpAnnouncementRepository();

        ObservableCollection<User> tmpUsers = new ObservableCollection<User>(); 
        ObservableCollection<Announcement> tmpAnnouncements = new ObservableCollection<Announcement>(); 
        ObservableCollection<TmpAnnouncement> tmpTmpAnnouncements = new ObservableCollection<TmpAnnouncement>();
        ObservableCollection<object> tmp = new ObservableCollection<object>();

        object selectedItem;
        string message;

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

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }

        public ObservableCollection<User> Users
        {
            get
            {
                selectedItem = null;
                return tmpUsers;
            }
        }
        public ObservableCollection<Announcement> Announcements
        {
            get
            {
                selectedItem = null;
                return tmpAnnouncements;
            }
        }
        public ObservableCollection<TmpAnnouncement> TmpAnnouncements
        {
            get
            {
                selectedItem = null;
                return tmpTmpAnnouncements;
            }
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

            foreach (User user in userRepository.getAll())
            {
                if(user.id != CurrentUser.User.id)
                    tmpUsers.Add(user);
            }
                
            foreach (Announcement announcement in announcementRepository.getAll())
                tmpAnnouncements.Add(announcement);
            foreach (TmpAnnouncement announcement in tmpAnnouncementRepository.getAll())
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
                announcement.idRegion = tmp.idRegion;
                announcement.about = tmp.about;
                announcement.cost = tmp.cost;
                announcementRepository.add(announcement);
                tmpAnnouncementRepository.delete(tmp);

                update();
            }
        }

        public void accept()
        {
            if (SelectedItem is User)
            {
                if (CurrentUser.isAdmin())
                {
                    if ((SelectedItem as User).privilege.Equals("admin"))
                       userRepository.changePrivelege((SelectedItem as User), "user");
                    else if ((SelectedItem as User).privilege.Equals("user"))
                        userRepository.changePrivelege((SelectedItem as User), "moderator");
                    else if ((SelectedItem as User).privilege.Equals("moderator"))
                        userRepository.changePrivelege((SelectedItem as User), "admin");

                    AlertWindow alertWindow = new AlertWindow($"Пользователь {(SelectedItem as User).firstName} {(SelectedItem as User).secondName} теперь {(SelectedItem as User).privilege}");
                    alertWindow.ShowDialog();
                }
                else
                {
                    AlertWindow alertWindow = new AlertWindow("У вас недостаточно прав для совершения данного действия");
                    alertWindow.ShowDialog();
                }
                
            }                     
            else if (SelectedItem is TmpAnnouncement)
                transferToAnnouncemet(SelectedItem as TmpAnnouncement);
            else
            {
                AlertWindow alertWindow = new AlertWindow($"Выберите объект");
                alertWindow.ShowDialog();
            }            

            update();
        }

        void deleteUser(User user)
        {
            foreach (TmpAnnouncement announcement in tmpAnnouncementRepository.getBySellerId(user.id))
                tmpAnnouncementRepository.delete(announcement);
            foreach (Announcement announcement in announcementRepository.getBySellerId(user.id))
                announcementRepository.delete(announcement);

            userRepository.delete(user);
        }

        public void delete()
        {
            if (SelectedItem is User)
            {
                if (CurrentUser.isAdmin())
                {
                    DialogWindow dialogWindow = new DialogWindow();
                    dialogWindow.DataContext = this;
                    Message = $"Уверены, что хотите удалить пользователя {(SelectedItem as User).firstName} {(SelectedItem as User).secondName}?";
                    dialogWindow.ShowDialog();
                    if (dialogWindow.DialogResult == true)
                        deleteUser(SelectedItem as User);
                }
                else
                {
                    AlertWindow alertWindow = new AlertWindow("У вас недостаточно прав для совершения данного действия");
                    alertWindow.ShowDialog();
                }
                
            }

            else if (SelectedItem is Announcement)
            {
                DialogWindow dialogWindow = new DialogWindow();
                dialogWindow.DataContext = this;
                Message = $"Уверены, что хотите удалить объявление \"{(SelectedItem as Announcement).Name}\" ?";
                dialogWindow.ShowDialog();
                if (dialogWindow.DialogResult == true)
                    announcementRepository.delete(SelectedItem as Announcement);
            }

            else if (SelectedItem is TmpAnnouncement)
            {
                DialogWindow dialogWindow = new DialogWindow();
                dialogWindow.DataContext = this;
                Message = $"Уверены, что хотите удалить объявление \"{(SelectedItem as TmpAnnouncement).Name}\" ?";
                dialogWindow.ShowDialog();
                if (dialogWindow.DialogResult == true)
                    tmpAnnouncementRepository.delete(SelectedItem as TmpAnnouncement);
            }
            else
            {
                AlertWindow alertWindow = new AlertWindow($"Выберите объект");
                alertWindow.ShowDialog();
            }
           
            update();

        }

        public void showInfo()
        {
            if(SelectedItem != null)
            {
                if(SelectedItem is User)
                {
                    UserViewWindow userViewWindow = new UserViewWindow(SelectedItem);                    
                    userViewWindow.ShowDialog();
                }
                else
                {
                    QuickViewWindow quickViewWindow = new QuickViewWindow(SelectedItem);
                    quickViewWindow.ShowDialog();
                }
                
            }
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
