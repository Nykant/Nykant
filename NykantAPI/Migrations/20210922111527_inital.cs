using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerInfs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Address1 = table.Column<string>(nullable: false),
                    Address2 = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    Postal = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInfs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingDeliveries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingDeliveries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Path = table.Column<string>(nullable: true),
                    ImageSource = table.Column<string>(nullable: true),
                    ImageSource2 = table.Column<string>(nullable: true),
                    TypeOfWood = table.Column<string>(nullable: true),
                    ItemType = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Alt = table.Column<string>(nullable: true),
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
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(nullable: true),
                    CustomerInfId = table.Column<int>(nullable: false),
                    ShippingDeliveryId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<string>(nullable: false),
                    Currency = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    PaymentIntent_Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_CustomerInfs_CustomerInfId",
                        column: x => x.CustomerInfId,
                        principalTable: "CustomerInfs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_ShippingDeliveries_ShippingDeliveryId",
                        column: x => x.ShippingDeliveryId,
                        principalTable: "ShippingDeliveries",
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Stole" },
                    { 2, "Borde" },
                    { 3, "Skærebrætter" },
                    { 4, "Ophæng" },
                    { 5, "Tilbehør" }
                });

            migrationBuilder.InsertData(
                table: "ShippingDeliveries",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "GLS", 35 },
                    { 2, "PostNord", 50 },
                    { 3, "GLS Privat", 65 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Alt", "CategoryId", "Color", "Description", "ImageSource", "ImageSource2", "ItemType", "LastModified", "Name", "Path", "Price", "Size", "Title", "TypeOfWood" },
                values: new object[,]
                {
                    { 1, null, 1, "naturligt", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "../images/gyngestol.jpg", "stol", new DateTime(2021, 9, 22, 13, 15, 12, 720, DateTimeKind.Local).AddTicks(4520), null, "wwwroot/images/gyngestol.jpg", 1000, "5mm", "Grøntsags Skærebræt", "valnød" },
                    { 17, null, 4, "naturligt", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "../images/gyngestol.jpg", "bænk", new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4465), null, "wwwroot/images/gyngestol.jpg", 1000, "10mm", "Grøntsags Skærebræt", "valnød" },
                    { 13, null, 4, "naturligt", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "../images/gyngestol.jpg", "stol", new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4453), null, "wwwroot/images/gyngestol.jpg", 1000, "5mm", "Grøntsags Skærebræt", "valnød" },
                    { 4, null, 4, "farvet-overflade", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "../images/gyngestol.jpg", "skærebræt", new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4425), null, "wwwroot/images/gyngestol.jpg", 1000, "5mm", "Grøntsags Skærebræt", "eg" },
                    { 18, null, 3, "farvet-overflade", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "../images/gyngestol.jpg", "skærebræt", new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4468), null, "wwwroot/images/gyngestol.jpg", 1000, "20mm", "Grøntsags Skærebræt", "fyr" },
                    { 15, null, 3, "naturligt", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "../images/gyngestol.jpg", "bænk", new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4459), null, "wwwroot/images/gyngestol.jpg", 1000, "20mm", "Grøntsags Skærebræt", "fyr" },
                    { 7, null, 3, "naturligt", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "../images/gyngestol.jpg", "stol", new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4434), null, "wwwroot/images/gyngestol.jpg", 1000, "5mm", "Grøntsags Skærebræt", "valnød" },
                    { 3, null, 3, "naturligt", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "../images/gyngestol.jpg", "bænk", new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4419), null, "wwwroot/images/gyngestol.jpg", 1000, "20mm", "Grøntsags Skærebræt", "fyr" },
                    { 5, null, 5, "naturligt", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "../images/gyngestol.jpg", "bænk", new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4428), null, "wwwroot/images/gyngestol.jpg", 1000, "10mm", "Grøntsags Skærebræt", "valnød" },
                    { 19, null, 2, "naturligt", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "../images/gyngestol.jpg", "bænk", new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4471), null, "wwwroot/images/gyngestol.jpg", 1000, "5mm", "Grøntsags Skærebræt", "valnød" },
                    { 12, null, 2, "farvet-overflade", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "../images/gyngestol.jpg", "skærebræt", new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4449), null, "wwwroot/images/gyngestol.jpg", 1000, "20mm", "Grøntsags Skærebræt", "fyr" },
                    { 8, null, 2, "farvet-overflade", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "../images/gyngestol.jpg", "stol", new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4437), null, "wwwroot/images/gyngestol.jpg", 1000, "10mm", "Grøntsags Skærebræt", "eg" },
                    { 2, null, 2, "farvet-overflade", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "../images/gyngestol.jpg", "stol", new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4341), null, "wwwroot/images/gyngestol.jpg", 1000, "10mm", "Grøntsags Skærebræt", "eg" },
                    { 14, null, 1, "farvet-overflade", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "../images/gyngestol.jpg", "stol", new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4456), null, "wwwroot/images/gyngestol.jpg", 1000, "10mm", "Grøntsags Skærebræt", "eg" },
                    { 11, null, 1, "naturligt", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "../images/gyngestol.jpg", "bænk", new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4446), null, "wwwroot/images/gyngestol.jpg", 1000, "10mm", "Grøntsags Skærebræt", "valnød" },
                    { 9, null, 1, "naturligt", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "../images/gyngestol.jpg", "bænk", new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4440), null, "wwwroot/images/gyngestol.jpg", 1000, "20mm", "Grøntsags Skærebræt", "fyr" },
                    { 6, null, 1, "farvet-overflade", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "../images/gyngestol.jpg", "skærebræt", new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4431), null, "wwwroot/images/gyngestol.jpg", 1000, "20mm", "Grøntsags Skærebræt", "fyr" },
                    { 16, null, 2, "farvet-overflade", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "../images/gyngestol.jpg", "skærebræt", new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4462), null, "wwwroot/images/gyngestol.jpg", 1000, "5mm", "Grøntsags Skærebræt", "eg" },
                    { 10, null, 5, "farvet-overflade", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "../images/gyngestol.jpg", "skærebræt", new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4442), null, "wwwroot/images/gyngestol.jpg", 1000, "5mm", "Grøntsags Skærebræt", "eg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ProductId", "Source" },
                values: new object[,]
                {
                    { 1, 1, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 74, 18, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 55, 18, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 37, 18, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 18, 18, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 71, 15, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 52, 15, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 34, 15, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 4, 4, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 15, 15, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 44, 7, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 26, 7, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 7, 7, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 77, 3, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 59, 3, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 40, 3, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 22, 3, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 63, 7, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 3, 3, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 23, 4, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 60, 4, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 29, 10, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 10, 10, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 79, 5, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 61, 5, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 42, 5, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 24, 5, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 5, 5, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 41, 4, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 73, 17, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 36, 17, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 17, 17, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 69, 13, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 50, 13, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 32, 13, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 13, 13, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 78, 4, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 54, 17, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 56, 19, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 19, 19, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 72, 16, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 48, 11, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 30, 11, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 11, 11, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 65, 9, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 46, 9, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 28, 9, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 9, 9, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 67, 11, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 80, 6, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 43, 6, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 25, 6, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 6, 6, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 75, 1, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 57, 1, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 38, 1, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 20, 1, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 62, 6, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 14, 14, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 33, 14, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 51, 14, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 53, 16, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 35, 16, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 16, 16, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 68, 12, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 49, 12, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 31, 12, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 12, 12, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 64, 8, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 45, 8, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 27, 8, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 8, 8, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 76, 2, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 58, 2, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 39, 2, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 21, 2, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 2, 2, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 70, 14, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 47, 10, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 66, 10, "../images/Finback-Chairs1-1280x853-c-default.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BagItems_ProductId",
                table: "BagItems",
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
                name: "IX_Orders_CustomerInfId",
                table: "Orders",
                column: "CustomerInfId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingDeliveryId",
                table: "Orders",
                column: "ShippingDeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BagItems");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "CustomerInfs");

            migrationBuilder.DropTable(
                name: "ShippingDeliveries");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
