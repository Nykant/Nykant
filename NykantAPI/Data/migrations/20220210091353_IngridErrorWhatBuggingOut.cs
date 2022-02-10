using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.data.migrations
{
    public partial class IngridErrorWhatBuggingOut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImgSource", "Name" },
                values: new object[] { "../images/Products/Category/Desktop/bord_natur_2.png", "Borde" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImgSource", "Name" },
                values: new object[] { "../images/Products/Category/Desktop/test_ingrid_natur_2.png", "Tøjstativer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImgSource", "Name" },
                values: new object[] { "../images/Products/Category/Desktop/test_ingrid_natur_2.png", "Tøjstativer" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImgSource", "Name" },
                values: new object[] { "../images/Products/Category/Desktop/bord_natur_2.png", "Borde" });
        }
    }
}
