using Infrastructure.Config;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DbSet<CategoryEntity> Categories { get; set; } = null!;
        public DbSet<ShopEntity> Shops { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string DbConnetion = $"Filename={Constants.DatabasePath}";
            optionsBuilder.UseSqlite(DbConnetion);
        }
    }
}
