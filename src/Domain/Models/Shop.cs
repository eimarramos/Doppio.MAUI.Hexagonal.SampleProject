namespace Domain.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Rating { get; set; }
        public string ImageSource { get; set; } = string.Empty;
        public string CategoriesString { get; set; } = string.Empty;
    }
}
