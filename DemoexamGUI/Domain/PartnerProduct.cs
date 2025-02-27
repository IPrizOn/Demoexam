namespace DemoexamGUI.Domain
{
    public class PartnerProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int PartnerId { get; set; }
        public int Count { get; set; }
        public DateTime SaleAt { get; set; }
    }
}
