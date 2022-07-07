using Microsoft.EntityFrameworkCore.Migrations;

namespace UserAPI.Migrations
{
    public partial class useradmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99999, "6b58ac89-9137-4fab-94c8-6af62bf7bcdd", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 99999, 0, "c92830eb-2c54-465d-b409-9c6cbe934d34", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEByCYYJHV6EM/y8NCwtR8UbShAGbx1x+POTCzh2NcLt5LDVKg3+3vCO7O9Y+rBkU9A==", null, false, "8495eee8-27b5-489b-9bb5-886a5c17debc", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 99999, 99999 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 99999, 99999 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999);
        }
    }
}
