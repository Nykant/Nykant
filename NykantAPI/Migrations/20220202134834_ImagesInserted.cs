using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.Migrations
{
    public partial class ImagesInserted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgSource",
                value: "../Images/Products/Category/Desktop/ingrid_natur_2.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImgSource",
                value: "../Images/Products/Category/Desktop/bord_natur_2.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImgSource",
                value: "../Images/Products/Category/Desktop/hylde_natur_1.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImgSource",
                value: "../Images/Products/Category/Desktop/opbevaringsbaenk_natur_3.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImgSource",
                value: "../Images/Products/Category/Desktop/boejle_natur_1.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgSrc",
                value: "../images/Products/Color/Desktop/boejle_natur_1.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImgSrc",
                value: "../images/Products/Color/Desktop/boejle_sort_1.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImgSrc",
                value: "../images/Products/Color/Desktop/boejle_hvid_1.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImgSrc",
                value: "../images/Products/Color/Desktop/boejle_natur_1.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImgSrc",
                value: "../images/Products/Color/Desktop/boejle_sort_01.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImgSrc",
                value: "../images/Products/Color/Desktop/boejle_hvid_1.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImgSrc",
                value: "../images/Products/Color/Desktop/boejle_natur_1.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImgSrc",
                value: "../images/Products/Color/Desktop/boejle_sort_1.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImgSrc",
                value: "../images/Products/Color/Desktop/boejle_hvid_1.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImgSrc",
                value: "../images/Products/Color/Desktop/hylde_hvid_1.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImgSrc",
                value: "../images/Products/Color/Desktop/hylde_sort_1.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImgSrc",
                value: "../images/Products/Color/Desktop/hylde_natur_1.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImgSrc",
                value: "../images/Products/Color/Desktop/hylde_hvid_1.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImgSrc",
                value: "../images/Products/Color/Desktop/hylde_sort_1.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImgSrc",
                value: "../images/Products/Color/Desktop/hylde_natur_1.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImgSrc",
                value: "../images/Products/Color/Desktop/hylde_hvid_1.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImgSrc",
                value: "../images/Products/Color/Desktop/hylde_sort_1.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImgSrc",
                value: "../images/Products/Color/Desktop/hylde_natur_1.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "EColor", "ImgSrc" },
                values: new object[] { 1, "../images/Products/Color/Desktop/hylde_hvid_1.png" });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "EColor", "ImgSrc", "ProductId" },
                values: new object[] { 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 7 });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ImgSrc", "ProductId" },
                values: new object[] { "../images/Products/Color/Desktop/hylde_natur_1.png", 7 });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "EColor", "ImgSrc", "ProductId", "ProductSourceId" },
                values: new object[] { 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 8, 7 });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "EColor", "ImgSrc", "ProductId", "ProductSourceId" },
                values: new object[] { 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 8, 8 });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "EColor", "ImgSrc", "ProductId", "ProductSourceId" },
                values: new object[,]
                {
                    { 24, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 8, 9 },
                    { 25, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 9, 7 },
                    { 31, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 11, 10 },
                    { 30, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 10, 12 },
                    { 29, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 10, 11 },
                    { 28, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 10, 10 },
                    { 26, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 9, 8 },
                    { 27, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 9, 9 },
                    { 32, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 11, 11 },
                    { 33, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 11, 12 }
                });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 1, 2, "../images/Products/Details_Slide/Desktop/NYKANT_boejle_naturolie_01.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 1, 2, "../images/Products/Details_Slide/Desktop/NYKANT_boejle_naturolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 2, 2, "../images/Products/Details_Slide/Desktop/NYKANT_boejle_sortolie_01.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 2, 2, "../images/Products/Details_Slide/Desktop/NYKANT_boejle_sortolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 3, 2, "../images/Products/Details_Slide/Desktop/NYKANT_boejle_hvidolie_01.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 3, 2, "../images/Products/Details_Slide/Desktop/NYKANT_boejle_hvidolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 4, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_01.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 4, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 4, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_03.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 5, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_01.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 5, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 5, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_03.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Size", "Source" },
                values: new object[] { 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_01.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Size", "Source" },
                values: new object[] { 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Size", "Source" },
                values: new object[] { 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_03.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 7, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_01.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 7, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 7, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_03.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Size", "Source" },
                values: new object[] { 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_01.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Size", "Source" },
                values: new object[] { 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Size", "Source" },
                values: new object[] { 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_03.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Size", "Source" },
                values: new object[] { 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_01.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Size", "Source" },
                values: new object[] { 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Size", "Source" },
                values: new object[] { 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_03.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Size", "Source" },
                values: new object[] { 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_01.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Size", "Source" },
                values: new object[] { 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Size", "Source" },
                values: new object[] { 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_03.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 11, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_01.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 11, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 11, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_03.png" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ImageType", "ProductId", "Size", "Source" },
                values: new object[,]
                {
                    { 123, 0, 4, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    { 122, 0, 4, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    { 134, 0, 8, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_02.png" },
                    { 125, 0, 5, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_02.png" },
                    { 126, 0, 5, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_03.png" },
                    { 127, 0, 6, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_01.png" },
                    { 128, 0, 6, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_02.png" },
                    { 129, 0, 6, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_03.png" },
                    { 130, 0, 7, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    { 132, 0, 7, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    { 131, 0, 7, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    { 121, 0, 4, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    { 133, 0, 8, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_01.png" },
                    { 124, 0, 5, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_01.png" },
                    { 120, 0, 3, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_boejle_hvidolie_02.png" },
                    { 116, 0, 1, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_boejle_naturolie_02.png" },
                    { 118, 0, 2, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_boejle_sortolie_02.png" },
                    { 237, 0, 4, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    { 236, 0, 4, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    { 235, 0, 4, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    { 234, 0, 3, 2, "../images/Products/Details_Button/Desktop/NYKANT_boejle_hvidolie_02.png" },
                    { 233, 0, 3, 2, "../images/Products/Details_Button/Desktop/NYKANT_boejle_hvidolie_01.png" },
                    { 232, 0, 2, 2, "../images/Products/Details_Button/Desktop/NYKANT_boejle_sortolie_02.png" },
                    { 231, 0, 2, 2, "../images/Products/Details_Button/Desktop/NYKANT_boejle_sortolie_01.png" },
                    { 230, 0, 1, 2, "../images/Products/Details_Button/Desktop/NYKANT_boejle_naturolie_02.png" },
                    { 229, 0, 1, 2, "../images/Products/Details_Button/Desktop/NYKANT_boejle_naturolie_01.png" },
                    { 144, 0, 11, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_03.png" },
                    { 143, 0, 11, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_02.png" },
                    { 142, 0, 11, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_01.png" },
                    { 141, 0, 10, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    { 140, 0, 10, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    { 139, 0, 10, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    { 138, 0, 9, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_03.png" },
                    { 137, 0, 9, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_02.png" },
                    { 136, 0, 9, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_01.png" },
                    { 135, 0, 8, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_03.png" },
                    { 238, 0, 5, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_01.png" },
                    { 119, 0, 3, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_boejle_hvidolie_01.png" },
                    { 239, 0, 5, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_02.png" },
                    { 241, 0, 6, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_01.png" },
                    { 117, 0, 2, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_boejle_sortolie_01.png" },
                    { 115, 0, 1, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_boejle_naturolie_01.png" },
                    { 258, 0, 11, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_03.png" },
                    { 257, 0, 11, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_02.png" },
                    { 256, 0, 11, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_01.png" },
                    { 255, 0, 10, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    { 254, 0, 10, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    { 240, 0, 5, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_03.png" },
                    { 252, 0, 9, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_03.png" },
                    { 253, 0, 10, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    { 250, 0, 9, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_01.png" },
                    { 249, 0, 8, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_03.png" },
                    { 248, 0, 8, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_02.png" },
                    { 247, 0, 8, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_01.png" },
                    { 246, 0, 7, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    { 245, 0, 7, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    { 244, 0, 7, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    { 243, 0, 6, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_03.png" },
                    { 242, 0, 6, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_02.png" },
                    { 251, 0, 9, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_02.png" }
                });

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 13,
                column: "ProductId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ProductId", "ProductReferenceId" },
                values: new object[] { 4, 9 });

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ProductId", "ProductReferenceId" },
                values: new object[] { 4, 12 });

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ProductId", "ProductReferenceId" },
                values: new object[] { 4, 15 });

            migrationBuilder.InsertData(
                table: "ProductLength",
                columns: new[] { "Id", "Length", "ProductId", "ProductReferenceId" },
                values: new object[,]
                {
                    { 36, "1000 mm.", 9, 16 },
                    { 24, "1000 mm.", 6, 15 },
                    { 33, "400 mm.", 9, 6 },
                    { 32, "1000 mm.", 8, 15 },
                    { 31, "800 mm.", 8, 12 },
                    { 30, "600 mm.", 8, 9 },
                    { 29, "400 mm.", 8, 6 },
                    { 28, "1000 mm.", 7, 15 },
                    { 27, "800 mm.", 7, 12 },
                    { 26, "600 mm.", 7, 9 },
                    { 25, "400 mm.", 7, 6 },
                    { 23, "800 mm.", 6, 12 },
                    { 22, "600 mm.", 6, 9 },
                    { 20, "1000 mm.", 5, 15 },
                    { 19, "800 mm.", 5, 12 },
                    { 18, "600 mm.", 5, 9 },
                    { 17, "400 mm.", 5, 6 },
                    { 34, "600 mm.", 9, 9 },
                    { 35, "800 mm.", 9, 12 },
                    { 21, "400 mm.", 6, 6 },
                    { 38, "600 mm.", 10, 9 },
                    { 39, "800 mm.", 10, 12 },
                    { 40, "1000 mm.", 10, 15 },
                    { 41, "400 mm.", 11, 6 },
                    { 42, "600 mm.", 11, 9 },
                    { 43, "800 mm.", 11, 12 },
                    { 44, "1000 mm.", 11, 15 },
                    { 37, "400 mm.", 10, 6 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GalleryImage1", "GalleryImage2", "Number" },
                values: new object[] { "../images/Products/Gallery/Desktop/NYKANT_boejle_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_boejle_naturolie_02.png", "15001" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "GalleryImage1", "GalleryImage2", "Number" },
                values: new object[] { "../images/Products/Gallery/Desktop/NYKANT_boejle_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_boejle_sortolie_02.png", "15003" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "GalleryImage1", "GalleryImage2", "Number" },
                values: new object[] { "../images/Products/Gallery/Desktop/NYKANT_boejle_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_boejle_hvidolie_02.png", "15002" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "GalleryImage1", "GalleryImage2", "Length", "Number", "Package", "Size" },
                values: new object[] { "Ingebor Description", "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_02.png", "400 mm.", "17032", "Ingeborg 400 Package", "Ingeborg 400 Size" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "GalleryImage1", "GalleryImage2", "Length", "Number", "Package", "Size" },
                values: new object[] { "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_02.png", "400 mm.", "17033", "Ingeborg 400 Package", "Ingeborg 400 Size" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "GalleryImage1", "GalleryImage2", "Length", "Number", "Package", "Size" },
                values: new object[] { "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_02.png", "400 mm.", "17031", "Ingeborg 400 Package", "Ingeborg 400 Size" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Amount", "AssemblyPath", "CategoryId", "Description", "EColor", "ExpectedDelivery", "GalleryImage1", "GalleryImage2", "Length", "Materials", "Name", "Note", "Number", "Oil", "Package", "Path", "Price", "Size", "Title", "WeightInKg" },
                values: new object[] { 0, "/word/Hylde_Vejledning.docx", 3, "Ingeborg Description", 1, new DateTime(2022, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_02.png", "600 mm.", "Ingeborg Materials", "Ingeborg Hylden", "Ingeborg Note", "17022", "Hvidolie", "Ingeborg 600 Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_hvidolie_01.png", 595.0, "Ingeborg 600 Size", "Hylde i massivt egetræ - Behandlet med hvidolie", 11.6 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Amount", "AssemblyPath", "CategoryId", "Description", "EColor", "ExpectedDelivery", "GalleryImage1", "GalleryImage2", "Length", "Materials", "Name", "Note", "Number", "Oil", "Package", "Path", "Price", "Size", "Title", "WeightInKg" },
                values: new object[] { 0, "/word/Hylde_Vejledning.docx", 3, "Ingeborg Description", 2, new DateTime(2022, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_02.png", "600 mm.", "Ingeborg Materials", "Ingeborg Hylden", "Ingeborg Note", "17023", "Sortolie", "Ingeborg 600 Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_sortolie_01.png", 595.0, "Ingeborg 600 Size", "Hylde i massivt egetræ - Behandlet med sortolie", 11.6 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Amount", "AssemblyPath", "CategoryId", "Description", "ExpectedDelivery", "GalleryImage1", "GalleryImage2", "Length", "Materials", "Name", "Note", "Number", "Package", "Path", "Price", "Size", "Title", "WeightInKg" },
                values: new object[] { 0, "/word/Hylde_Vejledning.docx", 3, "Ingeborg Description", new DateTime(2022, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_02.png", "600 mm.", "Ingeborg Materials", "Ingeborg Hylden", "Ingeborg Note", "17021", "Ingeborg 600 Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_naturolie_01.png", 595.0, "Ingeborg 600 Size", "Hylde i massivt egetræ - Behandlet med naturolie", 11.6 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Amount", "AssemblyPath", "CategoryId", "Description", "EColor", "ExpectedDelivery", "GalleryImage1", "GalleryImage2", "Length", "Materials", "Name", "Note", "Number", "Oil", "Package", "Path", "Price", "Size", "Title", "WeightInKg" },
                values: new object[] { 0, "/word/Hylde_Vejledning.docx", 3, "Ingeborg Description", 1, new DateTime(2022, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_02.png", "800 mm.", "Ingeborg Materials", "Ingeborg Hylden", "Ingeborg Note", "17012", "Hvidolie", "Ingeborg 800 Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_hvidolie_01.png", 595.0, "Ingeborg 800 Size", "Hylde i massivt egetræ - Behandlet med hvidolie", 11.6 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Amount", "AssemblyPath", "CategoryId", "Description", "EColor", "ExpectedDelivery", "GalleryImage1", "GalleryImage2", "Length", "Materials", "Name", "Note", "Number", "Oil", "Package", "Path", "Price", "Size", "Title", "WeightInKg" },
                values: new object[] { 0, "/word/Hylde_Vejledning.docx", 3, "Ingeborg Description", 2, new DateTime(2022, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_02.png", "800 mm.", "Ingeborg Materials", "Ingeborg Hylden", "Ingeborg Note", "17013", "Sortolie", "Ingeborg 800 Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_sortolie_01.png", 595.0, "Ingeborg 800 Size", "Hylde i massivt egetræ - Behandlet med sortolie", 11.6 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Alt", "Amount", "AssemblyPath", "CategoryId", "Description", "EColor", "ExpectedDelivery", "GalleryImage1", "GalleryImage2", "Length", "Materials", "Name", "Note", "Number", "Oil", "Package", "Path", "Pieces", "Price", "Size", "Title", "WeightInKg" },
                values: new object[,]
                {
                    { 31, null, 26, "/word/hænge_tøjrack.docx", 1, "Ingrid Description", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/Ingrid_Hvidolie_1.png", "../images/Products/Gallery/Desktop/Ingrid_Hvidolie_2.png", null, "Ingrid Materials", "Ingrid Tøjstativ", "Ingrid Note", "14002", "Hvidolie", "Ingrid Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", 1, 2295.0, "Ingrid Size", "Hængende tøjstativ i massivt egetræ - Behandlet med hvidolie", 2.0 },
                    { 12, null, 0, "/word/Hylde_Vejledning.docx", 3, "Ingeborg Description", 0, new DateTime(2022, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_02.png", "800 mm.", "Ingeborg Materials", "Ingeborg Hylden", "Ingeborg Note", "17011", "Naturolie", "Ingeborg 800 Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_naturolie_01.png", 1, 595.0, "Ingeborg 800 Size", "Hylde i massivt egetræ - Behandlet med naturolie", 11.6 },
                    { 13, null, 0, "/word/Hylde_Vejledning.docx", 3, "Ingeborg Description", 1, new DateTime(2022, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_02.png", "1000 mm.", "Ingeborg Materials", "Ingeborg Hylden", "Ingeborg Note", "17002", "Hvidolie", "Ingeborg 1000 Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_hvidolie_01.png", 1, 595.0, "Ingeborg 1000 Size", "Hylde i massivt egetræ - Behandlet med hvidolie", 11.6 },
                    { 14, null, 0, "/word/Hylde_Vejledning.docx", 3, "Ingeborg Description", 2, new DateTime(2022, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_02.png", "1000 mm.", "Ingeborg Materials", "Ingeborg Hylden", "Ingeborg Note", "17003", "Sortolie", "Ingeborg 1000 Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_sortolie_01.png", 1, 595.0, "Ingeborg 1000 Size", "Hylde i massivt egetræ - Behandlet med sortolie", 11.6 },
                    { 15, null, 0, "/word/Hylde_Vejledning.docx", 3, "Ingeborg Description", 0, new DateTime(2022, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_02.png", "1000 mm.", "Ingeborg Materials", "Ingeborg Hylden", "Ingeborg Note", "17001", "Naturolie", "Ingeborg 1000 Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_naturolie_01.png", 1, 595.0, "Ingeborg 1000 Size", "Hylde i massivt egetræ - Behandlet med naturolie", 11.6 },
                    { 16, null, 72, "/word/Bord.docx", 2, "Dagmar Description", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_bord_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_bord_naturolie_02.png", null, "Dagmar Materials", "Dagmar Bordet", "Dagmar Note", "16001", "Naturolie", "Dagmar Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_bord_naturolie_01.png", 1, 2995.0, "Dagmar Size", "Bord i massivt egetræ - Behandlet med naturolie", 22.0 },
                    { 17, null, 72, "/word/Bord.docx", 2, "Dagmar Description", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_bord_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_bord_hvidolie_02.png", null, "Dagmar Materials", "Dagmar Bordet", "Dagmar Note", "16002", "Hvidolie", "Dagmar Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_bord_hvidolie_01.png", 1, 2995.0, "Dagmar Size", "Bord i massivt egetræ - Behandlet med hvidolie", 22.0 },
                    { 18, null, 42, "/word/bænk.docx", 4, "Thyra Short Description", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_kortbaenk_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_kortbaenk_naturolie_02.png", "1150 mm.", "Thyra Short Materials", "Thyra Bænken", "Thyra Short Note", "12001", "Naturolie", "Thyra Short Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_kortbaenk_naturolie_01.png", 1, 2985.0, "Thyra Short Size", "Bænk i massivt egetræ - Behandlet med naturolie", 14.0 },
                    { 19, null, 42, "/word/bænk.docx", 4, "Thyra Short Description", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_kortbaenk_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_kortbaenk_hvidolie_02.png", "1150 mm.", "Thyra Short Materials", "Thyra Bænken", "Thyra Short Note", "12002", "Hvidolie", "Thyra Short Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_kortbaenk_naturolie_01.png", 1, 2985.0, "Thyra Short Size", "Bænk i massivt egetræ - Behandlet med hvidolie", 14.0 },
                    { 20, null, 42, "/word/bænk.docx", 4, "Thyra Short Description", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_kortbaenk_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_kortbaenk_sortolie_02.png", "1150 mm.", "Thyra Short Materials", "Thyra Bænken", "Thyra Short Note", "12003", "Sortolie", "Thyra Short Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_kortbaenk_naturolie_01.png", 1, 2985.0, "Thyra Short Size", "Bænk i massivt egetræ - Behandlet med sortolie", 14.0 },
                    { 21, null, 17, "/word/bænk.docx", 4, "Thyra Description", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_langbaenk_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_langbaenk_naturolie_02.png", "1700 mm.", "Thyra Materials", "Thyra Bænken", "Thyra Note", "11001", "Naturolie", "Thyra Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_langbaenk_naturolie_01.png", 1, 3885.0, "Thyra Size", "Bænk i massivt egetræ - Behandlet med naturolie", 20.0 },
                    { 22, null, 17, "/word/bænk.docx", 4, "Thyra Description", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_langbaenk_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_langbaenk_hvidolie_02.png", "1700 mm.", "Thyra Materials", "Thyra Bænken", "Thyra Note", "11002", "Hvidolie", "Thyra Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_langbaenk_naturolie_01.png", 1, 3885.0, "Thyra Size", "Bænk i massivt egetræ - Behandlet med hvidolie", 20.0 },
                    { 23, null, 17, "/word/bænk.docx", 4, "Thyra Description", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_langbaenk_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_langbaenk_sortolie_02.png", "1700 mm.", "Thyra Materials", "Thyra Bænken", "Thyra Note", "11003", "Sortolie", "Thyra Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_langbaenk_naturolie_01.png", 1, 3885.0, "Thyra Size", "Bænk i massivt egetræ - Behandlet med sortolie", 20.0 },
                    { 24, null, 50, "none", 4, "Filippa Description", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_opbevaringsbaenk_naturolie_02.png", null, "Filippa Materials", "Filippa Bænk", "Filippa Note", "10001", "Naturolie", "Filippa Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", 1, 4395.0, "Filippa Size", "Opbevaringsbænk i massivt egetræ - Behandlet med naturolie", 24.0 },
                    { 25, null, 50, "none", 4, "Filippa Description", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_opbevaringsbaenk_hvidolie_02.png", null, "Filippa Materials", "Filippa Bænk", "Filippa Note", "10002", "Hvidolie", "Filippa Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", 1, 4395.0, "Filippa Size", "Opbevaringsbænk i massivt egetræ - Behandlet med hvidolie", 24.0 },
                    { 26, null, 50, "none", 4, "Filippa Description", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_opbevaringsbaenk_sort_01.png", "../images/Products/Gallery/Desktop/NYKANT_opbevaringsbaenk_sort_02.png", null, "Filippa Materials", "Filippa Bænk", "Filippa Note", "10003", "Sortolie", "Filippa Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", 1, 4395.0, "Filippa Size", "Opbevaringsbænk i massivt egetræ - Behandlet med sortolie", 24.0 },
                    { 27, null, 26, "/word/Tøjstativ.docx", 1, "Nora Description", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_rack_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_rack_naturolie_02.png", null, "Nora Materials", "Nora Tøjstativ", "Nora Note", "13001 + 13001A", "Naturolie", "Nora Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", 1, 2295.0, "Nora Size", "Tøjstativ i massivt egetræ - Behandlet med naturolie", 8.0 },
                    { 28, null, 26, "/word/Tøjstativ.docx", 1, "Nora Description", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_rack_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_rack_hvidolie_02.png", null, "Nora Materials", "Nora Tøjstativ", "Nora Note", "13002 + 13002A", "Hvidolie", "Nora Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", 1, 2295.0, "Nora Size", "Tøjstativ i massivt egetræ - Behandlet med hvidolie", 8.0 },
                    { 29, null, 26, "/word/Tøjstativ.docx", 1, "Nora Description", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_rack_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_rack_sortolie_02.png", null, "Nora Materials", "Nora Tøjstativ", "Nora Note", "13003 + 13003A", "Sortolie", "Nora Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", 1, 2295.0, "Nora Size", "Tøjstativ i massivt egetræ - Behandlet med sortolie", 8.0 },
                    { 32, null, 26, "/word/hænge_tøjrack.docx", 1, "Ingrid Description", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/Ingrid_Sortolie_1.png", "../images/Products/Gallery/Desktop/Ingrid_Sortolie_2.png", null, "Ingrid Materials", "Ingrid Tøjstativ", "Ingrid Note", "14003", "Sortolie", "Ingrid Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", 1, 2295.0, "Ingrid Size", "Hængende tøjstativ i massivt egetræ - Behandlet med sortolie", 2.0 },
                    { 30, null, 26, "/word/hænge_tøjrack.docx", 1, "Ingrid Description", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/Ingrid_Naturolie_1.png", "../images/Products/Gallery/Desktop/Ingrid_Naturolie_2.png", null, "Ingrid Materials", "Ingrid Tøjstativ", "Ingrid Note", "14001", "Naturolie", "Ingrid Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", 1, 2295.0, "Ingrid Size", "Hængende tøjstativ i massivt egetræ - Behandlet med naturolie", 2.0 }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "EColor", "ImgSrc", "ProductId", "ProductSourceId" },
                values: new object[,]
                {
                    { 34, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 12, 10 },
                    { 67, 2, "../images/Products/Color/Desktop/NYKANT_langbaenk_sortolie_02.png", 23, 23 },
                    { 66, 1, "../images/Products/Color/Desktop/NYKANT_langbaenk_hvidolie_02.png", 23, 22 },
                    { 65, 0, "../images/Products/Color/Desktop/NYKANT_langbaenk_naturolie_02.png", 23, 21 },
                    { 64, 2, "../images/Products/Color/Desktop/NYKANT_langbaenk_sortolie_02.png", 22, 23 },
                    { 63, 1, "../images/Products/Color/Desktop/NYKANT_langbaenk_hvidolie_02.png", 22, 22 },
                    { 62, 0, "../images/Products/Color/Desktop/NYKANT_langbaenk_naturolie_02.png", 22, 21 },
                    { 61, 2, "../images/Products/Color/Desktop/NYKANT_langbaenk_sortolie_02.png", 21, 23 },
                    { 60, 1, "../images/Products/Color/Desktop/NYKANT_langbaenk_hvidolie_02.png", 21, 22 },
                    { 59, 0, "../images/Products/Color/Desktop/NYKANT_langbaenk_naturolie_02.png", 21, 21 },
                    { 58, 2, "../images/Products/Color/Desktop/NYKANT_kortbaenk_sortolie_02.png", 20, 20 },
                    { 57, 1, "../images/Products/Color/Desktop/kortbaenk_hvid_2.png", 20, 19 },
                    { 56, 0, "../images/Products/Color/Desktop/kortbaenk_natur_2.png", 20, 18 },
                    { 55, 2, "../images/Products/Color/Desktop/NYKANT_kortbaenk_sortolie_02.png", 19, 20 },
                    { 54, 1, "../images/Products/Color/Desktop/kortbaenk_hvid_2.png", 19, 19 },
                    { 53, 0, "../images/Products/Color/Desktop/kortbaenk_natur_2.png", 19, 18 },
                    { 52, 2, "../images/Products/Color/Desktop/NYKANT_kortbaenk_sortolie_02.png", 18, 20 },
                    { 51, 1, "../images/Products/Color/Desktop/kortbaenk_hvid_2.png", 18, 19 },
                    { 50, 0, "../images/Products/Color/Desktop/kortbaenk_natur_2.png", 18, 18 },
                    { 49, 1, "../images/Products/Color/Desktop/bord_hvid_2.png", 17, 17 },
                    { 48, 0, "../images/Products/Color/Desktop/bord_natur_2.png", 17, 16 },
                    { 47, 1, "../images/Products/Color/Desktop/bord_hvid_2.png", 16, 17 },
                    { 69, 1, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_hvidolie_02.png", 24, 25 },
                    { 70, 2, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_sort_02.png", 24, 26 },
                    { 71, 0, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_naturolie_02.png", 25, 24 },
                    { 72, 1, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_hvidolie_02.png", 25, 25 },
                    { 94, 2, "../images/Products/Color/Desktop/Ingrid_sort_2.png", 32, 32 },
                    { 93, 1, "../images/Products/Color/Desktop/Ingrid_hvid_2.png", 32, 31 },
                    { 92, 0, "../images/Products/Color/Desktop/Ingrid_natur_2.png", 32, 30 },
                    { 91, 2, "../images/Products/Color/Desktop/Ingrid_sort_2.png", 31, 32 },
                    { 90, 1, "../images/Products/Color/Desktop/Ingrid_hvid_2.png", 31, 31 },
                    { 89, 0, "../images/Products/Color/Desktop/Ingrid_natur_2.png", 31, 30 },
                    { 88, 2, "../images/Products/Color/Desktop/Ingrid_sort_2.png", 30, 32 },
                    { 87, 1, "../images/Products/Color/Desktop/Ingrid_hvid_2.png", 30, 31 },
                    { 86, 0, "../images/Products/Color/Desktop/Ingrid_natur_2.png", 30, 30 },
                    { 85, 2, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_sort_02.png", 29, 29 },
                    { 46, 0, "../images/Products/Color/Desktop/bord_natur_2.png", 16, 16 },
                    { 84, 1, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_hvidolie_02.png", 29, 28 },
                    { 82, 2, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_sort_02.png", 28, 29 },
                    { 81, 1, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_hvidolie_02.png", 28, 28 },
                    { 80, 0, "../images/Products/Color/Desktop/NYKANT_rack_naturolie_02.png", 28, 27 },
                    { 79, 2, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_sort_02.png", 27, 29 },
                    { 78, 1, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_hvidolie_02.png", 27, 28 },
                    { 77, 0, "../images/Products/Color/Desktop/NYKANT_rack_naturolie_02.png", 27, 27 },
                    { 76, 2, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_sort_02.png", 26, 26 },
                    { 75, 1, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_hvidolie_02.png", 26, 25 },
                    { 74, 0, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_naturolie_02.png", 26, 24 },
                    { 73, 2, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_sort_02.png", 25, 26 },
                    { 83, 0, "../images/Products/Color/Desktop/NYKANT_rack_naturolie_02.png", 29, 27 },
                    { 45, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 15, 15 },
                    { 68, 0, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_naturolie_02.png", 24, 24 },
                    { 36, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 12, 12 },
                    { 39, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 13, 15 },
                    { 43, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 15, 13 },
                    { 40, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 14, 13 },
                    { 38, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 13, 14 },
                    { 35, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 12, 11 },
                    { 37, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 13, 13 },
                    { 41, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 14, 14 },
                    { 42, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 14, 15 },
                    { 44, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 15, 14 }
                });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 12, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_01.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 12, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 12, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_03.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 13, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_01.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 13, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 13, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_03.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 14, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_01.png" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ImageType", "ProductId", "Size", "Source" },
                values: new object[,]
                {
                    { 89, 0, 27, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_naturolie_02.png" },
                    { 88, 0, 27, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_naturolie_01.png" },
                    { 315, 0, 26, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_06.png" },
                    { 314, 0, 26, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_05.png" },
                    { 312, 0, 26, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_04.png" },
                    { 311, 0, 26, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_03.png" },
                    { 316, 0, 26, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_07.png" },
                    { 90, 0, 27, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_naturolie_03.png" },
                    { 93, 0, 27, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_naturolie_06.png" },
                    { 92, 0, 27, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_naturolie_05.png" },
                    { 310, 0, 26, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_02.png" },
                    { 202, 0, 27, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_01.png" },
                    { 203, 0, 27, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_02.png" },
                    { 204, 0, 27, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_03.png" },
                    { 205, 0, 27, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_04.png" },
                    { 206, 0, 27, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_05.png" },
                    { 207, 0, 27, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_06.png" },
                    { 317, 0, 27, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_naturolie_01.png" },
                    { 318, 0, 27, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_naturolie_02.png" },
                    { 319, 0, 27, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_naturolie_03.png" },
                    { 320, 0, 27, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_naturolie_04.png" },
                    { 91, 0, 27, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_naturolie_04.png" },
                    { 309, 0, 26, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_01.png" },
                    { 198, 0, 26, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_04.png" },
                    { 200, 0, 26, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_06.png" },
                    { 304, 0, 25, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_03.png" },
                    { 303, 0, 25, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_02.png" },
                    { 302, 0, 25, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png" },
                    { 194, 0, 25, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_07.png" },
                    { 193, 0, 25, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_06.png" },
                    { 192, 0, 25, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_05.png" },
                    { 305, 0, 25, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_04.png" },
                    { 191, 0, 25, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_04.png" },
                    { 189, 0, 25, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_02.png" },
                    { 188, 0, 25, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png" },
                    { 80, 0, 25, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_07.png" },
                    { 79, 0, 25, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_06.png" },
                    { 78, 0, 25, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_05.png" },
                    { 77, 0, 25, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_04.png" },
                    { 190, 0, 25, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_03.png" },
                    { 201, 0, 26, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_07.png" },
                    { 306, 0, 25, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_05.png" },
                    { 308, 0, 25, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_07.png" },
                    { 199, 0, 26, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_05.png" },
                    { 197, 0, 26, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_03.png" },
                    { 196, 0, 26, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_02.png" },
                    { 195, 0, 26, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_01.png" },
                    { 87, 0, 26, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_07.png" },
                    { 86, 0, 26, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_06.png" },
                    { 307, 0, 25, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_06.png" },
                    { 85, 0, 26, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_05.png" },
                    { 83, 0, 26, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_03.png" },
                    { 82, 0, 26, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_02.png" },
                    { 81, 0, 26, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_01.png" },
                    { 148, 0, 13, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    { 149, 0, 13, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    { 150, 0, 13, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    { 84, 0, 26, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_04.png" },
                    { 321, 0, 27, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_naturolie_05.png" },
                    { 40, 0, 15, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_01.png" },
                    { 76, 0, 25, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_03.png" },
                    { 261, 0, 12, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_03.png" },
                    { 260, 0, 12, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_02.png" },
                    { 106, 0, 30, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Naturolie_1.png" },
                    { 107, 0, 30, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Naturolie_2.png" },
                    { 108, 0, 30, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Naturolie_3.png" },
                    { 220, 0, 30, 2, "../images/Products/Details_Fullscreen/Desktop/Ingrid_Naturolie_1.png" },
                    { 221, 0, 30, 2, "../images/Products/Details_Fullscreen/Desktop/Ingrid_Naturolie_2.png" },
                    { 222, 0, 30, 2, "../images/Products/Details_Fullscreen/Desktop/Ingrid_Naturolie_3.png" },
                    { 335, 0, 30, 2, "../images/Products/Details_Button/Desktop/Ingrid_Naturolie_1.png" },
                    { 336, 0, 30, 2, "../images/Products/Details_Button/Desktop/Ingrid_Naturolie_2.png" },
                    { 337, 0, 30, 2, "../images/Products/Details_Button/Desktop/Ingrid_Naturolie_3.png" },
                    { 259, 0, 12, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_01.png" },
                    { 147, 0, 12, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_03.png" },
                    { 146, 0, 12, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_02.png" },
                    { 109, 0, 31, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Hvidolie_1.png" },
                    { 110, 0, 31, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Hvidolie_2.png" },
                    { 111, 0, 31, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Hvidolie_3.png" },
                    { 341, 0, 32, 2, "../images/Products/Details_Button/Desktop/Ingrid_Sortolie_1.png" },
                    { 228, 0, 32, 2, "../images/Products/Details_Fullscreen/Desktop/Ingrid_Sortolie_3.png" },
                    { 227, 0, 32, 2, "../images/Products/Details_Fullscreen/Desktop/Ingrid_Sortolie_2.png" },
                    { 226, 0, 32, 2, "../images/Products/Details_Fullscreen/Desktop/Ingrid_Sortolie_1.png" },
                    { 114, 0, 32, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Sortolie_3.png" },
                    { 113, 0, 32, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Sortolie_2.png" },
                    { 334, 0, 29, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_sortolie_06.png" },
                    { 112, 0, 32, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Sortolie_1.png" },
                    { 340, 0, 31, 2, "../images/Products/Details_Button/Desktop/Ingrid_Hvidolie_3.png" },
                    { 339, 0, 31, 2, "../images/Products/Details_Button/Desktop/Ingrid_Hvidolie_2.png" },
                    { 338, 0, 31, 2, "../images/Products/Details_Button/Desktop/Ingrid_Hvidolie_1.png" },
                    { 225, 0, 31, 2, "../images/Products/Details_Fullscreen/Desktop/Ingrid_Hvidolie_3.png" },
                    { 224, 0, 31, 2, "../images/Products/Details_Fullscreen/Desktop/Ingrid_Hvidolie_2.png" },
                    { 223, 0, 31, 2, "../images/Products/Details_Fullscreen/Desktop/Ingrid_Hvidolie_1.png" },
                    { 145, 0, 12, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_01.png" },
                    { 333, 0, 29, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_sortolie_05.png" },
                    { 332, 0, 29, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_sortolie_04.png" },
                    { 331, 0, 29, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_sortolie_03.png" },
                    { 324, 0, 28, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_hvidolie_02.png" },
                    { 323, 0, 28, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_hvidolie_01.png" },
                    { 213, 0, 28, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_06.png" },
                    { 212, 0, 28, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_05.png" },
                    { 211, 0, 28, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_04.png" },
                    { 210, 0, 28, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_03.png" },
                    { 325, 0, 28, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_hvidolie_03.png" },
                    { 209, 0, 28, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_02.png" },
                    { 99, 0, 28, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_hvidolie_06.png" },
                    { 98, 0, 28, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_hvidolie_05.png" },
                    { 97, 0, 28, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_hvidolie_04.png" },
                    { 96, 0, 28, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_hvidolie_03.png" },
                    { 95, 0, 28, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_hvidolie_02.png" },
                    { 94, 0, 28, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_hvidolie_01.png" },
                    { 208, 0, 28, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_01.png" },
                    { 322, 0, 27, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_naturolie_06.png" },
                    { 326, 0, 28, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_hvidolie_04.png" },
                    { 328, 0, 28, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_hvidolie_06.png" },
                    { 330, 0, 29, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_sortolie_02.png" },
                    { 329, 0, 29, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_sortolie_01.png" },
                    { 219, 0, 29, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_06.png" },
                    { 218, 0, 29, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_05.png" },
                    { 217, 0, 29, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_04.png" },
                    { 216, 0, 29, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_03.png" },
                    { 327, 0, 28, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_hvidolie_05.png" },
                    { 215, 0, 29, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_02.png" },
                    { 105, 0, 29, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_sortolie_06.png" },
                    { 104, 0, 29, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_sortolie_05.png" },
                    { 103, 0, 29, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_sortolie_04.png" },
                    { 102, 0, 29, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_sortolie_03.png" },
                    { 101, 0, 29, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_sortolie_02.png" },
                    { 100, 0, 29, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_sortolie_01.png" },
                    { 214, 0, 29, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_01.png" },
                    { 75, 0, 25, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_02.png" },
                    { 263, 0, 13, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    { 262, 0, 13, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    { 164, 0, 18, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_naturolie_02.png" },
                    { 165, 0, 18, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_naturolie_03.png" },
                    { 277, 0, 18, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_naturolie_01.png" },
                    { 278, 0, 18, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_naturolie_02.png" },
                    { 279, 0, 18, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_naturolie_03.png" },
                    { 266, 0, 14, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_02.png" },
                    { 265, 0, 14, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_01.png" },
                    { 153, 0, 14, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_03.png" },
                    { 52, 0, 19, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_hvidolie_01.png" },
                    { 53, 0, 19, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_hvidolie_02.png" },
                    { 54, 0, 19, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_hvidolie_03.png" },
                    { 166, 0, 19, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_hvidolie_01.png" },
                    { 167, 0, 19, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_hvidolie_02.png" },
                    { 168, 0, 19, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_hvidolie_03.png" },
                    { 280, 0, 19, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_hvidolie_01.png" },
                    { 281, 0, 19, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_hvidolie_02.png" },
                    { 282, 0, 19, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_hvidolie_03.png" },
                    { 152, 0, 14, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_02.png" },
                    { 151, 0, 14, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_01.png" },
                    { 39, 0, 14, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_03.png" },
                    { 55, 0, 20, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_sortolie_01.png" },
                    { 56, 0, 20, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_sortolie_02.png" },
                    { 74, 0, 25, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png" },
                    { 169, 0, 20, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_sortolie_01.png" },
                    { 170, 0, 20, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_sortolie_02.png" },
                    { 171, 0, 20, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_sortolie_03.png" },
                    { 283, 0, 20, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_sortolie_01.png" },
                    { 163, 0, 18, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_naturolie_01.png" },
                    { 284, 0, 20, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_sortolie_02.png" },
                    { 51, 0, 18, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_naturolie_03.png" },
                    { 49, 0, 18, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_naturolie_01.png" },
                    { 41, 0, 15, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_02.png" },
                    { 42, 0, 15, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_03.png" },
                    { 154, 0, 15, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_01.png" },
                    { 155, 0, 15, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_02.png" },
                    { 156, 0, 15, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_03.png" },
                    { 268, 0, 15, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_01.png" },
                    { 269, 0, 15, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_02.png" },
                    { 270, 0, 15, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_03.png" },
                    { 43, 0, 16, 2, "../images/Products/Details_Slide/Desktop/NYKANT_bord_naturolie_01.png" },
                    { 44, 0, 16, 2, "../images/Products/Details_Slide/Desktop/NYKANT_bord_naturolie_02.png" },
                    { 45, 0, 16, 2, "../images/Products/Details_Slide/Desktop/NYKANT_bord_naturolie_03.png" },
                    { 157, 0, 16, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_bord_naturolie_01.png" },
                    { 158, 0, 16, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_bord_naturolie_02.png" },
                    { 159, 0, 16, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_bord_naturolie_03.png" },
                    { 271, 0, 16, 2, "../images/Products/Details_Button/Desktop/NYKANT_bord_naturolie_01.png" },
                    { 272, 0, 16, 2, "../images/Products/Details_Button/Desktop/NYKANT_bord_naturolie_02.png" },
                    { 273, 0, 16, 2, "../images/Products/Details_Button/Desktop/NYKANT_bord_naturolie_03.png" },
                    { 46, 0, 17, 2, "../images/Products/Details_Slide/Desktop/NYKANT_bord_hvidolie_01.png" },
                    { 47, 0, 17, 2, "../images/Products/Details_Slide/Desktop/NYKANT_bord_hvidolie_02.png" },
                    { 48, 0, 17, 2, "../images/Products/Details_Slide/Desktop/NYKANT_bord_hvidolie_03.png" },
                    { 160, 0, 17, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_bord_hvidolie_01.png" },
                    { 161, 0, 17, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_bord_hvidolie_02.png" },
                    { 162, 0, 17, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_bord_hvidolie_03.png" },
                    { 274, 0, 17, 2, "../images/Products/Details_Button/Desktop/NYKANT_bord_hvidolie_01.png" },
                    { 275, 0, 17, 2, "../images/Products/Details_Button/Desktop/NYKANT_bord_hvidolie_02.png" },
                    { 276, 0, 17, 2, "../images/Products/Details_Button/Desktop/NYKANT_bord_hvidolie_03.png" },
                    { 267, 0, 14, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_03.png" },
                    { 50, 0, 18, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_naturolie_02.png" },
                    { 285, 0, 20, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_sortolie_03.png" },
                    { 57, 0, 20, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_sortolie_03.png" },
                    { 292, 0, 23, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_sortolie_01.png" },
                    { 66, 0, 23, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_sortolie_03.png" },
                    { 178, 0, 23, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_sortolie_01.png" },
                    { 179, 0, 23, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_sortolie_02.png" },
                    { 180, 0, 23, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_sortolie_03.png" },
                    { 38, 0, 14, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_02.png" },
                    { 293, 0, 23, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_sortolie_02.png" },
                    { 294, 0, 23, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_sortolie_03.png" },
                    { 342, 0, 32, 2, "../images/Products/Details_Button/Desktop/Ingrid_Sortolie_2.png" },
                    { 67, 0, 24, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png" },
                    { 68, 0, 24, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_02.png" },
                    { 69, 0, 24, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_03.png" },
                    { 70, 0, 24, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_04.png" },
                    { 71, 0, 24, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_05.png" },
                    { 72, 0, 24, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_06.png" },
                    { 65, 0, 23, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_sortolie_02.png" },
                    { 73, 0, 24, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_07.png" },
                    { 182, 0, 24, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_02.png" },
                    { 183, 0, 24, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_03.png" },
                    { 184, 0, 24, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_04.png" },
                    { 185, 0, 24, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_05.png" },
                    { 186, 0, 24, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_06.png" },
                    { 187, 0, 24, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_07.png" },
                    { 295, 0, 24, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png" },
                    { 296, 0, 24, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_02.png" },
                    { 297, 0, 24, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_03.png" },
                    { 298, 0, 24, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_04.png" },
                    { 299, 0, 24, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_05.png" },
                    { 300, 0, 24, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_06.png" },
                    { 301, 0, 24, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_07.png" },
                    { 264, 0, 13, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    { 181, 0, 24, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png" },
                    { 64, 0, 23, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_sortolie_01.png" },
                    { 343, 0, 32, 2, "../images/Products/Details_Button/Desktop/Ingrid_Sortolie_3.png" },
                    { 288, 0, 21, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_naturolie_03.png" },
                    { 62, 0, 22, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_hvidolie_02.png" },
                    { 177, 0, 22, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_hvidolie_03.png" },
                    { 176, 0, 22, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_hvidolie_02.png" },
                    { 61, 0, 22, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_hvidolie_01.png" },
                    { 63, 0, 22, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_hvidolie_03.png" },
                    { 287, 0, 21, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_naturolie_02.png" },
                    { 286, 0, 21, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_naturolie_01.png" },
                    { 174, 0, 21, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_naturolie_03.png" },
                    { 173, 0, 21, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_naturolie_02.png" },
                    { 172, 0, 21, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_naturolie_01.png" },
                    { 291, 0, 22, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_hvidolie_03.png" },
                    { 60, 0, 21, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_naturolie_03.png" },
                    { 59, 0, 21, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_naturolie_02.png" },
                    { 58, 0, 21, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_naturolie_01.png" },
                    { 175, 0, 22, 2, "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_hvidolie_01.png" },
                    { 290, 0, 22, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_hvidolie_02.png" },
                    { 289, 0, 22, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_hvidolie_01.png" }
                });

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ProductId", "ProductReferenceId" },
                values: new object[] { 18, 18 });

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ProductId", "ProductReferenceId" },
                values: new object[] { 18, 21 });

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ProductId", "ProductReferenceId" },
                values: new object[] { 19, 18 });

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ProductId", "ProductReferenceId" },
                values: new object[] { 19, 21 });

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Length", "ProductId", "ProductReferenceId" },
                values: new object[] { "1150 mm.", 20, 18 });

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Length", "ProductId", "ProductReferenceId" },
                values: new object[] { "1700 mm.", 20, 21 });

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Length", "ProductId", "ProductReferenceId" },
                values: new object[] { "1150 mm.", 21, 18 });

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Length", "ProductId", "ProductReferenceId" },
                values: new object[] { "1700 mm.", 21, 21 });

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Length", "ProductId", "ProductReferenceId" },
                values: new object[] { "1150 mm.", 22, 18 });

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Length", "ProductId", "ProductReferenceId" },
                values: new object[] { "1700 mm.", 22, 21 });

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Length", "ProductId", "ProductReferenceId" },
                values: new object[] { "1150 mm.", 23, 18 });

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Length", "ProductId", "ProductReferenceId" },
                values: new object[] { "1700 mm.", 23, 21 });

            migrationBuilder.InsertData(
                table: "ProductLength",
                columns: new[] { "Id", "Length", "ProductId", "ProductReferenceId" },
                values: new object[,]
                {
                    { 49, "400 mm.", 13, 6 },
                    { 51, "800 mm.", 13, 12 },
                    { 52, "1000 mm.", 13, 15 },
                    { 46, "600 mm.", 12, 9 },
                    { 47, "800 mm.", 12, 12 },
                    { 53, "400 mm.", 14, 6 },
                    { 58, "600 mm.", 15, 9 },
                    { 55, "800 mm.", 14, 12 },
                    { 59, "800 mm.", 15, 12 },
                    { 60, "1000 mm.", 15, 15 },
                    { 45, "400 mm.", 12, 6 },
                    { 54, "600 mm.", 14, 9 },
                    { 48, "1000 mm.", 12, 15 },
                    { 50, "600 mm.", 13, 9 },
                    { 57, "400 mm.", 15, 6 },
                    { 56, "1000 mm.", 14, 15 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 38);

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

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 263);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 264);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 265);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 269);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 270);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 271);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 272);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 274);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 285);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 291);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 293);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 294);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 295);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 297);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 298);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 299);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 314);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 315);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 316);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 317);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 318);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 319);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 320);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 321);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 322);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 323);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 324);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 325);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 326);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 327);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 328);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 329);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 330);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 331);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 332);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 333);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 334);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 335);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 336);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 337);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 338);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 339);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 340);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 341);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 342);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 343);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgSource",
                value: "../images/Products/NYKANT_rack_naturolie_02.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImgSource",
                value: "../images/Products/NYKANT_bord_naturolie_02.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImgSource",
                value: "../images/Products/NYKANT_hylde_naturolie_01.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImgSource",
                value: "../images/Products/NYKANT_opbevaringsbaenk_naturolie_03.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImgSource",
                value: "../images/Products/NYKANT_boejle_naturolie_01.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgSrc",
                value: "../images/Products/NYKANT_boejle_naturolie_01.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImgSrc",
                value: "../images/Products/NYKANT_boejle_sortolie_01.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImgSrc",
                value: "../images/Products/NYKANT_boejle_hvidolie_01.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImgSrc",
                value: "../images/Products/NYKANT_boejle_naturolie_01.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImgSrc",
                value: "../images/Products/NYKANT_boejle_sortolie_01.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImgSrc",
                value: "../images/Products/NYKANT_boejle_hvidolie_01.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImgSrc",
                value: "../images/Products/NYKANT_boejle_naturolie_01.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImgSrc",
                value: "../images/Products/NYKANT_boejle_sortolie_01.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImgSrc",
                value: "../images/Products/NYKANT_boejle_hvidolie_01.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImgSrc",
                value: "../images/Products/NYKANT_hylde_hvidolie_01.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImgSrc",
                value: "../images/Products/NYKANT_hylde_sortolie_01.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImgSrc",
                value: "../images/Products/NYKANT_hylde_naturolie_01.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImgSrc",
                value: "../images/Products/NYKANT_hylde_hvidolie_01.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImgSrc",
                value: "../images/Products/NYKANT_hylde_sortolie_01.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImgSrc",
                value: "../images/Products/NYKANT_hylde_naturolie_01.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImgSrc",
                value: "../images/Products/NYKANT_hylde_hvidolie_01.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImgSrc",
                value: "../images/Products/NYKANT_hylde_sortolie_01.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImgSrc",
                value: "../images/Products/NYKANT_hylde_naturolie_01.png");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "EColor", "ImgSrc" },
                values: new object[] { 0, "../images/Products/NYKANT_bord_naturolie_01.png" });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "EColor", "ImgSrc", "ProductId" },
                values: new object[] { 0, "../images/Products/NYKANT_kortbaenk_naturolie_01.png", 8 });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ImgSrc", "ProductId" },
                values: new object[] { "../images/Products/NYKANT_langbaenk_naturolie_01.png", 9 });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "EColor", "ImgSrc", "ProductId", "ProductSourceId" },
                values: new object[] { 0, "../images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", 10, 10 });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "EColor", "ImgSrc", "ProductId", "ProductSourceId" },
                values: new object[] { 0, "../images/Products/NYKANT_rack_naturolie_01.png", 11, 11 });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 3, 0, "../images/Products/NYKANT_boejle_hvidolie_01.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 3, 0, "../images/Products/NYKANT_boejle_hvidolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 1, 0, "../images/Products/NYKANT_boejle_naturolie_01.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 1, 0, "../images/Products/NYKANT_boejle_naturolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 2, 0, "../images/Products/NYKANT_boejle_sortolie_01.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 2, 0, "../images/Products/NYKANT_boejle_sortolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 7, 0, "../images/Products/NYKANT_bord_naturolie_01.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 7, 0, "../images/Products/NYKANT_bord_naturolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 7, 0, "../images/Products/NYKANT_bord_naturolie_03.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 4, 0, "../images/Products/NYKANT_hylde_hvidolie_01.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 4, 0, "../images/Products/NYKANT_hylde_hvidolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 4, 0, "../images/Products/NYKANT_hylde_hvidolie_03.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Size", "Source" },
                values: new object[] { 0, "../images/Products/NYKANT_hylde_naturolie_01.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Size", "Source" },
                values: new object[] { 0, "../images/Products/NYKANT_hylde_naturolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Size", "Source" },
                values: new object[] { 0, "../images/Products/NYKANT_hylde_naturolie_03.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 5, 0, "../images/Products/NYKANT_hylde_sortolie_01.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 5, 0, "../images/Products/NYKANT_hylde_sortolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 5, 0, "../images/Products/NYKANT_hylde_sortolie_03.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Size", "Source" },
                values: new object[] { 0, "../images/Products/NYKANT_kortbaenk_naturolie_01.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Size", "Source" },
                values: new object[] { 0, "../images/Products/NYKANT_kortbaenk_naturolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Size", "Source" },
                values: new object[] { 0, "../images/Products/NYKANT_kortbaenk_naturolie_03.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Size", "Source" },
                values: new object[] { 0, "../images/Products/NYKANT_langbaenk_naturolie_01.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Size", "Source" },
                values: new object[] { 0, "../images/Products/NYKANT_langbaenk_naturolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Size", "Source" },
                values: new object[] { 0, "../images/Products/NYKANT_langbaenk_naturolie_03.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Size", "Source" },
                values: new object[] { 0, "../images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Size", "Source" },
                values: new object[] { 0, "../images/Products/NYKANT_opbevaringsbaenk_naturolie_02.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Size", "Source" },
                values: new object[] { 0, "../images/Products/NYKANT_opbevaringsbaenk_naturolie_03.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 10, 0, "../images/Products/NYKANT_opbevaringsbaenk_naturolie_04.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 10, 0, "../images/Products/NYKANT_opbevaringsbaenk_naturolie_05.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ProductId", "Size", "Source" },
                values: new object[] { 10, 0, "../images/Products/NYKANT_opbevaringsbaenk_naturolie_06.png" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ImageType", "ProductId", "Size", "Source" },
                values: new object[,]
                {
                    { 32, 0, 11, 0, "../images/Products/NYKANT_rack_naturolie_01.png" },
                    { 36, 0, 11, 0, "../images/Products/NYKANT_rack_naturolie_05.png" },
                    { 31, 0, 10, 0, "../images/Products/NYKANT_opbevaringsbaenk_naturolie_07.png" },
                    { 34, 0, 11, 0, "../images/Products/NYKANT_rack_naturolie_03.png" },
                    { 35, 0, 11, 0, "../images/Products/NYKANT_rack_naturolie_04.png" },
                    { 33, 0, 11, 0, "../images/Products/NYKANT_rack_naturolie_02.png" },
                    { 37, 0, 11, 0, "../images/Products/NYKANT_rack_naturolie_06.png" }
                });

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 13,
                column: "ProductId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ProductId", "ProductReferenceId" },
                values: new object[] { 6, 6 });

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ProductId", "ProductReferenceId" },
                values: new object[] { 6, 6 });

            migrationBuilder.UpdateData(
                table: "ProductLength",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ProductId", "ProductReferenceId" },
                values: new object[] { 6, 6 });

            migrationBuilder.InsertData(
                table: "ProductLength",
                columns: new[] { "Id", "Length", "ProductId", "ProductReferenceId" },
                values: new object[,]
                {
                    { 1, "1150 mm.", 8, 8 },
                    { 11, "800 mm.", 5, 6 },
                    { 2, "1700 mm.", 8, 9 },
                    { 3, "1150 mm.", 9, 8 },
                    { 4, "1700 mm.", 9, 9 },
                    { 12, "1000 mm.", 5, 6 },
                    { 10, "600 mm.", 5, 6 },
                    { 5, "400 mm.", 4, 6 },
                    { 8, "1000 mm.", 4, 6 },
                    { 7, "800 mm.", 4, 6 },
                    { 6, "600 mm.", 4, 6 },
                    { 9, "400 mm.", 5, 6 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GalleryImage1", "GalleryImage2", "Number" },
                values: new object[] { "../images/Products/NYKANT_boejle_naturolie_01.png", "../images/Products/NYKANT_boejle_naturolie_02.png", "101" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "GalleryImage1", "GalleryImage2", "Number" },
                values: new object[] { "../images/Products/NYKANT_boejle_sortolie_01.png", "../images/Products/NYKANT_boejle_sortolie_02.png", "101" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "GalleryImage1", "GalleryImage2", "Number" },
                values: new object[] { "../images/Products/NYKANT_boejle_hvidolie_01.png", "../images/Products/NYKANT_boejle_hvidolie_02.png", "101" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "GalleryImage1", "GalleryImage2", "Length", "Number", "Package", "Size" },
                values: new object[] { "Ingeborg Description", "../images/Products/NYKANT_hylde_hvidolie_01.png", "../images/Products/NYKANT_hylde_hvidolie_02.png", "600 mm.", "101", "Ingeborg Package", "Ingeborg Size" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "GalleryImage1", "GalleryImage2", "Length", "Number", "Package", "Size" },
                values: new object[] { "../images/Products/NYKANT_hylde_sortolie_01.png", "../images/Products/NYKANT_hylde_sortolie_02.png", "600 mm.", "101", "Ingeborg Package", "Ingeborg Size" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "GalleryImage1", "GalleryImage2", "Length", "Number", "Package", "Size" },
                values: new object[] { "../images/Products/NYKANT_hylde_naturolie_01.png", "../images/Products/NYKANT_hylde_naturolie_02.png", "600 mm.", "101", "Ingeborg Package", "Ingeborg Size" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Amount", "AssemblyPath", "CategoryId", "Description", "EColor", "ExpectedDelivery", "GalleryImage1", "GalleryImage2", "Length", "Materials", "Name", "Note", "Number", "Oil", "Package", "Path", "Price", "Size", "Title", "WeightInKg" },
                values: new object[] { 72, "/word/Bord.docx", 2, "Dagmar Description", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/NYKANT_bord_naturolie_01.png", "../images/Products/NYKANT_bord_naturolie_02.png", null, "Dagmar Materials", "Dagmar Bordet", "Dagmar Note", "16001", "Naturolie", "Dagmar Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_bord_naturolie_01.png", 2995.0, "Dagmar Size", "Bord i massivt egetræ - Behandlet med naturolie", 22.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Amount", "AssemblyPath", "CategoryId", "Description", "EColor", "ExpectedDelivery", "GalleryImage1", "GalleryImage2", "Length", "Materials", "Name", "Note", "Number", "Oil", "Package", "Path", "Price", "Size", "Title", "WeightInKg" },
                values: new object[] { 42, "/word/bænk.docx", 4, "Thyra Short Description", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/NYKANT_kortbaenk_naturolie_01.png", "../images/Products/NYKANT_kortbaenk_naturolie_02.png", "1150 mm.", "Thyra Short Materials", "Thyra Bænken", "Thyra Short Note", "12001", "Naturolie", "Thyra Short Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_kortbaenk_naturolie_01.png", 2985.0, "Thyra Short Size", "Bænk i massivt egetræ - Behandlet med naturolie", 14.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Amount", "AssemblyPath", "CategoryId", "Description", "ExpectedDelivery", "GalleryImage1", "GalleryImage2", "Length", "Materials", "Name", "Note", "Number", "Package", "Path", "Price", "Size", "Title", "WeightInKg" },
                values: new object[] { 17, "/word/bænk.docx", 4, "Thyra Description", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/NYKANT_langbaenk_naturolie_01.png", "../images/Products/NYKANT_langbaenk_naturolie_02.png", "1700 mm.", "Thyra Materials", "Thyra Bænken", "Thyra Note", "11001", "Thyra Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_langbaenk_naturolie_01.png", 3885.0, "Thyra Size", "Bænk i massivt egetræ - Behandlet med naturolie", 20.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Amount", "AssemblyPath", "CategoryId", "Description", "EColor", "ExpectedDelivery", "GalleryImage1", "GalleryImage2", "Length", "Materials", "Name", "Note", "Number", "Oil", "Package", "Path", "Price", "Size", "Title", "WeightInKg" },
                values: new object[] { 50, "none", 4, "Filippa Description", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", "../images/Products/NYKANT_opbevaringsbaenk_naturolie_02.png", null, "Filippa Materials", "Filippa Bænk", "Filippa Note", "10001", "Naturolie", "Filippa Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", 4395.0, "Filippa Size", "Opbevaringsbænk i massivt egetræ - Behandlet med naturolie", 24.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Amount", "AssemblyPath", "CategoryId", "Description", "EColor", "ExpectedDelivery", "GalleryImage1", "GalleryImage2", "Length", "Materials", "Name", "Note", "Number", "Oil", "Package", "Path", "Price", "Size", "Title", "WeightInKg" },
                values: new object[] { 26, "/word/Tøjstativ.docx", 1, "Nora Description", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/NYKANT_rack_naturolie_01.png", "../images/Products/NYKANT_rack_naturolie_02.png", null, "Nora Materials", "Nora Tøjstativ", "Nora Note", "13001 + 13001A", "Naturolie", "Nora Package", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", 2295.0, "Nora Size", "Tøjstativ i massivt egetræ - Behandlet med naturolie", 8.0 });
        }
    }
}
