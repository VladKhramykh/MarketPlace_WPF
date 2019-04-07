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

        public User getUserById(string mail)
        {
            return context.Users.FirstOrDefault(x => x.Mail == mail);
        }
    }
}
