using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.data.migrations.local
{
    public partial class OrderCouponDisconnected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Coupons_CouponCode",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CouponCode",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "CouponCode",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Coupons",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Coupons");

            migrationBuilder.AlterColumn<string>(
                name: "CouponCode",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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
    }
}
