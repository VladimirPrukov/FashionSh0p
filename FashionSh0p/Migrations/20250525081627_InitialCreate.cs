using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FashionWave.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductVariantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
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
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Дамско Облекло" });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Черен" },
                    { 2, "Червен" },
                    { 3, "Бял" },
                    { 4, "Розов" },
                    { 5, "Син" },
                    { 6, "Бежов" },
                    { 7, "Сив" },
                    { 8, "Лилав" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "S" },
                    { 2, "M" },
                    { 3, "L" },
                    { 4, "XL" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandName", "CategoryId", "Description", "ImageUrl", "Price", "ProductName", "ProductType" },
                values: new object[,]
                {
                    { 1, "NUCOMO", 1, "Дамска рокля на марката NUMOCO.\r\n- V-образно деколте\r\n- връзване на талията\r\n- изработени от топъл пуловерен материал\r\nМоделът на снимката е висок 165 см и носи размер UNI (XS-2XL).\r\nМатериал: 100% акрил", "https://i.factcool.com/cache2/1400x1400/catalog/products/60/b4/b8/60-b4-b884d8c3497-1-dwukolorowa-sukienka-z-15611.jpg", 89.989999999999995, "Плетени рокли", "Рокли" },
                    { 2, "NUCOMO", 1, "Дамска рокля на марката NUMOCO.\r\n- V-образно деколте\r\n- връзване на талията\r\n- изработени от топъл пуловерен материал\r\nМоделът на снимката е висок 165 см и носи размер UNI (XS-2XL).\r\nМатериал: 100% акрил", "https://i.factcool.com/cache2/800x800/catalog/products/60/87/f6/60-87-f6694719507-1-azurowa-sweterkowa-suki-15712.jpg", 72.989999999999995, "Плетени рокли", "Рокли" },
                    { 3, "TRENDYOL", 1, "Информация за модела: Измервания на модела: Височина: 180 см (5'11'') Бюст: 80 см (31 инча) Талия: 60 см (23 инча) Ханш: 89 см (35 инча);\r\nПродуктът върху манекена е с размер S/36/8;\r\nДължина на модела отпред: 125 см\r\n\r\nСъстав на материала: 100% акрил; Плетива", "https://i.factcool.com/cache2/800x800/catalog/products/11/85/ae/11-85-ae72cc6c1_org_zoom.jpg", 53.990000000000002, "Плетени рокли", "Рокли" },
                    { 4, "TRENDYOL", 1, "Дамска рокля Trendyol.\r\n- оребрена материя\r\n- удобна кройка\r\n- водолазка\r\nРазмери на модела: Височина: 173 см, Бюст: 79 см, Талия: 60 см, Ханш: 90 см.\r\nПродуктът на модела е с размер S/36.\r\nМатериал: 100% акрил", "https://i.factcool.com/cache2/800x800/catalog/products/11/45/22/11-45-2248bc251_org_zoom.jpg", 25.989999999999998, "Плетени рокли", "Рокли" },
                    { 5, "TRENDYOL", 1, "Дамска рокля Trendyol.\r\n- оребрена материя\r\n- обло деколте\r\n- дължина: 80 см\r\n- леко скъсано на долнището и ръкавите\r\nПродуктът на модела е с размер S/36.\r\nМатериал: 100% акрил", "https://i.factcool.com/cache2/800x800/catalog/products/11/31/ae/11-31-aee46a262_org_zoom.jpg", 23.989999999999998, "Плетени рокли", "Рокли" },
                    { 6, "TRENDYOL", 1, "Дамска рокля Trendyol.\r\n- оребрена материя\r\n- обло деколте\r\n- дължинаИнформация за модела: Измервания на модела: Височина: 180 см (5'11'') Бюст: 80 см (31 инча) Талия: 60 см (23 инча) Ханш: 89 см (35 инча);\r\nПродуктът върху манекена е с размер S/36/8;\r\nДължина на модела отпред: 125 см\r\n\r\nСъстав на материала: 100% акрил; Плетива", "https://i.factcool.com/cache2/800x800/catalog/products/11/fc/c9/11-fc-c9eed5581_org_zoom.jpg", 53.990000000000002, "Плетени рокли", "Рокли" },
                    { 7, "BeWear B083", 1, "- удобна кройка\r\n\r\n- 3/4 ръкав\r\n\r\n- преден джоб\r\n\r\nМатериал: 90% памук 10% еластан", "https://i.factcool.com/cache2/800x800/catalog/products/14/03/24/14-03-24b083_royalblue_1b.jpg", 145.99000000000001, "Плетени рокли", "Рокли" },
                    { 8, "TRENDYOL", 1, "70% акрил 30% полиестер", "https://i.factcool.com/cache2/800x800/catalog/products/11/71/f6/11-71-f6c80b436_org_zoom.jpg", 54.990000000000002, "Плетени рокли", "Рокли" },
                    { 9, "FRUIT OF THE LOOM FN63•Ladies Iconic Tee", 1, "Women's T-Shirt | Short sleeves Product features: • 100% cotton • round neckline • short sleeve • ribbed knit hem of the neckline • tapered cut", "https://i.factcool.com/cache2/800x800/catalog/products/15/81/b2/15-81-b2a2e379bg_FN63_03.jpg", 6.9900000000000002, "С къс ръкав", "Блузи" },
                    { 10, "FRUIT OF THE LOOM FN63•Ladies Iconic Tee", 1, "Women's T-Shirt | Short sleeves Product features: • 100% cotton • round neckline • short sleeve • ribbed knit hem of the neckline • tapered cut", "https://i.factcool.com/cache2/800x800/catalog/products/15/b3/06/15-b3-06f26515bg_FN63_01.jpg", 5.9900000000000002, "С къс ръкав", "Блузи" },
                    { 11, "FRUIT OF THE LOOM FN63•Ladies Iconic Tee", 1, "Women's T-Shirt | Short sleeves Product features: • 100% cotton • round neckline • short sleeve • ribbed knit hem of the neckline • tapered cut", "https://i.factcool.com/cache2/800x800/catalog/products/15/1e/2f/15-1e-2f16b42ebg_FN63_28.jpg", 6.9900000000000002, "С къс ръкав", "Блузи" },
                    { 12, "FRUIT OF THE LOOM FN63•Ladies Iconic Tee", 1, "Women's T-Shirt | Short sleeves Product features: • 100% cotton • round neckline • short sleeve • ribbed knit hem of the neckline • tapered cut", "https://i.factcool.com/cache2/800x800/catalog/products/15/4f/9c/15-4f-9c545530bg_FN63_05.jpg", 6.9900000000000002, "С къс ръкав", "Блузи" },
                    { 13, "FRUIT OF THE LOOM FN63•Ladies Iconic Tee", 1, "Women's T-Shirt | Short sleeves Product features: • 100% cotton • round neckline • short sleeve • ribbed knit hem of the neckline • tapered cut", "https://i.factcool.com/cache2/800x800/catalog/products/15/79/d4/15-79-d405a42abg_FN63_39.jpg", 6.9900000000000002, "С къс ръкав", "Блузи" },
                    { 14, "FRUIT OF THE LOOM FN63•Ladies Iconic Tee", 1, "Women's T-Shirt | Short sleeves Product features: • 100% cotton • round neckline • short sleeve • ribbed knit hem of the neckline • tapered cut", "https://i.factcool.com/cache2/800x800/catalog/products/15/c1/88/15-c1-885717c9bg_FN63_15.jpg", 6.9900000000000002, "С къс ръкав", "Блузи" },
                    { 15, "FRUIT OF THE LOOM FU78•Lady-Fit Valueweight Tee", 1, "Product features: • 100% cotton • round neckline with ribbed hemming cotton/Lycra • reinforcing band at the neck • side seams", "https://i.factcool.com/cache2/800x800/catalog/products/15/7e/c3/15-7e-c377b79ebg_FU78_01.jpg", 7.9900000000000002, "С къс ръкав", "Блузи" },
                    { 16, "Дамска тениска B&C Basic", 1, "Дамска тениска с кръгло деколте\r\nМатериал: 100% памукк", "https://i.factcool.com/cache2/800x800/catalog/products/15/5f/72/15-5f-721bf5acbg_B54E_36.jpg", 7.9900000000000002, "С къс ръкав", "Блузи" }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 1, "https://i.factcool.com/cache2/1400x1400/catalog/products/60/f4/b8/60-f4-b8e49ba4497-1-dwukolorowa-sukienka-z-15616.jpg", 1 },
                    { 2, "https://i.factcool.com/cache2/1400x1400/catalog/products/60/86/80/60-86-80395f09497-1-dwukolorowa-sukienka-z-15613.jpg", 1 },
                    { 3, "https://i.factcool.com/cache2/1400x1400/catalog/products/60/15/13/60-15-134c0ee8497-1-dwukolorowa-sukienka-z-15614.jpg", 1 },
                    { 4, "https://i.factcool.com/cache2/800x800/catalog/products/60/a5/e4/60-a5-e4374393497-1-dwukolorowa-sukienka-z-15612.jpg", 1 },
                    { 5, "https://i.factcool.com/cache2/800x800/catalog/products/60/88/ce/60-88-ce55abd6497-1-dwukolorowa-sukienka-z-15615.jpg", 1 },
                    { 6, "https://i.factcool.com/cache2/800x800/catalog/products/60/c8/36/60-c8-363f099b507-1-azurowa-sweterkowa-suki-15713.jpg", 2 },
                    { 7, "https://i.factcool.com/cache2/800x800/catalog/products/60/a4/d5/60-a4-d569035d507-1-azurowa-sweterkowa-suki-15716.jpg", 2 },
                    { 8, "https://i.factcool.com/cache2/800x800/catalog/products/60/58/83/60-58-834da908507-1-azurowa-sweterkowa-suki-15717.jpg", 2 },
                    { 9, "https://i.factcool.com/cache2/800x800/catalog/products/60/a7/4f/60-a7-4f58987e507-1-azurowa-sweterkowa-suki-15715.jpg", 2 },
                    { 10, "https://i.factcool.com/cache2/800x800/catalog/products/60/37/44/60-37-44418a78507-1-azurowa-sweterkowa-suki-15711.jpg", 2 },
                    { 11, "https://i.factcool.com/cachhttps://i.factcool.com/cache2/800x800/catalog/products/11/de/40/11-de-4068a6c71_org_zoom.jpg", 3 },
                    { 12, "https://i.factcool.com/cache2/800x800/catalog/products/11/4f/d6/11-4f-d6450bb01_org_zoom.jpg", 3 },
                    { 13, "https://i.factcool.com/cache2/800x800/catalog/products/11/25/8f/11-25-8f84079d1_org_zoom.jpg", 3 },
                    { 14, "https://i.factcool.com/cache2/800x800/catalog/products/11/06/ac/11-06-ac0272761_org_zoom.jpg", 3 },
                    { 15, "https://i.factcool.com/cache2/800x800/catalog/products/11/e5/53/11-e5-5394610a1_org_zoom.jpg", 3 },
                    { 16, "https://i.factcool.com/cache2/800x800/catalog/products/11/8a/9f/11-8a-9f956f4f2_org_zoom.jpg", 4 },
                    { 17, "https://i.factcool.com/cache2/800x800/catalog/products/11/19/6a/11-19-6af334bd4_org_zoom.jpg", 4 },
                    { 18, "https://i.factcool.com/cache2/800x800/catalog/products/11/24/e4/11-24-e4a72e355_org_zoom.jpg", 4 },
                    { 19, "https://i.factcool.com/cache2/800x800/catalog/products/11/c5/12/11-c5-12d40d767_org_zoom.jpg", 4 },
                    { 20, "https://i.factcool.com/cache2/800x800/catalog/products/11/41/fa/11-41-fa3f11351_org_zoom.jpg", 4 },
                    { 21, "https://i.factcool.com/cache2/800x800/catalog/products/11/ac/df/11-ac-df4cc6f56_org_zoom.jpg", 5 },
                    { 22, "https://i.factcool.com/cache2/800x800/catalog/products/11/13/1d/11-13-1de87ed18_org_zoom.jpg", 5 },
                    { 23, "https://i.factcool.com/cache2/800x800/catalog/products/11/79/7e/11-79-7e40acf82_org_zoom.jpg", 5 },
                    { 24, "https://i.factcool.com/cache2/800x800/catalog/products/11/e7/3b/11-e7-3b474ecf10_org_zoom.jpg", 5 },
                    { 25, "https://i.factcool.com/cache2/800x800/catalog/products/11/b9/ff/11-b9-ffbb28f31_org_zoom.jpg", 5 },
                    { 26, "https://i.factcool.com/cache2/800x800/catalog/products/11/b7/93/11-b7-93ecb7171_org_zoom.jpg", 6 },
                    { 27, "https://i.factcool.com/cache2/800x800/catalog/products/11/1f/1a/11-1f-1a5d4ba81_org_zoom.jpg", 6 },
                    { 28, "https://i.factcool.com/cache2/800x800/catalog/products/11/6e/54/11-6e-54ce6d341_org_zoom.jpg", 6 },
                    { 29, "https://i.factcool.com/cache2/800x800/catalog/products/11/7d/b9/11-7d-b9786c621_org_zoom.jpg", 6 },
                    { 30, "https://i.factcool.com/cache2/800x800/catalog/products/11/bd/94/11-bd-94fd928f1_org_zoom.jpg", 6 },
                    { 31, "https://i.factcool.com/cache2/800x800/catalog/products/14/f8/cd/14-f8-cdb083_royalblue_2b.jpg", 7 },
                    { 32, "https://i.factcool.com/cache2/800x800/catalog/products/14/f8/cd/14-f8-cdb083_royalblue_2b.jpg", 7 },
                    { 33, "https://i.factcool.com/cache2/800x800/catalog/products/11/b2/0a/11-b2-0ade54c32_org_zoom.jpg", 8 },
                    { 34, "https://i.factcool.com/cache2/800x800/catalog/products/11/1f/1a/11-1f-1a5d4ba81_org_zoom.jpg", 8 },
                    { 35, "https://i.factcool.com/cache2/800x800/catalog/products/11/fc/39/11-fc-3910fb854_org_zoom.jpg", 8 },
                    { 36, "https://i.factcool.com/cache2/800x800/catalog/products/11/7b/6c/11-7b-6ceafb4b7_org_zoom.jpg", 8 },
                    { 37, "https://i.factcool.com/cache2/800x800/catalog/products/11/d4/f4/11-d4-f456bd348_org_zoom.jpg", 8 },
                    { 38, "https://i.factcool.com/cache2/800x800/catalog/products/15/1f/64/15-1f-64109980bg_FN63_03_B.jpg", 9 },
                    { 39, "https://i.factcool.com/cache2/800x800/catalog/products/15/34/da/15-34-da177255bg_FN63_03_S.jpg", 9 },
                    { 40, "https://i.factcool.com/cache2/800x800/catalog/products/15/7f/ca/15-7f-cad38d7cbg_FN63_01_B.jpg", 10 },
                    { 41, "https://i.factcool.com/cache2/800x800/catalog/products/15/84/83/15-84-8379af09bg_FN63_01_S.jpg", 10 },
                    { 42, "https://i.factcool.com/cache2/800x800/catalog/products/15/b8/68/15-b8-6831513abg_FN63_28_B.jpg", 11 },
                    { 43, "https://i.factcool.com/cache2/800x800/catalog/products/15/53/d9/15-53-d920198cbg_FN63_28_S.jpg", 11 },
                    { 44, "https://i.factcool.com/cache2/800x800/catalog/products/15/13/31/15-13-3103e0d7bg_FN63_05_B.jpg", 12 },
                    { 45, "https://i.factcool.com/cache2/800x800/catalog/products/15/d8/24/15-d8-242c1f8dbg_FN63_05_S.jpg", 12 },
                    { 46, "https://i.factcool.com/cache2/800x800/catalog/products/15/52/9d/15-52-9d6fc0d2bg_FN63_39_B.jpg", 13 },
                    { 47, "https://i.factcool.com/cache2/800x800/catalog/products/15/e7/52/15-e7-521341e5bg_FN63_39_S.jpg", 13 },
                    { 48, "https://i.factcool.com/cache2/800x800/catalog/products/15/18/06/15-18-068585c6bg_FN63_15_B.jpg", 14 },
                    { 49, "https://i.factcool.com/cache2/800x800/catalog/products/15/70/ab/15-70-ab87e41cbg_FN63_15_S.jpg", 14 },
                    { 50, "https://i.factcool.com/cache2/800x800/catalog/products/15/9a/a1/15-9a-a1cee339bg_FU78_01_B.jpg", 15 },
                    { 51, "https://i.factcool.com/cache2/800x800/catalog/products/15/d4/11/15-d4-11b38613bg_FU78_01_S.jpg", 15 },
                    { 52, "https://i.factcool.com/cache2/800x800/catalog/products/15/01/45/15-01-45a014b3bg_B54E_36_B.jpg", 16 },
                    { 53, "https://i.factcool.com/cache2/800x800/catalog/products/15/07/6e/15-07-6ef736f8bg_B54E_36_S.jpg", 16 }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "Id", "ColorId", "ProductId", "SizeId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 10 },
                    { 2, 3, 2, 2, 8 },
                    { 3, 3, 3, 3, 5 },
                    { 4, 2, 4, 4, 10 },
                    { 5, 6, 5, 3, 5 },
                    { 6, 2, 6, 2, 7 },
                    { 7, 5, 7, 1, 9 },
                    { 8, 6, 8, 3, 9 },
                    { 9, 1, 9, 4, 2 },
                    { 10, 3, 10, 2, 5 },
                    { 11, 4, 11, 3, 3 },
                    { 12, 2, 12, 3, 6 },
                    { 13, 8, 13, 1, 2 },
                    { 14, 3, 14, 1, 6 },
                    { 15, 3, 15, 1, 5 },
                    { 16, 8, 16, 1, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ColorId",
                table: "ProductVariants",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductId",
                table: "ProductVariants",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_SizeId",
                table: "ProductVariants",
                column: "SizeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
