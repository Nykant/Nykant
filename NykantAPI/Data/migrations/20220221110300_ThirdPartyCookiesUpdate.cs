using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.data.migrations
{
    public partial class ThirdPartyCookiesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "_ga_2LWYP6ZC27");

            migrationBuilder.AddColumn<string>(
                name: "Domain",
                table: "Cookies",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "__stripe_mid",
                column: "Domain",
                value: ".nykant.dk");

            migrationBuilder.UpdateData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "__stripe_sid",
                column: "Domain",
                value: ".nykant.dk");

            migrationBuilder.UpdateData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "_ga",
                column: "Domain",
                value: ".nykant.dk");

            migrationBuilder.UpdateData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "AntiforgeryToken",
                column: "Domain",
                value: ".nykant.dk");

            migrationBuilder.UpdateData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "Culture",
                column: "Domain",
                value: ".nykant.dk");

            migrationBuilder.UpdateData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "Session",
                column: "Domain",
                value: "nykant.dk");

            migrationBuilder.InsertData(
                table: "Cookies",
                columns: new[] { "Name", "Category", "Description", "Domain", "Type1", "Type2" },
                values: new object[,]
                {
                    { "_ga_TrackingID", 3, "Denne cookie bruges af Google Analytics og indsamler data så som hvor mange gange en bruger har besøgt siden, datoen de har besøgt og det seneste besøg.", ".nykant.dk", 1, 0 },
                    { "m", 0, "Denne cookie bruges af Stripe og sørger for at vores betalingsservice virker, og er sikker.", "m.stripe.com", 1, 1 },
                    { "private_machine_identifier", 0, "Denne cookie bruges af Stripe og sørger for at vores betalingsservice virker, og er sikker.", ".stripe.com", 1, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "_ga_TrackingID");

            migrationBuilder.DeleteData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "m");

            migrationBuilder.DeleteData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "private_machine_identifier");

            migrationBuilder.DropColumn(
                name: "Domain",
                table: "Cookies");

            migrationBuilder.InsertData(
                table: "Cookies",
                columns: new[] { "Name", "Category", "Description", "Type1", "Type2" },
                values: new object[] { "_ga_2LWYP6ZC27", 3, "Denne cookie bruges af Google Analytics og indsamler data så som hvor mange gange en bruger har besøgt siden, datoen de har besøgt og det seneste besøg.", 1, 0 });
        }
    }
}
