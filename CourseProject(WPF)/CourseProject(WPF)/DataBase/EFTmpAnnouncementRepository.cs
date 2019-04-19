using CourseProject_WPF_.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_WPF_.DataBase
{

    class EFTmpAnnouncementRepository
    {
        private MarketPlaceEntities context;

        public EFTmpAnnouncementRepository()
        {
            context = new MarketPlaceEntities();
        }

        public IEnumerable<TmpAnnouncement> getProducts()
        {
            return context.TmpAnnouncements;
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
