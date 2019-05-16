using CourseProject_WPF_.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_WPF_.Repositories
{
    class EFAnnouncementRepository : IAnnouncementRepository
    {
        private NewMarketPlaceEntities1 context;

        public EFAnnouncementRepository()
        {
            context = new NewMarketPlaceEntities1();
        }

        public IEnumerable<Announcement> getAll()
        {
            return context.Announcements;
        }

        public void delete(Announcement announcement)
        {
            context.Announcements.Remove(context.Announcements.FirstOrDefault(x => x.id == announcement.id));
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
        public IEnumerable<Announcement> getByRegionId(int id)
        {
            return context.Announcements.Where(x => x.idRegion == id);
        }
        public List<string> getCategories()
        {
            List<string> tmp = new List<string>();

            foreach (Announcement announcement in context.Announcements)
                tmp.Add(announcement.category);

            return tmp;
        }

        public decimal MaxCost()
        {
            return context.Announcements.Count() > 0 ? context.Announcements.Max(x => x.cost).Value : 0;
        }
    }
}
