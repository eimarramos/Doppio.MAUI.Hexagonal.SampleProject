using Infrastructure.Config;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance
{
    public class DatabaseContext : DbContext
    {
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ShopEntity> Shops { get; set; }      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string DbConnetion = $"Filename={Constants.DatabasePath}";
            optionsBuilder.UseSqlite(DbConnetion);
        }
    }
}
