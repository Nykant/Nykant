using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.Migrations
{
    public partial class heya : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Oil",
                table: "Products",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Tøjstativ");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageSource2", "ItemType", "LastModified", "Name", "Oil", "Title", "TypeOfWood" },
                values: new object[] { "Vores tøjstativ ”Nora” er udviklet i et system hvor det samles uden skruer og lim, men udelukkende med kiler i massiv egetræ. Detaljen i sig selv er både meget nem at samle og skille, men viser måske i endnu højere grad nogle meget smukke og enkle detaljer, Der klæder møblet med en meget høj snedkermæssig niveau.", "../images/Products/NYKANT_boejle_hvidolie_01.png", "Tøjstativ", new DateTime(2021, 10, 15, 12, 41, 7, 963, DateTimeKind.Local).AddTicks(1350), "Nora", "naturligt", null, "Eg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LastModified", "Oil" },
                values: new object[] { new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4810), "farvet-overflade" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "LastModified", "Oil" },
                values: new object[] { new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4903), "naturligt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "LastModified", "Oil" },
                values: new object[] { new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4910), "farvet-overflade" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "LastModified", "Oil" },
                values: new object[] { new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4913), "naturligt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "LastModified", "Oil" },
                values: new object[] { new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4917), "farvet-overflade" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "LastModified", "Oil" },
                values: new object[] { new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4920), "naturligt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "LastModified", "Oil" },
                values: new object[] { new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4923), "farvet-overflade" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "LastModified", "Oil" },
                values: new object[] { new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4927), "naturligt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "LastModified", "Oil" },
                values: new object[] { new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4931), "farvet-overflade" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "LastModified", "Oil" },
                values: new object[] { new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4934), "naturligt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "LastModified", "Oil" },
                values: new object[] { new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4938), "farvet-overflade" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "LastModified", "Oil" },
                values: new object[] { new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4941), "naturligt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "LastModified", "Oil" },
                values: new object[] { new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4944), "farvet-overflade" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "LastModified", "Oil" },
                values: new object[] { new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4948), "naturligt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "LastModified", "Oil" },
                values: new object[] { new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4951), "farvet-overflade" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "LastModified", "Oil" },
                values: new object[] { new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4954), "naturligt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "LastModified", "Oil" },
                values: new object[] { new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4957), "farvet-overflade" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "LastModified", "Oil" },
                values: new object[] { new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4960), "naturligt" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Oil",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Stole");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Color", "Description", "ImageSource2", "ItemType", "LastModified", "Name", "Title", "TypeOfWood" },
                values: new object[] { "naturligt", "a test object", "../images/gyngestol.jpg", "stol", new DateTime(2021, 10, 13, 14, 57, 18, 869, DateTimeKind.Local).AddTicks(1384), "Grøntsags Skærebræt", "Grøntsags Skærebræt", "valnød" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Color", "LastModified" },
                values: new object[] { "farvet-overflade", new DateTime(2021, 10, 13, 14, 57, 18, 871, DateTimeKind.Local).AddTicks(4727) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Color", "LastModified" },
                values: new object[] { "naturligt", new DateTime(2021, 10, 13, 14, 57, 18, 871, DateTimeKind.Local).AddTicks(4813) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Color", "LastModified" },
                values: new object[] { "farvet-overflade", new DateTime(2021, 10, 13, 14, 57, 18, 871, DateTimeKind.Local).AddTicks(4819) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Color", "LastModified" },
                values: new object[] { "naturligt", new DateTime(2021, 10, 13, 14, 57, 18, 871, DateTimeKind.Local).AddTicks(4823) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Color", "LastModified" },
                values: new object[] { "farvet-overflade", new DateTime(2021, 10, 13, 14, 57, 18, 871, DateTimeKind.Local).AddTicks(4826) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Color", "LastModified" },
                values: new object[] { "naturligt", new DateTime(2021, 10, 13, 14, 57, 18, 871, DateTimeKind.Local).AddTicks(4829) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Color", "LastModified" },
                values: new object[] { "farvet-overflade", new DateTime(2021, 10, 13, 14, 57, 18, 871, DateTimeKind.Local).AddTicks(4833) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Color", "LastModified" },
                values: new object[] { "naturligt", new DateTime(2021, 10, 13, 14, 57, 18, 871, DateTimeKind.Local).AddTicks(4836) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Color", "LastModified" },
                values: new object[] { "farvet-overflade", new DateTime(2021, 10, 13, 14, 57, 18, 871, DateTimeKind.Local).AddTicks(4839) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Color", "LastModified" },
                values: new object[] { "naturligt", new DateTime(2021, 10, 13, 14, 57, 18, 871, DateTimeKind.Local).AddTicks(4842) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Color", "LastModified" },
                values: new object[] { "farvet-overflade", new DateTime(2021, 10, 13, 14, 57, 18, 871, DateTimeKind.Local).AddTicks(4845) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Color", "LastModified" },
                values: new object[] { "naturligt", new DateTime(2021, 10, 13, 14, 57, 18, 871, DateTimeKind.Local).AddTicks(4848) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Color", "LastModified" },
                values: new object[] { "farvet-overflade", new DateTime(2021, 10, 13, 14, 57, 18, 871, DateTimeKind.Local).AddTicks(4851) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Color", "LastModified" },
                values: new object[] { "naturligt", new DateTime(2021, 10, 13, 14, 57, 18, 871, DateTimeKind.Local).AddTicks(4854) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Color", "LastModified" },
                values: new object[] { "farvet-overflade", new DateTime(2021, 10, 13, 14, 57, 18, 871, DateTimeKind.Local).AddTicks(4857) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Color", "LastModified" },
                values: new object[] { "naturligt", new DateTime(2021, 10, 13, 14, 57, 18, 871, DateTimeKind.Local).AddTicks(4861) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Color", "LastModified" },
                values: new object[] { "farvet-overflade", new DateTime(2021, 10, 13, 14, 57, 18, 871, DateTimeKind.Local).AddTicks(4865) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Color", "LastModified" },
                values: new object[] { "naturligt", new DateTime(2021, 10, 13, 14, 57, 18, 871, DateTimeKind.Local).AddTicks(4868) });
        }
    }
}
