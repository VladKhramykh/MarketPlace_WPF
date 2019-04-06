using CourseProject_WPF_.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_WPF_.ViewModel
{
    public class AuthWindowViewModel : INotifyPropertyChanged
    {
        User[] users;
        public User[] Users { get; private set; }

        public AuthWindowViewModel()
        {
            users = User.getUsers();
        }



        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
