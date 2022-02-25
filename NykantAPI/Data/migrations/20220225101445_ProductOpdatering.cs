using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.data.migrations
{
    public partial class ProductOpdatering : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "_ga_TrackingID");

            migrationBuilder.DeleteData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "cookie-perms");

            migrationBuilder.DeleteData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "stripe.csrf");

            migrationBuilder.UpdateData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "__stripe_mid",
                column: "Description",
                value: "Sørger for sikkerhed under betalingen via vores betalingsservice stripe. Forebygger imod svig/forfalskning.");

            migrationBuilder.UpdateData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "__stripe_sid",
                column: "Description",
                value: "Sørger for sikkerhed under betalingen via vores betalingsservice stripe. Forebygger imod svig/forfalskning.");

            migrationBuilder.UpdateData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "_ga",
                column: "Description",
                value: "Indsamler anonymiseret data om hvad du foretager dig på hjemmesiden, og sender det til google analytics, så vi kan se og bruge det til at forbedre hjemmesiden.");

            migrationBuilder.UpdateData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "m",
                column: "Description",
                value: "Sørger for sikkerhed under betalingen via vores betalingsservice stripe. Forebygger imod svig/forfalskning.");

            migrationBuilder.UpdateData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "private_machine_identifier",
                column: "Description",
                value: "Sørger for sikkerhed under betalingen via vores betalingsservice stripe. Forebygger imod svig/forfalskning.");

            migrationBuilder.UpdateData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "Session",
                column: "Description",
                value: "Denne cookie husker/gemmer hvad du har lagt i din kurv, gemmer dine cookie preferencer, samt giver dig en bedre checkout oplevelse.");

            migrationBuilder.InsertData(
                table: "Cookies",
                columns: new[] { "Name", "Category", "Description", "Domain", "Type1", "Type2" },
                values: new object[] { "_ga_*", 3, "Indsamler anonymiseret data om hvad du foretager dig på hjemmesiden, og sender det til google analytics, så vi kan se og bruge det til at forbedre hjemmesiden.", ".nykant.dk", 1, 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 47x17x6 cm. (L x B x H)</p><p>Vægt: 0.6 kg.</p><p>Leveres samlet med 3 stk. pr. karton</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 47x17x6 cm. (L x B x H)</p><p>Vægt: 0.6 kg.</p><p>Leveres samlet med 3 stk. pr. karton</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 47x17x6 cm. (L x B x H)</p><p>Vægt: 0.6 kg.</p><p>Leveres samlet med 3 stk. pr. karton</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Package",
                value: "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 43x22x4.5 cm. (L x B x H)</p><p>Vægt: 1.4 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Package",
                value: "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 43x22x4.5 cm. (L x B x H)</p><p>Vægt: 1.4 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Package",
                value: "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 43x22x4.5 cm. (L x B x H)</p><p>Vægt: 1.4 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Package",
                value: "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 63x22x4.5 cm. (L x B x H)</p><p>Vægt: 2 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Package",
                value: "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 63x22x4.5 cm. (L x B x H)</p><p>Vægt: 2 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Package",
                value: "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 63x22x4.5 cm. (L x B x H)</p><p>Vægt: 2 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "Package",
                value: "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 83x22x4.5 cm. (L x B x H)</p><p>Vægt: 2.6 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "Package",
                value: "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 83x22x4.5 cm. (L x B x H)</p><p>Vægt: 2.6 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "Package",
                value: "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 83x22x4.5 cm. (L x B x H)</p><p>Vægt: 2.6 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "Package",
                value: "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse:  103x22x4.5 cm. (L x B x H)</p><p>Vægt: 3.2 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "Package",
                value: "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse:  103x22x4.5 cm. (L x B x H)</p><p>Vægt: 3.2 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "Package",
                value: "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse:  103x22x4.5 cm. (L x B x H)</p><p>Vægt: 3.2 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken:</strong></td><td><p>Vægt: 22 kg.</p><p>Størrelse: 11 x 75 x 114 cm. (H x B x L)</p><p> Leveres usamlet - se samlevejledning </p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken:</strong></td><td><p>Vægt: 22 kg.</p><p>Størrelse: 11 x 75 x 114 cm. (H x B x L)</p><p> Leveres usamlet - se samlevejledning </p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 11 x 47 x 120 cm. (H x B x L)</p><p>Vægt: 14 kg.</p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 11 x 47 x 120 cm. (H x B x L)</p><p>Vægt: 14 kg.</p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 11 x 47 x 120 cm. (H x B x L)</p><p>Vægt: 14 kg.</p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 11 x 47 x 175 cm. (H x B x L)</p><p>Vægt: 20 kg.</p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 11 x 47 x 175 cm. (H x B x L)</p><p>Vægt: 20 kg.</p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 11 x 47 x 175 cm. (H x B x L)</p><p>Vægt: 20 kg.</p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "Package",
                value: "<tr><td class='width-30'><strong>Pakken:</strong></td><td><p>Vægt: 24 kg.</p><p>Størrelse: 40 x 50 x 115 cm. (B x H x L)</p><p>Leveres samlet </p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "Package",
                value: "<tr><td class='width-30'><strong>Pakken:</strong></td><td><p>Vægt: 24 kg.</p><p>Størrelse: 40 x 50 x 115 cm. (B x H x L)</p><p>Leveres samlet </p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "Package",
                value: "<tr><td class='width-30'><strong>Pakken:</strong></td><td><p>Vægt: 24 kg.</p><p>Størrelse: 40 x 50 x 115 cm. (B x H x L)</p><p>Leveres samlet </p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Leveres usamlet i 2 kartoner - se samlevejledning</p></td></tr><tr class='no-border'><td class='width-30'><strong>Karton 1</strong></td><td> <p>Vægt: 5 kg.</p><p> Størrelse: 6.5 x 11.5 x 186 cm. (H x B x L)</p></td></tr><tr><td class='width-30'><strong>Karton 2</strong></td><td> <p>Vægt: 3 kg.</p><p>Størrelse: 5.5 x 54 x 119 cm. (H x B x L)</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Leveres usamlet i 2 kartoner - se samlevejledning</p></td></tr><tr class='no-border'><td class='width-30'><strong>Karton 1</strong></td><td> <p>Vægt: 5 kg.</p><p> Størrelse: 6.5 x 11.5 x 186 cm. (H x B x L)</p></td></tr><tr><td class='width-30'><strong>Karton 2</strong></td><td> <p>Vægt: 3 kg.</p><p>Størrelse: 5.5 x 54 x 119 cm. (H x B x L)</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Leveres usamlet i 2 kartoner - se samlevejledning</p></td></tr><tr class='no-border'><td class='width-30'><strong>Karton 1</strong></td><td> <p>Vægt: 5 kg.</p><p> Størrelse: 6.5 x 11.5 x 186 cm. (H x B x L)</p></td></tr><tr><td class='width-30'><strong>Karton 2</strong></td><td> <p>Vægt: 3 kg.</p><p>Størrelse: 5.5 x 54 x 119 cm. (H x B x L)</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Vægt: 2kg.</p><p>Størrelse: 7 x 105 x 9.5 cm. (H x L x B)</p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Vægt: 2kg.</p><p>Størrelse: 7 x 105 x 9.5 cm. (H x L x B)</p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Vægt: 2kg.</p><p>Størrelse: 7 x 105 x 9.5 cm. (H x L x B)</p><p>Leveres usamlet - se samlevejledning</p></td></tr>");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "_ga_*");

            migrationBuilder.UpdateData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "__stripe_mid",
                column: "Description",
                value: "Denne cookie bruges af Stripe og sørger for at vores betalingsservice virker, og er sikker.");

            migrationBuilder.UpdateData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "__stripe_sid",
                column: "Description",
                value: "Denne cookie bruges af Stripe og sørger for at vores betalingsservice virker, og er sikker.");

            migrationBuilder.UpdateData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "_ga",
                column: "Description",
                value: "Denne cookie bruges af Google Analytics og registrere et unikt ID, som bliver brugt til at generere statistiske data om hvordan besøgende bruger hjemmesiden.");

            migrationBuilder.UpdateData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "m",
                column: "Description",
                value: "Denne cookie bruges af Stripe og sørger for at vores betalingsservice virker, og er sikker.");

            migrationBuilder.UpdateData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "private_machine_identifier",
                column: "Description",
                value: "Denne cookie bruges af Stripe og sørger for at vores betalingsservice virker, og er sikker.");

            migrationBuilder.UpdateData(
                table: "Cookies",
                keyColumn: "Name",
                keyValue: "Session",
                column: "Description",
                value: "Denne cookie husker/gemmer hvad du har lagt i din kurv, samt giver dig en bedre checkout oplevelse.");

            migrationBuilder.InsertData(
                table: "Cookies",
                columns: new[] { "Name", "Category", "Description", "Domain", "Type1", "Type2" },
                values: new object[,]
                {
                    { "_ga_TrackingID", 3, "Denne cookie bruges af Google Analytics og indsamler data så som hvor mange gange en bruger har besøgt siden, datoen de har besøgt og det seneste besøg.", ".nykant.dk", 1, 0 },
                    { "stripe.csrf", 0, "Denne cookie bruges af Stripe og sørger for at vores betalingsservice virker, og er sikker.", "stripe.com", 1, 1 },
                    { "cookie-perms", 0, "Denne cookie bruges af Stripe og sørger for at vores betalingsservice virker, og er sikker.", "stripe.com", 1, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 47x17x6 cm.</p><p>Vægt: 0.6 kg.</p><p>Leveres samlet med 3 stk. pr. karton</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 47x17x6 cm.</p><p>Vægt: 0.6 kg.</p><p>Leveres samlet med 3 stk. pr. karton</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 47x17x6 cm.</p><p>Vægt: 0.6 kg.</p><p>Leveres samlet med 3 stk. pr. karton</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Package",
                value: "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 43x22x4.5 cm. </p><p>Vægt: 1.4 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Package",
                value: "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 43x22x4.5 cm. </p><p>Vægt: 1.4 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Package",
                value: "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 43x22x4.5 cm. </p><p>Vægt: 1.4 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Package",
                value: "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 63x22x4.5 cm. </p><p>Vægt: 2 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Package",
                value: "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 63x22x4.5 cm. </p><p>Vægt: 2 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Package",
                value: "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 63x22x4.5 cm. </p><p>Vægt: 2 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "Package",
                value: "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 83x22x4.5 cm. </p><p>Vægt: 2.6 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "Package",
                value: "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 83x22x4.5 cm. </p><p>Vægt: 2.6 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "Package",
                value: "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 83x22x4.5 cm. </p><p>Vægt: 2.6 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "Package",
                value: "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse:  103x22x4.5 cm.</p><p>Vægt: 3.2 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "Package",
                value: "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse:  103x22x4.5 cm.</p><p>Vægt: 3.2 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "Package",
                value: "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse:  103x22x4.5 cm.</p><p>Vægt: 3.2 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken:</strong></td><td><p>Vægt: 22 kg.</p><p>Størrelse: 11 x 75 x 114 cm.</p><p> Leveres usamlet - se samlevejledning </p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken:</strong></td><td><p>Vægt: 22 kg.</p><p>Størrelse: 11 x 75 x 114 cm.</p><p> Leveres usamlet - se samlevejledning </p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 11 x 47 x 120 cm.</p><p>Vægt: 14 kg.</p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 11 x 47 x 120 cm.</p><p>Vægt: 14 kg.</p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 11 x 47 x 120 cm.</p><p>Vægt: 14 kg.</p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 11 x 47 x 175 cm.</p><p>Vægt: 20 kg.</p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 11 x 47 x 175 cm.</p><p>Vægt: 20 kg.</p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 11 x 47 x 175 cm.</p><p>Vægt: 20 kg.</p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "Package",
                value: "<tr><td class='width-30'><strong>Pakken:</strong></td><td><p>Vægt: 24 kg.</p><p>Størrelse: 40 x 50 x 115 cm.</p><p>Leveres samlet </p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "Package",
                value: "<tr><td class='width-30'><strong>Pakken:</strong></td><td><p>Vægt: 24 kg.</p><p>Størrelse: 40 x 50 x 115 cm.</p><p>Leveres samlet </p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "Package",
                value: "<tr><td class='width-30'><strong>Pakken:</strong></td><td><p>Vægt: 24 kg.</p><p>Størrelse: 40 x 50 x 115 cm.</p><p>Leveres samlet </p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Leveres usamlet i 2 kartoner - se samlevejledning</p></td></tr><tr class='no-border'><td class='width-30'><strong>Karton 1</strong></td><td> <p>Vægt: 5 kg.</p><p> Størrelse: 6.5 x 11.5 x 186 cm.</p></td></tr><tr><td class='width-30'><strong>Karton 2</strong></td><td> <p>Vægt: 3 kg.</p><p>Størrelse: 5.5 x 54 x 119 cm.</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Leveres usamlet i 2 kartoner - se samlevejledning</p></td></tr><tr class='no-border'><td class='width-30'><strong>Karton 1</strong></td><td> <p>Vægt: 5 kg.</p><p> Størrelse: 6.5 x 11.5 x 186 cm.</p></td></tr><tr><td class='width-30'><strong>Karton 2</strong></td><td> <p>Vægt: 3 kg.</p><p>Størrelse: 5.5 x 54 x 119 cm.</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Leveres usamlet i 2 kartoner - se samlevejledning</p></td></tr><tr class='no-border'><td class='width-30'><strong>Karton 1</strong></td><td> <p>Vægt: 5 kg.</p><p> Størrelse: 6.5 x 11.5 x 186 cm.</p></td></tr><tr><td class='width-30'><strong>Karton 2</strong></td><td> <p>Vægt: 3 kg.</p><p>Størrelse: 5.5 x 54 x 119 cm.</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Vægt: 2kg.</p><p>Størrelse: 7 x 105 x 9.5 cm.</p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Vægt: 2kg.</p><p>Størrelse: 7 x 105 x 9.5 cm.</p><p>Leveres usamlet - se samlevejledning</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "Package",
                value: "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Vægt: 2kg.</p><p>Størrelse: 7 x 105 x 9.5 cm.</p><p>Leveres usamlet - se samlevejledning</p></td></tr>");
        }
    }
}
