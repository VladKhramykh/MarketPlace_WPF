using CourseProject_WPF_.Repositories;
using CourseProject_WPF_.Model;
using CourseProject_WPF_.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Media.Imaging;
using System.IO;

namespace CourseProject_WPF_.ViewModel
{
    public class AllAnnouncementViewModel : INotifyPropertyChanged
    {
        EFUserRepository userRepository = new EFUserRepository();
        EFAnnouncementRepository announcementRepository = new EFAnnouncementRepository();
        EFTmpAnnouncementRepository tmpAnnouncementRepository = new EFTmpAnnouncementRepository();
        EFRegionRepository regionRepository = new EFRegionRepository();

        ObservableCollection<Announcement> tmpAnnouncements = new ObservableCollection<Announcement>();
        List<string> tmpCategories = new List<string>();
        List<string> tmpSellers = new List<string>();
        List<string> tmpRegions = new List<string>();
        
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
        string regionInfo;
        string region;
        int selectedIndex;

        bool flag = false;

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

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                if (value >= 0)
                    selectedIndex = value;
                OnPropertyChanged("SelectedIndex");
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

        public List<string> Regions
        {
            get { return tmpRegions; }
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
        public string Region
        {
            get { return region; }
            set
            {
                region = value;
                OnPropertyChanged("Region");
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
        public string RegionInfo
        {
            get { return regionInfo; }
            set
            {
                regionInfo = value;
                OnPropertyChanged("RegionInfo");
            }
        }

        ViewWindow viewWindow;
        public AllAnnouncementViewModel()
        {            
            var announcements = getAnnouncements().ToList();
            Announcements.Clear();
            foreach (Announcement a in announcements)
            {
                a.BitmapImage = LoadPhoto(a.seller.Value);
                Announcements.Add(a);
            }
                

            tmpCategories = announcementRepository.getCategories().Distinct().ToList();
            tmpSellers = userRepository.getAllNames().Distinct().ToList();
            tmpRegions = regionRepository.getRegions();
            SelectedIndex = 0;
            Info = $"Найдено {Announcements.Count}";
            MAX_COST = announcementRepository.MaxCost();
            MaxCost = MAX_COST.ToString();

            viewWindow = new ViewWindow(this);
            viewWindow.Visibility = System.Windows.Visibility.Hidden;
            
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

        public void attachedAnnouncement()
        {
            QuickViewWindow quickViewWindow = new QuickViewWindow(SelectedItem);
            quickViewWindow.Show();
        }

        public void showInfo()
        {
            if (SelectedItem != null)
            {
                SellerInfo = userRepository.getById(SelectedItem.seller).Info;
                RegionInfo = regionRepository.getRegion(SelectedItem.idRegion.Value);
                viewWindow.DataContext = SelectedItem;
                if (viewWindow.Visibility == System.Windows.Visibility.Hidden && SelectedItem != null)
                    viewWindow.Show();
            }
            
        }

        public void search()
        {
            selectedItem = null;
            Announcements.Clear();
            Regex regex = new Regex(@"(\w*)(?i)" + SearchText + @"(\w*)");
            int regionId = SelectedIndex;
            HashSet<Announcement> tmp1 = new HashSet<Announcement>();
            HashSet<Announcement> tmp2 = new HashSet<Announcement>();

            if (SelectedIndex != 0)
            {
                foreach (Announcement announcement in announcementRepository.getByRegionId(SelectedIndex))
                    tmp1.Add(announcement);
            }
            else
            {
                foreach (Announcement announcement in announcementRepository.getAll())
                    tmp1.Add(announcement);
            }
            if (!String.IsNullOrEmpty(Category))
            {
                foreach (Announcement announcement in tmp1.Where(x=> x.category.Equals(Category)))
                    tmp2.Add(announcement);
                tmp1.Clear();
            }
            else
            {
                foreach (Announcement announcement in tmp1)
                    tmp2.Add(announcement);
                tmp1.Clear();
            }
            if (!String.IsNullOrEmpty(Seller))
            {
                int id = userRepository.getByName(Seller).id;
                foreach (Announcement announcement in tmp2.Where(x=>x.seller == id))
                    tmp1.Add(announcement);
                tmp2.Clear();
            }
            else
            {
                foreach (Announcement announcement in tmp2)
                    tmp1.Add(announcement);
                tmp2.Clear();
            }
            if (!String.IsNullOrEmpty(SearchText))
            {
                foreach (Announcement announcement in tmp1)
                {
                    if (regex.IsMatch(announcement.about) || regex.IsMatch(announcement.name))
                    {
                        if (maxCost == 0)
                        {
                            if (announcement.cost <= maxCost && announcement.cost >= MAX_COST)
                                tmp2.Add(announcement);
                        }
                        else
                        {
                            if (announcement.cost <= maxCost && announcement.cost >= minCost)
                                tmp2.Add(announcement);
                        }
                    }                   
                }
            }
            else
            {
                foreach (Announcement announcement in tmp1)
                {
                    if (maxCost == 0)
                    {
                        if (announcement.cost <= maxCost && announcement.cost >= MAX_COST)
                            tmp2.Add(announcement);
                    }
                    else
                    {
                        if (announcement.cost <= maxCost && announcement.cost >= minCost)
                            tmp2.Add(announcement);
                    }
                }
            }

            foreach (Announcement announcement in tmp2)
                Announcements.Add(announcement);

            tmp1.Clear();
            tmp2.Clear();

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

        public void sort()
        {
            if (flag)
            {
                Announcements.Clear();
                foreach (Announcement ann in getAnnouncements().OrderBy(x => x.cost))
                    Announcements.Add(ann);
                flag = false;
            }
            else
            {
                Announcements.Clear();
                foreach (Announcement ann in getAnnouncements().OrderByDescending(x => x.cost))
                    Announcements.Add(ann);
                flag = true;
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
