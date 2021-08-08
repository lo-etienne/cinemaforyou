using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaForYou.Migrations
{
    public partial class reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShowId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ShowId",
                table: "Reservations",
                column: "ShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Shows_ShowId",
                table: "Reservations",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Shows_ShowId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ShowId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ShowId",
                table: "Reservations");
        }
    }
}
