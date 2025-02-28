using DemoexamGUI.Database;
using DemoexamGUI.Domain;
using System.Windows;

namespace DemoexamGUI.Views.Windows
{
    public partial class UpdatePartnerWindow : Window
    {
        private Partner partner;

        private List<string> partnerTypes = new List<string> { "ЗАО", "ООО", "ПАО", "ОАО" };

        public UpdatePartnerWindow(Partner partner)
        {
            InitializeComponent();

            this.partner = partner;

            loadData();
        }

        private void loadData()
        {
            TextBoxName.Text = "";
            ComboBoxType.ItemsSource = partnerTypes;
            TextBoxRating.Text = "";
            TextBoxAddress.Text = "";
            TextBoxDirector.Text = "";
            TextBoxPhone.Text = "";
            TextBoxEmail.Text = "";
            TextBoxINN.Text = "";
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var type = ComboBoxType.SelectedItem.ToString();
            var name = TextBoxName.Text;
            var directorF = TextBoxDirector.Text;
            var directorI = TextBoxDirector.Text;
            var directorO = TextBoxDirector.Text;
            var email = TextBoxEmail.Text;
            var phone = TextBoxPhone.Text;
            var postcode = TextBoxAddress.Text;
            var address = TextBoxAddress.Text;
            var inn = TextBoxINN.Text;
            var rating = TextBoxRating.Text;

            //UpdateData();

            DialogResult = true;
        }
    }
}
