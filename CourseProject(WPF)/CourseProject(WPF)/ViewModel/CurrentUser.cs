using CourseProject_WPF_.Model;
using System.ComponentModel;

namespace CourseProject_WPF_
{
    public class CurrentUser : INotifyPropertyChanged
    {
        private static User user;
        string name;

        public static User User
        {
            get { return user; }
            set
            {
                user = value;                
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public static bool isAdmin()
        {
            if (User.privilege.Equals("admin"))
                return true;
            return false;
        }
        public static bool isModerator()
        {
            if (User.privilege.Equals("moderator"))
                return true;
            return false;
        }
        public override string ToString()
        {
            return User.FirstName + " " + User.SecondName;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
