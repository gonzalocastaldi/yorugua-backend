using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TwelftMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Squad_SquadId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Squad_SquadId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Squad",
                table: "Squad");

            migrationBuilder.RenameTable(
                name: "Squad",
                newName: "Squads");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Squads",
                table: "Squads",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Squads_SquadId",
                table: "Players",
                column: "SquadId",
                principalTable: "Squads",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Squads_SquadId",
                table: "Users",
                column: "SquadId",
                principalTable: "Squads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Squads_SquadId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Squads_SquadId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Squads",
                table: "Squads");

            migrationBuilder.RenameTable(
                name: "Squads",
                newName: "Squad");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Squad",
                table: "Squad",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Squad_SquadId",
                table: "Players",
                column: "SquadId",
                principalTable: "Squad",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Squad_SquadId",
                table: "Users",
                column: "SquadId",
                principalTable: "Squad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
