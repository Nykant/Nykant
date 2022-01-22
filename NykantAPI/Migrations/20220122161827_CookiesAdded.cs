using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.Migrations
{
    public partial class CookiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cookies",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Type1 = table.Column<int>(nullable: false),
                    Type2 = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cookies", x => x.Name);
                });

            migrationBuilder.InsertData(
                table: "Cookies",
                columns: new[] { "Name", "Category", "Description", "Type1", "Type2" },
                values: new object[,]
                {
                    { ".AspNetCore.Culture", 1, "Denne cookie gemmer din præference for sprog.", 1, 0 },
                    { "AntiforgeryToken", 0, "Denne cookie beskytter imod Cross-Site Request Forgery angreb", 0, 0 },
                    { "Session", 0, "Denne cookie husker/gemmer hvad du har lagt i din kurv, samt giver dig en bedre checkout oplevelse.", 0, 0 },
                    { "__stripe_mid", 0, "Denne cookie bruges af Stripe og sørger for at vores betalingsservice virker, og er sikker.", 1, 1 },
                    { "__stripe_sid", 0, "Denne cookie bruges af Stripe og sørger for at vores betalingsservice virker, og er sikker.", 1, 1 },
                    { "_ga", 3, "Denne cookie bruges af Google Analytics og registrere et unikt ID, som bliver brugt til at generere statistiske data om hvordan besøgende bruger hjemmesiden.", 1, 1 },
                    { "_ga_2LWYP6ZC27", 3, "Denne cookie bruges af Google Analytics og indsamler data så som hvor mange gange en bruger har besøgt siden, datoen de har besøgt og det seneste besøg.", 1, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cookies");
        }
    }
}
