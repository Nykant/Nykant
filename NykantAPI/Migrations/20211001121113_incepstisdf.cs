using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.Migrations
{
    public partial class incepstisdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShippingDeliveries",
                keyColumn: "Id",
                keyValue: 3);

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
                columns: new[] { "Name", "Price" },
                values: new object[] { "Til pakkeshop", 0 });

            migrationBuilder.UpdateData(
                table: "ShippingDeliveries",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Til leveringsaddressen", 65 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "ShippingDeliveries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Price" },
                values: new object[] { "GLS", 35 });

            migrationBuilder.UpdateData(
                table: "ShippingDeliveries",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Price" },
                values: new object[] { "PostNord", 50 });

            migrationBuilder.InsertData(
                table: "ShippingDeliveries",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 3, "GLS Privat", 65 });
        }
    }
}
