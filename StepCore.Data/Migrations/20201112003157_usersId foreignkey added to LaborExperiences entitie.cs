using Microsoft.EntityFrameworkCore.Migrations;

namespace StepCore.Data.Migrations
{
    public partial class usersIdforeignkeyaddedtoLaborExperiencesentitie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaborExperiences_Users_UsersId",
                table: "LaborExperiences");

            migrationBuilder.DropIndex(
                name: "IX_LaborExperiences_UsersId",
                table: "LaborExperiences");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "LaborExperiences");

            migrationBuilder.CreateIndex(
                name: "IX_LaborExperiences_UserId",
                table: "LaborExperiences",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LaborExperiences_Users_UserId",
                table: "LaborExperiences",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaborExperiences_Users_UserId",
                table: "LaborExperiences");

            migrationBuilder.DropIndex(
                name: "IX_LaborExperiences_UserId",
                table: "LaborExperiences");

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "LaborExperiences",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LaborExperiences_UsersId",
                table: "LaborExperiences",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_LaborExperiences_Users_UsersId",
                table: "LaborExperiences",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
