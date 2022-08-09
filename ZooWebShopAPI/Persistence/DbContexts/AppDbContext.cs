using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.Entities;

namespace ZooWebShopAPI.Persistence.DbContexts
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(z => z.Photos)
                .WithOne(c => c.Product);

            modelBuilder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pc => pc.CategoryId);

            modelBuilder.Entity<Category>()
                .HasData(
                new Category()
                {
                    Id = 1,
                    Name = "Dog food"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Cat food"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Rabbit food"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Bird food"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Fish food"
                },
                new Category()
                {
                    Id = 6,
                    Name = "Dog toys"
                },
                new Category()
                {
                    Id = 7,
                    Name = "Cat toys"
                },
                new Category()
                {
                    Id = 8,
                    Name = "Rabbit cages"
                },
                new Category()
                {
                    Id = 9,
                    Name = "Transport"
                },
                new Category()
                {
                    Id = 10,
                    Name = "Bird cage"
                });

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("zooshop-default"));
        }
    }
}
