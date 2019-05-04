using CourseProject_WPF_.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace CourseProject_WPF_.View
{
    public partial class PersonAreaPage : Page
    {
       PersonAreaViewModel personAreaViewModel = new PersonAreaViewModel();

        public PersonAreaPage()
        {
            InitializeComponent();
            DataContext = personAreaViewModel;
        }

        private void saveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            personAreaViewModel.changeDataOfUser();
        }

        private void deleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            personAreaViewModel.deleteUser();            
        }
    }
}
