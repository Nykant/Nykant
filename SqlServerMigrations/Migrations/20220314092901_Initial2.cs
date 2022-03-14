using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.data.migrations.local
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "_ga",
                column: "Description",
                value: "Indsamler anonyme data om hvad du foretager dig på hjemmesiden, og sender det til google analytics, så vi kan bruge det til at forbedre hjemmesiden.");

            migrationBuilder.UpdateData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "_ga_*",
                column: "Description",
                value: "Indsamler anonyme data om hvad du foretager dig på hjemmesiden, og sender det til google analytics, så vi kan bruge det til at forbedre hjemmesiden.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
