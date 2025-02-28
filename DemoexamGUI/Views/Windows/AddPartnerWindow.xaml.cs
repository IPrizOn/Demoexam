﻿using DemoexamGUI.Database;
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

            //AddData();

            DialogResult = true;
        }
    }
}
