using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_WPF_.Model 
{
    public class User : INotifyPropertyChanged
    {
        [Key]
        public int Id { get; set; }

        private string firstName;
        private string secondName;
        private string mail;
        private string password;
        private string telNumber;
        private string about;
        private string privilege;

        public virtual ICollection<Announcement> Announcements { get; set; }

        public  string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string SecondName
        {
            get { return firstName; }
            set
            {
                secondName = value;
                OnPropertyChanged("SecondName");
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

        public string About
        {
            get { return about; }
            set
            {
                about = value;
                OnPropertyChanged("About");
            }
        }

        public string Privilege
        {
            get { return privilege; }
            set
            {
                privilege = value;
                OnPropertyChanged("Privilege");
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

        public override string ToString()
        {
            return $"Имя: {firstName}\n" +
                $"Фамилия: {secondName}\n" +
                $"mail: {mail}\n";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));           
        }
       

            


    }
}
