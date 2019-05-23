namespace CourseProject_WPF_.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Windows.Media.Imaging;

    public partial class User : INotifyPropertyChanged
    {

        //public static readonly string filename2 = @"G:\УЧЁБА\Курсач ООП\CourseProject(WPF)\currentUserImage.png";
        public static readonly string filename = Environment.CurrentDirectory.ToString() + @"\currentUserImage.png";        

        public User()
        {
            this.Announcements = new HashSet<Announcement>();
            this.TmpAnnouncements = new HashSet<TmpAnnouncement>();
        }

        public int id { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public string telNumber { get; set; }
        public string about { get; set; }
        public byte[] image { get; set; }
        public string privilege { get; set; }


        public virtual ICollection<Announcement> Announcements { get; set; }
        public virtual ICollection<TmpAnnouncement> TmpAnnouncements { get; set; }


        BitmapImage bitmap;
        public BitmapImage BitmapImage
        {
            get { return bitmap; }
            set
            {
                bitmap = value;
                OnPropertyChanged("BitmapImage");
            }
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
            set { secondName = value; }
        }

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        public string TelNumber
        {
            get { return telNumber; }
            set { telNumber = value; }
        }

        public string About
        {
            get { return about; }
            set { about = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Privilege
        {
            get { return privilege; }
            set { privilege = value; }
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

        public User(string firstName, string secondName, string mail, string telNumber, string about, byte[] image) : this(firstName, secondName, mail, telNumber, about)
        {
            this.image = image;
        }

        public User(string firstName, string secondName, string mail, string telNumber, string about, string privilege)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            SecondName = secondName ?? throw new ArgumentNullException(nameof(secondName));
            Mail = mail ?? throw new ArgumentNullException(nameof(mail));
            TelNumber = telNumber ?? throw new ArgumentNullException(nameof(telNumber));
            About = about ?? throw new ArgumentNullException(nameof(about));
            Privilege = privilege ?? throw new ArgumentNullException(nameof(privilege));
        }

        public User(string firstName, string secondName, string mail, string telNumber, string about, byte[] image, string privilege) : this(firstName, secondName, mail, telNumber, about, image)
        {
            this.privilege = privilege;
        }

        public User(string firstName, string secondName, string mail, string password, string telNumber, string about, byte[] image, string privilege) : this(firstName, secondName, mail, password, telNumber, about)
        {
            this.image = image;
            this.privilege = privilege;
        }

        public string Name
        {
            get { return $"{firstName} {secondName}"; }
        }

        public override string ToString()
        {
            return $"{firstName} {secondName}\n" +
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
                return $"{firstName} {secondName}\n" +
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

        public void LoadPhoto()
        {
            if (image != null)
            {
                using (var ms = new MemoryStream(image))
                {
                    BitmapImage.BeginInit();
                    BitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    BitmapImage.StreamSource = ms;
                    BitmapImage.EndInit();
                }
            }
            OnPropertyChanged("BitmapImage");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}