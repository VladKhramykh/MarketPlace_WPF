using System;
using System.ComponentModel;
using CourseProject_WPF_.Model;
using CourseProject_WPF_.View;
using CourseProject_WPF_.Repositories;

namespace CourseProject_WPF_.ViewModel
{
    public class QuickWindowViewModel :INotifyPropertyChanged
    {

        EFUserRepository userRepository = new EFUserRepository();
        EFRegionRepository regionRepository = new EFRegionRepository();

        object item;
        string info;
        string name;
        string contactInfo;
        string region;
        string title;
        string about;
        decimal cost;

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
        public string Info
        {
            get { return info; }
            set
            {
                info = value;
                OnPropertyChanged("Info");
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

        public string Region
        {
            get { return region; }
            set
            {
                region = value;
                OnPropertyChanged("Region");
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
        public decimal Cost
        {
            get { return cost; }
            set
            {
                cost = value;
                OnPropertyChanged("Cost");
            }
        }

        public QuickWindowViewModel(object item)
        {
            Item = item;
            if(Item is Announcement)
            {
                Info = (Item as Announcement).Info;
                Title = $"Информация о объявлении {(Item as Announcement).Name}";
                Name = (Item as Announcement).Name;
                Region = regionRepository.getRegion((Item as Announcement).idRegion.Value);
                ContactInfo =   $"Mail: {userRepository.getById((Item as Announcement).seller).Mail}\n" +
                                $"Телефон: {userRepository.getById((Item as Announcement).seller).TelNumber}\n";
                About = $"{(Item as Announcement).About}\n";
                Cost = Decimal.Round((Item as Announcement).Cost, 2);
               
            }
            else if(Item is TmpAnnouncement)
            {
                Info = (Item as TmpAnnouncement).Info;
                Title = $"Информация о объявлении {(Item as TmpAnnouncement).Name}";
                Name = (Item as TmpAnnouncement).Name;
                Region = regionRepository.getRegion((Item as TmpAnnouncement).idRegion.Value);
                ContactInfo =   $"Mail: {userRepository.getById((Item as TmpAnnouncement).seller).Mail}\n" +
                                $"Телефон: {userRepository.getById((Item as TmpAnnouncement).seller).TelNumber}\n";
                About = $"{(Item as TmpAnnouncement).About}\n";
                Cost = Decimal.Round((Item as TmpAnnouncement).Cost, 2);
            }
            else
            {
                AlertWindow alertWindow = new AlertWindow("Ошибка типа данных!");
                alertWindow.ShowDialog();
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
