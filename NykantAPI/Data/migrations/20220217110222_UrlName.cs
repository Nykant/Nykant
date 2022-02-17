using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.data.migrations
{
    public partial class UrlName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlName",
                table: "Products",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "UrlName",
                value: "Bøjle-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "UrlName",
                value: "Bøjle-Egetræ-Sortolie");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "UrlName",
                value: "Bøjle-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "UrlName",
                value: "Hylde-Egetræ-Hvidolie-400mm");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "UrlName",
                value: "Hylde-Egetræ-Sortolie-400mm");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "UrlName",
                value: "Hylde-Egetræ-Naturolie-400mm");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "UrlName",
                value: "Hylde-Egetræ-Hvidolie-600mm");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "UrlName",
                value: "Hylde-Egetræ-Sortolie-600mm");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "UrlName",
                value: "Hylde-Egetræ-Naturolie-600mm");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "UrlName",
                value: "Hylde-Egetræ-Hvidolie-800mm");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "UrlName",
                value: "Hylde-Egetræ-Sortolie-800mm");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "UrlName",
                value: "Hylde-Egetræ-Naturolie-800mm");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "UrlName",
                value: "Hylde-Egetræ-Hvidolie-1000mm");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "UrlName",
                value: "Hylde-Egetræ-Sortolie-1000mm");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "UrlName",
                value: "Hylde-Egetræ-Naturolie-1000mm");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "UrlName",
                value: "Bord-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "UrlName",
                value: "Bord-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "UrlName",
                value: "Bænk-Egetræ-Naturolie-1150mm");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "UrlName",
                value: "Bænk-Egetræ-Hvidolie-1150mm");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "UrlName",
                value: "Bænk-Egetræ-Sortolie-1150mm");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "UrlName",
                value: "Bænk-Egetræ-Naturolie-1700mm");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "UrlName",
                value: "Bænk-Egetræ-Hvidolie-1700mm");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "UrlName",
                value: "Bænk-Egetræ-Sortolie-1700mm");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "UrlName",
                value: "Opbevaringsbænk-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "UrlName",
                value: "Opbevaringsbænk-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "UrlName",
                value: "Opbevaringsbænk-Egetræ-Sortolie");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "UrlName",
                value: "Tøjstativ-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "UrlName",
                value: "Tøjstativ-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "UrlName",
                value: "Tøjstativ-Egetræ-Sortolie");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "UrlName",
                value: "Ophængt-Tøjstativ-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "UrlName",
                value: "Ophængt-Tøjstativ-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "UrlName",
                value: "Ophængt-Tøjstativ-Egetræ-Sortolie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlName",
                table: "Products");
        }
    }
}
