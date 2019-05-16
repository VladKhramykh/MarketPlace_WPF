namespace CourseProject_WPF_.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security.Cryptography;
    using System.Text;

    public partial class User : INotifyPropertyChanged
    {

        public int id { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public string telNumber { get; set; }
        public string about { get; set; }
        public string privilege { get; set; }

        public virtual ICollection<Announcement> Announcements { get; set; }
        public virtual ICollection<TmpAnnouncement> TmpAnnouncements { get; set; }

        
        public User()
        {
            this.Announcements = new HashSet<Announcement>();
            this.TmpAnnouncements = new HashSet<TmpAnnouncement>();
        }

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

        public User(string firstName, string secondName, string mail, string telNumber, string about)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            SecondName = secondName ?? throw new ArgumentNullException(nameof(secondName));
            Mail = mail ?? throw new ArgumentNullException(nameof(mail));
            TelNumber = telNumber ?? throw new ArgumentNullException(nameof(telNumber));
            About = about ?? throw new ArgumentNullException(nameof(about));
            Privilege = "user";
        }

        public User(string firstName, string secondName, string mail, string telNumber, string about, string privilege)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            SecondName = secondName ?? throw new ArgumentNullException(nameof(secondName));
            Mail = mail ?? throw new ArgumentNullException(nameof(mail));
            TelNumber = telNumber ?? throw new ArgumentNullException(nameof(telNumber));
            About = about ?? throw new ArgumentNullException(nameof(about));
            Privilege = privilege  ?? throw new ArgumentNullException(nameof(privilege));
        }


        public string FirstName
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
            get { return secondName; }
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

        public string Name
        {
            get { return $"{firstName} {secondName}"; }
        }
        
        public override string ToString()
        {
            return  $"{firstName} {secondName}\n" + 
                    $"mail: {mail}\n" +
                    $"privelege: {privilege}\n";
        }

        public string getName()
        {
            return $"{firstName} {secondName}";            
        }

        public string Info
        {
            get
            {
                return  $"{firstName} {secondName}\n" +
                        $"mail: {mail}\n" +
                        $"Телефон: {telNumber}";
            }
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

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
