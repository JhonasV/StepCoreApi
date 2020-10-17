using Microsoft.EntityFrameworkCore.Migrations;

namespace StepCore.Data.Migrations
{
    public partial class IsPrincipalpropertyaddedtoApplicantsLaborExpCompentenciesandTrainings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPrincipal",
                table: "ApplicantsTrainings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrincipal",
                table: "ApplicantsLaborExperiences",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrincipal",
                table: "ApplicantsCompentencies",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPrincipal",
                table: "ApplicantsTrainings");

            migrationBuilder.DropColumn(
                name: "IsPrincipal",
                table: "ApplicantsLaborExperiences");

            migrationBuilder.DropColumn(
                name: "IsPrincipal",
                table: "ApplicantsCompentencies");
        }
    }
}
