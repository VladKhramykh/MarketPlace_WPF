using CourseProject_WPF_.Repositories;
using CourseProject_WPF_.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CourseProject_WPF_.ViewModel
{
    class TmpAnnouncementViewModel
    {
        
        EFUserRepository eFUser = new EFUserRepository();        
        EFAnnouncementRepository eFAnnouncement = new EFAnnouncementRepository();        
        EFTmpAnnouncementRepository eFTmpAnnouncement = new EFTmpAnnouncementRepository();

        ObservableCollection<TmpAnnouncement> tmpAnnouncement = new ObservableCollection<TmpAnnouncement>();

        public ObservableCollection<TmpAnnouncement> Announcements
        {
            get { return tmpAnnouncement; }
            set { tmpAnnouncement = value; }
        }

        public TmpAnnouncementViewModel()
        {
            foreach (TmpAnnouncement announcement in eFTmpAnnouncement.getAll())
                tmpAnnouncement.Add(announcement);
        }

        public IEnumerable<TmpAnnouncement> getAnnouncements()
        {
            return eFTmpAnnouncement.getAll();
        }

        public void deleteAnnouncement(TmpAnnouncement tmp)
        {
            eFTmpAnnouncement.delete(tmp);
        }

        public void addAnnouncement(TmpAnnouncement tmp)
        {
            eFTmpAnnouncement.add(tmp);
        }

        public IEnumerable<TmpAnnouncement> getAnnouncementsBySellerId(int sellerID)
        {
            if (sellerID != 0)
                return eFTmpAnnouncement.getBySellerId(sellerID);
            else
                return null;
        }

        public bool transferToAnnouncemet(TmpAnnouncement tmp)
        {
            if (tmp is TmpAnnouncement)
            {
                Announcement announcement = new Announcement();
                announcement.name = tmp.name;
                announcement.seller = tmp.seller;
                announcement.category = tmp.category;
                announcement.about = tmp.about;
                announcement.cost = tmp.cost;
                eFAnnouncement.add(announcement);
                deleteAnnouncement(tmp);
                return true;
            }
            else
                return false;

            
        }
    }
}
