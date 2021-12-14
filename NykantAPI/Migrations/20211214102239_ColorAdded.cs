using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.Migrations
{
    public partial class ColorAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    ImgSrc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colors_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "ImgSrc", "ProductId" },
                values: new object[,]
                {
                    { 1, "../images/Products/NYKANT_boejle_naturolie_01.png", 1 },
                    { 21, "../images/Products/NYKANT_langbaenk_naturolie_01.png", 9 },
                    { 20, "../images/Products/NYKANT_kortbaenk_naturolie_01.png", 8 },
                    { 19, "../images/Products/NYKANT_bord_naturolie_01.png", 7 },
                    { 18, "../images/Products/NYKANT_hylde_naturolie_01.png", 6 },
                    { 17, "../images/Products/NYKANT_hylde_sortolie_01.png", 6 },
                    { 16, "../images/Products/NYKANT_hylde_hvidolie_01.png", 6 },
                    { 15, "../images/Products/NYKANT_hylde_naturolie_01.png", 5 },
                    { 14, "../images/Products/NYKANT_hylde_sortolie_01.png", 5 },
                    { 13, "../images/Products/NYKANT_hylde_hvidolie_01.png", 5 },
                    { 22, "../images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", 10 },
                    { 12, "../images/Products/NYKANT_hylde_naturolie_01.png", 4 },
                    { 10, "../images/Products/NYKANT_hylde_hvidolie_01.png", 4 },
                    { 9, "../images/Products/NYKANT_boejle_hvidolie_01.png", 3 },
                    { 8, "../images/Products/NYKANT_boejle_sortolie_01.png", 3 },
                    { 7, "../images/Products/NYKANT_boejle_naturolie_01.png", 3 },
                    { 6, "../images/Products/NYKANT_boejle_hvidolie_01.png", 2 },
                    { 5, "../images/Products/NYKANT_boejle_sortolie_01.png", 2 },
                    { 4, "../images/Products/NYKANT_boejle_naturolie_01.png", 2 },
                    { 3, "../images/Products/NYKANT_boejle_hvidolie_01.png", 1 },
                    { 2, "../images/Products/NYKANT_boejle_sortolie_01.png", 1 },
                    { 11, "../images/Products/NYKANT_hylde_sortolie_01.png", 4 },
                    { 23, "../images/Products/NYKANT_rack_naturolie_01.png", 11 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colors_ProductId",
                table: "Colors",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colors");
        }
    }
}
