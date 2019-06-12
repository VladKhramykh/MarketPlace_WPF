using System;
using System.ComponentModel;
using CourseProject_WPF_.Model;
using CourseProject_WPF_.View;
using CourseProject_WPF_.Repositories;
using System.Net;
using System.Windows;

namespace CourseProject_WPF_.ViewModel
{
    public class VkLoginViewModel : INotifyPropertyChanged
    {        
        EFUserRepository userRepository = new EFUserRepository();

        string login;                
        string status;
        string code;

        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }
        public string Code
        {
            get { return code; }
            set
            {
                code = value;
                OnPropertyChanged("Code");
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
                Status = "Подождите нексолько секунд";
                Vk vk = new Vk(Login, password, Code);
                VkNet.Model.User user = vk.getUser();                

                string firstName = "";
                string lastName = "";
                string telNumber = "";
                string about = "";
                byte[] image;
                string i="";

                if (userRepository.getByMail(Login) != null)
                {
                    firstName = user.FirstName;
                    lastName = user.LastName;
                    telNumber = user.MobilePhone; ;
                    about = $"Страна: {user.Country.Title}\n" + $"Город: {user.City.Title}";

                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(new Uri(user.Photo200Orig.AbsoluteUri), User.filename);
                    }
                    using (System.IO.FileStream fs = new System.IO.FileStream(User.filename, System.IO.FileMode.OpenOrCreate))
                    {
                        image = new byte[fs.Length];
                        fs.Read(image, 0, image.Length);
                    }
                    CurrentUser.User = userRepository.getByMail(Login);
                    User tmp = new User(firstName, lastName, Login, telNumber, telNumber, about, image, CurrentUser.User.Privilege);
                    userRepository.update(CurrentUser.User, tmp);

                    App.authWindow.Close();
                    App.mainWindow = new MainWindow();
                    App.mainWindow.Show();
                    image = null;
                    return true;
                }
                else
                {
                    firstName = user.FirstName;
                    lastName = user.LastName;
                    telNumber = "";                    
                    about = $"Страна: {user.Country.Title}\n"+ $"Город: {user.City.Title}";
                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(new Uri(user.Photo200Orig.AbsoluteUri), User.filename);
                    }
                    using (System.IO.FileStream fs = new System.IO.FileStream(User.filename, System.IO.FileMode.Open))
                    {
                        image = new byte[fs.Length];
                        fs.Read(image, 0, image.Length);
                    }

                    userRepository.add(new Model.User(firstName, lastName, Login, telNumber,about,image));
                    CurrentUser.User = userRepository.getByMail(Login);

                    App.authWindow.Close();
                    App.mainWindow = new MainWindow();
                    App.mainWindow.Show();
                    image = null;
                    return true;
                    
                }

            }
            catch (VkNet.Exception.UserAuthorizationFailException)
            {
                Status = "Введите код подверждения и повторите вход";
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
