using System;
using System.Windows;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;

namespace CourseProject_WPF_.VkNet
{
    public class VKApiNet
    {
        VkApi vkApi = new VkApi();

        const ulong ApplicationId = 6982484;

        public VKApiNet(string login, string password)
        {
            var api = new VkApi();

            api.Authorize(new ApiAuthParams
            {                
                Login = login,
                Password = password,
                ApplicationId = ApplicationId,
                Settings = Settings.All,
                TwoFactorAuthorization = () =>
                {
                    Console.WriteLine("Введите код:");

                    return Console.ReadLine();
                }
            });
            //autorize(login,password);
        }

        //public string getFirstName()=>vkApi.Messages.

        void autorize(string login, string password)
        {
            
        }

        public void alert()
        {
            MessageBox.Show(vkApi.UserId.Value.ToString());
        }
    }
}
