using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.Migrations
{
    public partial class thenew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "ShippingAddress",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "BillingAddress",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 7, 6, 640, DateTimeKind.Local).AddTicks(2870));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 7, 6, 642, DateTimeKind.Local).AddTicks(4196));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 7, 6, 642, DateTimeKind.Local).AddTicks(4279));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 7, 6, 642, DateTimeKind.Local).AddTicks(4286));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 7, 6, 642, DateTimeKind.Local).AddTicks(4291));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 7, 6, 642, DateTimeKind.Local).AddTicks(4297));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 7, 6, 642, DateTimeKind.Local).AddTicks(4302));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 7, 6, 642, DateTimeKind.Local).AddTicks(4306));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 7, 6, 642, DateTimeKind.Local).AddTicks(4312));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 7, 6, 642, DateTimeKind.Local).AddTicks(4316));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 7, 6, 642, DateTimeKind.Local).AddTicks(4319));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 7, 6, 642, DateTimeKind.Local).AddTicks(4328));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 7, 6, 642, DateTimeKind.Local).AddTicks(4333));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 7, 6, 642, DateTimeKind.Local).AddTicks(4337));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 7, 6, 642, DateTimeKind.Local).AddTicks(4340));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 7, 6, 642, DateTimeKind.Local).AddTicks(4345));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 7, 6, 642, DateTimeKind.Local).AddTicks(4348));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 7, 6, 642, DateTimeKind.Local).AddTicks(4352));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "LastModified",
                value: new DateTime(2021, 9, 30, 12, 7, 6, 642, DateTimeKind.Local).AddTicks(4355));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: new DateTime(2021, 9, 29, 14, 43, 52, 400, DateTimeKind.Local).AddTicks(8446));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2021, 9, 29, 14, 43, 52, 403, DateTimeKind.Local).AddTicks(5183));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2021, 9, 29, 14, 43, 52, 403, DateTimeKind.Local).AddTicks(5282));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastModified",
                value: new DateTime(2021, 9, 29, 14, 43, 52, 403, DateTimeKind.Local).AddTicks(5289));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastModified",
                value: new DateTime(2021, 9, 29, 14, 43, 52, 403, DateTimeKind.Local).AddTicks(5292));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastModified",
                value: new DateTime(2021, 9, 29, 14, 43, 52, 403, DateTimeKind.Local).AddTicks(5295));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastModified",
                value: new DateTime(2021, 9, 29, 14, 43, 52, 403, DateTimeKind.Local).AddTicks(5298));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastModified",
                value: new DateTime(2021, 9, 29, 14, 43, 52, 403, DateTimeKind.Local).AddTicks(5302));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastModified",
                value: new DateTime(2021, 9, 29, 14, 43, 52, 403, DateTimeKind.Local).AddTicks(5305));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastModified",
                value: new DateTime(2021, 9, 29, 14, 43, 52, 403, DateTimeKind.Local).AddTicks(5309));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastModified",
                value: new DateTime(2021, 9, 29, 14, 43, 52, 403, DateTimeKind.Local).AddTicks(5312));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastModified",
                value: new DateTime(2021, 9, 29, 14, 43, 52, 403, DateTimeKind.Local).AddTicks(5315));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "LastModified",
                value: new DateTime(2021, 9, 29, 14, 43, 52, 403, DateTimeKind.Local).AddTicks(5318));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "LastModified",
                value: new DateTime(2021, 9, 29, 14, 43, 52, 403, DateTimeKind.Local).AddTicks(5320));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "LastModified",
                value: new DateTime(2021, 9, 29, 14, 43, 52, 403, DateTimeKind.Local).AddTicks(5323));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastModified",
                value: new DateTime(2021, 9, 29, 14, 43, 52, 403, DateTimeKind.Local).AddTicks(5326));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "LastModified",
                value: new DateTime(2021, 9, 29, 14, 43, 52, 403, DateTimeKind.Local).AddTicks(5329));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "LastModified",
                value: new DateTime(2021, 9, 29, 14, 43, 52, 403, DateTimeKind.Local).AddTicks(5332));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "LastModified",
                value: new DateTime(2021, 9, 29, 14, 43, 52, 403, DateTimeKind.Local).AddTicks(5335));
        }
    }
}
