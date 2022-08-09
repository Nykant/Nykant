using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.data.migrations.local
{
    public partial class upodateada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Tøjstativer Træ | Elegante tøjstativer i massivt egetræ | Køb online");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Egetræsborde | Køb massivt egetræsbord her | Bæredygtigt valg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Title",
                value: "Træbænke | Stilrene egetræsbænke i dansk design | Køb online");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Title",
                value: "Tøjbøjler Træ | Køb massive egetræsbøjler i elegant dansk design");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Tøjstativ træ | Elegante tøjstativer i massivt egetræ | Køb online");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Egetræsbord | Køb massivt egetræsbord her | Bæredygtigt valg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Title",
                value: "Træbænk | Stilrene egetræsbænke i dansk design | Køb online");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Title",
                value: "Træbøjler | Køb massive egetræsbøjler i elegant dansk design");
        }
    }
}
