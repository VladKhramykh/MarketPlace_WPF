using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CourseProject_WPF_.Model;
using CourseProject_WPF_.Repositories;

namespace CourseProject_WPF_.ViewModel
{
    public class AddWindowViewModel :INotifyPropertyChanged
    {
        EFTmpAnnouncementRepository tmpAnnouncementRepository = new EFTmpAnnouncementRepository();
        EFAnnouncementRepository announcementRepository = new EFAnnouncementRepository();
        EFRegionRepository regionRepository = new EFRegionRepository();

        string name;
        string category;
        string about;
        string region;
        decimal cost;
        string info;

        string statusName = "Не заполнено название";
        string statusCategory = "Не заполнено категория";
        string statusCost = "Не заполнена цена";
        string statusAbout = "Не заполнено описание";

        List<string> tmpCategories = new List<string>();
        List<string> tmpRegions = new List<string>();

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
        public string Region
        {
            get { return region; }
            set { region = value; }
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

        public AddWindowViewModel()
        {
            tmpCategories = announcementRepository.getCategories().Distinct().ToList();
            tmpRegions = regionRepository.getRegions(); 
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

        public bool addAnnouncement()
        {
            if(IsCorrected())
            {
                tmpAnnouncementRepository.add(new TmpAnnouncement(Name, CurrentUser.User.id, Regions.IndexOf(Region),Category, About, cost));
                return true;
            }
            return false;                
        }

        public void clear()
        {
            name = "";
            cost = 0;
            about = "";
            category = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}