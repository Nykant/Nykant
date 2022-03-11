using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NykantAPI.data.migrations.local
{
    public partial class InitialLocal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    UrlName = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    GalleryImage1 = table.Column<string>(nullable: true),
                    GalleryImage2 = table.Column<string>(nullable: true),
                    Pieces = table.Column<int>(nullable: false),
                    Path = table.Column<string>(nullable: true),
                    ExpectedDelivery = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    AssemblyPath = table.Column<string>(nullable: true),
                    EColor = table.Column<int>(nullable: false),
                    Length = table.Column<string>(nullable: true),
                    Oil = table.Column<string>(nullable: true),
                    Alt = table.Column<string>(nullable: true),
                    WeightInKg = table.Column<double>(nullable: false),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentIntent_Id = table.Column<string>(nullable: true),
                    Captured = table.Column<bool>(nullable: false),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<string>(nullable: false),
                    Taxes = table.Column<string>(nullable: false),
                    TaxLessPrice = table.Column<string>(nullable: false),
                    Currency = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    WeightInKg = table.Column<double>(nullable: false),
                    EstimatedDelivery = table.Column<DateTime>(nullable: false),
                    IsBackOrder = table.Column<bool>(nullable: false),
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
                name: "OrderItems",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    { 4, "../images/Products/Category/Desktop/opbevaringsbaenk_natur_3.png", "Bænke" }
                });

            migrationBuilder.InsertData(
                table: "Cookies",
                columns: new[] { "Name", "Category", "Description", "Domain", "Type1", "Type2" },
                values: new object[,]
                {
                    { "AntiforgeryToken", 0, "Denne cookie beskytter imod Cross-Site Request Forgery angreb", ".nykant.dk", 0, 0 },
                    { "Session", 0, "Session cookie'en gemmer et session id, som den bruger til at hente data fra session i serveren, som husker/gemmer hvad du har lagt i din kurv, gemmer dine cookie preferencer, samt giver dig en bedre checkout oplevelse.", "nykant.dk", 0, 0 },
                    { "_ga", 3, "Indsamler anonyme data om hvad du foretager dig på hjemmesiden, og sender det til google analytics, så vi kan se og bruge det til at forbedre hjemmesiden.", ".nykant.dk", 1, 0 },
                    { "_ga_*", 3, "Indsamler anonyme data om hvad du foretager dig på hjemmesiden, og sender det til google analytics, så vi kan se og bruge det til at forbedre hjemmesiden.", ".nykant.dk", 1, 0 },
                    { "__stripe_mid", 0, "Sørger for sikkerhed under betalingen via vores betalingsservice stripe. Forebygger imod svig/forfalskning. Nødvendig for at betaling kan fungere.", ".nykant.dk", 1, 0 },
                    { "__stripe_sid", 0, "Sørger for sikkerhed under betalingen via vores betalingsservice stripe. Forebygger imod svig/forfalskning. Nødvendig for at betaling kan fungere.", ".nykant.dk", 1, 0 },
                    { "m", 0, "Sørger for sikkerhed under betalingen via vores betalingsservice stripe. Forebygger imod svig/forfalskning. Nødvendig for at betaling kan fungere.", "m.stripe.com", 1, 1 },
                    { "private_machine_identifier", 0, "Sørger for sikkerhed under betalingen via vores betalingsservice stripe. Forebygger imod svig/forfalskning. Nødvendig for at betaling kan fungere.", "stripe.com", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Alt", "Amount", "AssemblyPath", "CategoryId", "Description", "EColor", "ExpectedDelivery", "GalleryImage1", "GalleryImage2", "Length", "Materials", "Name", "Note", "Number", "Oil", "Package", "Path", "Pieces", "Price", "Size", "Title", "UrlName", "WeightInKg" },
                values: new object[,]
                {
                    { 27, null, 26, "/word/Tøjstativ.docx", 1, "Vores elegante tøjstativ i massivt egetræ, er designet således at det samles udelukkende med trækiler. Bøjlestangen er en drejet rundstok, som er fræset i enderne så kilerne passer igennem. Det massive egetræsmøbel står sikkert og dekorativt med det fine snedkerarbejde, og lækre detaljer.", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_rack_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_rack_naturolie_02.png", null, "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Kiler</p></td></tr>", "Nora Tøjstativ", null, "13001 + 13001A", "Naturolie", "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Leveres usamlet i 2 kartoner - se samlevejledning</p></td></tr><tr class='no-border'><td class='width-30'><strong>Karton 1</strong></td><td> <p>Vægt: 5 kg.</p><p> Størrelse: 6.5 x 11.5 x 186 cm. (H x B x L)</p></td></tr><tr><td class='width-30'><strong>Karton 2</strong></td><td> <p>Vægt: 3 kg.</p><p>Størrelse: 5.5 x 54 x 119 cm. (H x B x L)</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", 1, 2595.0, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Højde: 180 cm.</p><p>Længde: 100 cm.</p><p>Bredde: 55 cm.</p></td></tr>", "Tøjstativ i massivt egetræ - Behandlet med naturolie", "Tøjstativ-Egetræ-Naturolie", 8.0 },
                    { 24, null, 50, "none", 4, "Denne elegante og robuste opbevaringsbænk er lavet i massivt egetræ, med drejede ben som er synlige i top. Opmagasineringen er enkel og nem at åbne. Det er en praktisk men samtidig en elegant bænk med fine detaljer, som vil føle sig hjemme hvor som helst.", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_opbevaringsbaenk_naturolie_02.png", null, "<tr><td class='width-30'><strong>Materialer:</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Læderstrop</p><p>Beslag </p></td></tr>", "Filippa Bænk", "<tr class='no-border'><td class='width-30'><strong>Note:</strong></td><td><p>Indvendige mål for opbevaring: 30 x 30 x 85 cm</p></td></tr>", "10001", "Naturolie", "<tr><td class='width-30'><strong>Pakken:</strong></td><td><p>Vægt: 24 kg.</p><p>Størrelse: 40 x 50 x 115 cm. (B x H x L)</p><p>Leveres samlet </p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", 1, 4985.0, "<tr><td class='width-30'><strong>Størrelse:</strong></td><td><p>Højde: 45 cm.</p><p>Længde: 110 cm.</p><p>Dybde: 35 cm. </p></td></tr>", "Opbevaringsbænk i massivt egetræ - Behandlet med naturolie", "Opbevaringsbænk-Egetræ-Naturolie", 24.0 },
                    { 23, null, 5, "/word/bænk.docx", 4, "Den elegante og praktiske bænk i massivt egetræ, med afrundede hjørner og synlige drejede ben, er fantastisk stabil og robust.", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_langbaenk_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_langbaenk_sortolie_02.png", "170 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p></td></tr>", "Thyra Bænken", null, "11003", "Sortolie", "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 11 x 47 x 175 cm. (H x B x L)</p><p>Vægt: 20 kg.</p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_langbaenk_naturolie_01.png", 1, 4395.0, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Højde: 47 cm.</p><p>Længde: 170 cm.</p><p>Bredde: 40 cm.</p></td></tr>", "Bænk i massivt egetræ - Behandlet med sortolie", "Bænk-Egetræ-Sortolie-170cm", 20.0 },
                    { 22, null, 10, "/word/bænk.docx", 4, "Den elegante og praktiske bænk i massivt egetræ, med afrundede hjørner og synlige drejede ben, er fantastisk stabil og robust.", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_langbaenk_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_langbaenk_hvidolie_02.png", "170 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p></td></tr>", "Thyra Bænken", null, "11002", "Hvidolie", "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 11 x 47 x 175 cm. (H x B x L)</p><p>Vægt: 20 kg.</p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_langbaenk_naturolie_01.png", 1, 4395.0, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Højde: 47 cm.</p><p>Længde: 170 cm.</p><p>Bredde: 40 cm.</p></td></tr>", "Bænk i massivt egetræ - Behandlet med hvidolie", "Bænk-Egetræ-Hvidolie-170cm", 20.0 },
                    { 21, null, 17, "/word/bænk.docx", 4, "Den elegante og praktiske bænk i massivt egetræ, med afrundede hjørner og synlige drejede ben, er fantastisk stabil og robust.", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_langbaenk_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_langbaenk_naturolie_02.png", "170 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p></td></tr>", "Thyra Bænken", null, "11001", "Naturolie", "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 11 x 47 x 175 cm. (H x B x L)</p><p>Vægt: 20 kg.</p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_langbaenk_naturolie_01.png", 1, 4395.0, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Højde: 47 cm.</p><p>Længde: 170 cm.</p><p>Bredde: 40 cm.</p></td></tr>", "Bænk i massivt egetræ - Behandlet med naturolie", "Bænk-Egetræ-Naturolie-170cm", 20.0 },
                    { 20, null, 10, "/word/bænk.docx", 4, "Den elegante og praktiske bænk i massivt egetræ, med afrundede hjørner og synlige drejede ben, er fantastisk stabil og robust.", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_kortbaenk_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_kortbaenk_sortolie_02.png", "115 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p></td></tr>", "Thyra Bænken", null, "12003", "Sortolie", "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 11 x 47 x 120 cm. (H x B x L)</p><p>Vægt: 14 kg.</p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_kortbaenk_naturolie_01.png", 1, 3665.0, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Højde: 47 cm.</p><p>Længde: 115 cm.</p><p>Bredde: 40 cm.</p></td></tr>", "Bænk i massivt egetræ - Behandlet med sortolie", "Bænk-Egetræ-Sortolie-115cm", 14.0 },
                    { 19, null, 20, "/word/bænk.docx", 4, "Den elegante og praktiske bænk i massivt egetræ, med afrundede hjørner og synlige drejede ben, er fantastisk stabil og robust.", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_kortbaenk_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_kortbaenk_hvidolie_02.png", "115 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p></td></tr>", "Thyra Bænken", null, "12002", "Hvidolie", "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 11 x 47 x 120 cm. (H x B x L)</p><p>Vægt: 14 kg.</p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_kortbaenk_naturolie_01.png", 1, 3665.0, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Højde: 47 cm.</p><p>Længde: 115 cm.</p><p>Bredde: 40 cm.</p></td></tr>", "Bænk i massivt egetræ - Behandlet med hvidolie", "Bænk-Egetræ-Hvidolie-115cm", 14.0 },
                    { 18, null, 42, "/word/bænk.docx", 4, "Den elegante og praktiske bænk i massivt egetræ, med afrundede hjørner og synlige drejede ben, er fantastisk stabil og robust.", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_kortbaenk_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_kortbaenk_naturolie_02.png", "115 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p></td></tr>", "Thyra Bænken", null, "12001", "Naturolie", "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Størrelse: 11 x 47 x 120 cm. (H x B x L)</p><p>Vægt: 14 kg.</p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_kortbaenk_naturolie_01.png", 1, 3665.0, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Højde: 47 cm.</p><p>Længde: 115 cm.</p><p>Bredde: 40 cm.</p></td></tr>", "Bænk i massivt egetræ - Behandlet med naturolie", "Bænk-Egetræ-Naturolie-115cm", 14.0 },
                    { 15, null, 0, "/word/Hylde.docx", 3, "Denne enkle hylde i massivt egetræ indeholder flere fine detaljer. De sammenskarede hyldeknægte og det skjulte nøglehulsbeslag gør at denne hylde monteres helt fladt til væggen, og uden synlig fastgørelse. Hylden fås i 4 længder, med de samme hyldeknægte som også vil kunne ophænges omvendt, da der er monteret nøglehulsbeslag som vender modsat hvis man har lyst til denne udgave af hylden.", 0, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_02.png", "100 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>", "Ingeborg Hylden", "<tr class='no-border'><td class='width-30'><strong>Note</strong></td><td><p>Tjek om plugs passer præcist til jeres væg</p></td></tr>", "17001", "Naturolie", "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse:  103x22x4.5 cm. (L x B x H)</p><p>Vægt: 3.2 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_naturolie_01.png", 1, 985.0, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Tykkelse: 2 cm.</p><p>Længde: 100 cm.</p><p>Bredde/dybde: 20 cm.</p></td></tr>", "Hylde i massivt egetræ - Behandlet med naturolie", "Hylde-Egetræ-Naturolie-100cm", 3.2000000000000002 },
                    { 14, null, 0, "/word/Hylde.docx", 3, "Denne enkle hylde i massivt egetræ indeholder flere fine detaljer. De sammenskarede hyldeknægte og det skjulte nøglehulsbeslag gør at denne hylde monteres helt fladt til væggen, og uden synlig fastgørelse. Hylden fås i 4 længder, med de samme hyldeknægte som også vil kunne ophænges omvendt, da der er monteret nøglehulsbeslag som vender modsat hvis man har lyst til denne udgave af hylden.", 2, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_02.png", "100 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>", "Ingeborg Hylden", "<tr class='no-border'><td class='width-30'><strong>Note</strong></td><td><p>Tjek om plugs passer præcist til jeres væg</p></td></tr>", "17003", "Sortolie", "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse:  103x22x4.5 cm. (L x B x H)</p><p>Vægt: 3.2 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_sortolie_01.png", 1, 985.0, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Tykkelse: 2 cm.</p><p>Længde: 100 cm.</p><p>Bredde/dybde: 20 cm.</p></td></tr>", "Hylde i massivt egetræ - Behandlet med sortolie", "Hylde-Egetræ-Sortolie-100cm", 3.2000000000000002 },
                    { 13, null, 0, "/word/Hylde.docx", 3, "Denne enkle hylde i massivt egetræ indeholder flere fine detaljer. De sammenskarede hyldeknægte og det skjulte nøglehulsbeslag gør at denne hylde monteres helt fladt til væggen, og uden synlig fastgørelse. Hylden fås i 4 længder, med de samme hyldeknægte som også vil kunne ophænges omvendt, da der er monteret nøglehulsbeslag som vender modsat hvis man har lyst til denne udgave af hylden.", 1, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_02.png", "100 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>", "Ingeborg Hylden", "<tr class='no-border'><td class='width-30'><strong>Note</strong></td><td><p>Tjek om plugs passer præcist til jeres væg</p></td></tr>", "17002", "Hvidolie", "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse:  103x22x4.5 cm. (L x B x H)</p><p>Vægt: 3.2 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_hvidolie_01.png", 1, 985.0, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Tykkelse: 2 cm.</p><p>Længde: 100 cm.</p><p>Bredde/dybde: 20 cm.</p></td></tr>", "Hylde i massivt egetræ - Behandlet med hvidolie", "Hylde-Egetræ-Hvidolie-100cm", 3.2000000000000002 },
                    { 12, null, 0, "/word/Hylde.docx", 3, "Denne enkle hylde i massivt egetræ indeholder flere fine detaljer. De sammenskarede hyldeknægte og det skjulte nøglehulsbeslag gør at denne hylde monteres helt fladt til væggen, og uden synlig fastgørelse. Hylden fås i 4 længder, med de samme hyldeknægte som også vil kunne ophænges omvendt, da der er monteret nøglehulsbeslag som vender modsat hvis man har lyst til denne udgave af hylden.", 0, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_02.png", "80 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>", "Ingeborg Hylden", "<tr class='no-border'><td class='width-30'><strong>Note</strong></td><td><p>Tjek om plugs passer præcist til jeres væg</p></td></tr>", "17011", "Naturolie", "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 83x22x4.5 cm. (L x B x H)</p><p>Vægt: 2.6 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_naturolie_01.png", 1, 885.0, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Tykkelse: 2 cm.</p><p>Længde: 80 cm.</p><p>Bredde/dybde: 20 cm.</p></td></tr>", "Hylde i massivt egetræ - Behandlet med naturolie", "Hylde-Egetræ-Naturolie-80cm", 2.6000000000000001 },
                    { 11, null, 0, "/word/Hylde.docx", 3, "Denne enkle hylde i massivt egetræ indeholder flere fine detaljer. De sammenskarede hyldeknægte og det skjulte nøglehulsbeslag gør at denne hylde monteres helt fladt til væggen, og uden synlig fastgørelse. Hylden fås i 4 længder, med de samme hyldeknægte som også vil kunne ophænges omvendt, da der er monteret nøglehulsbeslag som vender modsat hvis man har lyst til denne udgave af hylden.", 2, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_02.png", "80 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>", "Ingeborg Hylden", "<tr class='no-border'><td class='width-30'><strong>Note</strong></td><td><p>Tjek om plugs passer præcist til jeres væg</p></td></tr>", "17013", "Sortolie", "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 83x22x4.5 cm. (L x B x H)</p><p>Vægt: 2.6 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_sortolie_01.png", 1, 885.0, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Tykkelse: 2 cm.</p><p>Længde: 80 cm.</p><p>Bredde/dybde: 20 cm.</p></td></tr>", "Hylde i massivt egetræ - Behandlet med sortolie", "Hylde-Egetræ-Sortolie-80cm", 2.6000000000000001 },
                    { 25, null, 30, "none", 4, "Denne elegante og robuste opbevaringsbænk er lavet i massivt egetræ, med drejede ben som er synlige i top. Opmagasineringen er enkel og nem at åbne. Det er en praktisk men samtidig en elegant bænk med fine detaljer, som vil føle sig hjemme hvor som helst.", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_opbevaringsbaenk_hvidolie_02.png", null, "<tr><td class='width-30'><strong>Materialer:</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Læderstrop</p><p>Beslag </p></td></tr>", "Filippa Bænk", "<tr class='no-border'><td class='width-30'><strong>Note:</strong></td><td><p>Indvendige mål for opbevaring: 30 x 30 x 85 cm</p></td></tr>", "10002", "Hvidolie", "<tr><td class='width-30'><strong>Pakken:</strong></td><td><p>Vægt: 24 kg.</p><p>Størrelse: 40 x 50 x 115 cm. (B x H x L)</p><p>Leveres samlet </p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", 1, 4985.0, "<tr><td class='width-30'><strong>Størrelse:</strong></td><td><p>Højde: 45 cm.</p><p>Længde: 110 cm.</p><p>Dybde: 35 cm. </p></td></tr>", "Opbevaringsbænk i massivt egetræ - Behandlet med hvidolie", "Opbevaringsbænk-Egetræ-Hvidolie", 24.0 },
                    { 10, null, 0, "/word/Hylde.docx", 3, "Denne enkle hylde i massivt egetræ indeholder flere fine detaljer. De sammenskarede hyldeknægte og det skjulte nøglehulsbeslag gør at denne hylde monteres helt fladt til væggen, og uden synlig fastgørelse. Hylden fås i 4 længder, med de samme hyldeknægte som også vil kunne ophænges omvendt, da der er monteret nøglehulsbeslag som vender modsat hvis man har lyst til denne udgave af hylden.", 1, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_02.png", "80 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>", "Ingeborg Hylden", "<tr class='no-border'><td class='width-30'><strong>Note</strong></td><td><p>Tjek om plugs passer præcist til jeres væg</p></td></tr>", "17012", "Hvidolie", "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 83x22x4.5 cm. (L x B x H)</p><p>Vægt: 2.6 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_hvidolie_01.png", 1, 885.0, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Tykkelse: 2 cm.</p><p>Længde: 80 cm.</p><p>Bredde/dybde: 20 cm.</p></td></tr>", "Hylde i massivt egetræ - Behandlet med hvidolie", "Hylde-Egetræ-Hvidolie-80cm", 2.6000000000000001 },
                    { 8, null, 0, "/word/Hylde.docx", 3, "Denne enkle hylde i massivt egetræ indeholder flere fine detaljer. De sammenskarede hyldeknægte og det skjulte nøglehulsbeslag gør at denne hylde monteres helt fladt til væggen, og uden synlig fastgørelse. Hylden fås i 4 længder, med de samme hyldeknægte som også vil kunne ophænges omvendt, da der er monteret nøglehulsbeslag som vender modsat hvis man har lyst til denne udgave af hylden.", 2, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_02.png", "60 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>", "Ingeborg Hylden", "<tr class='no-border'><td class='width-30'><strong>Note</strong></td><td><p>Tjek om plugs passer præcist til jeres væg</p></td></tr>", "17023", "Sortolie", "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 63x22x4.5 cm. (L x B x H)</p><p>Vægt: 2 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_sortolie_01.png", 1, 785.0, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Tykkelse: 2 cm.</p><p>Længde: 60 cm.</p><p>Bredde/dybde: 20 cm.</p></td></tr>", "Hylde i massivt egetræ - Behandlet med sortolie", "Hylde-Egetræ-Sortolie-60cm", 2.0 },
                    { 7, null, 0, "/word/Hylde.docx", 3, "Denne enkle hylde i massivt egetræ indeholder flere fine detaljer. De sammenskarede hyldeknægte og det skjulte nøglehulsbeslag gør at denne hylde monteres helt fladt til væggen, og uden synlig fastgørelse. Hylden fås i 4 længder, med de samme hyldeknægte som også vil kunne ophænges omvendt, da der er monteret nøglehulsbeslag som vender modsat hvis man har lyst til denne udgave af hylden.", 1, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_02.png", "60 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>", "Ingeborg Hylden", "<tr class='no-border'><td class='width-30'><strong>Note</strong></td><td><p>Tjek om plugs passer præcist til jeres væg</p></td></tr>", "17022", "Hvidolie", "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 63x22x4.5 cm. (L x B x H)</p><p>Vægt: 2 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_hvidolie_01.png", 1, 785.0, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Tykkelse: 2 cm.</p><p>Længde: 60 cm.</p><p>Bredde/dybde: 20 cm.</p></td></tr>", "Hylde i massivt egetræ - Behandlet med hvidolie", "Hylde-Egetræ-Hvidolie-60cm", 2.0 },
                    { 6, null, 0, "/word/Hylde.docx", 3, "Denne enkle hylde i massivt egetræ indeholder flere fine detaljer. De sammenskarede hyldeknægte og det skjulte nøglehulsbeslag gør at denne hylde monteres helt fladt til væggen, og uden synlig fastgørelse. Hylden fås i 4 længder, med de samme hyldeknægte som også vil kunne ophænges omvendt, da der er monteret nøglehulsbeslag som vender modsat hvis man har lyst til denne udgave af hylden.", 0, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_02.png", "40 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>", "Ingeborg Hylden", "<tr class='no-border'><td class='width-30'><strong>Note</strong></td><td><p>Tjek om plugs passer præcist til jeres væg</p></td></tr>", "17031", "Naturolie", "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 43x22x4.5 cm. (L x B x H)</p><p>Vægt: 1.4 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_naturolie_01.png", 1, 685.0, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Tykkelse: 2 cm.</p><p>Længde: 40 cm.</p><p>Bredde/dybde: 20 cm.</p></td></tr>", "Hylde i massivt egetræ - Behandlet med naturolie", "Hylde-Egetræ-Naturolie-40cm", 1.3999999999999999 },
                    { 5, null, 0, "/word/Hylde.docx", 3, "Denne enkle hylde i massivt egetræ indeholder flere fine detaljer. De sammenskarede hyldeknægte og det skjulte nøglehulsbeslag gør at denne hylde monteres helt fladt til væggen, og uden synlig fastgørelse. Hylden fås i 4 længder, med de samme hyldeknægte som også vil kunne ophænges omvendt, da der er monteret nøglehulsbeslag som vender modsat hvis man har lyst til denne udgave af hylden.", 2, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_sortolie_02.png", "40 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>", "Ingeborg Hylden", "<tr class='no-border'><td class='width-30'><strong>Note</strong></td><td><p>Tjek om plugs passer præcist til jeres væg</p></td></tr>", "17033", "Sortolie", "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 43x22x4.5 cm. (L x B x H)</p><p>Vægt: 1.4 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_sortolie_01.png", 1, 685.0, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Tykkelse: 2 cm.</p><p>Længde: 40 cm.</p><p>Bredde/dybde: 20 cm.</p></td></tr>", "Hylde i massivt egetræ - Behandlet med sortolie", "Hylde-Egetræ-Sortolie-40cm", 1.3999999999999999 },
                    { 4, null, 0, "/word/Hylde.docx", 3, "Denne enkle hylde i massivt egetræ indeholder flere fine detaljer. De sammenskarede hyldeknægte og det skjulte nøglehulsbeslag gør at denne hylde monteres helt fladt til væggen, og uden synlig fastgørelse. Hylden fås i 4 længder, med de samme hyldeknægte som også vil kunne ophænges omvendt, da der er monteret nøglehulsbeslag som vender modsat hvis man har lyst til denne udgave af hylden.", 1, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_hvidolie_02.png", "40 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>", "Ingeborg Hylden", "<tr class='no-border'><td class='width-30'><strong>Note</strong></td><td><p>Tjek om plugs passer præcist til jeres væg</p></td></tr>", "17032", "Hvidolie", "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 43x22x4.5 cm. (L x B x H)</p><p>Vægt: 1.4 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_hvidolie_01.png", 1, 685.0, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Tykkelse: 2 cm.</p><p>Længde: 40 cm.</p><p>Bredde/dybde: 20 cm.</p></td></tr>", "Hylde i massivt egetræ - Behandlet med hvidolie", "Hylde-Egetræ-Hvidolie-40cm", 1.3999999999999999 },
                    { 17, null, 30, "/word/Bord.docx", 2, "Dette massive egetræsbord fremstår smukt og elegant med de affasede kanter, og drejede koniske ben, som skråner ud mod hjørnerne.Bordpladen er med gennemgående lameller.", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_bord_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_bord_hvidolie_02.png", null, "<tr><td class='width-30'><strong>Materialer:</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Metal fittings</p></td></tr>", "Dagmar Bordet", null, "16002", "Hvidolie", "<tr class='no-border'><td class='width-30'><strong>Pakken:</strong></td><td><p>Vægt: 22 kg.</p><p>Størrelse: 11 x 75 x 114 cm. (H x B x L)</p><p> Leveres usamlet - se samlevejledning </p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_bord_hvidolie_01.png", 1, 3585.0, "<tr><td class='width-30'><strong>Størrelse:</strong></td><td><p>Bordplade tykkelse: 2.5 cm.</p><p>Højde: 74 cm.</p><p>Længde: 110 cm.</p><p>Bredde: 70 cm.</p></td></tr>", "Bord i massivt egetræ - Behandlet med hvidolie", "Bord-Egetræ-Hvidolie", 22.0 },
                    { 16, null, 72, "/word/Bord.docx", 2, "Dette massive egetræsbord fremstår smukt og elegant med de affasede kanter, og drejede koniske ben, som skråner ud mod hjørnerne.Bordpladen er med gennemgående lameller.", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_bord_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_bord_naturolie_02.png", null, "<tr><td class='width-30'><strong>Materialer:</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Metal fittings</p></td></tr>", "Dagmar Bordet", null, "16001", "Naturolie", "<tr class='no-border'><td class='width-30'><strong>Pakken:</strong></td><td><p>Vægt: 22 kg.</p><p>Størrelse: 11 x 75 x 114 cm. (H x B x L)</p><p> Leveres usamlet - se samlevejledning </p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_bord_naturolie_01.png", 1, 3585.0, "<tr><td class='width-30'><strong>Størrelse:</strong></td><td><p>Bordplade tykkelse: 2.5 cm.</p><p>Højde: 74 cm.</p><p>Længde: 110 cm.</p><p>Bredde: 70 cm.</p></td></tr>", "Bord i massivt egetræ - Behandlet med naturolie", "Bord-Egetræ-Naturolie", 22.0 },
                    { 32, null, 10, "/word/hænge_tøjrack.docx", 1, "Vores unikke og smukke væghængte tøjstativ i massivt egetræ, er udviklet således den samles med kiler og monteres hængende ud fra væggen, med en lædderstrop.", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/Ingrid_Sortolie_1.png", "../images/Products/Gallery/Desktop/Ingrid_Sortolie_2.png", null, "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Lædderstrop</p><p>Beslag</p><p>Skruer</p></td></tr>", "Ingrid Tøjstativ", null, "14003", "Sortolie", "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Vægt: 2kg.</p><p>Størrelse: 7 x 105 x 9.5 cm. (H x L x B)</p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", 1, 1995.0, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Højde: 90 cm.</p><p>Fra væg/dybde: 40 cm.</p><p>Bredde: 105 cm.</p></td></tr>", "Hængende tøjstativ i massivt egetræ - Behandlet med sortolie", "Ophængt-Tøjstativ-Egetræ-Sortolie", 2.0 },
                    { 31, null, 15, "/word/hænge_tøjrack.docx", 1, "Vores unikke og smukke væghængte tøjstativ i massivt egetræ, er udviklet således den samles med kiler og monteres hængende ud fra væggen, med en lædderstrop.", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/Ingrid_Hvidolie_1.png", "../images/Products/Gallery/Desktop/Ingrid_Hvidolie_2.png", null, "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Lædderstrop</p><p>Beslag</p><p>Skruer</p></td></tr>", "Ingrid Tøjstativ", null, "14002", "Hvidolie", "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Vægt: 2kg.</p><p>Størrelse: 7 x 105 x 9.5 cm. (H x L x B)</p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", 1, 1995.0, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Højde: 90 cm.</p><p>Fra væg/dybde: 40 cm.</p><p>Bredde: 105 cm.</p></td></tr>", "Hængende tøjstativ i massivt egetræ - Behandlet med hvidolie", "Ophængt-Tøjstativ-Egetræ-Hvidolie", 2.0 },
                    { 30, null, 25, "/word/hænge_tøjrack.docx", 1, "Vores unikke og smukke væghængte tøjstativ i massivt egetræ, er udviklet således den samles med kiler og monteres hængende ud fra væggen, med en lædderstrop.", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/Ingrid_Naturolie_1.png", "../images/Products/Gallery/Desktop/Ingrid_Naturolie_2.png", null, "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Lædderstrop</p><p>Beslag</p><p>Skruer</p></td></tr>", "Ingrid Tøjstativ", null, "14001", "Naturolie", "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Vægt: 2kg.</p><p>Størrelse: 7 x 105 x 9.5 cm. (H x L x B)</p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", 1, 1995.0, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Højde: 90 cm.</p><p>Fra væg/dybde: 40 cm.</p><p>Bredde: 105 cm.</p></td></tr>", "Hængende tøjstativ i massivt egetræ - Behandlet med naturolie", "Ophængt-Tøjstativ-Egetræ-Naturolie", 2.0 },
                    { 29, null, 10, "/word/Tøjstativ.docx", 1, "Vores elegante tøjstativ i massivt egetræ, er designet således at det samles udelukkende med trækiler. Bøjlestangen er en drejet rundstok, som er fræset i enderne så kilerne passer igennem. Det massive egetræsmøbel står sikkert og dekorativt med det fine snedkerarbejde, og lækre detaljer.", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_rack_sortolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_rack_sortolie_02.png", null, "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Kiler</p></td></tr>", "Nora Tøjstativ", null, "13003 + 13003A", "Sortolie", "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Leveres usamlet i 2 kartoner - se samlevejledning</p></td></tr><tr class='no-border'><td class='width-30'><strong>Karton 1</strong></td><td> <p>Vægt: 5 kg.</p><p> Størrelse: 6.5 x 11.5 x 186 cm. (H x B x L)</p></td></tr><tr><td class='width-30'><strong>Karton 2</strong></td><td> <p>Vægt: 3 kg.</p><p>Størrelse: 5.5 x 54 x 119 cm. (H x B x L)</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", 1, 2595.0, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Højde: 180 cm.</p><p>Længde: 100 cm.</p><p>Bredde: 55 cm.</p></td></tr>", "Tøjstativ i massivt egetræ - Behandlet med sortolie", "Tøjstativ-Egetræ-Sortolie", 8.0 },
                    { 28, null, 16, "/word/Tøjstativ.docx", 1, "Vores elegante tøjstativ i massivt egetræ, er designet således at det samles udelukkende med trækiler. Bøjlestangen er en drejet rundstok, som er fræset i enderne så kilerne passer igennem. Det massive egetræsmøbel står sikkert og dekorativt med det fine snedkerarbejde, og lækre detaljer.", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_rack_hvidolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_rack_hvidolie_02.png", null, "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Kiler</p></td></tr>", "Nora Tøjstativ", null, "13002 + 13002A", "Hvidolie", "<tr class='no-border'><td class='width-30'><strong>Pakken</strong></td><td><p>Leveres usamlet i 2 kartoner - se samlevejledning</p></td></tr><tr class='no-border'><td class='width-30'><strong>Karton 1</strong></td><td> <p>Vægt: 5 kg.</p><p> Størrelse: 6.5 x 11.5 x 186 cm. (H x B x L)</p></td></tr><tr><td class='width-30'><strong>Karton 2</strong></td><td> <p>Vægt: 3 kg.</p><p>Størrelse: 5.5 x 54 x 119 cm. (H x B x L)</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_rack_naturolie_01.png", 1, 2595.0, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Højde: 180 cm.</p><p>Længde: 100 cm.</p><p>Bredde: 55 cm.</p></td></tr>", "Tøjstativ i massivt egetræ - Behandlet med hvidolie", "Tøjstativ-Egetræ-Hvidolie", 8.0 },
                    { 9, null, 0, "/word/Hylde.docx", 3, "Denne enkle hylde i massivt egetræ indeholder flere fine detaljer. De sammenskarede hyldeknægte og det skjulte nøglehulsbeslag gør at denne hylde monteres helt fladt til væggen, og uden synlig fastgørelse. Hylden fås i 4 længder, med de samme hyldeknægte som også vil kunne ophænges omvendt, da der er monteret nøglehulsbeslag som vender modsat hvis man har lyst til denne udgave af hylden.", 0, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_01.png", "../images/Products/Gallery/Desktop/NYKANT_hylde_naturolie_02.png", "60 cm.", "<tr><td class='width-30'><strong>Materialer</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Skruer</p><p>Beslag</p></td></tr>", "Ingeborg Hylden", "<tr class='no-border'><td class='width-30'><strong>Note</strong></td><td><p>Tjek om plugs passer præcist til jeres væg</p></td></tr>", "17021", "Naturolie", "<tr><td class='width-30'><strong>Pakken</strong></td><td><p>Størelse: 63x22x4.5 cm. (L x B x H)</p><p>Vægt: 2 kg. </p><p>Leveres usamlet - se samlevejledning</p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_hylde_naturolie_01.png", 1, 785.0, "<tr><td class='width-30'><strong>Størrelse</strong></td><td><p>Tykkelse: 2 cm.</p><p>Længde: 60 cm.</p><p>Bredde/dybde: 20 cm.</p></td></tr>", "Hylde i massivt egetræ - Behandlet med naturolie", "Hylde-Egetræ-Naturolie-60cm", 2.0 },
                    { 26, null, 20, "none", 4, "Denne elegante og robuste opbevaringsbænk er lavet i massivt egetræ, med drejede ben som er synlige i top. Opmagasineringen er enkel og nem at åbne. Det er en praktisk men samtidig en elegant bænk med fine detaljer, som vil føle sig hjemme hvor som helst.", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/Products/Gallery/Desktop/NYKANT_opbevaringsbaenk_sort_01.png", "../images/Products/Gallery/Desktop/NYKANT_opbevaringsbaenk_sort_02.png", null, "<tr><td class='width-30'><strong>Materialer:</strong></td><td><p>Bæredygtigt FSC certificeret egetræ</p><p>Olie</p><p>Læderstrop</p><p>Beslag </p></td></tr>", "Filippa Bænk", "<tr class='no-border'><td class='width-30'><strong>Note:</strong></td><td><p>Indvendige mål for opbevaring: 30 x 30 x 85 cm</p></td></tr>", "10003", "Sortolie", "<tr><td class='width-30'><strong>Pakken:</strong></td><td><p>Vægt: 24 kg.</p><p>Størrelse: 40 x 50 x 115 cm. (B x H x L)</p><p>Leveres samlet </p></td></tr>", "C:/Users/Christian/Documents/GitHub/Nykant/NykantMVC/wwwroot/images/Products/NYKANT_opbevaringsbaenk_naturolie_01.png", 1, 4985.0, "<tr><td class='width-30'><strong>Størrelse:</strong></td><td><p>Højde: 45 cm.</p><p>Længde: 110 cm.</p><p>Dybde: 35 cm. </p></td></tr>", "Opbevaringsbænk i massivt egetræ - Behandlet med sortolie", "Opbevaringsbænk-Egetræ-Sortolie", 24.0 }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "EColor", "ImgSrc", "ProductId", "ProductSourceId", "ProductSourceUrlName" },
                values: new object[,]
                {
                    { 77, 0, "../images/Products/Color/Desktop/NYKANT_rack_naturolie_02.png", 27, 27, "Tøjstativ-Egetræ-Naturolie" },
                    { 38, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 13, 14, "Hylde-Egetræ-Sortolie-100cm" },
                    { 37, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 13, 13, "Hylde-Egetræ-Hvidolie-100cm" },
                    { 36, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 12, 12, "Hylde-Egetræ-Naturolie-80cm" },
                    { 35, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 12, 11, "Hylde-Egetræ-Sortolie-80cm" },
                    { 34, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 12, 10, "Hylde-Egetræ-Hvidolie-80cm" },
                    { 33, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 11, 12, "Hylde-Egetræ-Naturolie-80cm" },
                    { 31, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 11, 10, "Hylde-Egetræ-Hvidolie-80cm" },
                    { 30, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 10, 12, "Hylde-Egetræ-Naturolie-80cm" },
                    { 29, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 10, 11, "Hylde-Egetræ-Sortolie-80cm" },
                    { 28, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 10, 10, "Hylde-Egetræ-Hvidolie-80cm" },
                    { 27, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 9, 9, "Hylde-Egetræ-Naturolie-60cm" },
                    { 26, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 9, 8, "Hylde-Egetræ-Sortolie-60cm" },
                    { 25, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 9, 7, "Hylde-Egetræ-Hvidolie-60cm" },
                    { 24, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 8, 9, "Hylde-Egetræ-Naturolie-60cm" },
                    { 39, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 13, 15, "Hylde-Egetræ-Naturolie-100cm" },
                    { 23, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 8, 8, "Hylde-Egetræ-Sortolie-60cm" },
                    { 21, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 7, 9, "Hylde-Egetræ-Naturolie-60cm" },
                    { 20, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 7, 8, "Hylde-Egetræ-Sortolie-60cm" },
                    { 19, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 7, 7, "Hylde-Egetræ-Hvidolie-60cm" },
                    { 18, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 6, 6, "Hylde-Egetræ-Naturolie-40cm" },
                    { 17, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 6, 5, "Hylde-Egetræ-Sortolie-40cm" },
                    { 16, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 6, 4, "Hylde-Egetræ-Hvidolie-40cm" },
                    { 15, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 5, 6, "Hylde-Egetræ-Naturolie-40cm" },
                    { 14, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 5, 5, "Hylde-Egetræ-Sortolie-40cm" },
                    { 13, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 5, 4, "Hylde-Egetræ-Hvidolie-40cm" },
                    { 12, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 4, 6, "Hylde-Egetræ-Naturolie-40cm" },
                    { 11, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 4, 5, "Hylde-Egetræ-Sortolie-40cm" },
                    { 10, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 4, 4, "Hylde-Egetræ-Hvidolie-40cm" },
                    { 49, 1, "../images/Products/Color/Desktop/bord_hvid_2.png", 17, 17, "Bord-Egetræ-Hvidolie" },
                    { 48, 0, "../images/Products/Color/Desktop/bord_natur_2.png", 17, 16, "Bord-Egetræ-Naturolie" },
                    { 22, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 8, 7, "Hylde-Egetræ-Hvidolie-60cm" },
                    { 47, 1, "../images/Products/Color/Desktop/bord_hvid_2.png", 16, 17, "Bord-Egetræ-Hvidolie" },
                    { 40, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 14, 13, "Hylde-Egetræ-Hvidolie-100cm" },
                    { 42, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 14, 15, "Hylde-Egetræ-Naturolie-100cm" },
                    { 76, 2, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_sort_01.png", 26, 26, "Opbevaringsbænk-Egetræ-Sortolie" },
                    { 75, 1, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png", 26, 25, "Opbevaringsbænk-Egetræ-Hvidolie" },
                    { 74, 0, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png", 26, 24, "Opbevaringsbænk-Egetræ-Naturolie" },
                    { 73, 2, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_sort_01.png", 25, 26, "Opbevaringsbænk-Egetræ-Sortolie" },
                    { 72, 1, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png", 25, 25, "Opbevaringsbænk-Egetræ-Hvidolie" },
                    { 71, 0, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png", 25, 24, "Opbevaringsbænk-Egetræ-Naturolie" },
                    { 70, 2, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_sort_01.png", 24, 26, "Opbevaringsbænk-Egetræ-Sortolie" },
                    { 69, 1, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png", 24, 25, "Opbevaringsbænk-Egetræ-Hvidolie" },
                    { 68, 0, "../images/Products/Color/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png", 24, 24, "Opbevaringsbænk-Egetræ-Naturolie" },
                    { 67, 2, "../images/Products/Color/Desktop/NYKANT_langbaenk_sortolie_02.png", 23, 23, "Bænk-Egetræ-Sortolie-170cm" },
                    { 66, 1, "../images/Products/Color/Desktop/NYKANT_langbaenk_hvidolie_02.png", 23, 22, "Bænk-Egetræ-Hvidolie-170cm" },
                    { 65, 0, "../images/Products/Color/Desktop/NYKANT_langbaenk_naturolie_02.png", 23, 21, "Bænk-Egetræ-Naturolie-170cm" },
                    { 64, 2, "../images/Products/Color/Desktop/NYKANT_langbaenk_sortolie_02.png", 22, 23, "Bænk-Egetræ-Sortolie-170cm" },
                    { 63, 1, "../images/Products/Color/Desktop/NYKANT_langbaenk_hvidolie_02.png", 22, 22, "Bænk-Egetræ-Hvidolie-170cm" },
                    { 41, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 14, 14, "Hylde-Egetræ-Sortolie-100cm" },
                    { 62, 0, "../images/Products/Color/Desktop/NYKANT_langbaenk_naturolie_02.png", 22, 21, "Bænk-Egetræ-Naturolie-170cm" },
                    { 60, 1, "../images/Products/Color/Desktop/NYKANT_langbaenk_hvidolie_02.png", 21, 22, "Bænk-Egetræ-Hvidolie-170cm" },
                    { 59, 0, "../images/Products/Color/Desktop/NYKANT_langbaenk_naturolie_02.png", 21, 21, "Bænk-Egetræ-Naturolie-170cm" },
                    { 58, 2, "../images/Products/Color/Desktop/NYKANT_kortbaenk_sortolie_02.png", 20, 20, "Bænk-Egetræ-Sortolie-115cm" },
                    { 57, 1, "../images/Products/Color/Desktop/kortbaenk_hvid_2.png", 20, 19, "Bænk-Egetræ-Hvidolie-115cm" },
                    { 56, 0, "../images/Products/Color/Desktop/kortbaenk_natur_2.png", 20, 18, "Bænk-Egetræ-Naturolie-115cm" },
                    { 55, 2, "../images/Products/Color/Desktop/NYKANT_kortbaenk_sortolie_02.png", 19, 20, "Bænk-Egetræ-Sortolie-115cm" },
                    { 54, 1, "../images/Products/Color/Desktop/kortbaenk_hvid_2.png", 19, 19, "Bænk-Egetræ-Hvidolie-115cm" },
                    { 53, 0, "../images/Products/Color/Desktop/kortbaenk_natur_2.png", 19, 18, "Bænk-Egetræ-Naturolie-115cm" },
                    { 52, 2, "../images/Products/Color/Desktop/NYKANT_kortbaenk_sortolie_02.png", 18, 20, "Bænk-Egetræ-Sortolie-115cm" },
                    { 51, 1, "../images/Products/Color/Desktop/kortbaenk_hvid_2.png", 18, 19, "Bænk-Egetræ-Hvidolie-115cm" },
                    { 50, 0, "../images/Products/Color/Desktop/kortbaenk_natur_2.png", 18, 18, "Bænk-Egetræ-Naturolie-115cm" },
                    { 45, 0, "../images/Products/Color/Desktop/hylde_natur_1.png", 15, 15, "Hylde-Egetræ-Naturolie-100cm" },
                    { 44, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 15, 14, "Hylde-Egetræ-Sortolie-100cm" },
                    { 43, 1, "../images/Products/Color/Desktop/hylde_hvid_1.png", 15, 13, "Hylde-Egetræ-Hvidolie-100cm" },
                    { 61, 2, "../images/Products/Color/Desktop/NYKANT_langbaenk_sortolie_02.png", 21, 23, "Bænk-Egetræ-Sortolie-170cm" },
                    { 46, 0, "../images/Products/Color/Desktop/bord_natur_2.png", 16, 16, "Bord-Egetræ-Naturolie" },
                    { 32, 2, "../images/Products/Color/Desktop/hylde_sort_1.png", 11, 11, "Hylde-Egetræ-Sortolie-80cm" },
                    { 80, 0, "../images/Products/Color/Desktop/NYKANT_rack_naturolie_02.png", 28, 27, "Tøjstativ-Egetræ-Naturolie" },
                    { 91, 2, "../images/Products/Color/Desktop/Ingrid_sort_2.png", 31, 32, "Ophængt-Tøjstativ-Egetræ-Sortolie" },
                    { 90, 1, "../images/Products/Color/Desktop/Ingrid_hvid_2.png", 31, 31, "Ophængt-Tøjstativ-Egetræ-Hvidolie" },
                    { 89, 0, "../images/Products/Color/Desktop/Ingrid_natur_2.png", 31, 30, "Ophængt-Tøjstativ-Egetræ-Naturolie" },
                    { 83, 0, "../images/Products/Color/Desktop/NYKANT_rack_naturolie_02.png", 29, 27, "Tøjstativ-Egetræ-Naturolie" },
                    { 86, 0, "../images/Products/Color/Desktop/Ingrid_natur_2.png", 30, 30, "Ophængt-Tøjstativ-Egetræ-Naturolie" },
                    { 88, 2, "../images/Products/Color/Desktop/Ingrid_sort_2.png", 30, 32, "Ophængt-Tøjstativ-Egetræ-Sortolie" },
                    { 79, 2, "../images/Products/Color/Desktop/NYKANT_rack_sortolie_02.png", 27, 29, "Tøjstativ-Egetræ-Sortolie" },
                    { 78, 1, "../images/Products/Color/Desktop/NYKANT_rack_hvidolie_02.png", 27, 28, "Tøjstativ-Egetræ-Hvidolie" },
                    { 92, 0, "../images/Products/Color/Desktop/Ingrid_natur_2.png", 32, 30, "Ophængt-Tøjstativ-Egetræ-Naturolie" },
                    { 93, 1, "../images/Products/Color/Desktop/Ingrid_hvid_2.png", 32, 31, "Ophængt-Tøjstativ-Egetræ-Hvidolie" },
                    { 87, 1, "../images/Products/Color/Desktop/Ingrid_hvid_2.png", 30, 31, "Ophængt-Tøjstativ-Egetræ-Hvidolie" },
                    { 84, 1, "../images/Products/Color/Desktop/NYKANT_rack_hvidolie_02.png", 29, 28, "Tøjstativ-Egetræ-Hvidolie" },
                    { 85, 2, "../images/Products/Color/Desktop/NYKANT_rack_sortolie_02.png", 29, 29, "Tøjstativ-Egetræ-Sortolie" },
                    { 82, 2, "../images/Products/Color/Desktop/NYKANT_rack_sortolie_02.png", 28, 29, "Tøjstativ-Egetræ-Sortolie" },
                    { 81, 1, "../images/Products/Color/Desktop/NYKANT_rack_hvidolie_02.png", 28, 28, "Tøjstativ-Egetræ-Hvidolie" },
                    { 94, 2, "../images/Products/Color/Desktop/Ingrid_sort_2.png", 32, 32, "Ophængt-Tøjstativ-Egetræ-Sortolie" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ImageType", "ProductId", "Size", "Source", "Source2" },
                values: new object[,]
                {
                    { 52, 0, 19, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_hvidolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_hvidolie_01.png" },
                    { 53, 0, 19, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_hvidolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_hvidolie_02.png" },
                    { 54, 0, 19, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_hvidolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_hvidolie_03.png" },
                    { 280, 1, 19, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_hvidolie_01.png", null },
                    { 287, 1, 21, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_naturolie_02.png", null },
                    { 286, 1, 21, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_naturolie_01.png", null },
                    { 60, 0, 21, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_naturolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_naturolie_03.png" },
                    { 281, 1, 19, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_hvidolie_02.png", null },
                    { 282, 1, 19, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_hvidolie_03.png", null },
                    { 97, 0, 28, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_hvidolie_04.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_04.png" },
                    { 55, 0, 20, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_sortolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_sortolie_01.png" },
                    { 95, 0, 28, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_hvidolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_02.png" },
                    { 94, 0, 28, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_hvidolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_01.png" },
                    { 56, 0, 20, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_sortolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_sortolie_02.png" },
                    { 57, 0, 20, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_sortolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_sortolie_03.png" },
                    { 283, 1, 20, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_sortolie_01.png", null },
                    { 59, 0, 21, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_naturolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_naturolie_02.png" },
                    { 98, 0, 28, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_hvidolie_05.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_05.png" },
                    { 58, 0, 21, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_naturolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_naturolie_01.png" },
                    { 284, 1, 20, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_sortolie_02.png", null },
                    { 285, 1, 20, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_sortolie_03.png", null },
                    { 96, 0, 28, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_hvidolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_03.png" },
                    { 99, 0, 28, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_hvidolie_06.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_hvidolie_06.png" },
                    { 277, 1, 18, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_naturolie_01.png", null },
                    { 279, 1, 18, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_naturolie_03.png", null },
                    { 35, 0, 13, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    { 36, 0, 13, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    { 262, 1, 13, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_01.png", null },
                    { 263, 1, 13, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_02.png", null },
                    { 264, 1, 13, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_03.png", null },
                    { 113, 0, 32, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Sortolie_2.png", "../images/Products/Details_Fullscreen/Desktop/Ingrid_Sortolie_2.png" },
                    { 100, 0, 29, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_sortolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_01.png" },
                    { 37, 0, 14, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_01.png" },
                    { 38, 0, 14, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_02.png" },
                    { 39, 0, 14, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_03.png" },
                    { 265, 1, 14, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_01.png", null },
                    { 266, 1, 14, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_02.png", null },
                    { 267, 1, 14, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_03.png", null },
                    { 328, 1, 28, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_hvidolie_06.png", null },
                    { 327, 1, 28, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_hvidolie_05.png", null },
                    { 40, 0, 15, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_01.png" },
                    { 41, 0, 15, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_02.png" },
                    { 42, 0, 15, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_03.png" },
                    { 268, 1, 15, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_01.png", null },
                    { 269, 1, 15, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_02.png", null },
                    { 270, 1, 15, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_03.png", null },
                    { 326, 1, 28, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_hvidolie_04.png", null },
                    { 325, 1, 28, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_hvidolie_03.png", null },
                    { 324, 1, 28, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_hvidolie_02.png", null },
                    { 49, 0, 18, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_naturolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_naturolie_01.png" },
                    { 50, 0, 18, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_naturolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_naturolie_02.png" },
                    { 51, 0, 18, 2, "../images/Products/Details_Slide/Desktop/NYKANT_kortbaenk_naturolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_kortbaenk_naturolie_03.png" },
                    { 288, 1, 21, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_naturolie_03.png", null },
                    { 278, 1, 18, 2, "../images/Products/Details_Button/Desktop/NYKANT_kortbaenk_naturolie_02.png", null },
                    { 323, 1, 28, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_hvidolie_01.png", null },
                    { 114, 0, 32, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Sortolie_3.png", "../images/Products/Details_Fullscreen/Desktop/Ingrid_Sortolie_3.png" },
                    { 62, 0, 22, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_hvidolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_hvidolie_02.png" },
                    { 321, 1, 27, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_naturolie_05.png", null },
                    { 90, 0, 27, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_naturolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_03.png" },
                    { 89, 0, 27, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_naturolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_02.png" },
                    { 74, 0, 25, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png" },
                    { 75, 0, 25, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_02.png" },
                    { 76, 0, 25, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_03.png" },
                    { 77, 0, 25, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_04.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_04.png" },
                    { 78, 0, 25, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_05.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_05.png" },
                    { 79, 0, 25, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_06.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_06.png" },
                    { 80, 0, 25, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_hvidolie_07.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_hvidolie_07.png" },
                    { 302, 1, 25, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_01.png", null },
                    { 303, 1, 25, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_02.png", null },
                    { 304, 1, 25, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_03.png", null },
                    { 305, 1, 25, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_04.png", null },
                    { 306, 1, 25, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_05.png", null },
                    { 307, 1, 25, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_06.png", null },
                    { 308, 1, 25, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_hvidolie_07.png", null },
                    { 88, 0, 27, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_naturolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_01.png" },
                    { 81, 0, 26, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_01.png" },
                    { 82, 0, 26, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_02.png" },
                    { 83, 0, 26, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_03.png" },
                    { 84, 0, 26, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_04.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_04.png" },
                    { 85, 0, 26, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_05.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_05.png" },
                    { 86, 0, 26, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_06.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_06.png" },
                    { 87, 0, 26, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_sort_07.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_sort_07.png" },
                    { 309, 1, 26, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_01.png", null },
                    { 310, 1, 26, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_02.png", null },
                    { 311, 1, 26, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_03.png", null },
                    { 312, 1, 26, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_04.png", null },
                    { 314, 1, 26, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_05.png", null },
                    { 91, 0, 27, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_naturolie_04.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_04.png" },
                    { 322, 1, 27, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_naturolie_06.png", null },
                    { 301, 1, 24, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_07.png", null },
                    { 299, 1, 24, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_05.png", null },
                    { 61, 0, 22, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_hvidolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_hvidolie_01.png" },
                    { 34, 0, 13, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    { 63, 0, 22, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_hvidolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_hvidolie_03.png" },
                    { 289, 1, 22, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_hvidolie_01.png", null },
                    { 290, 1, 22, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_hvidolie_02.png", null },
                    { 291, 1, 22, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_hvidolie_03.png", null },
                    { 320, 1, 27, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_naturolie_04.png", null },
                    { 319, 1, 27, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_naturolie_03.png", null },
                    { 318, 1, 27, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_naturolie_02.png", null },
                    { 64, 0, 23, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_sortolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_sortolie_01.png" },
                    { 65, 0, 23, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_sortolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_sortolie_02.png" },
                    { 66, 0, 23, 2, "../images/Products/Details_Slide/Desktop/NYKANT_langbaenk_sortolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_langbaenk_sortolie_03.png" },
                    { 292, 1, 23, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_sortolie_01.png", null },
                    { 293, 1, 23, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_sortolie_02.png", null },
                    { 294, 1, 23, 2, "../images/Products/Details_Button/Desktop/NYKANT_langbaenk_sortolie_03.png", null },
                    { 317, 1, 27, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_naturolie_01.png", null },
                    { 93, 0, 27, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_naturolie_06.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_06.png" },
                    { 92, 0, 27, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_naturolie_05.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_naturolie_05.png" },
                    { 67, 0, 24, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png" },
                    { 68, 0, 24, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_02.png" },
                    { 69, 0, 24, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_03.png" },
                    { 70, 0, 24, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_04.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_04.png" },
                    { 71, 0, 24, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_05.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_05.png" },
                    { 72, 0, 24, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_06.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_06.png" },
                    { 73, 0, 24, 2, "../images/Products/Details_Slide/Desktop/NYKANT_opbevaringsbaenk_naturolie_07.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_opbevaringsbaenk_naturolie_07.png" },
                    { 295, 1, 24, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_01.png", null },
                    { 296, 1, 24, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_02.png", null },
                    { 297, 1, 24, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_03.png", null },
                    { 298, 1, 24, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_04.png", null },
                    { 300, 1, 24, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_naturolie_06.png", null },
                    { 101, 0, 29, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_sortolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_02.png" },
                    { 316, 1, 26, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_07.png", null },
                    { 103, 0, 29, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_sortolie_04.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_04.png" },
                    { 239, 1, 5, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_02.png", null },
                    { 240, 1, 5, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_03.png", null },
                    { 13, 0, 6, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_01.png" },
                    { 14, 0, 6, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_02.png" },
                    { 15, 0, 6, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_03.png" },
                    { 241, 1, 6, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_01.png", null },
                    { 242, 1, 6, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_02.png", null },
                    { 243, 1, 6, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_03.png", null },
                    { 337, 1, 30, 2, "../images/Products/Details_Button/Desktop/Ingrid_Naturolie_3.png", null },
                    { 336, 1, 30, 2, "../images/Products/Details_Button/Desktop/Ingrid_Naturolie_2.png", null },
                    { 335, 1, 30, 2, "../images/Products/Details_Button/Desktop/Ingrid_Naturolie_1.png", null },
                    { 16, 0, 7, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    { 17, 0, 7, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    { 18, 0, 7, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    { 244, 1, 7, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_01.png", null },
                    { 245, 1, 7, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_02.png", null },
                    { 246, 1, 7, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_03.png", null },
                    { 108, 0, 30, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Naturolie_3.png", "../images/Products/Details_Fullscreen/Desktop/Ingrid_Naturolie_3.png" },
                    { 107, 0, 30, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Naturolie_2.png", "../images/Products/Details_Fullscreen/Desktop/Ingrid_Naturolie_2.png" },
                    { 106, 0, 30, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Naturolie_1.png", "../images/Products/Details_Fullscreen/Desktop/Ingrid_Naturolie_1.png" },
                    { 102, 0, 29, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_sortolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_03.png" },
                    { 20, 0, 8, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_02.png" },
                    { 21, 0, 8, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_03.png" },
                    { 247, 1, 8, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_01.png", null },
                    { 248, 1, 8, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_02.png", null },
                    { 249, 1, 8, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_03.png", null },
                    { 22, 0, 9, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_01.png" },
                    { 238, 1, 5, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_01.png", null },
                    { 12, 0, 5, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_03.png" },
                    { 11, 0, 5, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_02.png" },
                    { 10, 0, 5, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_01.png" },
                    { 341, 1, 32, 2, "../images/Products/Details_Button/Desktop/Ingrid_Sortolie_1.png", null },
                    { 342, 1, 32, 2, "../images/Products/Details_Button/Desktop/Ingrid_Sortolie_2.png", null },
                    { 343, 1, 32, 2, "../images/Products/Details_Button/Desktop/Ingrid_Sortolie_3.png", null },
                    { 112, 0, 32, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Sortolie_1.png", "../images/Products/Details_Fullscreen/Desktop/Ingrid_Sortolie_1.png" },
                    { 43, 0, 16, 2, "../images/Products/Details_Slide/Desktop/NYKANT_bord_naturolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_bord_naturolie_01.png" },
                    { 44, 0, 16, 2, "../images/Products/Details_Slide/Desktop/NYKANT_bord_naturolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_bord_naturolie_02.png" },
                    { 45, 0, 16, 2, "../images/Products/Details_Slide/Desktop/NYKANT_bord_naturolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_bord_naturolie_03.png" },
                    { 271, 1, 16, 2, "../images/Products/Details_Button/Desktop/NYKANT_bord_naturolie_01.png", null },
                    { 272, 1, 16, 2, "../images/Products/Details_Button/Desktop/NYKANT_bord_naturolie_02.png", null },
                    { 273, 1, 16, 2, "../images/Products/Details_Button/Desktop/NYKANT_bord_naturolie_03.png", null },
                    { 46, 0, 17, 2, "../images/Products/Details_Slide/Desktop/NYKANT_bord_hvidolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_bord_hvidolie_01.png" },
                    { 47, 0, 17, 2, "../images/Products/Details_Slide/Desktop/NYKANT_bord_hvidolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_bord_hvidolie_02.png" },
                    { 48, 0, 17, 2, "../images/Products/Details_Slide/Desktop/NYKANT_bord_hvidolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_bord_hvidolie_03.png" },
                    { 23, 0, 9, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_02.png" },
                    { 274, 1, 17, 2, "../images/Products/Details_Button/Desktop/NYKANT_bord_hvidolie_01.png", null },
                    { 276, 1, 17, 2, "../images/Products/Details_Button/Desktop/NYKANT_bord_hvidolie_03.png", null },
                    { 340, 1, 31, 2, "../images/Products/Details_Button/Desktop/Ingrid_Hvidolie_3.png", null },
                    { 339, 1, 31, 2, "../images/Products/Details_Button/Desktop/Ingrid_Hvidolie_2.png", null },
                    { 338, 1, 31, 2, "../images/Products/Details_Button/Desktop/Ingrid_Hvidolie_1.png", null },
                    { 7, 0, 4, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    { 8, 0, 4, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    { 9, 0, 4, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    { 235, 1, 4, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_01.png", null },
                    { 236, 1, 4, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_02.png", null },
                    { 237, 1, 4, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_03.png", null },
                    { 111, 0, 31, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Hvidolie_3.png", "../images/Products/Details_Fullscreen/Desktop/Ingrid_Hvidolie_3.png" },
                    { 110, 0, 31, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Hvidolie_2.png", "../images/Products/Details_Fullscreen/Desktop/Ingrid_Hvidolie_2.png" },
                    { 109, 0, 31, 2, "../images/Products/Details_Slide/Desktop/Ingrid_Hvidolie_1.png", "../images/Products/Details_Fullscreen/Desktop/Ingrid_Hvidolie_1.png" },
                    { 275, 1, 17, 2, "../images/Products/Details_Button/Desktop/NYKANT_bord_hvidolie_02.png", null },
                    { 24, 0, 9, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_03.png" },
                    { 19, 0, 8, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_01.png" },
                    { 251, 1, 9, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_02.png", null },
                    { 253, 1, 10, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_01.png", null },
                    { 254, 1, 10, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_02.png", null },
                    { 255, 1, 10, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_hvidolie_03.png", null },
                    { 331, 1, 29, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_sortolie_03.png", null },
                    { 250, 1, 9, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_01.png", null },
                    { 330, 1, 29, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_sortolie_02.png", null },
                    { 28, 0, 11, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_01.png" },
                    { 29, 0, 11, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_02.png" },
                    { 30, 0, 11, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_sortolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_sortolie_03.png" },
                    { 256, 1, 11, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_01.png", null },
                    { 257, 1, 11, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_02.png", null },
                    { 258, 1, 11, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_sortolie_03.png", null },
                    { 329, 1, 29, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_sortolie_01.png", null },
                    { 105, 0, 29, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_sortolie_06.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_06.png" },
                    { 104, 0, 29, 2, "../images/Products/Details_Slide/Desktop/NYKANT_rack_sortolie_05.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_rack_sortolie_05.png" },
                    { 31, 0, 12, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_01.png" },
                    { 32, 0, 12, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_02.png" },
                    { 33, 0, 12, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_naturolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_naturolie_03.png" },
                    { 259, 1, 12, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_01.png", null },
                    { 260, 1, 12, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_02.png", null },
                    { 261, 1, 12, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_03.png", null },
                    { 27, 0, 10, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_03.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_03.png" },
                    { 26, 0, 10, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_02.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_02.png" },
                    { 315, 1, 26, 2, "../images/Products/Details_Button/Desktop/NYKANT_opbevaringsbaenk_sort_06.png", null },
                    { 25, 0, 10, 2, "../images/Products/Details_Slide/Desktop/NYKANT_hylde_hvidolie_01.png", "../images/Products/Details_Fullscreen/Desktop/NYKANT_hylde_hvidolie_01.png" },
                    { 333, 1, 29, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_sortolie_05.png", null },
                    { 334, 1, 29, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_sortolie_06.png", null },
                    { 252, 1, 9, 2, "../images/Products/Details_Button/Desktop/NYKANT_hylde_naturolie_03.png", null },
                    { 332, 1, 29, 2, "../images/Products/Details_Button/Desktop/NYKANT_rack_sortolie_04.png", null }
                });

            migrationBuilder.InsertData(
                table: "ProductLength",
                columns: new[] { "Id", "Length", "ProductId", "ProductReferenceId", "ProductReferenceUrlName" },
                values: new object[,]
                {
                    { 43, "80 cm.", 11, 11, "Hylde-Egetræ-Sortolie-80cm" },
                    { 53, "40 cm.", 14, 5, "Hylde-Egetræ-Sortolie-40cm" },
                    { 54, "60 cm.", 14, 8, "Hylde-Egetræ-Sortolie-60cm" },
                    { 55, "80 cm.", 14, 11, "Hylde-Egetræ-Sortolie-80cm" },
                    { 42, "60 cm.", 11, 8, "Hylde-Egetræ-Sortolie-60cm" },
                    { 41, "40 cm.", 11, 5, "Hylde-Egetræ-Sortolie-40cm" },
                    { 3, "115 cm.", 19, 19, "Bænk-Egetræ-Hvidolie-115cm" },
                    { 13, "40 cm.", 4, 4, "Hylde-Egetræ-Hvidolie-40cm" },
                    { 14, "60 cm.", 4, 7, "Hylde-Egetræ-Hvidolie-60cm" },
                    { 15, "80 cm.", 4, 10, "Hylde-Egetræ-Hvidolie-80cm" },
                    { 56, "100 cm.", 14, 14, "Hylde-Egetræ-Sortolie-100cm" },
                    { 25, "40 cm.", 7, 4, "Hylde-Egetræ-Hvidolie-40cm" },
                    { 4, "170 cm.", 19, 22, "Bænk-Egetræ-Hvidolie-170cm" },
                    { 33, "40 cm.", 9, 6, "Hylde-Egetræ-Naturolie-40cm" },
                    { 29, "40 cm.", 8, 5, "Hylde-Egetræ-Sortolie-40cm" },
                    { 30, "60 cm.", 8, 8, "Hylde-Egetræ-Sortolie-60cm" },
                    { 6, "170 cm.", 20, 23, "Bænk-Egetræ-Sortolie-170cm" },
                    { 5, "115 cm.", 20, 20, "Bænk-Egetræ-Sortolie-115cm" },
                    { 31, "80 cm.", 8, 11, "Hylde-Egetræ-Sortolie-80cm" },
                    { 52, "100 cm.", 13, 13, "Hylde-Egetræ-Hvidolie-100cm" },
                    { 51, "80 cm.", 13, 10, "Hylde-Egetræ-Hvidolie-80cm" },
                    { 50, "60 cm.", 13, 7, "Hylde-Egetræ-Hvidolie-60cm" },
                    { 32, "100 cm.", 8, 14, "Hylde-Egetræ-Sortolie-100cm" },
                    { 45, "40 cm.", 12, 6, "Hylde-Egetræ-Naturolie-40cm" },
                    { 46, "60 cm.", 12, 9, "Hylde-Egetræ-Naturolie-60cm" },
                    { 47, "80 cm.", 12, 12, "Hylde-Egetræ-Naturolie-80cm" },
                    { 48, "100 cm.", 12, 15, "Hylde-Egetræ-Naturolie-100cm" },
                    { 44, "100 cm.", 11, 14, "Hylde-Egetræ-Sortolie-100cm" },
                    { 16, "100 cm.", 4, 13, "Hylde-Egetræ-Hvidolie-100cm" },
                    { 35, "80 cm.", 9, 12, "Hylde-Egetræ-Naturolie-80cm" },
                    { 36, "100 cm.", 9, 16, "Hylde-Egetræ-Naturolie-100cm" },
                    { 9, "115 cm.", 22, 19, "Bænk-Egetræ-Hvidolie-115cm" },
                    { 10, "170 cm.", 22, 22, "Bænk-Egetræ-Hvidolie-170cm" },
                    { 2, "170 cm.", 18, 21, "Bænk-Egetræ-Naturolie-170cm" },
                    { 1, "115 cm.", 18, 18, "Bænk-Egetræ-Naturolie-115cm" },
                    { 26, "60 cm.", 7, 7, "Hylde-Egetræ-Hvidolie-60cm" },
                    { 27, "80 cm.", 7, 10, "Hylde-Egetræ-Hvidolie-80cm" },
                    { 28, "100 cm.", 7, 13, "Hylde-Egetræ-Hvidolie-100cm" },
                    { 37, "40 cm.", 10, 4, "Hylde-Egetræ-Hvidolie-40cm" },
                    { 24, "100 cm.", 6, 15, "Hylde-Egetræ-Naturolie-100cm" },
                    { 23, "80 cm.", 6, 12, "Hylde-Egetræ-Naturolie-80cm" },
                    { 22, "60 cm.", 6, 9, "Hylde-Egetræ-Naturolie-60cm" },
                    { 11, "115 cm.", 23, 20, "Bænk-Egetræ-Sortolie-115cm" },
                    { 12, "170 cm.", 23, 23, "Bænk-Egetræ-Sortolie-170cm" },
                    { 21, "40 cm.", 6, 6, "Hylde-Egetræ-Naturolie-40cm" },
                    { 38, "60 cm.", 10, 7, "Hylde-Egetræ-Hvidolie-60cm" },
                    { 39, "80 cm.", 10, 10, "Hylde-Egetræ-Hvidolie-80cm" },
                    { 40, "100 cm.", 10, 13, "Hylde-Egetræ-Hvidolie-100cm" },
                    { 60, "100 cm.", 15, 15, "Hylde-Egetræ-Naturolie-100cm" },
                    { 20, "100 cm.", 5, 15, "Hylde-Egetræ-Sortolie-100cm" },
                    { 19, "80 cm.", 5, 11, "Hylde-Egetræ-Sortolie-80cm" },
                    { 18, "60 cm.", 5, 8, "Hylde-Egetræ-Sortolie-60cm" },
                    { 17, "40 cm.", 5, 5, "Hylde-Egetræ-Sortolie-40cm" },
                    { 59, "80 cm.", 15, 12, "Hylde-Egetræ-Naturolie-80cm" },
                    { 58, "60 cm.", 15, 9, "Hylde-Egetræ-Naturolie-60cm" },
                    { 57, "40 cm.", 15, 6, "Hylde-Egetræ-Naturolie-40cm" },
                    { 8, "170 cm.", 21, 21, "Bænk-Egetræ-Naturolie-170cm" },
                    { 7, "115 cm.", 21, 18, "Bænk-Egetræ-Naturolie-115cm" }
                });

            migrationBuilder.InsertData(
                table: "ProductLength",
                columns: new[] { "Id", "Length", "ProductId", "ProductReferenceId", "ProductReferenceUrlName" },
                values: new object[] { 34, "60 cm.", 9, 9, "Hylde-Egetræ-Naturolie-60cm" });

            migrationBuilder.InsertData(
                table: "ProductLength",
                columns: new[] { "Id", "Length", "ProductId", "ProductReferenceId", "ProductReferenceUrlName" },
                values: new object[] { 49, "40 cm.", 13, 4, "Hylde-Egetræ-Hvidolie-40cm" });

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
                column: "PaymentCaptureId");

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
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "ShippingAddress");

            migrationBuilder.DropTable(
                name: "ShippingDeliveries");

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
