using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaForYou.Migrations
{
    public partial class SpectatorsDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spectator_Reservations_ReservationId",
                table: "Spectator");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Spectator",
                table: "Spectator");

            migrationBuilder.RenameTable(
                name: "Spectator",
                newName: "Spectators");

            migrationBuilder.RenameIndex(
                name: "IX_Spectator_ReservationId",
                table: "Spectators",
                newName: "IX_Spectators_ReservationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Spectators",
                table: "Spectators",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Spectators_Reservations_ReservationId",
                table: "Spectators",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spectators_Reservations_ReservationId",
                table: "Spectators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Spectators",
                table: "Spectators");

            migrationBuilder.RenameTable(
                name: "Spectators",
                newName: "Spectator");

            migrationBuilder.RenameIndex(
                name: "IX_Spectators_ReservationId",
                table: "Spectator",
                newName: "IX_Spectator_ReservationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Spectator",
                table: "Spectator",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Spectator_Reservations_ReservationId",
                table: "Spectator",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
