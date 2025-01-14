using Infrastructure.Common;

namespace Infrastructure.Entities
{
    public class CartEntity : BaseEntity
    {
        public decimal Total { get; set; }
        public ICollection<CartDetailEntity> CartDetails { get; set; } = [];
    }
}
