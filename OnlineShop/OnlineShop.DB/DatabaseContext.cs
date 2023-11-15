using Microsoft.EntityFrameworkCore;
using OnlineShop.DB.Models;

namespace OnlineShop.DB
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();  // создаем бд при первом обращении
        }
    }
}
