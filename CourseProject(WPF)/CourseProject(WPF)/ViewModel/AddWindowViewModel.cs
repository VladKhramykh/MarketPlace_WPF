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

        string name;
        string category;
        string about;
        decimal cost;

        List<string> tmpCategories = new List<string>();

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

        public List<string> Categories
        {
            get { return tmpCategories; }
        }        

        public AddWindowViewModel()
        {
            tmpCategories = announcementRepository.getCategories().Distinct().ToList();
        }        

        public bool addAnnouncement()
        {
            if(Name != null && About != null && Name.Length >= 5 && About.Length >= 10 && !String.IsNullOrEmpty(Category))
            {
                tmpAnnouncementRepository.add(new TmpAnnouncement(Name, CurrentUser.User.id, Category, About, cost));
                return true;
            }
            return false;                
        }

        public void clear()
        {
            Name = "";
            cost = 0;
            About = "";
            Category = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}