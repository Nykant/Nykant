using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.data.migrations
{
    public partial class newrsr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModified",
                value: new DateTime(2021, 3, 18, 22, 45, 58, 325, DateTimeKind.Local).AddTicks(6532));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2021, 3, 18, 22, 45, 58, 327, DateTimeKind.Local).AddTicks(9839));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2021, 3, 18, 22, 45, 58, 327, DateTimeKind.Local).AddTicks(9933));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastModified",
                value: new DateTime(2021, 3, 18, 22, 45, 58, 327, DateTimeKind.Local).AddTicks(9977));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastModified",
                value: new DateTime(2021, 3, 18, 22, 45, 58, 327, DateTimeKind.Local).AddTicks(9981));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastModified",
                value: new DateTime(2021, 3, 18, 22, 45, 58, 327, DateTimeKind.Local).AddTicks(9984));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastModified",
                value: new DateTime(2021, 3, 18, 22, 45, 58, 327, DateTimeKind.Local).AddTicks(9987));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastModified",
                value: new DateTime(2021, 3, 18, 22, 45, 58, 327, DateTimeKind.Local).AddTicks(9990));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastModified",
                value: new DateTime(2021, 3, 18, 22, 45, 58, 327, DateTimeKind.Local).AddTicks(9993));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastModified",
                value: new DateTime(2021, 3, 18, 22, 45, 58, 327, DateTimeKind.Local).AddTicks(9995));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastModified",
                value: new DateTime(2021, 3, 18, 22, 45, 58, 328, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastModified",
                value: new DateTime(2021, 3, 18, 22, 45, 58, 328, DateTimeKind.Local).AddTicks(3));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "LastModified",
                value: new DateTime(2021, 3, 18, 22, 45, 58, 328, DateTimeKind.Local).AddTicks(8));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "LastModified",
                value: new DateTime(2021, 3, 18, 22, 45, 58, 328, DateTimeKind.Local).AddTicks(11));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "LastModified",
                value: new DateTime(2021, 3, 18, 22, 45, 58, 328, DateTimeKind.Local).AddTicks(13));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastModified",
                value: new DateTime(2021, 3, 18, 22, 45, 58, 328, DateTimeKind.Local).AddTicks(16));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "LastModified",
                value: new DateTime(2021, 3, 18, 22, 45, 58, 328, DateTimeKind.Local).AddTicks(19));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "LastModified",
                value: new DateTime(2021, 3, 18, 22, 45, 58, 328, DateTimeKind.Local).AddTicks(22));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "LastModified",
                value: new DateTime(2021, 3, 18, 22, 45, 58, 328, DateTimeKind.Local).AddTicks(24));

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModified",
                value: new DateTime(2021, 3, 11, 22, 42, 17, 890, DateTimeKind.Local).AddTicks(5305));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2021, 3, 11, 22, 42, 17, 892, DateTimeKind.Local).AddTicks(6083));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2021, 3, 11, 22, 42, 17, 892, DateTimeKind.Local).AddTicks(6157));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastModified",
                value: new DateTime(2021, 3, 11, 22, 42, 17, 892, DateTimeKind.Local).AddTicks(6163));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastModified",
                value: new DateTime(2021, 3, 11, 22, 42, 17, 892, DateTimeKind.Local).AddTicks(6166));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastModified",
                value: new DateTime(2021, 3, 11, 22, 42, 17, 892, DateTimeKind.Local).AddTicks(6169));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastModified",
                value: new DateTime(2021, 3, 11, 22, 42, 17, 892, DateTimeKind.Local).AddTicks(6172));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastModified",
                value: new DateTime(2021, 3, 11, 22, 42, 17, 892, DateTimeKind.Local).AddTicks(6175));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastModified",
                value: new DateTime(2021, 3, 11, 22, 42, 17, 892, DateTimeKind.Local).AddTicks(6179));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastModified",
                value: new DateTime(2021, 3, 11, 22, 42, 17, 892, DateTimeKind.Local).AddTicks(6182));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastModified",
                value: new DateTime(2021, 3, 11, 22, 42, 17, 892, DateTimeKind.Local).AddTicks(6184));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastModified",
                value: new DateTime(2021, 3, 11, 22, 42, 17, 892, DateTimeKind.Local).AddTicks(6187));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "LastModified",
                value: new DateTime(2021, 3, 11, 22, 42, 17, 892, DateTimeKind.Local).AddTicks(6190));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "LastModified",
                value: new DateTime(2021, 3, 11, 22, 42, 17, 892, DateTimeKind.Local).AddTicks(6193));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "LastModified",
                value: new DateTime(2021, 3, 11, 22, 42, 17, 892, DateTimeKind.Local).AddTicks(6196));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastModified",
                value: new DateTime(2021, 3, 11, 22, 42, 17, 892, DateTimeKind.Local).AddTicks(6198));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "LastModified",
                value: new DateTime(2021, 3, 11, 22, 42, 17, 892, DateTimeKind.Local).AddTicks(6201));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "LastModified",
                value: new DateTime(2021, 3, 11, 22, 42, 17, 892, DateTimeKind.Local).AddTicks(6204));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "LastModified",
                value: new DateTime(2021, 3, 11, 22, 42, 17, 892, DateTimeKind.Local).AddTicks(6207));
        }
    }
}
