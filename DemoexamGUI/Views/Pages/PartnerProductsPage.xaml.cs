using DemoexamGUI.AppData;
using DemoexamGUI.Database;
using DemoexamGUI.Domain;
using System.Windows.Controls;

namespace DemoexamGUI.Views.Pages
{ 
    public partial class PartnerProductsPage : Page
    {
        private List<Partner> partnersList;
        private List<Product> productsList;
        private List<ProductType> productTypesList;
        private List<PartnerProduct> partnerProductsList;

        public PartnerProductsPage()
        {
            InitializeComponent();

            loadPartnerProductsData();
        }

        private void loadPartnerProductsData()
        {
            partnersList = GetData.GetPartnersList();
            productsList = GetData.GetProductsList();
            productTypesList = GetData.GetProductTypesList();
            partnerProductsList = GetData.GetPartnerProductsList();

            var productsListEdited = productsList.Select(o => new Product
            {
                Id = o.Id,
                TypeId = o.TypeId,
                Material = o.Material,
                Scheme = o.Scheme,
                ProductClass = o.ProductClass,
                ThicknessMm = o.ThicknessMm,
                Chamfered = o.Chamfered,
                Article = o.Article,
                MinCost = o.MinCost,
                Type = productTypesList.FirstOrDefault(p => p.Id == o.TypeId).Type
            }).ToList();

            var partnerProductsListEdited = partnerProductsList.Select(o => new PartnerProduct
            {
                Id = o.Id,
                PartnerId = o.PartnerId,
                ProductId = o.ProductId,
                Count = o.Count,
                SaleAt = o.SaleAt,
                Partner = partnersList.FirstOrDefault(p => p.Id == o.PartnerId).Name,
                Product = productsListEdited.FirstOrDefault(p => p.Id == o.ProductId).ProductName,
            }).ToList();

            PartnerProductsDataGrid.ItemsSource = partnerProductsListEdited;
        }

        private void ButtonBack_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            HomeObjects.frameHome.Navigate(new HomePage());
        }
    }
}
