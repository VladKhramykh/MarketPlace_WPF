using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_WPF_.Model 
{
    public class User : INotifyPropertyChanged
    {
        private string firstName;
        private string secondName;
        private string mail;
        private string password;
        private string telNumber;
        
        public  string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("Firstname");
            }
        }

        public string SecondName
        {
            get { return firstName; }
            set
            {
                secondName = value;
                OnPropertyChanged("Secondname");
            }
        }
        public string Mail
        {
            get { return mail; }
            set
            {
                mail = value;
                OnPropertyChanged("Mail");
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public string TelNumber
        {
            get { return telNumber; }
            set
            {
                telNumber = value;
                OnPropertyChanged("TelNumber");
            }
        }

        
        
        public static User[] getUsers()
        {
            var result = new[]
            {
                new User() {FirstName ="1",SecondName="1",Mail="1",Password="1",TelNumber="1"},
                new User() {FirstName ="2",SecondName="2",Mail="2",Password="2",TelNumber="2"},
                new User() {FirstName ="3",SecondName="3",Mail="3",Password="3",TelNumber="3"},

            };
            return result;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
           
        }
       

            


    }
}
