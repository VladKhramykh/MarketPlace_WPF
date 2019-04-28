using CourseProject_WPF_.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        //public bool deleteAnnouncementsBySeller(User user)
        //{
        //    Announcement tmp = context.Announcements.FirstOrDefault(x=>x.seller == user.id);
        //    if (tmp != null)
        //    {
        //        context.Announcements.Remove(tmp);
        //        return true;
        //    }                
        //    else
        //        return false;
        //}

        public void deleteAnnouncement(Announcement tmp)
        {
            context.Announcements.Remove(tmp);
            context.SaveChanges();
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
        
        public IEnumerable<Announcement> getAnnouncementsBySellerId(int sellerID)
        {
            return context.Announcements.Where(x => x.seller == sellerID).ToList();
        }  
    }
}
