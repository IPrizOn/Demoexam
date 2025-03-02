namespace DemoexamGUI.Domain
{
    public class Partner
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string DirectorF { get; set; }
        public string DirectorI { get; set; }
        public string DirectorO { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Postcode { get; set; }
        public string Address { get; set; }
        public string INN { get; set; }
        public int Rating { get; set; }

        // Вспомогательные поля
        public string TypeAndName => $"{Type} | {Name}";
        public string DirectorFIO => $"{DirectorF} {DirectorI} {DirectorO}";
        public string PhoneFormatted => $"+7 {Phone}";
        public string RatingFormatted => $"Рейтинг: {Rating}";
        public string Percentage { get; set; }
    }
}
