﻿using CourseProject_WPF_.Model;
using CourseProject_WPF_.View;
using System.ComponentModel;

namespace CourseProject_WPF_.ViewModel
{
    public class MainWindowViewModel: INotifyPropertyChanged
    {

        int selectedIndex;
        object content;
        string userName;
        string firstSymbols;
        
        public User user
        {
            get { return CurrentUser.User; }
            set { user = value; }
        }

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                setPage(selectedIndex);
                OnPropertyChanged("SelectedIndex");
            }
        }
        public object Content
        {
            get { return content; }
            set
            {
                content = value;
                OnPropertyChanged("Content");
            }
        }

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = CurrentUser.User.firstName + " " + CurrentUser.User.secondName;
                OnPropertyChanged("UserName");
            }
        }
        
        public string FirstSymbols
        {
            get { return firstSymbols; }
            set
            {
                firstSymbols = CurrentUser.User.firstName.Substring(0, 1) + CurrentUser.User.secondName.Substring(0, 1);
                OnPropertyChanged("FirstSymbols");
            }
        }

        public MainWindowViewModel()
        {
            Content = new AllAnnouncement(); 
            UserName = CurrentUser.User.firstName + " " + CurrentUser.User.secondName;
            FirstSymbols = CurrentUser.User.firstName.Substring(0, 1) + CurrentUser.User.secondName.Substring(0, 1);
        }

        public void setPage(int index)
        {
            switch (index)
            {
                case 0:
                    Content = new AllAnnouncement();
                    break;
                case 1:
                    Content = new MyAnnouncementPage();                    
                    break;
                case 2:
                    Content = new PersonAreaPage();
                    break;
                case 3:
                    {
                        if (CurrentUser.isAdmin())
                            Content = new AdminPage();
                        else
                        {
                            AlertWindow alertWindow = new AlertWindow("У вас нет прав зайти в это меню");
                            alertWindow.ShowDialog();
                        }

                        break;
                        
                    }
                default:
                    Content = new AllAnnouncement();
                    break;
                    
            }
            
        }

        public void update()
        {
            FirstSymbols = CurrentUser.User.firstName.Substring(0, 1) + CurrentUser.User.secondName.Substring(0, 1);
            UserName = CurrentUser.User.firstName + " " + CurrentUser.User.secondName;
        }

        public void outFromMain()
        {
            CurrentUser.User = null;
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
