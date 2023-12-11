using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicPost__Data.Migrations
{
    public partial class ADD_DTKOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiemGiaoDichId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiemTapKetId",
                table: "Orders",
                type: "int",
                nullable: true);

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2a585c6a-7171-4ceb-bbbd-0250e7469f64", "AQAAAAEAACcQAAAAEBQc0Hqkg822FOZ1cPpN+mRUUalXWosOtp1y896vEN7tEu76iaHEAHJ9hoDeZDYzSw==" });

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
                columns: new[] { "DiemGiaoDichId", "OrderDate" },
                values: new object[] { 1, new DateTime(2023, 12, 12, 0, 14, 46, 653, DateTimeKind.Local).AddTicks(3575) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DiemTapKetId", "OrderDate" },
                values: new object[] { 1, new DateTime(2023, 12, 12, 0, 14, 46, 653, DateTimeKind.Local).AddTicks(3595) });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DiemGiaoDichId",
                table: "Orders",
                column: "DiemGiaoDichId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DiemTapKetId",
                table: "Orders",
                column: "DiemTapKetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DiemGiaoDichs_DiemGiaoDichId",
                table: "Orders",
                column: "DiemGiaoDichId",
                principalTable: "DiemGiaoDichs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DiemTapKets_DiemTapKetId",
                table: "Orders",
                column: "DiemTapKetId",
                principalTable: "DiemTapKets",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DiemGiaoDichs_DiemGiaoDichId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DiemTapKets_DiemTapKetId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DiemGiaoDichId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DiemTapKetId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DiemGiaoDichId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DiemTapKetId",
                table: "Orders");

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

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 12, 11, 0, 27, 8, 61, DateTimeKind.Local).AddTicks(7697));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 12, 11, 0, 27, 8, 61, DateTimeKind.Local).AddTicks(7700));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 12, 11, 0, 27, 8, 61, DateTimeKind.Local).AddTicks(7541));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 12, 11, 0, 27, 8, 61, DateTimeKind.Local).AddTicks(7558));
        }
    }
}
