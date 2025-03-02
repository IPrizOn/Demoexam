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

        private void ButtonPartners_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PartnersPage());
        }

        private void ButtonPartnerProducts_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PartnerProductsPage());
        }
    }
}
