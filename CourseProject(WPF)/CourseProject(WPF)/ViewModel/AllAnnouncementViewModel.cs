using CourseProject_WPF_.Repositories;
using CourseProject_WPF_.Model;
using CourseProject_WPF_.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace CourseProject_WPF_.ViewModel
{
    public class AllAnnouncementViewModel : INotifyPropertyChanged
    {
        EFUserRepository userRepository = new EFUserRepository();
        EFAnnouncementRepository announcementRepository = new EFAnnouncementRepository();
        EFTmpAnnouncementRepository tmpAnnouncementRepository = new EFTmpAnnouncementRepository();

        ObservableCollection<Announcement> tmpAnnouncements = new ObservableCollection<Announcement>();
        List<string> tmpCategories = new List<string>();
        List<string> tmpSellers = new List<string>();
        Announcement selectedItem;

        string seller = "";
        string category = "";
        string info = "";        
        string searchText = "";
        decimal minCost;
        decimal maxCost;
        decimal MAX_COST;
        string count;
        string sellerInfo;

        public ObservableCollection<Announcement> Announcements
        {
            get { return tmpAnnouncements; }
            set { tmpAnnouncements = value; }
        }
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnPropertyChanged("SearchText");
            }
        }
        public Announcement SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                if (value != null)                
                    Count = (Announcements.IndexOf(SelectedItem)+1).ToString();
                                                  
                OnPropertyChanged("SelectedItem");   
            }
        }

        public List<string> Categories
        {
            get { return tmpCategories; }
        }

        public List<string> Sellers
        {
            get { return tmpSellers; }
        }

        public string Seller
        {
            get { return seller; }
            set
            {
                seller = value;
                OnPropertyChanged("Seller");
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
        public string Info
        {
            get { return info; }
            set
            {
                info = $"Найдено {Announcements.Count} объявлений";
                OnPropertyChanged("Info");
            }
        }
        public string MinCost
        {
            get { return minCost.ToString(); }
            set
            {
                if (Decimal.TryParse(value.ToString(), out minCost) && Decimal.Parse(value) >= 0)              
                    minCost = Decimal.Parse(value);                                
                else
                    minCost = 0;
                OnPropertyChanged("MinCost");                    
            }
        }
        public string MaxCost
        {
            get { return maxCost.ToString(); }
            set
            {
                if (Decimal.TryParse(value.ToString(), out maxCost) && Decimal.Parse(value) >=0)
                    maxCost = Decimal.Parse(value);
                else
                    maxCost = MAX_COST;
                OnPropertyChanged("MaxCost");
            }
        }

        public string Count
        {
            get { return $"{count} -е  из {Announcements.Count} объявлений"; }
            set
            {
                count = value;
                OnPropertyChanged("Count");
            }
        }

        public string SellerInfo
        {
            get { return sellerInfo; }
            set
            {
                sellerInfo = value;
                OnPropertyChanged("SellerInfo");
            }
        }

        ViewWindow viewWindow;
        public AllAnnouncementViewModel()
        {            
            var announcements = getAnnouncements().ToList();
            Announcements.Clear();
            foreach (Announcement a in announcements)
                Announcements.Add(a);

            tmpCategories = announcementRepository.getCategories().Distinct().ToList();
            tmpSellers = userRepository.getAllNames().Distinct().ToList();
            Info = $"Найдено {Announcements.Count}";
            MAX_COST = announcementRepository.MaxCost();
            MaxCost = MAX_COST.ToString();

            viewWindow = new ViewWindow(this);
            viewWindow.Visibility = System.Windows.Visibility.Hidden;
            
        }
        
        public void attachedAnnouncement()
        {
            QuickViewWindow quickViewWindow = new QuickViewWindow(SelectedItem);
            quickViewWindow.Show();
        }

        public void showInfo()
        {
            SellerInfo = userRepository.getById(SelectedItem.seller).Info;
            viewWindow.DataContext = SelectedItem;
            if(viewWindow.Visibility == System.Windows.Visibility.Hidden && SelectedItem != null)
                viewWindow.Show();
        }

        public void search()
        {            
            tmpAnnouncements.Clear();
            Regex regex = new Regex(@"(\w*)(?i)" + SearchText + @"(\w*)");            

            if (!String.IsNullOrEmpty(Seller) && !String.IsNullOrEmpty(Category))
            {
                int id = userRepository.getByName(Seller).id;
                IEnumerable<Announcement> tmp = announcementRepository.getByCategory(Category);

                if (id != 0 && tmp.Count() != 0)
                {
                    Announcements.Clear();

                    foreach (Announcement announcement in tmp.Where(x => x.seller == id))
                    {                        
                        if (regex.IsMatch(announcement.about) || regex.IsMatch(announcement.name))
                        {
                            if (maxCost == 0)
                            {
                                if (announcement.cost <= maxCost && announcement.cost >= MAX_COST)
                                    Announcements.Add(announcement);
                            }
                            else
                            {
                                if (announcement.cost <= maxCost && announcement.cost >= minCost)
                                    Announcements.Add(announcement);
                            }
                        }
                    }                        
                }
                else
                    Announcements.Clear();

            }
            else if (!String.IsNullOrEmpty(Seller) && String.IsNullOrEmpty(Category))
            {
                int id = userRepository.getByName(Seller).id;

                if (id != 0)
                {
                    Announcements.Clear();
                    foreach (Announcement announcement in getAnnouncementsBySellerId(id))
                    {                        
                        if (regex.IsMatch(announcement.about) || regex.IsMatch(announcement.name))
                        {
                            if (maxCost == 0)
                            {
                                if (announcement.cost <= maxCost && announcement.cost >= MAX_COST)
                                    Announcements.Add(announcement);
                            }
                            else
                            {
                                if (announcement.cost <= maxCost && announcement.cost >= minCost)
                                    Announcements.Add(announcement);
                            }
                        }
                    }                        
                }
                else
                    Announcements.Clear();

            }
            else if (String.IsNullOrEmpty(Seller) && !String.IsNullOrEmpty(Category))
            {
                IEnumerable<Announcement> tmp = announcementRepository.getByCategory(Category);

                if (tmp.Count() != 0)
                {
                    Announcements.Clear();
                    foreach (Announcement announcement in tmp)
                    {                        
                        if (regex.IsMatch(announcement.about) || regex.IsMatch(announcement.name))
                        {
                            if (maxCost == 0)
                            {
                                if (announcement.cost <= maxCost && announcement.cost >= MAX_COST)
                                    Announcements.Add(announcement);
                            }
                            else
                            {
                                if (announcement.cost <= maxCost && announcement.cost >= minCost)
                                    Announcements.Add(announcement);
                            }
                        }
                            
                    }                        
                }
                else
                    Announcements.Clear();
            }
            else
            {
                Announcements.Clear();
                foreach (Announcement announcement in getAnnouncements())
                {                       
                    if(regex.IsMatch(announcement.about) || regex.IsMatch(announcement.name))
                    {
                        if(maxCost == 0)
                        {
                            if(announcement.cost <= maxCost && announcement.cost >= MAX_COST)
                                Announcements.Add(announcement);
                        }
                        else
                        {
                            if (announcement.cost <= maxCost && announcement.cost >= minCost)
                                Announcements.Add(announcement);
                        }  
                    }                      
                } 
            }
            Info = $"Найдено {Announcements.Count}";
        }

        public IEnumerable<Announcement> getAnnouncements()
        {
            return announcementRepository.getAll();
        }

        public void deleteAnnouncement(Announcement tmp)
        {
            announcementRepository.delete(tmp);
        }

        public IEnumerable<Announcement> getAnnouncementsBySellerId(int sellerID)
        {
            if (sellerID != 0)
                return announcementRepository.getBySellerId(sellerID);
            else
                return null;
        }

        public void addAnnouncement(Announcement announcement)
        {
            announcementRepository.add(announcement);
        }

        public void nextItem()
        {
            if(Announcements.IndexOf(SelectedItem) < Announcements.Count-1)
                SelectedItem = Announcements.ElementAt(Announcements.IndexOf(SelectedItem) + 1);
        }

        public void previousItem()
        {
            if (Announcements.IndexOf(SelectedItem) > 0)
                SelectedItem = Announcements.ElementAt(Announcements.IndexOf(SelectedItem) - 1);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
