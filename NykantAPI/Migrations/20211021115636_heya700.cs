using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.Migrations
{
    public partial class heya700 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageSource", "ImageSource2", "ItemType", "LastModified", "Path" },
                values: new object[] { "../images/Products/NYKANT_boejle_naturolie_01.png", "../images/Products/NYKANT_boejle_naturolie_02.png", "Bøjle", new DateTime(2021, 10, 21, 13, 56, 35, 270, DateTimeKind.Local).AddTicks(1566), "../images/Products/NYKANT_boejle_naturolie_01.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "ImageSource", "ImageSource2", "ItemType", "LastModified", "Name", "Oil", "Path", "Size", "Title", "TypeOfWood", "WeightInKg" },
                values: new object[] { 1, "Vores tøjstativ ”Nora” er udviklet i et system hvor det samles uden skruer og lim, men udelukkende med kiler i massiv egetræ. Detaljen i sig selv er både meget nem at samle og skille, men viser måske i endnu højere grad nogle meget smukke og enkle detaljer, Der klæder møblet med en meget høj snedkermæssig niveau.", "../images/Products/NYKANT_boejle_sortolie_01.png", "../images/Products/NYKANT_boejle_sortolie_02.png", "Bøjle", new DateTime(2021, 10, 21, 13, 56, 35, 272, DateTimeKind.Local).AddTicks(6697), "Nora", "naturligt", "../images/Products/NYKANT_boejle_sortolie_01.png", "5mm", null, "Eg", 11.6 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "ImageSource", "ImageSource2", "ItemType", "LastModified", "Name", "Path", "Size", "Title", "TypeOfWood", "WeightInKg" },
                values: new object[] { 1, "Vores tøjstativ ”Nora” er udviklet i et system hvor det samles uden skruer og lim, men udelukkende med kiler i massiv egetræ. Detaljen i sig selv er både meget nem at samle og skille, men viser måske i endnu højere grad nogle meget smukke og enkle detaljer, Der klæder møblet med en meget høj snedkermæssig niveau.", "../images/Products/NYKANT_boejle_hvidolie_01.png", "../images/Products/NYKANT_boejle_hvidolie_02.png", "Bøjle", new DateTime(2021, 10, 21, 13, 56, 35, 272, DateTimeKind.Local).AddTicks(6804), "Nora", "../images/Products/NYKANT_boejle_hvidolie_01.png", "5mm", null, "Eg", 11.6 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Description", "ImageSource", "ImageSource2", "ItemType", "LastModified", "Name", "Oil", "Path", "Title", "TypeOfWood", "WeightInKg" },
                values: new object[] { 1, "Vores tøjstativ ”Nora” er udviklet i et system hvor det samles uden skruer og lim, men udelukkende med kiler i massiv egetræ. Detaljen i sig selv er både meget nem at samle og skille, men viser måske i endnu højere grad nogle meget smukke og enkle detaljer, Der klæder møblet med en meget høj snedkermæssig niveau.", "../images/Products/NYKANT_hylde_hvidolie_01.png", "../images/Products/NYKANT_hylde_hvidolie_02.png", "Bøjle", new DateTime(2021, 10, 21, 13, 56, 35, 272, DateTimeKind.Local).AddTicks(6810), "Nora", "naturligt", "../images/Products/NYKANT_hylde_hvidolie_01.png", null, "Eg", 11.6 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Description", "ImageSource", "ImageSource2", "ItemType", "LastModified", "Name", "Path", "Size", "Title", "TypeOfWood", "WeightInKg" },
                values: new object[] { 1, "Vores tøjstativ ”Nora” er udviklet i et system hvor det samles uden skruer og lim, men udelukkende med kiler i massiv egetræ. Detaljen i sig selv er både meget nem at samle og skille, men viser måske i endnu højere grad nogle meget smukke og enkle detaljer, Der klæder møblet med en meget høj snedkermæssig niveau.", "../images/Products/NYKANT_hylde_sortolie_01.png", "../images/Products/NYKANT_hylde_sortolie_02.png", "Bøjle", new DateTime(2021, 10, 21, 13, 56, 35, 272, DateTimeKind.Local).AddTicks(6814), "Nora", "../images/Products/NYKANT_hylde_sortolie_01.png", "5mm", null, "Eg", 11.6 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "ImageSource", "ImageSource2", "ItemType", "LastModified", "Name", "Oil", "Path", "Size", "Title", "TypeOfWood", "WeightInKg" },
                values: new object[] { "Vores tøjstativ ”Nora” er udviklet i et system hvor det samles uden skruer og lim, men udelukkende med kiler i massiv egetræ. Detaljen i sig selv er både meget nem at samle og skille, men viser måske i endnu højere grad nogle meget smukke og enkle detaljer, Der klæder møblet med en meget høj snedkermæssig niveau.", "../images/Products/NYKANT_hylde_naturolie_01.png", "../images/Products/NYKANT_hylde_naturolie_02.png", "Bøjle", new DateTime(2021, 10, 21, 13, 56, 35, 272, DateTimeKind.Local).AddTicks(6818), "Nora", "naturligt", "../images/Products/NYKANT_hylde_naturolie_01.png", "5mm", null, "Eg", 11.6 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "Description", "ImageSource", "ImageSource2", "ItemType", "LastModified", "Name", "Path", "Title", "TypeOfWood", "WeightInKg" },
                values: new object[] { 1, "Vores tøjstativ ”Nora” er udviklet i et system hvor det samles uden skruer og lim, men udelukkende med kiler i massiv egetræ. Detaljen i sig selv er både meget nem at samle og skille, men viser måske i endnu højere grad nogle meget smukke og enkle detaljer, Der klæder møblet med en meget høj snedkermæssig niveau.", "../images/Products/NYKANT_bord_naturolie_01.png", "../images/Products/NYKANT_bord_naturolie_02.png", "Bøjle", new DateTime(2021, 10, 21, 13, 56, 35, 272, DateTimeKind.Local).AddTicks(6820), "Nora", "../images/Products/NYKANT_bord_naturolie_01.png", null, "Eg", 11.6 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastModified",
                value: new DateTime(2021, 10, 21, 13, 56, 35, 272, DateTimeKind.Local).AddTicks(7040));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastModified",
                value: new DateTime(2021, 10, 21, 13, 56, 35, 272, DateTimeKind.Local).AddTicks(7064));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastModified",
                value: new DateTime(2021, 10, 21, 13, 56, 35, 272, DateTimeKind.Local).AddTicks(7070));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastModified",
                value: new DateTime(2021, 10, 21, 13, 56, 35, 272, DateTimeKind.Local).AddTicks(7075));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastModified",
                value: new DateTime(2021, 10, 21, 13, 56, 35, 272, DateTimeKind.Local).AddTicks(7080));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "LastModified",
                value: new DateTime(2021, 10, 21, 13, 56, 35, 272, DateTimeKind.Local).AddTicks(7085));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "LastModified",
                value: new DateTime(2021, 10, 21, 13, 56, 35, 272, DateTimeKind.Local).AddTicks(7088));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "LastModified",
                value: new DateTime(2021, 10, 21, 13, 56, 35, 272, DateTimeKind.Local).AddTicks(7091));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastModified",
                value: new DateTime(2021, 10, 21, 13, 56, 35, 272, DateTimeKind.Local).AddTicks(7094));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "LastModified",
                value: new DateTime(2021, 10, 21, 13, 56, 35, 272, DateTimeKind.Local).AddTicks(7097));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "LastModified",
                value: new DateTime(2021, 10, 21, 13, 56, 35, 272, DateTimeKind.Local).AddTicks(7100));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "LastModified",
                value: new DateTime(2021, 10, 21, 13, 56, 35, 272, DateTimeKind.Local).AddTicks(7103));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageSource", "ImageSource2", "ItemType", "LastModified", "Path" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", "../images/Products/NYKANT_boejle_hvidolie_01.png", "Tøjstativ", new DateTime(2021, 10, 15, 12, 41, 7, 963, DateTimeKind.Local).AddTicks(1350), "wwwroot/images/gyngestol.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "ImageSource", "ImageSource2", "ItemType", "LastModified", "Name", "Oil", "Path", "Size", "Title", "TypeOfWood", "WeightInKg" },
                values: new object[] { 2, "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "../images/gyngestol.jpg", "stol", new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4810), "Grøntsags Skærebræt", "farvet-overflade", "wwwroot/images/gyngestol.jpg", "10mm", "Grøntsags Skærebræt", "eg", 13.4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "ImageSource", "ImageSource2", "ItemType", "LastModified", "Name", "Path", "Size", "Title", "TypeOfWood", "WeightInKg" },
                values: new object[] { 3, "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "../images/gyngestol.jpg", "bænk", new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4903), "Grøntsags Skærebræt", "wwwroot/images/gyngestol.jpg", "20mm", "Grøntsags Skærebræt", "fyr", 17.399999999999999 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Description", "ImageSource", "ImageSource2", "ItemType", "LastModified", "Name", "Oil", "Path", "Title", "TypeOfWood", "WeightInKg" },
                values: new object[] { 4, "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "../images/gyngestol.jpg", "skærebræt", new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4910), "Grøntsags Skærebræt", "farvet-overflade", "wwwroot/images/gyngestol.jpg", "Grøntsags Skærebræt", "eg", 7.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Description", "ImageSource", "ImageSource2", "ItemType", "LastModified", "Name", "Path", "Size", "Title", "TypeOfWood", "WeightInKg" },
                values: new object[] { 5, "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "../images/gyngestol.jpg", "bænk", new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4913), "Grøntsags Skærebræt", "wwwroot/images/gyngestol.jpg", "10mm", "Grøntsags Skærebræt", "valnød", 8.8000000000000007 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "ImageSource", "ImageSource2", "ItemType", "LastModified", "Name", "Oil", "Path", "Size", "Title", "TypeOfWood", "WeightInKg" },
                values: new object[] { "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "../images/gyngestol.jpg", "skærebræt", new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4917), "Grøntsags Skærebræt", "farvet-overflade", "wwwroot/images/gyngestol.jpg", "20mm", "Grøntsags Skærebræt", "fyr", 13.4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "Description", "ImageSource", "ImageSource2", "ItemType", "LastModified", "Name", "Path", "Title", "TypeOfWood", "WeightInKg" },
                values: new object[] { 3, "a test object", "../images/Finback-Chairs1-1280x853-c-default.jpg", "../images/gyngestol.jpg", "stol", new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4920), "Grøntsags Skærebræt", "wwwroot/images/gyngestol.jpg", "Grøntsags Skærebræt", "valnød", 13.4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastModified",
                value: new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4923));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastModified",
                value: new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4927));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastModified",
                value: new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4931));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastModified",
                value: new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4934));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastModified",
                value: new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4938));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "LastModified",
                value: new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4941));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "LastModified",
                value: new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4944));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "LastModified",
                value: new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4948));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastModified",
                value: new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4951));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "LastModified",
                value: new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4954));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "LastModified",
                value: new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4957));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "LastModified",
                value: new DateTime(2021, 10, 15, 12, 41, 7, 965, DateTimeKind.Local).AddTicks(4960));
        }
    }
}
