namespace Domain.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public List<CartDetail> Details { get; set; } = [];
        public decimal Total { get; set; }
    }
}
 