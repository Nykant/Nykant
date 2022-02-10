using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.data.migrations
{
    public partial class IngridErrorWhat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgSource",
                value: "../images/Products/Category/Desktop/ingrid_natur_2.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImgSource",
                value: "../images/Products/Category/Desktop/bord_natur_2.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImgSource",
                value: "../images/Products/Category/Desktop/hylde_natur_1.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImgSource",
                value: "../images/Products/Category/Desktop/opbevaringsbaenk_natur_3.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImgSource",
                value: "../images/Products/Category/Desktop/boejle_natur_1.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgSource",
                value: "../Images/Products/Category/Desktop/test_ingrid_natur_2.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImgSource",
                value: "../Images/Products/Category/Desktop/bord_natur_2.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImgSource",
                value: "../Images/Products/Category/Desktop/hylde_natur_1.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImgSource",
                value: "../Images/Products/Category/Desktop/opbevaringsbaenk_natur_3.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImgSource",
                value: "../Images/Products/Category/Desktop/boejle_natur_1.png");
        }
    }
}
