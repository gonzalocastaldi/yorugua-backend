using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EleventhMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SquadId",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SquadId",
                table: "Players",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Squad",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squad", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_SquadId",
                table: "Users",
                column: "SquadId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_SquadId",
                table: "Players",
                column: "SquadId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Squad_SquadId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Squad_SquadId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Squad");

            migrationBuilder.DropIndex(
                name: "IX_Users_SquadId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Players_SquadId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "SquadId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SquadId",
                table: "Players");
        }
    }
}
