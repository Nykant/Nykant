﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nykant.Data;

namespace Nykant.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210107091332_update-2")]
    partial class update2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Nykant.Models.CartItem", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("Nykant.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Session")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

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

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfWood")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "naturligt",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ItemType = "stol",
                            LastModified = new DateTime(2021, 1, 7, 10, 13, 31, 870, DateTimeKind.Local).AddTicks(9837),
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
                            LastModified = new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(3962),
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
                            LastModified = new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4028),
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
                            LastModified = new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4033),
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
                            LastModified = new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4036),
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
                            LastModified = new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4039),
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
                            LastModified = new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4042),
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
                            LastModified = new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4044),
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
                            LastModified = new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4047),
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
                            LastModified = new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4049),
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
                            LastModified = new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4052),
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
                            LastModified = new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4055),
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
                            LastModified = new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4057),
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
                            LastModified = new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4060),
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
                            LastModified = new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4062),
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
                            LastModified = new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4065),
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
                            LastModified = new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4068),
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
                            LastModified = new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4070),
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
                            LastModified = new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4073),
                            Price = 1000,
                            Size = "5mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "valnød"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
