using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CourseProject_WPF_.Model;

namespace CourseProject_WPF_.DataBase
{
    class EFUserRepository
    {
        private EFDBContext context;       

        public EFUserRepository()
        {
            context = new EFDBContext();
        }

        public IEnumerable<User> getUsers()
        {
            return context.Users;
        }

        public void addUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public User getUserByMail(string mail)
        {
            return context.Users.FirstOrDefault(x => x.Mail == mail);
        }
    }
}
