using CourseProject_WPF_.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
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

        public Vk(string login, string password, string code)
        {
            auth(login, password, code);
        }

        public void auth(string login, string password, string code)
        {
            vkApi.Authorize(new ApiAuthParams
            {
                ApplicationId = AppId,
                Login = login,
                Password = password,
                Settings = Settings.All,
                TwoFactorAuthorization = () =>
                {
                    //Enter enter = new Enter();
                    //enter.ShowDialog();
                    //return enter.getCode();
                    return code;
                }

            });
        }

        public User getUser()
        {
            var p = vkApi.Users.Get(
                new long[] { vkApi.UserId.Value },
                ProfileFields.Contacts | ProfileFields.Country |
                ProfileFields.City | ProfileFields.About |
                ProfileFields.Photo200Orig).FirstOrDefault();   
            
            return p;
        }

        public BitmapImage getImage()
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = getUser().Photo200Orig;
            bitmapImage.EndInit();
            return bitmapImage;
        }
    }
}
