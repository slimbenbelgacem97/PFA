using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class InitalModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    AgentCIN = table.Column<short>(type: "INTEGER", nullable: false),
                    Non = table.Column<string>(type: "TEXT", nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", nullable: false),
                    DateEmb = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Adresse = table.Column<string>(type: "TEXT", nullable: false),
                    Salaire = table.Column<double>(type: "REAL", nullable: false),
                    Fonction = table.Column<int>(type: "INTEGER", nullable: false),
                    Immatricule = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.AgentCIN);
                });

            migrationBuilder.CreateTable(
                name: "Candidats",
                columns: table => new
                {
                    CandidatCIN = table.Column<short>(type: "INTEGER", nullable: false),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", nullable: false),
                    Naissance = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Adresse = table.Column<string>(type: "TEXT", nullable: false),
                    Tel = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidats", x => x.CandidatCIN);
                });

            migrationBuilder.CreateTable(
                name: "LoginAgents",
                columns: table => new
                {
                    AgentCIN = table.Column<short>(type: "INTEGER", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginAgents", x => x.AgentCIN);
                    table.ForeignKey(
                        name: "FK_LoginAgents_Agents_AgentCIN",
                        column: x => x.AgentCIN,
                        principalTable: "Agents",
                        principalColumn: "AgentCIN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Immatricule = table.Column<string>(type: "TEXT", nullable: false),
                    Marque = table.Column<string>(type: "TEXT", nullable: false),
                    DateCirculation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AgentCIN = table.Column<short>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Immatricule);
                    table.ForeignKey(
                        name: "FK_Vehicles_Agents_AgentCIN",
                        column: x => x.AgentCIN,
                        principalTable: "Agents",
                        principalColumn: "AgentCIN",
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
                    CandidatCIN = table.Column<short>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Convocation);
                    table.ForeignKey(
                        name: "FK_Exams_Candidats_CandidatCIN",
                        column: x => x.CandidatCIN,
                        principalTable: "Candidats",
                        principalColumn: "CandidatCIN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seances",
                columns: table => new
                {
                    DateSeance = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CandidatCIN = table.Column<short>(type: "INTEGER", nullable: false),
                    AgentCIN = table.Column<short>(type: "INTEGER", nullable: false),
                    SeanceType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seances", x => new { x.DateSeance, x.CandidatCIN, x.AgentCIN });
                    table.ForeignKey(
                        name: "FK_Seances_Agents_AgentCIN",
                        column: x => x.AgentCIN,
                        principalTable: "Agents",
                        principalColumn: "AgentCIN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seances_Candidats_CandidatCIN",
                        column: x => x.CandidatCIN,
                        principalTable: "Candidats",
                        principalColumn: "CandidatCIN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exams_CandidatCIN",
                table: "Exams",
                column: "CandidatCIN");

            migrationBuilder.CreateIndex(
                name: "IX_Seances_AgentCIN",
                table: "Seances",
                column: "AgentCIN");

            migrationBuilder.CreateIndex(
                name: "IX_Seances_CandidatCIN",
                table: "Seances",
                column: "CandidatCIN");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_AgentCIN",
                table: "Vehicles",
                column: "AgentCIN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "LoginAgents");

            migrationBuilder.DropTable(
                name: "Seances");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Candidats");

            migrationBuilder.DropTable(
                name: "Agents");
        }
    }
}
