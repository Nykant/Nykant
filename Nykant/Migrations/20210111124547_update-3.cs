using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nykant.Migrations
{
    public partial class update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageSource",
                table: "Products");

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
                table: "Images",
                columns: new[] { "Id", "ProductId", "Source" },
                values: new object[,]
                {
                    { 1, 1, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 22, 3, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 23, 4, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 24, 5, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 25, 6, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 26, 7, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 27, 8, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 28, 9, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 21, 2, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 30, 11, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 32, 13, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 33, 14, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 34, 15, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 35, 16, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 36, 17, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 37, 18, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 38, 19, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 31, 12, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 20, 1, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 29, 10, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 18, 18, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 4, 4, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 5, 5, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 6, 6, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 7, 7, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 8, 8, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 9, 9, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 10, 10, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 19, 19, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 11, 11, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 12, 12, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 13, 13, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 14, 14, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 15, 15, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 16, 16, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 17, 17, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 3, 3, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 2, 2, "../images/Finback-Chairs1-1280x853-c-default.jpg" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 556, DateTimeKind.Local).AddTicks(6412));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7049));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7114));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7120));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7124));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7126));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7129));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7132));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7135));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7137));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7140));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7143));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7146));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7149));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7151));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7154));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7157));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7160));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7164));

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.AddColumn<string>(
                name: "ImageSource",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 7, 10, 13, 31, 870, DateTimeKind.Local).AddTicks(9837) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(3962) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4028) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4033) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4036) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4039) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4042) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4044) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4047) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4049) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4052) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4055) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4057) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4060) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4062) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4065) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4068) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4070) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 7, 10, 13, 31, 873, DateTimeKind.Local).AddTicks(4073) });
        }
    }
}
