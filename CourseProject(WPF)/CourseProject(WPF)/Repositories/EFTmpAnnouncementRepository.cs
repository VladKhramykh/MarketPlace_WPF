using CourseProject_WPF_.Model;
using System.Collections.Generic;
using System.Linq;

namespace CourseProject_WPF_.Repositories
{
    class EFTmpAnnouncementRepository : ITmpAnnouncementRepository
    {
        private NewMarketPlaceEntities1 context;

        public EFTmpAnnouncementRepository()
        {
            context = new NewMarketPlaceEntities1();
        }
        
        public IEnumerable<TmpAnnouncement> getAll()
        {
            return context.TmpAnnouncements;
        }

        public void delete(TmpAnnouncement announcement)
        {
            context.TmpAnnouncements.Remove(context.TmpAnnouncements.FirstOrDefault(x => x.id == announcement.id));
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
