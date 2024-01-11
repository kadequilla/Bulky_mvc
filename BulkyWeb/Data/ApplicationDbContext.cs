using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Action", Description = "TEST", DisplayOrder = 1 },
                new Category { CategoryId = 2, Name = "SciFi", Description = "TEST", DisplayOrder = 2 },
                new Category { CategoryId = 3, Name = "History", Description = "TEST", DisplayOrder = 3 }
                ); ;
        }
    }
}
