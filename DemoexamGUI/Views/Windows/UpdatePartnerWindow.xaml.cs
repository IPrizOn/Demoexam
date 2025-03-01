using DemoexamGUI.AppData;
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
            ComboBoxType.ItemsSource = partnerTypes;

            TextBoxName.Text = partner.Name;
            ComboBoxType.SelectedItem = partner.Type;
            TextBoxRating.Text = partner.Rating.ToString();
            TextBoxAddress.Text = $"{ partner.Postcode}, { partner.Address}";
            TextBoxDirector.Text = partner.DirectorFIO;
            TextBoxPhone.Text = partner.Phone;
            TextBoxEmail.Text = partner.Email;
            TextBoxINN.Text = partner.INN;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ComboBoxType.SelectedItem?.ToString()) ||
                string.IsNullOrEmpty(TextBoxName.Text) ||
                string.IsNullOrEmpty(TextBoxDirector.Text) ||
                string.IsNullOrEmpty(TextBoxEmail.Text) ||
                string.IsNullOrEmpty(TextBoxPhone.Text) ||
                string.IsNullOrEmpty(TextBoxAddress.Text) ||
                string.IsNullOrEmpty(TextBoxINN.Text) ||
                string.IsNullOrEmpty(TextBoxRating.Text))
            {
                MessageBox.Show("Поля не должны быть пустыми!");
            }
            else
            { 
                var directorFIOParts = TextBoxDirector.Text.Split(' ');

                var commaIndex = TextBoxAddress.Text.IndexOf(',');

                var type = ComboBoxType.SelectedItem.ToString();
                var name = TextBoxName.Text;
                var directorF = directorFIOParts[0];
                var directorI = directorFIOParts[1];
                var directorO = directorFIOParts[2];
                var email = TextBoxEmail.Text;
                var phone = TextBoxPhone.Text;
                var postcode = TextBoxAddress.Text.Substring(0, commaIndex).Trim();
                var address = TextBoxAddress.Text.Substring(commaIndex + 1).Trim();
                var inn = TextBoxINN.Text;
                var ratingString = TextBoxRating.Text;

                if (!StringCheck.IsIntNotNegative(ratingString))
                {
                    MessageBox.Show("Рейтинг может быть только целым неотрицательным числом!");
                }
                else
                {
                    var rating = int.Parse(ratingString);

                    UpdateData.UpdatePartner(partner.Id, type, name, directorF, directorI, directorO, email, phone, postcode, address, inn, rating);

                    DialogResult = true;
                }
            }
        }
    }
}
