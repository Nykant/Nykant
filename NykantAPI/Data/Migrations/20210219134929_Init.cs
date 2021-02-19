using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerInfs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    LastName = table.Column<string>(maxLength: 20, nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: false),
                    City = table.Column<string>(maxLength: 20, nullable: false),
                    Country = table.Column<string>(maxLength: 20, nullable: false),
                    Postal = table.Column<string>(maxLength: 20, nullable: false),
                    Phone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInfs", x => x.Id);
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
                    ImageSource = table.Column<string>(nullable: true),
                    TypeOfWood = table.Column<string>(nullable: true),
                    ItemType = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Alt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
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
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(nullable: true),
                    CustomerInfId = table.Column<int>(nullable: false),
                    ShippingDeliveryId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<int>(nullable: false),
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
                table: "Products",
                columns: new[] { "Id", "Alt", "Color", "Description", "ImageSource", "ItemType", "LastModified", "Name", "Price", "Size", "Title", "TypeOfWood" },
                values: new object[,]
                {
                    { 1, null, "naturligt", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "stol", new DateTime(2021, 2, 19, 14, 49, 14, 337, DateTimeKind.Local).AddTicks(2846), null, 1000, "5mm", "Grøntsags Skærebræt", "valnød" },
                    { 19, null, "naturligt", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "bænk", new DateTime(2021, 2, 19, 14, 49, 14, 340, DateTimeKind.Local).AddTicks(3971), null, 1000, "5mm", "Grøntsags Skærebræt", "valnød" },
                    { 18, null, "farvet-overflade", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "skærebræt", new DateTime(2021, 2, 19, 14, 49, 14, 340, DateTimeKind.Local).AddTicks(3968), null, 1000, "20mm", "Grøntsags Skærebræt", "fyr" },
                    { 17, null, "naturligt", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "bænk", new DateTime(2021, 2, 19, 14, 49, 14, 340, DateTimeKind.Local).AddTicks(3966), null, 1000, "10mm", "Grøntsags Skærebræt", "valnød" },
                    { 16, null, "farvet-overflade", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "skærebræt", new DateTime(2021, 2, 19, 14, 49, 14, 340, DateTimeKind.Local).AddTicks(3963), null, 1000, "5mm", "Grøntsags Skærebræt", "eg" },
                    { 15, null, "naturligt", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "bænk", new DateTime(2021, 2, 19, 14, 49, 14, 340, DateTimeKind.Local).AddTicks(3961), null, 1000, "20mm", "Grøntsags Skærebræt", "fyr" },
                    { 14, null, "farvet-overflade", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "stol", new DateTime(2021, 2, 19, 14, 49, 14, 340, DateTimeKind.Local).AddTicks(3958), null, 1000, "10mm", "Grøntsags Skærebræt", "eg" },
                    { 13, null, "naturligt", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "stol", new DateTime(2021, 2, 19, 14, 49, 14, 340, DateTimeKind.Local).AddTicks(3956), null, 1000, "5mm", "Grøntsags Skærebræt", "valnød" },
                    { 12, null, "farvet-overflade", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "skærebræt", new DateTime(2021, 2, 19, 14, 49, 14, 340, DateTimeKind.Local).AddTicks(3953), null, 1000, "20mm", "Grøntsags Skærebræt", "fyr" },
                    { 11, null, "naturligt", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "bænk", new DateTime(2021, 2, 19, 14, 49, 14, 340, DateTimeKind.Local).AddTicks(3950), null, 1000, "10mm", "Grøntsags Skærebræt", "valnød" },
                    { 9, null, "naturligt", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "bænk", new DateTime(2021, 2, 19, 14, 49, 14, 340, DateTimeKind.Local).AddTicks(3945), null, 1000, "20mm", "Grøntsags Skærebræt", "fyr" },
                    { 8, null, "farvet-overflade", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "stol", new DateTime(2021, 2, 19, 14, 49, 14, 340, DateTimeKind.Local).AddTicks(3943), null, 1000, "10mm", "Grøntsags Skærebræt", "eg" },
                    { 7, null, "naturligt", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "stol", new DateTime(2021, 2, 19, 14, 49, 14, 340, DateTimeKind.Local).AddTicks(3940), null, 1000, "5mm", "Grøntsags Skærebræt", "valnød" },
                    { 6, null, "farvet-overflade", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "skærebræt", new DateTime(2021, 2, 19, 14, 49, 14, 340, DateTimeKind.Local).AddTicks(3937), null, 1000, "20mm", "Grøntsags Skærebræt", "fyr" },
                    { 5, null, "naturligt", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "bænk", new DateTime(2021, 2, 19, 14, 49, 14, 340, DateTimeKind.Local).AddTicks(3934), null, 1000, "10mm", "Grøntsags Skærebræt", "valnød" },
                    { 4, null, "farvet-overflade", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "skærebræt", new DateTime(2021, 2, 19, 14, 49, 14, 340, DateTimeKind.Local).AddTicks(3931), null, 1000, "5mm", "Grøntsags Skærebræt", "eg" },
                    { 3, null, "naturligt", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "bænk", new DateTime(2021, 2, 19, 14, 49, 14, 340, DateTimeKind.Local).AddTicks(3926), null, 1000, "20mm", "Grøntsags Skærebræt", "fyr" },
                    { 2, null, "farvet-overflade", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "stol", new DateTime(2021, 2, 19, 14, 49, 14, 340, DateTimeKind.Local).AddTicks(3864), null, 1000, "10mm", "Grøntsags Skærebræt", "eg" },
                    { 10, null, "farvet-overflade", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "skærebræt", new DateTime(2021, 2, 19, 14, 49, 14, 340, DateTimeKind.Local).AddTicks(3948), null, 1000, "5mm", "Grøntsags Skærebræt", "eg" }
                });

            migrationBuilder.InsertData(
                table: "ShippingDeliveries",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 2, "PostNord", 50 },
                    { 1, "GLS", 35 },
                    { 3, "GLS Privat", 65 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ProductId", "Source" },
                values: new object[,]
                {
                    { 1, 1, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 30, 11, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 12, 12, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 31, 12, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 13, 13, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 32, 13, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 14, 14, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 33, 14, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 15, 15, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 34, 15, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 16, 16, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 35, 16, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 17, 17, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 36, 17, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 18, 18, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 37, 18, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 11, 11, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 29, 10, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 10, 10, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 28, 9, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 20, 1, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 2, 2, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 21, 2, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 3, 3, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 22, 3, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 4, 4, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 23, 4, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 19, 19, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 5, 5, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 6, 6, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 25, 6, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 7, 7, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 26, 7, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 8, 8, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 27, 8, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 9, 9, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 24, 5, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 38, 19, "../images/Finback-Chairs1-1280x853-c-default.jpg" }
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
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "CustomerInfs");

            migrationBuilder.DropTable(
                name: "ShippingDeliveries");
        }
    }
}
