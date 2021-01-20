﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nykant.Data;

namespace Nykant.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Nykant.Models.Bag", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId");

                    b.ToTable("Bags");
                });

            modelBuilder.Entity("Nykant.Models.BagItem", b =>
                {
                    b.Property<string>("BagId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("BagId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("BagItems");
                });

            modelBuilder.Entity("Nykant.Models.CustomerInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CustomerInfos");
                });

            modelBuilder.Entity("Nykant.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductId = 1,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 2,
                            ProductId = 2,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 3,
                            ProductId = 3,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 4,
                            ProductId = 4,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 5,
                            ProductId = 5,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 6,
                            ProductId = 6,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 7,
                            ProductId = 7,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 8,
                            ProductId = 8,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 9,
                            ProductId = 9,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 10,
                            ProductId = 10,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 11,
                            ProductId = 11,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 12,
                            ProductId = 12,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 13,
                            ProductId = 13,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 14,
                            ProductId = 14,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 15,
                            ProductId = 15,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 16,
                            ProductId = 16,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 17,
                            ProductId = 17,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 18,
                            ProductId = 18,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 19,
                            ProductId = 19,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 20,
                            ProductId = 1,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 21,
                            ProductId = 2,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 22,
                            ProductId = 3,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 23,
                            ProductId = 4,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 24,
                            ProductId = 5,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 25,
                            ProductId = 6,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 26,
                            ProductId = 7,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 27,
                            ProductId = 8,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 28,
                            ProductId = 9,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 29,
                            ProductId = 10,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 30,
                            ProductId = 11,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 31,
                            ProductId = 12,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 32,
                            ProductId = 13,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 33,
                            ProductId = 14,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 34,
                            ProductId = 15,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 35,
                            ProductId = 16,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 36,
                            ProductId = 17,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 37,
                            ProductId = 18,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 38,
                            ProductId = 19,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        });
                });

            modelBuilder.Entity("Nykant.Models.Order", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Nykant.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BagUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageSource")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfWood")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BagUserId");

                    b.HasIndex("OrderUserId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "naturligt",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ItemType = "stol",
                            LastModified = new DateTime(2021, 1, 20, 9, 45, 50, 137, DateTimeKind.Local).AddTicks(258),
                            Price = 1000,
                            Size = "5mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "valnød"
                        },
                        new
                        {
                            Id = 2,
                            Color = "farvet-overflade",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ItemType = "stol",
                            LastModified = new DateTime(2021, 1, 20, 9, 45, 50, 139, DateTimeKind.Local).AddTicks(6192),
                            Price = 1000,
                            Size = "10mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "eg"
                        },
                        new
                        {
                            Id = 3,
                            Color = "naturligt",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ItemType = "bænk",
                            LastModified = new DateTime(2021, 1, 20, 9, 45, 50, 139, DateTimeKind.Local).AddTicks(6263),
                            Price = 1000,
                            Size = "20mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "fyr"
                        },
                        new
                        {
                            Id = 4,
                            Color = "farvet-overflade",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ItemType = "skærebræt",
                            LastModified = new DateTime(2021, 1, 20, 9, 45, 50, 139, DateTimeKind.Local).AddTicks(6269),
                            Price = 1000,
                            Size = "5mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "eg"
                        },
                        new
                        {
                            Id = 5,
                            Color = "naturligt",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ItemType = "bænk",
                            LastModified = new DateTime(2021, 1, 20, 9, 45, 50, 139, DateTimeKind.Local).AddTicks(6272),
                            Price = 1000,
                            Size = "10mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "valnød"
                        },
                        new
                        {
                            Id = 6,
                            Color = "farvet-overflade",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ItemType = "skærebræt",
                            LastModified = new DateTime(2021, 1, 20, 9, 45, 50, 139, DateTimeKind.Local).AddTicks(6275),
                            Price = 1000,
                            Size = "20mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "fyr"
                        },
                        new
                        {
                            Id = 7,
                            Color = "naturligt",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ItemType = "stol",
                            LastModified = new DateTime(2021, 1, 20, 9, 45, 50, 139, DateTimeKind.Local).AddTicks(6278),
                            Price = 1000,
                            Size = "5mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "valnød"
                        },
                        new
                        {
                            Id = 8,
                            Color = "farvet-overflade",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ItemType = "stol",
                            LastModified = new DateTime(2021, 1, 20, 9, 45, 50, 139, DateTimeKind.Local).AddTicks(6282),
                            Price = 1000,
                            Size = "10mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "eg"
                        },
                        new
                        {
                            Id = 9,
                            Color = "naturligt",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ItemType = "bænk",
                            LastModified = new DateTime(2021, 1, 20, 9, 45, 50, 139, DateTimeKind.Local).AddTicks(6285),
                            Price = 1000,
                            Size = "20mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "fyr"
                        },
                        new
                        {
                            Id = 10,
                            Color = "farvet-overflade",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ItemType = "skærebræt",
                            LastModified = new DateTime(2021, 1, 20, 9, 45, 50, 139, DateTimeKind.Local).AddTicks(6287),
                            Price = 1000,
                            Size = "5mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "eg"
                        },
                        new
                        {
                            Id = 11,
                            Color = "naturligt",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ItemType = "bænk",
                            LastModified = new DateTime(2021, 1, 20, 9, 45, 50, 139, DateTimeKind.Local).AddTicks(6290),
                            Price = 1000,
                            Size = "10mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "valnød"
                        },
                        new
                        {
                            Id = 12,
                            Color = "farvet-overflade",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ItemType = "skærebræt",
                            LastModified = new DateTime(2021, 1, 20, 9, 45, 50, 139, DateTimeKind.Local).AddTicks(6293),
                            Price = 1000,
                            Size = "20mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "fyr"
                        },
                        new
                        {
                            Id = 13,
                            Color = "naturligt",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ItemType = "stol",
                            LastModified = new DateTime(2021, 1, 20, 9, 45, 50, 139, DateTimeKind.Local).AddTicks(6296),
                            Price = 1000,
                            Size = "5mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "valnød"
                        },
                        new
                        {
                            Id = 14,
                            Color = "farvet-overflade",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ItemType = "stol",
                            LastModified = new DateTime(2021, 1, 20, 9, 45, 50, 139, DateTimeKind.Local).AddTicks(6298),
                            Price = 1000,
                            Size = "10mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "eg"
                        },
                        new
                        {
                            Id = 15,
                            Color = "naturligt",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ItemType = "bænk",
                            LastModified = new DateTime(2021, 1, 20, 9, 45, 50, 139, DateTimeKind.Local).AddTicks(6301),
                            Price = 1000,
                            Size = "20mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "fyr"
                        },
                        new
                        {
                            Id = 16,
                            Color = "farvet-overflade",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ItemType = "skærebræt",
                            LastModified = new DateTime(2021, 1, 20, 9, 45, 50, 139, DateTimeKind.Local).AddTicks(6347),
                            Price = 1000,
                            Size = "5mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "eg"
                        },
                        new
                        {
                            Id = 17,
                            Color = "naturligt",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ItemType = "bænk",
                            LastModified = new DateTime(2021, 1, 20, 9, 45, 50, 139, DateTimeKind.Local).AddTicks(6351),
                            Price = 1000,
                            Size = "10mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "valnød"
                        },
                        new
                        {
                            Id = 18,
                            Color = "farvet-overflade",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ItemType = "skærebræt",
                            LastModified = new DateTime(2021, 1, 20, 9, 45, 50, 139, DateTimeKind.Local).AddTicks(6354),
                            Price = 1000,
                            Size = "20mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "fyr"
                        },
                        new
                        {
                            Id = 19,
                            Color = "naturligt",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ItemType = "bænk",
                            LastModified = new DateTime(2021, 1, 20, 9, 45, 50, 139, DateTimeKind.Local).AddTicks(6356),
                            Price = 1000,
                            Size = "5mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "valnød"
                        });
                });

            modelBuilder.Entity("Nykant.Models.BagItem", b =>
                {
                    b.HasOne("Nykant.Models.Bag", "Bag")
                        .WithMany("BagItems")
                        .HasForeignKey("BagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nykant.Models.Product", "Product")
                        .WithMany("BagItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Nykant.Models.Image", b =>
                {
                    b.HasOne("Nykant.Models.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Nykant.Models.Product", b =>
                {
                    b.HasOne("Nykant.Models.Bag", null)
                        .WithMany("Products")
                        .HasForeignKey("BagUserId");

                    b.HasOne("Nykant.Models.Order", null)
                        .WithMany("Products")
                        .HasForeignKey("OrderUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
