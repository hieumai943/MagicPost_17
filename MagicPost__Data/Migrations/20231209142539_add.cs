using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicPost__Data.Migrations
{
    public partial class add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                column: "ConcurrencyStamp",
                value: "608738ae-675a-49c3-b370-a587b5fa844c");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "310e1a35-4e41-4429-97c8-4a739a8f5d96");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8dbdfeba-e424-4e2c-9931-cdde4472daa6"),
                column: "ConcurrencyStamp",
                value: "6279d754-5c50-44d8-b65e-1b18fc74fceb");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f98d4249-7ab3-44b6-b074-9c28b018475b"),
                column: "ConcurrencyStamp",
                value: "623d13c4-04fb-482e-9680-cb630b01b433");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1ae9ae66-2d59-440e-80cb-2a329a93a06b", "AQAAAAEAACcQAAAAEGRLsgYhbgka2ul3fSOM9FhDcFvCXAGj0O0Hlea+yYaw1Wvz4YfaRGuinnrZo4iPPQ==" });

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
                value: new DateTime(2023, 12, 9, 21, 25, 37, 716, DateTimeKind.Local).AddTicks(2597));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
