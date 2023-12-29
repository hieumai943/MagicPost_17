using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicPost__Data.Migrations
{
    public partial class Add_log : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LogId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LogId1",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiemGiaoDichFromId = table.Column<int>(type: "int", nullable: true),
                    DiemTapKetFromId = table.Column<int>(type: "int", nullable: true),
                    DiemGiaoDichToId = table.Column<int>(type: "int", nullable: true),
                    DiemTapKetToId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_DiemGiaoDichs_DiemGiaoDichFromId",
                        column: x => x.DiemGiaoDichFromId,
                        principalTable: "DiemGiaoDichs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_DiemGiaoDichs_DiemGiaoDichToId",
                        column: x => x.DiemGiaoDichToId,
                        principalTable: "DiemGiaoDichs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_DiemTapKets_DiemTapKetFromId",
                        column: x => x.DiemTapKetFromId,
                        principalTable: "DiemTapKets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_DiemTapKets_DiemTapKetToId",
                        column: x => x.DiemTapKetToId,
                        principalTable: "DiemTapKets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                column: "ConcurrencyStamp",
                value: "b307401f-d3d9-46b4-9fd3-b2fdbe6f0497");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "74a46c60-ac75-4e4b-94ed-3a5b17cef007");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8dbdfeba-e424-4e2c-9931-cdde4472daa6"),
                column: "ConcurrencyStamp",
                value: "79a3fdfd-48a9-4039-9aee-3a7c84f44139");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f98d4249-7ab3-44b6-b074-9c28b018475b"),
                column: "ConcurrencyStamp",
                value: "4804df45-a27c-473a-a214-c78a0cc33fa5");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "990a41a6-e67f-4a87-bd9f-5986a1d398c7", "AQAAAAEAACcQAAAAEEBktBDKyXvzSRezdEixNv/rjqNbgrhG+ISy3RZ119H10/tlKmIrkq8BvEHiGFSLVA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7a4cbc13-8372-4b49-be76-0197798d3bb5", "AQAAAAEAACcQAAAAEFtK5qePoVaT+AgQLK6xoDFpLKDrFbO+G96VJvKyI93iPlM4rKpjDn1TdlclZmY7lw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("8dbdfeba-e424-4e2c-9931-cdde4472daa6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "10f95126-0916-45f9-8bc7-c7e9ee124803", "AQAAAAEAACcQAAAAEKSzLOAPyPgGnjBPm5eAcZuvJdxqRs+ghoH7evdBG5TRhsdRpL0khB9CLo/HpXTskg==" });

            migrationBuilder.InsertData(
                table: "Logs",
                columns: new[] { "Id", "DateCreated", "DiemGiaoDichFromId", "DiemGiaoDichToId", "DiemTapKetFromId", "DiemTapKetToId", "OrderId", "OrderStatus" },
                values: new object[] { 1, new DateTime(2023, 12, 11, 0, 27, 8, 61, DateTimeKind.Local).AddTicks(7697), 1, null, null, 1, 1, 0 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LogId", "OrderDate" },
                values: new object[] { 1, new DateTime(2023, 12, 11, 0, 27, 8, 61, DateTimeKind.Local).AddTicks(7541) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Code", "Cuoc", "KhoiLuong", "LogId", "LogId1", "OrderDate", "ReceiveAddress", "ReceiveName", "ReceivePhoneNumber", "SendAddress", "SendName", "SendPhoneNumber", "Status", "UserId" },
                values: new object[] { 2, "MAX123456", 100000m, 1.2, 2, null, new DateTime(2023, 12, 11, 0, 27, 8, 61, DateTimeKind.Local).AddTicks(7558), "Xuan Thuy", "Hao", "0889650723", "Cau giay", "Hieu", "08272594033", 0, new Guid("8d04dce2-969a-435d-bba4-df3f325983dc") });

            migrationBuilder.InsertData(
                table: "Logs",
                columns: new[] { "Id", "DateCreated", "DiemGiaoDichFromId", "DiemGiaoDichToId", "DiemTapKetFromId", "DiemTapKetToId", "OrderId", "OrderStatus" },
                values: new object[] { 2, new DateTime(2023, 12, 11, 0, 27, 8, 61, DateTimeKind.Local).AddTicks(7700), 2, null, null, 2, 2, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LogId1",
                table: "Orders",
                column: "LogId1");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_DiemGiaoDichFromId",
                table: "Logs",
                column: "DiemGiaoDichFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_DiemGiaoDichToId",
                table: "Logs",
                column: "DiemGiaoDichToId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_DiemTapKetFromId",
                table: "Logs",
                column: "DiemTapKetFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_DiemTapKetToId",
                table: "Logs",
                column: "DiemTapKetToId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_OrderId",
                table: "Logs",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Logs_LogId1",
                table: "Orders",
                column: "LogId1",
                principalTable: "Logs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Logs_LogId1",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Orders_LogId1",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "LogId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LogId1",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                column: "ConcurrencyStamp",
                value: "548ad0ef-8f47-494c-885c-90f7559d89c0");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "9d1e5e9c-4d43-411a-9f05-f3dae9d41e5b");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8dbdfeba-e424-4e2c-9931-cdde4472daa6"),
                column: "ConcurrencyStamp",
                value: "34cc5c77-86a8-4f7c-a482-2ee263563fec");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f98d4249-7ab3-44b6-b074-9c28b018475b"),
                column: "ConcurrencyStamp",
                value: "2433e77d-d078-49fb-972c-b55285654222");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "08890c39-05d1-45c3-abdc-db438f22815f", "AQAAAAEAACcQAAAAEPsXrwExsj5S3NMAiC5xgOWcvoJbPyp78uzzM3bw7SWuKXsiHi55OkuJZUNY0BHT7Q==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c51ea02b-dcbd-4fc8-b3ce-42683913fbf5", "AQAAAAEAACcQAAAAELIMquaRxz9osCrTB9adVCfT0B7p2dn6F44/Id4xbUY5U9CcxHGYKH+pi303+en6Hg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("8dbdfeba-e424-4e2c-9931-cdde4472daa6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e271a250-7902-4fff-ab4a-7194a6c964c7", "AQAAAAEAACcQAAAAEDh9oYIAwTO0gsRHxlIBp5iBPyUUIgiuqroGpHkM7WzQTDyC0AQJxJpNX6JiqDg0QQ==" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 12, 9, 22, 14, 25, 880, DateTimeKind.Local).AddTicks(2341));
        }
    }
}
