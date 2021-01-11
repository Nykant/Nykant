using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nykant.Migrations
{
    public partial class update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageSource",
                table: "Products",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 11, 14, 35, 21, 959, DateTimeKind.Local).AddTicks(2496) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 11, 14, 35, 21, 961, DateTimeKind.Local).AddTicks(7766) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 11, 14, 35, 21, 961, DateTimeKind.Local).AddTicks(7845) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 11, 14, 35, 21, 961, DateTimeKind.Local).AddTicks(7851) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 11, 14, 35, 21, 961, DateTimeKind.Local).AddTicks(7854) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 11, 14, 35, 21, 961, DateTimeKind.Local).AddTicks(7857) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 11, 14, 35, 21, 961, DateTimeKind.Local).AddTicks(7860) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 11, 14, 35, 21, 961, DateTimeKind.Local).AddTicks(7864) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 11, 14, 35, 21, 961, DateTimeKind.Local).AddTicks(7866) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 11, 14, 35, 21, 961, DateTimeKind.Local).AddTicks(7869) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 11, 14, 35, 21, 961, DateTimeKind.Local).AddTicks(7872) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 11, 14, 35, 21, 961, DateTimeKind.Local).AddTicks(7875) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 11, 14, 35, 21, 961, DateTimeKind.Local).AddTicks(7878) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 11, 14, 35, 21, 961, DateTimeKind.Local).AddTicks(7881) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 11, 14, 35, 21, 961, DateTimeKind.Local).AddTicks(7884) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 11, 14, 35, 21, 961, DateTimeKind.Local).AddTicks(7887) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 11, 14, 35, 21, 961, DateTimeKind.Local).AddTicks(7889) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 11, 14, 35, 21, 961, DateTimeKind.Local).AddTicks(7892) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ImageSource", "LastModified" },
                values: new object[] { "../images/Finback-Chairs1-1280x853-c-default.jpg", new DateTime(2021, 1, 11, 14, 35, 21, 961, DateTimeKind.Local).AddTicks(7895) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageSource",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 556, DateTimeKind.Local).AddTicks(6412));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7049));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7114));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7120));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7124));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7126));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7129));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7132));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7135));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7137));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7140));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7143));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7146));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7149));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7151));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7154));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7157));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7160));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "LastModified",
                value: new DateTime(2021, 1, 11, 13, 45, 46, 559, DateTimeKind.Local).AddTicks(7164));
        }
    }
}
