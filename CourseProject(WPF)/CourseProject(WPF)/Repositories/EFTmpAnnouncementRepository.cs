using CourseProject_WPF_.Model;
using System.Collections.Generic;
using System.Linq;

namespace CourseProject_WPF_.DataBase
{
    class EFTmpAnnouncementRepository : ITmpAnnouncementRepository
    {
        private MarketPlaceEntities context;

        public EFTmpAnnouncementRepository()
        {
            context = new MarketPlaceEntities();
        }

        
        public IEnumerable<TmpAnnouncement> getAll()
        {
            return context.TmpAnnouncements;
        }

        //public bool deleteTmpAnnouncementsBySeller(User user)
        //{
        //    TmpAnnouncement tmp = context.TmpAnnouncements.FirstOrDefault(x => x.seller == user.id);
        //    if (tmp != null)
        //    {
        //        context.TmpAnnouncements.Remove(tmp);
        //        return true;
        //    }
        //    else
        //        return false;
        //}

        public void delete(TmpAnnouncement tmp)
        {
            context.TmpAnnouncements.Remove(tmp);
            context.SaveChanges();
        }

        public void add(TmpAnnouncement tmpAnnouncement)
        {
            context.TmpAnnouncements.Add(tmpAnnouncement);
            context.SaveChanges();
        }

        public TmpAnnouncement getByName(string name)
        {
            return context.TmpAnnouncements.FirstOrDefault(x => x.name == name);
        }

        public IEnumerable<TmpAnnouncement> getBySellerId(int sellerID)
        {
            return context.TmpAnnouncements.Where(x => x.seller == sellerID).ToList();
        }
    }
}
