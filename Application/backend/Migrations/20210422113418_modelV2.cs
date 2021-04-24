using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class modelV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    AgentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", nullable: false),
                    DateEmb = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Adresse = table.Column<string>(type: "TEXT", nullable: false),
                    Salaire = table.Column<double>(type: "REAL", nullable: false),
                    Fonction = table.Column<short>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.AgentId);
                });

            migrationBuilder.CreateTable(
                name: "LoginAgents",
                columns: table => new
                {
                    AgentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Password = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginAgents", x => x.AgentId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicules",
                columns: table => new
                {
                    Immatricule = table.Column<string>(type: "TEXT", nullable: false),
                    Marque = table.Column<string>(type: "TEXT", nullable: true),
                    DateCirculation = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicules", x => x.Immatricule);
                });

            migrationBuilder.CreateTable(
                name: "Agents_Vehicules",
                columns: table => new
                {
                    AgentId = table.Column<int>(type: "INTEGER", nullable: false),
                    Immatricule = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents_Vehicules", x => new { x.AgentId, x.Immatricule });
                    table.ForeignKey(
                        name: "FK_Agents_Vehicules_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "AgentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agents_Vehicules_Vehicules_Immatricule",
                        column: x => x.Immatricule,
                        principalTable: "Vehicules",
                        principalColumn: "Immatricule",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seances",
                columns: table => new
                {
                    DateSeance = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CandidatCIN = table.Column<int>(type: "INTEGER", nullable: false),
                    AgentId = table.Column<int>(type: "INTEGER", nullable: false),
                    SeanceType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seances", x => new { x.AgentId, x.CandidatCIN, x.DateSeance });
                    table.ForeignKey(
                        name: "FK_Seances_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "AgentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Convocation = table.Column<string>(type: "TEXT", nullable: false),
                    List = table.Column<string>(type: "TEXT", nullable: false),
                    DateExam = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    CandidatCIN = table.Column<int>(type: "INTEGER", nullable: false),
                    CandidatCIN1 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Convocation);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    CandidatCIN = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", nullable: false),
                    Naissance = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Adresse = table.Column<string>(type: "TEXT", nullable: false),
                    Tel = table.Column<string>(type: "TEXT", nullable: false),
                    ExamConvocation = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.CandidatCIN);
                    table.ForeignKey(
                        name: "FK_Candidates_Exams_ExamConvocation",
                        column: x => x.ExamConvocation,
                        principalTable: "Exams",
                        principalColumn: "Convocation",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_Vehicules_Immatricule",
                table: "Agents_Vehicules",
                column: "Immatricule");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_ExamConvocation",
                table: "Candidates",
                column: "ExamConvocation");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_CandidatCIN1",
                table: "Exams",
                column: "CandidatCIN1");

            migrationBuilder.CreateIndex(
                name: "IX_Seances_CandidatCIN",
                table: "Seances",
                column: "CandidatCIN");

            migrationBuilder.AddForeignKey(
                name: "FK_Seances_Candidates_CandidatCIN",
                table: "Seances",
                column: "CandidatCIN",
                principalTable: "Candidates",
                principalColumn: "CandidatCIN",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Candidates_CandidatCIN1",
                table: "Exams",
                column: "CandidatCIN1",
                principalTable: "Candidates",
                principalColumn: "CandidatCIN",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Exams_ExamConvocation",
                table: "Candidates");

            migrationBuilder.DropTable(
                name: "Agents_Vehicules");

            migrationBuilder.DropTable(
                name: "LoginAgents");

            migrationBuilder.DropTable(
                name: "Seances");

            migrationBuilder.DropTable(
                name: "Vehicules");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Candidates");
        }
    }
}
