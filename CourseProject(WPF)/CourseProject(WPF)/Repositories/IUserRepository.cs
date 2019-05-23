using CourseProject_WPF_.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_WPF_.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> getAll();
        void add(User user);
        User getByMail(string name);
        User getById(int? id);
        void update(User oldUser, User newUser);       
        List<string> getAllNames();
        void changePrivelege(User user, string privelege);
    }
}
