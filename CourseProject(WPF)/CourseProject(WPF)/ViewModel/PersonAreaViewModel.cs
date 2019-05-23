using CourseProject_WPF_.Repositories;
using CourseProject_WPF_.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using CourseProject_WPF_.View;
using System.Windows.Media.Imaging;
using System.IO;
using System.Drawing;
using System.Windows;
using System.Windows.Media;
using Microsoft.Win32;

namespace CourseProject_WPF_.ViewModel
{
    public class PersonAreaViewModel:INotifyPropertyChanged
    {
        User user = CurrentUser.User;
        EFUserRepository userRepository = new EFUserRepository();
        EFAnnouncementRepository announcementRepository = new EFAnnouncementRepository();
        EFTmpAnnouncementRepository tmpAnnouncementRepository = new EFTmpAnnouncementRepository();

        string firstName;
        string secondName;
        string mail;
        string telNumber;
        string about;

        BitmapImage bitmap = new BitmapImage();
        string bitmapImage = "";
        string message;

        Image i;
        public Image Image
        {
            get { return i; }
            set
            {
                i = value;
                OnPropertyChanged("Image");
            }
        }

        public BitmapImage BitmapImage
        {
            get { return bitmap; }
            set
            {
                bitmap = value;
                OnPropertyChanged("BitmapImage");
            }
        }

        public PersonAreaViewModel()
        {
            firstName = user.firstName;
            secondName = user.secondName;
            mail = user.mail;
            telNumber = user.telNumber;
            about = user.about;           
            BitmapImage = LoadPhoto(user.id);
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if(!String.IsNullOrEmpty(value))
                    firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string SecondName
        {
            get { return secondName; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                    secondName = value;
                OnPropertyChanged("SecondName");
            }
        }

        public string Mail
        {
            get { return mail; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                    mail = value;
                OnPropertyChanged("Main");
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
        public string BitImage
        {
            get { return bitmapImage; }
            set
            {
                bitmapImage = value;
                OnPropertyChanged("BitImage");
            }
        }

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }

        public BitmapImage LoadPhoto(int seller)
        {
            BitmapImage bitmapImage = new BitmapImage();

            if (userRepository.getById(seller).image != null)
            {
                using (var ms = new MemoryStream(userRepository.getById(seller).image))
                {
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = ms;
                    bitmapImage.EndInit();
                }
            }
            return bitmapImage;
        }

        public void LoadImageFromFS()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "JPG (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp|Png (*.png)|*.png";
            if (open.ShowDialog() == true)
            {
                string fileName = open.FileName;
                if (File.Exists(fileName))
                {
                    using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                    {
                        byte[] image = new byte[fs.Length];
                        fs.Read(image, 0, image.Length);
                        userRepository.update(user, new User(CurrentUser.User.FirstName, CurrentUser.User.SecondName, CurrentUser.User.Mail, CurrentUser.User.TelNumber, CurrentUser.User.About, image));
                        BitmapImage = LoadPhoto(user.id);
                    }
                }
            }
            else
                return;            
        }

        public void changeDataOfUser()
        {
            User tmp = new User(FirstName, SecondName, Mail, TelNumber, About,CurrentUser.User.image, user.privilege);
            userRepository.update(user, tmp);
            CurrentUser.User = userRepository.getByMail(Mail);

            AlertWindow alertWindow = new AlertWindow($"Изменения сохранены\nДля входа используйте новый Mail - {Mail}");
            alertWindow.ShowDialog();
        }
            

        public void deleteUser()
        {
            DialogWindow dialogWindow = new DialogWindow();
            dialogWindow.DataContext = this;
            Message = $"Уверены, что хотите удалить пользователя {CurrentUser.User.FirstName} {CurrentUser.User.FirstName}?";
            dialogWindow.ShowDialog();
            if (dialogWindow.DialogResult == true)
            {
                foreach (TmpAnnouncement announcement in tmpAnnouncementRepository.getBySellerId(user.id))
                    tmpAnnouncementRepository.delete(announcement);
                foreach (Announcement announcement in announcementRepository.getBySellerId(user.id))
                    announcementRepository.delete(announcement);

                App.mainWindow.Close();
                userRepository.delete(CurrentUser.User);
                App.authWindow = new AuthWindow();
                App.authWindow.Show();
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
