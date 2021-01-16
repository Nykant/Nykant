using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nykant.Migrations
{
    public partial class BagItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BagItems",
                columns: table => new
                {
                    BagId = table.Column<string>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BagItems", x => new { x.BagId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_BagItems_Bags_BagId",
                        column: x => x.BagId,
                        principalTable: "Bags",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BagItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 580, DateTimeKind.Local).AddTicks(6873));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(1891));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(1956));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(1961));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(1964));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(1967));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(1971));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(1977));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(1979));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(1983));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(1987));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(1991));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(1994));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(1998));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(2001));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(2004));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(2008));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(2011));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "LastModified",
                value: new DateTime(2021, 1, 14, 14, 33, 52, 583, DateTimeKind.Local).AddTicks(2014));

            migrationBuilder.CreateIndex(
                name: "IX_BagItems_ProductId",
                table: "BagItems",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BagItems");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModified",
                value: new DateTime(2021, 1, 13, 14, 5, 1, 973, DateTimeKind.Local).AddTicks(6626));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2021, 1, 13, 14, 5, 1, 975, DateTimeKind.Local).AddTicks(8619));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2021, 1, 13, 14, 5, 1, 975, DateTimeKind.Local).AddTicks(8681));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastModified",
                value: new DateTime(2021, 1, 13, 14, 5, 1, 975, DateTimeKind.Local).AddTicks(8687));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastModified",
                value: new DateTime(2021, 1, 13, 14, 5, 1, 975, DateTimeKind.Local).AddTicks(8690));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastModified",
                value: new DateTime(2021, 1, 13, 14, 5, 1, 975, DateTimeKind.Local).AddTicks(8692));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastModified",
                value: new DateTime(2021, 1, 13, 14, 5, 1, 975, DateTimeKind.Local).AddTicks(8695));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastModified",
                value: new DateTime(2021, 1, 13, 14, 5, 1, 975, DateTimeKind.Local).AddTicks(8698));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastModified",
                value: new DateTime(2021, 1, 13, 14, 5, 1, 975, DateTimeKind.Local).AddTicks(8701));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastModified",
                value: new DateTime(2021, 1, 13, 14, 5, 1, 975, DateTimeKind.Local).AddTicks(8704));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastModified",
                value: new DateTime(2021, 1, 13, 14, 5, 1, 975, DateTimeKind.Local).AddTicks(8707));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastModified",
                value: new DateTime(2021, 1, 13, 14, 5, 1, 975, DateTimeKind.Local).AddTicks(8710));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "LastModified",
                value: new DateTime(2021, 1, 13, 14, 5, 1, 975, DateTimeKind.Local).AddTicks(8713));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "LastModified",
                value: new DateTime(2021, 1, 13, 14, 5, 1, 975, DateTimeKind.Local).AddTicks(8715));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "LastModified",
                value: new DateTime(2021, 1, 13, 14, 5, 1, 975, DateTimeKind.Local).AddTicks(8718));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastModified",
                value: new DateTime(2021, 1, 13, 14, 5, 1, 975, DateTimeKind.Local).AddTicks(8761));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "LastModified",
                value: new DateTime(2021, 1, 13, 14, 5, 1, 975, DateTimeKind.Local).AddTicks(8766));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "LastModified",
                value: new DateTime(2021, 1, 13, 14, 5, 1, 975, DateTimeKind.Local).AddTicks(8768));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "LastModified",
                value: new DateTime(2021, 1, 13, 14, 5, 1, 975, DateTimeKind.Local).AddTicks(8771));
        }
    }
}
