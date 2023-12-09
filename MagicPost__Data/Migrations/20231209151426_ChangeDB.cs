using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicPost__Data.Migrations
{
    public partial class ChangeDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppConfigs",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppConfigs", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
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
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
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
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SeoDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeoTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeoAlias = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LanguageId = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiemGiaoDichId = table.Column<int>(type: "int", nullable: true),
                    DiemTapKetId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiemTapKets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiemTapKets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiemTapKets_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiveName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiveAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceivePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cuoc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KhoiLuong = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExternalTransactionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Provider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiemGiaoDichs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiemTapKetId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiemGiaoDichs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiemGiaoDichs_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DiemGiaoDichs_DiemTapKets_DiemTapKetId",
                        column: x => x.DiemTapKetId,
                        principalTable: "DiemTapKets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
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
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppConfigs",
                columns: new[] { "Key", "Value" },
                values: new object[,]
                {
                    { "HomeDescription", "This is description of MagicPost" },
                    { "HomeKeyword", "This is keyword of MagicPost" },
                    { "HomeTitle", "This is home page of MagicPost" }
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), "548ad0ef-8f47-494c-885c-90f7559d89c0", "Lãnh đạo", "LanhDao", "LanhDao" },
                    { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), "9d1e5e9c-4d43-411a-9f05-f3dae9d41e5b", "Nhân viên tập kết", "NhanVienTapKet", "NhanVienTapKet" },
                    { new Guid("8dbdfeba-e424-4e2c-9931-cdde4472daa6"), "34cc5c77-86a8-4f7c-a482-2ee263563fec", "Trưởng điểm giao dịch và tập kết ", "TruongDiem", "TruongDiem" },
                    { new Guid("f98d4249-7ab3-44b6-b074-9c28b018475b"), "2433e77d-d078-49fb-972c-b55285654222", "Giao dịch viên", "GiaoDichVien", "GiaoDichVien" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("8d04dce2-969a-435d-bba4-df3f325983dc") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DiemGiaoDichId", "DiemTapKetId", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), 0, "08890c39-05d1-45c3-abdc-db438f22815f", null, null, new DateTime(2003, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "hieumai09042003@gmail.com", true, "Hao", "Nguyen", false, null, "hieumai09042003@gmail.com", "haonguyen123", "AQAAAAEAACcQAAAAEPsXrwExsj5S3NMAiC5xgOWcvoJbPyp78uzzM3bw7SWuKXsiHi55OkuJZUNY0BHT7Q==", null, false, "", false, "haonguyen123" },
                    { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), 0, "c51ea02b-dcbd-4fc8-b3ce-42683913fbf5", null, null, new DateTime(2003, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "hieumai09042003@gmail.com", true, "Hieu", "Nguyen", false, null, "hieumai09042003@gmail.com", "admin", "AQAAAAEAACcQAAAAELIMquaRxz9osCrTB9adVCfT0B7p2dn6F44/Id4xbUY5U9CcxHGYKH+pi303+en6Hg==", null, false, "", false, "admin" },
                    { new Guid("8dbdfeba-e424-4e2c-9931-cdde4472daa6"), 0, "e271a250-7902-4fff-ab4a-7194a6c964c7", null, null, new DateTime(2003, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "hieumai09042003@gmail.com", true, "Hungnguyen", "Nguyen", false, null, "hieumai09042003@gmail.com", "hungnguyen123", "AQAAAAEAACcQAAAAEDh9oYIAwTO0gsRHxlIBp5iBPyUUIgiuqroGpHkM7WzQTDyC0AQJxJpNX6JiqDg0QQ==", null, false, "", false, "hungnguyen123" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "IsDefault", "Name" },
                values: new object[,]
                {
                    { "en", false, "English" },
                    { "vi", true, "Tiếng Việt" }
                });

            migrationBuilder.InsertData(
                table: "Slides",
                columns: new[] { "Id", "Description", "Image", "Name", "SortOrder", "Status", "Url" },
                values: new object[,]
                {
                    { 1, "Magic Post siêu uy tín, uy tín số 1 Việt Nam", "/themes/images/carousel/1.png", "Magic Post siêu uy tín", 1, 1, "#" },
                    { 2, "Magic Post siêu uy tín, uy tín số 1 Việt Nam", "/themes/images/carousel/2.png", "Magic Post siêu uy tín", 2, 1, "#" },
                    { 3, "Magic Post siêu uy tín, uy tín số 1 Việt Nam", "/themes/images/carousel/3.png", "Magic Post siêu uy tín", 3, 1, "#" },
                    { 4, "Magic Post siêu uy tín, uy tín số 1 Việt Nam", "/themes/images/carousel/4.png", "Magic Post siêu uy tín", 4, 1, "#" },
                    { 5, "Magic Post siêu uy tín, uy tín số 1 Việt Nam", "/themes/images/carousel/5.png", "Magic Post siêu uy tín", 5, 1, "#" },
                    { 6, "Magic Post siêu uy tín, uy tín số 1 Việt Nam", "/themes/images/carousel/6.png", "Magic Post siêu uy tín", 6, 1, "#" }
                });

            migrationBuilder.InsertData(
                table: "DiemTapKets",
                columns: new[] { "Id", "Address", "Name", "UserId" },
                values: new object[] { 1, "Xuan Thuy, Cau Giay, Ha Noi", "Diem Tap Ket 1", new Guid("8d04dce2-969a-435d-bba4-df3f325983dc") });

            migrationBuilder.InsertData(
                table: "DiemTapKets",
                columns: new[] { "Id", "Address", "Name", "UserId" },
                values: new object[] { 2, "De La Thanh, Ba Dinh, Ha Noi", "Diem Tap Ket 2", new Guid("69bd714f-9576-45ba-b5b7-f00649be00de") });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Code", "Cuoc", "KhoiLuong", "OrderDate", "ReceiveAddress", "ReceiveName", "ReceivePhoneNumber", "SendAddress", "SendName", "SendPhoneNumber", "Status", "UserId" },
                values: new object[] { 1, "MAX123", 100000m, 1.2, new DateTime(2023, 12, 9, 22, 14, 25, 880, DateTimeKind.Local).AddTicks(2341), "Xuan Thuy", "Hung", "088965072", "Cau giay", "Hieu", "0827259403", 0, new Guid("8d04dce2-969a-435d-bba4-df3f325983dc") });

            migrationBuilder.InsertData(
                table: "DiemGiaoDichs",
                columns: new[] { "Id", "Address", "DiemTapKetId", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "144 Xuan Thuy, Cau Giay, Ha Noi", 1, "Diem Giao Dich 1.1", new Guid("69bd714f-9576-45ba-b5b7-f00649be00de") },
                    { 2, "36 Xuan Thuy, Cau Giay, Ha Noi", 1, "Diem Giao Dich 1.2", null },
                    { 3, "27 Xuan Thuy, Cau Giay, Ha Noi", 1, "Diem Giao Dich 1.3", null },
                    { 4, "27 De La Thanh, Ba Dinh, Ha Noi", 2, "Diem Giao Dich 2.1", null },
                    { 5, "39 De La Thanh, Ba Dinh, Ha Noi", 2, "Diem Giao Dich 2.2", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_DiemGiaoDichId",
                table: "AppUsers",
                column: "DiemGiaoDichId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_DiemTapKetId",
                table: "AppUsers",
                column: "DiemTapKetId");

            migrationBuilder.CreateIndex(
                name: "IX_DiemGiaoDichs_DiemTapKetId",
                table: "DiemGiaoDichs",
                column: "DiemTapKetId");

            migrationBuilder.CreateIndex(
                name: "IX_DiemGiaoDichs_UserId",
                table: "DiemGiaoDichs",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DiemTapKets_UserId",
                table: "DiemTapKets",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTranslations_LanguageId",
                table: "OrderTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_OrderId",
                table: "ProductImages",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_DiemGiaoDichs_DiemGiaoDichId",
                table: "AppUsers",
                column: "DiemGiaoDichId",
                principalTable: "DiemGiaoDichs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_DiemTapKets_DiemTapKetId",
                table: "AppUsers",
                column: "DiemTapKetId",
                principalTable: "DiemTapKets",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_DiemGiaoDichs_DiemGiaoDichId",
                table: "AppUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_DiemTapKets_DiemTapKetId",
                table: "AppUsers");

            migrationBuilder.DropTable(
                name: "AppConfigs");

            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUserTokens");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "OrderTranslations");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Slides");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "DiemGiaoDichs");

            migrationBuilder.DropTable(
                name: "DiemTapKets");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
