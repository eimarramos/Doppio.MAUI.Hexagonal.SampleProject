using Infrastructure.Common;

namespace Infrastructure.Entities
{
    public class PromotionEntity : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public ShopEntity? Shop { get; set; }
        public CoffeeEntity? Coffee { get; set; }
        public DateTimeOffset Expiration { get; set; }
    }
}
