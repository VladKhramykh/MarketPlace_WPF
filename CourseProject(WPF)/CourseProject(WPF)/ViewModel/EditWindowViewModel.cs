using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using CourseProject_WPF_.Repositories;
using CourseProject_WPF_.Model;
using CourseProject_WPF_.View;
using System.Windows;

namespace CourseProject_WPF_.ViewModel
{
    public class EditWindowViewModel : INotifyPropertyChanged
    {
        EFAnnouncementRepository announcementRepository = new EFAnnouncementRepository();
        EFTmpAnnouncementRepository tmpAnnouncementRepository = new EFTmpAnnouncementRepository();

        string name;
        string category;
        string about;
        decimal cost;
        string info;

        object tmp;

        List<string> tmpCategories = new List<string>();
        object item;

        public object Item
        {
            get
            {
                if(item is Announcement)
                    return item as Announcement;
                else if (item is TmpAnnouncement)
                    return item as TmpAnnouncement;
                else
                    return item;
            }
            set
            {
                if(value != null)
                {                    
                    item = value;
                    OnPropertyChanged("Item");
                    update();
                }               
                
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length >= 0 && value.Length < 50)
                    name = value;
                OnPropertyChanged("Name");

            }
        }
        public string Category
        {
            get { return category; }
            set
            {
                category = value;
                OnPropertyChanged("Category");
            }
        }
        public string About
        {
            get { return about; }
            set
            {
                if (value.Length >= 0 && value.Length < 1000)
                    about = value;
                OnPropertyChanged("About");

            }
        }
        public string Cost
        {
            get { return cost.ToString(); }
            set
            {
                if (Decimal.TryParse(value.ToString(), out cost))
                    cost = Decimal.Parse(value);
                else
                    cost = 0;
                OnPropertyChanged("Cost");
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

        public List<string> Categories
        {
            get { return tmpCategories; }
        }

        void update()
        {
            if (Item is Announcement)
            {
                Name = (Item as Announcement).name;
                Cost = (Item as Announcement).cost.ToString();
                About = (Item as Announcement).about;
                Category = (Item as Announcement).category;
                MessageBox.Show((Item as Announcement).about);
            }
            else if (Item is TmpAnnouncement)
            {
                Name = (Item as TmpAnnouncement).name;
                Cost = (Item as TmpAnnouncement).cost.ToString();
                About = (Item as TmpAnnouncement).about;
                Category = (Item as TmpAnnouncement).category;
            }
            else
            {
                Name = "default";
                Cost = "0";
                About = "default";
                Category = "default";
            }

        }

        public EditWindowViewModel()
        {
            tmpCategories = announcementRepository.getCategories().Distinct().ToList();
        }

        public bool addAnnouncement()
        {
            if (Name != null && About != null && Name.Length >= 5 && About.Length >= 10 && !String.IsNullOrEmpty(Category))
            {
                if (Item is TmpAnnouncement)
                {
                    TmpAnnouncement tmp = new TmpAnnouncement(Name, CurrentUser.User.id, Category, About, cost);
                    tmpAnnouncementRepository.add(tmp);
                    
                    tmpAnnouncementRepository.delete(Item as TmpAnnouncement);
                    Item = tmp;
                    return true;

                }
                else if (Item is Announcement)
                {
                    TmpAnnouncement tmp = new TmpAnnouncement(Name, CurrentUser.User.id, Category, About, cost);
                    tmpAnnouncementRepository.add(tmp);
                    
                    announcementRepository.delete(Item as Announcement);
                    Item = tmp;
                    return true;
                    
                }
                else
                {
                    Info = "Ошибочка";
                    return false;
                }
                    
            }
            else
            {
                Info = "Ошибочка";                
                return false;
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
