using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nykant.Migrations
{
    public partial class bagitemQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "BagItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModified",
                value: new DateTime(2021, 1, 15, 10, 39, 10, 684, DateTimeKind.Local).AddTicks(1492));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2021, 1, 15, 10, 39, 10, 686, DateTimeKind.Local).AddTicks(5007));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2021, 1, 15, 10, 39, 10, 686, DateTimeKind.Local).AddTicks(5070));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastModified",
                value: new DateTime(2021, 1, 15, 10, 39, 10, 686, DateTimeKind.Local).AddTicks(5075));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastModified",
                value: new DateTime(2021, 1, 15, 10, 39, 10, 686, DateTimeKind.Local).AddTicks(5078));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastModified",
                value: new DateTime(2021, 1, 15, 10, 39, 10, 686, DateTimeKind.Local).AddTicks(5080));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastModified",
                value: new DateTime(2021, 1, 15, 10, 39, 10, 686, DateTimeKind.Local).AddTicks(5083));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastModified",
                value: new DateTime(2021, 1, 15, 10, 39, 10, 686, DateTimeKind.Local).AddTicks(5086));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastModified",
                value: new DateTime(2021, 1, 15, 10, 39, 10, 686, DateTimeKind.Local).AddTicks(5088));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastModified",
                value: new DateTime(2021, 1, 15, 10, 39, 10, 686, DateTimeKind.Local).AddTicks(5091));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastModified",
                value: new DateTime(2021, 1, 15, 10, 39, 10, 686, DateTimeKind.Local).AddTicks(5095));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastModified",
                value: new DateTime(2021, 1, 15, 10, 39, 10, 686, DateTimeKind.Local).AddTicks(5097));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "LastModified",
                value: new DateTime(2021, 1, 15, 10, 39, 10, 686, DateTimeKind.Local).AddTicks(5100));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "LastModified",
                value: new DateTime(2021, 1, 15, 10, 39, 10, 686, DateTimeKind.Local).AddTicks(5102));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "LastModified",
                value: new DateTime(2021, 1, 15, 10, 39, 10, 686, DateTimeKind.Local).AddTicks(5105));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastModified",
                value: new DateTime(2021, 1, 15, 10, 39, 10, 686, DateTimeKind.Local).AddTicks(5108));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "LastModified",
                value: new DateTime(2021, 1, 15, 10, 39, 10, 686, DateTimeKind.Local).AddTicks(5111));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "LastModified",
                value: new DateTime(2021, 1, 15, 10, 39, 10, 686, DateTimeKind.Local).AddTicks(5113));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "LastModified",
                value: new DateTime(2021, 1, 15, 10, 39, 10, 686, DateTimeKind.Local).AddTicks(5116));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "BagItems");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 580, DateTimeKind.Local).AddTicks(6873));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(1891));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(1956));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(1961));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(1964));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(1967));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(1971));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(1977));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(1979));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(1983));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(1987));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(1991));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(1994));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(1998));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(2001));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(2004));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(2008));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(2011));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(2014));
        }
    }
}
