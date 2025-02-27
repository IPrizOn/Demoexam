using DemoexamGUI.AppData;
using DemoexamGUI.Database;
using DemoexamGUI.Domain;
using DemoexamGUI.Views.Windows;
using System.Windows.Controls;

namespace DemoexamGUI.Views.Pages
{
    public partial class PartnersPage : Page
    {
        private List<Partner> partnersList;
        private List<PartnerProduct> partnerProductsList;

        public List<PartnersDataOut> PartnersDataOutList { get; set; }

        public PartnersPage()
        {
            InitializeComponent();

            

            partnersList = GetData.GetPartners();
            partnerProductsList = GetData.GetPartnerProduct();

            PartnersDataOutList = new List<PartnersDataOut>();
            foreach (Partner partner in partnersList)
            {
                var partnerDataOut = new PartnersDataOut
                {
                    TypeAndName = $"{partner.Type} | {partner.Name}",
                    Director = $"{partner.DirectorF} {partner.DirectorI} {partner.DirectorO}",
                    Phone = $"+7 {partner.Phone}",
                    Rating = $"Рейтинг: {partner.Rating}",
                    Percentage = $"{calculateDiscount(partner)}%",
                };

                PartnersDataOutList.Add(partnerDataOut);
            }

            DataContext = this;
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

        private void ButtonAddPartnerWindow_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AddPartnerWindow addPartnerWindow = new AddPartnerWindow();
            addPartnerWindow.Show();
        }
    }

    public class PartnersDataOut
    {
        public string TypeAndName { get; set; }
        public string Director { get; set; }
        public string Phone { get; set; }
        public string Rating { get; set; }
        public string Percentage { get; set; }
    }
}
