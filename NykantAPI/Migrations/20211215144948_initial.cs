using System;
using Microsoft.EntityFrameworkCore.Metadata;
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
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ImgSource = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
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
                    Number = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    ImageSource = table.Column<string>(nullable: true),
                    ImageSource2 = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    Materials = table.Column<string>(nullable: true),
                    Oil = table.Column<string>(nullable: true),
                    Alt = table.Column<string>(nullable: true),
                    WeightInKg = table.Column<double>(nullable: false),
                    Size = table.Column<string>(nullable: true),
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
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
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
                    Currency = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
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
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
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
                    ProductSourceId = table.Column<int>(nullable: false)
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
                    { 1, "../images/Products/NYKANT_rack_naturolie_02.png", "Tøjstativer" },
                    { 2, "../images/Products/NYKANT_bord_naturolie_02.png", "Borde" },
                    { 3, "../images/Products/NYKANT_hylde_naturolie_01.png", "Hylder" },
                    { 4, "../images/Products/NYKANT_opbevaringsbaenk_naturolie_03.png", "Bænke" },
                    { 5, "../images/Products/NYKANT_boejle_naturolie_01.png", "Bøjler" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Alt", "CategoryId", "Description", "ImageSource", "ImageSource2", "Materials", "Name", "Note", "Number", "Oil", "Path", "Price", "Size", "WeightInKg" },
                values: new object[,]
                {
                    { 11, null, 1, "Nora Description", "../images/Products/NYKANT_rack_naturolie_01.png", "../images/Products/NYKANT_rack_naturolie_02.png", "Nora Materials", "Nora Tøjstativ", "Nora Note", "101", "Naturolie", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", 2295.0, "Nora Size", 13.4 },
                    { 7, null, 2, "Dagmar Description", "../images/Products/NYKANT_bord_naturolie_01.png", "../images/Products/NYKANT_bord_naturolie_02.png", "Dagmar Materials", "Dagmar Bordet", "Dagmar Note", "101", "Naturolie", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_bord_naturolie_01.png", 2995.0, "Dagmar Size", 22.0 },
                    { 4, null, 3, "Ingeborg Description", "../images/Products/NYKANT_hylde_hvidolie_01.png", "../images/Products/NYKANT_hylde_hvidolie_02.png", "Ingeborg Materials", "Ingeborg Hylden", "Ingeborg Note", "101", "Hvidolie", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_hvidolie_01.png", 595.0, "Ingeborg Size", 11.6 },
                    { 5, null, 3, "Ingeborg Description", "../images/Products/NYKANT_hylde_sortolie_01.png", "../images/Products/NYKANT_hylde_sortolie_02.png", "Ingeborg Materials", "Ingeborg Hylden", "Ingeborg Note", "101", "Sortolie", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_sortolie_01.png", 595.0, "Ingeborg Size", 11.6 },
                    { 6, null, 3, "Ingeborg Description", "../images/Products/NYKANT_hylde_naturolie_01.png", "../images/Products/NYKANT_hylde_naturolie_02.png", "Ingeborg Materials", "Ingeborg Hylden", "Ingeborg Note", "101", "Naturolie", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_naturolie_01.png", 595.0, "Ingeborg Size", 11.6 },
                    { 8, null, 4, "Thyra Description", "../images/Products/NYKANT_kortbaenk_naturolie_01.png", "../images/Products/NYKANT_kortbaenk_naturolie_02.png", "Thyra Materials", "Thyra Kortbænken", "Thyra Note", "101", "Naturolie", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_kortbaenk_naturolie_01.png", 2985.0, "Thyra Size", 14.0 },
                    { 9, null, 4, "Thyra Description", "../images/Products/NYKANT_langbaenk_naturolie_01.png", "../images/Products/NYKANT_langbaenk_naturolie_02.png", "Thyra Materials", "Thyra Langbænken", "Thyra Note", "101", "Naturolie", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_langbaenk_naturolie_01.png", 3885.0, "Thyra Size", 20.0 },
                    { 10, null, 4, "Filippa Description", "../images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", "../images/Products/NYKANT_opbevaringsbaenk_naturolie_02.png", "Filippa Materials", "Filippa Bænk", "Filippa Note", "101", "Naturolie", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", 4395.0, "Filippa Size", 24.0 },
                    { 1, null, 5, "Gertrud Description", "../images/Products/NYKANT_boejle_naturolie_01.png", "../images/Products/NYKANT_boejle_naturolie_02.png", "Gertrud Materials", "Bøjlen Gertrud", "Gertrud Note", "101", "Naturolie", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_boejle_naturolie_01.png", 375.0, "Gertrud Size", 11.6 },
                    { 2, null, 5, "Gertrud Description", "../images/Products/NYKANT_boejle_sortolie_01.png", "../images/Products/NYKANT_boejle_sortolie_02.png", "Gertrud Materials", "Bøjlen Gertrud", "Gertrud Note", "101", "Sortolie", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_boejle_sortolie_01.png", 375.0, "Gertrud Size", 11.6 },
                    { 3, null, 5, "Gertrud Description", "../images/Products/NYKANT_boejle_hvidolie_01.png", "../images/Products/NYKANT_boejle_hvidolie_02.png", "Gertrud Materials", "Bøjlen Gertrud", "Gertrud Note", "101", "Hvidolie", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_boejle_hvidolie_01.png", 375.0, "Gertrud Size", 11.6 }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "ImgSrc", "ProductId", "ProductSourceId" },
                values: new object[,]
                {
                    { 23, "../images/Products/NYKANT_rack_naturolie_01.png", 11, 11 },
                    { 16, "../images/Products/NYKANT_hylde_hvidolie_01.png", 6, 4 },
                    { 17, "../images/Products/NYKANT_hylde_sortolie_01.png", 6, 5 },
                    { 18, "../images/Products/NYKANT_hylde_naturolie_01.png", 6, 6 },
                    { 21, "../images/Products/NYKANT_langbaenk_naturolie_01.png", 9, 9 },
                    { 22, "../images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", 10, 10 },
                    { 1, "../images/Products/NYKANT_boejle_naturolie_01.png", 1, 1 },
                    { 15, "../images/Products/NYKANT_hylde_naturolie_01.png", 5, 6 },
                    { 2, "../images/Products/NYKANT_boejle_sortolie_01.png", 1, 2 },
                    { 4, "../images/Products/NYKANT_boejle_naturolie_01.png", 2, 1 },
                    { 5, "../images/Products/NYKANT_boejle_sortolie_01.png", 2, 2 },
                    { 6, "../images/Products/NYKANT_boejle_hvidolie_01.png", 2, 3 },
                    { 7, "../images/Products/NYKANT_boejle_naturolie_01.png", 3, 1 },
                    { 8, "../images/Products/NYKANT_boejle_sortolie_01.png", 3, 2 },
                    { 9, "../images/Products/NYKANT_boejle_hvidolie_01.png", 3, 3 },
                    { 3, "../images/Products/NYKANT_boejle_hvidolie_01.png", 1, 3 },
                    { 14, "../images/Products/NYKANT_hylde_sortolie_01.png", 5, 5 },
                    { 20, "../images/Products/NYKANT_kortbaenk_naturolie_01.png", 8, 8 },
                    { 10, "../images/Products/NYKANT_hylde_hvidolie_01.png", 4, 4 },
                    { 12, "../images/Products/NYKANT_hylde_naturolie_01.png", 4, 6 },
                    { 11, "../images/Products/NYKANT_hylde_sortolie_01.png", 4, 5 },
                    { 19, "../images/Products/NYKANT_bord_naturolie_01.png", 7, 7 },
                    { 13, "../images/Products/NYKANT_hylde_hvidolie_01.png", 5, 4 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ProductId", "Source" },
                values: new object[,]
                {
                    { 12, 4, "../images/Products/NYKANT_hylde_hvidolie_03.png" },
                    { 29, 10, "../images/Products/NYKANT_opbevaringsbaenk_naturolie_05.png" },
                    { 30, 10, "../images/Products/NYKANT_opbevaringsbaenk_naturolie_06.png" },
                    { 31, 10, "../images/Products/NYKANT_opbevaringsbaenk_naturolie_07.png" },
                    { 8, 7, "../images/Products/NYKANT_bord_naturolie_02.png" },
                    { 7, 7, "../images/Products/NYKANT_bord_naturolie_01.png" },
                    { 3, 1, "../images/Products/NYKANT_boejle_naturolie_01.png" },
                    { 37, 11, "../images/Products/NYKANT_rack_naturolie_06.png" },
                    { 36, 11, "../images/Products/NYKANT_rack_naturolie_05.png" },
                    { 35, 11, "../images/Products/NYKANT_rack_naturolie_04.png" },
                    { 5, 2, "../images/Products/NYKANT_boejle_sortolie_01.png" },
                    { 6, 2, "../images/Products/NYKANT_boejle_sortolie_02.png" },
                    { 34, 11, "../images/Products/NYKANT_rack_naturolie_03.png" },
                    { 33, 11, "../images/Products/NYKANT_rack_naturolie_02.png" },
                    { 32, 11, "../images/Products/NYKANT_rack_naturolie_01.png" },
                    { 4, 1, "../images/Products/NYKANT_boejle_naturolie_02.png" },
                    { 28, 10, "../images/Products/NYKANT_opbevaringsbaenk_naturolie_04.png" },
                    { 25, 10, "../images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png" },
                    { 26, 10, "../images/Products/NYKANT_opbevaringsbaenk_naturolie_02.png" },
                    { 11, 4, "../images/Products/NYKANT_hylde_hvidolie_02.png" },
                    { 16, 5, "../images/Products/NYKANT_hylde_sortolie_01.png" },
                    { 17, 5, "../images/Products/NYKANT_hylde_sortolie_02.png" },
                    { 18, 5, "../images/Products/NYKANT_hylde_sortolie_03.png" },
                    { 10, 4, "../images/Products/NYKANT_hylde_hvidolie_01.png" },
                    { 13, 6, "../images/Products/NYKANT_hylde_naturolie_01.png" },
                    { 14, 6, "../images/Products/NYKANT_hylde_naturolie_02.png" },
                    { 27, 10, "../images/Products/NYKANT_opbevaringsbaenk_naturolie_03.png" },
                    { 15, 6, "../images/Products/NYKANT_hylde_naturolie_03.png" },
                    { 19, 8, "../images/Products/NYKANT_kortbaenk_naturolie_01.png" },
                    { 20, 8, "../images/Products/NYKANT_kortbaenk_naturolie_02.png" },
                    { 21, 8, "../images/Products/NYKANT_kortbaenk_naturolie_03.png" },
                    { 22, 9, "../images/Products/NYKANT_langbaenk_naturolie_01.png" },
                    { 23, 9, "../images/Products/NYKANT_langbaenk_naturolie_02.png" },
                    { 24, 9, "../images/Products/NYKANT_langbaenk_naturolie_03.png" },
                    { 9, 7, "../images/Products/NYKANT_bord_naturolie_03.png" },
                    { 1, 3, "../images/Products/NYKANT_boejle_hvidolie_01.png" },
                    { 2, 3, "../images/Products/NYKANT_boejle_hvidolie_02.png" }
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
                name: "Images");

            migrationBuilder.DropTable(
                name: "NewsSubs");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ParcelshopData");

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
