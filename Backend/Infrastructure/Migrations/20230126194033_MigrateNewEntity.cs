using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrateNewEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OportunityApplicant",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OportunityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OportunityApplicant", x => new { x.UserId, x.OportunityId });
                    table.ForeignKey(
                        name: "FK_OportunityApplicant_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OportunityApplicant_Oportunities_OportunityId",
                        column: x => x.OportunityId,
                        principalTable: "Oportunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OportunityApplicant_OportunityId",
                table: "OportunityApplicant",
                column: "OportunityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OportunityApplicant");
        }
    }
}
