using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.Migrations
{
    public partial class ProductLengthAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Length",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductLength",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: false),
                    ProductReferenceId = table.Column<int>(nullable: false),
                    Length = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLength", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductLength_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductLength",
                columns: new[] { "Id", "Length", "ProductId", "ProductReferenceId" },
                values: new object[,]
                {
                    { 1, "1150 mm.", 8, 8 },
                    { 16, "1000 mm.", 6, 6 },
                    { 15, "800 mm.", 6, 6 },
                    { 14, "600 mm.", 6, 6 },
                    { 13, "400 mm.", 6, 6 },
                    { 12, "1000 mm.", 5, 6 },
                    { 11, "800 mm.", 5, 6 },
                    { 10, "600 mm.", 5, 6 },
                    { 9, "400 mm.", 5, 6 },
                    { 8, "1000 mm.", 4, 6 },
                    { 7, "800 mm.", 4, 6 },
                    { 6, "600 mm.", 4, 6 },
                    { 5, "400 mm.", 4, 6 },
                    { 4, "1700 mm.", 9, 9 },
                    { 3, "1150 mm.", 9, 8 },
                    { 2, "1700 mm.", 8, 9 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Thyra Bænken");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Thyra Bænken");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLength_ProductId",
                table: "ProductLength",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductLength");

            migrationBuilder.AddColumn<string>(
                name: "Length",
                table: "Products",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Length",
                value: "600 mm.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Length",
                value: "600 mm.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Length",
                value: "600 mm.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Length", "Name" },
                values: new object[] { "1150 mm.", "Thyra Kortbænken" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Length", "Name" },
                values: new object[] { "1700 mm.", "Thyra Langbænken" });
        }
    }
}
