using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.Migrations
{
    public partial class secondo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address2",
                table: "CustomerInfs",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModified",
                value: new DateTime(2021, 9, 23, 10, 58, 34, 961, DateTimeKind.Local).AddTicks(7688));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2021, 9, 23, 10, 58, 34, 963, DateTimeKind.Local).AddTicks(8644));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2021, 9, 23, 10, 58, 34, 963, DateTimeKind.Local).AddTicks(8760));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastModified",
                value: new DateTime(2021, 9, 23, 10, 58, 34, 963, DateTimeKind.Local).AddTicks(8766));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastModified",
                value: new DateTime(2021, 9, 23, 10, 58, 34, 963, DateTimeKind.Local).AddTicks(8769));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastModified",
                value: new DateTime(2021, 9, 23, 10, 58, 34, 963, DateTimeKind.Local).AddTicks(8772));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastModified",
                value: new DateTime(2021, 9, 23, 10, 58, 34, 963, DateTimeKind.Local).AddTicks(8775));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastModified",
                value: new DateTime(2021, 9, 23, 10, 58, 34, 963, DateTimeKind.Local).AddTicks(8777));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastModified",
                value: new DateTime(2021, 9, 23, 10, 58, 34, 963, DateTimeKind.Local).AddTicks(8781));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastModified",
                value: new DateTime(2021, 9, 23, 10, 58, 34, 963, DateTimeKind.Local).AddTicks(8784));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastModified",
                value: new DateTime(2021, 9, 23, 10, 58, 34, 963, DateTimeKind.Local).AddTicks(8787));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastModified",
                value: new DateTime(2021, 9, 23, 10, 58, 34, 963, DateTimeKind.Local).AddTicks(8790));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "LastModified",
                value: new DateTime(2021, 9, 23, 10, 58, 34, 963, DateTimeKind.Local).AddTicks(8795));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "LastModified",
                value: new DateTime(2021, 9, 23, 10, 58, 34, 963, DateTimeKind.Local).AddTicks(8798));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "LastModified",
                value: new DateTime(2021, 9, 23, 10, 58, 34, 963, DateTimeKind.Local).AddTicks(8801));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastModified",
                value: new DateTime(2021, 9, 23, 10, 58, 34, 963, DateTimeKind.Local).AddTicks(8804));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "LastModified",
                value: new DateTime(2021, 9, 23, 10, 58, 34, 963, DateTimeKind.Local).AddTicks(8807));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "LastModified",
                value: new DateTime(2021, 9, 23, 10, 58, 34, 963, DateTimeKind.Local).AddTicks(8810));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "LastModified",
                value: new DateTime(2021, 9, 23, 10, 58, 34, 963, DateTimeKind.Local).AddTicks(8813));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address2",
                table: "CustomerInfs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModified",
                value: new DateTime(2021, 9, 22, 13, 15, 12, 720, DateTimeKind.Local).AddTicks(4520));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4341));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4419));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastModified",
                value: new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4425));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastModified",
                value: new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4428));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastModified",
                value: new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4431));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastModified",
                value: new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4434));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastModified",
                value: new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4437));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastModified",
                value: new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4440));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastModified",
                value: new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4442));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastModified",
                value: new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4446));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastModified",
                value: new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4449));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "LastModified",
                value: new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4453));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "LastModified",
                value: new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4456));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "LastModified",
                value: new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4459));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastModified",
                value: new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4462));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "LastModified",
                value: new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4465));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "LastModified",
                value: new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4468));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "LastModified",
                value: new DateTime(2021, 9, 22, 13, 15, 12, 722, DateTimeKind.Local).AddTicks(4471));
        }
    }
}
