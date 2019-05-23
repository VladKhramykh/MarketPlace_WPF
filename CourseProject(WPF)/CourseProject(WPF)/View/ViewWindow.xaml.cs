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
    public partial class ViewWindow : Window
    {
        AllAnnouncementViewModel mainViewModel;

        public ViewWindow(AllAnnouncementViewModel viewModel)
        {
            InitializeComponent();
            mainViewModel = viewModel;
            DataContext = mainViewModel.SelectedItem;
            counter.DataContext = mainViewModel;
            Seller.DataContext = mainViewModel;
            Region.DataContext = mainViewModel;
            Title = "Окно просмотра";
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void previousButton_Click(object sender, RoutedEventArgs e)
        {
            mainViewModel.previousItem();
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            mainViewModel.nextItem();
        }       

        private void AttachedButton_Click(object sender, RoutedEventArgs e)
        {
            mainViewModel.attachedAnnouncement();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
