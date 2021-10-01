using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.Migrations
{
    public partial class addit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Region",
                table: "ShippingAddress");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "BillingAddress");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 13, 42, 13, 119, DateTimeKind.Local).AddTicks(6491));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 13, 42, 13, 121, DateTimeKind.Local).AddTicks(7988));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 13, 42, 13, 121, DateTimeKind.Local).AddTicks(8065));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 13, 42, 13, 121, DateTimeKind.Local).AddTicks(8071));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 13, 42, 13, 121, DateTimeKind.Local).AddTicks(8075));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 13, 42, 13, 121, DateTimeKind.Local).AddTicks(8077));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 13, 42, 13, 121, DateTimeKind.Local).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 13, 42, 13, 121, DateTimeKind.Local).AddTicks(8083));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 13, 42, 13, 121, DateTimeKind.Local).AddTicks(8087));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 13, 42, 13, 121, DateTimeKind.Local).AddTicks(8090));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 13, 42, 13, 121, DateTimeKind.Local).AddTicks(8093));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 13, 42, 13, 121, DateTimeKind.Local).AddTicks(8096));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 13, 42, 13, 121, DateTimeKind.Local).AddTicks(8098));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 13, 42, 13, 121, DateTimeKind.Local).AddTicks(8101));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 13, 42, 13, 121, DateTimeKind.Local).AddTicks(8104));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 13, 42, 13, 121, DateTimeKind.Local).AddTicks(8107));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 13, 42, 13, 121, DateTimeKind.Local).AddTicks(8110));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 13, 42, 13, 121, DateTimeKind.Local).AddTicks(8113));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 13, 42, 13, 121, DateTimeKind.Local).AddTicks(8116));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "ShippingAddress",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "BillingAddress",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 18, 21, 716, DateTimeKind.Local).AddTicks(1535));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 18, 21, 718, DateTimeKind.Local).AddTicks(2137));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 18, 21, 718, DateTimeKind.Local).AddTicks(2211));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 18, 21, 718, DateTimeKind.Local).AddTicks(2218));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 18, 21, 718, DateTimeKind.Local).AddTicks(2222));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 18, 21, 718, DateTimeKind.Local).AddTicks(2225));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 18, 21, 718, DateTimeKind.Local).AddTicks(2228));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 18, 21, 718, DateTimeKind.Local).AddTicks(2231));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 18, 21, 718, DateTimeKind.Local).AddTicks(2234));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 18, 21, 718, DateTimeKind.Local).AddTicks(2237));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 18, 21, 718, DateTimeKind.Local).AddTicks(2240));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 18, 21, 718, DateTimeKind.Local).AddTicks(2244));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 18, 21, 718, DateTimeKind.Local).AddTicks(2246));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 18, 21, 718, DateTimeKind.Local).AddTicks(2249));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 18, 21, 718, DateTimeKind.Local).AddTicks(2252));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 18, 21, 718, DateTimeKind.Local).AddTicks(2255));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 18, 21, 718, DateTimeKind.Local).AddTicks(2258));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 18, 21, 718, DateTimeKind.Local).AddTicks(2294));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 18, 21, 718, DateTimeKind.Local).AddTicks(2299));
        }
    }
}
