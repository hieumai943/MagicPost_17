using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicPost__Data.Migrations
{
    public partial class addMoreRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("69bd714f-9576-45ba-b5b7-f00649be00de") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                columns: new[] { "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "4920ff46-118d-41f3-9bed-b1f180e44e6b", "Nhân viên tập kết", "NhanVienTapKet", "NhanVienTapKet" });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), "c29b807a-2bd6-4cf1-9089-079a26ccaa6d", "Lãnh đạo", "LanhDao", "LanhDao" },
                    { new Guid("8dbdfeba-e424-4e2c-9931-cdde4472daa6"), "0c69d83c-b3f9-4d27-9c82-d02497b86cb1", "Trưởng điểm giao dịch và tập kết ", "TruongDiem", "TruongDiem" },
                    { new Guid("f98d4249-7ab3-44b6-b074-9c28b018475b"), "275e6d82-ddf6-433e-940d-db1e6af960f2", "Giao dịch viên", "GiaoDichVien", "GiaoDichVien" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("8d04dce2-969a-435d-bba4-df3f325983dc") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), 0, "b90b5fd5-3a20-4fbb-9535-005c842afe18", new DateTime(2003, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "hieumai09042003@gmail.com", true, "Hieu", "Nguyen", false, null, "hieumai09042003@gmail.com", "NhanVienTapKet", "AQAAAAEAACcQAAAAEA5zwnuK1FVSCEcEJnPhWUBxCCv7PJa9+R7dBRroCMFmAa6PBzRF497wF74wsa2R4g==", null, false, "", false, "NhanVienTapKet" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "OrderDate", "UserId" },
                values: new object[] { new DateTime(2023, 12, 6, 22, 45, 53, 28, DateTimeKind.Local).AddTicks(5916), new Guid("8d04dce2-969a-435d-bba4-df3f325983dc") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8dbdfeba-e424-4e2c-9931-cdde4472daa6"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("f98d4249-7ab3-44b6-b074-9c28b018475b"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("8d04dce2-969a-435d-bba4-df3f325983dc") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                columns: new[] { "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "491d810e-fcd3-4e01-8cd4-684ad2ffd77c", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("69bd714f-9576-45ba-b5b7-f00649be00de") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), 0, "7ac74355-c550-472d-88ef-514f8fa90dcb", new DateTime(2003, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "hieumai09042003@gmail.com", true, "Hieu", "Nguyen", false, null, "hieumai09042003@gmail.com", "admin", "AQAAAAEAACcQAAAAEEVhpRgkaI05wvmMtQry7s70Ufk4J0FLNAxjF4hye54IbSM/3Mge/wFaRDxHOrVhIA==", null, false, "", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "OrderDate", "UserId" },
                values: new object[] { new DateTime(2023, 11, 27, 22, 12, 52, 556, DateTimeKind.Local).AddTicks(4026), new Guid("69bd714f-9576-45ba-b5b7-f00649be00de") });
        }
    }
}
