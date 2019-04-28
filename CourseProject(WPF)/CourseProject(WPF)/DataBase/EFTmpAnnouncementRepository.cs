using CourseProject_WPF_.Model;
using System.Collections.Generic;
using System.Linq;

namespace CourseProject_WPF_.DataBase
{
    class EFTmpAnnouncementRepository
    {
        private MarketPlaceEntities context;

        public EFTmpAnnouncementRepository()
        {
            context = new MarketPlaceEntities();
        }

        public IEnumerable<TmpAnnouncement> getAnnouncements()
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

        public void deleteAnnouncement(TmpAnnouncement tmp)
        {
            context.TmpAnnouncements.Remove(tmp);
            context.SaveChanges();
        }

        public void addAnnouncement(TmpAnnouncement tmpAnnouncement)
        {
            context.TmpAnnouncements.Add(tmpAnnouncement);
            context.SaveChanges();
        }

        public TmpAnnouncement getAnnouncementByName(string name)
        {
            return context.TmpAnnouncements.FirstOrDefault(x => x.name == name);
        }

        public IEnumerable<TmpAnnouncement> getAnnouncementsBySellerId(int sellerID)
        {
            return context.TmpAnnouncements.Where(x => x.seller == sellerID).ToList();
        }
    }
}
