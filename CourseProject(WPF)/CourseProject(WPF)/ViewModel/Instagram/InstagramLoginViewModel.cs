using CourseProject_WPF_.Model;
using CourseProject_WPF_.Repositories;
using CourseProject_WPF_.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CourseProject_WPF_.ViewModel.Instagram
{
    public class InstagramLoginViewModel : INotifyPropertyChanged
    {
        EFUserRepository userRepository = new EFUserRepository();

        string login;
        string status;        

        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }

        public InstagramLoginViewModel()
        {            
        }

        public async Task<bool> auth(string password)
        {
            try
            {
                InstaLogin instaLogin = new InstaLogin(Login, password);
                Status = "Подождите несколько секунд";
                User user = await instaLogin.Get();

                if (user != null)
                {                  
                    if (userRepository.getByMail(user.mail) != null)
                    {              
                        userRepository.update(userRepository.getByMail(user.mail),user);
                        CurrentUser.User = userRepository.getByMail(user.mail);
                        App.authWindow.Close();
                        App.mainWindow = new MainWindow();
                        App.mainWindow.Show();
                    }
                    else
                    {
                        userRepository.add(user);
                        CurrentUser.User = userRepository.getByMail(user.mail);
                        App.authWindow.Close();
                        App.mainWindow = new MainWindow();
                        App.mainWindow.Show();
                    }
                    return true;
                }
                else
                {
                    throw new Exception();                    
                }
                    

            }
            catch (Exception)
            {
                Status = "Неверно указан логин или пароль";
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
