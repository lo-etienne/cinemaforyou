using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaForYou.Migrations
{
    public partial class Spectators : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MemberId1",
                table: "Reservations",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Spectator",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    ReservationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spectator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spectator_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_MemberId1",
                table: "Reservations",
                column: "MemberId1");

            migrationBuilder.CreateIndex(
                name: "IX_Spectator_ReservationId",
                table: "Spectator",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_MemberId1",
                table: "Reservations",
                column: "MemberId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_MemberId1",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "Spectator");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_MemberId1",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "MemberId1",
                table: "Reservations");
        }
    }
}
