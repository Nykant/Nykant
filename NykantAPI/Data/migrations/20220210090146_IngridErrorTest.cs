using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.data.migrations
{
    public partial class IngridErrorTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgSource",
                value: "../Images/Products/Category/Desktop/test_ingrid_natur_2.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgSource",
                value: "../Images/Products/Category/Desktop/ingrid_natur_2.png");
        }
    }
}
