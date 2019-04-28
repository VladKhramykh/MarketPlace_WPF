using CourseProject_WPF_.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CourseProject_WPF_
{
    public class CurrentUser
    {
        private static User user;

        public static User User
        {
            get { return user; }
            set
            {
                if (value != null)
                    user = value;
                else
                    MessageBox.Show("Ошибка входа!");
            }
        }

        
    }
}
