using Microsoft.EntityFrameworkCore.Migrations;

namespace UserAPI.Migrations
{
    public partial class creatingregularrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "ef3e890b-4203-466d-80c9-56cffa6893ba");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99997, "88ecd171-1a37-4e3d-a68d-26920cf2a310", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2ab488e-43e1-4c8c-9d5c-31f9472da0d9", "AQAAAAEAACcQAAAAEKHrb8KLE40LoRBJOOvh6Kbva39Tcfy8aHCPS7TmcUwOQLLwS1afmXxYkENUxWE23Q==", "66794037-6769-4214-b3ca-149fa36633a0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "6b58ac89-9137-4fab-94c8-6af62bf7bcdd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c92830eb-2c54-465d-b409-9c6cbe934d34", "AQAAAAEAACcQAAAAEByCYYJHV6EM/y8NCwtR8UbShAGbx1x+POTCzh2NcLt5LDVKg3+3vCO7O9Y+rBkU9A==", "8495eee8-27b5-489b-9bb5-886a5c17debc" });
        }
    }
}
