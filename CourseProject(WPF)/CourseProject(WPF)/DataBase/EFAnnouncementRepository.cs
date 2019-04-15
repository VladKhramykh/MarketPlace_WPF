using CourseProject_WPF_.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_WPF_.DataBase
{
    class EFAnnouncementRepository
    {
        private EFDBContext context;

        public EFAnnouncementRepository()
        {
            context = new EFDBContext();
        }

        public IEnumerable<Announcement> getAnnouncements()
        {
            return context.Announcements;
        }

        public void addAnnouncement(Announcement announcement)
        {
            context.Announcements.Add(announcement);
            context.SaveChanges();
        }

        public Announcement getAnnouncementByName(string name)
        {
            return context.Announcements.FirstOrDefault(x => x.Name == name);
        }

        public Announcement getAnnouncementBySeller(string sellerMail)
        {
            return context.Announcements.FirstOrDefault(x => x.Seller.Mail == sellerMail);
        }

        public Announcement getAnnouncementByCost(decimal cost)
        {
            return context.Announcements.FirstOrDefault(x => x.Cost == cost);
        }
    }
}
