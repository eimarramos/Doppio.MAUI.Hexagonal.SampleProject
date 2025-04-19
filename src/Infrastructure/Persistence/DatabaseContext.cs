using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options, IServiceProvider serviceProvider)
        : base(options){}
        public DbSet<CategoryEntity> Categories { get; set; } = null!;
        public DbSet<ShopEntity> Shops { get; set; } = null!;
        public DbSet<CoffeeEntity> Coffees { get; set; } = null!;
        public DbSet<CartEntity> Carts { get; set; } = null!;
        public DbSet<CartDetailEntity> CartDetails { get; set; } = null!;
        public DbSet<Notify> Notifies { get; set; } = null!;
        public DbSet<PromotionEntity> Promotions { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
