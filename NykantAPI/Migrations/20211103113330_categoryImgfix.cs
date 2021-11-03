using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.Migrations
{
    public partial class categoryImgfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgSource",
                value: "../images/Products/NYKANT_rack_naturolie_02.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImgSource",
                value: "../images/Products/NYKANT_bord_naturolie_02.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImgSource",
                value: "../images/Products/NYKANT_hylde_naturolie_01.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImgSource",
                value: "../images/Products/NYKANT_opbevaringsbaenk_naturolie_03.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImgSource",
                value: "../images/Products/NYKANT_boejle_naturolie_01.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgSource",
                value: "../images/Products/NYKANT_rack_naturolie_02");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImgSource",
                value: "../images/Products/NYKANT_bord_naturolie_02");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImgSource",
                value: "../images/Products/NYKANT_hylde_naturolie_01");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImgSource",
                value: "../images/Products/NYKANT_opbevaringsbaenk_naturolie_03");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImgSource",
                value: "../images/Products/NYKANT_boejle_naturolie_01");
        }
    }
}
