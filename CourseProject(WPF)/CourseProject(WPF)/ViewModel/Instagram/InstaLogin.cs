
using CourseProject_WPF_.Model;
using CourseProject_WPF_.View;
using InstagramApiSharp.API;
using InstagramApiSharp.API.Builder;
using InstagramApiSharp.Classes;
using InstagramApiSharp.Classes.Models;
using InstagramApiSharp.Logger;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows;

namespace CourseProject_WPF_.ViewModel.Instagram
{
    public class InstaLogin
    {
        string username;
        string password;

        static UserSessionData user;
        static IInstaApi api;

        User tmp;

        public InstaLogin(string username, string password)
        {
            this.username = username;
            this.password = password;
            auth();
        }
        void auth()
        {
            user = new UserSessionData();
            user.UserName = username;
            user.Password = password;
        }
        async Task Login()
        {
            api = InstaApiBuilder.CreateBuilder()
                .SetUser(user)
                .UseLogger(new DebugLogger(LogLevel.Exceptions))
                .Build();

            var loginRequest = await api.LoginAsync();
            if (loginRequest.Succeeded)
            {
                IResult<InstaCurrentUser> result = await api.GetCurrentUserAsync();

                var names = result.Value.FullName.Split(' ');
                string firstname = names[0];
                string secondName = secondName = names[1];
                string mail = result.Value.Email;
                string telNumber = result.Value.PhoneNumber;
                byte[] image;
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(new Uri(result.Value.HdProfilePicture.Uri), User.filename);                    
                }
                using (System.IO.FileStream fs = new System.IO.FileStream(User.filename, System.IO.FileMode.OpenOrCreate))
                {
                    image = new byte[fs.Length];
                    fs.Read(image, 0, image.Length);
                }

                string about = result.Value.FullName + "\n" + result.Value.Gender + "\n" + result.Value.UserName + "\n" + result.Value.CountryCode;
                tmp = new User(firstname, secondName, mail, telNumber, about, image);
            }
        }
        public async Task<User> Get()
        {
            await Login();
            return await Task.Run(() => GetUser());
        }
        public User GetUser()
        {
            return tmp;
        }
    }        
}

    

