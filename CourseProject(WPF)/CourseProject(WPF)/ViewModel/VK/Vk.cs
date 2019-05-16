using CourseProject_WPF_.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace CourseProject_WPF_
{
    public class Vk
    {
        VkApi vkApi = new VkApi();
        const ulong AppId = 4268118;

        public Vk(string login, string password)
        {
            auth(login, password);
        }

        public void auth(string login, string password)
        {
            vkApi.Authorize(new ApiAuthParams
            {
                ApplicationId = AppId,
                Login = login,
                Password = password,
                Settings = Settings.All
            });
        }

        public User getUser()
        {
            var p = vkApi.Users.Get(new long[] { vkApi.UserId.Value }, ProfileFields.Contacts | ProfileFields.Country | ProfileFields.City | ProfileFields.About).FirstOrDefault();   
            
            return p;
        }        
    }
}
