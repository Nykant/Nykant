using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.data.migrations.local
{
    public partial class refund : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RefundId",
                table: "PaymentCaptures",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Refunded",
                table: "PaymentCaptures",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Refunds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(nullable: false),
                    ReturnFee = table.Column<int>(nullable: false),
                    QualityFee = table.Column<int>(nullable: false),
                    Products = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refunds", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Sort bøjlekrog</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Materials",
                value: "<tr><td class='width-30'<strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Sort bøjlekrog</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Sort bøjlekrog</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer:</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Metal fittings</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer:</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Metal fittings</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer:</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Læderstrop</p><p>Beslag </p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer:</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Læderstrop</p><p>Beslag </p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer:</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Læderstrop</p><p>Beslag </p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Kiler</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Kiler</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Kiler</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Lædderstrop</p><p>Beslag</p><p>Skruer</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Lædderstrop</p><p>Beslag</p><p>Skruer</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Lædderstrop</p><p>Beslag</p><p>Skruer</p></td></tr>");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentCaptures_Refunds_RefundId",
                table: "PaymentCaptures");

            migrationBuilder.DropTable(
                name: "Refunds");

            migrationBuilder.DropIndex(
                name: "IX_PaymentCaptures_RefundId",
                table: "PaymentCaptures");

            migrationBuilder.DropColumn(
                name: "RefundId",
                table: "PaymentCaptures");

            migrationBuilder.DropColumn(
                name: "Refunded",
                table: "PaymentCaptures");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Sort bøjlekrog</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Materials",
                value: "<tr><td class='width-30'<strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Sort bøjlekrog</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Sort bøjlekrog</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer:</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Metal fittings</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer:</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Metal fittings</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer:</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Læderstrop</p><p>Beslag </p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer:</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Læderstrop</p><p>Beslag </p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer:</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Læderstrop</p><p>Beslag </p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Kiler</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Kiler</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Kiler</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Lædderstrop</p><p>Beslag</p><p>Skruer</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Lædderstrop</p><p>Beslag</p><p>Skruer</p></td></tr>");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "Materials",
                value: "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Lædderstrop</p><p>Beslag</p><p>Skruer</p></td></tr>");
        }
    }
}
