using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StepCore.Data.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    DocumentNumber = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    JobPositionsId = table.Column<int>(nullable: false),
                    Department = table.Column<string>(maxLength: 50, nullable: false),
                    SalaryAspiration = table.Column<double>(nullable: false),
                    RecommendedBy = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobPositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    RiskLevel = table.Column<string>(maxLength: 15, nullable: false),
                    SalaryMinLevel = table.Column<double>(nullable: false),
                    SalaryMaxLevel = table.Column<double>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compentencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 400, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ApplicantsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compentencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compentencies_Applicants_ApplicantsId",
                        column: x => x.ApplicantsId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Level = table.Column<string>(maxLength: 100, nullable: false),
                    InitialDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Academy = table.Column<string>(maxLength: 100, nullable: false),
                    ApplicantsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainings_Applicants_ApplicantsId",
                        column: x => x.ApplicantsId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    DocumentNumber = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    DateOfAdmission = table.Column<DateTime>(nullable: false),
                    Department = table.Column<string>(maxLength: 50, nullable: false),
                    JobPositionsId = table.Column<int>(nullable: false),
                    MonthSalary = table.Column<double>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_JobPositions_JobPositionsId",
                        column: x => x.JobPositionsId,
                        principalTable: "JobPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LaborExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Company = table.Column<string>(maxLength: 50, nullable: false),
                    JobPositionsId = table.Column<int>(nullable: false),
                    InitialDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Salary = table.Column<double>(nullable: false),
                    ApplicantsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaborExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaborExperiences_Applicants_ApplicantsId",
                        column: x => x.ApplicantsId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LaborExperiences_JobPositions_JobPositionsId",
                        column: x => x.JobPositionsId,
                        principalTable: "JobPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantsCompentencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    ApplicantsId = table.Column<int>(nullable: false),
                    CompentenciesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantsCompentencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicantsCompentencies_Applicants_ApplicantsId",
                        column: x => x.ApplicantsId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantsCompentencies_Compentencies_CompentenciesId",
                        column: x => x.CompentenciesId,
                        principalTable: "Compentencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantsTrainings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    ApplicantsId = table.Column<int>(nullable: false),
                    TrainingsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantsTrainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicantsTrainings_Applicants_ApplicantsId",
                        column: x => x.ApplicantsId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantsTrainings_Trainings_TrainingsId",
                        column: x => x.TrainingsId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantsLaborExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    ApplicantsId = table.Column<int>(nullable: false),
                    LaborExperiencesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantsLaborExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicantsLaborExperiences_Applicants_ApplicantsId",
                        column: x => x.ApplicantsId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantsLaborExperiences_LaborExperiences_LaborExperiencesId",
                        column: x => x.LaborExperiencesId,
                        principalTable: "LaborExperiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantsCompentencies_ApplicantsId",
                table: "ApplicantsCompentencies",
                column: "ApplicantsId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantsCompentencies_CompentenciesId",
                table: "ApplicantsCompentencies",
                column: "CompentenciesId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantsLaborExperiences_ApplicantsId",
                table: "ApplicantsLaborExperiences",
                column: "ApplicantsId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantsLaborExperiences_LaborExperiencesId",
                table: "ApplicantsLaborExperiences",
                column: "LaborExperiencesId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantsTrainings_ApplicantsId",
                table: "ApplicantsTrainings",
                column: "ApplicantsId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantsTrainings_TrainingsId",
                table: "ApplicantsTrainings",
                column: "TrainingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Compentencies_ApplicantsId",
                table: "Compentencies",
                column: "ApplicantsId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobPositionsId",
                table: "Employees",
                column: "JobPositionsId");

            migrationBuilder.CreateIndex(
                name: "IX_LaborExperiences_ApplicantsId",
                table: "LaborExperiences",
                column: "ApplicantsId");

            migrationBuilder.CreateIndex(
                name: "IX_LaborExperiences_JobPositionsId",
                table: "LaborExperiences",
                column: "JobPositionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_ApplicantsId",
                table: "Trainings",
                column: "ApplicantsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantsCompentencies");

            migrationBuilder.DropTable(
                name: "ApplicantsLaborExperiences");

            migrationBuilder.DropTable(
                name: "ApplicantsTrainings");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Compentencies");

            migrationBuilder.DropTable(
                name: "LaborExperiences");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "JobPositions");

            migrationBuilder.DropTable(
                name: "Applicants");
        }
    }
}
