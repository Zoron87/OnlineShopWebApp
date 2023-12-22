using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI
{
    public class ReviewDatabaseContext : DbContext
    {
        public DbSet<ReviewDB> Reviews { get; set; }
        public ReviewDatabaseContext(DbContextOptions<ReviewDatabaseContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReviewDB>()
                .HasOne(p => p.Rating)
                .WithMany()
                .HasForeignKey(p => p.RatingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
