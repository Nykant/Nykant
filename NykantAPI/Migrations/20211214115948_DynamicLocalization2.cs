using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.Migrations
{
    public partial class DynamicLocalization2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeOfWood",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Materials",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Products",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Materials", "Note", "Size" },
                values: new object[] { "Gertrud Materials", "Gertrud Note", "Gertrud Size" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Materials", "Note", "Size" },
                values: new object[] { "Gertrud Materials", "Gertrud Note", "Gertrud Size" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Materials", "Note", "Size" },
                values: new object[] { "Gertrud Materials", "Gertrud Note", "Gertrud Size" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Materials", "Note", "Size" },
                values: new object[] { "Ingeborg Materials", "Ingeborg Note", "Ingeborg Size" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Materials", "Note", "Size" },
                values: new object[] { "Ingeborg Materials", "Ingeborg Note", "Ingeborg Size" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Materials", "Note", "Size" },
                values: new object[] { "Ingeborg Materials", "Ingeborg Note", "Ingeborg Size" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Materials", "Note", "Size", "WeightInKg" },
                values: new object[] { "Dagmar Materials", "Dagmar Note", "Dagmar Size", 22.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Materials", "Note", "Size", "WeightInKg" },
                values: new object[] { "Thyra Materials", "Thyra Note", "Thyra Size", 14.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Materials", "Note", "Size", "WeightInKg" },
                values: new object[] { "Thyra Materials", "Thyra Note", "Thyra Size", 20.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Materials", "Note", "Size", "WeightInKg" },
                values: new object[] { "Filippa Materials", "Filippa Note", "Filippa Size", 24.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Materials", "Note", "Size" },
                values: new object[] { "Nora Materials", "Nora Note", "Nora Size" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Materials",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "TypeOfWood",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "TypeOfWood",
                value: "Eg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "TypeOfWood",
                value: "Eg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "TypeOfWood",
                value: "Eg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "TypeOfWood",
                value: "Eg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "TypeOfWood",
                value: "Eg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "TypeOfWood",
                value: "Eg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "TypeOfWood", "WeightInKg" },
                values: new object[] { "Eg", 11.6 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "TypeOfWood", "WeightInKg" },
                values: new object[] { "Eg", 13.4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "TypeOfWood", "WeightInKg" },
                values: new object[] { "Eg", 13.4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "TypeOfWood", "WeightInKg" },
                values: new object[] { "Eg", 23.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "TypeOfWood",
                value: "Eg");
        }
    }
}
