using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.Migrations
{
    public partial class ThyraShort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Materials", "Note", "Package", "Size" },
                values: new object[] { "Thyra Short Description", "Thyra Short Materials", "Thyra Short Note", "Thyra Short Package", "Thyra Short Size" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Materials", "Note", "Package", "Size" },
                values: new object[] { "Thyra Description", "Thyra Materials", "Thyra Note", "Thyra Package", "Thyra Size" });
        }
    }
}
