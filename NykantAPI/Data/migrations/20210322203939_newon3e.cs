using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.data.migrations
{
    public partial class newon3e : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 38,
                column: "ProductId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ProductId", "Source" },
                values: new object[,]
                {
                    { 62, 6, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 63, 7, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 64, 8, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 65, 9, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 66, 10, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 67, 11, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 68, 12, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 70, 14, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 61, 5, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 71, 15, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 73, 17, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 74, 18, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 75, 1, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 76, 2, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 77, 3, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 78, 4, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 79, 5, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 80, 6, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 72, 16, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 60, 4, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 69, 13, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 58, 2, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 59, 3, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 41, 4, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 42, 5, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 43, 6, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 44, 7, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 45, 8, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 46, 9, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 47, 10, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 48, 11, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 40, 3, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 50, 13, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 49, 12, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 57, 1, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 56, 19, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 55, 18, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 39, 2, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 53, 16, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 52, 15, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 51, 14, "../images/Finback-Chairs1-1280x853-c-default.jpg" },
                    { 54, 17, "../images/Finback-Chairs1-1280x853-c-default.jpg" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 39, 38, 910, DateTimeKind.Local).AddTicks(4470));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 39, 38, 912, DateTimeKind.Local).AddTicks(5918));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 39, 38, 912, DateTimeKind.Local).AddTicks(5987));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 39, 38, 912, DateTimeKind.Local).AddTicks(5993));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 39, 38, 912, DateTimeKind.Local).AddTicks(5996));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 39, 38, 912, DateTimeKind.Local).AddTicks(5999));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 39, 38, 912, DateTimeKind.Local).AddTicks(6002));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 39, 38, 912, DateTimeKind.Local).AddTicks(6005));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 39, 38, 912, DateTimeKind.Local).AddTicks(6008));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 39, 38, 912, DateTimeKind.Local).AddTicks(6010));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 39, 38, 912, DateTimeKind.Local).AddTicks(6013));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 39, 38, 912, DateTimeKind.Local).AddTicks(6016));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 39, 38, 912, DateTimeKind.Local).AddTicks(6019));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 39, 38, 912, DateTimeKind.Local).AddTicks(6022));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 39, 38, 912, DateTimeKind.Local).AddTicks(6025));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 39, 38, 912, DateTimeKind.Local).AddTicks(6028));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 39, 38, 912, DateTimeKind.Local).AddTicks(6031));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 39, 38, 912, DateTimeKind.Local).AddTicks(6033));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 39, 38, 912, DateTimeKind.Local).AddTicks(6036));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 38,
                column: "ProductId",
                value: 19);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 26, 22, 61, DateTimeKind.Local).AddTicks(2892));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 26, 22, 64, DateTimeKind.Local).AddTicks(2195));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 26, 22, 64, DateTimeKind.Local).AddTicks(2377));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 26, 22, 64, DateTimeKind.Local).AddTicks(2384));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 26, 22, 64, DateTimeKind.Local).AddTicks(2434));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 26, 22, 64, DateTimeKind.Local).AddTicks(2438));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 26, 22, 64, DateTimeKind.Local).AddTicks(2442));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 26, 22, 64, DateTimeKind.Local).AddTicks(2445));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 26, 22, 64, DateTimeKind.Local).AddTicks(2448));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 26, 22, 64, DateTimeKind.Local).AddTicks(2451));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 26, 22, 64, DateTimeKind.Local).AddTicks(2453));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 26, 22, 64, DateTimeKind.Local).AddTicks(2456));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 26, 22, 64, DateTimeKind.Local).AddTicks(2459));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 26, 22, 64, DateTimeKind.Local).AddTicks(2462));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 26, 22, 64, DateTimeKind.Local).AddTicks(2465));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 26, 22, 64, DateTimeKind.Local).AddTicks(2468));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 26, 22, 64, DateTimeKind.Local).AddTicks(2471));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 26, 22, 64, DateTimeKind.Local).AddTicks(2473));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "LastModified",
                value: new DateTime(2021, 3, 22, 21, 26, 22, 64, DateTimeKind.Local).AddTicks(2476));
        }
    }
}
