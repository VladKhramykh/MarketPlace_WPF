using CourseProject_WPF_.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_WPF_.Repositories
{
    public interface ITmpAnnouncementRepository
    {
        IEnumerable<TmpAnnouncement> getAll();
        void delete(TmpAnnouncement announcement);
        void add(TmpAnnouncement announcement);
        TmpAnnouncement getByName(string name);
        IEnumerable<TmpAnnouncement> getBySellerId(int id);
    }
}
