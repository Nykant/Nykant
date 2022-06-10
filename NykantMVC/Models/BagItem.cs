namespace NykantMVC.Models
{
    public class BagItem
    {
        public string Subject { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public long PiecePrice { get; set; }
        public long TotalPrice { get; set; }
    }
}
