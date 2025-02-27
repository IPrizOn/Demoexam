using System.Windows;
using System.Windows.Controls;

namespace DemoexamGUI.Views.Pages
{
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PartnersPage());
        }
    }
}
