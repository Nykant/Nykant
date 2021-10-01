using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.Migrations
{
    public partial class incepstisdfa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 656, DateTimeKind.Local).AddTicks(6154));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9728));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9805));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9811));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9814));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9817));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9820));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9823));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9826));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9829));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9832));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9835));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9838));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9841));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9844));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9847));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9850));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9852));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9855));

            migrationBuilder.UpdateData(
                table: "ShippingDeliveries",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Shop");

            migrationBuilder.UpdateData(
                table: "ShippingDeliveries",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Home");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 11, 11, 685, DateTimeKind.Local).AddTicks(255));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 11, 11, 687, DateTimeKind.Local).AddTicks(2137));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 11, 11, 687, DateTimeKind.Local).AddTicks(2217));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 11, 11, 687, DateTimeKind.Local).AddTicks(2237));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 11, 11, 687, DateTimeKind.Local).AddTicks(2240));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 11, 11, 687, DateTimeKind.Local).AddTicks(2243));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 11, 11, 687, DateTimeKind.Local).AddTicks(2247));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 11, 11, 687, DateTimeKind.Local).AddTicks(2250));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 11, 11, 687, DateTimeKind.Local).AddTicks(2253));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 11, 11, 687, DateTimeKind.Local).AddTicks(2256));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 11, 11, 687, DateTimeKind.Local).AddTicks(2259));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 11, 11, 687, DateTimeKind.Local).AddTicks(2262));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 11, 11, 687, DateTimeKind.Local).AddTicks(2265));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 11, 11, 687, DateTimeKind.Local).AddTicks(2268));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 11, 11, 687, DateTimeKind.Local).AddTicks(2271));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 11, 11, 687, DateTimeKind.Local).AddTicks(2274));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 11, 11, 687, DateTimeKind.Local).AddTicks(2278));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 11, 11, 687, DateTimeKind.Local).AddTicks(2281));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 11, 11, 687, DateTimeKind.Local).AddTicks(2284));

            migrationBuilder.UpdateData(
                table: "ShippingDeliveries",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Til pakkeshop");

            migrationBuilder.UpdateData(
                table: "ShippingDeliveries",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Til leveringsaddressen");
        }
    }
}
