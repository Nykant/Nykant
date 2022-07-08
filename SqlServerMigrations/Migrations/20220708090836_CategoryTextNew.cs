using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.data.migrations.local
{
    public partial class CategoryTextNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "H1", "H2", "Text1", "Text2" },
                values: new object[] { "Borde I Træ", "Egetræsborde I Minimalistisk Dansk Design", "Vores Dagmar bord er et enkelt og stilrent møbel i høj kvalitet, og tager udgangspunkt i sit smukke udseende, såvel som funktionalitet. Det er nemt at flytte og praktisk, hvad end det er til det lille tekøkken, hjørnekontoret, studieboligen, eller andre steder, hvor der ikke kræves meget plads.", "Vores borde nemt danne rammerne for en hyggelig krog eller samlingssted for små og store samtaleemner, samt giver det med sit udseende, et minimalistisk look til hjemmet. Match det med en af vores bænke for et fuldendt look eller sammensæt det på din egen måde." });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "H1", "H2", "Text1", "Text2" },
                values: new object[] { "Hylder I Træ", "Simple Træhylder I Mange Størrelser Og Farver", "Hylden, Ingeborg er solid, enkel og fås i tre, flotte overfladebehandlinger. Det er hylden til små nips, billeder, bøger eller andre ting, som er med til at skabe et hjem med kant. Det er lavet i stil med vores andre møbler med massivt træ og mere funktion.", "Ingeborg, kan monteres helt ind til væggen, og opsættes med bunden, op eller ned, så du helt selv bestemmer, hvordan det skal se ud. I soveværelset, stuen, kontoret eller entréen, der er ikke det sted, hvor den ikke kan være og så fås den også i flere størrelser, så der gås ikke ned på plads og opbevaring." });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "H1", "H2", "Text1", "Text2" },
                values: new object[] { "Bænke I Træ", "Solide Og Praktiske Bænke I Massivt Træ", "Leder du efter solide, smukke og praktisk bænke, hvor der er tænkt i funktion, såvel som æstetik, så har vi det rette. Her gås der ikke ned på detaljerne, og det ses blandt andet på vores bløde hjørner og rundinger af ben og planke. De går sig godt til ethvert hjem, og hvad enten du er til helt lys eller mørk overflade, eller midt imellem, så har vi noget til enhver smag.", "Bænke er det perfekte sted at have noget ekstra opbevaring, så mangler du noget ekstra plads til sko, handsker, m.m, så kan de nemt opbevares i vores opbevaringsbænk. Bænkene er med til at have en “holdeplads” i hjemmet, og kan sammensættes på mange måder. Det er kun fantasien, der sætter grænserne, og om det er ved spisebordet, entréen, soveværelset eller ude på en overdækket terrasse, så er vi sikre på at vores bænke kan give den kant du søger." });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "H1", "H2", "Text1", "Text2" },
                values: new object[] { "Bøjler I Træ", "Kvalitetsbøjler I Massivt Træ I Flere Farver", "Et tøjstativ, knagerække eller stumtjener er altid godt komplimenteret med et par bøjler. De er med til at holde vores tøj pænt, nemt tilgængeligt og fremhæver ens yndlingstasker, tøj, m.m.", "Vores bøjler er ligeledes også i massivt træ, med henblik på holdbarhed og langvarig brug, så du ikke går ned på ophæng af dine yndlingsting. De fås i tre farver, så de nemt kan sammensættes efter dine behov og i et tidløst design." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "H1", "H2", "Text1", "Text2" },
                values: new object[] { "Bøjler I Træ", "Kvalitetsbøjler I Massivt Træ I Flere Farver", "Et tøjstativ, knagerække eller stumtjener er altid godt komplimenteret med et par bøjler. De er med til at holde vores tøj pænt, nemt tilgængeligt og fremhæver ens yndlingstasker, tøj, m.m.", "Vores bøjler er ligeledes også i massivt træ, med henblik på holdbarhed og langvarig brug, så du ikke går ned på ophæng af dine yndlingsting. De fås i tre farver, så de nemt kan sammensættes efter dine behov og i et tidløst design. " });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "H1", "H2", "Text1", "Text2" },
                values: new object[] { "Bænke I Træ", "Solide Og Praktiske Bænke I Massivt Træ", "Leder du efter solide, smukke og praktisk bænke, hvor der er tænkt i funktion, såvel som æstetik. Her gås der ikke ned på detaljerne, og det ses blandt andet på vores bløde hjørner og rundinger af ben og planke. De går sig godt til ethvert hjem, og hvad enten du er til helt lys eller mørk overflade, eller midt imellem, så har vi noget til enhver smag.", "Bænke er det perfekte sted at have noget ekstra opbevaring, så mangler du noget ekstra plads til sko, handsker, m.m, så kan de nemt opbevares i vores opbevaringsbænk. Bænkene er med til at have en “holdeplads” i hjemmet, og kan sammensættes på mange måder. Det er kun fantasien, der sætter grænserne, og om det er ved spisebordet, entréen, soveværelset eller ude på en overdækket terrasse, så er vi sikre på at vores bænke kan give den kant du søger." });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "H1", "H2", "Text1", "Text2" },
                values: new object[] { "Borde I Træ", "Egetræsborde I Minimalistisk Dansk Design", "Vores Dagmar bord er et enkelt og stilrent møbel i høj kvalitet, og tager udgangspunkt i sit smukke udseende, såvel som funktionalitet. Det er nemt at flytte og praktisk, hvad end det er til det lille tekøkken, hjørnekontoret, studieboligen, eller andre steder, hvor der ikke kræves meget plads.", "Vores borde nemt danne rammerne for en hyggelig krog eller samlingssted for små og store samtaleemner, samt giver det med sit udseende, et minimalistisk look til hjemmet. Match det med en af vores bænke for et fuldendt look eller sammensæt det på din egen måde." });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "H1", "H2", "Text1", "Text2" },
                values: new object[] { "Hylder I Træ", "Simple Træhylder I Mange Størrelser Og Farver", "Hylden, Ingeborg er solid, enkel og fås i tre, flotte overfladebehandlinger. Det er hylden til små nips, billeder, bøger eller andre ting, som er med til at skabe et hjem med kant. Det er lavet i stil med vores andre møbler med massivt træ og mere funktion.", "Ingeborg, kan monteres helt ind til væggen, og opsættes med bunden, op eller ned, så du helt selv bestemmer, hvordan det skal se ud. I soveværelset, stuen, kontoret eller entréen, der er ikke det sted, hvor den ikke kan være og så fås den også i flere størrelser, så der gås ikke ned på plads og opbevaring." });
        }
    }
}
