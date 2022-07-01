using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieAPI.Migrations
{
    public partial class updateondeletetype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Theaters_Managers_ManagerId",
                table: "Theaters");

            migrationBuilder.AddForeignKey(
                name: "FK_Theaters_Managers_ManagerId",
                table: "Theaters",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Theaters_Managers_ManagerId",
                table: "Theaters");

            migrationBuilder.AddForeignKey(
                name: "FK_Theaters_Managers_ManagerId",
                table: "Theaters",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
