using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.Migrations
{
    public partial class NotHomeNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NotHomeNote",
                table: "ShippingDeliveries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotHomeNote",
                table: "ShippingDeliveries");
        }
    }
}
