using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.Migrations
{
    public partial class ImageTypeAndImageSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageSource",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageSource2",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "GalleryImage1",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GalleryImage2",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageType",
                table: "Images",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Images",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GalleryImage1", "GalleryImage2" },
                values: new object[] { "../images/Products/NYKANT_boejle_naturolie_01.png", "../images/Products/NYKANT_boejle_naturolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "GalleryImage1", "GalleryImage2" },
                values: new object[] { "../images/Products/NYKANT_boejle_sortolie_01.png", "../images/Products/NYKANT_boejle_sortolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "GalleryImage1", "GalleryImage2" },
                values: new object[] { "../images/Products/NYKANT_boejle_hvidolie_01.png", "../images/Products/NYKANT_boejle_hvidolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "GalleryImage1", "GalleryImage2" },
                values: new object[] { "../images/Products/NYKANT_hylde_hvidolie_01.png", "../images/Products/NYKANT_hylde_hvidolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "GalleryImage1", "GalleryImage2" },
                values: new object[] { "../images/Products/NYKANT_hylde_sortolie_01.png", "../images/Products/NYKANT_hylde_sortolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "GalleryImage1", "GalleryImage2" },
                values: new object[] { "../images/Products/NYKANT_hylde_naturolie_01.png", "../images/Products/NYKANT_hylde_naturolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "GalleryImage1", "GalleryImage2" },
                values: new object[] { "../images/Products/NYKANT_bord_naturolie_01.png", "../images/Products/NYKANT_bord_naturolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "GalleryImage1", "GalleryImage2" },
                values: new object[] { "../images/Products/NYKANT_kortbaenk_naturolie_01.png", "../images/Products/NYKANT_kortbaenk_naturolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "GalleryImage1", "GalleryImage2" },
                values: new object[] { "../images/Products/NYKANT_langbaenk_naturolie_01.png", "../images/Products/NYKANT_langbaenk_naturolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "GalleryImage1", "GalleryImage2" },
                values: new object[] { "../images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", "../images/Products/NYKANT_opbevaringsbaenk_naturolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "GalleryImage1", "GalleryImage2" },
                values: new object[] { "../images/Products/NYKANT_rack_naturolie_01.png", "../images/Products/NYKANT_rack_naturolie_02.png" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GalleryImage1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GalleryImage2",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageType",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "ImageSource",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageSource2",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageSource", "ImageSource2" },
                values: new object[] { "../images/Products/NYKANT_boejle_naturolie_01.png", "../images/Products/NYKANT_boejle_naturolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageSource", "ImageSource2" },
                values: new object[] { "../images/Products/NYKANT_boejle_sortolie_01.png", "../images/Products/NYKANT_boejle_sortolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImageSource", "ImageSource2" },
                values: new object[] { "../images/Products/NYKANT_boejle_hvidolie_01.png", "../images/Products/NYKANT_boejle_hvidolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImageSource", "ImageSource2" },
                values: new object[] { "../images/Products/NYKANT_hylde_hvidolie_01.png", "../images/Products/NYKANT_hylde_hvidolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ImageSource", "ImageSource2" },
                values: new object[] { "../images/Products/NYKANT_hylde_sortolie_01.png", "../images/Products/NYKANT_hylde_sortolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ImageSource", "ImageSource2" },
                values: new object[] { "../images/Products/NYKANT_hylde_naturolie_01.png", "../images/Products/NYKANT_hylde_naturolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ImageSource", "ImageSource2" },
                values: new object[] { "../images/Products/NYKANT_bord_naturolie_01.png", "../images/Products/NYKANT_bord_naturolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ImageSource", "ImageSource2" },
                values: new object[] { "../images/Products/NYKANT_kortbaenk_naturolie_01.png", "../images/Products/NYKANT_kortbaenk_naturolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ImageSource", "ImageSource2" },
                values: new object[] { "../images/Products/NYKANT_langbaenk_naturolie_01.png", "../images/Products/NYKANT_langbaenk_naturolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ImageSource", "ImageSource2" },
                values: new object[] { "../images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", "../images/Products/NYKANT_opbevaringsbaenk_naturolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ImageSource", "ImageSource2" },
                values: new object[] { "../images/Products/NYKANT_rack_naturolie_01.png", "../images/Products/NYKANT_rack_naturolie_02.png" });
        }
    }
}
