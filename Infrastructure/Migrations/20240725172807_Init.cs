﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
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
                    { new Guid("24f612d4-366f-4e5b-82ca-4ecf8c32441c"), "https://s3-alpha-sig.figma.com/img/d05a/0ffe/b3fae625b7a2312289ca8b5d79116b43?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=DlQHdriHW1fARq5WrdIWmKDp1Fo2zE-XPS28KM36452BPBOqXThKiruzrqhFPFpCwRhwynoUPB5T5FpAGMPBZAzX0zJu5g8QdvO~wND6y1v4y5X6ABi0SxqfYRuXEkVZs0ZgqOU3uBEpMIkUrV2iMezZTaNAtWmnM-XvaMzBEKHiTl2d2EMTNdNKWfiA49WMXShuPDNvnFlXKjpj~kK5rkQRKETKyA1DNumSEyt9lRA6ziTSZYPaEl8uPaki8ElkJTvObajNDDU4lpD2LcaoO9pHVlgnW0wpOZeE~xU2fywyHQ9u~SqAac2zHUnfGR0inZNE9LcuVL8A9XiJIMo3VA__", "Dairy" },
                    { new Guid("4bcc9e22-5843-4d3c-9d5c-35a122eba0c8"), "https://s3-alpha-sig.figma.com/img/3490/c81e/7dc6ca835077156ef1fffdc602f2f24e?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=aROAuua2E3h8njTXYBPu~38o6tSnUA4YlikmRg0qpF5d2kWbld0eBWl0coJ7F-wdyzysLC6ccAPxdyEe-5ij6UW2SzyLmD4uYtShiwndnt9gfDCc5XQuKYQcuoMeIQgKAsc-BtRtT-D-FXhta82atV1xWenlDp6kJDWHXu8OEhO9Y3F1m2zx21-ZVHMI7bGv9cGOYOsBDbx92qgJ9DhNBfr4t3fiH8DqbxLyv-lAVUvFJSAl9a4QQ8UacpxhUlTh5HYLk0Yu8Ju-r4jh80nci6i3p2JtDFjHjiV2jd~bPFwc8JsZfKKpAdABYhSG9sOAHUXSLjvcjlFsLxfui7pc5g__", "Vegetables and fruits" },
                    { new Guid("87b5e568-4339-4c24-bb91-f315043783da"), "https://s3-alpha-sig.figma.com/img/d047/5f37/d91cc57336799f6e4ae9bd86ef70de69?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=TvUt-gggS-6CmbPdf1IQ-ELMeBAEhI-whJRAY~0E5TUj7gOM~IXy7uq9HjG39SciAhiKzD0hgFscIfimRZjBdXX~FgJEg0A3JZDFpMbUMG8GkZRv8MPzSq6fI5mToqLj-nKfs3JUKZkMKZ6xWu6PFHIEvoT6HhDjq~63A6DLmIynv0Rx2o9IJvgDb8AQDSO75PaudKtPIPtSiZ9ONWmGEyBoD~PZQim~inXWer2EvtXyjw4bgBFMUjtI2~PKOKT9xsz~osQ9Q9KXPJpGcn8Byq7CguzgJ0XfUOHZ4fo4sZS0~huCqCe3KSOmPUQEaMByECeVTndus~wFuHpiApuAIA__", "Frozen food" },
                    { new Guid("a1be8b20-1226-4833-bb59-40cb6490f785"), "https://s3-alpha-sig.figma.com/img/9a4e/dfe9/adf6a4b9e371606cbbc1a30e4748eb17?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=V60rtJbrHaMF7TpiAaEuGZesY6Duoc2Bdt3DzlU1uIER32bVCuiZZGsrvJLSS-53~sFELdiigUv7I6EU-~khIYrDhcrZYVvn5TcQ~zH8W40LeXZ-9BuLNKbK5sCN6YttkKZhVc6~hfKuLlty~Bk7BaVlBpU4cf~vTEtFWJ0HB9-VhKmqlHNd1gpbtM8H3WXiccADGE-KX9HgkFEKwvQ~McB2nYsT7xSWVcehqwxTRSLmUqFWa8RtAX5YLoj4QhKNHlv~AnvPCXrmvE1XbBsHoM6z-7og0TKkIKuoGVJOlmCzLJL7XsfQSHxdL8g34~g7PdZPNFM1YhTIhdnZYvr2tA__", "Rice, atta and dal" },
                    { new Guid("afd07098-09a2-4e7a-abe2-72716032bb71"), "https://s3-alpha-sig.figma.com/img/5a1f/ba5c/29f3a85c13f96a4fc28e3aac77831888?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=qu~wrgsC5kWPnhIuIH2zj~iB0eW5PkJR~v9LyAoRcrY1Py7W1q-dtEh8C4EotpRPXN3lE2EgrZZWVBLRlrzQlqvZSRwln~GlCexdFrONwQFDC2STv8fII1ygqD7zZlY4Zuv6W06M7mb68kipZqLnk6JBygcM1zp0eVyyyq0atGqdeWiX5SVnIQxy3G~i2EqOZk8e9TzHLfkqTAlbYE5WEkuPZf5ASpanQsC9DKw-WiFrwJOhIiKiySkTHJ0uW3ryWkDBX34MwhccVXhohHhFTPhi7qD8k5AK0h87AlptKcCh8A6iUBxLn4ZH8EmekQORgTePU2ZxkTC~Ar-ZgXmwrA__", "Home care" },
                    { new Guid("bde57096-18b4-418e-a121-0d41c689b596"), "https://s3-alpha-sig.figma.com/img/5114/ffa7/4e47cf4adafabdfce63a5952aca0f5f0?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=qGZB04h-2IvON39-tp-kr75bmk7mEpWOtIHjTKTRCwHSVS2KsIjX24wePJ2112OhohabdtqT7-WgHl2aRXuQXdUx0e0ESAGim~D~O9rp~M~wGC7YYqxMu4J3n4X2d20IPjnJMayVpuOQAiswvYB2D8TH7evlu0P55TGEcneajytrJzFjDlBEsVpjz7jfKTGvAf4dhy17aHPD98hgOrW-5K2dAT27Wko~Sz7fDhPM6pYYBYwZlaX0dBmUAEHarIFV0w2py5GK0vfWNCv8I7i6u-pCQeUPB-Uoc1M5pHUHLebU4eerS1gaLLVe1oubFrMdehDk1LaMRu1uExf5hn2jcQ__", "Cold drinks and ice cream" },
                    { new Guid("c3e2e423-2612-4f07-9822-826016e78fae"), "https://s3-alpha-sig.figma.com/img/0ffc/7402/27992855098eaaa0de03e049deaa73e6?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=dhLvVVvHvveU7GkfZD68mrMlEHAkvug~UX2V2uOtV7E7XnBNRJM4LM~1d~O9Q3hMgr~c8fj2cGOOPD0xYqpZ~j3GhKXRv8SXG9oWtEVJwtCmXRGywic3encYIPTCtDzQWh9JlkWVcHjeYxiI3vCfCt7RPRy7HevpzceePVZbyP1TXPdu2xbOPNPZME5f9bMFNET4lMMzttiw6WNfBWF6iLy~psq90TcSkFtJd03bB9NdAEPnG~MWseksxXkVhMU8SS6~Hxn2RFV9CV2U4C3O3plwI-TaprO8lsfiSEc-j0w8qrMTNsPqQ3f1~LbZ73odGCvi08CPIjd75r70GrV6sg__", "Tea and coffee" },
                    { new Guid("e3cbd32f-9df5-407e-9c16-2879384b9249"), "https://s3-alpha-sig.figma.com/img/e384/6e6f/c204fbb6cf7593bbbca50801f5593af0?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=V2YgZUVgNA9pcTx~IUnUAcRy9fPkAmHYbVkPHLreSGDcrktOKOu5IIO6Mn-DxVprs6hBq~LzWRYJGlfhsY6I0xILs1LMrpLdrqrIss0tZfsvkRTWJlywkK0hP1PKjdWWDhGp8UXTscQ3WE4Df0MdlfOghgrCSjRj4EcU9bwWoDpGMp9CnBLDRgkXIQMzcXyY9SRts~jqXdXQwD8443wek3I5YUjrodVXRZuBuuGfr6eGA3ZcuequAHFz6c05EfDFDvr68XWEO7mswSgkEgjKLC8KHPf9631AFGOuNA1D3NIRoK4nHUpt0JOf7FzkCfoC377Bj6NnOItq9C7Bnng0JA__", "Snacks" },
                    { new Guid("f4b80fb3-6482-4d08-9044-2fd31bc9e5ae"), "https://s3-alpha-sig.figma.com/img/14fc/19ad/4bec662956b3fccae1d965d2556d915e?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=naQtakhT7nhg8is3~Pad3r~eYYGcELEX8bQK4M9NvwP6howTJx5aXYl2M5job-2yw1l5vURhcDMzpWA9i8afKh42NrWvHKZJTRP5RXDRgsgsUYjc9d37~0bYpZMXmx8j~aLvbHqNvLiPK0Pam0pKZJqd40ysy9uKgBsMsZY9SWI1x2aGQ5UNPUuTW87KqD-PwjoFcBTa0fu0YOTstN6dvhU1tNcodtCIU8vG539dFhGU5m0f3ePJV307FZeKQQCzXpR74tZviHgz0cT7r5dgMhMnVc8~TXTWiH0zmOfXSB8JcxmavWmY9ECV-VpEoyV3eGyh2MCDgFj5FTB1NC9oGQ__", "Chicken, meat and fish" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "ImgUrl", "Name", "NumberOfRatings", "Price", "Rating", "Weight" },
                values: new object[,]
                {
                    { new Guid("088c21e1-7993-4210-8995-346acb51a641"), new Guid("f4b80fb3-6482-4d08-9044-2fd31bc9e5ae"), "https://s3-alpha-sig.figma.com/img/2a1f/780d/d8fa5bec671f8b499a459fa864acf5ad?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=fSP6oQq05oRWzP1UuDYhccnc3vXsz0BZlzh0l5Hf-wG54RR99TqrKXby3pHOvip3BiLAsKGE2veRJK1dGDCsVoTd~6Y8oTGOlfX4LPQOzOKHSVATdKl8K6zSGdjdpkosjYawetq~a2yWLeZmo1gpJqhc22vIVWhheZSTi5rJK9rzzeHoB4nwU3QII-QRN689gvS-sgYOz~U-66MjNZYUBZzjnJWdiSp8i0ovdmZBFtcERnDSKI3nBmfa89HfEzN5lvRGJrmLIzMlqv-gvfMTjVP5KSY4LJtUe-kdORIA6hmq7sqPeKNaiK1H6jov7A6c7JwBZ2FdkmxcrQriOWyZCw__", "Chicken", 81405, 250.0, 4, "1 K" },
                    { new Guid("0e4d2478-be8c-4c75-bab4-88a36824f802"), new Guid("4bcc9e22-5843-4d3c-9d5c-35a122eba0c8"), "https://s3-alpha-sig.figma.com/img/384d/5e64/17d8624138ef5a297db171d973745d1f?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=V8CQ4UQa3AL2edp2dUSPbdCO5p~mCSOlj1P7EjXnMEXdWenDveEmVLjiedF8xEjjIskY4E7CARXfE5GgTLzX3AoVFteZRz4R0AsQzeNBZsIEWyh1KLvM-na3BBDeHDm3QSG1mJBmVck5SyUxpbvDcJvWAH6mDigMXvH5qB1z9seJrW1jKJkOqmY0QgIY5SdqNm2AuO9DO1etmXF~iyWyBHN9Q3Jr1SSbv3bSHzDgV~DbNnXyIvNsP3Yysw~PVzL6KAltcBmODf7kGT8dnqcUl-tnaXJvVKDPcujQ9eNHwL8F6Dt7xBXCzVYGPl0bsFB-NEvoK1vrfHrs22p5Z3EMQw__", "Apple", 2120, 18.0, 3, "1 KG" },
                    { new Guid("13c12c33-5ee1-42c7-9aec-e07e770b3835"), new Guid("a1be8b20-1226-4833-bb59-40cb6490f785"), "https://s3-alpha-sig.figma.com/img/485a/e641/1311424a4f794db62a3854696a10408a?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=awcrrLeZYR1g7ZymjSWe2LVYEg1EeFSDXgNTVYol68~nHe4nQBNM838AVZwIWZWVN1iWFNHnrWiugs2UV2t3siBGiyiJ9dGfB4aN~eygxaKYPUoOEeJWaPGH2RF4upz1Zr235z9TakKWxVSynKM2TgP0dHdwVRZ~PF~bL9v1pCtmUMB0vEcC6CXskL4tWN1VTvsFQWIB~qXhmQCU6iPQ3B-nFh4An8bW-jqi2n5~1x6~-5rtZngmbPTG4274-54pbmNNHh8-mGyGk2iT6sU-cXjAurw701irAkcFgRUxYgmDMPQCAMUWNRStL7-IpQtFl20cuYPibuhUPgldC-1yBQ__", "Atta", 175, 20.0, 4, "1 KG" },
                    { new Guid("1526acab-abfc-4d8e-a9fd-c06de938ad78"), new Guid("afd07098-09a2-4e7a-abe2-72716032bb71"), "https://s3-alpha-sig.figma.com/img/4c39/12a5/9ecde1ea67c855b209afb4cf9d42303a?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=d9hfjrNPmZtBldKep5qCQVADqc5GzlUle7EqQMowtb1hY803HilQlFrKrdtPl0CI8CeMUoG74IVUNzTz5OEWe9ivIu0JZR6ztZfyz4fcGu0jprO3AUDT3JkCurIezAj86~tXWKSoWFUIpOfddvt7cMziQ1wl9WvuzHotyNl7oPXZQCuZmRg~1jAO59DOKqu0mpuCSZgAtlFHG2ljgp7GN6josG68VTdFBqyr4dpzR~Cu5RMauKTI2s~wQcYoosjJCrpAIyfkWm5DIUuy4y5~Vh3m15ewx89v5AZ60FLxgDRkAfgu~u5-cZJZR8ChQU8PGyHFBqoXx7IRnPX45wHHMQ__", "Colgate", 12141, 50.0, 5, "250 G" },
                    { new Guid("237c29dd-4ab2-4c26-9b7e-e1a4a452beaa"), new Guid("24f612d4-366f-4e5b-82ca-4ecf8c32441c"), "https://s3-alpha-sig.figma.com/img/7a5b/9d24/ad31419938248f87f1ada2bf6ab0abce?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=Cjm6itLIHr1v5p3BX1tkOwLN~QPiDVaF-CQ6GjtCDjXT6nwMZfCyCqX3z4hkuozZ10EZziqN53t6dee55UOLdaY72009dJkLHoWaH~aIcbYgTWrOhWtaA5uhS5IVIWfvFE1M-rTgCXdg0v~qFnZz3HZq1RTGG8YOtYE4fhL0~drwsNpDpTEvcGAQZdvseSH4S-j68p0WhyqTLCZDKPUDhReWGiYUWizmhlajGfGc4-8nez3xr6riAHNI4DfnTscoQ9q~--7kfBSmfFY-9aQQdmff4iDJ~Clfj7UHvWAa0unmdmAthN7UlGZ3fdYalTwhxVNDo6~3hfjHjxKGNhr4YA__", "Ghee", 132, 70.0, 4, "500 ML" },
                    { new Guid("2af2f2ea-99f0-4b52-95df-4a6ec46bb6ed"), new Guid("e3cbd32f-9df5-407e-9c16-2879384b9249"), "https://s3-alpha-sig.figma.com/img/c5de/75dd/d375f2bee920fda0fcd7494b29135b94?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=b7Gra5jrt11CLMDG4j0Pcp2qEZOaEHePk3ZC4b5efYrtUobAeRABNRmNkf3z~q5zZd1zHgbzID06CbtVoAKkluNNGJ8-TJSGWC9vmHF5hwdtMvXuHQ21oWtBvZAVZiXyazWn-Rv~~1OMa1lcM2VKLpZbQQTgwX5EDujmcBdhhlfF~a2Z8W26td69T5c9OjkbXFEb5ie6hFQYlm~zjJh~rhiUeVFT6UmNaY5FMKXLOAVM-uZ1S6lQCnBrh04UtahrqcoWeigrSiPnKTXM7HF1OVsQSUhCtrwP8LU9lUOE4X-f2KmfI23BTtI~ySEZeAOZSmufyiWo0SLgQNwxy7T3Ow__", "Perk", 871, 5.0, 5, "100 G" },
                    { new Guid("2b6dbceb-05e0-4036-b0e0-0dc05c4569c5"), new Guid("bde57096-18b4-418e-a121-0d41c689b596"), "https://s3-alpha-sig.figma.com/img/dcca/0b4b/82651bee85edacbc4c796e1f65e2b6da?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=CdTzmoklUsRIq9-ToGAsRmi-Xu4jQ3va69L-ypfX84ZvFF8PTAlkEI6Q4nxx2qMHfPUy9HElgE6NKdzgDWj6yOizgQ6O3A394pox1hKXUqXJrZVYlraVttkQeLdJPSIKg2ieFWrkJWURYfqeYnm5UsJlAUw8SQ7HCtz-RrS49nVdvTIbeSQ4tC6S1P8aImRQnEvBlRpI9Eu4iogF0x6oKKnCwMkThZbReLrxqWcDfgZpaDxwoJLtecRXQ4EWB1uJynV738~3a1vYbVPh3sSqTzy09qsoo3fRGzyT6Zb28xyMF2zg2DBev-WzqSXH5i6N9W7voip6dLhNVvbi2fbnGA__", "Chocolate Ice Cream", 85235, 80.0, 5, "1 KG" },
                    { new Guid("2cb96f3a-a209-4b63-a14a-268cff88a807"), new Guid("4bcc9e22-5843-4d3c-9d5c-35a122eba0c8"), "https://s3-alpha-sig.figma.com/img/bf2b/bd64/2ecab0f93ee8af8393d98c6ebeaaae39?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=X5yVhRhQCpZMdYRLs88zzsYvUrMkrgR~vp-l4XBOsY5eCJo1HVbTXnZNiWTIDVEkT1Rrz-ouFJKKJ88Rz-TZz-SCdOCGfUSQfy2xTjLWqgLJmZTKeZtzzpvS~LFS9oiAQkZllVuaQUJ9exZlY7FkvpiLWzL9xMg-HT81xN7uDYTkYxDYIy14zZ8u0iR5bRe3qUjFzSeJHiqH4YPJd4BvbcaWgIxrCK-GZNndEdf8Ib6LrGazru1Mr~nUABXHKbeOXbK-QwC6uphhk~eINlXTxggtR2WVrjXaKEFHrDg3S~qAYx3EQMqVw0uSTyxLTBYLldA31xufGbAU3QdEyjJj1w__", "Chillies", 12, 28.0, 4, "1 KG" },
                    { new Guid("2e934ddf-3674-4352-9b9a-06e24fb7989f"), new Guid("24f612d4-366f-4e5b-82ca-4ecf8c32441c"), "https://s3-alpha-sig.figma.com/img/283a/2162/5b104fc8917f60390ba46f004ee4e40e?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=TjnSZUPlTgI52BifLL~YnMqZ1-Jev2jjalv9ZxuYzZqPe2hV1eqXzd3oNXQB4g3s1T~X-pU4H1YilehRYqDvvH7PTHaj6FllDUGdhEZY45y~1Hh81ccrw~B~rHd~mpqlJMpQapAe9zJx2iXZERpXHBa3wN-IqCz-pC1sTYiD0hKaXendCI6f2Y60Qq3PRrj24Kxl8cOOM~d0yIw1Tuw0NexiMrpuwUYw0y3B53-ZjAVxrTOUXgCp8x2lta0HT6z9IyyzayqWZe4vFexy7fhwdb4YRFHBf0GrYTuMIaBDrL3V6ddR3j~QVGI2mjPP-ZFMkvnfq8omvZ4YKyF6GqZsCg__", "Arokya Milk", 14212, 37.0, 5, "1 L" },
                    { new Guid("35f8384f-5bc4-4c82-baa9-36048b536518"), new Guid("4bcc9e22-5843-4d3c-9d5c-35a122eba0c8"), "https://s3-alpha-sig.figma.com/img/f44d/5fb7/feeed2a6408db9941f1d3eaf211c4457?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=q0Mfbtln4EyHlYMZ3je2xsPULf1HICwFGFl6yRT0b-P-25vfJ7HD5iIGicHThvyig1v8AqjF8iKGibWx-i122JazCrnms0Y2uMu~GsMznDOfsTdnXim-3XarfOYOVm5gXrGyvcp7M2igcfW7wcZ7xMlAZAWrBcaZRehoSFkLPPoTx25p~TGPY63AX6PAfdTB-s6S2fTQtPQFkBrvHrtKZpAHBNJK9fTGHKJ4hg9ByEVTIoJPOLd2BR1I6VIK17CYH-ipwxvdSU1f05MVOadVlYJVLjrVjDb~gimhhh1wBaCBaFPSP5FU6a5h09m6PAfOZPTPBM0kpLyf8C3CD9PW4Q__", "Watermelon", 2114, 50.0, 5, "2.5 KG" },
                    { new Guid("38631798-ebb8-4208-a0a2-e64672771633"), new Guid("afd07098-09a2-4e7a-abe2-72716032bb71"), "https://s3-alpha-sig.figma.com/img/7e11/29cf/6555e42f8bf579eec839ef7942b334eb?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=n1rrAOtnahlWWvXGJBS-2jBH9cowZv9jKfy0wacibsPmDnzr38t6JuROcBhe1YKvKPG2No4O~8UO-pJuIst-wBIToKr4Auo6g5-I3RH3qk68j4mAURrc~XG2sjS~aVO6Yb6XqbkXFHB3G6Uk-baWm8Io0wkmCHW97JzFbND75lHGtCHvWbZhqIr5Go39zoyuqyfhqPl6foKQ5yZJNekIkvvHwvPPnyveoR10MM0wQt06P5D3OOuu~gOLIbxOKT8yKzHxH8bmSv8QL5bEKDMRnnOPvgw7y~A5TgdGvX5sRmF2ExvJLaRQEk4LE0KlBpTCNI~ohhzX9Yh2RtvoR7SMfA__", "Harpic", 9701, 40.0, 3, "250 ML" },
                    { new Guid("3de01125-5e4a-4efa-914e-07992e25d295"), new Guid("bde57096-18b4-418e-a121-0d41c689b596"), "https://s3-alpha-sig.figma.com/img/a7f4/1e16/55bc4908948ebfe7c884acd7b4f6db0f?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=PD8ogPM8mKNYp0CDVFPCEi3g7CHdzC~nI8ypT47WH8ed08zbPvxJ5ROyZ48ciBT3jPOiIWnPlvSUtZQmpKZOmH-qX56jaFWmqgcAOAffzUlWrUqYvWdE-uY1sQDQ1xkDCH-i-TjIXg55ykTwwXeZ41mosOChlZzCfv5TXHSuy5pazC2Bw5aphHituBSNsB4piLuYG586aWBicwkvk10JqzapU7fZnd1MswXATEFmA0Ra8KigBuAcsOeh8WMrihI98vwQ9BVfAswiDKGSzIu73t4tZmuIHa9pvPhCOcBfNWugqt6ubidMoui8xBWzd8paeP1UO-rgfKr6LvMW4tD1tQ__", "Coca Cola", 112451, 15.0, 2, "250 ML" },
                    { new Guid("3fb7253d-579a-4fcd-9179-b84566f1ff1d"), new Guid("f4b80fb3-6482-4d08-9044-2fd31bc9e5ae"), "https://s3-alpha-sig.figma.com/img/e498/6c5d/e207555d4c182fdf252d843889fc8ce7?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=UpqiPQXVopABNmZVTPCxZJwD2~Qe4ua4RJMjTuMlqwKR5Rpo6i1z4ipicVSw8MBZ2DDaX0-Ssl~oPuRxFbODo5hFfxLCp-5wNAbprb-sWyU6BQyJaCPDBIRsocElaYYNmPLBazjZ5NgvvHG4lvN7dBQyaC6KvySXMSpno1wvQK5PCSHTtWWdaQ702FK-UXPfA9tsG4zJh1BO8typbTqYTaDCqlb3ZuW99zyipGBamV3KQvX2fq-BwfmgmRhuhyQmk67l8HjEMm-8h0wUZnwP6rVB1AQx6AMb1k7dgroLTwFeYh~S7pwnBW3-PrE80CB3J~E3OuO42Ebc75O1Nf4x9Q__", "Prawn", 1435, 460.0, 3, "1 K" },
                    { new Guid("3fb83435-22c2-48fd-a502-c79558ad487c"), new Guid("bde57096-18b4-418e-a121-0d41c689b596"), "https://s3-alpha-sig.figma.com/img/0333/1cc7/7cb7097cc4a9f73937f2953bcba9ddfb?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=B-MndsGkhWnuOOkzjJR88fIRz1dLOL8WS7WgkK3g66nGAAVgGDaYIuXt5SubsYo4eCPkUqMmUDy0KGgfD0kjwFVBFzYOUKLnyWTMqKueIQzqa2mwjnD59-m7wa-yzUio2OfWr12DMTVpk5DgzuiUpXjZGcKIGyQhMvgWXCqsMVhMdTpoUYyjkrqA3nMmHBsLTdfVFjGpW7-8bxBtqOS93jRoHyusPm1bQ8vMxPthRRYF~7i-Ij~Pnvn8DqjkltvYkSjMZpwhKmvbkq6BznTqNe35JyKBQyeLdqK-fuxQtkZaW6Hktb~QjDq1Wbdx-Sg3~Z2wKFYt~izPG7AbmelQ-Q__", "Mountain Dew", 6713, 25.0, 4, "250 ML" },
                    { new Guid("41966dd6-a187-4ed9-ba21-9887029d8b50"), new Guid("a1be8b20-1226-4833-bb59-40cb6490f785"), "https://s3-alpha-sig.figma.com/img/9a4e/dfe9/adf6a4b9e371606cbbc1a30e4748eb17?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=V60rtJbrHaMF7TpiAaEuGZesY6Duoc2Bdt3DzlU1uIER32bVCuiZZGsrvJLSS-53~sFELdiigUv7I6EU-~khIYrDhcrZYVvn5TcQ~zH8W40LeXZ-9BuLNKbK5sCN6YttkKZhVc6~hfKuLlty~Bk7BaVlBpU4cf~vTEtFWJ0HB9-VhKmqlHNd1gpbtM8H3WXiccADGE-KX9HgkFEKwvQ~McB2nYsT7xSWVcehqwxTRSLmUqFWa8RtAX5YLoj4QhKNHlv~AnvPCXrmvE1XbBsHoM6z-7og0TKkIKuoGVJOlmCzLJL7XsfQSHxdL8g34~g7PdZPNFM1YhTIhdnZYvr2tA__", "India Gate", 8175, 28.0, 5, "1 KG" },
                    { new Guid("4cd0f5b5-c9b8-44d1-babd-acc8ea113069"), new Guid("bde57096-18b4-418e-a121-0d41c689b596"), "https://s3-alpha-sig.figma.com/img/f259/8319/72bd823a19f137b7e9b9d5133c0c50b6?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=dB1HcYAOezEISSkyhWVZhi5wTumjHtAIXGm-CpTK1WQU5cDGo0ad-PLotdLkAwNBq2SXYcpxY7ru7WQ3B1FydqgcpOSJWZwbVOcBOzlWW12YJVAiePlijhLva9D26wFzL5e3QQDtNnKxewjXQX6HYlkaZfbtpKlzfhhMiVe~nReiwYBXzSHeZXgYN6rfAfhqJgzeWH9724ytQ6m0zV-AEYrQAZT2XsPxxzhf3VjF7qDgkZ3WsnBwUg5gLWs9idVwlo453h~aQVxFiqihrlso7sXObAe2QsTWhpyvqSQCGdKlFuotKfOos0FurUx5ssWB9ck0kR1Y8iOp9~ekSz6o8Q__", "Red Bull", 1581, 35.0, 5, "250 ML" },
                    { new Guid("5b8d604d-7329-4be0-bd74-567f47a5406f"), new Guid("c3e2e423-2612-4f07-9822-826016e78fae"), "https://s3-alpha-sig.figma.com/img/054b/5677/fef35b74be08d589f0e63ee837ac8884?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=NX0~wrEM3OMPS-9UXPmId3zfM3yAAwJHcksg6lYEnY8sVHb-YVmMSMkZSrA3EunK55L5BVQznJRTVEL5tkJvO81ncQ7N4x53JdFRdeAz0-mKzUERSEKljf-esb2ah-oGFK7H~dHFgDECIOXUjqDISLwA8dtGsHcUwlkQ2DXx0~Umi33bQeZRajO8oZ51K-YeZ5jHrhmRK09dtLh6CooWtojhfH5LNnB~wm4hT-lHDpBqLs~5bZrcWcfnBhd5CXHzQvPM2tc8TBCrM~CW1fYYghqbA3RVhlfqr-mCm6D6CWLl3kggRQVfyumNvtvCh639hnZHmBPGhkztFVdL0VITcQ__", "Taj Mahal Tea", 744, 40.0, 2, "250 G" },
                    { new Guid("5e674efc-1946-48e1-bd4f-8dc46970a02b"), new Guid("e3cbd32f-9df5-407e-9c16-2879384b9249"), "https://s3-alpha-sig.figma.com/img/ed8e/f805/a85a91cdd0951025badd8ce3ae81fe34?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=fkkKSM8hXGCHcD-FeT7IpMz~eB0r3oD9osRtGBzJ3Ga6HJPCoG6dSSiHs4DR8J4gS9jU~FMcHNyIhE2LbDHRqPjhm1sYjeUMID4K7yEXF1vcYXyZXbFSosSsRPUPIgbT9D80ZwNp4jnTuo3dNJJDZxzc7QazGDDCIC1-Gy5s4kjXOlGRkyOqvk-eLKEI5vMc1oyZnLz~YWbw6~i9qdkurN-Wqr8WmUd7bZyCuoY3IFjfAqfdleQxhZsIPf-Bo1q20pUpIvE9dRz3IdlgVjs5uqt0Ii6uwKxHPQVH0oMrUGKyxF7-JiNiLyMRSa8qXMtNwTatUYPvH7Ww-kyMcd6C3g__", "Dairy Milk", 1090, 20.0, 5, "100 G" },
                    { new Guid("60ea16e3-c435-48b2-8061-ad31c8bfb660"), new Guid("24f612d4-366f-4e5b-82ca-4ecf8c32441c"), "https://s3-alpha-sig.figma.com/img/ede5/b475/706ff4ef21f91c98757fe5ef7e812cd2?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=FLgeOAeO69poNWDSS5wiMiSGuSnRAndjmQ9r52~rqMWTKuJw7L3tV651qUcDEtWGU6YlPITSzTchwsZHpVAxg-WjixVwLAY~9v5Jm0RwmQPdVDEUAR8-ynz3Nmu6GSaYe2Qe5kYltiOL9s0gj4Sng5V78EhwGX-65dwJ10nqH5xFFzzilOdsIwS8TBAujYtMLwGHOx-J7LPXQSDihzslMVoYRBkL5lSVTXmuuS8yu-D9AriC4awhjjjanZiKRgOqFl3sos~ykPDMfcKsTbQw~QIlonwNgVC9spTXGhQviLSKfzRTFTYqUVVd9JUnDpnjxCh9XtAwIrwCy3Pv9MYNSA__", "Yoghurt", 1972, 25.0, 4, "900 G" },
                    { new Guid("6ca58511-c7b4-4f6a-82fd-aa6a1f221156"), new Guid("e3cbd32f-9df5-407e-9c16-2879384b9249"), "https://s3-alpha-sig.figma.com/img/e384/6e6f/c204fbb6cf7593bbbca50801f5593af0?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=V2YgZUVgNA9pcTx~IUnUAcRy9fPkAmHYbVkPHLreSGDcrktOKOu5IIO6Mn-DxVprs6hBq~LzWRYJGlfhsY6I0xILs1LMrpLdrqrIss0tZfsvkRTWJlywkK0hP1PKjdWWDhGp8UXTscQ3WE4Df0MdlfOghgrCSjRj4EcU9bwWoDpGMp9CnBLDRgkXIQMzcXyY9SRts~jqXdXQwD8443wek3I5YUjrodVXRZuBuuGfr6eGA3ZcuequAHFz6c05EfDFDvr68XWEO7mswSgkEgjKLC8KHPf9631AFGOuNA1D3NIRoK4nHUpt0JOf7FzkCfoC377Bj6NnOItq9C7Bnng0JA__", "Pringles", 32910, 10.0, 4, "100 G" },
                    { new Guid("6e596730-14e9-43a7-8f6b-614e4bd1f93b"), new Guid("f4b80fb3-6482-4d08-9044-2fd31bc9e5ae"), "https://s3-alpha-sig.figma.com/img/f0cc/c372/fb5ef5ab9991be9b914b626dec947647?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=irxVm5XrQ5sw1Cvokp4Fwc0Runikcfi9djjejkcn3fiqJw7q83UduC8BIjGIQ50rl-8yvoVbWheoPesirPL7tYXcpaVhMlQIh1i5acbNJN8HZ91beg-IB8KIag1n45m9nszyxBxmjrCjM-EHB4hsxLVXKqfWyMcHIwOIhrB4cajqqQOyTwn1fF93M1tGysoSm8tdmXUy3O9AMlAmYn2ruDtFZN3tGowJh5I27FBvD9EGeTreel3wJfyU-dnSDmySEi5M8toFz8NaBt6ZzNb8n-M0LqTa4iMgAEmmpPSA5Gjaj4AUWpLA-rlSWJHtrnD1fS69VV5CdLvbZO-8wf81PA__", "Fish", 35810, 80.0, 3, "1 K" },
                    { new Guid("7c351659-0c0a-418b-8893-b720b1a33ce1"), new Guid("afd07098-09a2-4e7a-abe2-72716032bb71"), "https://s3-alpha-sig.figma.com/img/5a1f/ba5c/29f3a85c13f96a4fc28e3aac77831888?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=qu~wrgsC5kWPnhIuIH2zj~iB0eW5PkJR~v9LyAoRcrY1Py7W1q-dtEh8C4EotpRPXN3lE2EgrZZWVBLRlrzQlqvZSRwln~GlCexdFrONwQFDC2STv8fII1ygqD7zZlY4Zuv6W06M7mb68kipZqLnk6JBygcM1zp0eVyyyq0atGqdeWiX5SVnIQxy3G~i2EqOZk8e9TzHLfkqTAlbYE5WEkuPZf5ASpanQsC9DKw-WiFrwJOhIiKiySkTHJ0uW3ryWkDBX34MwhccVXhohHhFTPhi7qD8k5AK0h87AlptKcCh8A6iUBxLn4ZH8EmekQORgTePU2ZxkTC~Ar-ZgXmwrA__", "Dettol", 16971, 70.0, 5, "250 ML" },
                    { new Guid("80c5025d-400d-4a67-ac75-003f8c74b08a"), new Guid("24f612d4-366f-4e5b-82ca-4ecf8c32441c"), "https://s3-alpha-sig.figma.com/img/2fc9/920d/e654757324d53d20c011cae2b9707f8c?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=D5Blii9UzDfdHcvNMXObXyvSAHrcHcN31h1~XPlKjnD~LR8hxrDpKJJD5p40Oq2R-21~OT3lZYnsKly-A5yyG0W--te7SB19WEn969pNdx-jp7fkZcBL~45YjTM9ClNjjS091D6WoLTUPXUzphrcQzY1uUvjLHCGUT0dsSx9-jx8EixngA0~KlKMTBt5lxyuYPerJv1rWEwXYmir5BlLwXe1j7W1XkRCUImVjpQ09TBy~ggQTuM-Kd4c829IGAqEtxRyumnxSKHJGrTMN9ANapJzhIQpdcaJwFFNqG5D20MW4Gw33IK6O4e6Q1LKUv4YI4KMWxCiXMKDCFr13R8eZQ__", "Alavin Milk", 6142, 40.0, 3, "1 L" },
                    { new Guid("85fe3b27-3f39-48b7-b2e8-5ce9957d558a"), new Guid("bde57096-18b4-418e-a121-0d41c689b596"), "https://s3-alpha-sig.figma.com/img/20e0/ae7a/caddcbb6c172368c7bdb12b4987b4bbf?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=QEEEyNrkQYeeOicj7HKHneEo-9X9ncJIYRZLvh4hm7~huz01tuMGCkxC57raTDmxcxyxN02yTStadbylMPm5kYsBX-kMwoR1oVunHUiUT3iNTkNt77nyGJ1m2vCbHiKeacMSYrvRugCy3AmwXUhmsRaFbrrAsw1EPfGwAwZvqxGjc9d02RvcVg4IY8s-L59QfVorkBqCYzN~ANauhx2AlGadHihv5AAqfKKdEQ8ZcvKU5htnu33hWzypAcdb7RSkh-LehzFH0Y0S-maMbUsht-ep2HQRwRDH1ErVOX046rJRJkjOxOhIlSZW6cfH2Cbuw7UGIbPbJHWfWGn9SIDxEQ__", "Sprite", 2451, 15.0, 3, "250 ML" },
                    { new Guid("8989a4de-905f-4e67-949c-be4fb458dab2"), new Guid("24f612d4-366f-4e5b-82ca-4ecf8c32441c"), "https://s3-alpha-sig.figma.com/img/4ff7/5907/6ac14f0ea5295944c1be4edffa8349f2?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=NC9LKtUGeE7BcKjgmxMrxEsC~mG6rQA4R0s2hEXkgfxBLfYFtVcU9UZTyfWN1jXiLScoumTeLORsKQwZ00-jaq6-exJSiW-42RF7EVwuCctLBJtxlvX7xfM1-Gv3Sw7KfJtWB58QafJFVd8D~1YcH3oSkC7w7JIAKA0bkYgYrDh7DcE44OiqpSHFdxcnRDQx4QhDX4-ZWOmeJVu2YpDwgb9ft2niVWiT8ZjjMlwQBW0w5Xz790raJ5Pij0O8GaP5FJhKrKeP5S8CCWit~MxhuNzd6JMpy7NcO~el7zQspfC6rzHGQIMdHb6h2RGPiGAAzjZO3QvJR6LuXOZn-q7a8Q__", "Tamil Milk", 5714, 70.0, 5, "500 ML" },
                    { new Guid("924cc07b-d12e-4e03-8c54-53b79eaa3e20"), new Guid("4bcc9e22-5843-4d3c-9d5c-35a122eba0c8"), "https://s3-alpha-sig.figma.com/img/1369/ef14/f5ef50512b0dad52cb75b39343bb0952?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=eYwM9SX3Z5x2ujAHKpm-R2f1tZXKzCiA4901pTClFxc9PvKhAnIw-eaTaGPaiwW9VL0ADKL5zYvlfupr-aPL3ks97MjtbNnbLN5kj8dPZXPj683nUd1SewV34v4iTttkaoV6qxKbPUgv5-OfetkKxtX4jMCmcXtoUCenB~024BTkaumM~lpmGZioT2JuTyjezLRUcsXCLa2ynsuiQt60DJtcrPmFY92L0vmfx8iDr483evb-FBlu9HYqpKsgc9r-vN0s~gX5XmTROe7qPNeemVSz8W1yLPZ7fQ2m4vJWv4jtBy7Vu5tIOvjZySUE0pc5G9c7Xm8WJqROHXsbyao-ig__", "Potato", 8741, 32.0, 5, "1 KG" },
                    { new Guid("9cf1e270-0ece-4dc3-88bb-84bd3d4f1ae6"), new Guid("4bcc9e22-5843-4d3c-9d5c-35a122eba0c8"), "https://s3-alpha-sig.figma.com/img/ae1a/3d22/5bfa971fdc16485538be63a4e3c17fba?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=BzWEn72K2-Ba4~gT-7VwotiQETjhy~kFRmpeY0vncYMEUBZBrQVuXHg8Qbg78Fv0vibe1Tu70tk795Jqbc-UjfpGEt4NzJoh1BK-BCzLTrrJfk-UEoF6NvD0ciUGzTj4YW51biJihJiTsGVgQl0t7C2ub6cp4GdRBNogQKkywWyCTUyjRIidacsa0AqK~99kQ12XqlD6ux0Itjb7a797n5truyljDJalZ7M7iAcl9NPJk5ijig5OfZq~qWdPVSSjdJeVqeeRiwmLkwT0PmBqmmPHRomGxLAxLDpzuXI03zxAekxs4fDZcTCJm5qwWLlJI6Gadqi3pNuKo-Q2Yp3tbg__", "Orange", 442, 30.0, 3, "1 KG" },
                    { new Guid("9fede6ad-03f7-419b-b7db-9bbc43d51e74"), new Guid("f4b80fb3-6482-4d08-9044-2fd31bc9e5ae"), "https://s3-alpha-sig.figma.com/img/77b4/4528/2bf108e1c1570e4eecc81475ee53bac8?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=oB3dTMRtrxb19~WoOgrnKHvo~Q3uvCNzDM8mcxaHnVHkU1iUY0JKuCNeYWX9iNn165z-oyrfVYrWsuc~mfwZGEqmETg9gL9CptxGAGFFxKrAj~xq8XBTArhDDSTNJEFm8JlxhPBtWOtQ2nvjSb6jj2T0E~COwDMaLt7WksnMUEydaT9UUGZn6oYvOD9cePvQUOKNO-2ETnrN1GfN1LMsHv4CHQFnkWU5Clj~as61rhJTAH~XPO-uBmXkWMy7oupfUjq3LRnkAxBUqh7~Y7569~rNtaBKUsYdsGOy5YaArTqXZBcrMLD4JOn11AJ3FdHLK3-hot-BFxrxl5FlHwhZtw__", "Mutton", 42405, 320.0, 3, "1 K" },
                    { new Guid("a2a29ad0-0c1b-4ff6-8246-3f84bdd7dd15"), new Guid("bde57096-18b4-418e-a121-0d41c689b596"), "https://s3-alpha-sig.figma.com/img/b049/bd34/ddc59fa3acf1e2471ef04fdb4f65c9ec?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=KTK5hn4zY-BTBoLz2TvLQrQ-RuLJfdgX8rh-vxuqUhRLM6mnJrq98IlvSTO4RkxP6QKyrtg7n-XlEOoddSn~V8bNU6Izdbsd3tg53vgnZeMNOXXJTPgKzSLLR0tM-gHtc~CJKICvf8Vg7T8CtfXdDgheLQCCvcwZ9TOc8bMKOeLmEO0OcDV60qI9f10ednm3Zh0RLgQh0i0VRQbCMRmS~9BvN6h5SyKrLtmRbU1~yEsWRwujKc2dznoLKm5PpLqGUX0mj92JGXjp04X6F00OJrX75EkKKbiHIFdIDEWhJrRUa-J9bVAqgZjdwbOxbeM~yXu2jOaa1byhHFFIJJ4fQA__", "Minut Maid", 24, 10.0, 3, "250 ML" },
                    { new Guid("a95f5b02-6e70-4825-b4b1-b36ab8a51087"), new Guid("4bcc9e22-5843-4d3c-9d5c-35a122eba0c8"), "https://s3-alpha-sig.figma.com/img/532b/d563/02f28ef6136709fabc221745336a1675?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=DZ8bR0Wo3jPjqblPYI3Y4ikxOLu-C3CpNCfD522tMdfAqybWHFGebbbWBeJW8PcQ1yaQUfzu7VqqWAv5ix4v0RBYpaTXsxWM7kOZDSgnNA7sLZ6kIksdjwaO3tR1DQD2WBZSN7DotGqa91XHsvn0HKerScQNK1B5bQrmLjrQB-d8z7xPRTJaAkoiExlPxe7zQV8l4Qc1vnpmw-VnD2w5L1cjHsQyoLoSMf0G2EiMy5V1JDOmq3jOR5w~UpwfNCzU~Y6QZUbQgay67c3L3tmhmbOeddJhiGPlx4sQcXG3HeuOEEsorhpCT2lpV3o1SWlTWm7NqTUBxXXpz2mc9XAeFg__", "Strawberry", 5014, 46.0, 4, "1 KG" },
                    { new Guid("b22c9dfd-76ce-474f-8bd1-00444a8f3208"), new Guid("e3cbd32f-9df5-407e-9c16-2879384b9249"), "https://s3-alpha-sig.figma.com/img/e2c0/286c/56e988e20099971fa63b317c7a375996?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=igD8a93SyVT-XDNdlg3l6Ooe~PfVHdZYXwHqtI5fGw9BiPrgzd3b6SqoYefzlFz4m4LKVjYed0dWxxGQL0Zh58tcdnOBYHEGIHVIZ-oERJSwMBGAez5oQMg0ZgNMwFG2xdF81RQi1G01NB6kWZ4jhCtt6l1zzi7pcHCVvMVIZRw~vodF22IF~RU3puyXRBx7FLoyh~b8NNs-aE3NUPwhrsiJrKqLQxkeM145nIRTwSxAKnXwieMQ0f3N8hf~kbgVFq-rFfBo7wNYDaNSkzaRwtWaUXtG5Ye9zKeUr2CxFja8q2UUfMBSorSMxr3WG4-w1xw1YQ~lYvuXDY0~VQIHBw__", "Parle-G", 280, 5.0, 4, "100 G" },
                    { new Guid("b3a06d48-cb1a-4f1f-89e4-e11c4d8f6b74"), new Guid("24f612d4-366f-4e5b-82ca-4ecf8c32441c"), "https://s3-alpha-sig.figma.com/img/ed51/f4a1/5146f4034c171c86ad6d021f66ec2adb?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=mGFXaGfBGavSSSjqC8jOP3Qu-uDM8caGmS7zWSWe2b8m0XUQXtudv5Pguzk94oyNiXmeYoSVSPkjeDdLl51OOyhbW9VkurT4vsdPVD~BImT~Qi0jhtzql7PSh6EnTXVc67TuDo9cr914k2vgiS6GgydhEUCFIJr-IlWNPJugtFt~WwrLsqsmLXemaP-ODH45lJMwOdXV6y5eLIHwVnngAllZFpQA52eF~3hWGJOpny5yBpp4o6KvdPTDWt4GR5sS~eJY~3ZADjL2j-zcCtxOzGqxCaorirUrEoL7Il6aOzwjeUDQzWF1VYhVWfcOQF2cgUbNgFP8Ts-5LyzWF~vR9A__", "Curd", 142, 54.0, 3, "500 ML" },
                    { new Guid("b4efd5b5-1286-403e-bea1-f0fc9a58889e"), new Guid("24f612d4-366f-4e5b-82ca-4ecf8c32441c"), "https://s3-alpha-sig.figma.com/img/9382/9338/ef170f770506c26753d57adb0373dae0?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=S7JX6ble~XDQ7-HVoZFPnFko8IDqwIOXpaRm~yA-sdZfXks5I9zOkb4RHc~-a7yFmZjEI8TEV~vsEXWcSiNbPWvXg14o-9fw7c~JG7WBfXAnTAE-syCLQFhFBYXQk3gwEKKXH4BbhsRkGypYzOmLQLOXws2qiH6TQXcE3nZTSU8UpTyxQC-lTJM~IgzPNisSsNXyiH7vTk4ux-S~EQdt1ePAORjAmFrof6mrh5BIS0nh76AqkZzkJlCil8VfdRmoTd665kbozVazMvSM3WgYgJVLQbop0-pMJFNAXPzF~GPqvJMC3lPfOA9n2gTKFX-kP-pNGg6fQi2YM3UKqx3z8A__", "Paneer", 2492, 90.0, 4, "100 G" },
                    { new Guid("b6f01fd0-06e7-477b-961c-f78cb7350451"), new Guid("afd07098-09a2-4e7a-abe2-72716032bb71"), "https://s3-alpha-sig.figma.com/img/2b89/62e2/f971f747dc96723b9d0ac63694c29e38?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=MxgRgX4OzFkOWlhvf7o5aCGQ135L1rKBHXFpwV7neh4Q0NBXl5YeWdAXd2BHUGuB5wySPANZzP~ezzON~kqcC4tQSRo1hinIDavheNErlOps3dMR~dkndy1ys9UaJGwKIJnEkTQMWOJLyZiH5qN-N5uTsrjS0K3KRxDsnLGpmr6O0oOKWHKb2upAX6mzbv7GRDt~YB-QYnOqWPZw0r6sBB5spgW4vmD58C85xJWWQWhDjnTkwqhkxCN96eWQP23bjPanQ1c4g19HDWZKnroQSOuXcYDFdp4znLdvZfPtkfdpU5W-iuU~qZfCGV3wr0LkWUBY42GVVklTMSfNnPSxtw__", "Medimix", 120, 25.0, 4, "150 G" },
                    { new Guid("badf7ebc-05ec-4724-9867-e2550cd40f54"), new Guid("e3cbd32f-9df5-407e-9c16-2879384b9249"), "https://s3-alpha-sig.figma.com/img/3701/3399/b5e4bbad27b1daa5f9d789050288058b?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=opbSnwF8YvCIgh63uwsjq-uAlDrtBMT0j3LXL2~URpaeazdWfsTrt5~u7rnHTYV9u7j2Ijoy3YpTP45061GWZnwXGVuKBM5dCCPOCTBfRrFp88IlK8J-OFDatjJp7qpbb6eiZmzh63QxkZAUOwUK3D6T0X5UoD9hF0~4FkFDsKQWkPM-xU-cg2Q4l9FBZKOY5pLcsa3i1SYI-c6V4tIEzF4DDjHB~lWpuxetzkHZGVF0zS4atHZECukOGL~0MbhuZPL8rv3vZQX14EsC3-bYcsx75TyzHVr~o05qIZ0AdHrYRrkCqrbHhpwXEkY3ZC5zdM-rlnQOJqIfGUodDIA6Fg__", "Oreo", 120, 10.0, 3, "100 G" },
                    { new Guid("be6701a3-17da-4035-8dee-fafef2952eb4"), new Guid("24f612d4-366f-4e5b-82ca-4ecf8c32441c"), "https://s3-alpha-sig.figma.com/img/e9dd/199b/e8f58907573da91a9e04db16fcf31a6f?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=o3viRMaI9LQB3z-F0GvsK21WFo0dLiIXS7OpCQn~ab4KW6Z7i9xtCVdESCMdMGEPXObeEk6dsyWrGmtp2bHLzVGxB6kIVV9CrMW1YavhKvQm19gGNk5CCNNaV2BaoFOAUOPl~0zhtXU-X-5fAF928YR8RIh~LwklHQN8qnb4BxVCIWdhHcE9ou9vKK-hbcEDGQkAiuOBPTVOIRHosVU9OlW5B9QNxNOgR11QKD34shNmseCmoun~bStheLlUzMS8s2gA9HKNo8cWgOGkNhP12Iztv1b7iSt-9MQ17~4H-iiuSrJpQ7d4zDEK36d9dADfZ5AkJqP2E1PytPuEtbY3kg__", "Butter", 691, 50.0, 5, "250 G" },
                    { new Guid("c1a8954e-09df-4355-a05b-4bdbb7634396"), new Guid("f4b80fb3-6482-4d08-9044-2fd31bc9e5ae"), "https://s3-alpha-sig.figma.com/img/744a/3044/201aaf7e9e6ef3c024b9fb965f2b1359?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=pv48YtFcIAlsNhX6nTfriCt1btLKrhGKnKdblDPRUsZIlOdngPKq0o1yvVdxEcK0VSYKhq1R0-hzJoOtuCrhxOBUpb~cjlLhCVZwFYK72~LEhhLIOg17QR5IPmdX-vyE3Mec-ZcYyb2zL7kWahT5Uf5rxkemyo2acl0UVmrdYoFjFr20mCEB-Nbmuhm1f0OeSFtXPP75dDcev4UFEOAEqe3VpTTZqim2Rc-8HzkVPD1fhJJnQEpKNkJuOIOL7h1xxWrvjDU-vz3DoROtVdILGucYN-y1V2b4DLdXUySjZLkh10ebhV7T89wuRyzW7g1p9uU1QBsZivHwWUonpNM6qw__", "Crab", 1114, 400.0, 2, "1 K" },
                    { new Guid("c75e2e80-efeb-46ca-bbba-edc9ceb49c83"), new Guid("24f612d4-366f-4e5b-82ca-4ecf8c32441c"), "https://s3-alpha-sig.figma.com/img/e7c8/6005/2a8ca0065b25765e73e5f6846fb6d070?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=pG9KHL8bWLqSp82bsMy7UQGiI1m84lsyP7fvoX2Xoxz-bAWqzQok9Ti6GVvteOE7Q21ptzZh~NRTafVzKD5eUWa16yGB1YCfbtV1lyUnxzJ5~ZnT8fFJ1qpGZlA8hnX8VbCtN38T5MiS4CgHlBYzEw26ajpSoXJDcccfvsrK1jhj3XBv5BuEVq59FW7KCTiILYIQ9mXYfU~lujjdMmDUmBVFVZXWx-4QxFAqIBX00wdQ35C8i~XOZcxnE3hR8xTG0QhFEoik62jWJeh-TEt3k46Tla71~cnpBE9UUx6QdmyrwPFH7ZUyEvg2B6oZNU2dxWfQ0GHzhiyGyu85z9sJPg__", "Amul Milk", 89, 60.0, 2, "1 L" },
                    { new Guid("cc97c187-b113-4fa4-845c-dbdc04a176cb"), new Guid("e3cbd32f-9df5-407e-9c16-2879384b9249"), "https://s3-alpha-sig.figma.com/img/296e/0ac3/8876dde0f0fbba792d8dc173939df1b5?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=gvw4fhUaBqOxGSHKi-eGPl9YqXRpnySiFK1VPorN1XtGqcf8WqI2ZWHkTSwKH5bWwywbsCk3Jqse29SoAXv8tS9BLHqVRNPQ-JQMcs738ZfJin~op6v9e2PyYbZYfplisEP7CHXpZOhpgpysBeM4EIu3zZsORXlgp1iWUrXkKskmD~RWqZwmTiqXI2H2E1iQm1~9Js0CVPiwCLcvzpNTX9ZCG8QAi0~qHwPpgrH45EloCyC-oBvPEHd6HXsvR8JgubmI0A5QbTFBCeZMwVZ8thxvE-Z-fR8jmaxIn6TdBYLDO5XRRmxkhH~N49kvyJBJqMmy3hB9UQ29BnY3EX1zfQ__", "Lays", 9330, 5.0, 4, "100 G" },
                    { new Guid("d3221499-4a7c-4bc0-a95d-88a2c1de87fe"), new Guid("4bcc9e22-5843-4d3c-9d5c-35a122eba0c8"), "https://s3-alpha-sig.figma.com/img/0dde/a401/c50af9b2fbaa9d101149f773b0998141?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=ApPnZRZ-7DvnieXA2k8drLEjJ8Ru7l3uyDJNnEH5873PEvE4ibUFHLrRUPWZbeju92sbzuW5XKxBEqD1ab1emg2FJBtKZhaA7pOeuHcKkK-rDvR9-SCkPIw650qTM~v0w8OiYd6kG7dcQoERE-z8GwLwWTN-x6Pi3aTtD3htnVbs6i0wjvgZBQL2WNrISLQZ9vtCHtHEtTLvhmEuUKQs6-fr5c9MH5-HRvNxzs3W-~falS0QjXkze5FpKod5JLo45P9AvNgzQnqEXWzkRLKSsJZ3KsombuBeUYpUwjiMiSoSdfkithgU~F-k~LadUGUWMptg6SzWLsIMbHTbkZ36TQ__", "Ginger", 71, 10.0, 2, "200 G" },
                    { new Guid("d917d9d2-bb17-4f8f-837c-7c9d3ed962c0"), new Guid("afd07098-09a2-4e7a-abe2-72716032bb71"), "https://s3-alpha-sig.figma.com/img/2df7/e4e3/27361fa8b79b27e4fab94fe8f32af4f4?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=qDKgNDr3OzCcwViK6L46fCAFj3x3es2JXPazUeoVObuzPzVoKsHnYrGIgVzyGwXnpFEX46xm0yXOzIHhUcfkizGRhVKz4zOXlHGX7WmFcCSGoZsOp9ZrfkQW2V6LLqsRDnjOWwQGr5VWcTFIy7LAfyySGdWr-uLFnsMO30zUJf-XumAhaQiWtvSjvPh3h5tVRxARgKNsVpFSfEmn8K5fDmio110CtgwPAMCz5I5u6RNnBJAwmJgScaV9MmvmBCKw8zCJhlTaLsCkU2iEMLBpbB1QwBCz6BaVtNezUMN2YWluMyAJMEhXL95R-0QHk-Ri5J6VdSIIFtKt0CQFrsTcjg__", "Tide", 1740, 40.0, 4, "250 ML" },
                    { new Guid("dd3d7e28-8678-48c9-8077-6067985d7411"), new Guid("c3e2e423-2612-4f07-9822-826016e78fae"), "https://s3-alpha-sig.figma.com/img/3499/d26d/ab0e339d5abd1a99fd3939cb7c500691?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=RNyIcnS0dIAUXN8yQUBXwT88p5s5d1DDAm4bnPNQL4HVPMXYEO7nWVUrZ7c3jre7ecj4Nrpp5BQoIxlWRcLttvMP-~1UvSXAM48vhh3HvkZGn8AtLwuUh1HfB5qDNFr-kl~4tYo7y2xSvUFwiWMidDbJxk5SNbdwIiT7CV45QDI6ci2XvdmWOCs4L5u9d7vr~AY3HRyYFT~NZTsih5Qaq9NFtjEz3apx9Ibv36kRwp1lWp1iLWlPJSNQAO6~s8T8ego-tft4c3-cdrqnuWjohMjtOzGuP0h~JC7Djtfn5jE7ig7JlcBdT-9cJ-lQDHjp7~YqM90yNfW3yh82LUjcRg__", "Sunrise Tea", 4, 30.0, 3, "250 G" },
                    { new Guid("e525ff86-45fc-4820-8300-460ead3f780e"), new Guid("4bcc9e22-5843-4d3c-9d5c-35a122eba0c8"), "https://s3-alpha-sig.figma.com/img/d9a0/ad3e/d7c6826acac6387e3daf2b1efed81f22?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=OLHHR7I6Hw329Hg9JWW~KO6kqHFuV8Q1FcO7RCDf~qj9jX8eS2fBkfvn3j34KIIEgNKDvJghWxo069RX221pE8p9ifJPIDedboB6TC3pmn7TYdQS-s8iYs1QbmvcVr4sWa5tz86nwfztapOVHdN0FxzsV~4cB3qfxqLP1bw2z0cOktMrpAHHLaGcy7ZjEFnnX0WcTjq~M2FqRC3gP6jTnkgpqORxJ5sYYHynZykqxbajf0~Wj2Wfhnd5eRGUu-4BoD4dQRMmen2DkDScdvDlmgPwP78iW45P0e-hjqi6MeVa6qwe9yEX-hUv3J6~ryOXvFiE8Cdtn5Njlv0WbtRV8w__", "Banana", 4570, 55.0, 5, "1 KG" },
                    { new Guid("e64f830e-0849-4094-8e58-b151e6117430"), new Guid("87b5e568-4339-4c24-bb91-f315043783da"), "https://res.cloudinary.com/dbsxwhtst/image/upload/v1721213499/GroceryAPI/Products/frozen/elwxsm6e8nkkjy8rr9bu.jpg", "Frozen Beans", 914, 30.0, 4, "1 KG" },
                    { new Guid("e8fd8dee-ec27-4cbe-bb63-beb523c9baf9"), new Guid("afd07098-09a2-4e7a-abe2-72716032bb71"), "https://s3-alpha-sig.figma.com/img/b45a/e1b1/fb0eb01130704f48ecdcde7fde4a3bf5?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=KNlqgVSQ2X1Jy55eS-WFtSdGk3HHv2K423AqJkR8Mnzrt7RaEYysyTvvBQSHWqu3ddDoWMaLDC1dNt2ercl8x3ftU4bIK1OxdxaTnVEb9YWHLAEelQ0~~Ld-VlZav6cPHyX72LNJfBFRQ25pWR3g6kTmIv7wj8I19BsarwAV6kdDk6zE9MCiu2k7N8ZFN1rAvxoesvlctw~0cE-zeAvQeS01QD4PwNL-NJVC8kGd9Z7YXJRFJnWIRzzf28z5XWBbudKmvSvMrduBLYWV663UjnImSbT9nd0NnbDjYoYTtSXO8DnWkd2vDeCvbUEwTHsLlYxSQgdOhTArZ4HXI8w~2w__", "Vim", 160, 40.0, 4, "250 ML" },
                    { new Guid("e90ccbf2-23e9-4e3d-b8d4-d9a94b92475d"), new Guid("4bcc9e22-5843-4d3c-9d5c-35a122eba0c8"), "https://s3-alpha-sig.figma.com/img/49d7/f854/cf106d63db38be3cb46ce283d7f584bb?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=Ij7fzMjJGcFxHfLT-dlCvMvVWZXW-y~B9wpxMYP4bCBHjkDTqX-G1DgsQRavc63uKE76t81ek7JWS9P9fkEK5TmFyGiAl4ben6HECHp-bf4-3Ram-9k6a79Il4lJpz8v8KnNcmDdr6znSnYyqNAFGDADxjVk72vHG5gMdtBgQfEMN4KSeuPtRyOr0Ffg8im8VKXFq0Mkn0URdmch2FHuiHmTbyfNjteUIaFkUOLVkaXEuMkOcquY1nqWpjNMMqF42~UGgs8yyd3B~G3ew6JK~cY~SM0W9L2ox4YRB37Pzk-FGR-GIiw2RHiw8PssCW5qFH0iKWUHl6KSLNmICeMgZw__", "Grapes", 210, 20.0, 5, "1 KG" },
                    { new Guid("f41e550e-af42-4f9e-8fdd-2672a2623086"), new Guid("87b5e568-4339-4c24-bb91-f315043783da"), "https://s3-alpha-sig.figma.com/img/f468/4d4b/bd371f24959cf6eaf212b2abf06e4df9?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=njVy5nJeNQkoQ8tT5eFkS9eDTIB1REnKKg3VBNtD3uJOLsG7E5rxfN3j1dCFbyor6lmzu16n0Cy6z9tP9A06XyPU~g-zUPllcPFYkmMjFkMu2vocaY2pjWlP2o~GAQeiqYqEwU4yPnmDJWZ9Y8mU4VA~A6ryf~6n6oBY5hNAT9CxVwyuhIAHFgeTjKj9gE9kQgEloTL4JaI1Yb8~RCbKB1J1xJwRIyOLpGj5gItbQIdWv6-Y7~-mb-k4zrlLLVzD6GhFHnKNyFmIkXEHTrNDO7O2729qL-UGTAtXn8p3dNK9lHjxm0tNkOGhkRak5NqbdH2TUmmNvfQWxsLStegq6g__", "Masala", 72, 80.0, 5, "1 KG" },
                    { new Guid("f589f64e-a06b-48a6-aa14-c1d321672cf8"), new Guid("4bcc9e22-5843-4d3c-9d5c-35a122eba0c8"), "https://s3-alpha-sig.figma.com/img/04f0/af31/fe6adab29c176c753984a7ef71427657?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=jDNxPiwncIKytXGlAgVXpNRR0g2cD74WbwOHo5rBXI4mmtcF~zOJLKEzEpWqn4j9m5JfK2SMrowpSZYTyi9VEIUPkUBFcE2nL3O-lG7SpD5cIqrVVddYk8u4GfE45ZlJP-8NCB~tQtXEfbh7qQFIAS~CRLQp0NrY1VIoQm2jyNoBLbjIp44uA7F8~e6YH~P9W~t66mRvKo4oLfVO0zT4NQViKhcBnEdE9f9InU9925cX03joIQZa-Qc0FTedaBGvaUKvj9bfsrmGy9SodAwn3BFBgknQgnV7WsEZlejp2kvGNhDL2A-jww7VsulMS6LoVF-4WvVGNYBYROy0SOQKxg__", "Bringal", 570, 34.0, 3, "1 KG" },
                    { new Guid("f5961533-c3f1-463d-900b-d5c0e74cc2cd"), new Guid("c3e2e423-2612-4f07-9822-826016e78fae"), "https://s3-alpha-sig.figma.com/img/285c/c601/36bc0c472199edf25b55aee031c84ff2?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=K2at6f75ZQCuUZ9bA8zDNmb6Ql9yOczq7bo~L7cZBn4HVyE9NlgwnsIRDknQCvgWXRrd4tAZaBWytN4M~q8-stNJvgCUAU-xpyN8oXRD1poYs~h2YkSQAhMikHxKKI4zzOQRL-5AxCd9lyOkSSh-IRx0Pea2Kmud4EbSigvfQFYosJJXzO50A-ohcrhbT4riv0NobaBrj3d0zevS5sj3uHDleJpA8-8N3Fvt4B6V1J32OvgVsEMIPSM2H02StszjWmJprM5gH0mdXwA~Cn8TDwBuCz-yXSvCxH-WdSWNGCOy0IAtlBRTKMOcg5AXF7YS9Jq9KNL64SLSAx4NcV2ijg__", "Bru Coffee", 12474, 60.0, 5, "250 G" },
                    { new Guid("ff14104f-b074-434f-86d3-2d218dcc7c71"), new Guid("c3e2e423-2612-4f07-9822-826016e78fae"), "https://s3-alpha-sig.figma.com/img/e7a1/2d27/cdab6fcd0cedd91a4584b0cb2759c3eb?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=qrPI3MVJho9iL98E097cVqZNWTI3AN5p~vfbqGq23T1woAEBMb~4UpGew9j5yhjZFZCKkLppLlWj2I1cXyGVXGujbOT84BkhS3cDTy9UCZIDN8noPlWAvhAslyQFsjCO-jnMblFXSjqdbnIurbj74ApFB~-J8diQC-mxwG3t-3r6-O1YbR94HUQwhmyOULnKpWpDZTp7S-abWkZVHg0RKSDrHRKn4JtDqJvBPEQ7QqN6m4L0ZvByLVKxBgthoLGt~Ghs5l~hQ1XHyINOeQ4E9FfSWQBj-vgoa8fjCkwovzbK1ZwetKXnUzCASFNysGs7rhJV-c22FENUr-OA57iIxA__", "Tata Tea", 94, 42.0, 4, "250 G" },
                    { new Guid("ff7fa7f6-4e9a-4663-9871-8688290e9d1e"), new Guid("4bcc9e22-5843-4d3c-9d5c-35a122eba0c8"), "https://s3-alpha-sig.figma.com/img/5a1a/464f/ff495ee471aac07be10fd93dfc2c6ca5?Expires=1722211200&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4&Signature=IfTXDlPBdizMu3XVgII12LL5qfOyjHw1aApxAlDQ1kjFRiLS1Y-xqOmKzB4rv4ekdiK~sqI~y4HKmFo4fzNmbH9~GdyJMhdZ4L4awluwvkxnkRx-ovEMup~Q0mR79Enkw7V4qN0rK6Jh6U6uBpSSM1-~rP1k5lTcsgpefjy-l8LJPLqxJPYTT2EsTRyWMxUTdt4XQEM49BriwjpX7VqJBs3KlY6IGj-op1ZEmdo2lXNHmfZRBuAOj2TQ0U9mBvoEeVz~sunumDsSPrz4SQvS3MDry5P2fsk~SXTn4M9DHU1qquBwOxI7XlV5DoKy5gmgVpNCgTEuR2Zck4k3BuiJCA__", "Tomato", 200, 15.0, 4, "1 KG" }
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
