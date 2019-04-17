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
        private MarketPlaceEntities context;

        public EFAnnouncementRepository()
        {
            context = new MarketPlaceEntities();
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
            return context.Announcements.FirstOrDefault(x => x.name == name);
        }

        /*
        public Announcements getAnnouncementBySeller(string seller)
        {
            return context.Announcements.FirstOrDefault(x => x.seller == seller);
        }
        */

        public Announcement getAnnouncementByCost(decimal cost)
        {
            return context.Announcements.FirstOrDefault(x => x.cost == cost);
        }
    }
}
