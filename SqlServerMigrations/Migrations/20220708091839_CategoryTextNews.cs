using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.data.migrations.local
{
    public partial class CategoryTextNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Text2",
                value: "Vores borde kan nemt danne rammerne for en hyggelig krog eller samlingssted for små og store samtaleemner, samt giver det med sit udseende, et minimalistisk look til hjemmet. Match det med en af vores bænke for et fuldendt look eller sammensæt det på din egen måde.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Text2",
                value: "Vores borde nemt danne rammerne for en hyggelig krog eller samlingssted for små og store samtaleemner, samt giver det med sit udseende, et minimalistisk look til hjemmet. Match det med en af vores bænke for et fuldendt look eller sammensæt det på din egen måde.");
        }
    }
}
