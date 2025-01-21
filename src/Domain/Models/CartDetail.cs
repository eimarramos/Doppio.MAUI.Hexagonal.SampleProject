namespace Domain.Models
{
    public class CartDetail
    {
        public int Id { get; set; }
        Coffee? Coffee { get; set; }
        public int Quantity { get; set; }
    }
}
