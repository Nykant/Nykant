using Microsoft.EntityFrameworkCore;
using Nykant.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nykant.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Description = "a test object", LastModified = DateTime.Now, ImageSource = "~/wwwroot/images/Finback-Chairs1-1280x853-c-default.jpg", TypeOfWood = "valnød", ItemType = "stol", Size = "5mm", Color = "naturligt"},
                new Product { Id = 2, Description = "a test object", LastModified = DateTime.Now, ImageSource = "~/wwwroot/images/Finback-Chairs1-1280x853-c-default.jpg", TypeOfWood = "eg", ItemType = "stol", Size = "10mm", Color = "farvet-overflade" },
                new Product { Id = 3, Description = "a test object", LastModified = DateTime.Now, ImageSource = "~/wwwroot/images/Finback-Chairs1-1280x853-c-default.jpg", TypeOfWood = "fyr", ItemType = "bænk", Size = "20mm", Color = "naturligt" },
                new Product { Id = 4, Description = "a test object", LastModified = DateTime.Now, ImageSource = "~/wwwroot/images/Finback-Chairs1-1280x853-c-default.jpg", TypeOfWood = "eg", ItemType = "skærebræt", Size = "5mm", Color = "farvet-overflade" },
                new Product { Id = 5, Description = "a test object", LastModified = DateTime.Now, ImageSource = "~/wwwroot/images/Finback-Chairs1-1280x853-c-default.jpg", TypeOfWood = "valnød", ItemType = "bænk", Size = "10mm", Color = "naturligt" },
                new Product { Id = 6, Description = "a test object", LastModified = DateTime.Now, ImageSource = "~/wwwroot/images/Finback-Chairs1-1280x853-c-default.jpg", TypeOfWood = "fyr", ItemType = "skærebræt", Size = "20mm", Color = "farvet-overflade" },
                new Product { Id = 7, Description = "a test object", LastModified = DateTime.Now, ImageSource = "~/wwwroot/images/Finback-Chairs1-1280x853-c-default.jpg", TypeOfWood = "valnød", ItemType = "bænk", Size = "5mm", Color = "naturligt" }
                );
        }
    }
}
