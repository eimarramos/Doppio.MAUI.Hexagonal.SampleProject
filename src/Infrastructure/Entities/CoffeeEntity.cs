using Infrastructure.Common;

namespace Infrastructure.Entities
{
    public class CoffeeEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageSource { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public ICollection<ShopEntity> Shops { get; set; } = new List<ShopEntity>();
    }
}
