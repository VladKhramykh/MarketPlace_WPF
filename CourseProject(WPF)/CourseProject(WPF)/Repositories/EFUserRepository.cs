using System.Collections.Generic;
using System.Linq;
using CourseProject_WPF_.Model;

namespace CourseProject_WPF_.DataBase
{
    class EFUserRepository : IUserRepository
    {
        private MarketPlaceEntities context;       

        public EFUserRepository()
        {
            context = new MarketPlaceEntities();
        }

        public List<string> getAllNames()
        {
            List<string> tmp = new List<string>();
            foreach (User s in context.Users)
                tmp.Add(s.mail);
            return tmp;
        }

        public IEnumerable<User> getAll()
        {
            return context.Users;
        }

        public void add(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }    
        
        public void delete(User user)
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }

        public User getByMail(string mail)
        {
            return context.Users.FirstOrDefault(x =>x.mail == mail);
        }

        public void update(User oldUser, User newUser)
        {
            var tmp = context.Users.FirstOrDefault(x => x.id == oldUser.id);

            if(tmp!= null)
            {
                tmp.firstName = newUser.firstName;
                tmp.secondName = newUser.secondName;
                tmp.mail = newUser.mail;
                tmp.about = newUser.about;
                tmp.telNumber = newUser.telNumber;
                context.SaveChanges();
            }
            
        }
    }
}
