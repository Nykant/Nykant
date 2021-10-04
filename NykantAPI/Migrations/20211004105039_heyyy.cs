using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.Migrations
{
    public partial class heyyy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShippingDeliveries_ShippingDeliveryId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShippingDeliveryId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "ShippingDeliveries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShippingDeliveries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ShippingDeliveries");

            migrationBuilder.DropColumn(
                name: "ShippingDeliveryId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "ShippingDeliveries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "ShippingDeliveries",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PakkeshopData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingDeliveryId = table.Column<int>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    Streetname = table.Column<string>(nullable: true),
                    Streetname2 = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    CityName = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true),
                    CountryCodeISO3166A2 = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    DistanceMetersAsTheCrowFlies = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PakkeshopData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PakkeshopData_ShippingDeliveries_ShippingDeliveryId",
                        column: x => x.ShippingDeliveryId,
                        principalTable: "ShippingDeliveries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModified",
                value: new DateTime(2021, 10, 4, 12, 50, 37, 365, DateTimeKind.Local).AddTicks(5718));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2021, 10, 4, 12, 50, 37, 367, DateTimeKind.Local).AddTicks(7802));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2021, 10, 4, 12, 50, 37, 367, DateTimeKind.Local).AddTicks(7879));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastModified",
                value: new DateTime(2021, 10, 4, 12, 50, 37, 367, DateTimeKind.Local).AddTicks(7884));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastModified",
                value: new DateTime(2021, 10, 4, 12, 50, 37, 367, DateTimeKind.Local).AddTicks(7888));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastModified",
                value: new DateTime(2021, 10, 4, 12, 50, 37, 367, DateTimeKind.Local).AddTicks(7892));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastModified",
                value: new DateTime(2021, 10, 4, 12, 50, 37, 367, DateTimeKind.Local).AddTicks(7896));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastModified",
                value: new DateTime(2021, 10, 4, 12, 50, 37, 367, DateTimeKind.Local).AddTicks(7899));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastModified",
                value: new DateTime(2021, 10, 4, 12, 50, 37, 367, DateTimeKind.Local).AddTicks(7902));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastModified",
                value: new DateTime(2021, 10, 4, 12, 50, 37, 367, DateTimeKind.Local).AddTicks(7906));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastModified",
                value: new DateTime(2021, 10, 4, 12, 50, 37, 367, DateTimeKind.Local).AddTicks(7909));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastModified",
                value: new DateTime(2021, 10, 4, 12, 50, 37, 367, DateTimeKind.Local).AddTicks(7912));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "LastModified",
                value: new DateTime(2021, 10, 4, 12, 50, 37, 367, DateTimeKind.Local).AddTicks(7915));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "LastModified",
                value: new DateTime(2021, 10, 4, 12, 50, 37, 367, DateTimeKind.Local).AddTicks(7919));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "LastModified",
                value: new DateTime(2021, 10, 4, 12, 50, 37, 367, DateTimeKind.Local).AddTicks(7922));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastModified",
                value: new DateTime(2021, 10, 4, 12, 50, 37, 367, DateTimeKind.Local).AddTicks(7925));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "LastModified",
                value: new DateTime(2021, 10, 4, 12, 50, 37, 367, DateTimeKind.Local).AddTicks(7929));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "LastModified",
                value: new DateTime(2021, 10, 4, 12, 50, 37, 367, DateTimeKind.Local).AddTicks(7932));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "LastModified",
                value: new DateTime(2021, 10, 4, 12, 50, 37, 367, DateTimeKind.Local).AddTicks(7935));

            migrationBuilder.CreateIndex(
                name: "IX_ShippingDeliveries_OrderId",
                table: "ShippingDeliveries",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PakkeshopData_ShippingDeliveryId",
                table: "PakkeshopData",
                column: "ShippingDeliveryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingDeliveries_Orders_OrderId",
                table: "ShippingDeliveries",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShippingDeliveries_Orders_OrderId",
                table: "ShippingDeliveries");

            migrationBuilder.DropTable(
                name: "PakkeshopData");

            migrationBuilder.DropIndex(
                name: "IX_ShippingDeliveries_OrderId",
                table: "ShippingDeliveries");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "ShippingDeliveries");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "ShippingDeliveries");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ShippingDeliveries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShippingDeliveryId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 656, DateTimeKind.Local).AddTicks(6154));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9728));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9805));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9811));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9814));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9817));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9820));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9823));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9826));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9829));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9832));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9835));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9838));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9841));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9844));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9847));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9850));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9852));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "LastModified",
                value: new DateTime(2021, 10, 1, 14, 15, 52, 658, DateTimeKind.Local).AddTicks(9855));

            migrationBuilder.InsertData(
                table: "ShippingDeliveries",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 2, "Home", 65 },
                    { 1, "Shop", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingDeliveryId",
                table: "Orders",
                column: "ShippingDeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShippingDeliveries_ShippingDeliveryId",
                table: "Orders",
                column: "ShippingDeliveryId",
                principalTable: "ShippingDeliveries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
