using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.data.migrations
{
    public partial class newers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModified",
                value: new DateTime(2021, 3, 8, 14, 4, 15, 410, DateTimeKind.Local).AddTicks(7941));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2021, 3, 8, 14, 4, 15, 413, DateTimeKind.Local).AddTicks(9946));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2021, 3, 8, 14, 4, 15, 414, DateTimeKind.Local).AddTicks(24));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastModified",
                value: new DateTime(2021, 3, 8, 14, 4, 15, 414, DateTimeKind.Local).AddTicks(30));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastModified",
                value: new DateTime(2021, 3, 8, 14, 4, 15, 414, DateTimeKind.Local).AddTicks(33));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastModified",
                value: new DateTime(2021, 3, 8, 14, 4, 15, 414, DateTimeKind.Local).AddTicks(35));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastModified",
                value: new DateTime(2021, 3, 8, 14, 4, 15, 414, DateTimeKind.Local).AddTicks(38));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastModified",
                value: new DateTime(2021, 3, 8, 14, 4, 15, 414, DateTimeKind.Local).AddTicks(41));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastModified",
                value: new DateTime(2021, 3, 8, 14, 4, 15, 414, DateTimeKind.Local).AddTicks(44));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastModified",
                value: new DateTime(2021, 3, 8, 14, 4, 15, 414, DateTimeKind.Local).AddTicks(91));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastModified",
                value: new DateTime(2021, 3, 8, 14, 4, 15, 414, DateTimeKind.Local).AddTicks(95));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastModified",
                value: new DateTime(2021, 3, 8, 14, 4, 15, 414, DateTimeKind.Local).AddTicks(97));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "LastModified",
                value: new DateTime(2021, 3, 8, 14, 4, 15, 414, DateTimeKind.Local).AddTicks(101));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "LastModified",
                value: new DateTime(2021, 3, 8, 14, 4, 15, 414, DateTimeKind.Local).AddTicks(104));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "LastModified",
                value: new DateTime(2021, 3, 8, 14, 4, 15, 414, DateTimeKind.Local).AddTicks(107));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastModified",
                value: new DateTime(2021, 3, 8, 14, 4, 15, 414, DateTimeKind.Local).AddTicks(109));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "LastModified",
                value: new DateTime(2021, 3, 8, 14, 4, 15, 414, DateTimeKind.Local).AddTicks(112));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "LastModified",
                value: new DateTime(2021, 3, 8, 14, 4, 15, 414, DateTimeKind.Local).AddTicks(115));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "LastModified",
                value: new DateTime(2021, 3, 8, 14, 4, 15, 414, DateTimeKind.Local).AddTicks(118));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModified",
                value: new DateTime(2021, 3, 3, 11, 14, 54, 313, DateTimeKind.Local).AddTicks(7349));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2021, 3, 3, 11, 14, 54, 316, DateTimeKind.Local).AddTicks(7188));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2021, 3, 3, 11, 14, 54, 316, DateTimeKind.Local).AddTicks(7262));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastModified",
                value: new DateTime(2021, 3, 3, 11, 14, 54, 316, DateTimeKind.Local).AddTicks(7268));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastModified",
                value: new DateTime(2021, 3, 3, 11, 14, 54, 316, DateTimeKind.Local).AddTicks(7272));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastModified",
                value: new DateTime(2021, 3, 3, 11, 14, 54, 316, DateTimeKind.Local).AddTicks(7274));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastModified",
                value: new DateTime(2021, 3, 3, 11, 14, 54, 316, DateTimeKind.Local).AddTicks(7278));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastModified",
                value: new DateTime(2021, 3, 3, 11, 14, 54, 316, DateTimeKind.Local).AddTicks(7281));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastModified",
                value: new DateTime(2021, 3, 3, 11, 14, 54, 316, DateTimeKind.Local).AddTicks(7284));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastModified",
                value: new DateTime(2021, 3, 3, 11, 14, 54, 316, DateTimeKind.Local).AddTicks(7287));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastModified",
                value: new DateTime(2021, 3, 3, 11, 14, 54, 316, DateTimeKind.Local).AddTicks(7291));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastModified",
                value: new DateTime(2021, 3, 3, 11, 14, 54, 316, DateTimeKind.Local).AddTicks(7294));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "LastModified",
                value: new DateTime(2021, 3, 3, 11, 14, 54, 316, DateTimeKind.Local).AddTicks(7297));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "LastModified",
                value: new DateTime(2021, 3, 3, 11, 14, 54, 316, DateTimeKind.Local).AddTicks(7299));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "LastModified",
                value: new DateTime(2021, 3, 3, 11, 14, 54, 316, DateTimeKind.Local).AddTicks(7302));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastModified",
                value: new DateTime(2021, 3, 3, 11, 14, 54, 316, DateTimeKind.Local).AddTicks(7305));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "LastModified",
                value: new DateTime(2021, 3, 3, 11, 14, 54, 316, DateTimeKind.Local).AddTicks(7308));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "LastModified",
                value: new DateTime(2021, 3, 3, 11, 14, 54, 316, DateTimeKind.Local).AddTicks(7311));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "LastModified",
                value: new DateTime(2021, 3, 3, 11, 14, 54, 316, DateTimeKind.Local).AddTicks(7313));
        }
    }
}
