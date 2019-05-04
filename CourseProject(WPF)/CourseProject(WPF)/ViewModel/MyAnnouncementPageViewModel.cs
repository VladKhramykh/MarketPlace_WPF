using CourseProject_WPF_.Model;
using CourseProject_WPF_.Repositories;
using CourseProject_WPF_.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_WPF_.ViewModel
{
    public class MyAnnouncementPageViewModel
    {
        EFUserRepository userRepository = new EFUserRepository();
        EFAnnouncementRepository announcementRepository = new EFAnnouncementRepository();
        EFTmpAnnouncementRepository tmpAnnouncementRepository = new EFTmpAnnouncementRepository();

        ObservableCollection<Announcement> tmpAnnouncements = new ObservableCollection<Announcement>();
        ObservableCollection<TmpAnnouncement> tmpTmpAnnouncements = new ObservableCollection<TmpAnnouncement>();
        object selectedItem;

        public ObservableCollection<Announcement> Announcements
        {
            get { return tmpAnnouncements; }
        }
        public ObservableCollection<TmpAnnouncement> TmpAnnouncements
        {
            get { return tmpTmpAnnouncements; }
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
            AlertWindow alertWindow = new AlertWindow(SelectedItem.ToString());
            alertWindow.Show();
        }

        public void editAnnouncement()
        {
            EditWindow editWindow = new EditWindow(SelectedItem);
            editWindow.ShowDialog();
            update();
        }
    }
}
