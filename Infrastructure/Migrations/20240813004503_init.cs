using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpiredTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpiredTokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavouritesLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouritesLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavouritesLists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    NumberOfRatings = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavouritesListItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FavouritesListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouritesListItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavouritesListItems_FavouritesLists_FavouritesListId",
                        column: x => x.FavouritesListId,
                        principalTable: "FavouritesLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouritesListItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewRating = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImgUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("24f612d4-366f-4e5b-82ca-4ecf8c32441c"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723506341/beqaltk/cat/eb6jaykdv8hxul9oamjv.png", "Dairy" },
                    { new Guid("4bcc9e22-5843-4d3c-9d5c-35a122eba0c8"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723506347/beqaltk/cat/b7vpup6kh8dfeazb0ycq.png", "Vegetables and fruits" },
                    { new Guid("87b5e568-4339-4c24-bb91-f315043783da"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723506343/beqaltk/cat/xzv5ld9jq7as0dijuarp.png", "Frozen food" },
                    { new Guid("a1be8b20-1226-4833-bb59-40cb6490f785"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723506342/beqaltk/cat/jvxr5ft2npvbaa5gwxyc.png", "Rice, atta and dal" },
                    { new Guid("afd07098-09a2-4e7a-abe2-72716032bb71"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723506341/beqaltk/cat/zq3gagl2qx5nwc1zgvqi.png", "Home care" },
                    { new Guid("bde57096-18b4-418e-a121-0d41c689b596"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723506339/beqaltk/cat/mfs9lgw0vthr7akl9aop.png", "Cold drinks and ice cream" },
                    { new Guid("c3e2e423-2612-4f07-9822-826016e78fae"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723506341/beqaltk/cat/k7wb8mmvv0lvns47s5iu.png", "Tea and coffee" },
                    { new Guid("e3cbd32f-9df5-407e-9c16-2879384b9249"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723506345/beqaltk/cat/jdacpvr7owpsjbc0akrz.png", "Snacks" },
                    { new Guid("f4b80fb3-6482-4d08-9044-2fd31bc9e5ae"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723506348/beqaltk/cat/osmc52awqxuedocnttuc.png", "Chicken, meat and fish" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "ImgUrl", "Name", "NumberOfRatings", "Price", "Rating", "Weight" },
                values: new object[,]
                {
                    { new Guid("088c21e1-7993-4210-8995-346acb51a641"), new Guid("f4b80fb3-6482-4d08-9044-2fd31bc9e5ae"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507539/beqaltk/pro/ij4uxxd7ppq7t7p5wfck.png", "Chicken", 0, 250.0, 0, "1 K" },
                    { new Guid("0e4d2478-be8c-4c75-bab4-88a36824f802"), new Guid("4bcc9e22-5843-4d3c-9d5c-35a122eba0c8"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507514/beqaltk/pro/i1coja7pjlqhzmpmdy6u.png", "Apple", 0, 18.0, 0, "1 KG" },
                    { new Guid("13c12c33-5ee1-42c7-9aec-e07e770b3835"), new Guid("a1be8b20-1226-4833-bb59-40cb6490f785"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507516/beqaltk/pro/fpgv3prfg700kkjofcrb.png", "Atta", 0, 20.0, 0, "1 KG" },
                    { new Guid("1526acab-abfc-4d8e-a9fd-c06de938ad78"), new Guid("afd07098-09a2-4e7a-abe2-72716032bb71"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507503/beqaltk/pro/pgojlz9nildchmiqiqga.png", "Colgate", 0, 50.0, 0, "250 G" },
                    { new Guid("237c29dd-4ab2-4c26-9b7e-e1a4a452beaa"), new Guid("24f612d4-366f-4e5b-82ca-4ecf8c32441c"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507508/beqaltk/pro/xt3l8sjzdnx8enxd80rw.png", "Ghee", 0, 70.0, 0, "500 ML" },
                    { new Guid("2af2f2ea-99f0-4b52-95df-4a6ec46bb6ed"), new Guid("e3cbd32f-9df5-407e-9c16-2879384b9249"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507521/beqaltk/pro/jpelj7a1ph2p37vujqn1.jpg", "Perk", 0, 5.0, 0, "100 G" },
                    { new Guid("2b6dbceb-05e0-4036-b0e0-0dc05c4569c5"), new Guid("bde57096-18b4-418e-a121-0d41c689b596"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507513/beqaltk/pro/r4318mhgqdg0iky6lu6a.jpg", "Chocolate Ice Cream", 0, 80.0, 0, "1 KG" },
                    { new Guid("2cb96f3a-a209-4b63-a14a-268cff88a807"), new Guid("4bcc9e22-5843-4d3c-9d5c-35a122eba0c8"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507515/beqaltk/pro/qowzecgx7wispwpvgz5a.png", "Chillies", 0, 28.0, 0, "1 KG" },
                    { new Guid("2e934ddf-3674-4352-9b9a-06e24fb7989f"), new Guid("24f612d4-366f-4e5b-82ca-4ecf8c32441c"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507499/beqaltk/pro/pzymqgooxbjjuptsqtpy.jpg", "Arokya Milk", 0, 37.0, 0, "1 L" },
                    { new Guid("35f8384f-5bc4-4c82-baa9-36048b536518"), new Guid("4bcc9e22-5843-4d3c-9d5c-35a122eba0c8"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507534/beqaltk/pro/kbedbvvyu07sdcxl70ct.png", "Watermelon", 0, 50.0, 0, "2.5 KG" },
                    { new Guid("38631798-ebb8-4208-a0a2-e64672771633"), new Guid("afd07098-09a2-4e7a-abe2-72716032bb71"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507510/beqaltk/pro/drktdwe5ebqtuddiikey.png", "Harpic", 0, 40.0, 0, "250 ML" },
                    { new Guid("3de01125-5e4a-4efa-914e-07992e25d295"), new Guid("bde57096-18b4-418e-a121-0d41c689b596"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507504/beqaltk/pro/l4atfmtpvey2uc9povfq.jpg", "Coca Cola", 0, 15.0, 0, "250 ML" },
                    { new Guid("3fb7253d-579a-4fcd-9179-b84566f1ff1d"), new Guid("f4b80fb3-6482-4d08-9044-2fd31bc9e5ae"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507522/beqaltk/pro/kvfs7h1nim12xxbo57j4.jpg", "Prawn", 0, 460.0, 0, "1 K" },
                    { new Guid("3fb83435-22c2-48fd-a502-c79558ad487c"), new Guid("bde57096-18b4-418e-a121-0d41c689b596"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507499/beqaltk/pro/rqjruxgbzee889zk0atr.jpg", "Mountain Dew", 0, 25.0, 0, "250 ML" },
                    { new Guid("41966dd6-a187-4ed9-ba21-9887029d8b50"), new Guid("a1be8b20-1226-4833-bb59-40cb6490f785"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507517/beqaltk/pro/gvv6xdowiiy0d6y0yu8d.png", "India Gate", 0, 28.0, 0, "1 KG" },
                    { new Guid("4cd0f5b5-c9b8-44d1-babd-acc8ea113069"), new Guid("bde57096-18b4-418e-a121-0d41c689b596"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507505/beqaltk/pro/xuwrzjfhnygxqbqiwwbp.jpg", "Red Bull", 0, 35.0, 0, "250 ML" },
                    { new Guid("5b8d604d-7329-4be0-bd74-567f47a5406f"), new Guid("c3e2e423-2612-4f07-9822-826016e78fae"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507527/beqaltk/pro/a5co9dsi27lrxhyilrpd.jpg", "Taj Mahal Tea", 0, 40.0, 0, "250 G" },
                    { new Guid("5e674efc-1946-48e1-bd4f-8dc46970a02b"), new Guid("e3cbd32f-9df5-407e-9c16-2879384b9249"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507515/beqaltk/pro/g3jzrvift0irckx5efpa.jpg", "Dairy Milk", 0, 20.0, 0, "100 G" },
                    { new Guid("60ea16e3-c435-48b2-8061-ad31c8bfb660"), new Guid("24f612d4-366f-4e5b-82ca-4ecf8c32441c"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507512/beqaltk/pro/l6mwbrlfdkd9jdnnptt4.jpg", "Yoghurt", 0, 25.0, 0, "900 G" },
                    { new Guid("6ca58511-c7b4-4f6a-82fd-aa6a1f221156"), new Guid("e3cbd32f-9df5-407e-9c16-2879384b9249"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507521/beqaltk/pro/we1gewq1rcc4tmcypqmf.png", "Pringles", 0, 10.0, 0, "100 G" },
                    { new Guid("6e596730-14e9-43a7-8f6b-614e4bd1f93b"), new Guid("f4b80fb3-6482-4d08-9044-2fd31bc9e5ae"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507525/beqaltk/pro/saa2zhgvwkndrmb2upjs.jpg", "Fish", 0, 80.0, 0, "1 K" },
                    { new Guid("7c351659-0c0a-418b-8893-b720b1a33ce1"), new Guid("afd07098-09a2-4e7a-abe2-72716032bb71"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507501/beqaltk/pro/uwdpuzzk1ulhdqqo6vs3.png", "Dettol", 0, 70.0, 0, "250 ML" },
                    { new Guid("80c5025d-400d-4a67-ac75-003f8c74b08a"), new Guid("24f612d4-366f-4e5b-82ca-4ecf8c32441c"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507522/beqaltk/pro/xmptvgmstsazhfaq1zd7.jpg", "Alavin Milk", 0, 40.0, 0, "1 L" },
                    { new Guid("85fe3b27-3f39-48b7-b2e8-5ce9957d558a"), new Guid("bde57096-18b4-418e-a121-0d41c689b596"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507518/beqaltk/pro/i0pucbshvt86cmhpocoh.jpg", "Sprite", 0, 15.0, 0, "250 ML" },
                    { new Guid("8989a4de-905f-4e67-949c-be4fb458dab2"), new Guid("24f612d4-366f-4e5b-82ca-4ecf8c32441c"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507498/beqaltk/pro/iw4kke7kmklss7wbpfp7.png", "Tamil Milk", 0, 70.0, 0, "500 ML" },
                    { new Guid("924cc07b-d12e-4e03-8c54-53b79eaa3e20"), new Guid("4bcc9e22-5843-4d3c-9d5c-35a122eba0c8"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507567/beqaltk/pro/rpdixsrmmwvev9icpnuv.png", "Potato", 0, 32.0, 0, "1 KG" },
                    { new Guid("9cf1e270-0ece-4dc3-88bb-84bd3d4f1ae6"), new Guid("4bcc9e22-5843-4d3c-9d5c-35a122eba0c8"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507500/beqaltk/pro/ys2i3tcherm5oeon5tjv.jpg", "Orange", 0, 30.0, 0, "1 KG" },
                    { new Guid("9fede6ad-03f7-419b-b7db-9bbc43d51e74"), new Guid("f4b80fb3-6482-4d08-9044-2fd31bc9e5ae"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507497/beqaltk/pro/e65khctoutmakfu7aynz.jpg", "Mutton", 0, 320.0, 0, "1 K" },
                    { new Guid("a2a29ad0-0c1b-4ff6-8246-3f84bdd7dd15"), new Guid("bde57096-18b4-418e-a121-0d41c689b596"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507522/beqaltk/pro/evomyd5cxh1vstahb5uj.jpg", "Minut Maid", 0, 10.0, 0, "250 ML" },
                    { new Guid("a95f5b02-6e70-4825-b4b1-b36ab8a51087"), new Guid("4bcc9e22-5843-4d3c-9d5c-35a122eba0c8"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507566/beqaltk/pro/udrypolhm0ybhtgo18kg.png", "Strawberry", 0, 46.0, 0, "1 KG" },
                    { new Guid("b22c9dfd-76ce-474f-8bd1-00444a8f3208"), new Guid("e3cbd32f-9df5-407e-9c16-2879384b9249"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507504/beqaltk/pro/si0jflwu52yylsb2kffi.jpg", "Parle-G", 0, 5.0, 0, "100 G" },
                    { new Guid("b3a06d48-cb1a-4f1f-89e4-e11c4d8f6b74"), new Guid("24f612d4-366f-4e5b-82ca-4ecf8c32441c"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507510/beqaltk/pro/zhmfngx3uyzuwotq1tn7.png", "Curd", 0, 54.0, 0, "500 ML" },
                    { new Guid("b4efd5b5-1286-403e-bea1-f0fc9a58889e"), new Guid("24f612d4-366f-4e5b-82ca-4ecf8c32441c"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507524/beqaltk/pro/xepzbchg13erg3girrck.png", "Paneer", 0, 90.0, 0, "100 G" },
                    { new Guid("b6f01fd0-06e7-477b-961c-f78cb7350451"), new Guid("afd07098-09a2-4e7a-abe2-72716032bb71"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507527/beqaltk/pro/huut3e3l4seyhhi0gwox.png", "Medimix", 0, 25.0, 0, "150 G" },
                    { new Guid("badf7ebc-05ec-4724-9867-e2550cd40f54"), new Guid("e3cbd32f-9df5-407e-9c16-2879384b9249"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507517/beqaltk/pro/l9hunwcakflpkgyob0zg.jpg", "Oreo", 0, 10.0, 0, "100 G" },
                    { new Guid("be6701a3-17da-4035-8dee-fafef2952eb4"), new Guid("24f612d4-366f-4e5b-82ca-4ecf8c32441c"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507522/beqaltk/pro/ytnv11dfmzmelbzhxt6o.jpg", "Butter", 0, 50.0, 0, "250 G" },
                    { new Guid("c1a8954e-09df-4355-a05b-4bdbb7634396"), new Guid("f4b80fb3-6482-4d08-9044-2fd31bc9e5ae"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507505/beqaltk/pro/ncqw3kpjbeeux9qyju2v.jpg", "Crab", 0, 400.0, 0, "1 K" },
                    { new Guid("c75e2e80-efeb-46ca-bbba-edc9ceb49c83"), new Guid("24f612d4-366f-4e5b-82ca-4ecf8c32441c"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507498/beqaltk/pro/uje8z49nttz7y05qv5vr.png", "Amul Milk", 0, 60.0, 0, "1 L" },
                    { new Guid("cc97c187-b113-4fa4-845c-dbdc04a176cb"), new Guid("e3cbd32f-9df5-407e-9c16-2879384b9249"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507515/beqaltk/pro/npy39v0n8bmjxxxefhq0.png", "Lays", 0, 5.0, 0, "100 G" },
                    { new Guid("d3221499-4a7c-4bc0-a95d-88a2c1de87fe"), new Guid("4bcc9e22-5843-4d3c-9d5c-35a122eba0c8"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507519/beqaltk/pro/mnz40gylcn13pbrbizbn.png", "Ginger", 0, 10.0, 0, "200 G" },
                    { new Guid("d917d9d2-bb17-4f8f-837c-7c9d3ed962c0"), new Guid("afd07098-09a2-4e7a-abe2-72716032bb71"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507512/beqaltk/pro/xvdn7kai1lfsifguw162.jpg", "Tide", 0, 40.0, 0, "250 ML" },
                    { new Guid("dd3d7e28-8678-48c9-8077-6067985d7411"), new Guid("c3e2e423-2612-4f07-9822-826016e78fae"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507516/beqaltk/pro/fvvcji66a4bmmxizzohi.jpg", "Sunrise Coffee", 0, 30.0, 0, "250 G" },
                    { new Guid("e525ff86-45fc-4820-8300-460ead3f780e"), new Guid("4bcc9e22-5843-4d3c-9d5c-35a122eba0c8"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507521/beqaltk/pro/tccorqv9duvzzl6bapm4.png", "Banana", 0, 55.0, 0, "1 KG" },
                    { new Guid("e64f830e-0849-4094-8e58-b151e6117430"), new Guid("87b5e568-4339-4c24-bb91-f315043783da"), "https://res.cloudinary.com/dbsxwhtst/image/upload/v1721213499/GroceryAPI/Products/frozen/elwxsm6e8nkkjy8rr9bu.jpg", "Frozen Beans", 0, 30.0, 0, "1 KG" },
                    { new Guid("e8fd8dee-ec27-4cbe-bb63-beb523c9baf9"), new Guid("afd07098-09a2-4e7a-abe2-72716032bb71"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507524/beqaltk/pro/wbsvxkmmr2ivpis7pbzg.jpg", "Vim", 0, 40.0, 0, "250 ML" },
                    { new Guid("e90ccbf2-23e9-4e3d-b8d4-d9a94b92475d"), new Guid("4bcc9e22-5843-4d3c-9d5c-35a122eba0c8"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507521/beqaltk/pro/dhxrorcpfip5o9nzu2ia.png", "Grapes", 0, 20.0, 0, "1 KG" },
                    { new Guid("f41e550e-af42-4f9e-8fdd-2672a2623086"), new Guid("87b5e568-4339-4c24-bb91-f315043783da"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507517/beqaltk/pro/hjdhgwtyij5jcxb6yqjb.jpg", "Masala", 0, 80.0, 0, "1 KG" },
                    { new Guid("f589f64e-a06b-48a6-aa14-c1d321672cf8"), new Guid("4bcc9e22-5843-4d3c-9d5c-35a122eba0c8"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507526/beqaltk/pro/lbvngfwsxqdlec0smpz9.jpg", "Bringal", 0, 34.0, 0, "1 KG" },
                    { new Guid("f5961533-c3f1-463d-900b-d5c0e74cc2cd"), new Guid("c3e2e423-2612-4f07-9822-826016e78fae"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507502/beqaltk/pro/ttdspcldqguaqyy9kc6j.jpg", "Bru Coffee", 0, 60.0, 0, "250 G" },
                    { new Guid("ff14104f-b074-434f-86d3-2d218dcc7c71"), new Guid("c3e2e423-2612-4f07-9822-826016e78fae"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507519/beqaltk/pro/qhwcsdx1lnyrdlfnl3hc.jpg", "Tata Tea", 0, 42.0, 0, "250 G" },
                    { new Guid("ff7fa7f6-4e9a-4663-9871-8688290e9d1e"), new Guid("4bcc9e22-5843-4d3c-9d5c-35a122eba0c8"), "https://res.cloudinary.com/dokp2svd4/image/upload/v1723507529/beqaltk/pro/ofzup4cp7ijj7p62rapo.png", "Tomato", 0, 15.0, 0, "1 KG" }
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
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FavouritesListItems_FavouritesListId",
                table: "FavouritesListItems",
                column: "FavouritesListId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouritesListItems_ProductId",
                table: "FavouritesListItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouritesLists_UserId",
                table: "FavouritesLists",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");
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
                name: "ExpiredTokens");

            migrationBuilder.DropTable(
                name: "FavouritesListItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "FavouritesLists");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
