using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.Migrations
{
    public partial class Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "ShippingAddress");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "ShippingAddress");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "BillingAddress");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "BillingAddress");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ShippingAddress",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BillingAddress",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ShippingAddress");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "BillingAddress");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "ShippingAddress",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "ShippingAddress",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "BillingAddress",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "BillingAddress",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "");
        }
    }
}
