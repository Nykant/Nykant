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
                new Product { Id = 1, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", TypeOfWood = "valnød", ItemType = "stol", Size = "5mm", Color = "naturligt"},
                new Product { Id = 2, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", TypeOfWood = "eg", ItemType = "stol", Size = "10mm", Color = "farvet-overflade" },
                new Product { Id = 3, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", TypeOfWood = "fyr", ItemType = "bænk", Size = "20mm", Color = "naturligt" },
                new Product { Id = 4, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", TypeOfWood = "eg", ItemType = "skærebræt", Size = "5mm", Color = "farvet-overflade" },
                new Product { Id = 5, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", TypeOfWood = "valnød", ItemType = "bænk", Size = "10mm", Color = "naturligt" },
                new Product { Id = 6, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", TypeOfWood = "fyr", ItemType = "skærebræt", Size = "20mm", Color = "farvet-overflade" },
                new Product { Id = 7, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", TypeOfWood = "valnød", ItemType = "stol", Size = "5mm", Color = "naturligt" },
                new Product { Id = 8, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", TypeOfWood = "eg", ItemType = "stol", Size = "10mm", Color = "farvet-overflade" },
                new Product { Id = 9, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", TypeOfWood = "fyr", ItemType = "bænk", Size = "20mm", Color = "naturligt" },
                new Product { Id = 10, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", TypeOfWood = "eg", ItemType = "skærebræt", Size = "5mm", Color = "farvet-overflade" },
                new Product { Id = 11, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", TypeOfWood = "valnød", ItemType = "bænk", Size = "10mm", Color = "naturligt" },
                new Product { Id = 12, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", TypeOfWood = "fyr", ItemType = "skærebræt", Size = "20mm", Color = "farvet-overflade" },
                new Product { Id = 13, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", TypeOfWood = "valnød", ItemType = "stol", Size = "5mm", Color = "naturligt" },
                new Product { Id = 14, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", TypeOfWood = "eg", ItemType = "stol", Size = "10mm", Color = "farvet-overflade" },
                new Product { Id = 15, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", TypeOfWood = "fyr", ItemType = "bænk", Size = "20mm", Color = "naturligt" },
                new Product { Id = 16, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", TypeOfWood = "eg", ItemType = "skærebræt", Size = "5mm", Color = "farvet-overflade" },
                new Product { Id = 17, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", TypeOfWood = "valnød", ItemType = "bænk", Size = "10mm", Color = "naturligt" },
                new Product { Id = 18, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", TypeOfWood = "fyr", ItemType = "skærebræt", Size = "20mm", Color = "farvet-overflade" },
                new Product { Id = 19, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", TypeOfWood = "valnød", ItemType = "bænk", Size = "5mm", Color = "naturligt" }
                );
        }
    }
}
