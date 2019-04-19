using CourseProject_WPF_.Model;
using CourseProject_WPF_.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace CourseProject_WPF_.View
{
    public partial class PersonAreaPage : Page
    {
        User user = CurrentUser.User;

        ViewModel.ViewModel authWindowViewModel;

        public User User
        {
            get { return user; }
        }

        public PersonAreaPage()
        {
            InitializeComponent();
            DataContext = this;
            authWindowViewModel = new ViewModel.ViewModel();
        }

        private void saveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            authWindowViewModel.changeDataOfUser(User, new User(firstNameTextBox.Text, secondNameTextBox.Text, mailTextBox.Text, telNumberTextBox.Text, aboutTextBox.Text, User.Privilege));
        }
    }
}
