using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.data.migrations
{
    public partial class StripeCookiesFirstparty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "__stripe_mid",
                column: "Type2",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "__stripe_sid",
                column: "Type2",
                value: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "__stripe_mid",
                column: "Type2",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "__stripe_sid",
                column: "Type2",
                value: 1);
        }
    }
}
