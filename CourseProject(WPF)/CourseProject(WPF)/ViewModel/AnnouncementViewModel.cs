using CourseProject_WPF_.DataBase;
using CourseProject_WPF_.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_WPF_.ViewModel
{
    class AnnouncementViewModel
    {
        EFUserRepository eFUser = new EFUserRepository();
        EFAnnouncementRepository eFAnnouncement = new EFAnnouncementRepository();
        EFTmpAnnouncementRepository eFTmpAnnouncement = new EFTmpAnnouncementRepository();

        public AnnouncementViewModel() { }        

        public IEnumerable<Announcement> getAnnouncements()
        {
            return eFAnnouncement.getAnnouncements();
        }

        public void deleteAnnouncement(Announcement tmp)
        {
            eFAnnouncement.deleteAnnouncement(tmp);
        }

        public IEnumerable<Announcement> getAnnouncementsBySellerId(int sellerID)
        {
            if (sellerID != 0)
                return eFAnnouncement.getAnnouncementsBySellerId(sellerID);
            else
                return null;
        }

        public void addAnnouncement(Announcement announcement)
        {
            eFAnnouncement.addAnnouncement(announcement);
        }

    }
}
