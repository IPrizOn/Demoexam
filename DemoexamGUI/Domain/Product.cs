namespace DemoexamGUI.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Material { get; set; }
        public string Scheme { get; set; }
        public string ProductClass { get; set; }
        public int ThicknessMm { get; set; }
        public bool Chamfered { get; set; }
        public string Article { get; set; }
        public int MinCost { get; set; }
    }
}
