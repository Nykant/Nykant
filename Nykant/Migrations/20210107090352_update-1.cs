using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nykant.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Alt",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Products",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LastModified", "Price", "Title" },
                values: new object[] { new DateTime(2021, 1, 7, 10, 3, 52, 139, DateTimeKind.Local).AddTicks(7627), 1000, "Grøntsags Skærebræt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LastModified", "Price", "Title" },
                values: new object[] { new DateTime(2021, 1, 7, 10, 3, 52, 142, DateTimeKind.Local).AddTicks(1091), 1000, "Grøntsags Skærebræt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "LastModified", "Price", "Title" },
                values: new object[] { new DateTime(2021, 1, 7, 10, 3, 52, 142, DateTimeKind.Local).AddTicks(1154), 1000, "Grøntsags Skærebræt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "LastModified", "Price", "Title" },
                values: new object[] { new DateTime(2021, 1, 7, 10, 3, 52, 142, DateTimeKind.Local).AddTicks(1160), 1000, "Grøntsags Skærebræt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "LastModified", "Price", "Title" },
                values: new object[] { new DateTime(2021, 1, 7, 10, 3, 52, 142, DateTimeKind.Local).AddTicks(1164), 1000, "Grøntsags Skærebræt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "LastModified", "Price", "Title" },
                values: new object[] { new DateTime(2021, 1, 7, 10, 3, 52, 142, DateTimeKind.Local).AddTicks(1166), 1000, "Grøntsags Skærebræt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ItemType", "LastModified", "Price", "Title" },
                values: new object[] { "stol", new DateTime(2021, 1, 7, 10, 3, 52, 142, DateTimeKind.Local).AddTicks(1169), 1000, "Grøntsags Skærebræt" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Alt", "Color", "Description", "ImageSource", "ItemType", "LastModified", "Name", "Price", "Size", "Title", "TypeOfWood" },
                values: new object[,]
                {
                    { 19, null, "naturligt", "a test object", "~/wwwroot/images/Finback-Chairs1-1280x853-c-default.jpg", "bænk", new DateTime(2021, 1, 7, 10, 3, 52, 142, DateTimeKind.Local).AddTicks(1201), null, 1000, "5mm", "Grøntsags Skærebræt", "valnød" },
                    { 18, null, "farvet-overflade", "a test object", "~/wwwroot/images/Finback-Chairs1-1280x853-c-default.jpg", "skærebræt", new DateTime(2021, 1, 7, 10, 3, 52, 142, DateTimeKind.Local).AddTicks(1199), null, 1000, "20mm", "Grøntsags Skærebræt", "fyr" },
                    { 17, null, "naturligt", "a test object", "~/wwwroot/images/Finback-Chairs1-1280x853-c-default.jpg", "bænk", new DateTime(2021, 1, 7, 10, 3, 52, 142, DateTimeKind.Local).AddTicks(1196), null, 1000, "10mm", "Grøntsags Skærebræt", "valnød" },
                    { 15, null, "naturligt", "a test object", "~/wwwroot/images/Finback-Chairs1-1280x853-c-default.jpg", "bænk", new DateTime(2021, 1, 7, 10, 3, 52, 142, DateTimeKind.Local).AddTicks(1191), null, 1000, "20mm", "Grøntsags Skærebræt", "fyr" },
                    { 14, null, "farvet-overflade", "a test object", "~/wwwroot/images/Finback-Chairs1-1280x853-c-default.jpg", "stol", new DateTime(2021, 1, 7, 10, 3, 52, 142, DateTimeKind.Local).AddTicks(1188), null, 1000, "10mm", "Grøntsags Skærebræt", "eg" },
                    { 13, null, "naturligt", "a test object", "~/wwwroot/images/Finback-Chairs1-1280x853-c-default.jpg", "stol", new DateTime(2021, 1, 7, 10, 3, 52, 142, DateTimeKind.Local).AddTicks(1185), null, 1000, "5mm", "Grøntsags Skærebræt", "valnød" },
                    { 12, null, "farvet-overflade", "a test object", "~/wwwroot/images/Finback-Chairs1-1280x853-c-default.jpg", "skærebræt", new DateTime(2021, 1, 7, 10, 3, 52, 142, DateTimeKind.Local).AddTicks(1183), null, 1000, "20mm", "Grøntsags Skærebræt", "fyr" },
                    { 11, null, "naturligt", "a test object", "~/wwwroot/images/Finback-Chairs1-1280x853-c-default.jpg", "bænk", new DateTime(2021, 1, 7, 10, 3, 52, 142, DateTimeKind.Local).AddTicks(1180), null, 1000, "10mm", "Grøntsags Skærebræt", "valnød" },
                    { 10, null, "farvet-overflade", "a test object", "~/wwwroot/images/Finback-Chairs1-1280x853-c-default.jpg", "skærebræt", new DateTime(2021, 1, 7, 10, 3, 52, 142, DateTimeKind.Local).AddTicks(1177), null, 1000, "5mm", "Grøntsags Skærebræt", "eg" },
                    { 9, null, "naturligt", "a test object", "~/wwwroot/images/Finback-Chairs1-1280x853-c-default.jpg", "bænk", new DateTime(2021, 1, 7, 10, 3, 52, 142, DateTimeKind.Local).AddTicks(1174), null, 1000, "20mm", "Grøntsags Skærebræt", "fyr" },
                    { 16, null, "farvet-overflade", "a test object", "~/wwwroot/images/Finback-Chairs1-1280x853-c-default.jpg", "skærebræt", new DateTime(2021, 1, 7, 10, 3, 52, 142, DateTimeKind.Local).AddTicks(1193), null, 1000, "5mm", "Grøntsags Skærebræt", "eg" },
                    { 8, null, "farvet-overflade", "a test object", "~/wwwroot/images/Finback-Chairs1-1280x853-c-default.jpg", "stol", new DateTime(2021, 1, 7, 10, 3, 52, 142, DateTimeKind.Local).AddTicks(1172), null, 1000, "10mm", "Grøntsags Skærebræt", "eg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DropColumn(
                name: "Alt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModified",
                value: new DateTime(2020, 12, 28, 17, 29, 51, 473, DateTimeKind.Local).AddTicks(5872));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2020, 12, 28, 17, 29, 51, 475, DateTimeKind.Local).AddTicks(5623));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2020, 12, 28, 17, 29, 51, 475, DateTimeKind.Local).AddTicks(5686));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastModified",
                value: new DateTime(2020, 12, 28, 17, 29, 51, 475, DateTimeKind.Local).AddTicks(5691));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastModified",
                value: new DateTime(2020, 12, 28, 17, 29, 51, 475, DateTimeKind.Local).AddTicks(5694));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastModified",
                value: new DateTime(2020, 12, 28, 17, 29, 51, 475, DateTimeKind.Local).AddTicks(5697));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ItemType", "LastModified" },
                values: new object[] { "bænk", new DateTime(2020, 12, 28, 17, 29, 51, 475, DateTimeKind.Local).AddTicks(5699) });
        }
    }
}
