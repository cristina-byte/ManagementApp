using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrateNewField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OportunityApplicant_AspNetUsers_UserId",
                table: "OportunityApplicant");

            migrationBuilder.DropForeignKey(
                name: "FK_OportunityApplicant_Oportunities_OportunityId",
                table: "OportunityApplicant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OportunityApplicant",
                table: "OportunityApplicant");

            migrationBuilder.RenameTable(
                name: "OportunityApplicant",
                newName: "OportunityApplicants");

            migrationBuilder.RenameIndex(
                name: "IX_OportunityApplicant_OportunityId",
                table: "OportunityApplicants",
                newName: "IX_OportunityApplicants_OportunityId");

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "OportunityApplicants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OportunityApplicants",
                table: "OportunityApplicants",
                columns: new[] { "UserId", "OportunityId" });

            migrationBuilder.CreateIndex(
                name: "IX_OportunityApplicants_PositionId",
                table: "OportunityApplicants",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_OportunityApplicants_AspNetUsers_UserId",
                table: "OportunityApplicants",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OportunityApplicants_Oportunities_OportunityId",
                table: "OportunityApplicants",
                column: "OportunityId",
                principalTable: "Oportunities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OportunityApplicants_Positions_PositionId",
                table: "OportunityApplicants",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OportunityApplicants_AspNetUsers_UserId",
                table: "OportunityApplicants");

            migrationBuilder.DropForeignKey(
                name: "FK_OportunityApplicants_Oportunities_OportunityId",
                table: "OportunityApplicants");

            migrationBuilder.DropForeignKey(
                name: "FK_OportunityApplicants_Positions_PositionId",
                table: "OportunityApplicants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OportunityApplicants",
                table: "OportunityApplicants");

            migrationBuilder.DropIndex(
                name: "IX_OportunityApplicants_PositionId",
                table: "OportunityApplicants");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "OportunityApplicants");

            migrationBuilder.RenameTable(
                name: "OportunityApplicants",
                newName: "OportunityApplicant");

            migrationBuilder.RenameIndex(
                name: "IX_OportunityApplicants_OportunityId",
                table: "OportunityApplicant",
                newName: "IX_OportunityApplicant_OportunityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OportunityApplicant",
                table: "OportunityApplicant",
                columns: new[] { "UserId", "OportunityId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OportunityApplicant_AspNetUsers_UserId",
                table: "OportunityApplicant",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OportunityApplicant_Oportunities_OportunityId",
                table: "OportunityApplicant",
                column: "OportunityId",
                principalTable: "Oportunities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
