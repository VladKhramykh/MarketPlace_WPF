using CourseProject_WPF_.Model;
using CourseProject_WPF_.Repositories;
using CourseProject_WPF_.View;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace CourseProject_WPF_.ViewModel
{
    public class MyAnnouncementPageViewModel : INotifyPropertyChanged
    {
        EFUserRepository userRepository = new EFUserRepository();
        EFAnnouncementRepository announcementRepository = new EFAnnouncementRepository();
        EFTmpAnnouncementRepository tmpAnnouncementRepository = new EFTmpAnnouncementRepository();

        ObservableCollection<Announcement> tmpAnnouncements = new ObservableCollection<Announcement>();
        ObservableCollection<TmpAnnouncement> tmpTmpAnnouncements = new ObservableCollection<TmpAnnouncement>();
        object selectedItem;

        int countActual;
        int countTmp;

        public ObservableCollection<Announcement> Announcements
        {
            get { return tmpAnnouncements; }
        }
        public ObservableCollection<TmpAnnouncement> TmpAnnouncements
        {
            get { return tmpTmpAnnouncements; }
        }

        public string CountActual
        {
            get { return $" Актуальные ( {countActual} )"; }
            set
            {
                countActual = Int32.Parse(value);
                OnPropertyChanged("CountActual");
            }
        }

        public string CountTmp
        {
            get { return $"На проверке ( {countTmp} )"; }
            set
            {
                countTmp = Int32.Parse(value);
                OnPropertyChanged("CountTmp");
            }
        }

        public object SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
            }
        }

        public MyAnnouncementPageViewModel()
        {
            update();
        }
        
        public void update()
        {            
            tmpAnnouncements.Clear();
            tmpTmpAnnouncements.Clear();
            
            foreach (Announcement announcement in announcementRepository.getBySellerId(CurrentUser.User.id))
                tmpAnnouncements.Add(announcement);
            foreach (TmpAnnouncement announcement in tmpAnnouncementRepository.getBySellerId(CurrentUser.User.id))
                tmpTmpAnnouncements.Add(announcement);

            CountActual = announcementRepository.getBySellerId(CurrentUser.User.id).Count().ToString();
            CountTmp = tmpAnnouncementRepository.getBySellerId(CurrentUser.User.id).Count().ToString();
        }

        public void deleteAnnouncement()
        {
            if (SelectedItem is Announcement)
                announcementRepository.delete(SelectedItem as Announcement);
            else if (SelectedItem is TmpAnnouncement)
                tmpAnnouncementRepository.delete(SelectedItem as TmpAnnouncement);

            update();
        }

        public void addAnnouncement()
        {
            AddWindow addWindow = new AddWindow();
            addWindow.ShowDialog();
        }

        public void showInfo()
        {
            if(SelectedItem != null)
            {
                QuickViewWindow quickViewWindow = new QuickViewWindow(SelectedItem);
                quickViewWindow.ShowDialog();
            }
            
        }

        public void editAnnouncement()
        {
            EditWindow editWindow = new EditWindow(SelectedItem);
            editWindow.ShowDialog();
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
