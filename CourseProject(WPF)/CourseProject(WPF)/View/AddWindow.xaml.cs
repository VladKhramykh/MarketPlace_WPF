﻿using CourseProject_WPF_.ViewModel;
using System.Windows;
using System.Windows.Media;

namespace CourseProject_WPF_.View
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        AddWindowViewModel addWindowViewModel = new AddWindowViewModel();

        public AddWindow()
        {
            InitializeComponent();
            DataContext = addWindowViewModel;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (addWindowViewModel.addAnnouncement())
            {
                addButton.Background = Brushes.LimeGreen;
                addButton.Content = "Добавлено!";
                Close();
                AlertWindow alertWindow = new AlertWindow("Ваше объявление отправлено на проверку.\nВ скором времени оно будет проверено и выставлено в актуальные объявления");
                alertWindow.ShowDialog();
            }
            else
            {
                addButton.Background = Brushes.PaleVioletRed;
                addButton.Content = "Ошибка!";
            }
                

        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            addWindowViewModel.clear();
            addButton.Background = Brushes.Purple;
            addButton.Content = "Добавить";
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
