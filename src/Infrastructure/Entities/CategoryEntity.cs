using Infrastructure.Common;

namespace Infrastructure.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<ShopEntity> Shops { get; set; } = new List<ShopEntity>();
    }
}
