using CourseProject_WPF_.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_WPF_.Repositories
{
    public interface IAnnouncementRepository
    {
        IEnumerable<Announcement> getAll();
        void delete(Announcement announcement);
        void add(Announcement announcement);
        Announcement getByName(string name);
        IEnumerable<Announcement> getBySellerId(int id);
        IEnumerable<Announcement> getByCategory(string category);
        List<string> getCategories();
    }
}
