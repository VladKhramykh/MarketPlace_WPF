using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_WPF_.Model 
{
    [Table("Users")]
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
        //public virtual ICollection<TmpProduct> TmpProduct { get; set; }



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

        public string TelNumber
        {
            get { return telNumber; }
            set
            {
                telNumber = value;
                OnPropertyChanged("TelNumber");
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

        
        public User() { }
        public User(string firstName, string secondName, string mail, string password)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            SecondName = secondName ?? throw new ArgumentNullException(nameof(secondName));
            Mail = mail ?? throw new ArgumentNullException(nameof(mail));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            TelNumber = "";
            About = "";
            Privilege = "user";

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

        public static string getHash(string password)
        {
            if (String.IsNullOrEmpty(password))
            {
                return "-1";
            }
            else
            {
                var md5 = MD5.Create();
                var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hash);
            }
        }
    }
}
