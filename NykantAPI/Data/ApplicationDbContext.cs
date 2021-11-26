using Microsoft.EntityFrameworkCore;
using NykantAPI.Models;
using NykantMVC.Models;
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
        public DbSet<Customer> Customer { get; set; }
        public DbSet<ShippingDelivery> ShippingDeliveries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<BillingAddress> BillingAddress { get; set; }
        public DbSet<ShippingAddress> ShippingAddress { get; set; }
        public DbSet<ParcelshopData> ParcelshopData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BagItem>()
                .HasKey(bi => new { bi.Subject, bi.ProductId });
            modelBuilder.Entity<OrderItem>()
                .HasKey(bi => new { bi.OrderId, bi.ProductId });

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Tøjstativer", ImgSource = "../images/Products/NYKANT_rack_naturolie_02.png" },
                new Category { Id = 2, Name = "Borde", ImgSource = "../images/Products/NYKANT_bord_naturolie_02.png" },
                new Category { Id = 3, Name = "Hylder", ImgSource = "../images/Products/NYKANT_hylde_naturolie_01.png" },
                new Category { Id = 4, Name = "Bænke", ImgSource = "../images/Products/NYKANT_opbevaringsbaenk_naturolie_03.png" },
                new Category { Id = 5, Name = "Bøjler", ImgSource = "../images/Products/NYKANT_boejle_naturolie_01.png" }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Nora", Price = 1000, CategoryId = 5, Description = "Bøjlen.", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_boejle_naturolie_01.png", ImageSource = "../images/Products/NYKANT_boejle_naturolie_01.png", ImageSource2 = "../images/Products/NYKANT_boejle_naturolie_02.png", TypeOfWood = "Eg", Oil = "Naturolie", WeightInKg = 11.6 },
                 new Product { Id = 2, Name = "Nora", Price = 1000, CategoryId = 5, Description = "Bøjlen.", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_boejle_sortolie_01.png", ImageSource = "../images/Products/NYKANT_boejle_sortolie_01.png", ImageSource2 = "../images/Products/NYKANT_boejle_sortolie_02.png", TypeOfWood = "Eg", Oil = "Sortolie", WeightInKg = 11.6 },
                 new Product { Id = 3, Name = "Nora", Price = 1000, CategoryId = 5, Description = "Bøjlen.", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_boejle_hvidolie_01.png", ImageSource = "../images/Products/NYKANT_boejle_hvidolie_01.png", ImageSource2 = "../images/Products/NYKANT_boejle_hvidolie_02.png", TypeOfWood = "Eg", Oil = "Hvidolie", WeightInKg = 11.6 },
                 new Product { Id = 4, Name = "Nora", Price = 1000, CategoryId = 3, Description = "Hylden.", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_hvidolie_01.png", ImageSource = "../images/Products/NYKANT_hylde_hvidolie_01.png", ImageSource2 = "../images/Products/NYKANT_hylde_hvidolie_02.png", TypeOfWood = "Eg", Oil = "Hvidolie", WeightInKg = 11.6 }, 
                 new Product { Id = 5, Name = "Nora", Price = 1000, CategoryId = 3, Description = "Hylden.", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_sortolie_01.png", ImageSource = "../images/Products/NYKANT_hylde_sortolie_01.png", ImageSource2 = "../images/Products/NYKANT_hylde_sortolie_02.png", TypeOfWood = "Eg", Oil = "Sortolie", WeightInKg = 11.6 }, 
                 new Product { Id = 6, Name = "Nora", Price = 1000, CategoryId = 3, Description = "Hylden.", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_naturolie_01.png", ImageSource = "../images/Products/NYKANT_hylde_naturolie_01.png", ImageSource2 = "../images/Products/NYKANT_hylde_naturolie_02.png", TypeOfWood = "Eg", Oil = "Naturolie", WeightInKg = 11.6 }, 
                 new Product { Id = 7, Name = "Nora", Price = 1000, CategoryId = 2, Description = "Bordet.", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_bord_naturolie_01.png", ImageSource = "../images/Products/NYKANT_bord_naturolie_01.png", ImageSource2 = "../images/Products/NYKANT_bord_naturolie_02.png", TypeOfWood = "Eg", Oil = "Naturolie", WeightInKg = 11.6 },
                new Product { Id = 8, Name = "Nora", Price = 1000, CategoryId = 4, Description = "Den korte bænk", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_kortbaenk_naturolie_01.png", ImageSource = "../images/Products/NYKANT_kortbaenk_naturolie_01.png", ImageSource2 = "../images/Products/NYKANT_kortbaenk_naturolie_02.png", TypeOfWood = "Eg", Oil = "Naturolie", WeightInKg = 13.4 },
                new Product { Id = 9, Name = "Nora", Price = 1000, CategoryId = 4, Description = "Den lange bænk", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_langbaenk_naturolie_01.png", ImageSource = "../images/Products/NYKANT_langbaenk_naturolie_01.png", ImageSource2 = "../images/Products/NYKANT_langbaenk_naturolie_02.png", TypeOfWood = "Eg", Oil = "Naturolie", WeightInKg = 13.4 },
                new Product { Id = 10, Name = "Grete", Price = 1000, CategoryId = 4, Description = "Opbevaringsbænk", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", ImageSource = "../images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", ImageSource2 = "../images/Products/NYKANT_opbevaringsbaenk_naturolie_02.png", TypeOfWood = "Eg", Oil = "Naturolie", WeightInKg = 13.4 },
                new Product { Id = 11, Name = "Ingrid", Price = 1000, CategoryId = 1, Description = "Vores tøjstativ ”Nora” er udviklet i et system hvor det samles uden skruer og lim, men udelukkende med kiler i massiv egetræ. Detaljen i sig selv er både meget nem at samle og skille, men viser måske i endnu højere grad nogle meget smukke og enkle detaljer, Der klæder møblet med en meget høj snedkermæssig niveau.", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", ImageSource = "../images/Products/NYKANT_rack_naturolie_01.png", ImageSource2 = "../images/Products/NYKANT_rack_naturolie_02.png", TypeOfWood = "Eg", Oil = "Naturolie", WeightInKg = 13.4 }
                );
            modelBuilder.Entity<Image>().HasData(
                    new Image { Id = 1, ProductId = 3, Source = "../images/Products/NYKANT_boejle_hvidolie_01.png" },
                    new Image { Id = 2, ProductId = 3, Source = "../images/Products/NYKANT_boejle_hvidolie_02.png" },
                    new Image { Id = 3, ProductId = 1, Source = "../images/Products/NYKANT_boejle_naturolie_01.png" },
                    new Image { Id = 4, ProductId = 1, Source = "../images/Products/NYKANT_boejle_naturolie_02.png" },
                    new Image { Id = 5, ProductId = 2, Source = "../images/Products/NYKANT_boejle_sortolie_01.png" },
                    new Image { Id = 6, ProductId = 2, Source = "../images/Products/NYKANT_boejle_sortolie_02.png" },

                    new Image { Id = 7, ProductId = 7, Source = "../images/Products/NYKANT_bord_naturolie_01.png" },
                    new Image { Id = 8, ProductId = 7, Source = "../images/Products/NYKANT_bord_naturolie_02.png" },
                    new Image { Id = 9, ProductId = 7, Source = "../images/Products/NYKANT_bord_naturolie_03.png" },

                    new Image { Id = 10, ProductId = 4, Source = "../images/Products/NYKANT_hylde_hvidolie_01.png" },
                    new Image { Id = 11, ProductId = 4, Source = "../images/Products/NYKANT_hylde_hvidolie_02.png" },
                    new Image { Id = 12, ProductId = 4, Source = "../images/Products/NYKANT_hylde_hvidolie_03.png" },
                    new Image { Id = 13, ProductId = 6, Source = "../images/Products/NYKANT_hylde_naturolie_01.png" },
                    new Image { Id = 14, ProductId = 6, Source = "../images/Products/NYKANT_hylde_naturolie_02.png" },
                    new Image { Id = 15, ProductId = 6, Source = "../images/Products/NYKANT_hylde_naturolie_03.png" },
                    new Image { Id = 16, ProductId = 5, Source = "../images/Products/NYKANT_hylde_sortolie_01.png" },
                    new Image { Id = 17, ProductId = 5, Source = "../images/Products/NYKANT_hylde_sortolie_02.png" },
                    new Image { Id = 18, ProductId = 5, Source = "../images/Products/NYKANT_hylde_sortolie_03.png" },

                    new Image { Id = 19, ProductId = 8, Source = "../images/Products/NYKANT_kortbaenk_naturolie_01.png" },
                    new Image { Id = 20, ProductId = 8, Source = "../images/Products/NYKANT_kortbaenk_naturolie_02.png" },
                    new Image { Id = 21, ProductId = 8, Source = "../images/Products/NYKANT_kortbaenk_naturolie_03.png" },

                    new Image { Id = 22, ProductId = 9, Source = "../images/Products/NYKANT_langbaenk_naturolie_01.png" },
                    new Image { Id = 23, ProductId = 9, Source = "../images/Products/NYKANT_langbaenk_naturolie_02.png" },
                    new Image { Id = 24, ProductId = 9, Source = "../images/Products/NYKANT_langbaenk_naturolie_03.png" },

                    new Image { Id = 25, ProductId = 10, Source = "../images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png" },
                    new Image { Id = 26, ProductId = 10, Source = "../images/Products/NYKANT_opbevaringsbaenk_naturolie_02.png" },
                    new Image { Id = 27, ProductId = 10, Source = "../images/Products/NYKANT_opbevaringsbaenk_naturolie_03.png" },
                    new Image { Id = 28, ProductId = 10, Source = "../images/Products/NYKANT_opbevaringsbaenk_naturolie_04.png" },
                    new Image { Id = 29, ProductId = 10, Source = "../images/Products/NYKANT_opbevaringsbaenk_naturolie_05.png" },
                    new Image { Id = 30, ProductId = 10, Source = "../images/Products/NYKANT_opbevaringsbaenk_naturolie_06.png" },
                    new Image { Id = 31, ProductId = 10, Source = "../images/Products/NYKANT_opbevaringsbaenk_naturolie_07.png" },

                    new Image { Id = 32, ProductId = 11, Source = "../images/Products/NYKANT_rack_naturolie_01.png" },
                    new Image { Id = 33, ProductId = 11, Source = "../images/Products/NYKANT_rack_naturolie_02.png" },
                    new Image { Id = 34, ProductId = 11, Source = "../images/Products/NYKANT_rack_naturolie_03.png" },
                    new Image { Id = 35, ProductId = 11, Source = "../images/Products/NYKANT_rack_naturolie_04.png" },
                    new Image { Id = 36, ProductId = 11, Source = "../images/Products/NYKANT_rack_naturolie_05.png" },
                    new Image { Id = 37, ProductId = 11, Source = "../images/Products/NYKANT_rack_naturolie_06.png" }
             );
        }
    }
}
