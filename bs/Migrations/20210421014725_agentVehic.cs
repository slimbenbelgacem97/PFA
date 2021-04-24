using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class agentVehic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Agents_AgentCIN",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_AgentCIN",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "AgentCIN",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Immatricule",
                table: "Agents");

            migrationBuilder.CreateTable(
                name: "Agents_Vehiciles",
                columns: table => new
                {
                    AgentCIN = table.Column<int>(type: "INTEGER", nullable: false),
                    Immatricule = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents_Vehiciles", x => new { x.AgentCIN, x.Immatricule });
                    table.ForeignKey(
                        name: "FK_Agents_Vehiciles_Agents_AgentCIN",
                        column: x => x.AgentCIN,
                        principalTable: "Agents",
                        principalColumn: "AgentCIN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agents_Vehiciles_Vehicles_Immatricule",
                        column: x => x.Immatricule,
                        principalTable: "Vehicles",
                        principalColumn: "Immatricule",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_Vehiciles_Immatricule",
                table: "Agents_Vehiciles",
                column: "Immatricule");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agents_Vehiciles");

            migrationBuilder.AddColumn<int>(
                name: "AgentCIN",
                table: "Vehicles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Immatricule",
                table: "Agents",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_AgentCIN",
                table: "Vehicles",
                column: "AgentCIN",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Agents_AgentCIN",
                table: "Vehicles",
                column: "AgentCIN",
                principalTable: "Agents",
                principalColumn: "AgentCIN",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
