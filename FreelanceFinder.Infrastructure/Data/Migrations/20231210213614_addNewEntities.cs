using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreelanceFinder.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addNewEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Rating = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    ProjectOffersCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    FinishedProjectsCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    RegistrationDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SkillAreaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_SkillAreas_SkillAreaId",
                        column: x => x.SkillAreaId,
                        principalTable: "SkillAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Freelancers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApprovedProjectsCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    FinishedProjectsCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    RegistrationDate = table.Column<DateTime>(type: "date", nullable: false),
                    Rating = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Freelancers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FreelancerSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    ExperienceInitDate = table.Column<DateTime>(type: "date", nullable: false),
                    FinishedProjectCount = table.Column<int>(type: "int", nullable: false),
                    FreelancerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreelancerSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FreelancerSkills_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FreelancerSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectAdvertisements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployerId = table.Column<int>(type: "int", nullable: false),
                    ExpiredAt = table.Column<DateTime>(type: "date", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    WorkplaceCount = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    FreelancerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectAdvertisements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectAdvertisements_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectAdvertisements_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectAdvertiseId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_ProjectAdvertisements_ProjectAdvertiseId",
                        column: x => x.ProjectAdvertiseId,
                        principalTable: "ProjectAdvertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequiredSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    MonthsOfExperience = table.Column<int>(type: "int", nullable: true),
                    FinishedProjectCount = table.Column<int>(type: "int", nullable: true),
                    ProjectAdvertisementId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequiredSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequiredSkills_ProjectAdvertisements_ProjectAdvertisementId",
                        column: x => x.ProjectAdvertisementId,
                        principalTable: "ProjectAdvertisements",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RequiredSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Freelancers_ProjectId",
                table: "Freelancers",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_FreelancerSkills_FreelancerId",
                table: "FreelancerSkills",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_FreelancerSkills_SkillId",
                table: "FreelancerSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAdvertisements_EmployerId",
                table: "ProjectAdvertisements",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAdvertisements_FreelancerId",
                table: "ProjectAdvertisements",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectAdvertiseId",
                table: "Projects",
                column: "ProjectAdvertiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_StatusId",
                table: "Projects",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RequiredSkills_ProjectAdvertisementId",
                table: "RequiredSkills",
                column: "ProjectAdvertisementId");

            migrationBuilder.CreateIndex(
                name: "IX_RequiredSkills_SkillId",
                table: "RequiredSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SkillAreaId",
                table: "Skills",
                column: "SkillAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Freelancers_Projects_ProjectId",
                table: "Freelancers",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Freelancers_Projects_ProjectId",
                table: "Freelancers");

            migrationBuilder.DropTable(
                name: "FreelancerSkills");

            migrationBuilder.DropTable(
                name: "RequiredSkills");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectAdvertisements");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Employers");

            migrationBuilder.DropTable(
                name: "Freelancers");
        }
    }
}
