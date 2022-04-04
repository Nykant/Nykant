using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.data.migrations.local
{
    public partial class BackOrdersGone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentCaptureId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsBackOrder",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentCaptureId",
                table: "Orders",
                column: "PaymentCaptureId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentCaptureId",
                table: "Orders");

            migrationBuilder.AddColumn<bool>(
                name: "IsBackOrder",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentCaptureId",
                table: "Orders",
                column: "PaymentCaptureId");
        }
    }
}
