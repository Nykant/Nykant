using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.Migrations
{
    public partial class InvoiceAdded3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Orders_OrderId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_OrderId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Invoices");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_InvoiceId",
                table: "Orders",
                column: "InvoiceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Invoices_InvoiceId",
                table: "Orders",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Invoices_InvoiceId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_InvoiceId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_OrderId",
                table: "Invoices",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Orders_OrderId",
                table: "Invoices",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
