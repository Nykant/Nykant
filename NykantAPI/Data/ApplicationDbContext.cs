using Microsoft.EntityFrameworkCore;
using NykantAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NykantAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<BagItem> BagItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CustomerInf> CustomerInfs { get; set; }
        public DbSet<ShippingDelivery> ShippingDeliveries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BagItem>()
                .HasKey(bi => new { bi.Subject, bi.ProductId });
            modelBuilder.Entity<OrderItem>()
                .HasKey(bi => new { bi.OrderId, bi.ProductId});

            modelBuilder.Entity<ShippingDelivery>().HasData(
                new ShippingDelivery { Id = 1, Name = "GLS", Price = 35 },
                new ShippingDelivery { Id = 2, Name = "PostNord", Price = 50 },
                new ShippingDelivery { Id = 3, Name = "GLS Privat", Price = 65 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, Path = @"C:\Users\Christian\source\repos\Nykant\NykantMVC\wwwroot\images\gyngestol.jpg", ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", ImageSource2 = "../images/gyngestol.jpg", TypeOfWood = "valnød", ItemType = "stol", Size = "5mm", Color = "naturligt" },
                new Product { Id = 2, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, Path = @"C:\Users\Christian\source\repos\Nykant\NykantMVC\wwwroot\images\gyngestol.jpg", ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", ImageSource2 = "../images/gyngestol.jpg", TypeOfWood = "eg", ItemType = "stol", Size = "10mm", Color = "farvet-overflade" },
                new Product { Id = 3, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, Path = @"C:\Users\Christian\source\repos\Nykant\NykantMVC\wwwroot\images\gyngestol.jpg", ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", ImageSource2 = "../images/gyngestol.jpg", TypeOfWood = "fyr", ItemType = "bænk", Size = "20mm", Color = "naturligt" },
                new Product { Id = 4, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, Path = @"C:\Users\Christian\source\repos\Nykant\NykantMVC\wwwroot\images\gyngestol.jpg", ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", ImageSource2 = "../images/gyngestol.jpg", TypeOfWood = "eg", ItemType = "skærebræt", Size = "5mm", Color = "farvet-overflade" },
                new Product { Id = 5, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, Path = @"C:\Users\Christian\source\repos\Nykant\NykantMVC\wwwroot\images\gyngestol.jpg", ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", ImageSource2 = "../images/gyngestol.jpg", TypeOfWood = "valnød", ItemType = "bænk", Size = "10mm", Color = "naturligt" },
                new Product { Id = 6, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, Path = @"C:\Users\Christian\source\repos\Nykant\NykantMVC\wwwroot\images\gyngestol.jpg", ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", ImageSource2 = "../images/gyngestol.jpg", TypeOfWood = "fyr", ItemType = "skærebræt", Size = "20mm", Color = "farvet-overflade" },
                new Product { Id = 7, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, Path = @"C:\Users\Christian\source\repos\Nykant\NykantMVC\wwwroot\images\gyngestol.jpg", ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", ImageSource2 = "../images/gyngestol.jpg", TypeOfWood = "valnød", ItemType = "stol", Size = "5mm", Color = "naturligt" },
                new Product { Id = 8, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, Path = @"C:\Users\Christian\source\repos\Nykant\NykantMVC\wwwroot\images\gyngestol.jpg", ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", ImageSource2 = "../images/gyngestol.jpg", TypeOfWood = "eg", ItemType = "stol", Size = "10mm", Color = "farvet-overflade" },
                new Product { Id = 9, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, Path = @"C:\Users\Christian\source\repos\Nykant\NykantMVC\wwwroot\images\gyngestol.jpg", ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", ImageSource2 = "../images/gyngestol.jpg", TypeOfWood = "fyr", ItemType = "bænk", Size = "20mm", Color = "naturligt" },
                new Product { Id = 10, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, Path = @"C:\Users\Christian\source\repos\Nykant\NykantMVC\wwwroot\images\gyngestol.jpg", ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", ImageSource2 = "../images/gyngestol.jpg", TypeOfWood = "eg", ItemType = "skærebræt", Size = "5mm", Color = "farvet-overflade" },
                new Product { Id = 11, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, Path = @"C:\Users\Christian\source\repos\Nykant\NykantMVC\wwwroot\images\gyngestol.jpg", ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", ImageSource2 = "../images/gyngestol.jpg", TypeOfWood = "valnød", ItemType = "bænk", Size = "10mm", Color = "naturligt" },
                new Product { Id = 12, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, Path = @"C:\Users\Christian\source\repos\Nykant\NykantMVC\wwwroot\images\gyngestol.jpg", ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", ImageSource2 = "../images/gyngestol.jpg", TypeOfWood = "fyr", ItemType = "skærebræt", Size = "20mm", Color = "farvet-overflade" },
                new Product { Id = 13, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, Path = @"C:\Users\Christian\source\repos\Nykant\NykantMVC\wwwroot\images\gyngestol.jpg", ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", ImageSource2 = "../images/gyngestol.jpg", TypeOfWood = "valnød", ItemType = "stol", Size = "5mm", Color = "naturligt" },
                new Product { Id = 14, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, Path = @"C:\Users\Christian\source\repos\Nykant\NykantMVC\wwwroot\images\gyngestol.jpg", ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", ImageSource2 = "../images/gyngestol.jpg", TypeOfWood = "eg", ItemType = "stol", Size = "10mm", Color = "farvet-overflade" },
                new Product { Id = 15, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, Path = @"C:\Users\Christian\source\repos\Nykant\NykantMVC\wwwroot\images\gyngestol.jpg", ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", ImageSource2 = "../images/gyngestol.jpg", TypeOfWood = "fyr", ItemType = "bænk", Size = "20mm", Color = "naturligt" },
                new Product { Id = 16, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, Path = @"C:\Users\Christian\source\repos\Nykant\NykantMVC\wwwroot\images\gyngestol.jpg", ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", ImageSource2 = "../images/gyngestol.jpg", TypeOfWood = "eg", ItemType = "skærebræt", Size = "5mm", Color = "farvet-overflade" },
                new Product { Id = 17, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, Path = @"C:\Users\Christian\source\repos\Nykant\NykantMVC\wwwroot\images\gyngestol.jpg", ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", ImageSource2 = "../images/gyngestol.jpg", TypeOfWood = "valnød", ItemType = "bænk", Size = "10mm", Color = "naturligt" },
                new Product { Id = 18, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, Path = @"C:\Users\Christian\source\repos\Nykant\NykantMVC\wwwroot\images\gyngestol.jpg", ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", ImageSource2 = "../images/gyngestol.jpg", TypeOfWood = "fyr", ItemType = "skærebræt", Size = "20mm", Color = "farvet-overflade" },
                new Product { Id = 19, Title = "Grøntsags Skærebræt", Price = 1000, Description = "a test object", LastModified = DateTime.Now, Path = @"C:\Users\Christian\source\repos\Nykant\NykantMVC\wwwroot\images\gyngestol.jpg", ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg", ImageSource2 = "../images/gyngestol.jpg", TypeOfWood = "valnød", ItemType = "bænk", Size = "5mm", Color = "naturligt" }
                );
            modelBuilder.Entity<Image>().HasData(
                new Image { Id = 1, ProductId = 1, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 2, ProductId = 2, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 3, ProductId = 3, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 4, ProductId = 4, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 5, ProductId = 5, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 6, ProductId = 6, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 7, ProductId = 7, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 8, ProductId = 8, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 9, ProductId = 9, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 10, ProductId = 10, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 11, ProductId = 11, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 12, ProductId = 12, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 13, ProductId = 13, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 14, ProductId = 14, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 15, ProductId = 15, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 16, ProductId = 16, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 17, ProductId = 17, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 18, ProductId = 18, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 19, ProductId = 19, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 20, ProductId = 1, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 21, ProductId = 2, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 22, ProductId = 3, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 23, ProductId = 4, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 24, ProductId = 5, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 25, ProductId = 6, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 26, ProductId = 7, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 27, ProductId = 8, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 28, ProductId = 9, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 29, ProductId = 10, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 30, ProductId = 11, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 31, ProductId = 12, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 32, ProductId = 13, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 33, ProductId = 14, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 34, ProductId = 15, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 35, ProductId = 16, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 36, ProductId = 17, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 37, ProductId = 18, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                new Image { Id = 38, ProductId = 19, Source = "../images/Finback-Chairs1-1280x853-c-default.jpg" }

                );
        }
    }
}
