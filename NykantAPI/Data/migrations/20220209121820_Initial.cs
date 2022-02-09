using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.Data.migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ImgSource = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cookies",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Type1 = table.Column<int>(nullable: false),
                    Type2 = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cookies", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsSubs",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsSubs", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    GalleryImage1 = table.Column<string>(nullable: true),
                    GalleryImage2 = table.Column<string>(nullable: true),
                    Pieces = table.Column<int>(nullable: false),
                    Path = table.Column<string>(nullable: true),
                    ExpectedDelivery = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    AssemblyPath = table.Column<string>(nullable: true),
                    EColor = table.Column<int>(nullable: false),
                    Length = table.Column<string>(nullable: true),
                    Oil = table.Column<string>(nullable: true),
                    Alt = table.Column<string>(nullable: true),
                    WeightInKg = table.Column<double>(nullable: false),
                    Size = table.Column<string>(nullable: true),
                    Materials = table.Column<string>(nullable: true),
                    Package = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillingAddress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    Postal = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillingAddress_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Subject = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<string>(nullable: false),
                    Taxes = table.Column<string>(nullable: false),
                    TaxLessPrice = table.Column<string>(nullable: false),
                    Currency = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    WeightInKg = table.Column<double>(nullable: false),
                    EstimatedDelivery = table.Column<DateTime>(nullable: false),
                    IsBackOrder = table.Column<bool>(nullable: false),
                    PaymentIntent_Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShippingAddress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    Postal = table.Column<string>(nullable: false),
                    SameAsBilling = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingAddress_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BagItems",
                columns: table => new
                {
                    Subject = table.Column<string>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BagItems", x => new { x.Subject, x.ProductId });
                    table.ForeignKey(
                        name: "FK_BagItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: false),
                    ImgSrc = table.Column<string>(nullable: true),
                    ProductSourceId = table.Column<int>(nullable: false),
                    EColor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colors_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Source = table.Column<string>(nullable: true),
                    Source2 = table.Column<string>(nullable: true),
                    ImageType = table.Column<int>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductLength",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: false),
                    ProductReferenceId = table.Column<int>(nullable: false),
                    Length = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLength", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductLength_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: false),
                    Subject = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: false),
                    Stars = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShippingDeliveries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    NotHomeNote = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingDeliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingDeliveries_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParcelshopData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ShippingDeliveryId = table.Column<int>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    Streetname = table.Column<string>(nullable: true),
                    Streetname2 = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    CityName = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true),
                    CountryCodeISO3166A2 = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    DistanceMetersAsTheCrowFlies = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelshopData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParcelshopData_ShippingDeliveries_ShippingDeliveryId",
                        column: x => x.ShippingDeliveryId,
                        principalTable: "ShippingDeliveries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImgSource", "Name" },
                values: new object[,]
                {
                    { 1, "../Images/Products/Category/Desktop/ingrid_natur_2.png", "Tøjstativer" },
                    { 2, "../Images/Products/Category/Desktop/bord_natur_2.png", "Borde" },
                    { 3, "../Images/Products/Category/Desktop/hylde_natur_1.png", "Hylder" },
                    { 4, "../Images/Products/Category/Desktop/opbevaringsbaenk_natur_3.png", "Bænke" },
                    { 5, "../Images/Products/Category/Desktop/boejle_natur_1.png", "Bøjler" }
                });

            migrationBuilder.InsertData(
                table: "Cookies",
                columns: new[] { "Name", "Category", "Description", "Type1", "Type2" },
                values: new object[,]
                {
                    { "Culture", 1, "Denne cookie gemmer din præference for sprog.", 1, 0 },
                    { "AntiforgeryToken", 0, "Denne cookie beskytter imod Cross-Site Request Forgery angreb", 0, 0 },
                    { "Session", 0, "Denne cookie husker/gemmer hvad du har lagt i din kurv, samt giver dig en bedre checkout oplevelse.", 0, 0 },
                    { "__stripe_mid", 0, "Denne cookie bruges af Stripe og sørger for at vores betalingsservice virker, og er sikker.", 1, 1 },
                    { "__stripe_sid", 0, "Denne cookie bruges af Stripe og sørger for at vores betalingsservice virker, og er sikker.", 1, 1 },
                    { "_ga", 3, "Denne cookie bruges af Google Analytics og registrere et unikt ID, som bliver brugt til at generere statistiske data om hvordan besøgende bruger hjemmesiden.", 1, 1 },
                    { "_ga_2LWYP6ZC27", 3, "Denne cookie bruges af Google Analytics og indsamler data så som hvor mange gange en bruger har besøgt siden, datoen de har besøgt og det seneste besøg.", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Alt", "Amount", "AssemblyPath", "CategoryId", "Description", "EColor", "ExpectedDelivery", "GalleryImage1", "GalleryImage2", "Length", "Materials", "Name", "Note", "Number", "Oil", "Package", "Path", "Pieces", "Price", "Size", "Title", "WeightInKg" },
                values: new object[,]
                {
                    { 27, null, 26, "/word/Tøjstativ.docx", 1, "Nora Description", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_rack_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_rack_naturolie_02.png", null, "Nora Materials", "Nora Tøjstativ", "Nora Note", "13001 + 13001A", "Naturolie", "Nora Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", 1, 2595.0, "Nora Size", "Tøjstativ i massivt egetræ - Behandlet med naturolie", 8.0 },
                    { 1, null, 0, "none", 5, "Gertrud Description", 0, new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_boejle_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_boejle_naturolie_02.png", null, "Gertrud Materials", "Bøjlen Gertrud / 3 stk.", "Gertrud Note", "15001", "Naturolie", "Gertrud Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_boejle_naturolie_01.png", 3, 420.0, "Gertrud Size", "Bøjle i massivt egetræ - Behandlet med naturolie", 11.6 },
                    { 26, null, 20, "none", 4, "Filippa Description", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_opbevaringsbaenk_sort_01.png", "../images/Products/Gallery/Desktop/NYKANT_opbevaringsbaenk_sort_02.png", null, "Filippa Materials", "Filippa Bænk", "Filippa Note", "10003", "Sortolie", "Filippa Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", 1, 4985.0, "Filippa Size", "Opbevaringsbænk i massivt egetræ - Behandlet med sortolie", 24.0 },
                    { 25, null, 30, "none", 4, "Filippa Description", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_opbevaringsbaenk_hvidolie_02.png", null, "Filippa Materials", "Filippa Bænk", "Filippa Note", "10002", "Hvidolie", "Filippa Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", 1, 4985.0, "Filippa Size", "Opbevaringsbænk i massivt egetræ - Behandlet med hvidolie", 24.0 },
                    { 24, null, 50, "none", 4, "Filippa Description", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_opbevaringsbaenk_naturolie_02.png", null, "Filippa Materials", "Filippa Bænk", "Filippa Note", "10001", "Naturolie", "Filippa Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", 1, 4985.0, "Filippa Size", "Opbevaringsbænk i massivt egetræ - Behandlet med naturolie", 24.0 },
                    { 23, null, 5, "/word/bænk.docx", 4, "Thyra Description", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_langbaenk_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_langbaenk_sortolie_02.png", "1700 mm.", "Thyra Materials", "Thyra Bænken", "Thyra Note", "11003", "Sortolie", "Thyra Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_langbaenk_naturolie_01.png", 1, 4395.0, "Thyra Size", "Bænk i massivt egetræ - Behandlet med sortolie", 20.0 },
                    { 22, null, 10, "/word/bænk.docx", 4, "Thyra Description", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_langbaenk_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_langbaenk_hvidolie_02.png", "1700 mm.", "Thyra Materials", "Thyra Bænken", "Thyra Note", "11002", "Hvidolie", "Thyra Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_langbaenk_naturolie_01.png", 1, 4395.0, "Thyra Size", "Bænk i massivt egetræ - Behandlet med hvidolie", 20.0 },
                    { 21, null, 17, "/word/bænk.docx", 4, "Thyra Description", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_langbaenk_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_langbaenk_naturolie_02.png", "1700 mm.", "Thyra Materials", "Thyra Bænken", "Thyra Note", "11001", "Naturolie", "Thyra Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_langbaenk_naturolie_01.png", 1, 4395.0, "Thyra Size", "Bænk i massivt egetræ - Behandlet med naturolie", 20.0 },
                    { 20, null, 10, "/word/bænk.docx", 4, "Thyra Short Description", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_kortbaenk_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_kortbaenk_sortolie_02.png", "1150 mm.", "Thyra Short Materials", "Thyra Bænken", "Thyra Short Note", "12003", "Sortolie", "Thyra Short Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_kortbaenk_naturolie_01.png", 1, 3665.0, "Thyra Short Size", "Bænk i massivt egetræ - Behandlet med sortolie", 14.0 },
                    { 19, null, 20, "/word/bænk.docx", 4, "Thyra Short Description", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_kortbaenk_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_kortbaenk_hvidolie_02.png", "1150 mm.", "Thyra Short Materials", "Thyra Bænken", "Thyra Short Note", "12002", "Hvidolie", "Thyra Short Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_kortbaenk_naturolie_01.png", 1, 3665.0, "Thyra Short Size", "Bænk i massivt egetræ - Behandlet med hvidolie", 14.0 },
                    { 18, null, 42, "/word/bænk.docx", 4, "Thyra Short Description", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_kortbaenk_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_kortbaenk_naturolie_02.png", "1150 mm.", "Thyra Short Materials", "Thyra Bænken", "Thyra Short Note", "12001", "Naturolie", "Thyra Short Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_kortbaenk_naturolie_01.png", 1, 3665.0, "Thyra Short Size", "Bænk i massivt egetræ - Behandlet med naturolie", 14.0 },
                    { 15, null, 0, "/word/Hylde_Vejledning.docx", 3, "Ingeborg Description", 0, new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_02.png", "1000 mm.", "Ingeborg Materials", "Ingeborg Hylden", "Ingeborg Note", "17001", "Naturolie", "Ingeborg 1000 Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_naturolie_01.png", 1, 985.0, "Ingeborg 1000 Size", "Hylde i massivt egetræ - Behandlet med naturolie", 11.6 },
                    { 14, null, 0, "/word/Hylde_Vejledning.docx", 3, "Ingeborg Description", 2, new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_02.png", "1000 mm.", "Ingeborg Materials", "Ingeborg Hylden", "Ingeborg Note", "17003", "Sortolie", "Ingeborg 1000 Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_sortolie_01.png", 1, 985.0, "Ingeborg 1000 Size", "Hylde i massivt egetræ - Behandlet med sortolie", 11.6 },
                    { 13, null, 0, "/word/Hylde_Vejledning.docx", 3, "Ingeborg Description", 1, new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_02.png", "1000 mm.", "Ingeborg Materials", "Ingeborg Hylden", "Ingeborg Note", "17002", "Hvidolie", "Ingeborg 1000 Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_hvidolie_01.png", 1, 985.0, "Ingeborg 1000 Size", "Hylde i massivt egetræ - Behandlet med hvidolie", 11.6 },
                    { 12, null, 0, "/word/Hylde_Vejledning.docx", 3, "Ingeborg Description", 0, new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_02.png", "800 mm.", "Ingeborg Materials", "Ingeborg Hylden", "Ingeborg Note", "17011", "Naturolie", "Ingeborg 800 Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_naturolie_01.png", 1, 885.0, "Ingeborg 800 Size", "Hylde i massivt egetræ - Behandlet med naturolie", 11.6 },
                    { 11, null, 0, "/word/Hylde_Vejledning.docx", 3, "Ingeborg Description", 2, new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_02.png", "800 mm.", "Ingeborg Materials", "Ingeborg Hylden", "Ingeborg Note", "17013", "Sortolie", "Ingeborg 800 Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_sortolie_01.png", 1, 885.0, "Ingeborg 800 Size", "Hylde i massivt egetræ - Behandlet med sortolie", 11.6 },
                    { 10, null, 0, "/word/Hylde_Vejledning.docx", 3, "Ingeborg Description", 1, new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_02.png", "800 mm.", "Ingeborg Materials", "Ingeborg Hylden", "Ingeborg Note", "17012", "Hvidolie", "Ingeborg 800 Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_hvidolie_01.png", 1, 885.0, "Ingeborg 800 Size", "Hylde i massivt egetræ - Behandlet med hvidolie", 11.6 },
                    { 9, null, 0, "/word/Hylde_Vejledning.docx", 3, "Ingeborg Description", 0, new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_02.png", "600 mm.", "Ingeborg Materials", "Ingeborg Hylden", "Ingeborg Note", "17021", "Naturolie", "Ingeborg 600 Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_naturolie_01.png", 1, 785.0, "Ingeborg 600 Size", "Hylde i massivt egetræ - Behandlet med naturolie", 11.6 },
                    { 8, null, 0, "/word/Hylde_Vejledning.docx", 3, "Ingeborg Description", 2, new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_02.png", "600 mm.", "Ingeborg Materials", "Ingeborg Hylden", "Ingeborg Note", "17023", "Sortolie", "Ingeborg 600 Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_sortolie_01.png", 1, 785.0, "Ingeborg 600 Size", "Hylde i massivt egetræ - Behandlet med sortolie", 11.6 },
                    { 7, null, 0, "/word/Hylde_Vejledning.docx", 3, "Ingeborg Description", 1, new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_02.png", "600 mm.", "Ingeborg Materials", "Ingeborg Hylden", "Ingeborg Note", "17022", "Hvidolie", "Ingeborg 600 Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_hvidolie_01.png", 1, 785.0, "Ingeborg 600 Size", "Hylde i massivt egetræ - Behandlet med hvidolie", 11.6 },
                    { 6, null, 0, "/word/Hylde_Vejledning.docx", 3, "Ingeborg Description", 0, new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_02.png", "400 mm.", "Ingeborg Materials", "Ingeborg Hylden", "Ingeborg Note", "17031", "Naturolie", "Ingeborg 400 Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_naturolie_01.png", 1, 685.0, "Ingeborg 400 Size", "Hylde i massivt egetræ - Behandlet med naturolie", 11.6 },
                    { 5, null, 0, "/word/Hylde_Vejledning.docx", 3, "Ingeborg Description", 2, new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_02.png", "400 mm.", "Ingeborg Materials", "Ingeborg Hylden", "Ingeborg Note", "17033", "Sortolie", "Ingeborg 400 Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_sortolie_01.png", 1, 685.0, "Ingeborg 400 Size", "Hylde i massivt egetræ - Behandlet med sortolie", 11.6 },
                    { 4, null, 0, "/word/Hylde_Vejledning.docx", 3, "Ingebor Description", 1, new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_02.png", "400 mm.", "Ingeborg Materials", "Ingeborg Hylden", "Ingeborg Note", "17032", "Hvidolie", "Ingeborg 400 Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_hvidolie_01.png", 1, 685.0, "Ingeborg 400 Size", "Hylde i massivt egetræ - Behandlet med hvidolie", 11.6 },
                    { 17, null, 30, "/word/Bord.docx", 2, "Dagmar Description", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_bord_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_bord_hvidolie_02.png", null, "Dagmar Materials", "Dagmar Bordet", "Dagmar Note", "16002", "Hvidolie", "Dagmar Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_bord_hvidolie_01.png", 1, 3585.0, "Dagmar Size", "Bord i massivt egetræ - Behandlet med hvidolie", 22.0 },
                    { 16, null, 72, "/word/Bord.docx", 2, "Dagmar Description", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_bord_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_bord_naturolie_02.png", null, "Dagmar Materials", "Dagmar Bordet", "Dagmar Note", "16001", "Naturolie", "Dagmar Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_bord_naturolie_01.png", 1, 3585.0, "Dagmar Size", "Bord i massivt egetræ - Behandlet med naturolie", 22.0 },
                    { 32, null, 10, "/word/hænge_tøjrack.docx", 1, "Ingrid Description", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/Ingrid_Sortolie_1.png", "../images/Products/Gallery/Desktop/Ingrid_Sortolie_2.png", null, "Ingrid Materials", "Ingrid Tøjstativ", "Ingrid Note", "14003", "Sortolie", "Ingrid Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", 1, 1995.0, "Ingrid Size", "Hængende tøjstativ i massivt egetræ - Behandlet med sortolie", 2.0 },
                    { 31, null, 15, "/word/hænge_tøjrack.docx", 1, "Ingrid Description", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/Ingrid_Hvidolie_1.png", "../images/Products/Gallery/Desktop/Ingrid_Hvidolie_2.png", null, "Ingrid Materials", "Ingrid Tøjstativ", "Ingrid Note", "14002", "Hvidolie", "Ingrid Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", 1, 1995.0, "Ingrid Size", "Hængende tøjstativ i massivt egetræ - Behandlet med hvidolie", 2.0 },
                    { 30, null, 25, "/word/hænge_tøjrack.docx", 1, "Ingrid Description", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/Ingrid_Naturolie_1.png", "../images/Products/Gallery/Desktop/Ingrid_Naturolie_2.png", null, "Ingrid Materials", "Ingrid Tøjstativ", "Ingrid Note", "14001", "Naturolie", "Ingrid Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", 1, 1995.0, "Ingrid Size", "Hængende tøjstativ i massivt egetræ - Behandlet med naturolie", 2.0 },
                    { 29, null, 10, "/word/Tøjstativ.docx", 1, "Nora Description", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_rack_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_rack_sortolie_02.png", null, "Nora Materials", "Nora Tøjstativ", "Nora Note", "13003 + 13003A", "Sortolie", "Nora Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", 1, 2595.0, "Nora Size", "Tøjstativ i massivt egetræ - Behandlet med sortolie", 8.0 },
                    { 28, null, 16, "/word/Tøjstativ.docx", 1, "Nora Description", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_rack_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_rack_hvidolie_02.png", null, "Nora Materials", "Nora Tøjstativ", "Nora Note", "13002 + 13002A", "Hvidolie", "Nora Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", 1, 2595.0, "Nora Size", "Tøjstativ i massivt egetræ - Behandlet med hvidolie", 8.0 },
                    { 2, null, 0, "none", 5, "Gertrud Description", 2, new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_boejle_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_boejle_sortolie_02.png", null, "Gertrud Materials", "Bøjlen Gertrud / 3 stk.", "Gertrud Note", "15003", "Sortolie", "Gertrud Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_boejle_sortolie_01.png", 3, 420.0, "Gertrud Size", "Bøjle i massivt egetræ - Behandlet med sortolie", 11.6 },
                    { 3, null, 0, "none", 5, "Gertrud Description", 1, new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_boejle_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_boejle_hvidolie_02.png", null, "Gertrud Materials", "Bøjlen Gertrud / 3 stk.", "Gertrud Note", "15002", "Hvidolie", "Gertrud Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_boejle_hvidolie_01.png", 3, 420.0, "Gertrud Size", "Bøjle i massivt egetræ - Behandlet med hvidolie", 11.6 }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "EColor", "ImgSrc", "ProductId", "ProductSourceId" },
                values: new object[,]
                {
                    { 77, 0, "../images/Products/Color/Desktop/NYKANT_rack_naturolie_02.png", 27, 27 },
                    { 20, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 7, 8 },
                    { 19, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 7, 7 },
                    { 60, 1, "../images/Products/Color/Desktop/NYKANT_langbaenk_hvidolie_02.png", 21, 22 },
                    { 61, 2, "../images/Products/Color/Desktop/NYKANT_langbaenk_sortolie_02.png", 21, 23 },
                    { 62, 0, "../images/Products/Color/Desktop/NYKANT_langbaenk_naturolie_02.png", 22, 21 },
                    { 63, 1, "../images/Products/Color/Desktop/NYKANT_langbaenk_hvidolie_02.png", 22, 22 },
                    { 18, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 6, 6 },
                    { 17, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 6, 5 },
                    { 16, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 6, 4 },
                    { 64, 2, "../images/Products/Color/Desktop/NYKANT_langbaenk_sortolie_02.png", 22, 23 },
                    { 65, 0, "../images/Products/Color/Desktop/NYKANT_langbaenk_naturolie_02.png", 23, 21 },
                    { 66, 1, "../images/Products/Color/Desktop/NYKANT_langbaenk_hvidolie_02.png", 23, 22 },
                    { 67, 2, "../images/Products/Color/Desktop/NYKANT_langbaenk_sortolie_02.png", 23, 23 },
                    { 15, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 5, 6 },
                    { 14, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 5, 5 },
                    { 13, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 5, 4 },
                    { 38, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 13, 14 },
                    { 68, 0, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png", 24, 24 },
                    { 69, 1, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png", 24, 25 },
                    { 70, 2, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_sort_01.png", 24, 26 },
                    { 12, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 4, 6 },
                    { 11, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 4, 5 },
                    { 10, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 4, 4 },
                    { 49, 1, "../images/Products/Color/Desktop/bord_hvid_2.png", 17, 17 },
                    { 48, 0, "../images/Products/Color/Desktop/bord_natur_2.png", 17, 16 },
                    { 47, 1, "../images/Products/Color/Desktop/bord_hvid_2.png", 16, 17 },
                    { 46, 0, "../images/Products/Color/Desktop/bord_natur_2.png", 16, 16 },
                    { 71, 0, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png", 25, 24 },
                    { 72, 1, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png", 25, 25 },
                    { 21, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 7, 9 },
                    { 73, 2, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_sort_01.png", 25, 26 },
                    { 59, 0, "../images/Products/Color/Desktop/NYKANT_langbaenk_naturolie_02.png", 21, 21 },
                    { 57, 1, "../images/Products/Color/Desktop/kortbaenk_hvid_2.png", 20, 19 },
                    { 39, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 13, 15 },
                    { 36, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 12, 12 },
                    { 35, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 12, 11 },
                    { 34, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 12, 10 },
                    { 40, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 14, 13 },
                    { 41, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 14, 14 },
                    { 42, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 14, 15 },
                    { 33, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 11, 12 },
                    { 32, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 11, 11 },
                    { 31, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 11, 10 },
                    { 43, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 15, 13 },
                    { 44, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 15, 14 },
                    { 45, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 15, 15 },
                    { 30, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 10, 12 },
                    { 29, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 10, 11 },
                    { 28, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 10, 10 },
                    { 50, 0, "../images/Products/Color/Desktop/kortbaenk_natur_2.png", 18, 18 },
                    { 51, 1, "../images/Products/Color/Desktop/kortbaenk_hvid_2.png", 18, 19 },
                    { 52, 2, "../images/Products/Color/Desktop/NYKANT_kortbaenk_sortolie_02.png", 18, 20 },
                    { 27, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 9, 9 },
                    { 26, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 9, 8 },
                    { 25, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 9, 7 },
                    { 53, 0, "../images/Products/Color/Desktop/kortbaenk_natur_2.png", 19, 18 },
                    { 54, 1, "../images/Products/Color/Desktop/kortbaenk_hvid_2.png", 19, 19 },
                    { 55, 2, "../images/Products/Color/Desktop/NYKANT_kortbaenk_sortolie_02.png", 19, 20 },
                    { 24, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 8, 9 },
                    { 23, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 8, 8 },
                    { 22, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 8, 7 },
                    { 56, 0, "../images/Products/Color/Desktop/kortbaenk_natur_2.png", 20, 18 },
                    { 58, 2, "../images/Products/Color/Desktop/NYKANT_kortbaenk_sortolie_02.png", 20, 20 },
                    { 94, 2, "../images/Products/Color/Desktop/Ingrid_sort_2.png", 32, 32 },
                    { 37, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 13, 13 },
                    { 81, 1, "../images/Products/Color/Desktop/NYKANT_rack_hvidolie_02.png", 28, 28 },
                    { 89, 0, "../images/Products/Color/Desktop/Ingrid_natur_2.png", 31, 30 },
                    { 6, 1, "../images/Products/Color/Desktop/boejle_hvid_1.png", 2, 3 },
                    { 5, 2, "../images/Products/Color/Desktop/boejle_sort_1.png", 2, 2 },
                    { 4, 0, "../images/Products/Color/Desktop/boejle_natur_1.png", 2, 1 },
                    { 80, 0, "../images/Products/Color/Desktop/NYKANT_rack_naturolie_02.png", 28, 27 },
                    { 84, 1, "../images/Products/Color/Desktop/NYKANT_rack_hvidolie_02.png", 29, 28 },
                    { 88, 2, "../images/Products/Color/Desktop/Ingrid_sort_2.png", 30, 32 },
                    { 87, 1, "../images/Products/Color/Desktop/Ingrid_hvid_2.png", 30, 31 },
                    { 90, 1, "../images/Products/Color/Desktop/Ingrid_hvid_2.png", 31, 31 },
                    { 86, 0, "../images/Products/Color/Desktop/Ingrid_natur_2.png", 30, 30 },
                    { 82, 2, "../images/Products/Color/Desktop/NYKANT_rack_sortolie_02.png", 28, 29 },
                    { 75, 1, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png", 26, 25 },
                    { 76, 2, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_sort_01.png", 26, 26 },
                    { 3, 1, "../images/Products/Color/Desktop/boejle_hvid_1.png", 1, 3 },
                    { 2, 2, "../images/Products/Color/Desktop/boejle_sort_1.png", 1, 2 },
                    { 1, 0, "../images/Products/Color/Desktop/boejle_natur_1.png", 1, 1 },
                    { 85, 2, "../images/Products/Color/Desktop/NYKANT_rack_sortolie_02.png", 29, 29 },
                    { 93, 1, "../images/Products/Color/Desktop/Ingrid_hvid_2.png", 32, 31 },
                    { 74, 0, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png", 26, 24 },
                    { 91, 2, "../images/Products/Color/Desktop/Ingrid_sort_2.png", 31, 32 },
                    { 83, 0, "../images/Products/Color/Desktop/NYKANT_rack_naturolie_02.png", 29, 27 },
                    { 78, 1, "../images/Products/Color/Desktop/NYKANT_rack_hvidolie_02.png", 27, 28 },
                    { 79, 2, "../images/Products/Color/Desktop/NYKANT_rack_sortolie_02.png", 27, 29 },
                    { 92, 0, "../images/Products/Color/Desktop/Ingrid_natur_2.png", 32, 30 },
                    { 9, 1, "../images/Products/Color/Desktop/boejle_hvid_1.png", 3, 3 },
                    { 8, 2, "../images/Products/Color/Desktop/boejle_sort_1.png", 3, 2 },
                    { 7, 0, "../images/Products/Color/Desktop/boejle_natur_1.png", 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ImageType", "ProductId", "Size", "Source", "Source2" },
                values: new object[,]
                {
                    { 4, 0, 2, 2, "../images/Products/Details_Slide/Desktop/NYKANT_boejle_sortolie_02.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_boejle_sortolie_02.png" },
                    { 277, 1, 18, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_naturolie_01.png", null },
                    { 278, 1, 18, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_naturolie_02.png", null },
                    { 2, 0, 1, 2, "../images/Products/Details_Slide/Desktop/NYKANT_boejle_naturolie_02.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_boejle_naturolie_02.png" },
                    { 1, 0, 1, 2, "../images/Products/Details_Slide/Desktop/NYKANT_boejle_naturolie_01.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_boejle_naturolie_01.png" },
                    { 279, 1, 18, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_naturolie_03.png", null },
                    { 35, 0, 13, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_02.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    { 34, 0, 13, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_01.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    { 316, 1, 26, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_07.png", null },
                    { 52, 0, 19, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_hvidolie_01.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_hvidolie_01.png" },
                    { 53, 0, 19, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_hvidolie_02.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_hvidolie_02.png" },
                    { 54, 0, 19, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_hvidolie_03.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_hvidolie_03.png" },
                    { 280, 1, 19, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_hvidolie_01.png", null },
                    { 281, 1, 19, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_hvidolie_02.png", null },
                    { 282, 1, 19, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_hvidolie_03.png", null },
                    { 315, 1, 26, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_06.png", null },
                    { 314, 1, 26, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_05.png", null },
                    { 312, 1, 26, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_04.png", null },
                    { 51, 0, 18, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_naturolie_03.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_naturolie_03.png" },
                    { 50, 0, 18, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_naturolie_02.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_naturolie_02.png" },
                    { 5, 0, 3, 2, "../images/Products/Details_Slide/Desktop/NYKANT_boejle_hvidolie_01.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_boejle_hvidolie_01.png" },
                    { 265, 1, 14, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_01.png", null },
                    { 231, 1, 2, 2, "../images/Products/Details_Button/Desktop/NYKANT_boejle_sortolie_01.png", null },
                    { 232, 1, 2, 2, "../images/Products/Details_Button/Desktop/NYKANT_boejle_sortolie_02.png", null },
                    { 266, 1, 14, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_02.png", null },
                    { 267, 1, 14, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_03.png", null },
                    { 3, 0, 2, 2, "../images/Products/Details_Slide/Desktop/NYKANT_boejle_sortolie_01.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_boejle_sortolie_01.png" },
                    { 39, 0, 14, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_03.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_03.png" },
                    { 38, 0, 14, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_02.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_02.png" },
                    { 40, 0, 15, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_01.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_01.png" },
                    { 41, 0, 15, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_02.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_02.png" },
                    { 42, 0, 15, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_03.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_03.png" },
                    { 268, 1, 15, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_01.png", null },
                    { 37, 0, 14, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_01.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_01.png" },
                    { 264, 1, 13, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_03.png", null },
                    { 263, 1, 13, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_02.png", null },
                    { 262, 1, 13, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_01.png", null },
                    { 269, 1, 15, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_02.png", null },
                    { 270, 1, 15, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_03.png", null },
                    { 36, 0, 13, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_03.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    { 230, 1, 1, 2, "../images/Products/Details_Button/Desktop/NYKANT_boejle_naturolie_02.png", null },
                    { 229, 1, 1, 2, "../images/Products/Details_Button/Desktop/NYKANT_boejle_naturolie_01.png", null },
                    { 49, 0, 18, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_naturolie_01.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_naturolie_01.png" },
                    { 6, 0, 3, 2, "../images/Products/Details_Slide/Desktop/NYKANT_boejle_hvidolie_02.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_boejle_hvidolie_02.png" },
                    { 75, 0, 25, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_02.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_02.png" },
                    { 284, 1, 20, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_sortolie_02.png", null },
                    { 55, 0, 20, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_sortolie_01.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_sortolie_01.png" },
                    { 293, 1, 23, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_sortolie_02.png", null },
                    { 294, 1, 23, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_sortolie_03.png", null },
                    { 305, 1, 25, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_04.png", null },
                    { 304, 1, 25, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_03.png", null },
                    { 303, 1, 25, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_02.png", null },
                    { 67, 0, 24, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png" },
                    { 68, 0, 24, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_02.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_02.png" },
                    { 69, 0, 24, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_03.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_03.png" },
                    { 70, 0, 24, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_04.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_04.png" },
                    { 71, 0, 24, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_05.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_05.png" },
                    { 72, 0, 24, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_06.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_06.png" },
                    { 73, 0, 24, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_07.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_07.png" },
                    { 292, 1, 23, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_sortolie_01.png", null },
                    { 302, 1, 25, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png", null },
                    { 295, 1, 24, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png", null },
                    { 296, 1, 24, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_02.png", null },
                    { 297, 1, 24, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_03.png", null },
                    { 298, 1, 24, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_04.png", null },
                    { 299, 1, 24, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_05.png", null },
                    { 300, 1, 24, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_06.png", null },
                    { 79, 0, 25, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_06.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_06.png" },
                    { 78, 0, 25, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_05.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_05.png" },
                    { 301, 1, 24, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_07.png", null },
                    { 77, 0, 25, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_04.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_04.png" },
                    { 76, 0, 25, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_03.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_03.png" },
                    { 74, 0, 25, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png" },
                    { 80, 0, 25, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_07.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_07.png" },
                    { 66, 0, 23, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_sortolie_03.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_langbaenk_sortolie_03.png" },
                    { 306, 1, 25, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_05.png", null },
                    { 64, 0, 23, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_sortolie_01.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_langbaenk_sortolie_01.png" },
                    { 56, 0, 20, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_sortolie_02.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_sortolie_02.png" },
                    { 57, 0, 20, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_sortolie_03.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_sortolie_03.png" },
                    { 283, 1, 20, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_sortolie_01.png", null },
                    { 285, 1, 20, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_sortolie_03.png", null },
                    { 310, 1, 26, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_02.png", null },
                    { 309, 1, 26, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_01.png", null },
                    { 87, 0, 26, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_07.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_07.png" },
                    { 86, 0, 26, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_06.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_06.png" },
                    { 85, 0, 26, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_05.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_05.png" },
                    { 58, 0, 21, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_naturolie_01.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_langbaenk_naturolie_01.png" },
                    { 59, 0, 21, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_naturolie_02.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_langbaenk_naturolie_02.png" },
                    { 60, 0, 21, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_naturolie_03.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_langbaenk_naturolie_03.png" },
                    { 286, 1, 21, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_naturolie_01.png", null },
                    { 287, 1, 21, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_naturolie_02.png", null },
                    { 288, 1, 21, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_naturolie_03.png", null },
                    { 84, 0, 26, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_04.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_04.png" },
                    { 83, 0, 26, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_03.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_03.png" },
                    { 82, 0, 26, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_02.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_02.png" },
                    { 81, 0, 26, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_01.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_01.png" },
                    { 61, 0, 22, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_hvidolie_01.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_langbaenk_hvidolie_01.png" },
                    { 62, 0, 22, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_hvidolie_02.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_langbaenk_hvidolie_02.png" },
                    { 63, 0, 22, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_hvidolie_03.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_langbaenk_hvidolie_03.png" },
                    { 289, 1, 22, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_hvidolie_01.png", null },
                    { 290, 1, 22, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_hvidolie_02.png", null },
                    { 291, 1, 22, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_hvidolie_03.png", null },
                    { 308, 1, 25, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_07.png", null },
                    { 307, 1, 25, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_06.png", null },
                    { 311, 1, 26, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_03.png", null },
                    { 65, 0, 23, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_sortolie_02.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_langbaenk_sortolie_02.png" },
                    { 234, 1, 3, 2, "../images/Products/Details_Button/Desktop/NYKANT_boejle_hvidolie_02.png", null },
                    { 21, 0, 8, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_03.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_03.png" },
                    { 13, 0, 6, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_01.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_01.png" },
                    { 14, 0, 6, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_02.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_02.png" },
                    { 338, 1, 31, 2, "../images/Products/Details_Button/Desktop/Ingrid_Hvidolie_1.png", null },
                    { 111, 0, 31, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Hvidolie_3.png", "../images/products/Details_Fullscreen/Desktop/Ingrid_Hvidolie_3.png" },
                    { 15, 0, 6, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_03.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_03.png" },
                    { 241, 1, 6, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_01.png", null },
                    { 242, 1, 6, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_02.png", null },
                    { 243, 1, 6, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_03.png", null },
                    { 110, 0, 31, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Hvidolie_2.png", "../images/products/Details_Fullscreen/Desktop/Ingrid_Hvidolie_2.png" },
                    { 109, 0, 31, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Hvidolie_1.png", "../images/products/Details_Fullscreen/Desktop/Ingrid_Hvidolie_1.png" },
                    { 337, 1, 30, 2, "../images/Products/Details_Button/Desktop/Ingrid_Naturolie_3.png", null },
                    { 336, 1, 30, 2, "../images/Products/Details_Button/Desktop/Ingrid_Naturolie_2.png", null },
                    { 339, 1, 31, 2, "../images/Products/Details_Button/Desktop/Ingrid_Hvidolie_2.png", null },
                    { 16, 0, 7, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_01.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    { 108, 0, 30, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Naturolie_3.png", "../images/products/Details_Fullscreen/Desktop/Ingrid_Naturolie_3.png" },
                    { 17, 0, 7, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_02.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    { 18, 0, 7, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_03.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    { 244, 1, 7, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_01.png", null },
                    { 245, 1, 7, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_02.png", null },
                    { 246, 1, 7, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_03.png", null },
                    { 107, 0, 30, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Naturolie_2.png", "../images/products/Details_Fullscreen/Desktop/Ingrid_Naturolie_2.png" },
                    { 106, 0, 30, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Naturolie_1.png", "../images/products/Details_Fullscreen/Desktop/Ingrid_Naturolie_1.png" },
                    { 334, 1, 29, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_sortolie_06.png", null },
                    { 333, 1, 29, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_sortolie_05.png", null },
                    { 332, 1, 29, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_sortolie_04.png", null },
                    { 331, 1, 29, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_sortolie_03.png", null },
                    { 335, 1, 30, 2, "../images/Products/Details_Button/Desktop/Ingrid_Naturolie_1.png", null },
                    { 261, 1, 12, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_03.png", null },
                    { 340, 1, 31, 2, "../images/Products/Details_Button/Desktop/Ingrid_Hvidolie_3.png", null },
                    { 112, 0, 32, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Sortolie_1.png", "../images/products/Details_Fullscreen/Desktop/Ingrid_Sortolie_1.png" },
                    { 273, 1, 16, 2, "../images/Products/Details_Button/Desktop/NYKANT_bord_naturolie_03.png", null },
                    { 46, 0, 17, 2, "../images/Products/Details_Slide/Desktop/NYKANT_bord_hvidolie_01.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_bord_hvidolie_01.png" },
                    { 47, 0, 17, 2, "../images/Products/Details_Slide/Desktop/NYKANT_bord_hvidolie_02.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_bord_hvidolie_02.png" },
                    { 48, 0, 17, 2, "../images/Products/Details_Slide/Desktop/NYKANT_bord_hvidolie_03.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_bord_hvidolie_03.png" },
                    { 274, 1, 17, 2, "../images/Products/Details_Button/Desktop/NYKANT_bord_hvidolie_01.png", null },
                    { 275, 1, 17, 2, "../images/Products/Details_Button/Desktop/NYKANT_bord_hvidolie_02.png", null },
                    { 276, 1, 17, 2, "../images/Products/Details_Button/Desktop/NYKANT_bord_hvidolie_03.png", null },
                    { 7, 0, 4, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_01.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    { 8, 0, 4, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_02.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    { 9, 0, 4, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_03.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    { 235, 1, 4, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_01.png", null },
                    { 45, 0, 16, 2, "../images/Products/Details_Slide/Desktop/NYKANT_bord_naturolie_03.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_bord_naturolie_03.png" },
                    { 44, 0, 16, 2, "../images/Products/Details_Slide/Desktop/NYKANT_bord_naturolie_02.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_bord_naturolie_02.png" },
                    { 236, 1, 4, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_02.png", null },
                    { 237, 1, 4, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_03.png", null },
                    { 43, 0, 16, 2, "../images/Products/Details_Slide/Desktop/NYKANT_bord_naturolie_01.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_bord_naturolie_01.png" },
                    { 343, 1, 32, 2, "../images/Products/Details_Button/Desktop/Ingrid_Sortolie_3.png", null },
                    { 342, 1, 32, 2, "../images/Products/Details_Button/Desktop/Ingrid_Sortolie_2.png", null },
                    { 341, 1, 32, 2, "../images/Products/Details_Button/Desktop/Ingrid_Sortolie_1.png", null },
                    { 10, 0, 5, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_01.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_01.png" },
                    { 11, 0, 5, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_02.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_02.png" },
                    { 12, 0, 5, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_03.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_03.png" },
                    { 114, 0, 32, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Sortolie_3.png", "../images/products/Details_Fullscreen/Desktop/Ingrid_Sortolie_3.png" },
                    { 113, 0, 32, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Sortolie_2.png", "../images/products/Details_Fullscreen/Desktop/Ingrid_Sortolie_2.png" },
                    { 238, 1, 5, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_01.png", null },
                    { 239, 1, 5, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_02.png", null },
                    { 240, 1, 5, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_03.png", null },
                    { 19, 0, 8, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_01.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_01.png" },
                    { 20, 0, 8, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_02.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_02.png" },
                    { 271, 1, 16, 2, "../images/Products/Details_Button/Desktop/NYKANT_bord_naturolie_01.png", null },
                    { 247, 1, 8, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_01.png", null },
                    { 96, 0, 28, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_hvidolie_03.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_03.png" },
                    { 95, 0, 28, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_hvidolie_01.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_02.png" },
                    { 94, 0, 28, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_hvidolie_01.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_01.png" },
                    { 322, 1, 27, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_naturolie_06.png", null },
                    { 321, 1, 27, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_naturolie_05.png", null },
                    { 28, 0, 11, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_01.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_01.png" },
                    { 29, 0, 11, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_02.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_02.png" },
                    { 30, 0, 11, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_03.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_03.png" },
                    { 256, 1, 11, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_01.png", null },
                    { 257, 1, 11, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_02.png", null },
                    { 258, 1, 11, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_03.png", null },
                    { 320, 1, 27, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_naturolie_04.png", null },
                    { 319, 1, 27, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_naturolie_03.png", null },
                    { 318, 1, 27, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_naturolie_02.png", null },
                    { 317, 1, 27, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_naturolie_01.png", null },
                    { 93, 0, 27, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_naturolie_06.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_06.png" },
                    { 92, 0, 27, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_naturolie_05.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_05.png" },
                    { 233, 1, 3, 2, "../images/Products/Details_Button/Desktop/NYKANT_boejle_hvidolie_01.png", null },
                    { 91, 0, 27, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_naturolie_04.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_04.png" },
                    { 31, 0, 12, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_01.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_01.png" },
                    { 32, 0, 12, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_02.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_02.png" },
                    { 33, 0, 12, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_03.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_03.png" },
                    { 259, 1, 12, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_01.png", null },
                    { 260, 1, 12, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_02.png", null },
                    { 90, 0, 27, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_naturolie_03.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_03.png" },
                    { 89, 0, 27, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_naturolie_02.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_02.png" },
                    { 88, 0, 27, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_naturolie_01.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_01.png" },
                    { 97, 0, 28, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_hvidolie_04.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_04.png" },
                    { 272, 1, 16, 2, "../images/Products/Details_Button/Desktop/NYKANT_bord_naturolie_02.png", null },
                    { 98, 0, 28, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_hvidolie_05.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_05.png" },
                    { 255, 1, 10, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_03.png", null },
                    { 248, 1, 8, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_02.png", null },
                    { 249, 1, 8, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_03.png", null },
                    { 330, 1, 29, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_sortolie_02.png", null },
                    { 329, 1, 29, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_sortolie_01.png", null },
                    { 105, 0, 29, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_sortolie_06.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_06.png" },
                    { 104, 0, 29, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_sortolie_05.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_05.png" },
                    { 103, 0, 29, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_sortolie_04.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_04.png" },
                    { 102, 0, 29, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_sortolie_03.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_03.png" },
                    { 22, 0, 9, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_01.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_01.png" },
                    { 23, 0, 9, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_02.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_02.png" },
                    { 24, 0, 9, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_03.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_03.png" },
                    { 250, 1, 9, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_01.png", null },
                    { 251, 1, 9, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_02.png", null },
                    { 252, 1, 9, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_03.png", null },
                    { 101, 0, 29, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_sortolie_02.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_02.png" },
                    { 100, 0, 29, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_sortolie_01.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_01.png" },
                    { 328, 1, 28, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_hvidolie_06.png", null },
                    { 327, 1, 28, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_hvidolie_05.png", null },
                    { 326, 1, 28, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_hvidolie_04.png", null },
                    { 325, 1, 28, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_hvidolie_03.png", null },
                    { 324, 1, 28, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_hvidolie_02.png", null },
                    { 323, 1, 28, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_hvidolie_01.png", null },
                    { 25, 0, 10, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_01.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    { 26, 0, 10, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_02.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    { 27, 0, 10, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_03.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    { 253, 1, 10, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_01.png", null },
                    { 254, 1, 10, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_02.png", null },
                    { 99, 0, 28, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_hvidolie_06.png", "../images/products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_06.png" }
                });

            migrationBuilder.InsertData(
                table: "ProductLength",
                columns: new[] { "Id", "Length", "ProductId", "ProductReferenceId" },
                values: new object[,]
                {
                    { 45, "400 mm.", 12, 6 },
                    { 19, "800 mm.", 5, 12 },
                    { 11, "1150 mm.", 23, 18 },
                    { 34, "600 mm.", 9, 9 },
                    { 60, "1000 mm.", 15, 15 },
                    { 59, "800 mm.", 15, 12 },
                    { 58, "600 mm.", 15, 9 },
                    { 57, "400 mm.", 15, 6 },
                    { 35, "800 mm.", 9, 12 },
                    { 36, "1000 mm.", 9, 16 },
                    { 37, "400 mm.", 10, 6 },
                    { 56, "1000 mm.", 14, 15 },
                    { 55, "800 mm.", 14, 12 },
                    { 54, "600 mm.", 14, 9 },
                    { 53, "400 mm.", 14, 6 },
                    { 38, "600 mm.", 10, 9 },
                    { 39, "800 mm.", 10, 12 },
                    { 40, "1000 mm.", 10, 15 },
                    { 52, "1000 mm.", 13, 15 },
                    { 51, "800 mm.", 13, 12 },
                    { 50, "600 mm.", 13, 9 },
                    { 49, "400 mm.", 13, 6 },
                    { 41, "400 mm.", 11, 6 },
                    { 42, "600 mm.", 11, 9 },
                    { 44, "1000 mm.", 11, 15 },
                    { 48, "1000 mm.", 12, 15 },
                    { 47, "800 mm.", 12, 12 },
                    { 46, "600 mm.", 12, 9 },
                    { 33, "400 mm.", 9, 6 },
                    { 32, "1000 mm.", 8, 15 },
                    { 1, "1150 mm.", 18, 18 },
                    { 2, "1700 mm.", 18, 21 },
                    { 13, "400 mm.", 4, 6 },
                    { 14, "600 mm.", 4, 9 },
                    { 15, "800 mm.", 4, 12 },
                    { 16, "1000 mm.", 4, 15 },
                    { 10, "1700 mm.", 22, 21 },
                    { 9, "1150 mm.", 22, 18 },
                    { 17, "400 mm.", 5, 6 },
                    { 18, "600 mm.", 5, 9 },
                    { 20, "1000 mm.", 5, 15 },
                    { 8, "1700 mm.", 21, 21 },
                    { 7, "1150 mm.", 21, 18 },
                    { 21, "400 mm.", 6, 6 },
                    { 12, "1700 mm.", 23, 21 },
                    { 22, "600 mm.", 6, 9 },
                    { 24, "1000 mm.", 6, 15 },
                    { 6, "1700 mm.", 20, 21 },
                    { 5, "1150 mm.", 20, 18 },
                    { 25, "400 mm.", 7, 6 },
                    { 26, "600 mm.", 7, 9 },
                    { 27, "800 mm.", 7, 12 },
                    { 28, "1000 mm.", 7, 15 },
                    { 4, "1700 mm.", 19, 21 },
                    { 3, "1150 mm.", 19, 18 },
                    { 29, "400 mm.", 8, 6 },
                    { 30, "600 mm.", 8, 9 },
                    { 31, "800 mm.", 8, 12 },
                    { 23, "800 mm.", 6, 12 },
                    { 43, "800 mm.", 11, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BagItems_ProductId",
                table: "BagItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingAddress_CustomerId",
                table: "BillingAddress",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colors_ProductId",
                table: "Colors",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_OrderId",
                table: "Invoices",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelshopData_ShippingDeliveryId",
                table: "ParcelshopData",
                column: "ShippingDeliveryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductLength_ProductId",
                table: "ProductLength",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddress_CustomerId",
                table: "ShippingAddress",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShippingDeliveries_OrderId",
                table: "ShippingDeliveries",
                column: "OrderId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BagItems");

            migrationBuilder.DropTable(
                name: "BillingAddress");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Cookies");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "NewsSubs");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ParcelshopData");

            migrationBuilder.DropTable(
                name: "ProductLength");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "ShippingAddress");

            migrationBuilder.DropTable(
                name: "ShippingDeliveries");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
