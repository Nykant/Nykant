using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.Migrations
{
    public partial class thenewsetassss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "WeightInKg",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LastModified", "WeightInKg" },
                values: new object[] { new DateTime(2021, 10, 13, 12, 33, 17, 511, DateTimeKind.Local).AddTicks(8216), 11.6 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LastModified", "WeightInKg" },
                values: new object[] { new DateTime(2021, 10, 13, 12, 33, 17, 513, DateTimeKind.Local).AddTicks(9927), 13.4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "LastModified", "WeightInKg" },
                values: new object[] { new DateTime(2021, 10, 13, 12, 33, 17, 514, DateTimeKind.Local).AddTicks(13), 17.399999999999999 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "LastModified", "WeightInKg" },
                values: new object[] { new DateTime(2021, 10, 13, 12, 33, 17, 514, DateTimeKind.Local).AddTicks(19), 7.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "LastModified", "WeightInKg" },
                values: new object[] { new DateTime(2021, 10, 13, 12, 33, 17, 514, DateTimeKind.Local).AddTicks(22), 8.8000000000000007 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "LastModified", "WeightInKg" },
                values: new object[] { new DateTime(2021, 10, 13, 12, 33, 17, 514, DateTimeKind.Local).AddTicks(56), 13.4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "LastModified", "WeightInKg" },
                values: new object[] { new DateTime(2021, 10, 13, 12, 33, 17, 514, DateTimeKind.Local).AddTicks(61), 13.4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "LastModified", "WeightInKg" },
                values: new object[] { new DateTime(2021, 10, 13, 12, 33, 17, 514, DateTimeKind.Local).AddTicks(65), 13.4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "LastModified", "WeightInKg" },
                values: new object[] { new DateTime(2021, 10, 13, 12, 33, 17, 514, DateTimeKind.Local).AddTicks(68), 13.4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "LastModified", "WeightInKg" },
                values: new object[] { new DateTime(2021, 10, 13, 12, 33, 17, 514, DateTimeKind.Local).AddTicks(71), 13.4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "LastModified", "WeightInKg" },
                values: new object[] { new DateTime(2021, 10, 13, 12, 33, 17, 514, DateTimeKind.Local).AddTicks(75), 13.4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "LastModified", "WeightInKg" },
                values: new object[] { new DateTime(2021, 10, 13, 12, 33, 17, 514, DateTimeKind.Local).AddTicks(78), 13.4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "LastModified", "WeightInKg" },
                values: new object[] { new DateTime(2021, 10, 13, 12, 33, 17, 514, DateTimeKind.Local).AddTicks(81), 13.4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "LastModified", "WeightInKg" },
                values: new object[] { new DateTime(2021, 10, 13, 12, 33, 17, 514, DateTimeKind.Local).AddTicks(86), 13.4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "LastModified", "WeightInKg" },
                values: new object[] { new DateTime(2021, 10, 13, 12, 33, 17, 514, DateTimeKind.Local).AddTicks(89), 13.4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "LastModified", "WeightInKg" },
                values: new object[] { new DateTime(2021, 10, 13, 12, 33, 17, 514, DateTimeKind.Local).AddTicks(92), 13.4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "LastModified", "WeightInKg" },
                values: new object[] { new DateTime(2021, 10, 13, 12, 33, 17, 514, DateTimeKind.Local).AddTicks(95), 13.4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "LastModified", "WeightInKg" },
                values: new object[] { new DateTime(2021, 10, 13, 12, 33, 17, 514, DateTimeKind.Local).AddTicks(98), 13.4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "LastModified", "WeightInKg" },
                values: new object[] { new DateTime(2021, 10, 13, 12, 33, 17, 514, DateTimeKind.Local).AddTicks(102), 13.4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeightInKg",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModified",
                value: new DateTime(2021, 10, 13, 12, 22, 26, 479, DateTimeKind.Local).AddTicks(4715));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2021, 10, 13, 12, 22, 26, 481, DateTimeKind.Local).AddTicks(6082));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2021, 10, 13, 12, 22, 26, 481, DateTimeKind.Local).AddTicks(6154));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastModified",
                value: new DateTime(2021, 10, 13, 12, 22, 26, 481, DateTimeKind.Local).AddTicks(6160));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastModified",
                value: new DateTime(2021, 10, 13, 12, 22, 26, 481, DateTimeKind.Local).AddTicks(6164));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastModified",
                value: new DateTime(2021, 10, 13, 12, 22, 26, 481, DateTimeKind.Local).AddTicks(6167));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastModified",
                value: new DateTime(2021, 10, 13, 12, 22, 26, 481, DateTimeKind.Local).AddTicks(6170));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastModified",
                value: new DateTime(2021, 10, 13, 12, 22, 26, 481, DateTimeKind.Local).AddTicks(6173));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastModified",
                value: new DateTime(2021, 10, 13, 12, 22, 26, 481, DateTimeKind.Local).AddTicks(6176));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastModified",
                value: new DateTime(2021, 10, 13, 12, 22, 26, 481, DateTimeKind.Local).AddTicks(6180));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastModified",
                value: new DateTime(2021, 10, 13, 12, 22, 26, 481, DateTimeKind.Local).AddTicks(6183));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastModified",
                value: new DateTime(2021, 10, 13, 12, 22, 26, 481, DateTimeKind.Local).AddTicks(6186));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "LastModified",
                value: new DateTime(2021, 10, 13, 12, 22, 26, 481, DateTimeKind.Local).AddTicks(6188));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "LastModified",
                value: new DateTime(2021, 10, 13, 12, 22, 26, 481, DateTimeKind.Local).AddTicks(6191));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "LastModified",
                value: new DateTime(2021, 10, 13, 12, 22, 26, 481, DateTimeKind.Local).AddTicks(6194));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastModified",
                value: new DateTime(2021, 10, 13, 12, 22, 26, 481, DateTimeKind.Local).AddTicks(6197));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "LastModified",
                value: new DateTime(2021, 10, 13, 12, 22, 26, 481, DateTimeKind.Local).AddTicks(6200));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "LastModified",
                value: new DateTime(2021, 10, 13, 12, 22, 26, 481, DateTimeKind.Local).AddTicks(6204));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "LastModified",
                value: new DateTime(2021, 10, 13, 12, 22, 26, 481, DateTimeKind.Local).AddTicks(6207));
        }
    }
}
