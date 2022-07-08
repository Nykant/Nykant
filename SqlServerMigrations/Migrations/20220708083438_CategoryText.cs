using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.data.migrations.local
{
    public partial class CategoryText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "H1",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "H2",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text1",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text2",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Categories",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "H1", "H2", "Text1", "Text2", "Title" },
                values: new object[] { "Hos Nykant får du æstetiske tøjstativer i massivt egetræ. Tøjstativerne er lette at samle, og du kan vælge blandt flere farver. Shop online med hurtig levering.", "Tøjstativer I Træ", "Moderne Tøjstativer I Massivt Egetræ", "Vores moderne og praktiske tøjstativer er i massivt træ, tydeligt inspireret af minimalistisk dansk design, og som både er nemme at samle og sætte op. De er perfekte til indretning af et smukt, naturligt og flot hjem, hvor der er tænkt på hver detalje, i ophæng, såvel som udseende.", "Vores tøjstativer kan nemt sættes op, hvad enten det er i entréen, på kontoret eller soveværelset. Ophæng og tøjstativer, giver plads til opbevaring og er noget af det første man ser i et hjem. De giver et rigtig godt førstehåndsindtryk og skaber orden, samtidig med at se godt ud og give kant i hjemmet.", "Tøjstativ træ | Elegante tøjstativer i massivt egetræ | Køb online" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "H1", "H2", "Text1", "Text2", "Title" },
                values: new object[] { "Med et bord fra Nykant får du dansk design, overlegne detaljer og materialer i høj kvalitet. Bordene passer ind i moderne hjem. Køb online med hurtig levering.", "Bøjler I Træ", "Kvalitetsbøjler I Massivt Træ I Flere Farver", "Et tøjstativ, knagerække eller stumtjener er altid godt komplimenteret med et par bøjler. De er med til at holde vores tøj pænt, nemt tilgængeligt og fremhæver ens yndlingstasker, tøj, m.m.", "Vores bøjler er ligeledes også i massivt træ, med henblik på holdbarhed og langvarig brug, så du ikke går ned på ophæng af dine yndlingsting. De fås i tre farver, så de nemt kan sammensættes efter dine behov og i et tidløst design. ", "Egetræsbord | Køb massivt egetræsbord her | Bæredygtigt valg" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "H1", "H2", "Text1", "Text2", "Title" },
                values: new object[] { "Her hos Nykant finder du dansk designede hylder i massivt egetræ. Hylderne er lette at montere på væggen, og du kan vælge blandt flere farver. Hurtig levering.", "Bænke I Træ", "Solide Og Praktiske Bænke I Massivt Træ", "Leder du efter solide, smukke og praktisk bænke, hvor der er tænkt i funktion, såvel som æstetik. Her gås der ikke ned på detaljerne, og det ses blandt andet på vores bløde hjørner og rundinger af ben og planke. De går sig godt til ethvert hjem, og hvad enten du er til helt lys eller mørk overflade, eller midt imellem, så har vi noget til enhver smag.", "Bænke er det perfekte sted at have noget ekstra opbevaring, så mangler du noget ekstra plads til sko, handsker, m.m, så kan de nemt opbevares i vores opbevaringsbænk. Bænkene er med til at have en “holdeplads” i hjemmet, og kan sammensættes på mange måder. Det er kun fantasien, der sætter grænserne, og om det er ved spisebordet, entréen, soveværelset eller ude på en overdækket terrasse, så er vi sikre på at vores bænke kan give den kant du søger.", "Egetræshylder | Moderne væghylder i massivt egetræ | køb her" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "H1", "H2", "Text1", "Text2", "Title" },
                values: new object[] { "Find din nye favorit træbænk her hos Nykant. Designet er elegant og dansk, og bænkene er lavet i massivt egetræ. Se udvalget og køb online. Hurtig levering.", "Borde I Træ", "Egetræsborde I Minimalistisk Dansk Design", "Vores Dagmar bord er et enkelt og stilrent møbel i høj kvalitet, og tager udgangspunkt i sit smukke udseende, såvel som funktionalitet. Det er nemt at flytte og praktisk, hvad end det er til det lille tekøkken, hjørnekontoret, studieboligen, eller andre steder, hvor der ikke kræves meget plads.", "Vores borde nemt danne rammerne for en hyggelig krog eller samlingssted for små og store samtaleemner, samt giver det med sit udseende, et minimalistisk look til hjemmet. Match det med en af vores bænke for et fuldendt look eller sammensæt det på din egen måde.", "Træbænk | Stilrene egetræsbænke i dansk design | Køb online" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "H1", "H2", "Text1", "Text2", "Title" },
                values: new object[] { "Se de lækre bøjler i massivt egetræ hos Nykant. Der er kræset for detaljerne, og intet er tilfældigt. Bøjlerne kommer i forskellige farver. Hurtig levering.", "Hylder I Træ", "Simple Træhylder I Mange Størrelser Og Farver", "Hylden, Ingeborg er solid, enkel og fås i tre, flotte overfladebehandlinger. Det er hylden til små nips, billeder, bøger eller andre ting, som er med til at skabe et hjem med kant. Det er lavet i stil med vores andre møbler med massivt træ og mere funktion.", "Ingeborg, kan monteres helt ind til væggen, og opsættes med bunden, op eller ned, så du helt selv bestemmer, hvordan det skal se ud. I soveværelset, stuen, kontoret eller entréen, der er ikke det sted, hvor den ikke kan være og så fås den også i flere størrelser, så der gås ikke ned på plads og opbevaring.", "Træbøjler | Køb massive egetræsbøjler i elegant dansk design" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "H1",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "H2",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Text1",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Text2",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Categories");
        }
    }
}
