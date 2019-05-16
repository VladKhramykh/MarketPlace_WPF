using CourseProject_WPF_.Repositories;
using CourseProject_WPF_.Model;
using CourseProject_WPF_.View;
using System;
using System.ComponentModel;

namespace CourseProject_WPF_.ViewModel
{
    public class AuthWindowViewModel:INotifyPropertyChanged
    {
        EFUserRepository eFUserRepository = new EFUserRepository();
        string password;
        string login;
        string info;

        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
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

        public bool compareDataOfUser(string password)
        {           
            if (!String.IsNullOrEmpty(Login) && !String.IsNullOrEmpty(password))
            { 
                User tmp = eFUserRepository.getByMail(Login);
                if (tmp != null)
                {
                    if (User.getHash(password).Equals(tmp.password))
                    {
                        CurrentUser.User = tmp;                        
                        App.mainWindow = new MainWindow();
                        App.mainWindow.Show();
                        return true;
                    }
                    else
                    {
                        Info = "Проверьте введённые данные";
                        return false;
                    }
                    
                }
                else
                {
                    Info = "Проверьте введённые данные";
                    return false;
                }
            }
            else
            {
                Info = "Не всё ввели";
                return false;
            }        
        }

        public void VkLogin()
        {
            VKLoginWindow vKLogin = new VKLoginWindow();
            vKLogin.ShowDialog();
            
        }

        public void InstaLogin()
        {
            InstagramWindow instagramWindow = new InstagramWindow();
            instagramWindow.ShowDialog();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
