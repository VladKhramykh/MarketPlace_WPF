using CourseProject_WPF_.Model;
using CourseProject_WPF_.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CourseProject_WPF_.View
{
    public partial class MainWindow : Window
    {
        User User = CurrentUser.User;
        MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = mainWindowViewModel;
            Title = "Главное окно";
        }

        void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        void GridBarTitle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        void fullScreenButton_Click(object sender, RoutedEventArgs e)
        {
            this.MaxHeight = SystemParameters.WorkArea.Height+10;

            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else
                WindowState = WindowState.Maximized;
        }

        void minScreenButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }        

        void outButton_Click(object sender, RoutedEventArgs e)
        {            
            Close();
            mainWindowViewModel.outFromMain();            
        }

        private void menuList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MoveCursorMenu(mainWindowViewModel.SelectedIndex);
        }

        private void MoveCursorMenu(int index)
        {
            TransitionSlider.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, 40 + (85 * index), 0, 0);
        }

        private void chip_Click(object sender, RoutedEventArgs e)
        {
            mainWindowViewModel.SelectedIndex = 2;
        }

        
    }
    
}
