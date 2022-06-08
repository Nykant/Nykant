using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.data.migrations.local
{
    public partial class OrderCouponEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CouponCode",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discount",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CouponCode",
                table: "Orders",
                column: "CouponCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Coupons_CouponCode",
                table: "Orders",
                column: "CouponCode",
                principalTable: "Coupons",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Coupons_CouponCode",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CouponCode",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CouponCode",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Orders");
        }
    }
}
