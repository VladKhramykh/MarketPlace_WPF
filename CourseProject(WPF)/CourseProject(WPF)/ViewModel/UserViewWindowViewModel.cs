using CourseProject_WPF_.Model;
using CourseProject_WPF_.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CourseProject_WPF_.ViewModel
{
    public class UserViewWindowViewModel : INotifyPropertyChanged
    {
        object item;
        string name;
        string contactInfo;
        string title;
        string about;

        public object Item
        {
            get { return item; }
            set
            {
                if (value != null)
                    item = value;
                OnPropertyChanged("Item");
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

        public string About
        {
            get { return about; }
            set
            {
                about = value;
                OnPropertyChanged("About");
            }
        }
        public string ContactInfo
        {
            get { return contactInfo; }
            set
            {
                contactInfo = value;
                OnPropertyChanged("ContactInfo");
            }
        }
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        BitmapImage bitmap = new BitmapImage();
        public BitmapImage BitmapImage
        {
            get { return bitmap; }
            set
            {
                bitmap = value;
                OnPropertyChanged("BitmapImage");
            }
        }

        public UserViewWindowViewModel(object item)
        {
            Item = item;
            if (Item is User)
            {
                Title = $"Информация о пользователе {(Item as User).FirstName} {(Item as User).SecondName}";
                Name = $"{(Item as User).FirstName} {(Item as User).SecondName}";
                ContactInfo = $"Mail: {(Item as User).Mail}\nТелефон: {(Item as User).TelNumber}\n";
                About = $"{(Item as User).About}\n";
                BitmapImage = LoadPhoto();
            }            
            else
            {
                AlertWindow alertWindow = new AlertWindow("Ошибка типа данных!");
                alertWindow.ShowDialog();
            }
        }

        public BitmapImage LoadPhoto()
        {
            BitmapImage tmp = new BitmapImage();
            if ((Item as User).image != null)
            {
                using (var ms = new MemoryStream((Item as User).image))
                {
                    tmp.BeginInit();
                    tmp.CacheOption = BitmapCacheOption.OnLoad;
                    tmp.StreamSource = ms;
                    tmp.EndInit();
                }
            }
            return tmp;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
