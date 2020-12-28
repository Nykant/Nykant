using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nykant.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Session = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    ImageSource = table.Column<string>(nullable: true),
                    TypeOfWood = table.Column<string>(nullable: true),
                    ItemType = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "ImageSource", "ItemType", "LastModified", "Size", "TypeOfWood" },
                values: new object[,]
                {
                    { 1, "naturligt", "a test object", "~/wwwroot/images/Finback-Chairs1-1280x853-c-default.jpg", "stol", new DateTime(2020, 12, 28, 17, 29, 51, 473, DateTimeKind.Local).AddTicks(5872), "5mm", "valnød" },
                    { 2, "farvet-overflade", "a test object", "~/wwwroot/images/Finback-Chairs1-1280x853-c-default.jpg", "stol", new DateTime(2020, 12, 28, 17, 29, 51, 475, DateTimeKind.Local).AddTicks(5623), "10mm", "eg" },
                    { 3, "naturligt", "a test object", "~/wwwroot/images/Finback-Chairs1-1280x853-c-default.jpg", "bænk", new DateTime(2020, 12, 28, 17, 29, 51, 475, DateTimeKind.Local).AddTicks(5686), "20mm", "fyr" },
                    { 4, "farvet-overflade", "a test object", "~/wwwroot/images/Finback-Chairs1-1280x853-c-default.jpg", "skærebræt", new DateTime(2020, 12, 28, 17, 29, 51, 475, DateTimeKind.Local).AddTicks(5691), "5mm", "eg" },
                    { 5, "naturligt", "a test object", "~/wwwroot/images/Finback-Chairs1-1280x853-c-default.jpg", "bænk", new DateTime(2020, 12, 28, 17, 29, 51, 475, DateTimeKind.Local).AddTicks(5694), "10mm", "valnød" },
                    { 6, "farvet-overflade", "a test object", "~/wwwroot/images/Finback-Chairs1-1280x853-c-default.jpg", "skærebræt", new DateTime(2020, 12, 28, 17, 29, 51, 475, DateTimeKind.Local).AddTicks(5697), "20mm", "fyr" },
                    { 7, "naturligt", "a test object", "~/wwwroot/images/Finback-Chairs1-1280x853-c-default.jpg", "bænk", new DateTime(2020, 12, 28, 17, 29, 51, 475, DateTimeKind.Local).AddTicks(5699), "5mm", "valnød" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
