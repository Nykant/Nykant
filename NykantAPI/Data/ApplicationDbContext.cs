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
        public DbSet<NewsSub> NewsSubs { get; set; }
        public DbSet<Color> Colors { get; set; }

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
                new Product { Id = 1, Name = "Bøjlen Gertrud / 3 stk.", Title = "Bøjle i massivt egetræ - Behandlet med naturolie", Pieces = 3, Price = 375, CategoryId = 5, Description = "Gertrud Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_boejle_naturolie_01.png", ImageSource = "../images/Products/NYKANT_boejle_naturolie_01.png", ImageSource2 = "../images/Products/NYKANT_boejle_naturolie_02.png", Materials = "Gertrud Materials", Oil = "Naturolie", WeightInKg = 11.6, Number = "101", Size = "Gertrud Size", Note = "Gertrud Note", AssemblyPath = "none" },
                 new Product { Id = 2, Name = "Bøjlen Gertrud / 3 stk.", Title = "Bøjle i massivt egetræ - Behandlet med sortolie", Pieces = 3, Price = 375, CategoryId = 5, Description = "Gertrud Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_boejle_sortolie_01.png", ImageSource = "../images/Products/NYKANT_boejle_sortolie_01.png", ImageSource2 = "../images/Products/NYKANT_boejle_sortolie_02.png", Materials = "Gertrud Materials", Oil = "Sortolie", WeightInKg = 11.6, Number = "101", Size = "Gertrud Size", Note = "Gertrud Note", AssemblyPath = "none" },
                 new Product { Id = 3, Name = "Bøjlen Gertrud / 3 stk.", Title = "Bøjle i massivt egetræ - Behandlet med hvidolie", Pieces = 3, Price = 375, CategoryId = 5, Description = "Gertrud Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_boejle_hvidolie_01.png", ImageSource = "../images/Products/NYKANT_boejle_hvidolie_01.png", ImageSource2 = "../images/Products/NYKANT_boejle_hvidolie_02.png", Materials = "Gertrud Materials", Oil = "Hvidolie", WeightInKg = 11.6, Number = "101", Size = "Gertrud Size", Note = "Gertrud Note", AssemblyPath = "none" },
                 new Product { Id = 4, Name = "Ingeborg Hylden", Title = "Hylde i massivt egetræ - Behandlet med hvidolie", Price = 595, CategoryId = 3, Description = "Ingeborg Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_hvidolie_01.png", ImageSource = "../images/Products/NYKANT_hylde_hvidolie_01.png", ImageSource2 = "../images/Products/NYKANT_hylde_hvidolie_02.png", Materials = "Ingeborg Materials", Oil = "Hvidolie", WeightInKg = 11.6, Number = "101", Size = "Ingeborg Size", Note = "Ingeborg Note", AssemblyPath = "/word/Hylde_Vejledning.docx" }, 
                 new Product { Id = 5, Name = "Ingeborg Hylden", Title = "Hylde i massivt egetræ - Behandlet med sortolie", Price = 595, CategoryId = 3, Description = "Ingeborg Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_sortolie_01.png", ImageSource = "../images/Products/NYKANT_hylde_sortolie_01.png", ImageSource2 = "../images/Products/NYKANT_hylde_sortolie_02.png", Materials = "Ingeborg Materials", Oil = "Sortolie", WeightInKg = 11.6, Number = "101", Size = "Ingeborg Size", Note = "Ingeborg Note", AssemblyPath = "/word/Hylde_Vejledning.docx" }, 
                 new Product { Id = 6, Name = "Ingeborg Hylden", Title = "Hylde i massivt egetræ - Behandlet med naturolie", Price = 595, CategoryId = 3, Description = "Ingeborg Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_naturolie_01.png", ImageSource = "../images/Products/NYKANT_hylde_naturolie_01.png", ImageSource2 = "../images/Products/NYKANT_hylde_naturolie_02.png", Materials = "Ingeborg Materials", Oil = "Naturolie", WeightInKg = 11.6, Number = "101", Size = "Ingeborg Size", Note = "Ingeborg Note", AssemblyPath = "/word/Hylde_Vejledning.docx" }, 
                 new Product { Id = 7, Name = "Dagmar Bordet", Title = "Bord i massivt egetræ - Behandlet med naturolie", Price = 2995, CategoryId = 2, Description = "Dagmar Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_bord_naturolie_01.png", ImageSource = "../images/Products/NYKANT_bord_naturolie_01.png", ImageSource2 = "../images/Products/NYKANT_bord_naturolie_02.png", Materials = "Dagmar Materials", Oil = "Naturolie", WeightInKg = 22, Number = "101", Size = "Dagmar Size", Note = "Dagmar Note", AssemblyPath = "/word/Bord.docx" },
                new Product { Id = 8, Name = "Thyra Kortbænken", Title = "Bænk i massivt egetræ - Behandlet med naturolie", Price = 2985, CategoryId = 4, Description = "Thyra Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_kortbaenk_naturolie_01.png", ImageSource = "../images/Products/NYKANT_kortbaenk_naturolie_01.png", ImageSource2 = "../images/Products/NYKANT_kortbaenk_naturolie_02.png", Materials = "Thyra Materials", Oil = "Naturolie", WeightInKg = 14, Number = "101", Size = "Thyra Size", Note = "Thyra Note", AssemblyPath = "/word/bænk.docx" },
                new Product { Id = 9, Name = "Thyra Langbænken", Title = "Bænk i massivt egetræ - Behandlet med naturolie", Price = 3885, CategoryId = 4, Description = "Thyra Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_langbaenk_naturolie_01.png", ImageSource = "../images/Products/NYKANT_langbaenk_naturolie_01.png", ImageSource2 = "../images/Products/NYKANT_langbaenk_naturolie_02.png", Materials = "Thyra Materials", Oil = "Naturolie", WeightInKg = 20, Number = "101", Size = "Thyra Size", Note = "Thyra Note", AssemblyPath = "/word/bænk.docx" },
                new Product { Id = 10, Name = "Filippa Bænk", Title = "Opbevaringsbænk i massivt egetræ - Behandlet med naturolie", Price = 4395, CategoryId = 4, Description = "Filippa Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", ImageSource = "../images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", ImageSource2 = "../images/Products/NYKANT_opbevaringsbaenk_naturolie_02.png", Materials = "Filippa Materials", Oil = "Naturolie", WeightInKg = 24.0, Number = "101", Size = "Filippa Size", Note = "Filippa Note", AssemblyPath = "none" },
                new Product { Id = 11, Name = "Nora Tøjstativ", Title = "Tøjstativ i massivt egetræ - Behandlet med naturolie", Price = 2295, CategoryId = 1, Description = "Nora Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", ImageSource = "../images/Products/NYKANT_rack_naturolie_01.png", ImageSource2 = "../images/Products/NYKANT_rack_naturolie_02.png", Materials = "Nora Materials", Oil = "Naturolie", WeightInKg = 13.4, Number = "101", Size = "Nora Size", Note = "Nora Note", AssemblyPath = "/word/Tøjstativ.docx" }
                );

            modelBuilder.Entity<Color>().HasData(
                new Color { Id = 1, ProductId = 1, ProductSourceId = 1, ImgSrc = "../images/Products/NYKANT_boejle_naturolie_01.png" },
                new Color { Id = 2, ProductId = 1, ProductSourceId = 2, ImgSrc = "../images/Products/NYKANT_boejle_sortolie_01.png" },
                new Color { Id = 3, ProductId = 1, ProductSourceId = 3, ImgSrc = "../images/Products/NYKANT_boejle_hvidolie_01.png" },
                new Color { Id = 4, ProductId = 2, ProductSourceId = 1, ImgSrc = "../images/Products/NYKANT_boejle_naturolie_01.png" },
                new Color { Id = 5, ProductId = 2, ProductSourceId = 2, ImgSrc = "../images/Products/NYKANT_boejle_sortolie_01.png" },
                new Color { Id = 6, ProductId = 2, ProductSourceId = 3, ImgSrc = "../images/Products/NYKANT_boejle_hvidolie_01.png" },
                new Color { Id = 7, ProductId = 3, ProductSourceId = 1, ImgSrc = "../images/Products/NYKANT_boejle_naturolie_01.png" },
                new Color { Id = 8, ProductId = 3, ProductSourceId = 2, ImgSrc = "../images/Products/NYKANT_boejle_sortolie_01.png" },
                new Color { Id = 9, ProductId = 3, ProductSourceId = 3, ImgSrc = "../images/Products/NYKANT_boejle_hvidolie_01.png" },

                new Color { Id = 10, ProductId = 4, ProductSourceId = 4, ImgSrc = "../images/Products/NYKANT_hylde_hvidolie_01.png" },
                new Color { Id = 11, ProductId = 4, ProductSourceId = 5, ImgSrc = "../images/Products/NYKANT_hylde_sortolie_01.png" },
                new Color { Id = 12, ProductId = 4, ProductSourceId = 6, ImgSrc = "../images/Products/NYKANT_hylde_naturolie_01.png" },
                new Color { Id = 13, ProductId = 5, ProductSourceId = 4, ImgSrc = "../images/Products/NYKANT_hylde_hvidolie_01.png" },
                new Color { Id = 14, ProductId = 5, ProductSourceId = 5, ImgSrc = "../images/Products/NYKANT_hylde_sortolie_01.png" },
                new Color { Id = 15, ProductId = 5, ProductSourceId = 6, ImgSrc = "../images/Products/NYKANT_hylde_naturolie_01.png" },
                new Color { Id = 16, ProductId = 6, ProductSourceId = 4, ImgSrc = "../images/Products/NYKANT_hylde_hvidolie_01.png" },
                new Color { Id = 17, ProductId = 6, ProductSourceId = 5, ImgSrc = "../images/Products/NYKANT_hylde_sortolie_01.png" },
                new Color { Id = 18, ProductId = 6, ProductSourceId = 6, ImgSrc = "../images/Products/NYKANT_hylde_naturolie_01.png" },

                new Color { Id = 19, ProductId = 7, ProductSourceId = 7, ImgSrc = "../images/Products/NYKANT_bord_naturolie_01.png" },

                new Color { Id = 20, ProductId = 8, ProductSourceId = 8, ImgSrc = "../images/Products/NYKANT_kortbaenk_naturolie_01.png" },

                new Color { Id = 21, ProductId = 9, ProductSourceId = 9, ImgSrc = "../images/Products/NYKANT_langbaenk_naturolie_01.png" },

                new Color { Id = 22, ProductId = 10, ProductSourceId = 10, ImgSrc = "../images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png" },

                new Color { Id = 23, ProductId = 11, ProductSourceId = 11, ImgSrc = "../images/Products/NYKANT_rack_naturolie_01.png" }
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
