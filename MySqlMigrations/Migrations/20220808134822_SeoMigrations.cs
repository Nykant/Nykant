using Microsoft.EntityFrameworkCore.Migrations;

namespace MySqlMigrations.Migrations
{
    public partial class SeoMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaTitle",
                table: "Products",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductSourceUrlName",
                value: "Tøjbøjle-Massivt-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductSourceUrlName",
                value: "Tøjbøjle-Massivt-Egetræ-Sortolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProductSourceUrlName",
                value: "Tøjbøjle-Massivt-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "ProductSourceUrlName",
                value: "Tøjbøjle-Massivt-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "ProductSourceUrlName",
                value: "Tøjbøjle-Massivt-Egetræ-Sortolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "ProductSourceUrlName",
                value: "Tøjbøjle-Massivt-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "ProductSourceUrlName",
                value: "Tøjbøjle-Massivt-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "ProductSourceUrlName",
                value: "Tøjbøjle-Massivt-Egetræ-Sortolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 9,
                column: "ProductSourceUrlName",
                value: "Tøjbøjle-Massivt-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 10,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Hvidolie-40cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 11,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Sortolie-40cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 12,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Naturolie-40cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 13,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Hvidolie-40cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 14,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Sortolie-40cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 15,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Naturolie-40cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 16,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Hvidolie-40cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 17,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Sortolie-40cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 18,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Naturolie-40cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 19,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Hvidolie-60cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 20,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Sortolie-60cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 21,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Naturolie-60cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 22,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Hvidolie-60cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 23,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Sortolie-60cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 24,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Naturolie-60cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 25,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Hvidolie-60cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 26,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Sortolie-60cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 27,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Naturolie-60cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 28,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Hvidolie-80cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 29,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Sortolie-80cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 30,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Naturolie-80cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 31,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Hvidolie-80cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 32,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Sortolie-80cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 33,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Naturolie-80cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 34,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Hvidolie-80cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 35,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Sortolie-80cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 36,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Naturolie-80cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 37,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Hvidolie-100cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 38,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Sortolie-100cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 39,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Naturolie-100cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 40,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Hvidolie-100cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 41,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Sortolie-100cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 42,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Naturolie-100cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 43,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Hvidolie-100cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 44,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Sortolie-100cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 45,
                column: "ProductSourceUrlName",
                value: "Væghylde-Massivt-Egetræ-Naturolie-100cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 46,
                column: "ProductSourceUrlName",
                value: "Bord-Massivt-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 47,
                column: "ProductSourceUrlName",
                value: "Bord-Massivt-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 48,
                column: "ProductSourceUrlName",
                value: "Bord-Massivt-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 49,
                column: "ProductSourceUrlName",
                value: "Bord-Massivt-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 50,
                column: "ProductSourceUrlName",
                value: "Bænk-Massivt-Egetræ-Naturolie-115cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 51,
                column: "ProductSourceUrlName",
                value: "Bænk-Massivt-Egetræ-Hvidolie-115cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 52,
                column: "ProductSourceUrlName",
                value: "Bænk-Massivt-Egetræ-Sortolie-115cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 53,
                column: "ProductSourceUrlName",
                value: "Bænk-Massivt-Egetræ-Naturolie-115cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 54,
                column: "ProductSourceUrlName",
                value: "Bænk-Massivt-Egetræ-Hvidolie-115cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 55,
                column: "ProductSourceUrlName",
                value: "Bænk-Massivt-Egetræ-Sortolie-115cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 56,
                column: "ProductSourceUrlName",
                value: "Bænk-Massivt-Egetræ-Naturolie-115cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 57,
                column: "ProductSourceUrlName",
                value: "Bænk-Massivt-Egetræ-Hvidolie-115cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 58,
                column: "ProductSourceUrlName",
                value: "Bænk-Massivt-Egetræ-Sortolie-115cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 59,
                column: "ProductSourceUrlName",
                value: "Bænk-Massivt-Egetræ-Naturolie-170cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 60,
                column: "ProductSourceUrlName",
                value: "Bænk-Massivt-Egetræ-Hvidolie-170cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 61,
                column: "ProductSourceUrlName",
                value: "Bænk-Massivt-Egetræ-Sortolie-170cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 62,
                column: "ProductSourceUrlName",
                value: "Bænk-Massivt-Egetræ-Naturolie-170cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 63,
                column: "ProductSourceUrlName",
                value: "Bænk-Massivt-Egetræ-Hvidolie-170cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 64,
                column: "ProductSourceUrlName",
                value: "Bænk-Massivt-Egetræ-Sortolie-170cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 65,
                column: "ProductSourceUrlName",
                value: "Bænk-Massivt-Egetræ-Naturolie-170cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 66,
                column: "ProductSourceUrlName",
                value: "Bænk-Massivt-Egetræ-Hvidolie-170cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 67,
                column: "ProductSourceUrlName",
                value: "Bænk-Massivt-Egetræ-Sortolie-170cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 68,
                column: "ProductSourceUrlName",
                value: "Opbevaringsbænk-Massivt-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 69,
                column: "ProductSourceUrlName",
                value: "Opbevaringsbænk-Massivt-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 70,
                column: "ProductSourceUrlName",
                value: "Opbevaringsbænk-Massivt-Egetræ-Sortolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 71,
                column: "ProductSourceUrlName",
                value: "Opbevaringsbænk-Massivt-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 72,
                column: "ProductSourceUrlName",
                value: "Opbevaringsbænk-Massivt-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 73,
                column: "ProductSourceUrlName",
                value: "Opbevaringsbænk-Massivt-Egetræ-Sortolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 74,
                column: "ProductSourceUrlName",
                value: "Opbevaringsbænk-Massivt-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 75,
                column: "ProductSourceUrlName",
                value: "Opbevaringsbænk-Massivt-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 76,
                column: "ProductSourceUrlName",
                value: "Opbevaringsbænk-Massivt-Egetræ-Sortolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 77,
                column: "ProductSourceUrlName",
                value: "Tøjstativ-Massivt-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 78,
                column: "ProductSourceUrlName",
                value: "Tøjstativ-Massivt-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 79,
                column: "ProductSourceUrlName",
                value: "Tøjstativ-Massivt-Egetræ-Sortolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 80,
                column: "ProductSourceUrlName",
                value: "Tøjstativ-Massivt-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 81,
                column: "ProductSourceUrlName",
                value: "Tøjstativ-Massivt-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 82,
                column: "ProductSourceUrlName",
                value: "Tøjstativ-Massivt-Egetræ-Sortolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 83,
                column: "ProductSourceUrlName",
                value: "Tøjstativ-Massivt-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 84,
                column: "ProductSourceUrlName",
                value: "Tøjstativ-Massivt-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 85,
                column: "ProductSourceUrlName",
                value: "Tøjstativ-Massivt-Egetræ-Sortolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 86,
                column: "ProductSourceUrlName",
                value: "Væghængt-Tøjstativ-Massivt-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 87,
                column: "ProductSourceUrlName",
                value: "Væghængt-Tøjstativ-Massivt-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 88,
                column: "ProductSourceUrlName",
                value: "Væghængt-Tøjstativ-Massivt-Egetræ-Sortolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 89,
                column: "ProductSourceUrlName",
                value: "Væghængt-Tøjstativ-Massivt-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 90,
                column: "ProductSourceUrlName",
                value: "Væghængt-Tøjstativ-Massivt-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 91,
                column: "ProductSourceUrlName",
                value: "Væghængt-Tøjstativ-Massivt-Egetræ-Sortolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 92,
                column: "ProductSourceUrlName",
                value: "Væghængt-Tøjstativ-Massivt-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 93,
                column: "ProductSourceUrlName",
                value: "Væghængt-Tøjstativ-Massivt-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 94,
                column: "ProductSourceUrlName",
                value: "Væghængt-Tøjstativ-Massivt-Egetræ-Sortolie");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductReferenceUrlName",
                value: "Bænk-Massivt-Egetræ-Naturolie-115cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductReferenceUrlName",
                value: "Bænk-Massivt-Egetræ-Naturolie-170cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProductReferenceUrlName",
                value: "Bænk-Massivt-Egetræ-Hvidolie-115cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 4,
                column: "ProductReferenceUrlName",
                value: "Bænk-Massivt-Egetræ-Hvidolie-170cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 5,
                column: "ProductReferenceUrlName",
                value: "Bænk-Massivt-Egetræ-Hvidolie-170cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 6,
                column: "ProductReferenceUrlName",
                value: "Bænk-Massivt-Egetræ-Sortolie-170cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 7,
                column: "ProductReferenceUrlName",
                value: "Bænk-Massivt-Egetræ-Naturolie-115cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 8,
                column: "ProductReferenceUrlName",
                value: "Bænk-Massivt-Egetræ-Naturolie-170cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 9,
                column: "ProductReferenceUrlName",
                value: "Bænk-Massivt-Egetræ-Hvidolie-115cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 10,
                column: "ProductReferenceUrlName",
                value: "Bænk-Massivt-Egetræ-Hvidolie-170cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 11,
                column: "ProductReferenceUrlName",
                value: "Bænk-Massivt-Egetræ-Sortolie-115cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 12,
                column: "ProductReferenceUrlName",
                value: "Bænk-Massivt-Egetræ-Sortolie-170cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 13,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Hvidolie-40cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 14,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Hvidolie-60cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 15,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Hvidolie-80cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 16,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Hvidolie-100cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 17,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Sortolie-40cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 18,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Sortolie-60cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 19,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Sortolie-80cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 20,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Sortolie-100cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 21,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Naturolie-40cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 22,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Naturolie-60cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 23,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Naturolie-80cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 24,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Naturolie-100cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 25,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Hvidolie-40cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 26,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Hvidolie-60cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 27,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Hvidolie-80cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 28,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Hvidolie-100cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 29,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Sortolie-40cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 30,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Sortolie-60cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 31,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Sortolie-80cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 32,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Sortolie-100cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 33,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Naturolie-40cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 34,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Naturolie-60cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 35,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Naturolie-80cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 36,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Naturolie-100cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 37,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Hvidolie-40cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 38,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Hvidolie-60cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 39,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Hvidolie-80cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 40,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Hvidolie-100cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 41,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Sortolie-40cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 42,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Sortolie-60cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 43,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Sortolie-80cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 44,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Sortolie-100cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 45,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Naturolie-40cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 46,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Naturolie-60cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 47,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Naturolie-80cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 48,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Naturolie-100cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 49,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Hvidolie-40cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 50,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Hvidolie-60cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 51,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Hvidolie-80cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 52,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Hvidolie-100cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 53,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Sortolie-40cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 54,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Sortolie-60cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 55,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Sortolie-80cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 56,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Sortolie-100cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 57,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Naturolie-40cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 58,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Naturolie-60cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 59,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Naturolie-80cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 60,
                column: "ProductReferenceUrlName",
                value: "Væghylde-Massivt-Egetræ-Naturolie-100cm");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Tøjbøjle i massivt egetræ behandlet med naturolie, er lavet med kvalitet og funktionalitet i fokus, kan købes i 3 forskellige farver. købes i pakke af 3. Gratis og hurtig levering. Se mere her...", "Tøjbøjle | Kvalitets Tøjbøjle I Massivt Egetræ | Naturolie | Køb Her", "Tøjbøjle I Massivt Egetræ", "Tøjbøjle-Massivt-Egetræ-Naturolie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Tøjbøjle i massivt egetræ behandlet med sortolie, er lavet med kvalitet, funktionalitet og kærlighed i fokus, kan købes i 3 forskellige farver. købes i pakke af 3. Gratis og hurtig levering. Se mere her...", "Tøjbøjle | Kvalitets Tøjbøjle I Massivt Egetræ | Sortolie | Køb Her", "Tøjbøjle I Massivt Egetræ", "Tøjbøjle-Massivt-Egetræ-Sortolie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Tøjbøjle i massivt egetræ behandlet med hvidolie, er lavet med kvalitet, funktionalitet og kærlighed i fokus, kan købes i 3 forskellige farver. købes i pakke af 3. Gratis og hurtig levering. Se mere her...", "Tøjbøjle | Kvalitets Tøjbøjle I Massivt Egetræ | Hvidolie | Køb Her", "Tøjbøjle i massivt egetræ", "Tøjbøjle-Massivt-Egetræ-Hvidolie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Hylde i massivt egetræ som monteres på væggen, er lavet med kvalitet, funktionalitet og minimalisme i fokus. 40cm lang. kan købes i 3 forskellige farver og 4 forskellige længder. Gratis og hurtig levering. Se mere her...", "Træhylde | Kvalitets VægHylde I Massivt Egetræ | Hvidolie | Køb Her", "Væghylde I Massivt Egetræ", "Væghylde-Massivt-Egetræ-Hvidolie-40cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Hylde i massivt egetræ som monteres på væggen, er lavet med kvalitet, funktionalitet og minimalisme i fokus. 40cm lang kan købes i 3 forskellige farver og 4 forskellige længder. Gratis og hurtig levering. Se mere her...", "Træhylde | Kvalitets VægHylde I Massivt Egetræ | Sortolie | Køb Her", "Væghylde I Massivt Egetræ", "Væghylde-Massivt-Egetræ-Sortolie-40cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Hylde i massivt egetræ som monteres på væggen, er lavet med kvalitet, funktionalitet og minimalisme i fokus. 40cm lang kan købes i 3 forskellige farver og 4 forskellige længder. Gratis og hurtig levering. Se mere her...", "Træhylde | Kvalitets VægHylde I Massivt Egetræ | Naturolie | Køb Her", "Væghylde I Massivt Egetræ", "Væghylde-Massivt-Egetræ-Naturolie-40cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Hylde i massivt egetræ som monteres på væggen, er lavet med kvalitet, funktionalitet og minimalisme i fokus. 60cm lang kan købes i 3 forskellige farver og 4 forskellige længder. Gratis og hurtig levering. Se mere her...", "Træhylde | Kvalitets VægHylde I Massivt Egetræ | Hvidolie | Køb Her", "Væghylde I Massivt Egetræ", "Væghylde-Massivt-Egetræ-Hvidolie-60cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Hylde i massivt egetræ som monteres på væggen, er lavet med kvalitet, funktionalitet og minimalisme i fokus. 60cm lang kan købes i 3 forskellige farver og 4 forskellige længder. Gratis og hurtig levering. Se mere her...", "Træhylde | Kvalitets VægHylde I Massivt Egetræ | Sortolie | Køb Her", "Væghylde I Massivt Egetræ", "Væghylde-Massivt-Egetræ-Sortolie-60cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Hylde i massivt egetræ som monteres på væggen, er lavet med kvalitet, funktionalitet og minimalisme i fokus. 60cm lang kan købes i 3 forskellige farver og 4 forskellige længder. Gratis og hurtig levering. Se mere her...", "Træhylde | Kvalitets VægHylde I Massivt Egetræ | Naturolie | Køb Her", "Væghylde I Massivt Egetræ", "Væghylde-Massivt-Egetræ-Naturolie-60cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Hylde i massivt egetræ som monteres på væggen, er lavet med kvalitet, funktionalitet og minimalisme i fokus. 80cm lang kan købes i 3 forskellige farver og 4 forskellige længder. Gratis og hurtig levering. Se mere her...", "Træhylde | Kvalitets VægHylde I Massivt Egetræ | Hvidolie | Køb Her", "Væghylde I Massivt Egetræ", "Væghylde-Massivt-Egetræ-Hvidolie-80cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Hylde i massivt egetræ som monteres på væggen, er lavet med kvalitet, funktionalitet og minimalisme i fokus. 80cm lang kan købes i 3 forskellige farver og 4 forskellige længder. Gratis og hurtig levering. Se mere her...", "Træhylde | Kvalitets VægHylde I Massivt Egetræ | Sortolie | Køb Her", "Væghylde I Massivt Egetræ", "Væghylde-Massivt-Egetræ-Sortolie-80cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Hylde i massivt egetræ som monteres på væggen, er lavet med kvalitet, funktionalitet og minimalisme i fokus. 80cm lang kan købes i 3 forskellige farver og 4 forskellige længder. Gratis og hurtig levering. Se mere her...", "Træhylde | Kvalitets VægHylde I Massivt Egetræ | Naturolie | Køb Her", "Væghylde I Massivt Egetræ", "Væghylde-Massivt-Egetræ-Naturolie-80cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Hylde i massivt egetræ som monteres på væggen, er lavet med kvalitet, funktionalitet og minimalisme i fokus. 100cm lang kan købes i 3 forskellige farver og 4 forskellige længder. Gratis og hurtig levering. Se mere her...", "Træhylde | Kvalitets VægHylde I Massivt Egetræ | Hvidolie | Køb Her", "Væghylde I Massivt Egetræ", "Væghylde-Massivt-Egetræ-Hvidolie-100cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Hylde i massivt egetræ som monteres på væggen, er lavet med kvalitet, funktionalitet og minimalisme i fokus. 100cm lang kan købes i 3 forskellige farver og 4 forskellige længder. Gratis og hurtig levering. Se mere her...", "Træhylde | Kvalitets VægHylde I Massivt Egetræ | Sortolie | Køb Her", "Væghylde I Massivt Egetræ", "Væghylde-Massivt-Egetræ-Sortolie-100cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Hylde i massivt egetræ som monteres på væggen, er lavet med kvalitet, funktionalitet og minimalisme i fokus. 100cm lang kan købes i 3 forskellige farver og 4 forskellige længder. Gratis og hurtig levering. Se mere her...", "Træhylde | Kvalitets VægHylde I Massivt Egetræ | Naturolie | Køb Her", "Væghylde I Massivt Egetræ", "Væghylde-Massivt-Egetræ-Naturolie-100cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Bord i massivt egetræ, er i dansk design med minimalisme og høj kvalitet. Med 110cm langt og 70cm bredt passer det perfekt til et lille kontor. kan købes i 2 forskellige farver Gratis og hurtig levering. Se mere her...", "Egetræsbord | Massivt Egetræsbord I Dansk Design | Naturolie | Køb Her", "Egetræsbord I Massivt Egetræ", "Bord-Massivt-Egetræ-Naturolie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Bord i massivt egetræ, er i dansk design med minimalisme og høj kvalitet. Med 110cm langt og 70cm bredt passer det perfekt til et lille kontor. kan købes i 2 forskellige farver Gratis og hurtig levering. Se mere her...", "Egetræsbord | Massivt Egetræsbord I Dansk Design | Hvidolie | Køb Her", "Egetræsbord I Massivt Egetræ", "Bord-Massivt-Egetræ-Hvidolie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Bænk i massivt egetræ er lavet med høj kvalitet og minimalisme i fokus. Denne smukke egetræsbænk er 115 cm lang. kan købes i 3 forskellige farver og 2 forskellige længder. Gratis og hurtig levering. Se mere her...", "Egetræsbænk | Minimalistisk Bænk I Massivt Egetræ | Naturolie | Køb Her", "Egetræsbænk I Massivt Egetræ", "Bænk-Massivt-Egetræ-Naturolie-115cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Bænk i massivt egetræ er lavet med høj kvalitet og minimalisme i fokus. Denne smukke egetræsbænk er 115 cm lang. kan købes i 3 forskellige farver og 2 forskellige længder. Gratis og hurtig levering. Se mere her...", "Egetræsbænk | Minimalistisk Bænk I Massivt Egetræ | Hvidolie | Køb Her", "Egetræsbænk I Massivt Egetræ", "Bænk-Massivt-Egetræ-Hvidolie-115cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Bænk i massivt egetræ er lavet med høj kvalitet og minimalisme i fokus. Denne smukke egetræsbænk er 115 cm lang. kan købes i 3 forskellige farver og 2 forskellige længder. Gratis og hurtig levering. Se mere her...", "Egetræsbænk | Minimalistisk Bænk I Massivt Egetræ | Sortolie | Køb Her", "Egetræsbænk I Massivt Egetræ", "Bænk-Massivt-Egetræ-Sortolie-115cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Bænk i massivt egetræ er lavet med høj kvalitet og minimalisme i fokus. Denne smukke egetræsbænk er 170 cm lang. kan købes i 3 forskellige farver og 2 forskellige længder. Gratis og hurtig levering. Se mere her...", "Egetræsbænk | Minimalistisk Bænk I Massivt Egetræ | Naturolie | Køb Her", "Egetræsbænk I Massivt Egetræ", "Bænk-Massivt-Egetræ-Naturolie-170cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Bænk i massivt egetræ er lavet med høj kvalitet og minimalisme i fokus. Denne smukke egetræsbænk er 170 cm lang. kan købes i 3 forskellige farver og 2 forskellige længder. Gratis og hurtig levering. Se mere her...", "Egetræsbænk | Minimalistisk Bænk I Massivt Egetræ | Hvidolie | Køb Her", "Egetræsbænk I Massivt Egetræ", "Bænk-Massivt-Egetræ-Hvidolie-170cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Bænk i massivt egetræ er lavet med høj kvalitet og minimalisme i fokus. Denne smukke egetræsbænk er 170 cm lang. kan købes i 3 forskellige farver og 2 forskellige længder. Gratis og hurtig levering. Se mere her...", "Egetræsbænk | Minimalistisk Bænk I Massivt Egetræ | Sortolie | Køb Her", "Egetræsbænk I Massivt Egetræ", "Bænk-Massivt-Egetræ-Sortolie-170cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Opbevaringsbænk i massivt egetræ, er lavet med dansk design og kvalitet i fokus. Opbevaringsbænken har masser af plads til tæpper eller tøj. Kan købes i 3 forskellige farver. Gratis og hurtig levering. Se mere her...", "Opbevaringsbænk | Kvalitets Opbevaringsbænk I Massivt Egetræ | Naturolie | Køb Her", "Opbevaringsbænk I Massivt Egetræ", "Opbevaringsbænk-Massivt-Egetræ-Naturolie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Opbevaringsbænk i massivt egetræ, er lavet med dansk design og kvalitet i fokus. Opbevaringsbænken har masser af plads til tæpper eller tøj. Kan købes i 3 forskellige farver. Gratis og hurtig levering. Se mere her...", "Opbevaringsbænk | Kvalitets Opbevaringsbænk I Massivt Egetræ | Hvidolie | Køb Her", "Opbevaringsbænk I Massivt Egetræ", "Opbevaringsbænk-Massivt-Egetræ-Hvidolie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Opbevaringsbænk i massivt egetræ, er lavet med dansk design og kvalitet i fokus. Opbevaringsbænken har masser af plads til tæpper eller tøj. Kan købes i 3 forskellige farver. Gratis og hurtig levering. Se mere her...", "Opbevaringsbænk | Kvalitets Opbevaringsbænk I Massivt Egetræ | Sortolie | Køb Her", "Opbevaringsbænk I Massivt Egetræ", "Opbevaringsbænk-Massivt-Egetræ-Sortolie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Tøjstativ i massivt egetræ består kun af træ og samles udelukkende med trækiler. Det er et kvalitet i minimalistisk dansk design. Kan købes i 3 forskellige farver. Gratis og hurtig levering. Se mere her...", "Tøjstativ | Kvalitets Tøjstativ I Massivt Egetræ | Naturolie | Køb Her", "Tøjstativ I Massivt Egetræ", "Tøjstativ-Massivt-Egetræ-Naturolie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Tøjstativ i massivt egetræ består kun af træ og samles udelukkende med trækiler. Det er et kvalitet i minimalistisk dansk design. Kan købes i 3 forskellige farver. Gratis og hurtig levering. Se mere her...", "Tøjstativ | Kvalitets Tøjstativ I Massivt Egetræ | Hvidolie | Køb Her", "Tøjstativ I Massivt Egetræ", "Tøjstativ-Massivt-Egetræ-Hvidolie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Tøjstativ i massivt egetræ består kun af træ og samles udelukkende med trækiler. Det er et kvalitet i minimalistisk dansk design. Kan købes i 3 forskellige farver. Gratis og hurtig levering. Se mere her...", "Tøjstativ | Kvalitets Tøjstativ I Massivt Egetræ | Sortolie | Køb Her", "Tøjstativ I Massivt Egetræ", "Tøjstativ-Massivt-Egetræ-Sortolie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Væghængte Tøjstativ i massivt egetræ er designet kvalitet og minimalisme i fokus. Kan købes i 3 forskellige farver. Gratis og hurtig levering. Se mere her...", "Væghængt Tøjstativ | Minimalistisk Væghængt Tøjstativ I Massivt Egetræ | Naturolie | Køb Her", "Væghængt Tøjstativ I Massivt Egetræ", "Væghængt-Tøjstativ-Massivt-Egetræ-Naturolie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Væghængte Tøjstativ i massivt egetræ er designet kvalitet og minimalisme i fokus. Kan købes i 3 forskellige farver. Gratis og hurtig levering. Se mere her...", "Væghængt Tøjstativ | Minimalistisk Væghængt Tøjstativ I Massivt Egetræ | Hvidolie | Køb Her", "Væghængt Tøjstativ I Massivt Egetræ", "Væghængt-Tøjstativ-Massivt-Egetræ-Hvidolie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "MetaDescription", "MetaTitle", "Title", "UrlName" },
                values: new object[] { "Nykants Væghængte Tøjstativ i massivt egetræ er designet kvalitet og minimalisme i fokus. Kan købes i 3 forskellige farver. Gratis og hurtig levering. Se mere her...", "Væghængt Tøjstativ | Minimalistisk Væghængt Tøjstativ I Massivt Egetræ | Sortolie | Køb Her", "Væghængt Tøjstativ I Massivt Egetræ", "Væghængt-Tøjstativ-Massivt-Egetræ-Sortolie" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetaDescription",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MetaTitle",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductSourceUrlName",
                value: "Bøjle-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductSourceUrlName",
                value: "Bøjle-Egetræ-Sortolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProductSourceUrlName",
                value: "Bøjle-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "ProductSourceUrlName",
                value: "Bøjle-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "ProductSourceUrlName",
                value: "Bøjle-Egetræ-Sortolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "ProductSourceUrlName",
                value: "Bøjle-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "ProductSourceUrlName",
                value: "Bøjle-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "ProductSourceUrlName",
                value: "Bøjle-Egetræ-Sortolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 9,
                column: "ProductSourceUrlName",
                value: "Bøjle-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 10,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Hvidolie-40cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 11,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Sortolie-40cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 12,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Naturolie-40cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 13,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Hvidolie-40cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 14,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Sortolie-40cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 15,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Naturolie-40cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 16,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Hvidolie-40cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 17,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Sortolie-40cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 18,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Naturolie-40cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 19,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Hvidolie-60cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 20,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Sortolie-60cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 21,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Naturolie-60cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 22,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Hvidolie-60cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 23,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Sortolie-60cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 24,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Naturolie-60cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 25,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Hvidolie-60cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 26,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Sortolie-60cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 27,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Naturolie-60cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 28,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Hvidolie-80cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 29,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Sortolie-80cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 30,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Naturolie-80cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 31,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Hvidolie-80cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 32,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Sortolie-80cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 33,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Naturolie-80cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 34,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Hvidolie-80cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 35,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Sortolie-80cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 36,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Naturolie-80cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 37,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Hvidolie-100cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 38,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Sortolie-100cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 39,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Naturolie-100cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 40,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Hvidolie-100cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 41,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Sortolie-100cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 42,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Naturolie-100cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 43,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Hvidolie-100cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 44,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Sortolie-100cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 45,
                column: "ProductSourceUrlName",
                value: "Hylde-Egetræ-Naturolie-100cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 46,
                column: "ProductSourceUrlName",
                value: "Bord-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 47,
                column: "ProductSourceUrlName",
                value: "Bord-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 48,
                column: "ProductSourceUrlName",
                value: "Bord-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 49,
                column: "ProductSourceUrlName",
                value: "Bord-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 50,
                column: "ProductSourceUrlName",
                value: "Bænk-Egetræ-Naturolie-115cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 51,
                column: "ProductSourceUrlName",
                value: "Bænk-Egetræ-Hvidolie-115cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 52,
                column: "ProductSourceUrlName",
                value: "Bænk-Egetræ-Sortolie-115cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 53,
                column: "ProductSourceUrlName",
                value: "Bænk-Egetræ-Naturolie-115cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 54,
                column: "ProductSourceUrlName",
                value: "Bænk-Egetræ-Hvidolie-115cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 55,
                column: "ProductSourceUrlName",
                value: "Bænk-Egetræ-Sortolie-115cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 56,
                column: "ProductSourceUrlName",
                value: "Bænk-Egetræ-Naturolie-115cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 57,
                column: "ProductSourceUrlName",
                value: "Bænk-Egetræ-Hvidolie-115cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 58,
                column: "ProductSourceUrlName",
                value: "Bænk-Egetræ-Sortolie-115cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 59,
                column: "ProductSourceUrlName",
                value: "Bænk-Egetræ-Naturolie-170cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 60,
                column: "ProductSourceUrlName",
                value: "Bænk-Egetræ-Hvidolie-170cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 61,
                column: "ProductSourceUrlName",
                value: "Bænk-Egetræ-Sortolie-170cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 62,
                column: "ProductSourceUrlName",
                value: "Bænk-Egetræ-Naturolie-170cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 63,
                column: "ProductSourceUrlName",
                value: "Bænk-Egetræ-Hvidolie-170cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 64,
                column: "ProductSourceUrlName",
                value: "Bænk-Egetræ-Sortolie-170cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 65,
                column: "ProductSourceUrlName",
                value: "Bænk-Egetræ-Naturolie-170cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 66,
                column: "ProductSourceUrlName",
                value: "Bænk-Egetræ-Hvidolie-170cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 67,
                column: "ProductSourceUrlName",
                value: "Bænk-Egetræ-Sortolie-170cm");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 68,
                column: "ProductSourceUrlName",
                value: "Opbevaringsbænk-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 69,
                column: "ProductSourceUrlName",
                value: "Opbevaringsbænk-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 70,
                column: "ProductSourceUrlName",
                value: "Opbevaringsbænk-Egetræ-Sortolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 71,
                column: "ProductSourceUrlName",
                value: "Opbevaringsbænk-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 72,
                column: "ProductSourceUrlName",
                value: "Opbevaringsbænk-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 73,
                column: "ProductSourceUrlName",
                value: "Opbevaringsbænk-Egetræ-Sortolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 74,
                column: "ProductSourceUrlName",
                value: "Opbevaringsbænk-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 75,
                column: "ProductSourceUrlName",
                value: "Opbevaringsbænk-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 76,
                column: "ProductSourceUrlName",
                value: "Opbevaringsbænk-Egetræ-Sortolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 77,
                column: "ProductSourceUrlName",
                value: "Tøjstativ-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 78,
                column: "ProductSourceUrlName",
                value: "Tøjstativ-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 79,
                column: "ProductSourceUrlName",
                value: "Tøjstativ-Egetræ-Sortolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 80,
                column: "ProductSourceUrlName",
                value: "Tøjstativ-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 81,
                column: "ProductSourceUrlName",
                value: "Tøjstativ-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 82,
                column: "ProductSourceUrlName",
                value: "Tøjstativ-Egetræ-Sortolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 83,
                column: "ProductSourceUrlName",
                value: "Tøjstativ-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 84,
                column: "ProductSourceUrlName",
                value: "Tøjstativ-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 85,
                column: "ProductSourceUrlName",
                value: "Tøjstativ-Egetræ-Sortolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 86,
                column: "ProductSourceUrlName",
                value: "Ophængt-Tøjstativ-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 87,
                column: "ProductSourceUrlName",
                value: "Ophængt-Tøjstativ-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 88,
                column: "ProductSourceUrlName",
                value: "Ophængt-Tøjstativ-Egetræ-Sortolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 89,
                column: "ProductSourceUrlName",
                value: "Ophængt-Tøjstativ-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 90,
                column: "ProductSourceUrlName",
                value: "Ophængt-Tøjstativ-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 91,
                column: "ProductSourceUrlName",
                value: "Ophængt-Tøjstativ-Egetræ-Sortolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 92,
                column: "ProductSourceUrlName",
                value: "Ophængt-Tøjstativ-Egetræ-Naturolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 93,
                column: "ProductSourceUrlName",
                value: "Ophængt-Tøjstativ-Egetræ-Hvidolie");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 94,
                column: "ProductSourceUrlName",
                value: "Ophængt-Tøjstativ-Egetræ-Sortolie");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductReferenceUrlName",
                value: "Bænk-Egetræ-Naturolie-115cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductReferenceUrlName",
                value: "Bænk-Egetræ-Naturolie-170cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProductReferenceUrlName",
                value: "Bænk-Egetræ-Hvidolie-115cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 4,
                column: "ProductReferenceUrlName",
                value: "Bænk-Egetræ-Hvidolie-170cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 5,
                column: "ProductReferenceUrlName",
                value: "Bænk-Egetræ-Sortolie-115cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 6,
                column: "ProductReferenceUrlName",
                value: "Bænk-Egetræ-Sortolie-170cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 7,
                column: "ProductReferenceUrlName",
                value: "Bænk-Egetræ-Naturolie-115cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 8,
                column: "ProductReferenceUrlName",
                value: "Bænk-Egetræ-Naturolie-170cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 9,
                column: "ProductReferenceUrlName",
                value: "Bænk-Egetræ-Hvidolie-115cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 10,
                column: "ProductReferenceUrlName",
                value: "Bænk-Egetræ-Hvidolie-170cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 11,
                column: "ProductReferenceUrlName",
                value: "Bænk-Egetræ-Sortolie-115cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 12,
                column: "ProductReferenceUrlName",
                value: "Bænk-Egetræ-Sortolie-170cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 13,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Hvidolie-40cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 14,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Hvidolie-60cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 15,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Hvidolie-80cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 16,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Hvidolie-100cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 17,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Sortolie-40cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 18,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Sortolie-60cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 19,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Sortolie-80cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 20,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Sortolie-100cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 21,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Naturolie-40cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 22,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Naturolie-60cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 23,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Naturolie-80cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 24,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Naturolie-100cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 25,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Hvidolie-40cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 26,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Hvidolie-60cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 27,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Hvidolie-80cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 28,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Hvidolie-100cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 29,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Sortolie-40cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 30,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Sortolie-60cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 31,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Sortolie-80cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 32,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Sortolie-100cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 33,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Naturolie-40cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 34,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Naturolie-60cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 35,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Naturolie-80cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 36,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Naturolie-100cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 37,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Hvidolie-40cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 38,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Hvidolie-60cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 39,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Hvidolie-80cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 40,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Hvidolie-100cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 41,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Sortolie-40cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 42,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Sortolie-60cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 43,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Sortolie-80cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 44,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Sortolie-100cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 45,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Naturolie-40cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 46,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Naturolie-60cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 47,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Naturolie-80cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 48,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Naturolie-100cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 49,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Hvidolie-40cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 50,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Hvidolie-60cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 51,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Hvidolie-80cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 52,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Hvidolie-100cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 53,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Sortolie-40cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 54,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Sortolie-60cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 55,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Sortolie-80cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 56,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Sortolie-100cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 57,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Naturolie-40cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 58,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Naturolie-60cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 59,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Naturolie-80cm");

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 60,
                column: "ProductReferenceUrlName",
                value: "Hylde-Egetræ-Naturolie-100cm");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Bøjle i massivt egetræ - Behandlet med naturolie", "Bøjle-Egetræ-Naturolie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Bøjle i massivt egetræ - Behandlet med sortolie", "Bøjle-Egetræ-Sortolie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Bøjle i massivt egetræ - Behandlet med hvidolie", "Bøjle-Egetræ-Hvidolie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Hylde i massivt egetræ - Behandlet med hvidolie", "Hylde-Egetræ-Hvidolie-40cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Hylde i massivt egetræ - Behandlet med sortolie", "Hylde-Egetræ-Sortolie-40cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Hylde i massivt egetræ - Behandlet med naturolie", "Hylde-Egetræ-Naturolie-40cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Hylde i massivt egetræ - Behandlet med hvidolie", "Hylde-Egetræ-Hvidolie-60cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Hylde i massivt egetræ - Behandlet med sortolie", "Hylde-Egetræ-Sortolie-60cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Hylde i massivt egetræ - Behandlet med naturolie", "Hylde-Egetræ-Naturolie-60cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Hylde i massivt egetræ - Behandlet med hvidolie", "Hylde-Egetræ-Hvidolie-80cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Hylde i massivt egetræ - Behandlet med sortolie", "Hylde-Egetræ-Sortolie-80cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Hylde i massivt egetræ - Behandlet med naturolie", "Hylde-Egetræ-Naturolie-80cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Hylde i massivt egetræ - Behandlet med hvidolie", "Hylde-Egetræ-Hvidolie-100cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Hylde i massivt egetræ - Behandlet med sortolie", "Hylde-Egetræ-Sortolie-100cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Hylde i massivt egetræ - Behandlet med naturolie", "Hylde-Egetræ-Naturolie-100cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Bord i massivt egetræ - Behandlet med naturolie", "Bord-Egetræ-Naturolie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Bord i massivt egetræ - Behandlet med hvidolie", "Bord-Egetræ-Hvidolie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Bænk i massivt egetræ - Behandlet med naturolie", "Bænk-Egetræ-Naturolie-115cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Bænk i massivt egetræ - Behandlet med hvidolie", "Bænk-Egetræ-Hvidolie-115cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Bænk i massivt egetræ - Behandlet med sortolie", "Bænk-Egetræ-Sortolie-115cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Bænk i massivt egetræ - Behandlet med naturolie", "Bænk-Egetræ-Naturolie-170cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Bænk i massivt egetræ - Behandlet med hvidolie", "Bænk-Egetræ-Hvidolie-170cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Bænk i massivt egetræ - Behandlet med sortolie", "Bænk-Egetræ-Sortolie-170cm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Opbevaringsbænk i massivt egetræ - Behandlet med naturolie", "Opbevaringsbænk-Egetræ-Naturolie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Opbevaringsbænk i massivt egetræ - Behandlet med hvidolie", "Opbevaringsbænk-Egetræ-Hvidolie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Opbevaringsbænk i massivt egetræ - Behandlet med sortolie", "Opbevaringsbænk-Egetræ-Sortolie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Tøjstativ i massivt egetræ - Behandlet med naturolie", "Tøjstativ-Egetræ-Naturolie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Tøjstativ i massivt egetræ - Behandlet med hvidolie", "Tøjstativ-Egetræ-Hvidolie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Tøjstativ i massivt egetræ - Behandlet med sortolie", "Tøjstativ-Egetræ-Sortolie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Hængende tøjstativ i massivt egetræ - Behandlet med naturolie", "Ophængt-Tøjstativ-Egetræ-Naturolie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Hængende tøjstativ i massivt egetræ - Behandlet med hvidolie", "Ophængt-Tøjstativ-Egetræ-Hvidolie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Title", "UrlName" },
                values: new object[] { "Hængende tøjstativ i massivt egetræ - Behandlet med sortolie", "Ophængt-Tøjstativ-Egetræ-Sortolie" });
        }
    }
}
