using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FourteenMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Squads_SquadId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_SquadId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "SquadId",
                table: "Players");

            migrationBuilder.CreateTable(
                name: "PlayerSquad",
                columns: table => new
                {
                    PlayersId = table.Column<Guid>(type: "uuid", nullable: false),
                    SquadsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSquad", x => new { x.PlayersId, x.SquadsId });
                    table.ForeignKey(
                        name: "FK_PlayerSquad_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerSquad_Squads_SquadsId",
                        column: x => x.SquadsId,
                        principalTable: "Squads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSquad_SquadsId",
                table: "PlayerSquad",
                column: "SquadsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerSquad");

            migrationBuilder.AddColumn<Guid>(
                name: "SquadId",
                table: "Players",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_SquadId",
                table: "Players",
                column: "SquadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Squads_SquadId",
                table: "Players",
                column: "SquadId",
                principalTable: "Squads",
                principalColumn: "Id");
        }
    }
}
