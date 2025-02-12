using Infrastructure.Common;

namespace Infrastructure.Entities
{
    public class Notify : BaseEntity
    {
        public CoffeeEntity? Coffee { get; set; }
        public int Progress { get; set; }
    }
}
