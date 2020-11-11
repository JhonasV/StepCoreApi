using Microsoft.EntityFrameworkCore.Migrations;

namespace StepCore.Data.Migrations
{
    public partial class LaborExperiencejobPositionIdremovedandUserIdadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaborExperiences_JobPositions_JobPositionsId",
                table: "LaborExperiences");

            migrationBuilder.DropIndex(
                name: "IX_LaborExperiences_JobPositionsId",
                table: "LaborExperiences");

            migrationBuilder.DropColumn(
                name: "JobPositionsId",
                table: "LaborExperiences");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "LaborExperiences",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "LaborExperiences",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaborExperiences_Users_UsersId",
                table: "LaborExperiences");

            migrationBuilder.DropIndex(
                name: "IX_LaborExperiences_UsersId",
                table: "LaborExperiences");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "LaborExperiences");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "LaborExperiences");

            migrationBuilder.AddColumn<int>(
                name: "JobPositionsId",
                table: "LaborExperiences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LaborExperiences_JobPositionsId",
                table: "LaborExperiences",
                column: "JobPositionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_LaborExperiences_JobPositions_JobPositionsId",
                table: "LaborExperiences",
                column: "JobPositionsId",
                principalTable: "JobPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
