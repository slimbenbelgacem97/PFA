using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vehicles_AgentCIN",
                table: "Vehicles");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_AgentCIN",
                table: "Vehicles",
                column: "AgentCIN",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vehicles_AgentCIN",
                table: "Vehicles");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_AgentCIN",
                table: "Vehicles",
                column: "AgentCIN");
        }
    }
}
