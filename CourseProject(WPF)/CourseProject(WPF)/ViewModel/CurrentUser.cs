using CourseProject_WPF_.Model;

namespace CourseProject_WPF_
{
    public class CurrentUser
    {
        private static User user;

        public static User User
        {
            get { return user; }
            set { user = value; }
        }

        public static bool isAdmin()
        {
            if (User.privilege.Equals("admin"))
                return true;
            return false;
        }

        public override string ToString()
        {
            return User.FirstName + " " + User.SecondName;
        }
    }
}
