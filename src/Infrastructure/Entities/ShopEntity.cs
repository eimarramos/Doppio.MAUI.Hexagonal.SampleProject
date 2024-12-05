using Infrastructure.Common;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities
{
    public class ShopEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        [Range(1, 5)]
        public double Rating { get; set; }
        public string ImageSource { get; set; } = string.Empty;
        public ICollection<CategoryEntity> Categories { get; set; } = new List<CategoryEntity>();     
    }
}
