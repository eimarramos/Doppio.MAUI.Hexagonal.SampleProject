namespace Domain.Models
{
    public class CartDetail
    {
        public int Id { get; set; }
        public Coffee? Coffee { get; set; }
        public int Quantity { get; set; }
    }
}
