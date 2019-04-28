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
            return eFTmpAnnouncement.getAnnouncements();
        }

        public void deleteAnnouncement(TmpAnnouncement tmp)
        {
            eFTmpAnnouncement.deleteAnnouncement(tmp);
        }

        public void addAnnouncement(TmpAnnouncement tmp)
        {
            eFTmpAnnouncement.addAnnouncement(tmp);
        }

        public IEnumerable<TmpAnnouncement> getAnnouncementsBySellerId(int sellerID)
        {
            if (sellerID != 0)
                return eFTmpAnnouncement.getAnnouncementsBySellerId(sellerID);
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
                eFAnnouncement.addAnnouncement(announcement);
                deleteAnnouncement(tmp);
                return true;
            }
            else
                return false;

            
        }
    }
}
