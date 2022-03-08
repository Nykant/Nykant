using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.data.migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "Culture");

            migrationBuilder.UpdateData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "_ga",
                column: "Description",
                value: "Indsamler anonyme data om hvad du foretager dig på hjemmesiden, og sender det til google analytics, så vi kan se og bruge det til at forbedre hjemmesiden.");

            migrationBuilder.UpdateData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "_ga_*",
                column: "Description",
                value: "Indsamler anonyme data om hvad du foretager dig på hjemmesiden, og sender det til google analytics, så vi kan se og bruge det til at forbedre hjemmesiden.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "_ga",
                column: "Description",
                value: "Indsamler anonymiseret data om hvad du foretager dig på hjemmesiden, og sender det til google analytics, så vi kan se og bruge det til at forbedre hjemmesiden.");

            migrationBuilder.UpdateData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "_ga_*",
                column: "Description",
                value: "Indsamler anonymiseret data om hvad du foretager dig på hjemmesiden, og sender det til google analytics, så vi kan se og bruge det til at forbedre hjemmesiden.");

            migrationBuilder.InsertData(
                table: "Cookies",
                columns: new[] { "Name", "Category", "Description", "Domain", "Type1", "Type2" },
                values: new object[] { "Culture", 1, "Denne cookie gemmer din præference for sprog.", ".nykant.dk", 1, 0 });
        }
    }
}
