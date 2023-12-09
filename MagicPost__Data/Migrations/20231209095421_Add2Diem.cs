using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicPost__Data.Migrations
{
    public partial class Add2Diem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiemGiaoDichId",
                table: "AppUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiemTapKetId",
                table: "AppUsers",
                type: "int",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                column: "ConcurrencyStamp",
                value: "9a6f3f4e-6064-4e66-be2a-8a332e9a87c1");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "4fdd5113-08e9-4b3d-a6b1-df9d398c8b6d");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8dbdfeba-e424-4e2c-9931-cdde4472daa6"),
                column: "ConcurrencyStamp",
                value: "eb41ef76-cd3f-4ee1-8aea-9647c001e8d1");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f98d4249-7ab3-44b6-b074-9c28b018475b"),
                column: "ConcurrencyStamp",
                value: "83f76a88-d584-4f0e-8d2d-862856e105b0");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6692079c-9675-4d29-9f16-2a1ad9391597", "AQAAAAEAACcQAAAAEFh94DGFfndst13GtWAJLtMxRPCSMQrOSduQVEglIJEOqawDEO3yW4EgQzCIYGCUGA==" });

            migrationBuilder.InsertData(
                table: "DiemTapKets",
                columns: new[] { "Id", "Address", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "Xuan Thuy, Cau Giay, Ha Noi", "Diem Tap Ket 1", new Guid("7dba6422-7136-4d8d-488c-08dbf31d70c7") },
                    { 2, "De La Thanh, Ba Dinh, Ha Noi", "Diem Tap Ket 2", new Guid("d756ad9c-bd14-4e57-88f2-08dbf52dd1ef") }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 12, 9, 16, 54, 19, 642, DateTimeKind.Local).AddTicks(7695));

            migrationBuilder.InsertData(
                table: "DiemGiaoDichs",
                columns: new[] { "Id", "Address", "DiemTapKetId", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "144 Xuan Thuy, Cau Giay, Ha Noi", 1, "Diem Giao Dich 1.1", new Guid("7dba6422-7136-4d8d-488c-08dbf31d70c7") },
                    { 2, "36 Xuan Thuy, Cau Giay, Ha Noi", 1, "Diem Giao Dich 1.2", new Guid("d756ad9c-bd14-4e57-88f2-08dbf52dd1ef") },
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
                name: "DiemGiaoDichs");

            migrationBuilder.DropTable(
                name: "DiemTapKets");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_DiemGiaoDichId",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_DiemTapKetId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "DiemGiaoDichId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "DiemTapKetId",
                table: "AppUsers");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                column: "ConcurrencyStamp",
                value: "828c0e6d-d034-413a-afb3-15685153a5d5");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "55e91905-681e-4ec9-a455-7622315293c7");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8dbdfeba-e424-4e2c-9931-cdde4472daa6"),
                column: "ConcurrencyStamp",
                value: "48609084-672f-4628-9f99-343eda82a8b4");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f98d4249-7ab3-44b6-b074-9c28b018475b"),
                column: "ConcurrencyStamp",
                value: "5bbf16b5-047f-4e92-abf7-d259aa2c88be");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "704cd6bb-9034-424a-8b36-535f3d7e98e9", "AQAAAAEAACcQAAAAEMg9EUK0OMJD3lR1umx2Ci5AxFfEHaDiv7JHizdDPmDIiqF7leEV45/vV+zUlZRwkA==" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 12, 7, 23, 17, 5, 63, DateTimeKind.Local).AddTicks(2979));
        }
    }
}
