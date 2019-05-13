using CourseProject_WPF_.ViewModel;
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
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        EditWindowViewModel editWindowViewModel = new EditWindowViewModel();
        

        public EditWindow(object Item)
        {
            InitializeComponent();
            editWindowViewModel.Item = Item;
            DataContext = editWindowViewModel;
            Title = "Редактирование";
        }

        void acceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (editWindowViewModel.addAnnouncement())
            {
                Close();
                AlertWindow alertWindow = new AlertWindow("Ваше объявление отправлено на проверку.\nВ скором времени оно будет проверено и выставлено в актуальные объявления");
                alertWindow.ShowDialog();
            }            
        }

        void returnButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
                
        void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
