using Microsoft.EntityFrameworkCore.Migrations;

namespace StepCore.Data.Migrations
{
    public partial class RemoveUsersFKonRoleEntite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_UsersId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_UsersId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Roles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UsersId",
                table: "Roles",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_UsersId",
                table: "Roles",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
