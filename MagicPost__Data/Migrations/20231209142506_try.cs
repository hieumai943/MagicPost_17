using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicPost__Data.Migrations
{
    public partial class @try : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiemGiaoDichs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DiemGiaoDichs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DiemGiaoDichs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DiemGiaoDichs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DiemGiaoDichs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DiemTapKets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DiemTapKets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                column: "ConcurrencyStamp",
                value: "46963661-3892-48e5-a022-f70279ce83bc");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "05616071-0066-4fc8-86e5-3249ff9eed35");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8dbdfeba-e424-4e2c-9931-cdde4472daa6"),
                column: "ConcurrencyStamp",
                value: "096981f1-98a7-4d23-af6a-f3d6c4d3bc2e");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f98d4249-7ab3-44b6-b074-9c28b018475b"),
                column: "ConcurrencyStamp",
                value: "eb5d1d76-badd-4b8b-9370-3d4371f11c44");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fb35d7af-eebb-4aca-836b-669af396eb1b", "AQAAAAEAACcQAAAAEHdsnWG9QQM0wmibhqCL2ng/a+hhS9ShxhIFSa6is7Sgjxg9cnYMJ4BxxAPV6oflGA==" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 12, 9, 21, 25, 5, 342, DateTimeKind.Local).AddTicks(5705));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                column: "ConcurrencyStamp",
                value: "db6f0daa-c07b-4e7f-9211-e088c7dd6e0d");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "a083c1c4-afe0-47f7-a9aa-0854703a4bea");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8dbdfeba-e424-4e2c-9931-cdde4472daa6"),
                column: "ConcurrencyStamp",
                value: "e40c990d-6d60-40f5-b72d-1aa2cbb5756a");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f98d4249-7ab3-44b6-b074-9c28b018475b"),
                column: "ConcurrencyStamp",
                value: "23bdc0cf-7d7b-40e7-add8-fe2e312f6908");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "06b673b7-6bb4-4558-8502-d4c6f958278c", "AQAAAAEAACcQAAAAEESBStYU69S+dMcCgi3LneaZxYtIr6CQ8PfPmPGNdc2Cv9kNXWLhcLGkmgyoD+n9tw==" });

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
                value: new DateTime(2023, 12, 9, 21, 15, 56, 653, DateTimeKind.Local).AddTicks(8696));

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
        }
    }
}
