using DemoexamGUI.AppData;
using DemoexamGUI.Database;
using System.Windows;

namespace DemoexamGUI.Views.Windows
{
    public partial class AddPartnerWindow : Window
    {
        private List<string> partnerTypes = new List<string> { "ЗАО", "ООО", "ПАО", "ОАО" };

        public AddPartnerWindow()
        {
            InitializeComponent();

            loadData();
        }

        private void loadData()
        {
            ComboBoxType.ItemsSource = partnerTypes;
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
                MessageBox.Show("Вы заполнили не все поля!");
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

                    AddData.AddPartner(type, name, directorF, directorI, directorO, email, phone, postcode, address, inn, rating);

                    DialogResult = true;
                }
            }
        }
    }
}
