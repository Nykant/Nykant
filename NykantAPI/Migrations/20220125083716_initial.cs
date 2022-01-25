using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    ImageSource = table.Column<string>(nullable: true),
                    Pieces = table.Column<int>(nullable: false),
                    ImageSource2 = table.Column<string>(nullable: true),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Source = table.Column<string>(nullable: true),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    { 1, "../images/Products/NYKANT_rack_naturolie_02.png", "Tøjstativer" },
                    { 2, "../images/Products/NYKANT_bord_naturolie_02.png", "Borde" },
                    { 3, "../images/Products/NYKANT_hylde_naturolie_01.png", "Hylder" },
                    { 4, "../images/Products/NYKANT_opbevaringsbaenk_naturolie_03.png", "Bænke" },
                    { 5, "../images/Products/NYKANT_boejle_naturolie_01.png", "Bøjler" }
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
                columns: new[] { "Id", "Alt", "Amount", "AssemblyPath", "CategoryId", "Description", "EColor", "ExpectedDelivery", "ImageSource", "ImageSource2", "Length", "Materials", "Name", "Note", "Number", "Oil", "Package", "Path", "Pieces", "Price", "Size", "Title", "WeightInKg" },
                values: new object[,]
                {
                    { 11, null, 26, "/word/Tøjstativ.docx", 1, "Nora Description", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/NYKANT_rack_naturolie_01.png", "../images/Products/NYKANT_rack_naturolie_02.png", null, "Nora Materials", "Nora Tøjstativ", "Nora Note", "13001 + 13001A", "Naturolie", "Nora Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", 1, 2295.0, "Nora Size", "Tøjstativ i massivt egetræ - Behandlet med naturolie", 8.0 },
                    { 7, null, 72, "/word/Bord.docx", 2, "Dagmar Description", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/NYKANT_bord_naturolie_01.png", "../images/Products/NYKANT_bord_naturolie_02.png", null, "Dagmar Materials", "Dagmar Bordet", "Dagmar Note", "16001", "Naturolie", "Dagmar Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_bord_naturolie_01.png", 1, 2995.0, "Dagmar Size", "Bord i massivt egetræ - Behandlet med naturolie", 22.0 },
                    { 4, null, 0, "/word/Hylde_Vejledning.docx", 3, "Ingeborg Description", 1, new DateTime(2022, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/NYKANT_hylde_hvidolie_01.png", "../images/Products/NYKANT_hylde_hvidolie_02.png", "600 mm.", "Ingeborg Materials", "Ingeborg Hylden", "Ingeborg Note", "101", "Hvidolie", "Ingeborg Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_hvidolie_01.png", 1, 595.0, "Ingeborg Size", "Hylde i massivt egetræ - Behandlet med hvidolie", 11.6 },
                    { 5, null, 0, "/word/Hylde_Vejledning.docx", 3, "Ingeborg Description", 2, new DateTime(2022, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/NYKANT_hylde_sortolie_01.png", "../images/Products/NYKANT_hylde_sortolie_02.png", "600 mm.", "Ingeborg Materials", "Ingeborg Hylden", "Ingeborg Note", "101", "Sortolie", "Ingeborg Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_sortolie_01.png", 1, 595.0, "Ingeborg Size", "Hylde i massivt egetræ - Behandlet med sortolie", 11.6 },
                    { 6, null, 0, "/word/Hylde_Vejledning.docx", 3, "Ingeborg Description", 0, new DateTime(2022, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/NYKANT_hylde_naturolie_01.png", "../images/Products/NYKANT_hylde_naturolie_02.png", "600 mm.", "Ingeborg Materials", "Ingeborg Hylden", "Ingeborg Note", "101", "Naturolie", "Ingeborg Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_naturolie_01.png", 1, 595.0, "Ingeborg Size", "Hylde i massivt egetræ - Behandlet med naturolie", 11.6 },
                    { 8, null, 42, "/word/bænk.docx", 4, "Thyra Short Description", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/NYKANT_kortbaenk_naturolie_01.png", "../images/Products/NYKANT_kortbaenk_naturolie_02.png", "1150 mm.", "Thyra Short Materials", "Thyra Bænken", "Thyra Short Note", "12001", "Naturolie", "Thyra Short Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_kortbaenk_naturolie_01.png", 1, 2985.0, "Thyra Short Size", "Bænk i massivt egetræ - Behandlet med naturolie", 14.0 },
                    { 9, null, 17, "/word/bænk.docx", 4, "Thyra Description", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/NYKANT_langbaenk_naturolie_01.png", "../images/Products/NYKANT_langbaenk_naturolie_02.png", "1700 mm.", "Thyra Materials", "Thyra Bænken", "Thyra Note", "11001", "Naturolie", "Thyra Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_langbaenk_naturolie_01.png", 1, 3885.0, "Thyra Size", "Bænk i massivt egetræ - Behandlet med naturolie", 20.0 },
                    { 10, null, 50, "none", 4, "Filippa Description", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", "../images/Products/NYKANT_opbevaringsbaenk_naturolie_02.png", null, "Filippa Materials", "Filippa Bænk", "Filippa Note", "10001", "Naturolie", "Filippa Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", 1, 4395.0, "Filippa Size", "Opbevaringsbænk i massivt egetræ - Behandlet med naturolie", 24.0 },
                    { 1, null, 0, "none", 5, "Gertrud Description", 0, new DateTime(2022, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/NYKANT_boejle_naturolie_01.png", "../images/Products/NYKANT_boejle_naturolie_02.png", null, "Gertrud Materials", "Bøjlen Gertrud / 3 stk.", "Gertrud Note", "101", "Naturolie", "Gertrud Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_boejle_naturolie_01.png", 3, 375.0, "Gertrud Size", "Bøjle i massivt egetræ - Behandlet med naturolie", 11.6 },
                    { 2, null, 0, "none", 5, "Gertrud Description", 2, new DateTime(2022, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/NYKANT_boejle_sortolie_01.png", "../images/Products/NYKANT_boejle_sortolie_02.png", null, "Gertrud Materials", "Bøjlen Gertrud / 3 stk.", "Gertrud Note", "101", "Sortolie", "Gertrud Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_boejle_sortolie_01.png", 3, 375.0, "Gertrud Size", "Bøjle i massivt egetræ - Behandlet med sortolie", 11.6 },
                    { 3, null, 0, "none", 5, "Gertrud Description", 1, new DateTime(2022, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/NYKANT_boejle_hvidolie_01.png", "../images/Products/NYKANT_boejle_hvidolie_02.png", null, "Gertrud Materials", "Bøjlen Gertrud / 3 stk.", "Gertrud Note", "101", "Hvidolie", "Gertrud Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_boejle_hvidolie_01.png", 3, 375.0, "Gertrud Size", "Bøjle i massivt egetræ - Behandlet med hvidolie", 11.6 }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "EColor", "ImgSrc", "ProductId", "ProductSourceId" },
                values: new object[,]
                {
                    { 23, 0, "../images/Products/NYKANT_rack_naturolie_01.png", 11, 11 },
                    { 21, 0, "../images/Products/NYKANT_langbaenk_naturolie_01.png", 9, 9 },
                    { 18, 0, "../images/Products/NYKANT_hylde_naturolie_01.png", 6, 6 },
                    { 17, 2, "../images/Products/NYKANT_hylde_sortolie_01.png", 6, 5 },
                    { 16, 1, "../images/Products/NYKANT_hylde_hvidolie_01.png", 6, 4 },
                    { 22, 0, "../images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", 10, 10 },
                    { 15, 0, "../images/Products/NYKANT_hylde_naturolie_01.png", 5, 6 },
                    { 14, 2, "../images/Products/NYKANT_hylde_sortolie_01.png", 5, 5 },
                    { 13, 1, "../images/Products/NYKANT_hylde_hvidolie_01.png", 5, 4 },
                    { 1, 0, "../images/Products/NYKANT_boejle_naturolie_01.png", 1, 1 },
                    { 2, 2, "../images/Products/NYKANT_boejle_sortolie_01.png", 1, 2 },
                    { 3, 1, "../images/Products/NYKANT_boejle_hvidolie_01.png", 1, 3 },
                    { 12, 0, "../images/Products/NYKANT_hylde_naturolie_01.png", 4, 6 },
                    { 20, 0, "../images/Products/NYKANT_kortbaenk_naturolie_01.png", 8, 8 },
                    { 10, 1, "../images/Products/NYKANT_hylde_hvidolie_01.png", 4, 4 },
                    { 4, 0, "../images/Products/NYKANT_boejle_naturolie_01.png", 2, 1 },
                    { 9, 1, "../images/Products/NYKANT_boejle_hvidolie_01.png", 3, 3 },
                    { 5, 2, "../images/Products/NYKANT_boejle_sortolie_01.png", 2, 2 },
                    { 19, 0, "../images/Products/NYKANT_bord_naturolie_01.png", 7, 7 },
                    { 6, 1, "../images/Products/NYKANT_boejle_hvidolie_01.png", 2, 3 },
                    { 8, 2, "../images/Products/NYKANT_boejle_sortolie_01.png", 3, 2 },
                    { 7, 0, "../images/Products/NYKANT_boejle_naturolie_01.png", 3, 1 },
                    { 11, 2, "../images/Products/NYKANT_hylde_sortolie_01.png", 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ProductId", "Source" },
                values: new object[,]
                {
                    { 3, 1, "../images/Products/NYKANT_boejle_naturolie_01.png" },
                    { 20, 8, "../images/Products/NYKANT_kortbaenk_naturolie_02.png" },
                    { 21, 8, "../images/Products/NYKANT_kortbaenk_naturolie_03.png" },
                    { 22, 9, "../images/Products/NYKANT_langbaenk_naturolie_01.png" },
                    { 6, 2, "../images/Products/NYKANT_boejle_sortolie_02.png" },
                    { 23, 9, "../images/Products/NYKANT_langbaenk_naturolie_02.png" },
                    { 26, 10, "../images/Products/NYKANT_opbevaringsbaenk_naturolie_02.png" },
                    { 5, 2, "../images/Products/NYKANT_boejle_sortolie_01.png" },
                    { 25, 10, "../images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png" },
                    { 27, 10, "../images/Products/NYKANT_opbevaringsbaenk_naturolie_03.png" },
                    { 28, 10, "../images/Products/NYKANT_opbevaringsbaenk_naturolie_04.png" },
                    { 29, 10, "../images/Products/NYKANT_opbevaringsbaenk_naturolie_05.png" },
                    { 19, 8, "../images/Products/NYKANT_kortbaenk_naturolie_01.png" },
                    { 31, 10, "../images/Products/NYKANT_opbevaringsbaenk_naturolie_07.png" },
                    { 4, 1, "../images/Products/NYKANT_boejle_naturolie_02.png" },
                    { 24, 9, "../images/Products/NYKANT_langbaenk_naturolie_03.png" },
                    { 30, 10, "../images/Products/NYKANT_opbevaringsbaenk_naturolie_06.png" },
                    { 2, 3, "../images/Products/NYKANT_boejle_hvidolie_02.png" },
                    { 36, 11, "../images/Products/NYKANT_rack_naturolie_05.png" },
                    { 10, 4, "../images/Products/NYKANT_hylde_hvidolie_01.png" },
                    { 16, 5, "../images/Products/NYKANT_hylde_sortolie_01.png" },
                    { 17, 5, "../images/Products/NYKANT_hylde_sortolie_02.png" },
                    { 18, 5, "../images/Products/NYKANT_hylde_sortolie_03.png" },
                    { 9, 7, "../images/Products/NYKANT_bord_naturolie_03.png" },
                    { 8, 7, "../images/Products/NYKANT_bord_naturolie_02.png" },
                    { 7, 7, "../images/Products/NYKANT_bord_naturolie_01.png" },
                    { 37, 11, "../images/Products/NYKANT_rack_naturolie_06.png" },
                    { 12, 4, "../images/Products/NYKANT_hylde_hvidolie_03.png" },
                    { 35, 11, "../images/Products/NYKANT_rack_naturolie_04.png" },
                    { 13, 6, "../images/Products/NYKANT_hylde_naturolie_01.png" },
                    { 14, 6, "../images/Products/NYKANT_hylde_naturolie_02.png" },
                    { 34, 11, "../images/Products/NYKANT_rack_naturolie_03.png" },
                    { 33, 11, "../images/Products/NYKANT_rack_naturolie_02.png" },
                    { 15, 6, "../images/Products/NYKANT_hylde_naturolie_03.png" },
                    { 1, 3, "../images/Products/NYKANT_boejle_hvidolie_01.png" },
                    { 32, 11, "../images/Products/NYKANT_rack_naturolie_01.png" },
                    { 11, 4, "../images/Products/NYKANT_hylde_hvidolie_02.png" }
                });

            migrationBuilder.InsertData(
                table: "ProductLength",
                columns: new[] { "Id", "Length", "ProductId", "ProductReferenceId" },
                values: new object[,]
                {
                    { 15, "800 mm.", 6, 6 },
                    { 8, "1000 mm.", 4, 6 },
                    { 6, "600 mm.", 4, 6 },
                    { 7, "800 mm.", 4, 6 },
                    { 16, "1000 mm.", 6, 6 },
                    { 9, "400 mm.", 5, 6 },
                    { 10, "600 mm.", 5, 6 },
                    { 4, "1700 mm.", 9, 9 },
                    { 3, "1150 mm.", 9, 8 },
                    { 11, "800 mm.", 5, 6 },
                    { 12, "1000 mm.", 5, 6 },
                    { 2, "1700 mm.", 8, 9 },
                    { 1, "1150 mm.", 8, 8 },
                    { 14, "600 mm.", 6, 6 },
                    { 5, "400 mm.", 4, 6 },
                    { 13, "400 mm.", 6, 6 }
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
