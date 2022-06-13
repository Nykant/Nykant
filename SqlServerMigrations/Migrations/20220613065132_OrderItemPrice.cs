using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.data.migrations.local
{
    public partial class OrderItemPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Price",
                table: "OrderItems",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderItems");
        }
    }
}
