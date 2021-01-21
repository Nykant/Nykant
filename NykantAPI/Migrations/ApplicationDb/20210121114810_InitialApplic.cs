using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.Migrations.ApplicationDb
{
    public partial class InitialApplic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bags",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bags", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Postal = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    ImageSource = table.Column<string>(nullable: true),
                    TypeOfWood = table.Column<string>(nullable: true),
                    ItemType = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Alt = table.Column<string>(nullable: true),
                    BagUserId = table.Column<string>(nullable: true),
                    OrderUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Bags_BagUserId",
                        column: x => x.BagUserId,
                        principalTable: "Bags",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Orders_OrderUserId",
                        column: x => x.OrderUserId,
                        principalTable: "Orders",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BagItems",
                columns: table => new
                {
                    BagId = table.Column<string>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BagItems", x => new { x.BagId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_BagItems_Bags_BagId",
                        column: x => x.BagId,
                        principalTable: "Bags",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Alt", "BagUserId", "Color", "Description", "ImageSource", "ItemType", "LastModified", "Name", "OrderUserId", "Price", "Size", "Title", "TypeOfWood" },
                values: new object[,]
                {
                    { 1, null, null, "naturligt", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "stol", new DateTime(2021, 1, 21, 12, 47, 59, 266, DateTimeKind.Local).AddTicks(6140), null, null, 1000, "5mm", "Grøntsags Skærebræt", "valnød" },
                    { 17, null, null, "naturligt", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "bænk", new DateTime(2021, 1, 21, 12, 47, 59, 269, DateTimeKind.Local).AddTicks(2301), null, null, 1000, "10mm", "Grøntsags Skærebræt", "valnød" },
                    { 16, null, null, "farvet-overflade", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "skærebræt", new DateTime(2021, 1, 21, 12, 47, 59, 269, DateTimeKind.Local).AddTicks(2298), null, null, 1000, "5mm", "Grøntsags Skærebræt", "eg" },
                    { 15, null, null, "naturligt", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "bænk", new DateTime(2021, 1, 21, 12, 47, 59, 269, DateTimeKind.Local).AddTicks(2296), null, null, 1000, "20mm", "Grøntsags Skærebræt", "fyr" },
                    { 14, null, null, "farvet-overflade", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "stol", new DateTime(2021, 1, 21, 12, 47, 59, 269, DateTimeKind.Local).AddTicks(2292), null, null, 1000, "10mm", "Grøntsags Skærebræt", "eg" },
                    { 13, null, null, "naturligt", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "stol", new DateTime(2021, 1, 21, 12, 47, 59, 269, DateTimeKind.Local).AddTicks(2261), null, null, 1000, "5mm", "Grøntsags Skærebræt", "valnød" },
                    { 12, null, null, "farvet-overflade", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "skærebræt", new DateTime(2021, 1, 21, 12, 47, 59, 269, DateTimeKind.Local).AddTicks(2257), null, null, 1000, "20mm", "Grøntsags Skærebræt", "fyr" },
                    { 11, null, null, "naturligt", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "bænk", new DateTime(2021, 1, 21, 12, 47, 59, 269, DateTimeKind.Local).AddTicks(2255), null, null, 1000, "10mm", "Grøntsags Skærebræt", "valnød" },
                    { 18, null, null, "farvet-overflade", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "skærebræt", new DateTime(2021, 1, 21, 12, 47, 59, 269, DateTimeKind.Local).AddTicks(2304), null, null, 1000, "20mm", "Grøntsags Skærebræt", "fyr" },
                    { 10, null, null, "farvet-overflade", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "skærebræt", new DateTime(2021, 1, 21, 12, 47, 59, 269, DateTimeKind.Local).AddTicks(2252), null, null, 1000, "5mm", "Grøntsags Skærebræt", "eg" },
                    { 8, null, null, "farvet-overflade", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "stol", new DateTime(2021, 1, 21, 12, 47, 59, 269, DateTimeKind.Local).AddTicks(2247), null, null, 1000, "10mm", "Grøntsags Skærebræt", "eg" },
                    { 7, null, null, "naturligt", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "stol", new DateTime(2021, 1, 21, 12, 47, 59, 269, DateTimeKind.Local).AddTicks(2244), null, null, 1000, "5mm", "Grøntsags Skærebræt", "valnød" },
                    { 6, null, null, "farvet-overflade", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "skærebræt", new DateTime(2021, 1, 21, 12, 47, 59, 269, DateTimeKind.Local).AddTicks(2241), null, null, 1000, "20mm", "Grøntsags Skærebræt", "fyr" },
                    { 5, null, null, "naturligt", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "bænk", new DateTime(2021, 1, 21, 12, 47, 59, 269, DateTimeKind.Local).AddTicks(2239), null, null, 1000, "10mm", "Grøntsags Skærebræt", "valnød" },
                    { 4, null, null, "farvet-overflade", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "skærebræt", new DateTime(2021, 1, 21, 12, 47, 59, 269, DateTimeKind.Local).AddTicks(2236), null, null, 1000, "5mm", "Grøntsags Skærebræt", "eg" },
                    { 3, null, null, "naturligt", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "bænk", new DateTime(2021, 1, 21, 12, 47, 59, 269, DateTimeKind.Local).AddTicks(2230), null, null, 1000, "20mm", "Grøntsags Skærebræt", "fyr" },
                    { 2, null, null, "farvet-overflade", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "stol", new DateTime(2021, 1, 21, 12, 47, 59, 269, DateTimeKind.Local).AddTicks(2170), null, null, 1000, "10mm", "Grøntsags Skærebræt", "eg" },
                    { 9, null, null, "naturligt", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "bænk", new DateTime(2021, 1, 21, 12, 47, 59, 269, DateTimeKind.Local).AddTicks(2249), null, null, 1000, "20mm", "Grøntsags Skærebræt", "fyr" },
                    { 19, null, null, "naturligt", "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "bænk", new DateTime(2021, 1, 21, 12, 47, 59, 269, DateTimeKind.Local).AddTicks(2306), null, null, 1000, "5mm", "Grøntsags Skærebræt", "valnød" }
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
                name: "IX_Products_BagUserId",
                table: "Products",
                column: "BagUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderUserId",
                table: "Products",
                column: "OrderUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BagItems");

            migrationBuilder.DropTable(
                name: "CustomerInfos");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Bags");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
