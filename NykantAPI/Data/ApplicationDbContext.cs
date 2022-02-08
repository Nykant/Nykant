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
        public DbSet<Cookie> Cookies { get; set; }
        public DbSet<BillingAddress> BillingAddress { get; set; }
        public DbSet<ShippingAddress> ShippingAddress { get; set; }
        public DbSet<ParcelshopData> ParcelshopData { get; set; }
        public DbSet<NewsSub> NewsSubs { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Order>().HasOne(x => x.Invoice);
            modelBuilder.Entity<BagItem>()
                .HasKey(bi => new { bi.Subject, bi.ProductId });
            modelBuilder.Entity<OrderItem>()
                .HasKey(bi => new { bi.OrderId, bi.ProductId });

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Tøjstativer", ImgSource = "../Images/Products/Category/Desktop/ingrid_natur_2.png" },
                new Category { Id = 2, Name = "Borde", ImgSource = "../Images/Products/Category/Desktop/bord_natur_2.png" },
                new Category { Id = 3, Name = "Hylder", ImgSource = "../Images/Products/Category/Desktop/hylde_natur_1.png" },
                new Category { Id = 4, Name = "Bænke", ImgSource = "../Images/Products/Category/Desktop/opbevaringsbaenk_natur_3.png" },
                new Category { Id = 5, Name = "Bøjler", ImgSource = "../Images/Products/Category/Desktop/boejle_natur_1.png" }
                );

            modelBuilder.Entity<Cookie>().HasData(
                // First-Party
                new Cookie { Name = "Culture", Type1 = CookieType1.Persistent, Type2 = CookieType2.FirstParty, Category = CookieCategory.Functional, Description = "Denne cookie gemmer din præference for sprog." },
                new Cookie { Name = "AntiforgeryToken", Type1 = CookieType1.Session, Type2 = CookieType2.FirstParty, Category = CookieCategory.Necessary, Description = "Denne cookie beskytter imod Cross-Site Request Forgery angreb" },
                new Cookie { Name = "Session", Type1 = CookieType1.Session, Type2 = CookieType2.FirstParty, Category = CookieCategory.Necessary, Description = "Denne cookie husker/gemmer hvad du har lagt i din kurv, samt giver dig en bedre checkout oplevelse." },

                // Third-Party
                new Cookie { Name = "__stripe_mid", Type1 = CookieType1.Persistent, Type2 = CookieType2.ThirdParty, Category = CookieCategory.Necessary, Description = "Denne cookie bruges af Stripe og sørger for at vores betalingsservice virker, og er sikker." },
                new Cookie { Name = "__stripe_sid", Type1 = CookieType1.Persistent, Type2 = CookieType2.ThirdParty, Category = CookieCategory.Necessary, Description = "Denne cookie bruges af Stripe og sørger for at vores betalingsservice virker, og er sikker." },
                new Cookie { Name = "_ga", Type1 = CookieType1.Persistent, Type2 = CookieType2.ThirdParty, Category = CookieCategory.Statistics, Description = "Denne cookie bruges af Google Analytics og registrere et unikt ID, som bliver brugt til at generere statistiske data om hvordan besøgende bruger hjemmesiden." },
                new Cookie { Name = "_ga_2LWYP6ZC27", Type1 = CookieType1.Persistent, Type2 = CookieType2.ThirdParty, Category = CookieCategory.Statistics, Description = "Denne cookie bruges af Google Analytics og indsamler data så som hvor mange gange en bruger har besøgt siden, datoen de har besøgt og det seneste besøg." }
             );

            modelBuilder.Entity<Product>().HasData(
                // bøjler
                new Product { Id = 1, Name = "Bøjlen Gertrud / 3 stk.", EColor = EColor.Nature, Title = "Bøjle i massivt egetræ - Behandlet med naturolie", Pieces = 3, ExpectedDelivery = new DateTime(2022, 02, 28), Price = 375, Amount = 0, CategoryId = 5, Description = "Gertrud Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_boejle_naturolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/NYKANT_boejle_naturolie_01.png", GalleryImage2 = "../images/Products/Gallery/Desktop/NYKANT_boejle_naturolie_02.png", Materials = "Gertrud Materials", Oil = "Naturolie", Length = null, WeightInKg = 11.6, Number = "15001", Size = "Gertrud Size", Package = "Gertrud Package", Note = "Gertrud Note", AssemblyPath = "none" },
                new Product { Id = 2, Name = "Bøjlen Gertrud / 3 stk.", EColor = EColor.Black, Title = "Bøjle i massivt egetræ - Behandlet med sortolie", Pieces = 3, ExpectedDelivery = new DateTime(2022, 02, 28), Price = 375, Amount = 0, CategoryId = 5, Description = "Gertrud Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_boejle_sortolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/NYKANT_boejle_sortolie_01.png", GalleryImage2 = "../images/Products/Gallery/Desktop/NYKANT_boejle_sortolie_02.png", Materials = "Gertrud Materials", Oil = "Sortolie", Length = null, WeightInKg = 11.6, Number = "15003", Size = "Gertrud Size", Package = "Gertrud Package", Note = "Gertrud Note", AssemblyPath = "none" },
                new Product { Id = 3, Name = "Bøjlen Gertrud / 3 stk.", EColor = EColor.White, Title = "Bøjle i massivt egetræ - Behandlet med hvidolie", Pieces = 3, ExpectedDelivery = new DateTime(2022, 02, 28), Price = 375, Amount = 0, CategoryId = 5, Description = "Gertrud Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_boejle_hvidolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/NYKANT_boejle_hvidolie_01.png", GalleryImage2 = "../images/Products/Gallery/Desktop/NYKANT_boejle_hvidolie_02.png", Materials = "Gertrud Materials", Oil = "Hvidolie", Length = null, WeightInKg = 11.6, Number = "15002", Size = "Gertrud Size", Package = "Gertrud Package", Note = "Gertrud Note", AssemblyPath = "none" },

                // hylder
                new Product { Id = 4, Name = "Ingeborg Hylden", EColor = EColor.White, Title = "Hylde i massivt egetræ - Behandlet med hvidolie", Pieces = 1, ExpectedDelivery = new DateTime(2022, 02, 28), Price = 595, Amount = 0, CategoryId = 3, Description = "Ingebor Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_hvidolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_01.png", GalleryImage2 = "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_02.png", Materials = "Ingeborg Materials", Oil = "Hvidolie", Length = "400 mm.", WeightInKg = 11.6, Number = "17032", Size = "Ingeborg 400 Size", Package = "Ingeborg 400 Package", Note = "Ingeborg Note", AssemblyPath = "/word/Hylde_Vejledning.docx" },
                new Product { Id = 5, Name = "Ingeborg Hylden", EColor = EColor.Black, Title = "Hylde i massivt egetræ - Behandlet med sortolie", Pieces = 1, ExpectedDelivery = new DateTime(2022, 02, 28), Price = 595, Amount = 0, CategoryId = 3, Description = "Ingeborg Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_sortolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_01.png", GalleryImage2 = "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_02.png", Materials = "Ingeborg Materials", Oil = "Sortolie", Length = "400 mm.", WeightInKg = 11.6, Number = "17033", Size = "Ingeborg 400 Size", Package = "Ingeborg 400 Package", Note = "Ingeborg Note", AssemblyPath = "/word/Hylde_Vejledning.docx" },
                new Product { Id = 6, Name = "Ingeborg Hylden", EColor = EColor.Nature, Title = "Hylde i massivt egetræ - Behandlet med naturolie", Pieces = 1, ExpectedDelivery = new DateTime(2022, 02, 28), Price = 595, Amount = 0, CategoryId = 3, Description = "Ingeborg Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_naturolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_01.png", GalleryImage2 = "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_02.png", Materials = "Ingeborg Materials", Oil = "Naturolie", Length = "400 mm.", WeightInKg = 11.6, Number = "17031", Size = "Ingeborg 400 Size", Package = "Ingeborg 400 Package", Note = "Ingeborg Note", AssemblyPath = "/word/Hylde_Vejledning.docx" },
                new Product { Id = 7, Name = "Ingeborg Hylden", EColor = EColor.White, Title = "Hylde i massivt egetræ - Behandlet med hvidolie", Pieces = 1, ExpectedDelivery = new DateTime(2022, 02, 28), Price = 595, Amount = 0, CategoryId = 3, Description = "Ingeborg Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_hvidolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_01.png", GalleryImage2 = "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_02.png", Materials = "Ingeborg Materials", Oil = "Hvidolie", Length = "600 mm.", WeightInKg = 11.6, Number = "17022", Size = "Ingeborg 600 Size", Package = "Ingeborg 600 Package", Note = "Ingeborg Note", AssemblyPath = "/word/Hylde_Vejledning.docx" },
                new Product { Id = 8, Name = "Ingeborg Hylden", EColor = EColor.Black, Title = "Hylde i massivt egetræ - Behandlet med sortolie", Pieces = 1, ExpectedDelivery = new DateTime(2022, 02, 28), Price = 595, Amount = 0, CategoryId = 3, Description = "Ingeborg Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_sortolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_01.png", GalleryImage2 = "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_02.png", Materials = "Ingeborg Materials", Oil = "Sortolie", Length = "600 mm.", WeightInKg = 11.6, Number = "17023", Size = "Ingeborg 600 Size", Package = "Ingeborg 600 Package", Note = "Ingeborg Note", AssemblyPath = "/word/Hylde_Vejledning.docx" },
                new Product { Id = 9, Name = "Ingeborg Hylden", EColor = EColor.Nature, Title = "Hylde i massivt egetræ - Behandlet med naturolie", Pieces = 1, ExpectedDelivery = new DateTime(2022, 02, 28), Price = 595, Amount = 0, CategoryId = 3, Description = "Ingeborg Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_naturolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_01.png", GalleryImage2 = "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_02.png", Materials = "Ingeborg Materials", Oil = "Naturolie", Length = "600 mm.", WeightInKg = 11.6, Number = "17021", Size = "Ingeborg 600 Size", Package = "Ingeborg 600 Package", Note = "Ingeborg Note", AssemblyPath = "/word/Hylde_Vejledning.docx" },
                new Product { Id = 10, Name = "Ingeborg Hylden", EColor = EColor.White, Title = "Hylde i massivt egetræ - Behandlet med hvidolie", Pieces = 1, ExpectedDelivery = new DateTime(2022, 02, 28), Price = 595, Amount = 0, CategoryId = 3, Description = "Ingeborg Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_hvidolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_01.png", GalleryImage2 = "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_02.png", Materials = "Ingeborg Materials", Oil = "Hvidolie", Length = "800 mm.", WeightInKg = 11.6, Number = "17012", Size = "Ingeborg 800 Size", Package = "Ingeborg 800 Package", Note = "Ingeborg Note", AssemblyPath = "/word/Hylde_Vejledning.docx" },
                new Product { Id = 11, Name = "Ingeborg Hylden", EColor = EColor.Black, Title = "Hylde i massivt egetræ - Behandlet med sortolie", Pieces = 1, ExpectedDelivery = new DateTime(2022, 02, 28), Price = 595, Amount = 0, CategoryId = 3, Description = "Ingeborg Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_sortolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_01.png", GalleryImage2 = "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_02.png", Materials = "Ingeborg Materials", Oil = "Sortolie", Length = "800 mm.", WeightInKg = 11.6, Number = "17013", Size = "Ingeborg 800 Size", Package = "Ingeborg 800 Package", Note = "Ingeborg Note", AssemblyPath = "/word/Hylde_Vejledning.docx" },
                new Product { Id = 12, Name = "Ingeborg Hylden", EColor = EColor.Nature, Title = "Hylde i massivt egetræ - Behandlet med naturolie", Pieces = 1, ExpectedDelivery = new DateTime(2022, 02, 28), Price = 595, Amount = 0, CategoryId = 3, Description = "Ingeborg Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_naturolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_01.png", GalleryImage2 = "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_02.png", Materials = "Ingeborg Materials", Oil = "Naturolie", Length = "800 mm.", WeightInKg = 11.6, Number = "17011", Size = "Ingeborg 800 Size", Package = "Ingeborg 800 Package", Note = "Ingeborg Note", AssemblyPath = "/word/Hylde_Vejledning.docx" },
                new Product { Id = 13, Name = "Ingeborg Hylden", EColor = EColor.White, Title = "Hylde i massivt egetræ - Behandlet med hvidolie", Pieces = 1, ExpectedDelivery = new DateTime(2022, 02, 28), Price = 595, Amount = 0, CategoryId = 3, Description = "Ingeborg Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_hvidolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_01.png", GalleryImage2 = "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_02.png", Materials = "Ingeborg Materials", Oil = "Hvidolie", Length = "1000 mm.", WeightInKg = 11.6, Number = "17002", Size = "Ingeborg 1000 Size", Package = "Ingeborg 1000 Package", Note = "Ingeborg Note", AssemblyPath = "/word/Hylde_Vejledning.docx" },
                new Product { Id = 14, Name = "Ingeborg Hylden", EColor = EColor.Black, Title = "Hylde i massivt egetræ - Behandlet med sortolie", Pieces = 1, ExpectedDelivery = new DateTime(2022, 02, 28), Price = 595, Amount = 0, CategoryId = 3, Description = "Ingeborg Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_sortolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_01.png", GalleryImage2 = "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_02.png", Materials = "Ingeborg Materials", Oil = "Sortolie", Length = "1000 mm.", WeightInKg = 11.6, Number = "17003", Size = "Ingeborg 1000 Size", Package = "Ingeborg 1000 Package", Note = "Ingeborg Note", AssemblyPath = "/word/Hylde_Vejledning.docx" },
                new Product { Id = 15, Name = "Ingeborg Hylden", EColor = EColor.Nature, Title = "Hylde i massivt egetræ - Behandlet med naturolie", Pieces = 1, ExpectedDelivery = new DateTime(2022, 02, 28), Price = 595, Amount = 0, CategoryId = 3, Description = "Ingeborg Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_naturolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_01.png", GalleryImage2 = "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_02.png", Materials = "Ingeborg Materials", Oil = "Naturolie", Length = "1000 mm.", WeightInKg = 11.6, Number = "17001", Size = "Ingeborg 1000 Size", Package = "Ingeborg 1000 Package", Note = "Ingeborg Note", AssemblyPath = "/word/Hylde_Vejledning.docx" },

                // borde
                new Product { Id = 16, Name = "Dagmar Bordet", EColor = EColor.Nature, Title = "Bord i massivt egetræ - Behandlet med naturolie", Pieces = 1, ExpectedDelivery = new DateTime(), Price = 2995, Amount = 72, CategoryId = 2, Description = "Dagmar Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_bord_naturolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/NYKANT_bord_naturolie_01.png", GalleryImage2 = "../images/Products/Gallery/Desktop/NYKANT_bord_naturolie_02.png", Materials = "Dagmar Materials", Oil = "Naturolie", Length = null, WeightInKg = 22, Number = "16001", Size = "Dagmar Size", Package = "Dagmar Package", Note = "Dagmar Note", AssemblyPath = "/word/Bord.docx" },
                new Product { Id = 17, Name = "Dagmar Bordet", EColor = EColor.White, Title = "Bord i massivt egetræ - Behandlet med hvidolie", Pieces = 1, ExpectedDelivery = new DateTime(), Price = 2995, Amount = 30, CategoryId = 2, Description = "Dagmar Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_bord_hvidolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/NYKANT_bord_hvidolie_01.png", GalleryImage2 = "../images/Products/Gallery/Desktop/NYKANT_bord_hvidolie_02.png", Materials = "Dagmar Materials", Oil = "Hvidolie", Length = null, WeightInKg = 22, Number = "16002", Size = "Dagmar Size", Package = "Dagmar Package", Note = "Dagmar Note", AssemblyPath = "/word/Bord.docx" },

                // thyra bænk
                new Product { Id = 18, Name = "Thyra Bænken", EColor = EColor.Nature, Title = "Bænk i massivt egetræ - Behandlet med naturolie", Pieces = 1, ExpectedDelivery = new DateTime(), Price = 2985, Amount = 42, CategoryId = 4, Description = "Thyra Short Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_kortbaenk_naturolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/NYKANT_kortbaenk_naturolie_01.png", GalleryImage2 = "../images/Products/Gallery/Desktop/NYKANT_kortbaenk_naturolie_02.png", Materials = "Thyra Short Materials", Oil = "Naturolie", Length = "1150 mm.", WeightInKg = 14, Number = "12001", Size = "Thyra Short Size", Package = "Thyra Short Package", Note = "Thyra Short Note", AssemblyPath = "/word/bænk.docx" },
                new Product { Id = 19, Name = "Thyra Bænken", EColor = EColor.White, Title = "Bænk i massivt egetræ - Behandlet med hvidolie", Pieces = 1, ExpectedDelivery = new DateTime(), Price = 2985, Amount = 20, CategoryId = 4, Description = "Thyra Short Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_kortbaenk_naturolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/NYKANT_kortbaenk_hvidolie_01.png", GalleryImage2 = "../images/Products/Gallery/Desktop/NYKANT_kortbaenk_hvidolie_02.png", Materials = "Thyra Short Materials", Oil = "Hvidolie", Length = "1150 mm.", WeightInKg = 14, Number = "12002", Size = "Thyra Short Size", Package = "Thyra Short Package", Note = "Thyra Short Note", AssemblyPath = "/word/bænk.docx" },
                new Product { Id = 20, Name = "Thyra Bænken", EColor = EColor.Black, Title = "Bænk i massivt egetræ - Behandlet med sortolie", Pieces = 1, ExpectedDelivery = new DateTime(), Price = 2985, Amount = 10, CategoryId = 4, Description = "Thyra Short Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_kortbaenk_naturolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/NYKANT_kortbaenk_sortolie_01.png", GalleryImage2 = "../images/Products/Gallery/Desktop/NYKANT_kortbaenk_sortolie_02.png", Materials = "Thyra Short Materials", Oil = "Sortolie", Length = "1150 mm.", WeightInKg = 14, Number = "12003", Size = "Thyra Short Size", Package = "Thyra Short Package", Note = "Thyra Short Note", AssemblyPath = "/word/bænk.docx" },
                new Product { Id = 21, Name = "Thyra Bænken", EColor = EColor.Nature, Title = "Bænk i massivt egetræ - Behandlet med naturolie", Pieces = 1, ExpectedDelivery = new DateTime(), Price = 3885, Amount = 17, CategoryId = 4, Description = "Thyra Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_langbaenk_naturolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/NYKANT_langbaenk_naturolie_01.png", GalleryImage2 = "../images/Products/Gallery/Desktop/NYKANT_langbaenk_naturolie_02.png", Materials = "Thyra Materials", Oil = "Naturolie", Length = "1700 mm.", WeightInKg = 20, Number = "11001", Size = "Thyra Size", Package = "Thyra Package", Note = "Thyra Note", AssemblyPath = "/word/bænk.docx" },
                new Product { Id = 22, Name = "Thyra Bænken", EColor = EColor.White, Title = "Bænk i massivt egetræ - Behandlet med hvidolie", Pieces = 1, ExpectedDelivery = new DateTime(), Price = 3885, Amount = 10, CategoryId = 4, Description = "Thyra Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_langbaenk_naturolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/NYKANT_langbaenk_hvidolie_01.png", GalleryImage2 = "../images/Products/Gallery/Desktop/NYKANT_langbaenk_hvidolie_02.png", Materials = "Thyra Materials", Oil = "Hvidolie", Length = "1700 mm.", WeightInKg = 20, Number = "11002", Size = "Thyra Size", Package = "Thyra Package", Note = "Thyra Note", AssemblyPath = "/word/bænk.docx" },
                new Product { Id = 23, Name = "Thyra Bænken", EColor = EColor.Black, Title = "Bænk i massivt egetræ - Behandlet med sortolie", Pieces = 1, ExpectedDelivery = new DateTime(), Price = 3885, Amount = 5, CategoryId = 4, Description = "Thyra Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_langbaenk_naturolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/NYKANT_langbaenk_sortolie_01.png", GalleryImage2 = "../images/Products/Gallery/Desktop/NYKANT_langbaenk_sortolie_02.png", Materials = "Thyra Materials", Oil = "Sortolie", Length = "1700 mm.", WeightInKg = 20, Number = "11003", Size = "Thyra Size", Package = "Thyra Package", Note = "Thyra Note", AssemblyPath = "/word/bænk.docx" },

                // filippa bænk
                new Product { Id = 24, Name = "Filippa Bænk", EColor = EColor.Nature, Title = "Opbevaringsbænk i massivt egetræ - Behandlet med naturolie", Pieces = 1, ExpectedDelivery = new DateTime(), Price = 4395, Amount = 50, CategoryId = 4, Description = "Filippa Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png", GalleryImage2 = "../images/Products/Gallery/Desktop/NYKANT_opbevaringsbaenk_naturolie_02.png", Materials = "Filippa Materials", Oil = "Naturolie", Length = null, WeightInKg = 24.0, Number = "10001", Size = "Filippa Size", Package = "Filippa Package", Note = "Filippa Note", AssemblyPath = "none" },
                new Product { Id = 25, Name = "Filippa Bænk", EColor = EColor.White, Title = "Opbevaringsbænk i massivt egetræ - Behandlet med hvidolie", Pieces = 1, ExpectedDelivery = new DateTime(), Price = 4395, Amount = 30, CategoryId = 4, Description = "Filippa Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png", GalleryImage2 = "../images/Products/Gallery/Desktop/NYKANT_opbevaringsbaenk_hvidolie_02.png", Materials = "Filippa Materials", Oil = "Hvidolie", Length = null, WeightInKg = 24.0, Number = "10002", Size = "Filippa Size", Package = "Filippa Package", Note = "Filippa Note", AssemblyPath = "none" },
                new Product { Id = 26, Name = "Filippa Bænk", EColor = EColor.Black, Title = "Opbevaringsbænk i massivt egetræ - Behandlet med sortolie", Pieces = 1, ExpectedDelivery = new DateTime(), Price = 4395, Amount = 20, CategoryId = 4, Description = "Filippa Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/NYKANT_opbevaringsbaenk_sort_01.png", GalleryImage2 = "../images/Products/Gallery/Desktop/NYKANT_opbevaringsbaenk_sort_02.png", Materials = "Filippa Materials", Oil = "Sortolie", Length = null, WeightInKg = 24.0, Number = "10003", Size = "Filippa Size", Package = "Filippa Package", Note = "Filippa Note", AssemblyPath = "none" },

                // nora tøjstativ standing
                new Product { Id = 27, Name = "Nora Tøjstativ", EColor = EColor.Nature, Title = "Tøjstativ i massivt egetræ - Behandlet med naturolie", Pieces = 1, ExpectedDelivery = new DateTime(), Price = 2295, Amount = 26, CategoryId = 1, Description = "Nora Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/NYKANT_rack_naturolie_01.png", GalleryImage2 = "../images/Products/Gallery/Desktop/NYKANT_rack_naturolie_02.png", Materials = "Nora Materials", Oil = "Naturolie", Length = null, WeightInKg = 8, Number = "13001 + 13001A", Size = "Nora Size", Package = "Nora Package", Note = "Nora Note", AssemblyPath = "/word/Tøjstativ.docx" },
                new Product { Id = 28, Name = "Nora Tøjstativ", EColor = EColor.White, Title = "Tøjstativ i massivt egetræ - Behandlet med hvidolie", Pieces = 1, ExpectedDelivery = new DateTime(), Price = 2295, Amount = 16, CategoryId = 1, Description = "Nora Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/NYKANT_rack_hvidolie_01.png", GalleryImage2 = "../images/Products/Gallery/Desktop/NYKANT_rack_hvidolie_02.png", Materials = "Nora Materials", Oil = "Hvidolie", Length = null, WeightInKg = 8, Number = "13002 + 13002A", Size = "Nora Size", Package = "Nora Package", Note = "Nora Note", AssemblyPath = "/word/Tøjstativ.docx" },
                new Product { Id = 29, Name = "Nora Tøjstativ", EColor = EColor.Black, Title = "Tøjstativ i massivt egetræ - Behandlet med sortolie", Pieces = 1, ExpectedDelivery = new DateTime(), Price = 2295, Amount = 10, CategoryId = 1, Description = "Nora Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/NYKANT_rack_sortolie_01.png", GalleryImage2 = "../images/Products/Gallery/Desktop/NYKANT_rack_sortolie_02.png", Materials = "Nora Materials", Oil = "Sortolie", Length = null, WeightInKg = 8, Number = "13003 + 13003A", Size = "Nora Size", Package = "Nora Package", Note = "Nora Note", AssemblyPath = "/word/Tøjstativ.docx" },

                // ingrid tøjstativ hanging
                new Product { Id = 30, Name = "Ingrid Tøjstativ", EColor = EColor.Nature, Title = "Hængende tøjstativ i massivt egetræ - Behandlet med naturolie", Pieces = 1, ExpectedDelivery = new DateTime(), Price = 2295, Amount = 25, CategoryId = 1, Description = "Ingrid Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/Ingrid_Naturolie_1.png", GalleryImage2 = "../images/Products/Gallery/Desktop/Ingrid_Naturolie_2.png", Materials = "Ingrid Materials", Oil = "Naturolie", Length = null, WeightInKg = 2, Number = "14001", Size = "Ingrid Size", Package = "Ingrid Package", Note = "Ingrid Note", AssemblyPath = "/word/hænge_tøjrack.docx" },
                new Product { Id = 31, Name = "Ingrid Tøjstativ", EColor = EColor.White, Title = "Hængende tøjstativ i massivt egetræ - Behandlet med hvidolie", Pieces = 1, ExpectedDelivery = new DateTime(), Price = 2295, Amount = 15, CategoryId = 1, Description = "Ingrid Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/Ingrid_Hvidolie_1.png", GalleryImage2 = "../images/Products/Gallery/Desktop/Ingrid_Hvidolie_2.png", Materials = "Ingrid Materials", Oil = "Hvidolie", Length = null, WeightInKg = 2, Number = "14002", Size = "Ingrid Size", Package = "Ingrid Package", Note = "Ingrid Note", AssemblyPath = "/word/hænge_tøjrack.docx" },
                new Product { Id = 32, Name = "Ingrid Tøjstativ", EColor = EColor.Black, Title = "Hængende tøjstativ i massivt egetræ - Behandlet med sortolie", Pieces = 1, ExpectedDelivery = new DateTime(), Price = 2295, Amount = 10, CategoryId = 1, Description = "Ingrid Description", Path = "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", GalleryImage1 = "../images/Products/Gallery/Desktop/Ingrid_Sortolie_1.png", GalleryImage2 = "../images/Products/Gallery/Desktop/Ingrid_Sortolie_2.png", Materials = "Ingrid Materials", Oil = "Sortolie", Length = null, WeightInKg = 2, Number = "14003", Size = "Ingrid Size", Package = "Ingrid Package", Note = "Ingrid Note", AssemblyPath = "/word/hænge_tøjrack.docx" }
                );

            modelBuilder.Entity<Color>().HasData(
                // bøjler
                new Color { Id = 1, ProductId = 1, EColor = EColor.Nature, ProductSourceId = 1, ImgSrc = "../images/Products/Color/Desktop/boejle_natur_1.png" },
                new Color { Id = 2, ProductId = 1, EColor = EColor.Black, ProductSourceId = 2, ImgSrc = "../images/Products/Color/Desktop/boejle_sort_1.png" },
                new Color { Id = 3, ProductId = 1, EColor = EColor.White, ProductSourceId = 3, ImgSrc = "../images/Products/Color/Desktop/boejle_hvid_1.png" },
                new Color { Id = 4, ProductId = 2, EColor = EColor.Nature, ProductSourceId = 1, ImgSrc = "../images/Products/Color/Desktop/boejle_natur_1.png" },
                new Color { Id = 5, ProductId = 2, EColor = EColor.Black, ProductSourceId = 2, ImgSrc = "../images/Products/Color/Desktop/boejle_sort_1.png" },
                new Color { Id = 6, ProductId = 2, EColor = EColor.White, ProductSourceId = 3, ImgSrc = "../images/Products/Color/Desktop/boejle_hvid_1.png" },
                new Color { Id = 7, ProductId = 3, EColor = EColor.Nature, ProductSourceId = 1, ImgSrc = "../images/Products/Color/Desktop/boejle_natur_1.png" },
                new Color { Id = 8, ProductId = 3, EColor = EColor.Black, ProductSourceId = 2, ImgSrc = "../images/Products/Color/Desktop/boejle_sort_1.png" },
                new Color { Id = 9, ProductId = 3, EColor = EColor.White, ProductSourceId = 3, ImgSrc = "../images/Products/Color/Desktop/boejle_hvid_1.png" },

                // hylder
                // 400
                new Color { Id = 10, ProductId = 4, EColor = EColor.White, ProductSourceId = 4, ImgSrc = "../images/Products/Color/Desktop/hylde_hvid_1.png" },
                new Color { Id = 11, ProductId = 4, EColor = EColor.Black, ProductSourceId = 5, ImgSrc = "../images/Products/Color/Desktop/hylde_sort_1.png" },
                new Color { Id = 12, ProductId = 4, EColor = EColor.Nature, ProductSourceId = 6, ImgSrc = "../images/Products/Color/Desktop/hylde_natur_1.png" },
                new Color { Id = 13, ProductId = 5, EColor = EColor.White, ProductSourceId = 4, ImgSrc = "../images/Products/Color/Desktop/hylde_hvid_1.png" },
                new Color { Id = 14, ProductId = 5, EColor = EColor.Black, ProductSourceId = 5, ImgSrc = "../images/Products/Color/Desktop/hylde_sort_1.png" },
                new Color { Id = 15, ProductId = 5, EColor = EColor.Nature, ProductSourceId = 6, ImgSrc = "../images/Products/Color/Desktop/hylde_natur_1.png" },
                new Color { Id = 16, ProductId = 6, EColor = EColor.White, ProductSourceId = 4, ImgSrc = "../images/Products/Color/Desktop/hylde_hvid_1.png" },
                new Color { Id = 17, ProductId = 6, EColor = EColor.Black, ProductSourceId = 5, ImgSrc = "../images/Products/Color/Desktop/hylde_sort_1.png" },
                new Color { Id = 18, ProductId = 6, EColor = EColor.Nature, ProductSourceId = 6, ImgSrc = "../images/Products/Color/Desktop/hylde_natur_1.png" },

                // 600
                new Color { Id = 19, ProductId = 7, EColor = EColor.White, ProductSourceId = 7, ImgSrc = "../images/Products/Color/Desktop/hylde_hvid_1.png" },
                new Color { Id = 20, ProductId = 7, EColor = EColor.Black, ProductSourceId = 8, ImgSrc = "../images/Products/Color/Desktop/hylde_sort_1.png" },
                new Color { Id = 21, ProductId = 7, EColor = EColor.Nature, ProductSourceId = 9, ImgSrc = "../images/Products/Color/Desktop/hylde_natur_1.png" },
                new Color { Id = 22, ProductId = 8, EColor = EColor.White, ProductSourceId = 7, ImgSrc = "../images/Products/Color/Desktop/hylde_hvid_1.png" },
                new Color { Id = 23, ProductId = 8, EColor = EColor.Black, ProductSourceId = 8, ImgSrc = "../images/Products/Color/Desktop/hylde_sort_1.png" },
                new Color { Id = 24, ProductId = 8, EColor = EColor.Nature, ProductSourceId = 9, ImgSrc = "../images/Products/Color/Desktop/hylde_natur_1.png" },
                new Color { Id = 25, ProductId = 9, EColor = EColor.White, ProductSourceId = 7, ImgSrc = "../images/Products/Color/Desktop/hylde_hvid_1.png" },
                new Color { Id = 26, ProductId = 9, EColor = EColor.Black, ProductSourceId = 8, ImgSrc = "../images/Products/Color/Desktop/hylde_sort_1.png" },
                new Color { Id = 27, ProductId = 9, EColor = EColor.Nature, ProductSourceId = 9, ImgSrc = "../images/Products/Color/Desktop/hylde_natur_1.png" },

                // 800
                new Color { Id = 28, ProductId = 10, EColor = EColor.White, ProductSourceId = 10, ImgSrc = "../images/Products/Color/Desktop/hylde_hvid_1.png" },
                new Color { Id = 29, ProductId = 10, EColor = EColor.Black, ProductSourceId = 11, ImgSrc = "../images/Products/Color/Desktop/hylde_sort_1.png" },
                new Color { Id = 30, ProductId = 10, EColor = EColor.Nature, ProductSourceId = 12, ImgSrc = "../images/Products/Color/Desktop/hylde_natur_1.png" },
                new Color { Id = 31, ProductId = 11, EColor = EColor.White, ProductSourceId = 10, ImgSrc = "../images/Products/Color/Desktop/hylde_hvid_1.png" },
                new Color { Id = 32, ProductId = 11, EColor = EColor.Black, ProductSourceId = 11, ImgSrc = "../images/Products/Color/Desktop/hylde_sort_1.png" },
                new Color { Id = 33, ProductId = 11, EColor = EColor.Nature, ProductSourceId = 12, ImgSrc = "../images/Products/Color/Desktop/hylde_natur_1.png" },
                new Color { Id = 34, ProductId = 12, EColor = EColor.White, ProductSourceId = 10, ImgSrc = "../images/Products/Color/Desktop/hylde_hvid_1.png" },
                new Color { Id = 35, ProductId = 12, EColor = EColor.Black, ProductSourceId = 11, ImgSrc = "../images/Products/Color/Desktop/hylde_sort_1.png" },
                new Color { Id = 36, ProductId = 12, EColor = EColor.Nature, ProductSourceId = 12, ImgSrc = "../images/Products/Color/Desktop/hylde_natur_1.png" },

                // 1000
                new Color { Id = 37, ProductId = 13, EColor = EColor.White, ProductSourceId = 13, ImgSrc = "../images/Products/Color/Desktop/hylde_hvid_1.png" },
                new Color { Id = 38, ProductId = 13, EColor = EColor.Black, ProductSourceId = 14, ImgSrc = "../images/Products/Color/Desktop/hylde_sort_1.png" },
                new Color { Id = 39, ProductId = 13, EColor = EColor.Nature, ProductSourceId = 15, ImgSrc = "../images/Products/Color/Desktop/hylde_natur_1.png" },
                new Color { Id = 40, ProductId = 14, EColor = EColor.White, ProductSourceId = 13, ImgSrc = "../images/Products/Color/Desktop/hylde_hvid_1.png" },
                new Color { Id = 41, ProductId = 14, EColor = EColor.Black, ProductSourceId = 14, ImgSrc = "../images/Products/Color/Desktop/hylde_sort_1.png" },
                new Color { Id = 42, ProductId = 14, EColor = EColor.Nature, ProductSourceId = 15, ImgSrc = "../images/Products/Color/Desktop/hylde_natur_1.png" },
                new Color { Id = 43, ProductId = 15, EColor = EColor.White, ProductSourceId = 13, ImgSrc = "../images/Products/Color/Desktop/hylde_hvid_1.png" },
                new Color { Id = 44, ProductId = 15, EColor = EColor.Black, ProductSourceId = 14, ImgSrc = "../images/Products/Color/Desktop/hylde_sort_1.png" },
                new Color { Id = 45, ProductId = 15, EColor = EColor.Nature, ProductSourceId = 15, ImgSrc = "../images/Products/Color/Desktop/hylde_natur_1.png" },

                // bord
                new Color { Id = 46, ProductId = 16, EColor = EColor.Nature, ProductSourceId = 16, ImgSrc = "../images/Products/Color/Desktop/bord_natur_2.png" },
                new Color { Id = 47, ProductId = 16, EColor = EColor.White, ProductSourceId = 17, ImgSrc = "../images/Products/Color/Desktop/bord_hvid_2.png" },
                new Color { Id = 48, ProductId = 17, EColor = EColor.Nature, ProductSourceId = 16, ImgSrc = "../images/Products/Color/Desktop/bord_natur_2.png" },
                new Color { Id = 49, ProductId = 17, EColor = EColor.White, ProductSourceId = 17, ImgSrc = "../images/Products/Color/Desktop/bord_hvid_2.png" },

                // kort bænk
                new Color { Id = 50, ProductId = 18, EColor = EColor.Nature, ProductSourceId = 18, ImgSrc = "../images/Products/Color/Desktop/kortbaenk_natur_2.png" },
                new Color { Id = 51, ProductId = 18, EColor = EColor.White, ProductSourceId = 19, ImgSrc = "../images/Products/Color/Desktop/kortbaenk_hvid_2.png" },
                new Color { Id = 52, ProductId = 18, EColor = EColor.Black, ProductSourceId = 20, ImgSrc = "../images/Products/Color/Desktop/NYKANT_kortbaenk_sortolie_02.png" },
                new Color { Id = 53, ProductId = 19, EColor = EColor.Nature, ProductSourceId = 18, ImgSrc = "../images/Products/Color/Desktop/kortbaenk_natur_2.png" },
                new Color { Id = 54, ProductId = 19, EColor = EColor.White, ProductSourceId = 19, ImgSrc = "../images/Products/Color/Desktop/kortbaenk_hvid_2.png" },
                new Color { Id = 55, ProductId = 19, EColor = EColor.Black, ProductSourceId = 20, ImgSrc = "../images/Products/Color/Desktop/NYKANT_kortbaenk_sortolie_02.png" },
                new Color { Id = 56, ProductId = 20, EColor = EColor.Nature, ProductSourceId = 18, ImgSrc = "../images/Products/Color/Desktop/kortbaenk_natur_2.png" },
                new Color { Id = 57, ProductId = 20, EColor = EColor.White, ProductSourceId = 19, ImgSrc = "../images/Products/Color/Desktop/kortbaenk_hvid_2.png" },
                new Color { Id = 58, ProductId = 20, EColor = EColor.Black, ProductSourceId = 20, ImgSrc = "../images/Products/Color/Desktop/NYKANT_kortbaenk_sortolie_02.png" },

                // lang bænk
                new Color { Id = 59, ProductId = 21, EColor = EColor.Nature, ProductSourceId = 21, ImgSrc = "../images/Products/Color/Desktop/NYKANT_langbaenk_naturolie_02.png" },
                new Color { Id = 60, ProductId = 21, EColor = EColor.White, ProductSourceId = 22, ImgSrc = "../images/Products/Color/Desktop/NYKANT_langbaenk_hvidolie_02.png" },
                new Color { Id = 61, ProductId = 21, EColor = EColor.Black, ProductSourceId = 23, ImgSrc = "../images/Products/Color/Desktop/NYKANT_langbaenk_sortolie_02.png" },
                new Color { Id = 62, ProductId = 22, EColor = EColor.Nature, ProductSourceId = 21, ImgSrc = "../images/Products/Color/Desktop/NYKANT_langbaenk_naturolie_02.png" },
                new Color { Id = 63, ProductId = 22, EColor = EColor.White, ProductSourceId = 22, ImgSrc = "../images/Products/Color/Desktop/NYKANT_langbaenk_hvidolie_02.png" },
                new Color { Id = 64, ProductId = 22, EColor = EColor.Black, ProductSourceId = 23, ImgSrc = "../images/Products/Color/Desktop/NYKANT_langbaenk_sortolie_02.png" },
                new Color { Id = 65, ProductId = 23, EColor = EColor.Nature, ProductSourceId = 21, ImgSrc = "../images/Products/Color/Desktop/NYKANT_langbaenk_naturolie_02.png" },
                new Color { Id = 66, ProductId = 23, EColor = EColor.White, ProductSourceId = 22, ImgSrc = "../images/Products/Color/Desktop/NYKANT_langbaenk_hvidolie_02.png" },
                new Color { Id = 67, ProductId = 23, EColor = EColor.Black, ProductSourceId = 23, ImgSrc = "../images/Products/Color/Desktop/NYKANT_langbaenk_sortolie_02.png" },

                // opbevaringsbænk
                new Color { Id = 68, ProductId = 24, EColor = EColor.Nature, ProductSourceId = 24, ImgSrc = "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png" },
                new Color { Id = 69, ProductId = 24, EColor = EColor.White, ProductSourceId = 25, ImgSrc = "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png" },
                new Color { Id = 70, ProductId = 24, EColor = EColor.Black, ProductSourceId = 26, ImgSrc = "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_sort_01.png" },
                new Color { Id = 71, ProductId = 25, EColor = EColor.Nature, ProductSourceId = 24, ImgSrc = "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png" },
                new Color { Id = 72, ProductId = 25, EColor = EColor.White, ProductSourceId = 25, ImgSrc = "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png" },
                new Color { Id = 73, ProductId = 25, EColor = EColor.Black, ProductSourceId = 26, ImgSrc = "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_sort_01.png" },
                new Color { Id = 74, ProductId = 26, EColor = EColor.Nature, ProductSourceId = 24, ImgSrc = "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png" },
                new Color { Id = 75, ProductId = 26, EColor = EColor.White, ProductSourceId = 25, ImgSrc = "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png" },
                new Color { Id = 76, ProductId = 26, EColor = EColor.Black, ProductSourceId = 26, ImgSrc = "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_sort_01.png" },

                // standing rack
                new Color { Id = 77, ProductId = 27, EColor = EColor.Nature, ProductSourceId = 27, ImgSrc = "../images/Products/Color/Desktop/NYKANT_rack_naturolie_02.png" },
                new Color { Id = 78, ProductId = 27, EColor = EColor.White, ProductSourceId = 28, ImgSrc = "../images/Products/Color/Desktop/NYKANT_rack_hvidolie_02.png" },
                new Color { Id = 79, ProductId = 27, EColor = EColor.Black, ProductSourceId = 29, ImgSrc = "../images/Products/Color/Desktop/NYKANT_rack_sortolie_02.png" },
                new Color { Id = 80, ProductId = 28, EColor = EColor.Nature, ProductSourceId = 27, ImgSrc = "../images/Products/Color/Desktop/NYKANT_rack_naturolie_02.png" },
                new Color { Id = 81, ProductId = 28, EColor = EColor.White, ProductSourceId = 28, ImgSrc = "../images/Products/Color/Desktop/NYKANT_rack_hvidolie_02.png" },
                new Color { Id = 82, ProductId = 28, EColor = EColor.Black, ProductSourceId = 29, ImgSrc = "../images/Products/Color/Desktop/NYKANT_rack_sortolie_02.png" },
                new Color { Id = 83, ProductId = 29, EColor = EColor.Nature, ProductSourceId = 27, ImgSrc = "../images/Products/Color/Desktop/NYKANT_rack_naturolie_02.png" },
                new Color { Id = 84, ProductId = 29, EColor = EColor.White, ProductSourceId = 28, ImgSrc = "../images/Products/Color/Desktop/NYKANT_rack_hvidolie_02.png" },
                new Color { Id = 85, ProductId = 29, EColor = EColor.Black, ProductSourceId = 29, ImgSrc = "../images/Products/Color/Desktop/NYKANT_rack_sortolie_02.png" },

                // hanging rack
                new Color { Id = 86, ProductId = 30, EColor = EColor.Nature, ProductSourceId = 30, ImgSrc = "../images/Products/Color/Desktop/Ingrid_natur_2.png" },
                new Color { Id = 87, ProductId = 30, EColor = EColor.White, ProductSourceId = 31, ImgSrc = "../images/Products/Color/Desktop/Ingrid_hvid_2.png" },
                new Color { Id = 88, ProductId = 30, EColor = EColor.Black, ProductSourceId = 32, ImgSrc = "../images/Products/Color/Desktop/Ingrid_sort_2.png" },
                new Color { Id = 89, ProductId = 31, EColor = EColor.Nature, ProductSourceId = 30, ImgSrc = "../images/Products/Color/Desktop/Ingrid_natur_2.png" },
                new Color { Id = 90, ProductId = 31, EColor = EColor.White, ProductSourceId = 31, ImgSrc = "../images/Products/Color/Desktop/Ingrid_hvid_2.png" },
                new Color { Id = 91, ProductId = 31, EColor = EColor.Black, ProductSourceId = 32, ImgSrc = "../images/Products/Color/Desktop/Ingrid_sort_2.png" },
                new Color { Id = 92, ProductId = 32, EColor = EColor.Nature, ProductSourceId = 30, ImgSrc = "../images/Products/Color/Desktop/Ingrid_natur_2.png" },
                new Color { Id = 93, ProductId = 32, EColor = EColor.White, ProductSourceId = 31, ImgSrc = "../images/Products/Color/Desktop/Ingrid_hvid_2.png" },
                new Color { Id = 94, ProductId = 32, EColor = EColor.Black, ProductSourceId = 32, ImgSrc = "../images/Products/Color/Desktop/Ingrid_sort_2.png" }
                );

            modelBuilder.Entity<Image>().HasData(
                    // Details Slide - Desktop ------------------------------------------------------------------
                    // bøjler
                    new Image { Id = 1, ProductId = 1, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_boejle_naturolie_01.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_boejle_naturolie_01.png" },
                    new Image { Id = 2, ProductId = 1, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_boejle_naturolie_02.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_boejle_naturolie_02.png" },
                    new Image { Id = 3, ProductId = 2, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_boejle_sortolie_01.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_boejle_sortolie_01.png" },
                    new Image { Id = 4, ProductId = 2, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_boejle_sortolie_02.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_boejle_sortolie_02.png" },
                    new Image { Id = 5, ProductId = 3, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_boejle_hvidolie_01.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_boejle_hvidolie_01.png" },
                    new Image { Id = 6, ProductId = 3, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_boejle_hvidolie_02.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_boejle_hvidolie_02.png" },

                    // hylder
                    // 400
                    new Image { Id = 7, ProductId = 4, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_01.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    new Image { Id = 8, ProductId = 4, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_02.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    new Image { Id = 9, ProductId = 4, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_03.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    new Image { Id = 10, ProductId = 5, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_01.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_01.png" },
                    new Image { Id = 11, ProductId = 5, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_02.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_02.png" },
                    new Image { Id = 12, ProductId = 5, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_03.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_03.png" },
                    new Image { Id = 13, ProductId = 6, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_01.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_01.png" },
                    new Image { Id = 14, ProductId = 6, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_02.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_02.png" },
                    new Image { Id = 15, ProductId = 6, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_03.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_03.png" },

                    // 600
                    new Image { Id = 16, ProductId = 7, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_01.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    new Image { Id = 17, ProductId = 7, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_02.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    new Image { Id = 18, ProductId = 7, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_03.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    new Image { Id = 19, ProductId = 8, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_01.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_01.png" },
                    new Image { Id = 20, ProductId = 8, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_02.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_02.png" },
                    new Image { Id = 21, ProductId = 8, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_03.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_03.png" },
                    new Image { Id = 22, ProductId = 9, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_01.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_01.png" },
                    new Image { Id = 23, ProductId = 9, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_02.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_02.png" },
                    new Image { Id = 24, ProductId = 9, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_03.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_03.png" },

                    // 800
                    new Image { Id = 25, ProductId = 10, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_01.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    new Image { Id = 26, ProductId = 10, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_02.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    new Image { Id = 27, ProductId = 10, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_03.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    new Image { Id = 28, ProductId = 11, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_01.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_01.png" },
                    new Image { Id = 29, ProductId = 11, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_02.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_02.png" },
                    new Image { Id = 30, ProductId = 11, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_03.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_03.png" },
                    new Image { Id = 31, ProductId = 12, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_01.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_01.png" },
                    new Image { Id = 32, ProductId = 12, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_02.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_02.png" },
                    new Image { Id = 33, ProductId = 12, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_03.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_03.png" },

                    // 1000
                    new Image { Id = 34, ProductId = 13, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_01.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    new Image { Id = 35, ProductId = 13, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_02.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    new Image { Id = 36, ProductId = 13, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_03.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    new Image { Id = 37, ProductId = 14, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_01.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_01.png" },
                    new Image { Id = 38, ProductId = 14, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_02.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_02.png" },
                    new Image { Id = 39, ProductId = 14, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_03.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_03.png" },
                    new Image { Id = 40, ProductId = 15, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_01.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_01.png" },
                    new Image { Id = 41, ProductId = 15, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_02.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_02.png" },
                    new Image { Id = 42, ProductId = 15, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_03.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_03.png" },

                    // bord
                    new Image { Id = 43, ProductId = 16, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_bord_naturolie_01.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_bord_naturolie_01.png" },
                    new Image { Id = 44, ProductId = 16, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_bord_naturolie_02.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_bord_naturolie_02.png" },
                    new Image { Id = 45, ProductId = 16, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_bord_naturolie_03.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_bord_naturolie_03.png" },
                    new Image { Id = 46, ProductId = 17, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_bord_hvidolie_01.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_bord_hvidolie_01.png" },
                    new Image { Id = 47, ProductId = 17, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_bord_hvidolie_02.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_bord_hvidolie_02.png" },
                    new Image { Id = 48, ProductId = 17, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_bord_hvidolie_03.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_bord_hvidolie_03.png" },

                    // thyra bænk kort
                    new Image { Id = 49, ProductId = 18, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_naturolie_01.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_naturolie_01.png" },
                    new Image { Id = 50, ProductId = 18, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_naturolie_02.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_naturolie_02.png" },
                    new Image { Id = 51, ProductId = 18, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_naturolie_03.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_naturolie_03.png" },
                    new Image { Id = 52, ProductId = 19, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_hvidolie_01.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_hvidolie_01.png" },
                    new Image { Id = 53, ProductId = 19, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_hvidolie_02.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_hvidolie_02.png" },
                    new Image { Id = 54, ProductId = 19, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_hvidolie_03.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_hvidolie_03.png" },
                    new Image { Id = 55, ProductId = 20, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_sortolie_01.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_sortolie_01.png" },
                    new Image { Id = 56, ProductId = 20, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_sortolie_02.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_sortolie_02.png" },
                    new Image { Id = 57, ProductId = 20, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_sortolie_03.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_sortolie_03.png" },

                    // thyra bænk kort
                    new Image { Id = 58, ProductId = 21, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_langbaenk_naturolie_01.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_naturolie_01.png" },
                    new Image { Id = 59, ProductId = 21, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_langbaenk_naturolie_02.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_naturolie_02.png" },
                    new Image { Id = 60, ProductId = 21, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_langbaenk_naturolie_03.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_naturolie_03.png" },
                    new Image { Id = 61, ProductId = 22, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_langbaenk_hvidolie_01.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_hvidolie_01.png" },
                    new Image { Id = 62, ProductId = 22, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_langbaenk_hvidolie_02.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_hvidolie_02.png" },
                    new Image { Id = 63, ProductId = 22, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_langbaenk_hvidolie_03.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_hvidolie_03.png" },
                    new Image { Id = 64, ProductId = 23, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_langbaenk_sortolie_01.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_sortolie_01.png" },
                    new Image { Id = 65, ProductId = 23, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_langbaenk_sortolie_02.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_sortolie_02.png" },
                    new Image { Id = 66, ProductId = 23, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_langbaenk_sortolie_03.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_sortolie_03.png" },

                    // filippa bænk
                    new Image { Id = 67, ProductId = 24, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png" },
                    new Image { Id = 68, ProductId = 24, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_02.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_02.png" },
                    new Image { Id = 69, ProductId = 24, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_03.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_03.png" },
                    new Image { Id = 70, ProductId = 24, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_04.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_04.png" },
                    new Image { Id = 71, ProductId = 24, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_05.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_05.png" },
                    new Image { Id = 72, ProductId = 24, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_06.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_06.png" },
                    new Image { Id = 73, ProductId = 24, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_07.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_07.png" },
                    new Image { Id = 74, ProductId = 25, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png" },
                    new Image { Id = 75, ProductId = 25, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_02.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_02.png" },
                    new Image { Id = 76, ProductId = 25, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_03.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_03.png" },
                    new Image { Id = 77, ProductId = 25, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_04.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_04.png" },
                    new Image { Id = 78, ProductId = 25, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_05.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_05.png" },
                    new Image { Id = 79, ProductId = 25, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_06.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_06.png" },
                    new Image { Id = 80, ProductId = 25, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_07.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_07.png" },
                    new Image { Id = 81, ProductId = 26, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_01.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_01.png" },
                    new Image { Id = 82, ProductId = 26, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_02.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_02.png" },
                    new Image { Id = 83, ProductId = 26, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_03.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_03.png" },
                    new Image { Id = 84, ProductId = 26, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_04.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_04.png" },
                    new Image { Id = 85, ProductId = 26, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_05.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_05.png" },
                    new Image { Id = 86, ProductId = 26, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_06.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_06.png" },
                    new Image { Id = 87, ProductId = 26, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_07.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_07.png" },

                    // nora tøjstativ standing
                    new Image { Id = 88, ProductId = 27, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_01.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_rack_naturolie_01.png" },
                    new Image { Id = 89, ProductId = 27, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_02.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_rack_naturolie_02.png" },
                    new Image { Id = 90, ProductId = 27, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_03.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_rack_naturolie_03.png" },
                    new Image { Id = 91, ProductId = 27, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_04.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_rack_naturolie_04.png" },
                    new Image { Id = 92, ProductId = 27, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_05.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_rack_naturolie_05.png" },
                    new Image { Id = 93, ProductId = 27, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_06.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_rack_naturolie_06.png" },
                    new Image { Id = 94, ProductId = 28, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_01.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_rack_hvidolie_01.png" },
                    new Image { Id = 95, ProductId = 28, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_02.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_rack_hvidolie_01.png" },
                    new Image { Id = 96, ProductId = 28, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_03.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_rack_hvidolie_03.png" },
                    new Image { Id = 97, ProductId = 28, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_04.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_rack_hvidolie_04.png" },
                    new Image { Id = 98, ProductId = 28, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_05.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_rack_hvidolie_05.png" },
                    new Image { Id = 99, ProductId = 28, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_06.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_rack_hvidolie_06.png" },
                    new Image { Id = 100, ProductId = 29, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_01.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_rack_sortolie_01.png" },
                    new Image { Id = 101, ProductId = 29, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_02.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_rack_sortolie_02.png" },
                    new Image { Id = 102, ProductId = 29, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_03.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_rack_sortolie_03.png" },
                    new Image { Id = 103, ProductId = 29, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_04.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_rack_sortolie_04.png" },
                    new Image { Id = 104, ProductId = 29, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_05.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_rack_sortolie_05.png" },
                    new Image { Id = 105, ProductId = 29, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_06.png", Source = "../images/Products/Details_Slide/Desktop/NYKANT_rack_sortolie_06.png" },

                    // ingrid tøjstatic hanging
                    new Image { Id = 106, ProductId = 30, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/Ingrid_Naturolie_1.png", Source = "../images/Products/Details_Slide/Desktop/Ingrid_Naturolie_1.png" },
                    new Image { Id = 107, ProductId = 30, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/Ingrid_Naturolie_2.png", Source = "../images/Products/Details_Slide/Desktop/Ingrid_Naturolie_2.png" },
                    new Image { Id = 108, ProductId = 30, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/Ingrid_Naturolie_3.png", Source = "../images/Products/Details_Slide/Desktop/Ingrid_Naturolie_3.png" },
                    new Image { Id = 109, ProductId = 31, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/Ingrid_Hvidolie_1.png", Source = "../images/Products/Details_Slide/Desktop/Ingrid_Hvidolie_1.png" },
                    new Image { Id = 110, ProductId = 31, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/Ingrid_Hvidolie_2.png", Source = "../images/Products/Details_Slide/Desktop/Ingrid_Hvidolie_2.png" },
                    new Image { Id = 111, ProductId = 31, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/Ingrid_Hvidolie_3.png", Source = "../images/Products/Details_Slide/Desktop/Ingrid_Hvidolie_3.png" },
                    new Image { Id = 112, ProductId = 32, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/Ingrid_Sortolie_1.png", Source = "../images/Products/Details_Slide/Desktop/Ingrid_Sortolie_1.png" },
                    new Image { Id = 113, ProductId = 32, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/Ingrid_Sortolie_2.png", Source = "../images/Products/Details_Slide/Desktop/Ingrid_Sortolie_2.png" },
                    new Image { Id = 114, ProductId = 32, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source2 = "../images/products/Details_Fullscreen/Desktop/Ingrid_Sortolie_3.png", Source = "../images/Products/Details_Slide/Desktop/Ingrid_Sortolie_3.png" },

                    // Details Fullscreen -------------------------------------------------------------------------
                    // bøjler
                    //new Image { Id = 115, ProductId = 1, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_boejle_naturolie_01.png" },
                    //new Image { Id = 116, ProductId = 1, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_boejle_naturolie_02.png" },
                    //new Image { Id = 117, ProductId = 2, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_boejle_sortolie_01.png" },
                    //new Image { Id = 118, ProductId = 2, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_boejle_sortolie_02.png" },
                    //new Image { Id = 119, ProductId = 3, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_boejle_hvidolie_01.png" },
                    //new Image { Id = 120, ProductId = 3, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_boejle_hvidolie_02.png" },

                    //// hylder
                    //// 400
                    //new Image { Id = 121, ProductId = 4, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    //new Image { Id = 122, ProductId = 4, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    //new Image { Id = 123, ProductId = 4, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    //new Image { Id = 124, ProductId = 5, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_01.png" },
                    //new Image { Id = 125, ProductId = 5, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_02.png" },
                    //new Image { Id = 126, ProductId = 5, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_03.png" },
                    //new Image { Id = 127, ProductId = 6, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_01.png" },
                    //new Image { Id = 128, ProductId = 6, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_02.png" },
                    //new Image { Id = 129, ProductId = 6, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_03.png" },

                    //// 600
                    //new Image { Id = 130, ProductId = 7, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    //new Image { Id = 131, ProductId = 7, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    //new Image { Id = 132, ProductId = 7, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    //new Image { Id = 133, ProductId = 8, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_01.png" },
                    //new Image { Id = 134, ProductId = 8, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_02.png" },
                    //new Image { Id = 135, ProductId = 8, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_03.png" },
                    //new Image { Id = 136, ProductId = 9, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_01.png" },
                    //new Image { Id = 137, ProductId = 9, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_02.png" },
                    //new Image { Id = 138, ProductId = 9, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_03.png" },

                    //// 800
                    //new Image { Id = 139, ProductId = 10, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    //new Image { Id = 140, ProductId = 10, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    //new Image { Id = 141, ProductId = 10, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    //new Image { Id = 142, ProductId = 11, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_01.png" },
                    //new Image { Id = 143, ProductId = 11, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_02.png" },
                    //new Image { Id = 144, ProductId = 11, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_03.png" },
                    //new Image { Id = 145, ProductId = 12, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_01.png" },
                    //new Image { Id = 146, ProductId = 12, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_02.png" },
                    //new Image { Id = 147, ProductId = 12, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_03.png" },

                    //// 1000
                    //new Image { Id = 148, ProductId = 13, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    //new Image { Id = 149, ProductId = 13, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    //new Image { Id = 150, ProductId = 13, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    //new Image { Id = 151, ProductId = 14, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_01.png" },
                    //new Image { Id = 152, ProductId = 14, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_02.png" },
                    //new Image { Id = 153, ProductId = 14, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_03.png" },
                    //new Image { Id = 154, ProductId = 15, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_01.png" },
                    //new Image { Id = 155, ProductId = 15, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_02.png" },
                    //new Image { Id = 156, ProductId = 15, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_03.png" },

                    //// bord
                    //new Image { Id = 157, ProductId = 16, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_bord_naturolie_01.png" },
                    //new Image { Id = 158, ProductId = 16, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_bord_naturolie_02.png" },
                    //new Image { Id = 159, ProductId = 16, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_bord_naturolie_03.png" },
                    //new Image { Id = 160, ProductId = 17, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_bord_hvidolie_01.png" },
                    //new Image { Id = 161, ProductId = 17, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_bord_hvidolie_02.png" },
                    //new Image { Id = 162, ProductId = 17, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_bord_hvidolie_03.png" },

                    //// thyra bænk kort
                    //new Image { Id = 163, ProductId = 18, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_naturolie_01.png" },
                    //new Image { Id = 164, ProductId = 18, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_naturolie_02.png" },
                    //new Image { Id = 165, ProductId = 18, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_naturolie_03.png" },
                    //new Image { Id = 166, ProductId = 19, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_hvidolie_01.png" },
                    //new Image { Id = 167, ProductId = 19, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_hvidolie_02.png" },
                    //new Image { Id = 168, ProductId = 19, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_hvidolie_03.png" },
                    //new Image { Id = 169, ProductId = 20, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_sortolie_01.png" },
                    //new Image { Id = 170, ProductId = 20, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_sortolie_02.png" },
                    //new Image { Id = 171, ProductId = 20, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_sortolie_03.png" },

                    //// thyra bænk kort
                    //new Image { Id = 172, ProductId = 21, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_naturolie_01.png" },
                    //new Image { Id = 173, ProductId = 21, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_naturolie_02.png" },
                    //new Image { Id = 174, ProductId = 21, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_naturolie_03.png" },
                    //new Image { Id = 175, ProductId = 22, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_hvidolie_01.png" },
                    //new Image { Id = 176, ProductId = 22, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_hvidolie_02.png" },
                    //new Image { Id = 177, ProductId = 22, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_hvidolie_03.png" },
                    //new Image { Id = 178, ProductId = 23, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_sortolie_01.png" },
                    //new Image { Id = 179, ProductId = 23, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_sortolie_02.png" },
                    //new Image { Id = 180, ProductId = 23, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_sortolie_03.png" },

                    //// filippa bænk
                    //new Image { Id = 181, ProductId = 24, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png" },
                    //new Image { Id = 182, ProductId = 24, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_02.png" },
                    //new Image { Id = 183, ProductId = 24, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_03.png" },
                    //new Image { Id = 184, ProductId = 24, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_04.png" },
                    //new Image { Id = 185, ProductId = 24, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_05.png" },
                    //new Image { Id = 186, ProductId = 24, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_06.png" },
                    //new Image { Id = 187, ProductId = 24, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_07.png" },
                    //new Image { Id = 188, ProductId = 25, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png" },
                    //new Image { Id = 189, ProductId = 25, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_02.png" },
                    //new Image { Id = 190, ProductId = 25, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_03.png" },
                    //new Image { Id = 191, ProductId = 25, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_04.png" },
                    //new Image { Id = 192, ProductId = 25, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_05.png" },
                    //new Image { Id = 193, ProductId = 25, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_06.png" },
                    //new Image { Id = 194, ProductId = 25, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_07.png" },
                    //new Image { Id = 195, ProductId = 26, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_01.png" },
                    //new Image { Id = 196, ProductId = 26, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_02.png" },
                    //new Image { Id = 197, ProductId = 26, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_03.png" },
                    //new Image { Id = 198, ProductId = 26, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_04.png" },
                    //new Image { Id = 199, ProductId = 26, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_05.png" },
                    //new Image { Id = 200, ProductId = 26, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_06.png" },
                    //new Image { Id = 201, ProductId = 26, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_07.png" },

                    //// nora tøjstativ standing
                    //new Image { Id = 202, ProductId = 27, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_01.png" },
                    //new Image { Id = 203, ProductId = 27, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_02.png" },
                    //new Image { Id = 204, ProductId = 27, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_03.png" },
                    //new Image { Id = 205, ProductId = 27, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_04.png" },
                    //new Image { Id = 206, ProductId = 27, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_05.png" },
                    //new Image { Id = 207, ProductId = 27, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_06.png" },
                    //new Image { Id = 208, ProductId = 28, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_01.png" },
                    //new Image { Id = 209, ProductId = 28, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_02.png" },
                    //new Image { Id = 210, ProductId = 28, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_03.png" },
                    //new Image { Id = 211, ProductId = 28, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_04.png" },
                    //new Image { Id = 212, ProductId = 28, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_05.png" },
                    //new Image { Id = 213, ProductId = 28, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_06.png" },
                    //new Image { Id = 214, ProductId = 29, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_01.png" },
                    //new Image { Id = 215, ProductId = 29, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_02.png" },
                    //new Image { Id = 216, ProductId = 29, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_03.png" },
                    //new Image { Id = 217, ProductId = 29, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_04.png" },
                    //new Image { Id = 218, ProductId = 29, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_05.png" },
                    //new Image { Id = 219, ProductId = 29, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_06.png" },

                    //// ingrid tøjstatic hanging
                    //new Image { Id = 220, ProductId = 30, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/Ingrid_Naturolie_1.png" },
                    //new Image { Id = 221, ProductId = 30, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/Ingrid_Naturolie_2.png" },
                    //new Image { Id = 222, ProductId = 30, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/Ingrid_Naturolie_3.png" },
                    //new Image { Id = 223, ProductId = 31, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/Ingrid_Hvidolie_1.png" },
                    //new Image { Id = 224, ProductId = 31, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/Ingrid_Hvidolie_2.png" },
                    //new Image { Id = 225, ProductId = 31, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/Ingrid_Hvidolie_3.png" },
                    //new Image { Id = 226, ProductId = 32, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/Ingrid_Sortolie_1.png" },
                    //new Image { Id = 227, ProductId = 32, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/Ingrid_Sortolie_2.png" },
                    //new Image { Id = 228, ProductId = 32, ImageType = ImageType.DetailsSlide, Size = Size.Desktop, Source = "../images/Products/Details_Fullscreen/Desktop/Ingrid_Sortolie_3.png" },

                    // Details Button -----------------------------------------------------------------------------
                    // bøjler
                    new Image { Id = 229, ProductId = 1, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_boejle_naturolie_01.png" },
                    new Image { Id = 230, ProductId = 1, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_boejle_naturolie_02.png" },
                    new Image { Id = 231, ProductId = 2, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_boejle_sortolie_01.png" },
                    new Image { Id = 232, ProductId = 2, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_boejle_sortolie_02.png" },
                    new Image { Id = 233, ProductId = 3, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_boejle_hvidolie_01.png" },
                    new Image { Id = 234, ProductId = 3, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_boejle_hvidolie_02.png" },

                    // hylder
                    // 400
                    new Image { Id = 235, ProductId = 4, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    new Image { Id = 236, ProductId = 4, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    new Image { Id = 237, ProductId = 4, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    new Image { Id = 238, ProductId = 5, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_01.png" },
                    new Image { Id = 239, ProductId = 5, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_02.png" },
                    new Image { Id = 240, ProductId = 5, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_03.png" },
                    new Image { Id = 241, ProductId = 6, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_01.png" },
                    new Image { Id = 242, ProductId = 6, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_02.png" },
                    new Image { Id = 243, ProductId = 6, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_03.png" },

                    // 600
                    new Image { Id = 244, ProductId = 7, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    new Image { Id = 245, ProductId = 7, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    new Image { Id = 246, ProductId = 7, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    new Image { Id = 247, ProductId = 8, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_01.png" },
                    new Image { Id = 248, ProductId = 8, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_02.png" },
                    new Image { Id = 249, ProductId = 8, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_03.png" },
                    new Image { Id = 250, ProductId = 9, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_01.png" },
                    new Image { Id = 251, ProductId = 9, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_02.png" },
                    new Image { Id = 252, ProductId = 9, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_03.png" },

                    // 800
                    new Image { Id = 253, ProductId = 10, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    new Image { Id = 254, ProductId = 10, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    new Image { Id = 255, ProductId = 10, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    new Image { Id = 256, ProductId = 11, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_01.png" },
                    new Image { Id = 257, ProductId = 11, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_02.png" },
                    new Image { Id = 258, ProductId = 11, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_03.png" },
                    new Image { Id = 259, ProductId = 12, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_01.png" },
                    new Image { Id = 260, ProductId = 12, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_02.png" },
                    new Image { Id = 261, ProductId = 12, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_03.png" },

                    // 1000
                    new Image { Id = 262, ProductId = 13, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    new Image { Id = 263, ProductId = 13, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    new Image { Id = 264, ProductId = 13, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    new Image { Id = 265, ProductId = 14, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_01.png" },
                    new Image { Id = 266, ProductId = 14, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_02.png" },
                    new Image { Id = 267, ProductId = 14, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_03.png" },
                    new Image { Id = 268, ProductId = 15, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_01.png" },
                    new Image { Id = 269, ProductId = 15, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_02.png" },
                    new Image { Id = 270, ProductId = 15, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_03.png" },

                    // bord
                    new Image { Id = 271, ProductId = 16, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_bord_naturolie_01.png" },
                    new Image { Id = 272, ProductId = 16, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_bord_naturolie_02.png" },
                    new Image { Id = 273, ProductId = 16, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_bord_naturolie_03.png" },
                    new Image { Id = 274, ProductId = 17, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_bord_hvidolie_01.png" },
                    new Image { Id = 275, ProductId = 17, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_bord_hvidolie_02.png" },
                    new Image { Id = 276, ProductId = 17, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_bord_hvidolie_03.png" },

                    // thyra bænk kort
                    new Image { Id = 277, ProductId = 18, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_naturolie_01.png" },
                    new Image { Id = 278, ProductId = 18, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_naturolie_02.png" },
                    new Image { Id = 279, ProductId = 18, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_naturolie_03.png" },
                    new Image { Id = 280, ProductId = 19, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_hvidolie_01.png" },
                    new Image { Id = 281, ProductId = 19, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_hvidolie_02.png" },
                    new Image { Id = 282, ProductId = 19, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_hvidolie_03.png" },
                    new Image { Id = 283, ProductId = 20, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_sortolie_01.png" },
                    new Image { Id = 284, ProductId = 20, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_sortolie_02.png" },
                    new Image { Id = 285, ProductId = 20, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_sortolie_03.png" },

                    // thyra bænk kort
                    new Image { Id = 286, ProductId = 21, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_naturolie_01.png" },
                    new Image { Id = 287, ProductId = 21, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_naturolie_02.png" },
                    new Image { Id = 288, ProductId = 21, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_naturolie_03.png" },
                    new Image { Id = 289, ProductId = 22, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_hvidolie_01.png" },
                    new Image { Id = 290, ProductId = 22, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_hvidolie_02.png" },
                    new Image { Id = 291, ProductId = 22, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_hvidolie_03.png" },
                    new Image { Id = 292, ProductId = 23, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_sortolie_01.png" },
                    new Image { Id = 293, ProductId = 23, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_sortolie_02.png" },
                    new Image { Id = 294, ProductId = 23, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_sortolie_03.png" },

                    // filippa bænk
                    new Image { Id = 295, ProductId = 24, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png" },
                    new Image { Id = 296, ProductId = 24, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_02.png" },
                    new Image { Id = 297, ProductId = 24, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_03.png" },
                    new Image { Id = 298, ProductId = 24, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_04.png" },
                    new Image { Id = 299, ProductId = 24, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_05.png" },
                    new Image { Id = 300, ProductId = 24, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_06.png" },
                    new Image { Id = 301, ProductId = 24, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_07.png" },
                    new Image { Id = 302, ProductId = 25, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png" },
                    new Image { Id = 303, ProductId = 25, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_02.png" },
                    new Image { Id = 304, ProductId = 25, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_03.png" },
                    new Image { Id = 305, ProductId = 25, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_04.png" },
                    new Image { Id = 306, ProductId = 25, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_05.png" },
                    new Image { Id = 307, ProductId = 25, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_06.png" },
                    new Image { Id = 308, ProductId = 25, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_07.png" },
                    new Image { Id = 309, ProductId = 26, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_01.png" },
                    new Image { Id = 310, ProductId = 26, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_02.png" },
                    new Image { Id = 311, ProductId = 26, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_03.png" },
                    new Image { Id = 312, ProductId = 26, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_04.png" },
                    new Image { Id = 314, ProductId = 26, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_05.png" },
                    new Image { Id = 315, ProductId = 26, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_06.png" },
                    new Image { Id = 316, ProductId = 26, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_07.png" },

                    // nora tøjstativ standing
                    new Image { Id = 317, ProductId = 27, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_rack_naturolie_01.png" },
                    new Image { Id = 318, ProductId = 27, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_rack_naturolie_02.png" },
                    new Image { Id = 319, ProductId = 27, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_rack_naturolie_03.png" },
                    new Image { Id = 320, ProductId = 27, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_rack_naturolie_04.png" },
                    new Image { Id = 321, ProductId = 27, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_rack_naturolie_05.png" },
                    new Image { Id = 322, ProductId = 27, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_rack_naturolie_06.png" },
                    new Image { Id = 323, ProductId = 28, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_rack_hvidolie_01.png" },
                    new Image { Id = 324, ProductId = 28, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_rack_hvidolie_02.png" },
                    new Image { Id = 325, ProductId = 28, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_rack_hvidolie_03.png" },
                    new Image { Id = 326, ProductId = 28, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_rack_hvidolie_04.png" },
                    new Image { Id = 327, ProductId = 28, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_rack_hvidolie_05.png" },
                    new Image { Id = 328, ProductId = 28, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_rack_hvidolie_06.png" },
                    new Image { Id = 329, ProductId = 29, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_rack_sortolie_01.png" },
                    new Image { Id = 330, ProductId = 29, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_rack_sortolie_02.png" },
                    new Image { Id = 331, ProductId = 29, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_rack_sortolie_03.png" },
                    new Image { Id = 332, ProductId = 29, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_rack_sortolie_04.png" },
                    new Image { Id = 333, ProductId = 29, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_rack_sortolie_05.png" },
                    new Image { Id = 334, ProductId = 29, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/NYKANT_rack_sortolie_06.png" },

                    // ingrid tøjstatic hanging
                    new Image { Id = 335, ProductId = 30, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/Ingrid_Naturolie_1.png" },
                    new Image { Id = 336, ProductId = 30, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/Ingrid_Naturolie_2.png" },
                    new Image { Id = 337, ProductId = 30, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/Ingrid_Naturolie_3.png" },
                    new Image { Id = 338, ProductId = 31, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/Ingrid_Hvidolie_1.png" },
                    new Image { Id = 339, ProductId = 31, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/Ingrid_Hvidolie_2.png" },
                    new Image { Id = 340, ProductId = 31, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/Ingrid_Hvidolie_3.png" },
                    new Image { Id = 341, ProductId = 32, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/Ingrid_Sortolie_1.png" },
                    new Image { Id = 342, ProductId = 32, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/Ingrid_Sortolie_2.png" },
                    new Image { Id = 343, ProductId = 32, ImageType = ImageType.DetailsButton, Size = Size.Desktop, Source = "../images/Products/Details_Button/Desktop/Ingrid_Sortolie_3.png" }
             );

            modelBuilder.Entity<ProductLength>().HasData(

                // 1150
                new ProductLength { Id = 1, ProductId = 18, ProductReferenceId = 18, Length = "1150 mm." },
                new ProductLength { Id = 2, ProductId = 18, ProductReferenceId = 21, Length = "1700 mm." },
                new ProductLength { Id = 3, ProductId = 19, ProductReferenceId = 18, Length = "1150 mm." },
                new ProductLength { Id = 4, ProductId = 19, ProductReferenceId = 21, Length = "1700 mm." },
                new ProductLength { Id = 5, ProductId = 20, ProductReferenceId = 18, Length = "1150 mm." },
                new ProductLength { Id = 6, ProductId = 20, ProductReferenceId = 21, Length = "1700 mm." },

                // 1700
                new ProductLength { Id = 7, ProductId = 21, ProductReferenceId = 18, Length = "1150 mm." },
                new ProductLength { Id = 8, ProductId = 21, ProductReferenceId = 21, Length = "1700 mm." },
                new ProductLength { Id = 9, ProductId = 22, ProductReferenceId = 18, Length = "1150 mm." },
                new ProductLength { Id = 10, ProductId = 22, ProductReferenceId = 21, Length = "1700 mm." },
                new ProductLength { Id = 11, ProductId = 23, ProductReferenceId = 18, Length = "1150 mm." },
                new ProductLength { Id = 12, ProductId = 23, ProductReferenceId = 21, Length = "1700 mm." },

                // 400
                new ProductLength { Id = 13, ProductId = 4, ProductReferenceId = 6, Length = "400 mm." },
                new ProductLength { Id = 14, ProductId = 4, ProductReferenceId = 9, Length = "600 mm." },
                new ProductLength { Id = 15, ProductId = 4, ProductReferenceId = 12, Length = "800 mm." },
                new ProductLength { Id = 16, ProductId = 4, ProductReferenceId = 15, Length = "1000 mm." },
                new ProductLength { Id = 17, ProductId = 5, ProductReferenceId = 6, Length = "400 mm." },
                new ProductLength { Id = 18, ProductId = 5, ProductReferenceId = 9, Length = "600 mm." },
                new ProductLength { Id = 19, ProductId = 5, ProductReferenceId = 12, Length = "800 mm." },
                new ProductLength { Id = 20, ProductId = 5, ProductReferenceId = 15, Length = "1000 mm." },
                new ProductLength { Id = 21, ProductId = 6, ProductReferenceId = 6, Length = "400 mm." },
                new ProductLength { Id = 22, ProductId = 6, ProductReferenceId = 9, Length = "600 mm." },
                new ProductLength { Id = 23, ProductId = 6, ProductReferenceId = 12, Length = "800 mm." },
                new ProductLength { Id = 24, ProductId = 6, ProductReferenceId = 15, Length = "1000 mm." },

                // 600
                new ProductLength { Id = 25, ProductId = 7, ProductReferenceId = 6, Length = "400 mm." },
                new ProductLength { Id = 26, ProductId = 7, ProductReferenceId = 9, Length = "600 mm." },
                new ProductLength { Id = 27, ProductId = 7, ProductReferenceId = 12, Length = "800 mm." },
                new ProductLength { Id = 28, ProductId = 7, ProductReferenceId = 15, Length = "1000 mm." },
                new ProductLength { Id = 29, ProductId = 8, ProductReferenceId = 6, Length = "400 mm." },
                new ProductLength { Id = 30, ProductId = 8, ProductReferenceId = 9, Length = "600 mm." },
                new ProductLength { Id = 31, ProductId = 8, ProductReferenceId = 12, Length = "800 mm." },
                new ProductLength { Id = 32, ProductId = 8, ProductReferenceId = 15, Length = "1000 mm." },
                new ProductLength { Id = 33, ProductId = 9, ProductReferenceId = 6, Length = "400 mm." },
                new ProductLength { Id = 34, ProductId = 9, ProductReferenceId = 9, Length = "600 mm." },
                new ProductLength { Id = 35, ProductId = 9, ProductReferenceId = 12, Length = "800 mm." },
                new ProductLength { Id = 36, ProductId = 9, ProductReferenceId = 16, Length = "1000 mm." },

                // 800
                new ProductLength { Id = 37, ProductId = 10, ProductReferenceId = 6, Length = "400 mm." },
                new ProductLength { Id = 38, ProductId = 10, ProductReferenceId = 9, Length = "600 mm." },
                new ProductLength { Id = 39, ProductId = 10, ProductReferenceId = 12, Length = "800 mm." },
                new ProductLength { Id = 40, ProductId = 10, ProductReferenceId = 15, Length = "1000 mm." },
                new ProductLength { Id = 41, ProductId = 11, ProductReferenceId = 6, Length = "400 mm." },
                new ProductLength { Id = 42, ProductId = 11, ProductReferenceId = 9, Length = "600 mm." },
                new ProductLength { Id = 43, ProductId = 11, ProductReferenceId = 12, Length = "800 mm." },
                new ProductLength { Id = 44, ProductId = 11, ProductReferenceId = 15, Length = "1000 mm." },
                new ProductLength { Id = 45, ProductId = 12, ProductReferenceId = 6, Length = "400 mm." },
                new ProductLength { Id = 46, ProductId = 12, ProductReferenceId = 9, Length = "600 mm." },
                new ProductLength { Id = 47, ProductId = 12, ProductReferenceId = 12, Length = "800 mm." },
                new ProductLength { Id = 48, ProductId = 12, ProductReferenceId = 15, Length = "1000 mm." },

                // 1000
                new ProductLength { Id = 49, ProductId = 13, ProductReferenceId = 6, Length = "400 mm." },
                new ProductLength { Id = 50, ProductId = 13, ProductReferenceId = 9, Length = "600 mm." },
                new ProductLength { Id = 51, ProductId = 13, ProductReferenceId = 12, Length = "800 mm." },
                new ProductLength { Id = 52, ProductId = 13, ProductReferenceId = 15, Length = "1000 mm." },
                new ProductLength { Id = 53, ProductId = 14, ProductReferenceId = 6, Length = "400 mm." },
                new ProductLength { Id = 54, ProductId = 14, ProductReferenceId = 9, Length = "600 mm." },
                new ProductLength { Id = 55, ProductId = 14, ProductReferenceId = 12, Length = "800 mm." },
                new ProductLength { Id = 56, ProductId = 14, ProductReferenceId = 15, Length = "1000 mm." },
                new ProductLength { Id = 57, ProductId = 15, ProductReferenceId = 6, Length = "400 mm." },
                new ProductLength { Id = 58, ProductId = 15, ProductReferenceId = 9, Length = "600 mm." },
                new ProductLength { Id = 59, ProductId = 15, ProductReferenceId = 12, Length = "800 mm." },
                new ProductLength { Id = 60, ProductId = 15, ProductReferenceId = 15, Length = "1000 mm." }
                );
        }
    }
}
