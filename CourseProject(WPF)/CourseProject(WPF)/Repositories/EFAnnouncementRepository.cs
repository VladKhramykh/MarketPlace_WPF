using CourseProject_WPF_.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_WPF_.DataBase
{
    class EFAnnouncementRepository : IAnnouncementRepository
    {
        private MarketPlaceEntities context;

        public EFAnnouncementRepository()
        {
            context = new MarketPlaceEntities();
        }

        public IEnumerable<Announcement> getAll()
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

        public void delete(Announcement tmp)
        {
            context.Announcements.Remove(tmp);
            context.SaveChanges();
        }       

        public void add(Announcement announcement)
        {
            context.Announcements.Add(announcement);
            context.SaveChanges();
        }

        public Announcement getByName(string name)
        {
            return context.Announcements.FirstOrDefault(x => x.name == name);
        }
        
        public IEnumerable<Announcement> getBySellerId(int sellerID)
        {
            return context.Announcements.Where(x => x.seller == sellerID).ToList();
        }  

        public IEnumerable<Announcement> getByCategory(string category)
        {
            return context.Announcements.Where(x => x.category == category);
        }

        public List<string> getCategories()
        {
            List<string> tmp = new List<string>();

            foreach (Announcement announcement in context.Announcements)
                tmp.Add(announcement.category);

            return tmp;
        }
    }
}
