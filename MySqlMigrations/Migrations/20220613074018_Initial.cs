using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySqlMigrations.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ImgSource = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IPAddress = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    ConsentText = table.Column<string>(nullable: true),
                    How = table.Column<int>(nullable: false),
                    ButtonText = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cookies",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Type1 = table.Column<int>(nullable: false),
                    Type2 = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    Domain = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cookies", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    Discount = table.Column<int>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    ForAllProducts = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsSubs",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsSubs", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    UrlName = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<long>(nullable: false),
                    GalleryImage1 = table.Column<string>(nullable: true),
                    GalleryImage2 = table.Column<string>(nullable: true),
                    Pieces = table.Column<int>(nullable: false),
                    Path = table.Column<string>(nullable: true),
                    ExpectedDelivery = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    AssemblyPath = table.Column<string>(nullable: true),
                    EColor = table.Column<int>(nullable: false),
                    Length = table.Column<string>(nullable: true),
                    Discount = table.Column<int>(nullable: false),
                    Oil = table.Column<string>(nullable: true),
                    Alt = table.Column<string>(nullable: true),
                    WeightInKg = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    Materials = table.Column<string>(nullable: true),
                    Package = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillingAddress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    Postal = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillingAddress_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentCaptures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PaymentIntent_Id = table.Column<string>(nullable: true),
                    Captured = table.Column<bool>(nullable: false),
                    Refunded = table.Column<bool>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentCaptures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentCaptures_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShippingAddress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    Postal = table.Column<string>(nullable: false),
                    SameAsBilling = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingAddress_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BagItems",
                columns: table => new
                {
                    Subject = table.Column<string>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BagItems", x => new { x.Subject, x.ProductId });
                    table.ForeignKey(
                        name: "FK_BagItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: false),
                    ImgSrc = table.Column<string>(nullable: true),
                    ProductSourceId = table.Column<int>(nullable: false),
                    ProductSourceUrlName = table.Column<string>(nullable: true),
                    EColor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colors_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CouponForProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CouponCode = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponForProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CouponForProducts_Coupons_CouponCode",
                        column: x => x.CouponCode,
                        principalTable: "Coupons",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CouponForProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Source = table.Column<string>(nullable: true),
                    Source2 = table.Column<string>(nullable: true),
                    ImageType = table.Column<int>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductLength",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: false),
                    ProductReferenceId = table.Column<int>(nullable: false),
                    ProductReferenceUrlName = table.Column<string>(nullable: true),
                    Length = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLength", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductLength_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: false),
                    Subject = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: false),
                    Stars = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    PaymentCaptureId = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<string>(nullable: true),
                    Taxes = table.Column<string>(nullable: true),
                    TaxLessPrice = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_PaymentCaptures_PaymentCaptureId",
                        column: x => x.PaymentCaptureId,
                        principalTable: "PaymentCaptures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<string>(nullable: false),
                    Taxes = table.Column<string>(nullable: false),
                    TaxLessPrice = table.Column<string>(nullable: false),
                    Currency = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Discount = table.Column<string>(nullable: true),
                    WeightInKg = table.Column<double>(nullable: false),
                    CouponCode = table.Column<string>(nullable: true),
                    EstimatedDelivery = table.Column<DateTime>(nullable: false),
                    PaymentCaptureId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_PaymentCaptures_PaymentCaptureId",
                        column: x => x.PaymentCaptureId,
                        principalTable: "PaymentCaptures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Refunds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<int>(nullable: false),
                    ReturnFee = table.Column<int>(nullable: false),
                    QualityFee = table.Column<int>(nullable: false),
                    Products = table.Column<string>(nullable: true),
                    PaymentCaptureId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refunds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Refunds_PaymentCaptures_PaymentCaptureId",
                        column: x => x.PaymentCaptureId,
                        principalTable: "PaymentCaptures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Price = table.Column<long>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShippingDeliveries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingDeliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingDeliveries_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImgSource", "Name" },
                values: new object[,]
                {
                    { 1, "../images/Products/Category/Desktop/ingrid_natur_2.png", "Tøjstativer" },
                    { 2, "../images/Products/Category/Desktop/bord_natur_2.png", "Borde" },
                    { 3, "../images/Products/Category/Desktop/hylde_natur_1.png", "Hylder" },
                    { 4, "../images/Products/Category/Desktop/opbevaringsbaenk_natur_3.png", "Bænke" },
                    { 5, "../images/Products/Category/Desktop/boejle_natur_1.png", "Bøjler" }
                });

            migrationBuilder.InsertData(
                table: "Cookies",
                columns: new[] { "Name", "Category", "Description", "Domain", "Type1", "Type2" },
                values: new object[,]
                {
                    { "AntiforgeryToken", 0, "Denne cookie beskytter imod Cross-Site Request Forgery angreb", ".nykant.dk", 0, 0 },
                    { "Session", 0, "Session cookie'en gemmer et session id, som den bruger til at hente data fra session i serveren, som husker/gemmer hvad du har lagt i din kurv, gemmer dine cookie preferencer, samt giver dig en bedre checkout oplevelse.", "nykant.dk", 0, 0 },
                    { "_ga", 3, "Indsamler anonyme data om hvad du foretager dig på hjemmesiden, og sender det til google analytics, så vi kan bruge det til at forbedre hjemmesiden.", ".nykant.dk", 1, 0 },
                    { "_ga_*", 3, "Indsamler anonyme data om hvad du foretager dig på hjemmesiden, og sender det til google analytics, så vi kan bruge det til at forbedre hjemmesiden.", ".nykant.dk", 1, 0 },
                    { "__stripe_mid", 0, "Sørger for sikkerhed under betalingen via vores betalingsservice stripe. Forebygger imod svig/forfalskning. Nødvendig for at betaling kan fungere.", ".nykant.dk", 1, 0 },
                    { "__stripe_sid", 0, "Sørger for sikkerhed under betalingen via vores betalingsservice stripe. Forebygger imod svig/forfalskning. Nødvendig for at betaling kan fungere.", ".nykant.dk", 1, 0 },
                    { "m", 0, "Sørger for sikkerhed under betalingen via vores betalingsservice stripe. Forebygger imod svig/forfalskning. Nødvendig for at betaling kan fungere.", "m.stripe.com", 1, 1 },
                    { "private_machine_identifier", 0, "Sørger for sikkerhed under betalingen via vores betalingsservice stripe. Forebygger imod svig/forfalskning. Nødvendig for at betaling kan fungere.", "stripe.com", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Alt", "Amount", "AssemblyPath", "CategoryId", "Description", "Discount", "EColor", "ExpectedDelivery", "GalleryImage1", "GalleryImage2", "Length", "Materials", "Name", "Note", "Number", "Oil", "Package", "Path", "Pieces", "Price", "Size", "Title", "UrlName", "WeightInKg" },
                values: new object[,]
                {
                    { 27, null, 26, "/word/Tøjstativ.docx", 1, "Nora er vores bedste svar på minimalisme. Ingen skruer, ingen beslag, ingen metal. Nora er så naturlig som muligt. Nora består udelukkende af massivt egetræ, som samles via trækiler man bare skubber i, og så står det robust og elegant. Bøjlestangen og underdelen, er fræset i enderne så kilerne passer igennem. Designet med trækiler giver Nora et unikt og naturligt look, som giver øjnene varme og sjælen ro.", 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_rack_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_rack_naturolie_02.png", null, "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Kiler</p></td></tr>", "Nora Tøjstativ", null, "13001 + 13001A", "Naturolie", "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Leveres usamlet i 2 kartoner - se samlevejledning</p></td></tr><tr class='no-border'><td class='width-30'><strong>Karton 1</strong></td><td> <p>Vægt: 5 kg.</p><p> Størrelse: 6.5 x 11.5 x 186 cm. (H x B x L)</p></td></tr><tr><td class='width-30'><strong>Karton 2</strong></td><td> <p>Vægt: 3 kg.</p><p>Størrelse: 5.5 x 54 x 119 cm. (H x B x L)</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", 1, 2595L, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Højde: 180 cm.</p><p>Længde: 100 cm.</p><p>Bredde: 55 cm.</p></td></tr>", "Tøjstativ i massivt egetræ - Behandlet med naturolie", "Tøjstativ-Egetræ-Naturolie", "8" },
                    { 1, null, 420, "none", 5, "En smuk bøjle i massivt egetræ med afrundede hjørner, som er bløde, og skåner tøjet. Gertrud har også fået en lille blød nedrunding til tøj med stropper, så den kan klare hvad som helst.", 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_boejle_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_boejle_naturolie_02.png", null, "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Sort bøjlekrog</p></td></tr>", "Bøjlen Gertrud / 3 stk.", null, "15001", "Naturolie", "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 47x17x6 cm. (L x B x H)</p><p>Vægt: 0.6 kg.</p><p>Leveres samlet med 3 stk. pr. karton</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_boejle_naturolie_01.png", 3, 420L, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Tykkelse: 2 cm.</p><p>Længde: 45 cm.</p></td></tr>", "Bøjle i massivt egetræ - Behandlet med naturolie", "Bøjle-Egetræ-Naturolie", "0.6" },
                    { 26, null, 20, "none", 4, "Filippa er en smuk og praktisk opbevaringsbænk lavet i massivt egetræ, med drejede ben som er synlige op igennem sædet. Bænken har et flot læderhåndtag til at åbne opbevaringsrummet, som er stort og kan bruges til hvad som helst. Filippa er også meget robust og stabil, så man skal ikke være bange for at lægge vægt på. Fås i 3 forskellige overfladebehandlinger, og vil passe ind i alle hjem.", 0, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_opbevaringsbaenk_sort_01.png", "../images/Products/Gallery/Desktop/NYKANT_opbevaringsbaenk_sort_02.png", null, "<tr><td class='width-30'><strong>Materialer:</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Læderstrop</p><p>Beslag </p></td></tr>", "Filippa Bænk", "<tr class='no-border'><td class='width-30'><strong>Note:</strong></td><td><p>Indvendige mål for opbevaring: 30 x 30 x 85 cm</p></td></tr>", "10003", "Sortolie", "<tr><td class='width-30'><strong>Pakken:</strong></td><td><p>Vægt: 24 kg.</p><p>Størrelse: 40 x 50 x 115 cm. (B x H x L)</p><p>Leveres samlet </p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", 1, 4985L, "<tr><td class='width-30'><strong>Størrelse:</strong></td><td><p>Højde: 45 cm.</p><p>Længde: 110 cm.</p><p>Dybde: 35 cm. </p></td></tr>", "Opbevaringsbænk i massivt egetræ - Behandlet med sortolie", "Opbevaringsbænk-Egetræ-Sortolie", "24" },
                    { 25, null, 30, "none", 4, "Filippa er en smuk og praktisk opbevaringsbænk lavet i massivt egetræ, med drejede ben som er synlige op igennem sædet. Bænken har et flot læderhåndtag til at åbne opbevaringsrummet, som er stort og kan bruges til hvad som helst. Filippa er også meget robust og stabil, så man skal ikke være bange for at lægge vægt på. Fås i 3 forskellige overfladebehandlinger, og vil passe ind i alle hjem.", 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_opbevaringsbaenk_hvidolie_02.png", null, "<tr><td class='width-30'><strong>Materialer:</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Læderstrop</p><p>Beslag </p></td></tr>", "Filippa Bænk", "<tr class='no-border'><td class='width-30'><strong>Note:</strong></td><td><p>Indvendige mål for opbevaring: 30 x 30 x 85 cm</p></td></tr>", "10002", "Hvidolie", "<tr><td class='width-30'><strong>Pakken:</strong></td><td><p>Vægt: 24 kg.</p><p>Størrelse: 40 x 50 x 115 cm. (B x H x L)</p><p>Leveres samlet </p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", 1, 4985L, "<tr><td class='width-30'><strong>Størrelse:</strong></td><td><p>Højde: 45 cm.</p><p>Længde: 110 cm.</p><p>Dybde: 35 cm. </p></td></tr>", "Opbevaringsbænk i massivt egetræ - Behandlet med hvidolie", "Opbevaringsbænk-Egetræ-Hvidolie", "24" },
                    { 24, null, 50, "none", 4, "Filippa er en smuk og praktisk opbevaringsbænk lavet i massivt egetræ, med drejede ben som er synlige op igennem sædet. Bænken har et flot læderhåndtag til at åbne opbevaringsrummet, som er stort og kan bruges til hvad som helst. Filippa er også meget robust og stabil, så man skal ikke være bange for at lægge vægt på. Fås i 3 forskellige overfladebehandlinger, og vil passe ind i alle hjem.", 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_opbevaringsbaenk_naturolie_02.png", null, "<tr><td class='width-30'><strong>Materialer:</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Læderstrop</p><p>Beslag </p></td></tr>", "Filippa Bænk", "<tr class='no-border'><td class='width-30'><strong>Note:</strong></td><td><p>Indvendige mål for opbevaring: 30 x 30 x 85 cm</p></td></tr>", "10001", "Naturolie", "<tr><td class='width-30'><strong>Pakken:</strong></td><td><p>Vægt: 24 kg.</p><p>Størrelse: 40 x 50 x 115 cm. (B x H x L)</p><p>Leveres samlet </p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", 1, 4985L, "<tr><td class='width-30'><strong>Størrelse:</strong></td><td><p>Højde: 45 cm.</p><p>Længde: 110 cm.</p><p>Dybde: 35 cm. </p></td></tr>", "Opbevaringsbænk i massivt egetræ - Behandlet med naturolie", "Opbevaringsbænk-Egetræ-Naturolie", "24" },
                    { 23, null, 5, "/word/bænk.docx", 4, "Thyra er en meget elegant og robust bænk at se på. De afrundede hjørner, og drejede ben, som går op igennem sædet og gør sig synlige, giver Thyra det unikke look som det fortjener. Bygget i den bedste kvalitet af massivt egetræ, fås det i 3 forskellige overfladebehandlinger og 2 størrrelse, så det kan passe ind i hvilket som helst hjem.", 0, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_langbaenk_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_langbaenk_sortolie_02.png", "170 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p></td></tr>", "Lang Thyra Bænk", null, "11003", "Sortolie", "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 11 x 47 x 175 cm. (H x B x L)</p><p>Vægt: 20 kg.</p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_langbaenk_naturolie_01.png", 1, 4395L, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Højde: 47 cm.</p><p>Længde: 170 cm.</p><p>Bredde: 40 cm.</p></td></tr>", "Bænk i massivt egetræ - Behandlet med sortolie", "Bænk-Egetræ-Sortolie-170cm", "20" },
                    { 22, null, 10, "/word/bænk.docx", 4, "Thyra er en meget elegant og robust bænk at se på. De afrundede hjørner, og drejede ben, som går op igennem sædet og gør sig synlige, giver Thyra det unikke look som det fortjener. Bygget i den bedste kvalitet af massivt egetræ, fås det i 3 forskellige overfladebehandlinger og 2 størrrelse, så det kan passe ind i hvilket som helst hjem.", 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_langbaenk_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_langbaenk_hvidolie_02.png", "170 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p></td></tr>", "Lang Thyra Bænk", null, "11002", "Hvidolie", "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 11 x 47 x 175 cm. (H x B x L)</p><p>Vægt: 20 kg.</p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_langbaenk_naturolie_01.png", 1, 4395L, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Højde: 47 cm.</p><p>Længde: 170 cm.</p><p>Bredde: 40 cm.</p></td></tr>", "Bænk i massivt egetræ - Behandlet med hvidolie", "Bænk-Egetræ-Hvidolie-170cm", "20" },
                    { 21, null, 17, "/word/bænk.docx", 4, "Thyra er en meget elegant og robust bænk at se på. De afrundede hjørner, og drejede ben, som går op igennem sædet og gør sig synlige, giver Thyra det unikke look som det fortjener. Bygget i den bedste kvalitet af massivt egetræ, fås det i 3 forskellige overfladebehandlinger og 2 størrrelse, så det kan passe ind i hvilket som helst hjem.", 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_langbaenk_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_langbaenk_naturolie_02.png", "170 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p></td></tr>", "Lang Thyra Bænk", null, "11001", "Naturolie", "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 11 x 47 x 175 cm. (H x B x L)</p><p>Vægt: 20 kg.</p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_langbaenk_naturolie_01.png", 1, 4395L, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Højde: 47 cm.</p><p>Længde: 170 cm.</p><p>Bredde: 40 cm.</p></td></tr>", "Bænk i massivt egetræ - Behandlet med naturolie", "Bænk-Egetræ-Naturolie-170cm", "20" },
                    { 20, null, 10, "/word/bænk.docx", 4, "Thyra er en meget elegant og robust bænk at se på. De afrundede hjørner, og drejede ben, som går op igennem sædet og gør sig synlige, giver Thyra det unikke look som det fortjener. Bygget i den bedste kvalitet af massivt egetræ, fås det i 3 forskellige overfladebehandlinger og 2 størrrelse, så det kan passe ind i hvilket som helst hjem.", 0, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_kortbaenk_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_kortbaenk_sortolie_02.png", "115 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p></td></tr>", "Kort Thyra Bænk", null, "12003", "Sortolie", "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 11 x 47 x 120 cm. (H x B x L)</p><p>Vægt: 14 kg.</p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_kortbaenk_naturolie_01.png", 1, 3665L, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Højde: 47 cm.</p><p>Længde: 115 cm.</p><p>Bredde: 40 cm.</p></td></tr>", "Bænk i massivt egetræ - Behandlet med sortolie", "Bænk-Egetræ-Sortolie-115cm", "14" },
                    { 19, null, 20, "/word/bænk.docx", 4, "Thyra er en meget elegant og robust bænk at se på. De afrundede hjørner, og drejede ben, som går op igennem sædet og gør sig synlige, giver Thyra det unikke look som det fortjener. Bygget i den bedste kvalitet af massivt egetræ, fås det i 3 forskellige overfladebehandlinger og 2 størrrelse, så det kan passe ind i hvilket som helst hjem.", 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_kortbaenk_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_kortbaenk_hvidolie_02.png", "115 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p></td></tr>", "Kort Thyra Bænk", null, "12002", "Hvidolie", "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 11 x 47 x 120 cm. (H x B x L)</p><p>Vægt: 14 kg.</p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_kortbaenk_naturolie_01.png", 1, 3665L, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Højde: 47 cm.</p><p>Længde: 115 cm.</p><p>Bredde: 40 cm.</p></td></tr>", "Bænk i massivt egetræ - Behandlet med hvidolie", "Bænk-Egetræ-Hvidolie-115cm", "14" },
                    { 18, null, 42, "/word/bænk.docx", 4, "Thyra er en meget elegant og robust bænk at se på. De afrundede hjørner, og drejede ben, som går op igennem sædet og gør sig synlige, giver Thyra det unikke look som det fortjener. Bygget i den bedste kvalitet af massivt egetræ, fås det i 3 forskellige overfladebehandlinger og 2 størrrelse, så det kan passe ind i hvilket som helst hjem.", 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_kortbaenk_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_kortbaenk_naturolie_02.png", "115 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p></td></tr>", "Kort Thyra Bænk", null, "12001", "Naturolie", "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 11 x 47 x 120 cm. (H x B x L)</p><p>Vægt: 14 kg.</p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_kortbaenk_naturolie_01.png", 1, 3665L, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Højde: 47 cm.</p><p>Længde: 115 cm.</p><p>Bredde: 40 cm.</p></td></tr>", "Bænk i massivt egetræ - Behandlet med naturolie", "Bænk-Egetræ-Naturolie-115cm", "14" },
                    { 15, null, 7, "/word/Hylde.docx", 3, "Denne væghylde er simpel, og kan finde sig til rette i hvilket som helst hjem. I hyldeknægtene er nøglehulsbeslagene allerede bygget ind, så hylden monteres helt fladt til væggen, uden synlig fastgørelse. Nøglehulsbeslagene sidder både i top og bunden af hyldeknægtene, således at man kan vende hylden både op eller ned alt efter smag, og nemt skifte frem og tilbage. Der er 4 forskellige længder og 3 forskellige overfladebehandlinger af hylden, så man kan vælge den som passer bedst til sit hjem.", 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_02.png", "100 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>", "Ingeborg Hylden", "<tr class='no-border'><td class='width-30'><strong>Note</strong></td><td><p>Tjek om plugs passer præcist til jeres væg</p></td></tr>", "17001", "Naturolie", "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse:  103x22x4.5 cm. (L x B x H)</p><p>Vægt: 3.2 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_naturolie_01.png", 1, 985L, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Tykkelse: 2 cm.</p><p>Længde: 100 cm.</p><p>Bredde/dybde: 20 cm.</p></td></tr>", "Hylde i massivt egetræ - Behandlet med naturolie", "Hylde-Egetræ-Naturolie-100cm", "3.2" },
                    { 14, null, 2, "/word/Hylde.docx", 3, "Denne væghylde er simpel, og kan finde sig til rette i hvilket som helst hjem. I hyldeknægtene er nøglehulsbeslagene allerede bygget ind, så hylden monteres helt fladt til væggen, uden synlig fastgørelse. Nøglehulsbeslagene sidder både i top og bunden af hyldeknægtene, således at man kan vende hylden både op eller ned alt efter smag, og nemt skifte frem og tilbage. Der er 4 forskellige længder og 3 forskellige overfladebehandlinger af hylden, så man kan vælge den som passer bedst til sit hjem.", 0, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_02.png", "100 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>", "Ingeborg Hylden", "<tr class='no-border'><td class='width-30'><strong>Note</strong></td><td><p>Tjek om plugs passer præcist til jeres væg</p></td></tr>", "17003", "Sortolie", "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse:  103x22x4.5 cm. (L x B x H)</p><p>Vægt: 3.2 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_sortolie_01.png", 1, 985L, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Tykkelse: 2 cm.</p><p>Længde: 100 cm.</p><p>Bredde/dybde: 20 cm.</p></td></tr>", "Hylde i massivt egetræ - Behandlet med sortolie", "Hylde-Egetræ-Sortolie-100cm", "3.2" },
                    { 13, null, 3, "/word/Hylde.docx", 3, "Denne væghylde er simpel, og kan finde sig til rette i hvilket som helst hjem. I hyldeknægtene er nøglehulsbeslagene allerede bygget ind, så hylden monteres helt fladt til væggen, uden synlig fastgørelse. Nøglehulsbeslagene sidder både i top og bunden af hyldeknægtene, således at man kan vende hylden både op eller ned alt efter smag, og nemt skifte frem og tilbage. Der er 4 forskellige længder og 3 forskellige overfladebehandlinger af hylden, så man kan vælge den som passer bedst til sit hjem.", 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_02.png", "100 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>", "Ingeborg Hylden", "<tr class='no-border'><td class='width-30'><strong>Note</strong></td><td><p>Tjek om plugs passer præcist til jeres væg</p></td></tr>", "17002", "Hvidolie", "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse:  103x22x4.5 cm. (L x B x H)</p><p>Vægt: 3.2 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_hvidolie_01.png", 1, 985L, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Tykkelse: 2 cm.</p><p>Længde: 100 cm.</p><p>Bredde/dybde: 20 cm.</p></td></tr>", "Hylde i massivt egetræ - Behandlet med hvidolie", "Hylde-Egetræ-Hvidolie-100cm", "3.2" },
                    { 12, null, 11, "/word/Hylde.docx", 3, "Denne væghylde er simpel, og kan finde sig til rette i hvilket som helst hjem. I hyldeknægtene er nøglehulsbeslagene allerede bygget ind, så hylden monteres helt fladt til væggen, uden synlig fastgørelse. Nøglehulsbeslagene sidder både i top og bunden af hyldeknægtene, således at man kan vende hylden både op eller ned alt efter smag, og nemt skifte frem og tilbage. Der er 4 forskellige længder og 3 forskellige overfladebehandlinger af hylden, så man kan vælge den som passer bedst til sit hjem.", 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_02.png", "80 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>", "Ingeborg Hylden", "<tr class='no-border'><td class='width-30'><strong>Note</strong></td><td><p>Tjek om plugs passer præcist til jeres væg</p></td></tr>", "17011", "Naturolie", "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 83x22x4.5 cm. (L x B x H)</p><p>Vægt: 2.6 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_naturolie_01.png", 1, 885L, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Tykkelse: 2 cm.</p><p>Længde: 80 cm.</p><p>Bredde/dybde: 20 cm.</p></td></tr>", "Hylde i massivt egetræ - Behandlet med naturolie", "Hylde-Egetræ-Naturolie-80cm", "2.6" },
                    { 11, null, 2, "/word/Hylde.docx", 3, "Denne væghylde er simpel, og kan finde sig til rette i hvilket som helst hjem. I hyldeknægtene er nøglehulsbeslagene allerede bygget ind, så hylden monteres helt fladt til væggen, uden synlig fastgørelse. Nøglehulsbeslagene sidder både i top og bunden af hyldeknægtene, således at man kan vende hylden både op eller ned alt efter smag, og nemt skifte frem og tilbage. Der er 4 forskellige længder og 3 forskellige overfladebehandlinger af hylden, så man kan vælge den som passer bedst til sit hjem.", 0, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_02.png", "80 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>", "Ingeborg Hylden", "<tr class='no-border'><td class='width-30'><strong>Note</strong></td><td><p>Tjek om plugs passer præcist til jeres væg</p></td></tr>", "17013", "Sortolie", "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 83x22x4.5 cm. (L x B x H)</p><p>Vægt: 2.6 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_sortolie_01.png", 1, 885L, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Tykkelse: 2 cm.</p><p>Længde: 80 cm.</p><p>Bredde/dybde: 20 cm.</p></td></tr>", "Hylde i massivt egetræ - Behandlet med sortolie", "Hylde-Egetræ-Sortolie-80cm", "2.6" },
                    { 10, null, 4, "/word/Hylde.docx", 3, "Denne væghylde er simpel, og kan finde sig til rette i hvilket som helst hjem. I hyldeknægtene er nøglehulsbeslagene allerede bygget ind, så hylden monteres helt fladt til væggen, uden synlig fastgørelse. Nøglehulsbeslagene sidder både i top og bunden af hyldeknægtene, således at man kan vende hylden både op eller ned alt efter smag, og nemt skifte frem og tilbage. Der er 4 forskellige længder og 3 forskellige overfladebehandlinger af hylden, så man kan vælge den som passer bedst til sit hjem.", 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_02.png", "80 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>", "Ingeborg Hylden", "<tr class='no-border'><td class='width-30'><strong>Note</strong></td><td><p>Tjek om plugs passer præcist til jeres væg</p></td></tr>", "17012", "Hvidolie", "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 83x22x4.5 cm. (L x B x H)</p><p>Vægt: 2.6 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_hvidolie_01.png", 1, 885L, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Tykkelse: 2 cm.</p><p>Længde: 80 cm.</p><p>Bredde/dybde: 20 cm.</p></td></tr>", "Hylde i massivt egetræ - Behandlet med hvidolie", "Hylde-Egetræ-Hvidolie-80cm", "2.6" },
                    { 9, null, 30, "/word/Hylde.docx", 3, "Denne væghylde er simpel, og kan finde sig til rette i hvilket som helst hjem. I hyldeknægtene er nøglehulsbeslagene allerede bygget ind, så hylden monteres helt fladt til væggen, uden synlig fastgørelse. Nøglehulsbeslagene sidder både i top og bunden af hyldeknægtene, således at man kan vende hylden både op eller ned alt efter smag, og nemt skifte frem og tilbage. Der er 4 forskellige længder og 3 forskellige overfladebehandlinger af hylden, så man kan vælge den som passer bedst til sit hjem.", 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_02.png", "60 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>", "Ingeborg Hylden", "<tr class='no-border'><td class='width-30'><strong>Note</strong></td><td><p>Tjek om plugs passer præcist til jeres væg</p></td></tr>", "17021", "Naturolie", "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 63x22x4.5 cm. (L x B x H)</p><p>Vægt: 2 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_naturolie_01.png", 1, 785L, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Tykkelse: 2 cm.</p><p>Længde: 60 cm.</p><p>Bredde/dybde: 20 cm.</p></td></tr>", "Hylde i massivt egetræ - Behandlet med naturolie", "Hylde-Egetræ-Naturolie-60cm", "2" },
                    { 8, null, 11, "/word/Hylde.docx", 3, "Denne væghylde er simpel, og kan finde sig til rette i hvilket som helst hjem. I hyldeknægtene er nøglehulsbeslagene allerede bygget ind, så hylden monteres helt fladt til væggen, uden synlig fastgørelse. Nøglehulsbeslagene sidder både i top og bunden af hyldeknægtene, således at man kan vende hylden både op eller ned alt efter smag, og nemt skifte frem og tilbage. Der er 4 forskellige længder og 3 forskellige overfladebehandlinger af hylden, så man kan vælge den som passer bedst til sit hjem.", 0, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_02.png", "60 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>", "Ingeborg Hylden", "<tr class='no-border'><td class='width-30'><strong>Note</strong></td><td><p>Tjek om plugs passer præcist til jeres væg</p></td></tr>", "17023", "Sortolie", "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 63x22x4.5 cm. (L x B x H)</p><p>Vægt: 2 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_sortolie_01.png", 1, 785L, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Tykkelse: 2 cm.</p><p>Længde: 60 cm.</p><p>Bredde/dybde: 20 cm.</p></td></tr>", "Hylde i massivt egetræ - Behandlet med sortolie", "Hylde-Egetræ-Sortolie-60cm", "2" },
                    { 7, null, 10, "/word/Hylde.docx", 3, "Denne væghylde er simpel, og kan finde sig til rette i hvilket som helst hjem. I hyldeknægtene er nøglehulsbeslagene allerede bygget ind, så hylden monteres helt fladt til væggen, uden synlig fastgørelse. Nøglehulsbeslagene sidder både i top og bunden af hyldeknægtene, således at man kan vende hylden både op eller ned alt efter smag, og nemt skifte frem og tilbage. Der er 4 forskellige længder og 3 forskellige overfladebehandlinger af hylden, så man kan vælge den som passer bedst til sit hjem.", 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_02.png", "60 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>", "Ingeborg Hylden", "<tr class='no-border'><td class='width-30'><strong>Note</strong></td><td><p>Tjek om plugs passer præcist til jeres væg</p></td></tr>", "17022", "Hvidolie", "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 63x22x4.5 cm. (L x B x H)</p><p>Vægt: 2 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_hvidolie_01.png", 1, 785L, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Tykkelse: 2 cm.</p><p>Længde: 60 cm.</p><p>Bredde/dybde: 20 cm.</p></td></tr>", "Hylde i massivt egetræ - Behandlet med hvidolie", "Hylde-Egetræ-Hvidolie-60cm", "2" },
                    { 6, null, 14, "/word/Hylde.docx", 3, "Denne væghylde er simpel, og kan finde sig til rette i hvilket som helst hjem. I hyldeknægtene er nøglehulsbeslagene allerede bygget ind, så hylden monteres helt fladt til væggen, uden synlig fastgørelse. Nøglehulsbeslagene sidder både i top og bunden af hyldeknægtene, således at man kan vende hylden både op eller ned alt efter smag, og nemt skifte frem og tilbage. Der er 4 forskellige længder og 3 forskellige overfladebehandlinger af hylden, så man kan vælge den som passer bedst til sit hjem.", 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_02.png", "40 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>", "Ingeborg Hylden", "<tr class='no-border'><td class='width-30'><strong>Note</strong></td><td><p>Tjek om plugs passer præcist til jeres væg</p></td></tr>", "17031", "Naturolie", "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 43x22x4.5 cm. (L x B x H)</p><p>Vægt: 1.4 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_naturolie_01.png", 1, 685L, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Tykkelse: 2 cm.</p><p>Længde: 40 cm.</p><p>Bredde/dybde: 20 cm.</p></td></tr>", "Hylde i massivt egetræ - Behandlet med naturolie", "Hylde-Egetræ-Naturolie-40cm", "1.4" },
                    { 5, null, 0, "/word/Hylde.docx", 3, "Denne væghylde er simpel, og kan finde sig til rette i hvilket som helst hjem. I hyldeknægtene er nøglehulsbeslagene allerede bygget ind, så hylden monteres helt fladt til væggen, uden synlig fastgørelse. Nøglehulsbeslagene sidder både i top og bunden af hyldeknægtene, således at man kan vende hylden både op eller ned alt efter smag, og nemt skifte frem og tilbage. Der er 4 forskellige længder og 3 forskellige overfladebehandlinger af hylden, så man kan vælge den som passer bedst til sit hjem.", 0, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_02.png", "40 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>", "Ingeborg Hylden", "<tr class='no-border'><td class='width-30'><strong>Note</strong></td><td><p>Tjek om plugs passer præcist til jeres væg</p></td></tr>", "17033", "Sortolie", "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 43x22x4.5 cm. (L x B x H)</p><p>Vægt: 1.4 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_sortolie_01.png", 1, 685L, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Tykkelse: 2 cm.</p><p>Længde: 40 cm.</p><p>Bredde/dybde: 20 cm.</p></td></tr>", "Hylde i massivt egetræ - Behandlet med sortolie", "Hylde-Egetræ-Sortolie-40cm", "1.4" },
                    { 4, null, 4, "/word/Hylde.docx", 3, "Denne væghylde er simpel, og kan finde sig til rette i hvilket som helst hjem. I hyldeknægtene er nøglehulsbeslagene allerede bygget ind, så hylden monteres helt fladt til væggen, uden synlig fastgørelse. Nøglehulsbeslagene sidder både i top og bunden af hyldeknægtene, således at man kan vende hylden både op eller ned alt efter smag, og nemt skifte frem og tilbage. Der er 4 forskellige længder og 3 forskellige overfladebehandlinger af hylden, så man kan vælge den som passer bedst til sit hjem.", 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_02.png", "40 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>", "Ingeborg Hylden", "<tr class='no-border'><td class='width-30'><strong>Note</strong></td><td><p>Tjek om plugs passer præcist til jeres væg</p></td></tr>", "17032", "Hvidolie", "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 43x22x4.5 cm. (L x B x H)</p><p>Vægt: 1.4 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_hvidolie_01.png", 1, 685L, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Tykkelse: 2 cm.</p><p>Længde: 40 cm.</p><p>Bredde/dybde: 20 cm.</p></td></tr>", "Hylde i massivt egetræ - Behandlet med hvidolie", "Hylde-Egetræ-Hvidolie-40cm", "1.4" },
                    { 17, null, 30, "/word/Bord.docx", 2, "Affasede kanter, og drejede koniske ben som skråner ud mod hjørnerne, gør bordet unikt at se på. Det eneste man skal gøre er at skrue nogle ben på, og så har man samlet bordet. Både nemt at samle og pakke sammen igen hvis man vil flytte det. Bordet er ikke særligt langt, så passer rigtigt godt til et tebord eller et lille skrivebord, men det er selfølgelig dig som bestemmer det. Bordet fås i 2 overfladebehandlinger, og træet består selvfølgelig udelukkende af massivt egetræ.", 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_bord_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_bord_hvidolie_02.png", null, "<tr><td class='width-30'><strong>Materialer:</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Metal fittings</p></td></tr>", "Dagmar Bordet", null, "16002", "Hvidolie", "<tr class='no-border'><td class='width-30'><strong>Pakken:</strong></td><td><p>Vægt: 22 kg.</p><p>Størrelse: 11 x 75 x 114 cm. (H x B x L)</p><p> Leveres usamlet - se samlevejledning </p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_bord_hvidolie_01.png", 1, 3585L, "<tr><td class='width-30'><strong>Størrelse:</strong></td><td><p>Bordplade tykkelse: 2.5 cm.</p><p>Højde: 74 cm.</p><p>Længde: 110 cm.</p><p>Bredde: 70 cm.</p></td></tr>", "Bord i massivt egetræ - Behandlet med hvidolie", "Bord-Egetræ-Hvidolie", "22" },
                    { 16, null, 72, "/word/Bord.docx", 2, "Affasede kanter, og drejede koniske ben som skråner ud mod hjørnerne, gør bordet unikt at se på. Det eneste man skal gøre er at skrue nogle ben på, og så har man samlet bordet. Både nemt at samle og pakke sammen igen hvis man vil flytte det. Bordet er ikke særligt langt, så passer rigtigt godt til et tebord eller et lille skrivebord, men det er selfølgelig dig som bestemmer det. Bordet fås i 2 overfladebehandlinger, og træet består selvfølgelig udelukkende af massivt egetræ.", 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_bord_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_bord_naturolie_02.png", null, "<tr><td class='width-30'><strong>Materialer:</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Metal fittings</p></td></tr>", "Dagmar Bordet", null, "16001", "Naturolie", "<tr class='no-border'><td class='width-30'><strong>Pakken:</strong></td><td><p>Vægt: 22 kg.</p><p>Størrelse: 11 x 75 x 114 cm. (H x B x L)</p><p> Leveres usamlet - se samlevejledning </p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_bord_naturolie_01.png", 1, 3585L, "<tr><td class='width-30'><strong>Størrelse:</strong></td><td><p>Bordplade tykkelse: 2.5 cm.</p><p>Højde: 74 cm.</p><p>Længde: 110 cm.</p><p>Bredde: 70 cm.</p></td></tr>", "Bord i massivt egetræ - Behandlet med naturolie", "Bord-Egetræ-Naturolie", "22" },
                    { 32, null, 10, "/word/hænge_tøjrack.docx", 1, "Da vi tegnede Ingrid tog vi udgangspunkt i vores andet andet tøjstativ Nora. Designet minder lidt om hinanden, med den drejede rundstok, og trækiler til at holde stativet sammen. Ingrid monteres hængende ud fra væggen med, 2 skrå læderstropper, for at skabe mere stabilitet, og plantet løst i 2 fødder som skrues ind i væggen. Det var et forsøg på at lave et tøjstativ som ikke fylder ret meget, men stadig har et æstetisk look. ", 0, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/Ingrid_Sortolie_1.png", "../images/Products/Gallery/Desktop/Ingrid_Sortolie_2.png", null, "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Lædderstrop</p><p>Beslag</p><p>Skruer</p></td></tr>", "Ingrid Tøjstativ", null, "14003", "Sortolie", "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Vægt: 2kg.</p><p>Størrelse: 7 x 105 x 9.5 cm. (H x L x B)</p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", 1, 1995L, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Højde: 90 cm.</p><p>Fra væg/dybde: 40 cm.</p><p>Bredde: 105 cm.</p></td></tr>", "Hængende tøjstativ i massivt egetræ - Behandlet med sortolie", "Ophængt-Tøjstativ-Egetræ-Sortolie", "2" },
                    { 31, null, 15, "/word/hænge_tøjrack.docx", 1, "Da vi tegnede Ingrid tog vi udgangspunkt i vores andet andet tøjstativ Nora. Designet minder lidt om hinanden, med den drejede rundstok, og trækiler til at holde stativet sammen. Ingrid monteres hængende ud fra væggen med, 2 skrå læderstropper, for at skabe mere stabilitet, og plantet løst i 2 fødder som skrues ind i væggen. Det var et forsøg på at lave et tøjstativ som ikke fylder ret meget, men stadig har et æstetisk look. ", 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/Ingrid_Hvidolie_1.png", "../images/Products/Gallery/Desktop/Ingrid_Hvidolie_2.png", null, "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Lædderstrop</p><p>Beslag</p><p>Skruer</p></td></tr>", "Ingrid Tøjstativ", null, "14002", "Hvidolie", "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Vægt: 2kg.</p><p>Størrelse: 7 x 105 x 9.5 cm. (H x L x B)</p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", 1, 1995L, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Højde: 90 cm.</p><p>Fra væg/dybde: 40 cm.</p><p>Bredde: 105 cm.</p></td></tr>", "Hængende tøjstativ i massivt egetræ - Behandlet med hvidolie", "Ophængt-Tøjstativ-Egetræ-Hvidolie", "2" },
                    { 30, null, 25, "/word/hænge_tøjrack.docx", 1, "Da vi tegnede Ingrid tog vi udgangspunkt i vores andet andet tøjstativ Nora. Designet minder lidt om hinanden, med den drejede rundstok, og trækiler til at holde stativet sammen. Ingrid monteres hængende ud fra væggen med, 2 skrå læderstropper, for at skabe mere stabilitet, og plantet løst i 2 fødder som skrues ind i væggen. Det var et forsøg på at lave et tøjstativ som ikke fylder ret meget, men stadig har et æstetisk look. ", 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/Ingrid_Naturolie_1.png", "../images/Products/Gallery/Desktop/Ingrid_Naturolie_2.png", null, "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Lædderstrop</p><p>Beslag</p><p>Skruer</p></td></tr>", "Ingrid Tøjstativ", null, "14001", "Naturolie", "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Vægt: 2kg.</p><p>Størrelse: 7 x 105 x 9.5 cm. (H x L x B)</p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", 1, 1995L, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Højde: 90 cm.</p><p>Fra væg/dybde: 40 cm.</p><p>Bredde: 105 cm.</p></td></tr>", "Hængende tøjstativ i massivt egetræ - Behandlet med naturolie", "Ophængt-Tøjstativ-Egetræ-Naturolie", "2" },
                    { 29, null, 10, "/word/Tøjstativ.docx", 1, "Nora er vores bedste svar på minimalisme. Ingen skruer, ingen beslag, ingen metal. Nora er så naturlig som muligt. Nora består udelukkende af massivt egetræ, som samles via trækiler man bare skubber i, og så står det robust og elegant. Bøjlestangen og underdelen, er fræset i enderne så kilerne passer igennem. Designet med trækiler giver Nora et unikt og naturligt look, som giver øjnene varme og sjælen ro.", 0, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_rack_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_rack_sortolie_02.png", null, "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Kiler</p></td></tr>", "Nora Tøjstativ", null, "13003 + 13003A", "Sortolie", "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Leveres usamlet i 2 kartoner - se samlevejledning</p></td></tr><tr class='no-border'><td class='width-30'><strong>Karton 1</strong></td><td> <p>Vægt: 5 kg.</p><p> Størrelse: 6.5 x 11.5 x 186 cm. (H x B x L)</p></td></tr><tr><td class='width-30'><strong>Karton 2</strong></td><td> <p>Vægt: 3 kg.</p><p>Størrelse: 5.5 x 54 x 119 cm. (H x B x L)</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", 1, 2595L, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Højde: 180 cm.</p><p>Længde: 100 cm.</p><p>Bredde: 55 cm.</p></td></tr>", "Tøjstativ i massivt egetræ - Behandlet med sortolie", "Tøjstativ-Egetræ-Sortolie", "8" },
                    { 28, null, 16, "/word/Tøjstativ.docx", 1, "Nora er vores bedste svar på minimalisme. Ingen skruer, ingen beslag, ingen metal. Nora er så naturlig som muligt. Nora består udelukkende af massivt egetræ, som samles via trækiler man bare skubber i, og så står det robust og elegant. Bøjlestangen og underdelen, er fræset i enderne så kilerne passer igennem. Designet med trækiler giver Nora et unikt og naturligt look, som giver øjnene varme og sjælen ro.", 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_rack_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_rack_hvidolie_02.png", null, "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Kiler</p></td></tr>", "Nora Tøjstativ", null, "13002 + 13002A", "Hvidolie", "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Leveres usamlet i 2 kartoner - se samlevejledning</p></td></tr><tr class='no-border'><td class='width-30'><strong>Karton 1</strong></td><td> <p>Vægt: 5 kg.</p><p> Størrelse: 6.5 x 11.5 x 186 cm. (H x B x L)</p></td></tr><tr><td class='width-30'><strong>Karton 2</strong></td><td> <p>Vægt: 3 kg.</p><p>Størrelse: 5.5 x 54 x 119 cm. (H x B x L)</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", 1, 2595L, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Højde: 180 cm.</p><p>Længde: 100 cm.</p><p>Bredde: 55 cm.</p></td></tr>", "Tøjstativ i massivt egetræ - Behandlet med hvidolie", "Tøjstativ-Egetræ-Hvidolie", "8" },
                    { 2, null, 123, "none", 5, "En smuk bøjle i massivt egetræ med afrundede hjørner, som er bløde, og skåner tøjet. Gertrud har også fået en lille blød nedrunding til tøj med stropper, så den kan klare hvad som helst.", 0, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_boejle_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_boejle_sortolie_02.png", null, "<tr><td class='width-30'<strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Sort bøjlekrog</p></td></tr>", "Bøjlen Gertrud / 3 stk.", null, "15003", "Sortolie", "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 47x17x6 cm. (L x B x H)</p><p>Vægt: 0.6 kg.</p><p>Leveres samlet med 3 stk. pr. karton</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_boejle_sortolie_01.png", 3, 420L, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Tykkelse: 2 cm.</p><p>Længde: 45 cm.</p></td></tr>", "Bøjle i massivt egetræ - Behandlet med sortolie", "Bøjle-Egetræ-Sortolie", "0.6" },
                    { 3, null, 123, "none", 5, "En smuk bøjle i massivt egetræ med afrundede hjørner, som er bløde, og skåner tøjet. Gertrud har også fået en lille blød nedrunding til tøj med stropper, så den kan klare hvad som helst.", 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_boejle_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_boejle_hvidolie_02.png", null, "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Massivt Egetræ</p><p>Olie</p><p>Sort bøjlekrog</p></td></tr>", "Bøjlen Gertrud / 3 stk.", null, "15002", "Hvidolie", "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 47x17x6 cm. (L x B x H)</p><p>Vægt: 0.6 kg.</p><p>Leveres samlet med 3 stk. pr. karton</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_boejle_hvidolie_01.png", 3, 420L, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Tykkelse: 2 cm.</p><p>Længde: 45 cm.</p></td></tr>", "Bøjle i massivt egetræ - Behandlet med hvidolie", "Bøjle-Egetræ-Hvidolie", "0.6" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "EColor", "ImgSrc", "ProductId", "ProductSourceId", "ProductSourceUrlName" },
                values: new object[,]
                {
                    { 77, 0, "../images/Products/Color/Desktop/NYKANT_rack_naturolie_02.png", 27, 27, "Tøjstativ-Egetræ-Naturolie" },
                    { 20, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 7, 8, "Hylde-Egetræ-Sortolie-60cm" },
                    { 19, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 7, 7, "Hylde-Egetræ-Hvidolie-60cm" },
                    { 60, 1, "../images/Products/Color/Desktop/NYKANT_langbaenk_hvidolie_02.png", 21, 22, "Bænk-Egetræ-Hvidolie-170cm" },
                    { 61, 2, "../images/Products/Color/Desktop/NYKANT_langbaenk_sortolie_02.png", 21, 23, "Bænk-Egetræ-Sortolie-170cm" },
                    { 62, 0, "../images/Products/Color/Desktop/NYKANT_langbaenk_naturolie_02.png", 22, 21, "Bænk-Egetræ-Naturolie-170cm" },
                    { 63, 1, "../images/Products/Color/Desktop/NYKANT_langbaenk_hvidolie_02.png", 22, 22, "Bænk-Egetræ-Hvidolie-170cm" },
                    { 18, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 6, 6, "Hylde-Egetræ-Naturolie-40cm" },
                    { 17, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 6, 5, "Hylde-Egetræ-Sortolie-40cm" },
                    { 16, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 6, 4, "Hylde-Egetræ-Hvidolie-40cm" },
                    { 64, 2, "../images/Products/Color/Desktop/NYKANT_langbaenk_sortolie_02.png", 22, 23, "Bænk-Egetræ-Sortolie-170cm" },
                    { 65, 0, "../images/Products/Color/Desktop/NYKANT_langbaenk_naturolie_02.png", 23, 21, "Bænk-Egetræ-Naturolie-170cm" },
                    { 66, 1, "../images/Products/Color/Desktop/NYKANT_langbaenk_hvidolie_02.png", 23, 22, "Bænk-Egetræ-Hvidolie-170cm" },
                    { 67, 2, "../images/Products/Color/Desktop/NYKANT_langbaenk_sortolie_02.png", 23, 23, "Bænk-Egetræ-Sortolie-170cm" },
                    { 15, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 5, 6, "Hylde-Egetræ-Naturolie-40cm" },
                    { 14, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 5, 5, "Hylde-Egetræ-Sortolie-40cm" },
                    { 13, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 5, 4, "Hylde-Egetræ-Hvidolie-40cm" },
                    { 38, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 13, 14, "Hylde-Egetræ-Sortolie-100cm" },
                    { 68, 0, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png", 24, 24, "Opbevaringsbænk-Egetræ-Naturolie" },
                    { 69, 1, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png", 24, 25, "Opbevaringsbænk-Egetræ-Hvidolie" },
                    { 70, 2, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_sort_01.png", 24, 26, "Opbevaringsbænk-Egetræ-Sortolie" },
                    { 12, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 4, 6, "Hylde-Egetræ-Naturolie-40cm" },
                    { 11, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 4, 5, "Hylde-Egetræ-Sortolie-40cm" },
                    { 10, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 4, 4, "Hylde-Egetræ-Hvidolie-40cm" },
                    { 49, 1, "../images/Products/Color/Desktop/bord_hvid_2.png", 17, 17, "Bord-Egetræ-Hvidolie" },
                    { 48, 0, "../images/Products/Color/Desktop/bord_natur_2.png", 17, 16, "Bord-Egetræ-Naturolie" },
                    { 47, 1, "../images/Products/Color/Desktop/bord_hvid_2.png", 16, 17, "Bord-Egetræ-Hvidolie" },
                    { 46, 0, "../images/Products/Color/Desktop/bord_natur_2.png", 16, 16, "Bord-Egetræ-Naturolie" },
                    { 71, 0, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png", 25, 24, "Opbevaringsbænk-Egetræ-Naturolie" },
                    { 72, 1, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png", 25, 25, "Opbevaringsbænk-Egetræ-Hvidolie" },
                    { 21, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 7, 9, "Hylde-Egetræ-Naturolie-60cm" },
                    { 73, 2, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_sort_01.png", 25, 26, "Opbevaringsbænk-Egetræ-Sortolie" },
                    { 59, 0, "../images/Products/Color/Desktop/NYKANT_langbaenk_naturolie_02.png", 21, 21, "Bænk-Egetræ-Naturolie-170cm" },
                    { 57, 1, "../images/Products/Color/Desktop/kortbaenk_hvid_2.png", 20, 19, "Bænk-Egetræ-Hvidolie-115cm" },
                    { 39, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 13, 15, "Hylde-Egetræ-Naturolie-100cm" },
                    { 36, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 12, 12, "Hylde-Egetræ-Naturolie-80cm" },
                    { 35, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 12, 11, "Hylde-Egetræ-Sortolie-80cm" },
                    { 34, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 12, 10, "Hylde-Egetræ-Hvidolie-80cm" },
                    { 40, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 14, 13, "Hylde-Egetræ-Hvidolie-100cm" },
                    { 41, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 14, 14, "Hylde-Egetræ-Sortolie-100cm" },
                    { 42, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 14, 15, "Hylde-Egetræ-Naturolie-100cm" },
                    { 33, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 11, 12, "Hylde-Egetræ-Naturolie-80cm" },
                    { 32, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 11, 11, "Hylde-Egetræ-Sortolie-80cm" },
                    { 31, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 11, 10, "Hylde-Egetræ-Hvidolie-80cm" },
                    { 43, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 15, 13, "Hylde-Egetræ-Hvidolie-100cm" },
                    { 44, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 15, 14, "Hylde-Egetræ-Sortolie-100cm" },
                    { 45, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 15, 15, "Hylde-Egetræ-Naturolie-100cm" },
                    { 30, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 10, 12, "Hylde-Egetræ-Naturolie-80cm" },
                    { 29, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 10, 11, "Hylde-Egetræ-Sortolie-80cm" },
                    { 28, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 10, 10, "Hylde-Egetræ-Hvidolie-80cm" },
                    { 50, 0, "../images/Products/Color/Desktop/kortbaenk_natur_2.png", 18, 18, "Bænk-Egetræ-Naturolie-115cm" },
                    { 51, 1, "../images/Products/Color/Desktop/kortbaenk_hvid_2.png", 18, 19, "Bænk-Egetræ-Hvidolie-115cm" },
                    { 52, 2, "../images/Products/Color/Desktop/NYKANT_kortbaenk_sortolie_02.png", 18, 20, "Bænk-Egetræ-Sortolie-115cm" },
                    { 27, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 9, 9, "Hylde-Egetræ-Naturolie-60cm" },
                    { 26, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 9, 8, "Hylde-Egetræ-Sortolie-60cm" },
                    { 25, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 9, 7, "Hylde-Egetræ-Hvidolie-60cm" },
                    { 53, 0, "../images/Products/Color/Desktop/kortbaenk_natur_2.png", 19, 18, "Bænk-Egetræ-Naturolie-115cm" },
                    { 54, 1, "../images/Products/Color/Desktop/kortbaenk_hvid_2.png", 19, 19, "Bænk-Egetræ-Hvidolie-115cm" },
                    { 55, 2, "../images/Products/Color/Desktop/NYKANT_kortbaenk_sortolie_02.png", 19, 20, "Bænk-Egetræ-Sortolie-115cm" },
                    { 24, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 8, 9, "Hylde-Egetræ-Naturolie-60cm" },
                    { 23, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 8, 8, "Hylde-Egetræ-Sortolie-60cm" },
                    { 22, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 8, 7, "Hylde-Egetræ-Hvidolie-60cm" },
                    { 56, 0, "../images/Products/Color/Desktop/kortbaenk_natur_2.png", 20, 18, "Bænk-Egetræ-Naturolie-115cm" },
                    { 58, 2, "../images/Products/Color/Desktop/NYKANT_kortbaenk_sortolie_02.png", 20, 20, "Bænk-Egetræ-Sortolie-115cm" },
                    { 94, 2, "../images/Products/Color/Desktop/Ingrid_sort_2.png", 32, 32, "Ophængt-Tøjstativ-Egetræ-Sortolie" },
                    { 37, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 13, 13, "Hylde-Egetræ-Hvidolie-100cm" },
                    { 81, 1, "../images/Products/Color/Desktop/NYKANT_rack_hvidolie_02.png", 28, 28, "Tøjstativ-Egetræ-Hvidolie" },
                    { 89, 0, "../images/Products/Color/Desktop/Ingrid_natur_2.png", 31, 30, "Ophængt-Tøjstativ-Egetræ-Naturolie" },
                    { 6, 1, "../images/Products/Color/Desktop/boejle_hvid_1.png", 2, 3, "Bøjle-Egetræ-Hvidolie" },
                    { 5, 2, "../images/Products/Color/Desktop/boejle_sort_1.png", 2, 2, "Bøjle-Egetræ-Sortolie" },
                    { 4, 0, "../images/Products/Color/Desktop/boejle_natur_1.png", 2, 1, "Bøjle-Egetræ-Naturolie" },
                    { 80, 0, "../images/Products/Color/Desktop/NYKANT_rack_naturolie_02.png", 28, 27, "Tøjstativ-Egetræ-Naturolie" },
                    { 84, 1, "../images/Products/Color/Desktop/NYKANT_rack_hvidolie_02.png", 29, 28, "Tøjstativ-Egetræ-Hvidolie" },
                    { 88, 2, "../images/Products/Color/Desktop/Ingrid_sort_2.png", 30, 32, "Ophængt-Tøjstativ-Egetræ-Sortolie" },
                    { 87, 1, "../images/Products/Color/Desktop/Ingrid_hvid_2.png", 30, 31, "Ophængt-Tøjstativ-Egetræ-Hvidolie" },
                    { 90, 1, "../images/Products/Color/Desktop/Ingrid_hvid_2.png", 31, 31, "Ophængt-Tøjstativ-Egetræ-Hvidolie" },
                    { 86, 0, "../images/Products/Color/Desktop/Ingrid_natur_2.png", 30, 30, "Ophængt-Tøjstativ-Egetræ-Naturolie" },
                    { 82, 2, "../images/Products/Color/Desktop/NYKANT_rack_sortolie_02.png", 28, 29, "Tøjstativ-Egetræ-Sortolie" },
                    { 75, 1, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png", 26, 25, "Opbevaringsbænk-Egetræ-Hvidolie" },
                    { 76, 2, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_sort_01.png", 26, 26, "Opbevaringsbænk-Egetræ-Sortolie" },
                    { 3, 1, "../images/Products/Color/Desktop/boejle_hvid_1.png", 1, 3, "Bøjle-Egetræ-Hvidolie" },
                    { 2, 2, "../images/Products/Color/Desktop/boejle_sort_1.png", 1, 2, "Bøjle-Egetræ-Sortolie" },
                    { 1, 0, "../images/Products/Color/Desktop/boejle_natur_1.png", 1, 1, "Bøjle-Egetræ-Naturolie" },
                    { 85, 2, "../images/Products/Color/Desktop/NYKANT_rack_sortolie_02.png", 29, 29, "Tøjstativ-Egetræ-Sortolie" },
                    { 93, 1, "../images/Products/Color/Desktop/Ingrid_hvid_2.png", 32, 31, "Ophængt-Tøjstativ-Egetræ-Hvidolie" },
                    { 74, 0, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png", 26, 24, "Opbevaringsbænk-Egetræ-Naturolie" },
                    { 91, 2, "../images/Products/Color/Desktop/Ingrid_sort_2.png", 31, 32, "Ophængt-Tøjstativ-Egetræ-Sortolie" },
                    { 83, 0, "../images/Products/Color/Desktop/NYKANT_rack_naturolie_02.png", 29, 27, "Tøjstativ-Egetræ-Naturolie" },
                    { 78, 1, "../images/Products/Color/Desktop/NYKANT_rack_hvidolie_02.png", 27, 28, "Tøjstativ-Egetræ-Hvidolie" },
                    { 79, 2, "../images/Products/Color/Desktop/NYKANT_rack_sortolie_02.png", 27, 29, "Tøjstativ-Egetræ-Sortolie" },
                    { 92, 0, "../images/Products/Color/Desktop/Ingrid_natur_2.png", 32, 30, "Ophængt-Tøjstativ-Egetræ-Naturolie" },
                    { 9, 1, "../images/Products/Color/Desktop/boejle_hvid_1.png", 3, 3, "Bøjle-Egetræ-Hvidolie" },
                    { 8, 2, "../images/Products/Color/Desktop/boejle_sort_1.png", 3, 2, "Bøjle-Egetræ-Sortolie" },
                    { 7, 0, "../images/Products/Color/Desktop/boejle_natur_1.png", 3, 1, "Bøjle-Egetræ-Naturolie" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ImageType", "ProductId", "Size", "Source", "Source2" },
                values: new object[,]
                {
                    { 4, 0, 2, 2, "../images/Products/Details_Slide/Desktop/NYKANT_boejle_sortolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_boejle_sortolie_02.png" },
                    { 277, 1, 18, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_naturolie_01.png", null },
                    { 278, 1, 18, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_naturolie_02.png", null },
                    { 2, 0, 1, 2, "../images/Products/Details_Slide/Desktop/NYKANT_boejle_naturolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_boejle_naturolie_02.png" },
                    { 1, 0, 1, 2, "../images/Products/Details_Slide/Desktop/NYKANT_boejle_naturolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_boejle_naturolie_01.png" },
                    { 279, 1, 18, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_naturolie_03.png", null },
                    { 35, 0, 13, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    { 34, 0, 13, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    { 316, 1, 26, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_07.png", null },
                    { 52, 0, 19, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_hvidolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_hvidolie_01.png" },
                    { 53, 0, 19, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_hvidolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_hvidolie_02.png" },
                    { 54, 0, 19, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_hvidolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_hvidolie_03.png" },
                    { 280, 1, 19, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_hvidolie_01.png", null },
                    { 281, 1, 19, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_hvidolie_02.png", null },
                    { 282, 1, 19, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_hvidolie_03.png", null },
                    { 315, 1, 26, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_06.png", null },
                    { 314, 1, 26, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_05.png", null },
                    { 312, 1, 26, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_04.png", null },
                    { 51, 0, 18, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_naturolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_naturolie_03.png" },
                    { 50, 0, 18, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_naturolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_naturolie_02.png" },
                    { 5, 0, 3, 2, "../images/Products/Details_Slide/Desktop/NYKANT_boejle_hvidolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_boejle_hvidolie_01.png" },
                    { 265, 1, 14, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_01.png", null },
                    { 231, 1, 2, 2, "../images/Products/Details_Button/Desktop/NYKANT_boejle_sortolie_01.png", null },
                    { 232, 1, 2, 2, "../images/Products/Details_Button/Desktop/NYKANT_boejle_sortolie_02.png", null },
                    { 266, 1, 14, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_02.png", null },
                    { 267, 1, 14, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_03.png", null },
                    { 3, 0, 2, 2, "../images/Products/Details_Slide/Desktop/NYKANT_boejle_sortolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_boejle_sortolie_01.png" },
                    { 39, 0, 14, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_03.png" },
                    { 38, 0, 14, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_02.png" },
                    { 40, 0, 15, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_01.png" },
                    { 41, 0, 15, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_02.png" },
                    { 42, 0, 15, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_03.png" },
                    { 268, 1, 15, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_01.png", null },
                    { 37, 0, 14, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_01.png" },
                    { 264, 1, 13, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_03.png", null },
                    { 263, 1, 13, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_02.png", null },
                    { 262, 1, 13, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_01.png", null },
                    { 269, 1, 15, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_02.png", null },
                    { 270, 1, 15, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_03.png", null },
                    { 36, 0, 13, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    { 230, 1, 1, 2, "../images/Products/Details_Button/Desktop/NYKANT_boejle_naturolie_02.png", null },
                    { 229, 1, 1, 2, "../images/Products/Details_Button/Desktop/NYKANT_boejle_naturolie_01.png", null },
                    { 49, 0, 18, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_naturolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_naturolie_01.png" },
                    { 6, 0, 3, 2, "../images/Products/Details_Slide/Desktop/NYKANT_boejle_hvidolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_boejle_hvidolie_02.png" },
                    { 75, 0, 25, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_02.png" },
                    { 284, 1, 20, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_sortolie_02.png", null },
                    { 55, 0, 20, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_sortolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_sortolie_01.png" },
                    { 293, 1, 23, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_sortolie_02.png", null },
                    { 294, 1, 23, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_sortolie_03.png", null },
                    { 305, 1, 25, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_04.png", null },
                    { 304, 1, 25, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_03.png", null },
                    { 303, 1, 25, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_02.png", null },
                    { 67, 0, 24, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png" },
                    { 68, 0, 24, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_02.png" },
                    { 69, 0, 24, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_03.png" },
                    { 70, 0, 24, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_04.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_04.png" },
                    { 71, 0, 24, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_05.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_05.png" },
                    { 72, 0, 24, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_06.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_06.png" },
                    { 73, 0, 24, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_07.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_07.png" },
                    { 292, 1, 23, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_sortolie_01.png", null },
                    { 302, 1, 25, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png", null },
                    { 295, 1, 24, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png", null },
                    { 296, 1, 24, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_02.png", null },
                    { 297, 1, 24, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_03.png", null },
                    { 298, 1, 24, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_04.png", null },
                    { 299, 1, 24, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_05.png", null },
                    { 300, 1, 24, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_06.png", null },
                    { 79, 0, 25, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_06.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_06.png" },
                    { 78, 0, 25, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_05.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_05.png" },
                    { 301, 1, 24, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_07.png", null },
                    { 77, 0, 25, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_04.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_04.png" },
                    { 76, 0, 25, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_03.png" },
                    { 74, 0, 25, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png" },
                    { 80, 0, 25, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_07.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_07.png" },
                    { 66, 0, 23, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_sortolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_sortolie_03.png" },
                    { 306, 1, 25, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_05.png", null },
                    { 64, 0, 23, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_sortolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_sortolie_01.png" },
                    { 56, 0, 20, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_sortolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_sortolie_02.png" },
                    { 57, 0, 20, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_sortolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_sortolie_03.png" },
                    { 283, 1, 20, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_sortolie_01.png", null },
                    { 285, 1, 20, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_sortolie_03.png", null },
                    { 310, 1, 26, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_02.png", null },
                    { 309, 1, 26, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_01.png", null },
                    { 87, 0, 26, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_07.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_07.png" },
                    { 86, 0, 26, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_06.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_06.png" },
                    { 85, 0, 26, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_05.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_05.png" },
                    { 58, 0, 21, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_naturolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_naturolie_01.png" },
                    { 59, 0, 21, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_naturolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_naturolie_02.png" },
                    { 60, 0, 21, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_naturolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_naturolie_03.png" },
                    { 286, 1, 21, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_naturolie_01.png", null },
                    { 287, 1, 21, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_naturolie_02.png", null },
                    { 288, 1, 21, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_naturolie_03.png", null },
                    { 84, 0, 26, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_04.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_04.png" },
                    { 83, 0, 26, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_03.png" },
                    { 82, 0, 26, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_02.png" },
                    { 81, 0, 26, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_01.png" },
                    { 61, 0, 22, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_hvidolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_hvidolie_01.png" },
                    { 62, 0, 22, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_hvidolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_hvidolie_02.png" },
                    { 63, 0, 22, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_hvidolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_hvidolie_03.png" },
                    { 289, 1, 22, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_hvidolie_01.png", null },
                    { 290, 1, 22, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_hvidolie_02.png", null },
                    { 291, 1, 22, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_hvidolie_03.png", null },
                    { 308, 1, 25, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_07.png", null },
                    { 307, 1, 25, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_06.png", null },
                    { 311, 1, 26, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_03.png", null },
                    { 65, 0, 23, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_sortolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_sortolie_02.png" },
                    { 234, 1, 3, 2, "../images/Products/Details_Button/Desktop/NYKANT_boejle_hvidolie_02.png", null },
                    { 21, 0, 8, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_03.png" },
                    { 13, 0, 6, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_01.png" },
                    { 14, 0, 6, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_02.png" },
                    { 338, 1, 31, 2, "../images/Products/Details_Button/Desktop/Ingrid_Hvidolie_1.png", null },
                    { 111, 0, 31, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Hvidolie_3.png", "../images/Products/Details_Fullscreen/Desktop/Ingrid_Hvidolie_3.png" },
                    { 15, 0, 6, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_03.png" },
                    { 241, 1, 6, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_01.png", null },
                    { 242, 1, 6, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_02.png", null },
                    { 243, 1, 6, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_03.png", null },
                    { 110, 0, 31, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Hvidolie_2.png", "../images/Products/Details_Fullscreen/Desktop/Ingrid_Hvidolie_2.png" },
                    { 109, 0, 31, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Hvidolie_1.png", "../images/Products/Details_Fullscreen/Desktop/Ingrid_Hvidolie_1.png" },
                    { 337, 1, 30, 2, "../images/Products/Details_Button/Desktop/Ingrid_Naturolie_3.png", null },
                    { 336, 1, 30, 2, "../images/Products/Details_Button/Desktop/Ingrid_Naturolie_2.png", null },
                    { 339, 1, 31, 2, "../images/Products/Details_Button/Desktop/Ingrid_Hvidolie_2.png", null },
                    { 16, 0, 7, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    { 108, 0, 30, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Naturolie_3.png", "../images/Products/Details_Fullscreen/Desktop/Ingrid_Naturolie_3.png" },
                    { 17, 0, 7, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    { 18, 0, 7, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    { 244, 1, 7, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_01.png", null },
                    { 245, 1, 7, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_02.png", null },
                    { 246, 1, 7, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_03.png", null },
                    { 107, 0, 30, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Naturolie_2.png", "../images/Products/Details_Fullscreen/Desktop/Ingrid_Naturolie_2.png" },
                    { 106, 0, 30, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Naturolie_1.png", "../images/Products/Details_Fullscreen/Desktop/Ingrid_Naturolie_1.png" },
                    { 334, 1, 29, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_sortolie_06.png", null },
                    { 333, 1, 29, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_sortolie_05.png", null },
                    { 332, 1, 29, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_sortolie_04.png", null },
                    { 331, 1, 29, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_sortolie_03.png", null },
                    { 335, 1, 30, 2, "../images/Products/Details_Button/Desktop/Ingrid_Naturolie_1.png", null },
                    { 261, 1, 12, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_03.png", null },
                    { 340, 1, 31, 2, "../images/Products/Details_Button/Desktop/Ingrid_Hvidolie_3.png", null },
                    { 112, 0, 32, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Sortolie_1.png", "../images/Products/Details_Fullscreen/Desktop/Ingrid_Sortolie_1.png" },
                    { 273, 1, 16, 2, "../images/Products/Details_Button/Desktop/NYKANT_bord_naturolie_03.png", null },
                    { 46, 0, 17, 2, "../images/Products/Details_Slide/Desktop/NYKANT_bord_hvidolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_bord_hvidolie_01.png" },
                    { 47, 0, 17, 2, "../images/Products/Details_Slide/Desktop/NYKANT_bord_hvidolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_bord_hvidolie_02.png" },
                    { 48, 0, 17, 2, "../images/Products/Details_Slide/Desktop/NYKANT_bord_hvidolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_bord_hvidolie_03.png" },
                    { 274, 1, 17, 2, "../images/Products/Details_Button/Desktop/NYKANT_bord_hvidolie_01.png", null },
                    { 275, 1, 17, 2, "../images/Products/Details_Button/Desktop/NYKANT_bord_hvidolie_02.png", null },
                    { 276, 1, 17, 2, "../images/Products/Details_Button/Desktop/NYKANT_bord_hvidolie_03.png", null },
                    { 7, 0, 4, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    { 8, 0, 4, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    { 9, 0, 4, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    { 235, 1, 4, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_01.png", null },
                    { 45, 0, 16, 2, "../images/Products/Details_Slide/Desktop/NYKANT_bord_naturolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_bord_naturolie_03.png" },
                    { 44, 0, 16, 2, "../images/Products/Details_Slide/Desktop/NYKANT_bord_naturolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_bord_naturolie_02.png" },
                    { 236, 1, 4, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_02.png", null },
                    { 237, 1, 4, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_03.png", null },
                    { 43, 0, 16, 2, "../images/Products/Details_Slide/Desktop/NYKANT_bord_naturolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_bord_naturolie_01.png" },
                    { 343, 1, 32, 2, "../images/Products/Details_Button/Desktop/Ingrid_Sortolie_3.png", null },
                    { 342, 1, 32, 2, "../images/Products/Details_Button/Desktop/Ingrid_Sortolie_2.png", null },
                    { 341, 1, 32, 2, "../images/Products/Details_Button/Desktop/Ingrid_Sortolie_1.png", null },
                    { 10, 0, 5, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_01.png" },
                    { 11, 0, 5, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_02.png" },
                    { 12, 0, 5, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_03.png" },
                    { 114, 0, 32, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Sortolie_3.png", "../images/Products/Details_Fullscreen/Desktop/Ingrid_Sortolie_3.png" },
                    { 113, 0, 32, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Sortolie_2.png", "../images/Products/Details_Fullscreen/Desktop/Ingrid_Sortolie_2.png" },
                    { 238, 1, 5, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_01.png", null },
                    { 239, 1, 5, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_02.png", null },
                    { 240, 1, 5, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_03.png", null },
                    { 19, 0, 8, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_01.png" },
                    { 20, 0, 8, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_02.png" },
                    { 271, 1, 16, 2, "../images/Products/Details_Button/Desktop/NYKANT_bord_naturolie_01.png", null },
                    { 247, 1, 8, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_01.png", null },
                    { 96, 0, 28, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_hvidolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_03.png" },
                    { 95, 0, 28, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_hvidolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_02.png" },
                    { 94, 0, 28, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_hvidolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_01.png" },
                    { 322, 1, 27, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_naturolie_06.png", null },
                    { 321, 1, 27, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_naturolie_05.png", null },
                    { 28, 0, 11, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_01.png" },
                    { 29, 0, 11, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_02.png" },
                    { 30, 0, 11, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_03.png" },
                    { 256, 1, 11, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_01.png", null },
                    { 257, 1, 11, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_02.png", null },
                    { 258, 1, 11, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_03.png", null },
                    { 320, 1, 27, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_naturolie_04.png", null },
                    { 319, 1, 27, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_naturolie_03.png", null },
                    { 318, 1, 27, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_naturolie_02.png", null },
                    { 317, 1, 27, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_naturolie_01.png", null },
                    { 93, 0, 27, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_naturolie_06.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_06.png" },
                    { 92, 0, 27, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_naturolie_05.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_05.png" },
                    { 233, 1, 3, 2, "../images/Products/Details_Button/Desktop/NYKANT_boejle_hvidolie_01.png", null },
                    { 91, 0, 27, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_naturolie_04.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_04.png" },
                    { 31, 0, 12, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_01.png" },
                    { 32, 0, 12, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_02.png" },
                    { 33, 0, 12, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_03.png" },
                    { 259, 1, 12, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_01.png", null },
                    { 260, 1, 12, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_02.png", null },
                    { 90, 0, 27, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_naturolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_03.png" },
                    { 89, 0, 27, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_naturolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_02.png" },
                    { 88, 0, 27, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_naturolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_01.png" },
                    { 97, 0, 28, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_hvidolie_04.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_04.png" },
                    { 272, 1, 16, 2, "../images/Products/Details_Button/Desktop/NYKANT_bord_naturolie_02.png", null },
                    { 98, 0, 28, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_hvidolie_05.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_05.png" },
                    { 255, 1, 10, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_03.png", null },
                    { 248, 1, 8, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_02.png", null },
                    { 249, 1, 8, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_03.png", null },
                    { 330, 1, 29, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_sortolie_02.png", null },
                    { 329, 1, 29, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_sortolie_01.png", null },
                    { 105, 0, 29, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_sortolie_06.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_06.png" },
                    { 104, 0, 29, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_sortolie_05.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_05.png" },
                    { 103, 0, 29, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_sortolie_04.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_04.png" },
                    { 102, 0, 29, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_sortolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_03.png" },
                    { 22, 0, 9, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_01.png" },
                    { 23, 0, 9, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_02.png" },
                    { 24, 0, 9, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_03.png" },
                    { 250, 1, 9, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_01.png", null },
                    { 251, 1, 9, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_02.png", null },
                    { 252, 1, 9, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_03.png", null },
                    { 101, 0, 29, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_sortolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_02.png" },
                    { 100, 0, 29, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_sortolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_01.png" },
                    { 328, 1, 28, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_hvidolie_06.png", null },
                    { 327, 1, 28, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_hvidolie_05.png", null },
                    { 326, 1, 28, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_hvidolie_04.png", null },
                    { 325, 1, 28, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_hvidolie_03.png", null },
                    { 324, 1, 28, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_hvidolie_02.png", null },
                    { 323, 1, 28, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_hvidolie_01.png", null },
                    { 25, 0, 10, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    { 26, 0, 10, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    { 27, 0, 10, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    { 253, 1, 10, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_01.png", null },
                    { 254, 1, 10, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_02.png", null },
                    { 99, 0, 28, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_hvidolie_06.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_06.png" }
                });

            migrationBuilder.InsertData(
                table: "ProductLength",
                columns: new[] { "Id", "Length", "ProductId", "ProductReferenceId", "ProductReferenceUrlName" },
                values: new object[,]
                {
                    { 45, "40 cm.", 12, 6, "Hylde-Egetræ-Naturolie-40cm" },
                    { 19, "80 cm.", 5, 11, "Hylde-Egetræ-Sortolie-80cm" },
                    { 11, "115 cm.", 23, 20, "Bænk-Egetræ-Sortolie-115cm" },
                    { 34, "60 cm.", 9, 9, "Hylde-Egetræ-Naturolie-60cm" },
                    { 60, "100 cm.", 15, 15, "Hylde-Egetræ-Naturolie-100cm" },
                    { 59, "80 cm.", 15, 12, "Hylde-Egetræ-Naturolie-80cm" },
                    { 58, "60 cm.", 15, 9, "Hylde-Egetræ-Naturolie-60cm" },
                    { 57, "40 cm.", 15, 6, "Hylde-Egetræ-Naturolie-40cm" },
                    { 35, "80 cm.", 9, 12, "Hylde-Egetræ-Naturolie-80cm" },
                    { 36, "100 cm.", 9, 16, "Hylde-Egetræ-Naturolie-100cm" },
                    { 37, "40 cm.", 10, 4, "Hylde-Egetræ-Hvidolie-40cm" },
                    { 56, "100 cm.", 14, 14, "Hylde-Egetræ-Sortolie-100cm" },
                    { 55, "80 cm.", 14, 11, "Hylde-Egetræ-Sortolie-80cm" },
                    { 54, "60 cm.", 14, 8, "Hylde-Egetræ-Sortolie-60cm" },
                    { 53, "40 cm.", 14, 5, "Hylde-Egetræ-Sortolie-40cm" },
                    { 38, "60 cm.", 10, 7, "Hylde-Egetræ-Hvidolie-60cm" },
                    { 39, "80 cm.", 10, 10, "Hylde-Egetræ-Hvidolie-80cm" },
                    { 40, "100 cm.", 10, 13, "Hylde-Egetræ-Hvidolie-100cm" },
                    { 52, "100 cm.", 13, 13, "Hylde-Egetræ-Hvidolie-100cm" },
                    { 51, "80 cm.", 13, 10, "Hylde-Egetræ-Hvidolie-80cm" },
                    { 50, "60 cm.", 13, 7, "Hylde-Egetræ-Hvidolie-60cm" },
                    { 49, "40 cm.", 13, 4, "Hylde-Egetræ-Hvidolie-40cm" },
                    { 41, "40 cm.", 11, 5, "Hylde-Egetræ-Sortolie-40cm" },
                    { 42, "60 cm.", 11, 8, "Hylde-Egetræ-Sortolie-60cm" },
                    { 44, "100 cm.", 11, 14, "Hylde-Egetræ-Sortolie-100cm" },
                    { 48, "100 cm.", 12, 15, "Hylde-Egetræ-Naturolie-100cm" },
                    { 47, "80 cm.", 12, 12, "Hylde-Egetræ-Naturolie-80cm" },
                    { 46, "60 cm.", 12, 9, "Hylde-Egetræ-Naturolie-60cm" },
                    { 33, "40 cm.", 9, 6, "Hylde-Egetræ-Naturolie-40cm" },
                    { 32, "100 cm.", 8, 14, "Hylde-Egetræ-Sortolie-100cm" },
                    { 1, "115 cm.", 18, 18, "Bænk-Egetræ-Naturolie-115cm" },
                    { 2, "170 cm.", 18, 21, "Bænk-Egetræ-Naturolie-170cm" },
                    { 13, "40 cm.", 4, 4, "Hylde-Egetræ-Hvidolie-40cm" }
                });

            migrationBuilder.InsertData(
                table: "ProductLength",
                columns: new[] { "Id", "Length", "ProductId", "ProductReferenceId", "ProductReferenceUrlName" },
                values: new object[,]
                {
                    { 14, "60 cm.", 4, 7, "Hylde-Egetræ-Hvidolie-60cm" },
                    { 15, "80 cm.", 4, 10, "Hylde-Egetræ-Hvidolie-80cm" },
                    { 16, "100 cm.", 4, 13, "Hylde-Egetræ-Hvidolie-100cm" },
                    { 10, "170 cm.", 22, 22, "Bænk-Egetræ-Hvidolie-170cm" },
                    { 9, "115 cm.", 22, 19, "Bænk-Egetræ-Hvidolie-115cm" },
                    { 17, "40 cm.", 5, 5, "Hylde-Egetræ-Sortolie-40cm" },
                    { 18, "60 cm.", 5, 8, "Hylde-Egetræ-Sortolie-60cm" },
                    { 20, "100 cm.", 5, 15, "Hylde-Egetræ-Sortolie-100cm" },
                    { 8, "170 cm.", 21, 21, "Bænk-Egetræ-Naturolie-170cm" },
                    { 7, "115 cm.", 21, 18, "Bænk-Egetræ-Naturolie-115cm" },
                    { 21, "40 cm.", 6, 6, "Hylde-Egetræ-Naturolie-40cm" },
                    { 12, "170 cm.", 23, 23, "Bænk-Egetræ-Sortolie-170cm" },
                    { 22, "60 cm.", 6, 9, "Hylde-Egetræ-Naturolie-60cm" },
                    { 24, "100 cm.", 6, 15, "Hylde-Egetræ-Naturolie-100cm" },
                    { 6, "170 cm.", 20, 23, "Bænk-Egetræ-Sortolie-170cm" },
                    { 5, "115 cm.", 20, 20, "Bænk-Egetræ-Sortolie-115cm" },
                    { 25, "40 cm.", 7, 4, "Hylde-Egetræ-Hvidolie-40cm" },
                    { 26, "60 cm.", 7, 7, "Hylde-Egetræ-Hvidolie-60cm" },
                    { 27, "80 cm.", 7, 10, "Hylde-Egetræ-Hvidolie-80cm" },
                    { 28, "100 cm.", 7, 13, "Hylde-Egetræ-Hvidolie-100cm" },
                    { 4, "170 cm.", 19, 22, "Bænk-Egetræ-Hvidolie-170cm" },
                    { 3, "115 cm.", 19, 19, "Bænk-Egetræ-Hvidolie-115cm" },
                    { 29, "40 cm.", 8, 5, "Hylde-Egetræ-Sortolie-40cm" },
                    { 30, "60 cm.", 8, 8, "Hylde-Egetræ-Sortolie-60cm" },
                    { 31, "80 cm.", 8, 11, "Hylde-Egetræ-Sortolie-80cm" },
                    { 23, "80 cm.", 6, 12, "Hylde-Egetræ-Naturolie-80cm" },
                    { 43, "80 cm.", 11, 11, "Hylde-Egetræ-Sortolie-80cm" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BagItems_ProductId",
                table: "BagItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingAddress_CustomerId",
                table: "BillingAddress",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colors_ProductId",
                table: "Colors",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponForProducts_CouponCode",
                table: "CouponForProducts",
                column: "CouponCode");

            migrationBuilder.CreateIndex(
                name: "IX_CouponForProducts_ProductId",
                table: "CouponForProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PaymentCaptureId",
                table: "Invoices",
                column: "PaymentCaptureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentCaptureId",
                table: "Orders",
                column: "PaymentCaptureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentCaptures_CustomerId",
                table: "PaymentCaptures",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLength_ProductId",
                table: "ProductLength",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Refunds_PaymentCaptureId",
                table: "Refunds",
                column: "PaymentCaptureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddress_CustomerId",
                table: "ShippingAddress",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShippingDeliveries_OrderId",
                table: "ShippingDeliveries",
                column: "OrderId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BagItems");

            migrationBuilder.DropTable(
                name: "BillingAddress");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Consents");

            migrationBuilder.DropTable(
                name: "Cookies");

            migrationBuilder.DropTable(
                name: "CouponForProducts");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "NewsSubs");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductLength");

            migrationBuilder.DropTable(
                name: "Refunds");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "ShippingAddress");

            migrationBuilder.DropTable(
                name: "ShippingDeliveries");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "PaymentCaptures");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
