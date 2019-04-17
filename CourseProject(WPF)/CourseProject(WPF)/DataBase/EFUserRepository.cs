using System.Collections.Generic;
using System.Linq;
using CourseProject_WPF_.Model;

namespace CourseProject_WPF_.DataBase
{
    class EFUserRepository
    {
        private MarketPlaceEntities context;       

        public EFUserRepository()
        {
            context = new MarketPlaceEntities();
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
            return context.Users.FirstOrDefault(x =>x.mail == mail);
        }

        public void changeUserData(User oldUser, User newUser)
        {
            var tmp = context.Users.FirstOrDefault(x => x.id == oldUser.id);
            tmp.firstName = newUser.firstName;
            tmp.secondName = newUser.secondName;
            tmp.mail = newUser.mail;           
            tmp.about = newUser.about;
            tmp.telNumber = newUser.telNumber;
            context.SaveChanges();
        }
    }
}
