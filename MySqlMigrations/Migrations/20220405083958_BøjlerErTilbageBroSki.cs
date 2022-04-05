using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySqlMigrations.Migrations
{
    public partial class BøjlerErTilbageBroSki : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImgSource", "Name" },
                values: new object[] { 5, "../images/Products/Category/Desktop/boejle_natur_1.png", "Bøjler" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Amount", "ExpectedDelivery" },
                values: new object[] { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExpectedDelivery",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Amount", "ExpectedDelivery" },
                values: new object[] { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Amount", "ExpectedDelivery" },
                values: new object[] { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Amount", "ExpectedDelivery" },
                values: new object[] { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Amount", "ExpectedDelivery" },
                values: new object[] { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Amount", "ExpectedDelivery" },
                values: new object[] { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Amount", "ExpectedDelivery" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Amount", "ExpectedDelivery" },
                values: new object[] { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Amount", "ExpectedDelivery" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Amount", "ExpectedDelivery" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Amount", "ExpectedDelivery" },
                values: new object[] { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Alt", "Amount", "AssemblyPath", "CategoryId", "Description", "EColor", "ExpectedDelivery", "GalleryImage1", "GalleryImage2", "Length", "Materials", "Name", "Note", "Number", "Oil", "Package", "Path", "Pieces", "Price", "Size", "Title", "UrlName", "WeightInKg" },
                values: new object[] { 1, null, 420, "none", 5, "Denne smukke bøjle med klassiske fine linjer, afrundede kanter og ender, giver perfekt støtte og mindst mulige mærker i tøjet.", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_boejle_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_boejle_naturolie_02.png", null, "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Sort bøjlekrog</p></td></tr>", "Bøjlen Gertrud / 3 stk.", null, "15001", "Naturolie", "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 47x17x6 cm. (L x B x H)</p><p>Vægt: 0.6 kg.</p><p>Leveres samlet med 3 stk. pr. karton</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_boejle_naturolie_01.png", 3, 420.0, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Tykkelse: 2 cm.</p><p>Længde: 45 cm.</p></td></tr>", "Bøjle i massivt egetræ - Behandlet med naturolie", "Bøjle-Egetræ-Naturolie", 0.59999999999999998 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Alt", "Amount", "AssemblyPath", "CategoryId", "Description", "EColor", "ExpectedDelivery", "GalleryImage1", "GalleryImage2", "Length", "Materials", "Name", "Note", "Number", "Oil", "Package", "Path", "Pieces", "Price", "Size", "Title", "UrlName", "WeightInKg" },
                values: new object[] { 2, null, 123, "none", 5, "Denne smukke bøjle med klassiske fine linjer, afrundede kanter og ender, giver perfekt støtte og mindst mulige mærker i tøjet.", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_boejle_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_boejle_sortolie_02.png", null, "<tr><td class='width-30'<strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Sort bøjlekrog</p></td></tr>", "Bøjlen Gertrud / 3 stk.", null, "15003", "Sortolie", "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 47x17x6 cm. (L x B x H)</p><p>Vægt: 0.6 kg.</p><p>Leveres samlet med 3 stk. pr. karton</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_boejle_sortolie_01.png", 3, 420.0, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Tykkelse: 2 cm.</p><p>Længde: 45 cm.</p></td></tr>", "Bøjle i massivt egetræ - Behandlet med sortolie", "Bøjle-Egetræ-Sortolie", 0.59999999999999998 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Alt", "Amount", "AssemblyPath", "CategoryId", "Description", "EColor", "ExpectedDelivery", "GalleryImage1", "GalleryImage2", "Length", "Materials", "Name", "Note", "Number", "Oil", "Package", "Path", "Pieces", "Price", "Size", "Title", "UrlName", "WeightInKg" },
                values: new object[] { 3, null, 123, "none", 5, "Denne smukke bøjle med klassiske fine linjer, afrundede kanter og ender, giver perfekt støtte og mindst mulige mærker i tøjet.", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_boejle_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_boejle_hvidolie_02.png", null, "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Sort bøjlekrog</p></td></tr>", "Bøjlen Gertrud / 3 stk.", null, "15002", "Hvidolie", "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 47x17x6 cm. (L x B x H)</p><p>Vægt: 0.6 kg.</p><p>Leveres samlet med 3 stk. pr. karton</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_boejle_hvidolie_01.png", 3, 420.0, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Tykkelse: 2 cm.</p><p>Længde: 45 cm.</p></td></tr>", "Bøjle i massivt egetræ - Behandlet med hvidolie", "Bøjle-Egetræ-Hvidolie", 0.59999999999999998 });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "EColor", "ImgSrc", "ProductId", "ProductSourceId", "ProductSourceUrlName" },
                values: new object[,]
                {
                    { 1, 0, "../images/Products/Color/Desktop/boejle_natur_1.png", 1, 1, "Bøjle-Egetræ-Naturolie" },
                    { 2, 2, "../images/Products/Color/Desktop/boejle_sort_1.png", 1, 2, "Bøjle-Egetræ-Sortolie" },
                    { 3, 1, "../images/Products/Color/Desktop/boejle_hvid_1.png", 1, 3, "Bøjle-Egetræ-Hvidolie" },
                    { 9, 1, "../images/Products/Color/Desktop/boejle_hvid_1.png", 3, 3, "Bøjle-Egetræ-Hvidolie" },
                    { 8, 2, "../images/Products/Color/Desktop/boejle_sort_1.png", 3, 2, "Bøjle-Egetræ-Sortolie" },
                    { 4, 0, "../images/Products/Color/Desktop/boejle_natur_1.png", 2, 1, "Bøjle-Egetræ-Naturolie" },
                    { 5, 2, "../images/Products/Color/Desktop/boejle_sort_1.png", 2, 2, "Bøjle-Egetræ-Sortolie" },
                    { 6, 1, "../images/Products/Color/Desktop/boejle_hvid_1.png", 2, 3, "Bøjle-Egetræ-Hvidolie" },
                    { 7, 0, "../images/Products/Color/Desktop/boejle_natur_1.png", 3, 1, "Bøjle-Egetræ-Naturolie" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ImageType", "ProductId", "Size", "Source", "Source2" },
                values: new object[,]
                {
                    { 6, 0, 3, 2, "../images/Products/Details_Slide/Desktop/NYKANT_boejle_hvidolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_boejle_hvidolie_02.png" },
                    { 5, 0, 3, 2, "../images/Products/Details_Slide/Desktop/NYKANT_boejle_hvidolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_boejle_hvidolie_01.png" },
                    { 232, 1, 2, 2, "../images/Products/Details_Button/Desktop/NYKANT_boejle_sortolie_02.png", null },
                    { 3, 0, 2, 2, "../images/Products/Details_Slide/Desktop/NYKANT_boejle_sortolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_boejle_sortolie_01.png" },
                    { 4, 0, 2, 2, "../images/Products/Details_Slide/Desktop/NYKANT_boejle_sortolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_boejle_sortolie_02.png" },
                    { 233, 1, 3, 2, "../images/Products/Details_Button/Desktop/NYKANT_boejle_hvidolie_01.png", null },
                    { 230, 1, 1, 2, "../images/Products/Details_Button/Desktop/NYKANT_boejle_naturolie_02.png", null },
                    { 229, 1, 1, 2, "../images/Products/Details_Button/Desktop/NYKANT_boejle_naturolie_01.png", null },
                    { 2, 0, 1, 2, "../images/Products/Details_Slide/Desktop/NYKANT_boejle_naturolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_boejle_naturolie_02.png" },
                    { 1, 0, 1, 2, "../images/Products/Details_Slide/Desktop/NYKANT_boejle_naturolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_boejle_naturolie_01.png" },
                    { 231, 1, 2, 2, "../images/Products/Details_Button/Desktop/NYKANT_boejle_sortolie_01.png", null },
                    { 234, 1, 3, 2, "../images/Products/Details_Button/Desktop/NYKANT_boejle_hvidolie_02.png", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Amount", "ExpectedDelivery" },
                values: new object[] { 0, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExpectedDelivery",
                value: new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Amount", "ExpectedDelivery" },
                values: new object[] { 0, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Amount", "ExpectedDelivery" },
                values: new object[] { 0, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Amount", "ExpectedDelivery" },
                values: new object[] { 0, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Amount", "ExpectedDelivery" },
                values: new object[] { 0, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Amount", "ExpectedDelivery" },
                values: new object[] { 0, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Amount", "ExpectedDelivery" },
                values: new object[] { 0, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Amount", "ExpectedDelivery" },
                values: new object[] { 0, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Amount", "ExpectedDelivery" },
                values: new object[] { 0, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Amount", "ExpectedDelivery" },
                values: new object[] { 0, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Amount", "ExpectedDelivery" },
                values: new object[] { 0, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
