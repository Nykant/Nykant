using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.data.migrations.local
{
    public partial class refund2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentCaptures_Refunds_RefundId",
                table: "PaymentCaptures");

            migrationBuilder.DropIndex(
                name: "IX_PaymentCaptures_RefundId",
                table: "PaymentCaptures");

            migrationBuilder.DropColumn(
                name: "RefundId",
                table: "PaymentCaptures");

            migrationBuilder.AddColumn<int>(
                name: "PaymentCaptureId",
                table: "Refunds",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Refunds_PaymentCaptureId",
                table: "Refunds",
                column: "PaymentCaptureId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Refunds_PaymentCaptures_PaymentCaptureId",
                table: "Refunds",
                column: "PaymentCaptureId",
                principalTable: "PaymentCaptures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Refunds_PaymentCaptures_PaymentCaptureId",
                table: "Refunds");

            migrationBuilder.DropIndex(
                name: "IX_Refunds_PaymentCaptureId",
                table: "Refunds");

            migrationBuilder.DropColumn(
                name: "PaymentCaptureId",
                table: "Refunds");

            migrationBuilder.AddColumn<int>(
                name: "RefundId",
                table: "PaymentCaptures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentCaptures_RefundId",
                table: "PaymentCaptures",
                column: "RefundId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentCaptures_Refunds_RefundId",
                table: "PaymentCaptures",
                column: "RefundId",
                principalTable: "Refunds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
