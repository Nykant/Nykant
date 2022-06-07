using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.data.migrations.local
{
    public partial class coupon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    Discount = table.Column<int>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    ForAllProducts = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "CouponForProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouponCode = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponForProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CouponForProducts_Coupons_CouponCode",
                        column: x => x.CouponCode,
                        principalTable: "Coupons",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CouponForProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CouponForProducts_CouponCode",
                table: "CouponForProducts",
                column: "CouponCode");

            migrationBuilder.CreateIndex(
                name: "IX_CouponForProducts_ProductId",
                table: "CouponForProducts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CouponForProducts");

            migrationBuilder.DropTable(
                name: "Coupons");
        }
    }
}
