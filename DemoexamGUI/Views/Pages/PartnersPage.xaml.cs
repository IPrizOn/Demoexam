using DemoexamGUI.AppData;
using DemoexamGUI.Database;
using DemoexamGUI.Domain;
using DemoexamGUI.Views.Windows;
using System.Windows.Controls;

namespace DemoexamGUI.Views.Pages
{
    public partial class PartnersPage : Page
    {
        public List<Partner> PartnersList;

        private List<PartnerProduct> partnerProductsList;

        public PartnersPage()
        {
            InitializeComponent();

            loadPartnersData();        
        }

        private void loadPartnersData()
        {
            PartnersList = GetData.GetPartnersList();

            partnerProductsList = GetData.GetPartnerProductsList();

            foreach (var partner in PartnersList)
            {
                partner.Percentage = $"{calculateDiscount(partner)}%";
            }

            PartnersListBox.ItemsSource = PartnersList;
        }

        private int calculateDiscount(Partner partner)
        {
            int discount = 0;
            int soldProducts = 0;

            foreach (PartnerProduct partnerProduct in partnerProductsList)
            {
                if (partnerProduct.PartnerId == partner.Id)
                {
                    soldProducts += partnerProduct.Count;
                }
            }

            discount =
                soldProducts < 10000 ? 0 :
                soldProducts < 50000 ? 5 :
                soldProducts < 300000 ? 10 : 15;

            return discount;
        }

        private void ButtonBack_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            HomeObjects.frameHome.Navigate(new HomePage());
        }

        private void ButtonAddPartner_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AddPartnerWindow addPartnerWindow = new AddPartnerWindow();
            if (addPartnerWindow.ShowDialog() == true)
            {
                loadPartnersData();
            }
        }

        private void ListPartners_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PartnersListBox.SelectedItem is Partner selectedPartner) 
            {
                UpdatePartnerWindow addPartnerWindow = new UpdatePartnerWindow(selectedPartner);
                if (addPartnerWindow.ShowDialog() == true)
                {
                    loadPartnersData();
                }
            }

            PartnersListBox.SelectedItem = null;
        }
    }
}
