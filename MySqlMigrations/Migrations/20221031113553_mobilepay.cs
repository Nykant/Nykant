using Microsoft.EntityFrameworkCore.Migrations;

namespace MySqlMigrations.Migrations
{
    public partial class mobilepay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MobilePay",
                table: "PaymentCaptures",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MobilePay",
                table: "PaymentCaptures");
        }
    }
}
