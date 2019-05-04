using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProject_WPF_.Model;
using CourseProject_WPF_.Repositories;

namespace CourseProject_WPF_.ViewModel
{
    public class RegistrationViewModel:INotifyPropertyChanged
    {
        EFUserRepository userRepository = new EFUserRepository();

        string firstName;
        string secondName;
        string mail;
        string password1;
        string password2;
        string info;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string SecondName
        {
            get { return secondName; }
            set
            {
                secondName = value;
                OnPropertyChanged("SecondName");
            }
        }
        public string Mail
        {
            get { return mail; }
            set {
                mail = value;
                OnPropertyChanged("Mail");
            }
        }
        public string Password1
        {
            get { return password1; }
            set
            {
                password1 = value;
                OnPropertyChanged("Password1");
            }
        }
        public string Password2
        {
            get { return password2; }
            set
            {
                password2 = value;
                OnPropertyChanged("Password2");
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

        public bool registration(string password1, string password2)
        {
            Password1 = password1;
            Password2 = password2;
            if (!String.IsNullOrEmpty(FirstName) && !String.IsNullOrEmpty(SecondName) && !String.IsNullOrEmpty(Mail) && !String.IsNullOrEmpty(Password1) && !String.IsNullOrEmpty(Password2))
            {
                if (Password1.Equals(Password2))
                {
                    User tmp = userRepository.getByMail(Mail);
                    if(tmp == null)
                    {
                        userRepository.add(new User(FirstName, SecondName, Mail, Password1));
                        Info = "Зареган!";
                        return true;
                    }
                    else
                    {
                        Info = "Пользователь с таким Mail уже есть";
                        return false;
                    }
                    
                }
                else
                {                    
                    Info = "Пароли должны совпадать";
                    return false;
                }

            }
            else
            {
                Info = "Проверьте данные!";
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

