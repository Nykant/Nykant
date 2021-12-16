using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Products",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Bøjle i massivt egetræ - Behandlet med naturolie");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Bøjle i massivt egetræ - Behandlet med sortolie");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "Bøjle i massivt egetræ - Behandlet med hvidolie");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Title",
                value: "Hylde i massivt egetræ - Behandlet med hvidolie");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Title",
                value: "Hylde i massivt egetræ - Behandlet med sortolie");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Title",
                value: "Hylde i massivt egetræ - Behandlet med naturolie");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Title",
                value: "Bord i massivt egetræ - Behandlet med naturolie");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Title",
                value: "Bænk i massivt egetræ - Behandlet med naturolie");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Title",
                value: "Bænk i massivt egetræ - Behandlet med naturolie");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "Title",
                value: "Opbevaringsbænk i massivt egetræ - Behandlet med naturolie");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "Title",
                value: "Tøjstativ i massivt egetræ - Behandlet med naturolie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Products");
        }
    }
}
