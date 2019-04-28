using CourseProject_WPF_.DataBase;
using CourseProject_WPF_.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace CourseProject_WPF_.ViewModel
{
    public class AnnouncementViewModel
    { 
        EFUserRepository eFUser = new EFUserRepository();
        EFAnnouncementRepository eFAnnouncement = new EFAnnouncementRepository();
        EFTmpAnnouncementRepository eFTmpAnnouncement = new EFTmpAnnouncementRepository();

        ObservableCollection<Announcement> tmpAnnouncement = new ObservableCollection<Announcement>();
        List<string> tmpCategories = new List<string>();
        List<string> tmpSellers = new List<string>();

        string seller="";
        string category="";

        public ObservableCollection<Announcement> Announcements
        {
            get { return tmpAnnouncement; }
            set { tmpAnnouncement = value; }
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
            set  { seller = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public AnnouncementViewModel()
        {
            
            var announcements = getAnnouncements().ToList();
            Announcements.Clear();
            foreach (Announcement a in announcements)
                tmpAnnouncement.Add(a);

            tmpCategories = eFAnnouncement.getCategories().Distinct().ToList();
            tmpSellers = eFUser.getAllNames().Distinct().ToList();
            
        }

        public void search()
        {
            if (!String.IsNullOrEmpty(Seller) && !String.IsNullOrEmpty(Category))
            {
                int id = eFUser.getByMail(Seller).id;
                IEnumerable<Announcement> tmp = eFAnnouncement.getByCategory(Category);

                if (id != 0 && tmp.Count() != 0)
                {
                    tmpAnnouncement.Clear();
                    foreach (Announcement announcement in tmp.Where(x=>x.seller == id))
                        tmpAnnouncement.Add(announcement);
                }                
                else
                    tmpAnnouncement.Clear();
                    
            }
            else if(!String.IsNullOrEmpty(Seller) && String.IsNullOrEmpty(Category))
            {
                int id = eFUser.getByMail(Seller).id;

                if (id != 0)
                {
                    tmpAnnouncement.Clear();
                    foreach (Announcement announcement in getAnnouncementsBySellerId(id))
                        tmpAnnouncement.Add(announcement);
                }
                else
                    tmpAnnouncement.Clear();
            
            }
            else if(String.IsNullOrEmpty(Seller) && !String.IsNullOrEmpty(Category))
            {
                IEnumerable<Announcement> tmp = eFAnnouncement.getByCategory(Category);

                if (tmp.Count() != 0)
                {
                    tmpAnnouncement.Clear();
                    foreach (Announcement announcement in tmp)
                        tmpAnnouncement.Add(announcement);
                }
                else
                    tmpAnnouncement.Clear();
            }
            else
            {
                tmpAnnouncement.Clear();
                foreach (Announcement announcement in getAnnouncements())
                    tmpAnnouncement.Add(announcement);
            }
        }

        public IEnumerable<Announcement> getAnnouncements()
        {
            return eFAnnouncement.getAll();
        }

        public void deleteAnnouncement(Announcement tmp)
        {
            eFAnnouncement.delete(tmp);
        }

        public IEnumerable<Announcement> getAnnouncementsBySellerId(int sellerID)
        {
            if (sellerID != 0)
                return eFAnnouncement.getBySellerId(sellerID);
            else
                return null;
        }

        public void addAnnouncement(Announcement announcement)
        {
            eFAnnouncement.add(announcement);
        }

        

    }
}
