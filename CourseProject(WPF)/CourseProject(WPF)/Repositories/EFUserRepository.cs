using System.Collections.Generic;
using System.Linq;
using CourseProject_WPF_.Model;

namespace CourseProject_WPF_.Repositories
{
    class EFUserRepository : IUserRepository
    {
        private NewMarketPlaceEntities1 context;       

        public EFUserRepository()
        {
            context = new NewMarketPlaceEntities1();
        }
        public List<string> getAllNames()
        {
            List<string> tmp = new List<string>();
            foreach (User s in context.Users)
                tmp.Add(s.getName());
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
        public User getByName(string name)
        {
            return context.Users.FirstOrDefault(x => (x.firstName + " " + x.secondName) == name);
        }
        public  User getById(int? id)
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
                tmp.image = newUser.image;
                tmp.TelNumber = newUser.telNumber;                
            }
            context.SaveChanges();
        }
        public void changePrivelege(User user, string privelege)
        {
            context.Users.FirstOrDefault(x => x.id == user.id).privilege = privelege;
            context.SaveChanges();
        }
    }
}
