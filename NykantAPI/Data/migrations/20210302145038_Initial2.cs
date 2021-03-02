using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.data.migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "CustomerInfs");

            migrationBuilder.AlterColumn<string>(
                name: "Postal",
                table: "CustomerInfs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "CustomerInfs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "CustomerInfs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "CustomerInfs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "CustomerInfs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "Address1",
                table: "CustomerInfs",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "CustomerInfs",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 15, 50, 37, 980, DateTimeKind.Local).AddTicks(3887));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 15, 50, 37, 982, DateTimeKind.Local).AddTicks(5674));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 15, 50, 37, 982, DateTimeKind.Local).AddTicks(5767));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 15, 50, 37, 982, DateTimeKind.Local).AddTicks(5773));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 15, 50, 37, 982, DateTimeKind.Local).AddTicks(5776));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 15, 50, 37, 982, DateTimeKind.Local).AddTicks(5779));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 15, 50, 37, 982, DateTimeKind.Local).AddTicks(5782));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 15, 50, 37, 982, DateTimeKind.Local).AddTicks(5784));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 15, 50, 37, 982, DateTimeKind.Local).AddTicks(5788));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 15, 50, 37, 982, DateTimeKind.Local).AddTicks(5790));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 15, 50, 37, 982, DateTimeKind.Local).AddTicks(5793));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 15, 50, 37, 982, DateTimeKind.Local).AddTicks(5796));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 15, 50, 37, 982, DateTimeKind.Local).AddTicks(5800));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 15, 50, 37, 982, DateTimeKind.Local).AddTicks(5859));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 15, 50, 37, 982, DateTimeKind.Local).AddTicks(5863));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 15, 50, 37, 982, DateTimeKind.Local).AddTicks(5866));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 15, 50, 37, 982, DateTimeKind.Local).AddTicks(5869));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 15, 50, 37, 982, DateTimeKind.Local).AddTicks(5871));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 15, 50, 37, 982, DateTimeKind.Local).AddTicks(5874));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address1",
                table: "CustomerInfs");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "CustomerInfs");

            migrationBuilder.AlterColumn<string>(
                name: "Postal",
                table: "CustomerInfs",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "CustomerInfs",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "CustomerInfs",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "CustomerInfs",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "CustomerInfs",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "CustomerInfs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 11, 5, 31, 462, DateTimeKind.Local).AddTicks(5264));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 11, 5, 31, 464, DateTimeKind.Local).AddTicks(7217));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 11, 5, 31, 464, DateTimeKind.Local).AddTicks(7334));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 11, 5, 31, 464, DateTimeKind.Local).AddTicks(7340));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 11, 5, 31, 464, DateTimeKind.Local).AddTicks(7343));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 11, 5, 31, 464, DateTimeKind.Local).AddTicks(7346));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 11, 5, 31, 464, DateTimeKind.Local).AddTicks(7349));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 11, 5, 31, 464, DateTimeKind.Local).AddTicks(7352));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 11, 5, 31, 464, DateTimeKind.Local).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 11, 5, 31, 464, DateTimeKind.Local).AddTicks(7357));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 11, 5, 31, 464, DateTimeKind.Local).AddTicks(7361));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 11, 5, 31, 464, DateTimeKind.Local).AddTicks(7364));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 11, 5, 31, 464, DateTimeKind.Local).AddTicks(7367));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 11, 5, 31, 464, DateTimeKind.Local).AddTicks(7369));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 11, 5, 31, 464, DateTimeKind.Local).AddTicks(7372));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 11, 5, 31, 464, DateTimeKind.Local).AddTicks(7375));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 11, 5, 31, 464, DateTimeKind.Local).AddTicks(7378));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 11, 5, 31, 464, DateTimeKind.Local).AddTicks(7381));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "LastModified",
                value: new DateTime(2021, 3, 2, 11, 5, 31, 464, DateTimeKind.Local).AddTicks(7384));
        }
    }
}
