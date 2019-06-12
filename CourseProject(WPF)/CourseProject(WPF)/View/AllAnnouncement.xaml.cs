using CourseProject_WPF_.Repositories;
using CourseProject_WPF_.Model;
using System.Collections.ObjectModel;
using CourseProject_WPF_.ViewModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System;

namespace CourseProject_WPF_.View
{
    public partial class AllAnnouncement : Page
    {
        User User = CurrentUser.User;
        public AllAnnouncementViewModel viewModel;

        public AllAnnouncement()
        {            
            InitializeComponent();
            viewModel = new AllAnnouncementViewModel();
            DataContext = viewModel;
        }
        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.showInfo();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.search();
        }

        private void sortButton_Click(object sender, RoutedEventArgs e)
        {
            if(down.Visibility == Visibility.Visible)
            {
                viewModel.sort();
                down.Visibility = Visibility.Hidden;
                up.Visibility = Visibility.Visible;
            }
            else
            {
                viewModel.sort();
                up.Visibility = Visibility.Hidden;
                down.Visibility = Visibility.Visible;
            }
                
            
        }
    }
}
