using CourseProject_WPF_.DataBase;
using CourseProject_WPF_.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_WPF_.ViewModel
{
    class TmpAnnouncementViewModel
    {
        
        EFUserRepository eFUser = new EFUserRepository();        
        EFAnnouncementRepository eFAnnouncement = new EFAnnouncementRepository();        
        EFTmpAnnouncementRepository eFTmpAnnouncement = new EFTmpAnnouncementRepository();

        public TmpAnnouncementViewModel() { }

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
