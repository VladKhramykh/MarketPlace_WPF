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
        EFRegionRepository regionRepository = new EFRegionRepository();

        string name;
        string category;
        string region;
        string about;
        decimal cost;
        string info;       

        string statusName;
        string statusRegion;
        string statusCategory;
        string statusCost;
        string statusAbout;

        List<string> tmpCategories = new List<string>();
        List<string> tmpRegions = new List<string>();
        
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
                if (value.Length >= 5 && value.Length < 50)
                {
                    name = value;                    
                        statusName = "";
                }
                else
                    statusName = "Название слишком коротокое";

                OnPropertyChanged("Name");
            }
        }
        public string Category
        {
            get { return category; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    category = value;                   
                        statusCategory = "";
                }
                else
                    statusCategory = "Првоерьте категорию";
                OnPropertyChanged("Category");
            }
        }
        public string Region
        {
            get { return region; }
            set { region = value; }
        }
        public string About
        {
            get { return about; }
            set
            {
                if (value.Length >= 10 && value.Length < 1000)
                {
                    about = value;                    
                        statusAbout = "";
                }
                else
                    statusAbout = "Описание слишком короткое";

                OnPropertyChanged("About");

            }
        }

        public string Cost
        {
            get { return cost.ToString(); }
            set
            {
                if (Decimal.TryParse(value.ToString(), out cost) && Decimal.Parse(value) >= 0)
                {
                    if (Decimal.Parse(value) > Decimal.MaxValue)
                        cost = Decimal.MaxValue;
                    else
                        cost = Decimal.Parse(value);

                    statusCost = "";
                }
                else
                {
                    statusCost = "Некорректно задана цена)";
                    cost = 0;
                }
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
        public List<string> Regions
        {
            get { return tmpRegions; }
        }

        void update()
        {
            if (Item is Announcement)
            {
                Name = (Item as Announcement).name;
                Cost = (Item as Announcement).cost.ToString();
                About = (Item as Announcement).about;
                Category = (Item as Announcement).category;
                Region = regionRepository.getRegion((Item as Announcement).idRegion.Value);
                
            }
            else if (Item is TmpAnnouncement)
            {
                Name = (Item as TmpAnnouncement).name;
                Cost = (Item as TmpAnnouncement).cost.ToString();
                About = (Item as TmpAnnouncement).about;
                Category = (Item as TmpAnnouncement).category;
                Region = regionRepository.getRegion((Item as TmpAnnouncement).idRegion.Value);
            }
            else
            {
                Name = "Error";
                Cost = "0";
                About = "Error";
                Category = "Error";
            }

        }

        bool IsCorrected()
        {
            if (!String.IsNullOrEmpty(statusName))
            {
                Info = statusName;
                return false;
            }                
            else if (!String.IsNullOrEmpty(statusCost))
            {
                Info = statusCost;
                return false;
            }
            else if (!String.IsNullOrEmpty(statusCategory))
            {
                Info = statusCategory;
                return false;
            }
            else if (!String.IsNullOrEmpty(statusAbout))
            {
                Info = statusAbout;
                return false;
            }
            else
                return true;
        }
        public EditWindowViewModel()
        {
            tmpCategories = announcementRepository.getCategories().Distinct().ToList();
            tmpRegions = regionRepository.getRegions();
        }

        public bool addAnnouncement()
        {
            if (IsCorrected())
            {
                if (Item is TmpAnnouncement)
                {
                    TmpAnnouncement tmp = new TmpAnnouncement(Name, CurrentUser.User.id, Regions.IndexOf(Region), Category, About, cost);
                    tmpAnnouncementRepository.add(tmp);
                    
                    tmpAnnouncementRepository.delete(Item as TmpAnnouncement);
                    Item = tmp;
                    return true;

                }
                else if (Item is Announcement)
                {
                    TmpAnnouncement tmp = new TmpAnnouncement(Name, CurrentUser.User.id, Regions.IndexOf(Region), Category, About, cost);
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
                return false;
              
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
