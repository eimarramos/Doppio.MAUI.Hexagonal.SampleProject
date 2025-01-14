using Infrastructure.Common;

namespace Infrastructure.Entities
{
    public class CartDetailEntity : BaseEntity
    {
        public CoffeeEntity? Coffee { get; set; }
        public CartEntity? Cart { get; set; }
        public int Quantity { get; set; }
    }
}
