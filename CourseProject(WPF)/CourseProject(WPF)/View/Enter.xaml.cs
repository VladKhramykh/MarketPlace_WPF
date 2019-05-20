using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CourseProject_WPF_.View
{
    /// <summary>
    /// Логика взаимодействия для Enter.xaml
    /// </summary>
    public partial class Enter : Window
    {
        string str;
        public Enter()
        {
            InitializeComponent();
        }

        public string getCode()
        {
            return str;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            str = code.Text;
            Hide();
        }
    }
}
