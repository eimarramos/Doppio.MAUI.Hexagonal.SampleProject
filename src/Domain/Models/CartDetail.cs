namespace Domain.Models
{
    public class CartDetail
    {
        public int Id { get; set; }
        public int CoffeeId { get; set; }
        public int CartId { get; set; }
        public string CoffeeName { get; set; } = string.Empty;
        public string CoffeeDescription { get; set; } = string.Empty;
        public string CoffeeImageSource { get; set; } = string.Empty;
        public decimal CoffeePrice { get; set; }
        public int Quantity { get; set; }
    }
}
