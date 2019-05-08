using System.Collections.Generic;
using System.Linq;
using CourseProject_WPF_.Model;

namespace CourseProject_WPF_.Repositories
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
            context.Users.Remove(context.Users.FirstOrDefault(x=>x.id == user.id));
            context.SaveChanges();
        }

        public User getByMail(string mail)
        {
            return context.Users.FirstOrDefault(x =>x.mail == mail);
        }

        public User getById(int? id)
        {
            return context.Users.FirstOrDefault(x => x.id == id);
        }

        public void update(User oldUser, User newUser)
        {
            var tmp = context.Users.FirstOrDefault(x => x.id == oldUser.id);

            if(tmp!= null)
            {
                tmp.FirstName = newUser.firstName;
                tmp.SecondName = newUser.secondName;
                tmp.Mail = newUser.mail;
                tmp.About = newUser.about;
                tmp.TelNumber = newUser.telNumber;                
            }
            context.SaveChanges();

        }

        public bool changePrivelege(User user, string privelege)
        {
            if (context.Users.FirstOrDefault(x => x.id == user.id).privilege.Equals(privelege))
                return false;
            else
            {
                context.Users.FirstOrDefault(x => x.id == user.id).privilege = privelege;
                context.SaveChanges();
                return true;
            }
            
            
        }
    }
}
