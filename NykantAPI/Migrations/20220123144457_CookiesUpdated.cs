using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.Migrations
{
    public partial class CookiesUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: ".AspNetCore.Culture");

            migrationBuilder.InsertData(
                table: "Cookies",
                columns: new[] { "Name", "Category", "Description", "Type1", "Type2" },
                values: new object[] { "Culture", 1, "Denne cookie gemmer din præference for sprog.", 1, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "Culture");

            migrationBuilder.InsertData(
                table: "Cookies",
                columns: new[] { "Name", "Category", "Description", "Type1", "Type2" },
                values: new object[] { ".AspNetCore.Culture", 1, "Denne cookie gemmer din præference for sprog.", 1, 0 });
        }
    }
}
