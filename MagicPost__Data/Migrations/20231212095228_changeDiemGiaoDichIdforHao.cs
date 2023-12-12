using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicPost__Data.Migrations
{
    public partial class changeDiemGiaoDichIdforHao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_DiemTapKets_DiemTapKetId",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_DiemTapKetId",
                table: "AppUsers");

            migrationBuilder.AddColumn<int>(
                name: "DiemTapKetId1",
                table: "AppUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                column: "ConcurrencyStamp",
                value: "9b025587-ccec-4be2-9836-c9693dcf9155");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "bba99012-1458-4cad-998c-1375ae576f98");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8dbdfeba-e424-4e2c-9931-cdde4472daa6"),
                column: "ConcurrencyStamp",
                value: "7b5e84fe-4ef5-4a9e-a099-78f8db82728e");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f98d4249-7ab3-44b6-b074-9c28b018475b"),
                column: "ConcurrencyStamp",
                value: "c7e203aa-8dbc-46aa-84fa-5df73d9dbced");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "DiemGiaoDichId", "PasswordHash" },
                values: new object[] { "f2f620f8-f524-4886-9be6-601f1d2e0bd7", 1, "AQAAAAEAACcQAAAAEJvttegrp3qH/jMpz6HrlqX8osYz1hiZ4nMf3SHpEne3vIc2Sd1v/al9su9Nr7sOiw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2edb643f-f389-4e85-9246-9f7d3444f253", "AQAAAAEAACcQAAAAEOFm9GJGtOpOG3akTzuAI70/O4at9jXsmuHW+zFeLC8ucsHv5R17gjBgUwHCd57ieQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("8dbdfeba-e424-4e2c-9931-cdde4472daa6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c5493561-c308-4529-8535-eaeb313d547f", "AQAAAAEAACcQAAAAEK3SjaVZQjnM4Bopz8ggFOovELqbwqUoGBgnVpZADbGqxQB7MllW+QxvyvVrT9AOmg==" });

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 12, 12, 16, 52, 27, 244, DateTimeKind.Local).AddTicks(2833));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 12, 12, 16, 52, 27, 244, DateTimeKind.Local).AddTicks(2835));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 12, 12, 16, 52, 27, 244, DateTimeKind.Local).AddTicks(2682));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 12, 12, 16, 52, 27, 244, DateTimeKind.Local).AddTicks(2706));

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_DiemTapKetId1",
                table: "AppUsers",
                column: "DiemTapKetId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_DiemTapKets_DiemTapKetId1",
                table: "AppUsers",
                column: "DiemTapKetId1",
                principalTable: "DiemTapKets",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_DiemTapKets_DiemTapKetId1",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_DiemTapKetId1",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "DiemTapKetId1",
                table: "AppUsers");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                column: "ConcurrencyStamp",
                value: "3c8510cb-13b3-41a7-8a2b-5169b96bf13d");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "653bea68-c0dd-4e13-8819-e920dea7f20c");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8dbdfeba-e424-4e2c-9931-cdde4472daa6"),
                column: "ConcurrencyStamp",
                value: "762d3678-8c84-4b81-a7e6-93ec416eeb55");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f98d4249-7ab3-44b6-b074-9c28b018475b"),
                column: "ConcurrencyStamp",
                value: "efffc7cb-20a2-4f4f-a3ab-d991ea88d868");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "DiemGiaoDichId", "PasswordHash" },
                values: new object[] { "2a585c6a-7171-4ceb-bbbd-0250e7469f64", null, "AQAAAAEAACcQAAAAEBQc0Hqkg822FOZ1cPpN+mRUUalXWosOtp1y896vEN7tEu76iaHEAHJ9hoDeZDYzSw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2104e0ca-5fb6-4eae-a61e-dde887040d0f", "AQAAAAEAACcQAAAAEL20HPbZAiTf4rLEHrZx3PXIzQD6cyM72c4C5kqowjltjGI1QkaDK/WPnvHMBEpAuQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("8dbdfeba-e424-4e2c-9931-cdde4472daa6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f89836e5-43b3-4530-aa8f-696b47fe60d9", "AQAAAAEAACcQAAAAECyPPYpnnHlTQKvb8OXJSxfqPWSePid711ruGqNA7et/h+poLEo3383MVoFJ3u9iDg==" });

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 12, 12, 0, 14, 46, 653, DateTimeKind.Local).AddTicks(3701));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 12, 12, 0, 14, 46, 653, DateTimeKind.Local).AddTicks(3703));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 12, 12, 0, 14, 46, 653, DateTimeKind.Local).AddTicks(3575));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 12, 12, 0, 14, 46, 653, DateTimeKind.Local).AddTicks(3595));

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_DiemTapKetId",
                table: "AppUsers",
                column: "DiemTapKetId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_DiemTapKets_DiemTapKetId",
                table: "AppUsers",
                column: "DiemTapKetId",
                principalTable: "DiemTapKets",
                principalColumn: "Id");
        }
    }
}
