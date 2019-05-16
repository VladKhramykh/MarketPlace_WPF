using System;
using System.ComponentModel;
using CourseProject_WPF_.Model;
using CourseProject_WPF_.View;
using CourseProject_WPF_.Repositories;

namespace CourseProject_WPF_.ViewModel
{
    public class VkLoginViewModel : INotifyPropertyChanged
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

        public bool auth(string password)
        {
            try
            {
                Vk vk = new Vk(Login, password);
                VkNet.Model.User user = vk.getUser();                

                string firstName = "";
                string lastName = "";
                string telNumber = "";
                string about = "";

                if (userRepository.getByMail(Login) != null)
                {
                    firstName = user.FirstName;
                    lastName = user.LastName;
                    telNumber = user.MobilePhone; ;
                    about = $"Страна: {user.Country.Title}\n" + $"Город: {user.City.Title}";
                    CurrentUser.User = userRepository.getByMail(Login);
                    User tmp = new User(firstName, lastName, Login, telNumber, about, CurrentUser.User.Privilege);
                    userRepository.update(CurrentUser.User, tmp);
                    CurrentUser.User = userRepository.getByMail(Login);
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    return true;
                }
                else
                {
                    firstName = user.FirstName;
                    lastName = user.LastName;
                    telNumber = "";                    
                    about = $"Страна: {user.Country.Title}\n"+ $"Город: {user.City.Title}";
                    userRepository.add(new Model.User(firstName, lastName, Login, telNumber, about));
                    CurrentUser.User = userRepository.getByMail(Login);
                    App.authWindow.Close();
                    App.mainWindow = new MainWindow();
                    App.mainWindow.Show();
                    return true;
                    
                }
            }
            catch (VkNet.Exception.VkApiException)
            {
                Status = "Неверно указан логин или пароль";
            }
            catch (Exception)
            {
                Status = "Ошибка";
            }
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
