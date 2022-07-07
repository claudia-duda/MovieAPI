using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserAPI.Migrations
{
    public partial class Addcustomidentityuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "b2337ee0-bf12-4d57-b897-94278f49839f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "eee8547e-b837-4d6e-aba5-d3a7d38d944f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da75f2fd-2d2e-4197-b353-b3c310ada7cd", "AQAAAAEAACcQAAAAEEwNzfqzkqVs0UjdjVNfQGxdVpFuFBJevVt2ZBa+VDM3VprhP7HKxEwDZkd8z9zL/g==", "8f23e83a-b6d0-4fea-ba86-84de6d06478f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "88ecd171-1a37-4e3d-a68d-26920cf2a310");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "ef3e890b-4203-466d-80c9-56cffa6893ba");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2ab488e-43e1-4c8c-9d5c-31f9472da0d9", "AQAAAAEAACcQAAAAEKHrb8KLE40LoRBJOOvh6Kbva39Tcfy8aHCPS7TmcUwOQLLwS1afmXxYkENUxWE23Q==", "66794037-6769-4214-b3ca-149fa36633a0" });
        }
    }
}
