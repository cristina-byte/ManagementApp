using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrateNewPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OportunityApplicants",
                table: "OportunityApplicants");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OportunityApplicants",
                table: "OportunityApplicants",
                columns: new[] { "UserId", "OportunityId", "PositionId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OportunityApplicants",
                table: "OportunityApplicants");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OportunityApplicants",
                table: "OportunityApplicants",
                columns: new[] { "UserId", "OportunityId" });
        }
    }
}
