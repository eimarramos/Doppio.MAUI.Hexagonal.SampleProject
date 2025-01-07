namespace Domain.Models
{
    public class Coffee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageSource { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
