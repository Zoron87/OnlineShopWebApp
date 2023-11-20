using Microsoft.EntityFrameworkCore;
using OnlineShop.DB.Models;
using System.Collections.Generic;

namespace OnlineShop.DB
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Compare> Compares { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();  // создаем бд при первом обращении
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasOne(u => u.OrderDetails).WithOne().HasForeignKey<OrderDetails>(x=>x.Id);                
        }
    }
}
