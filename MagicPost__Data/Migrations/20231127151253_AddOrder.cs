using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicPost__Data.Migrations
{
    public partial class AddOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "ProductImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "491d810e-fcd3-4e01-8cd4-684ad2ffd77c");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7ac74355-c550-472d-88ef-514f8fa90dcb", "AQAAAAEAACcQAAAAEEVhpRgkaI05wvmMtQry7s70Ufk4J0FLNAxjF4hye54IbSM/3Mge/wFaRDxHOrVhIA==" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Code", "Cuoc", "KhoiLuong", "OrderDate", "ReceiveAddress", "ReceiveName", "ReceivePhoneNumber", "SendAddress", "SendName", "SendPhoneNumber", "Status", "UserId" },
                values: new object[] { 1, "MAX123", 100000m, 1.2, new DateTime(2023, 11, 27, 22, 12, 52, 556, DateTimeKind.Local).AddTicks(4026), "Xuan Thuy", "Hung", "088965072", "Cau giay", "Hieu", "0827259403", 0, new Guid("69bd714f-9576-45ba-b5b7-f00649be00de") });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_OrderId",
                table: "ProductImages",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Orders_OrderId",
                table: "ProductImages",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Orders_OrderId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_OrderId",
                table: "ProductImages");

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "ProductImages");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "d5add88e-4ff9-4f5f-bc5c-6584b50ee9fa");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2e19d08e-9071-48af-a0c5-861c0b8997a4", "AQAAAAEAACcQAAAAEG55t0zLpN9m/rpsrwRMXGhGFa1dCSoiA5NhIAyYR1wEN1GtN4jd0Fo/av/jx3JC2Q==" });
        }
    }
}
