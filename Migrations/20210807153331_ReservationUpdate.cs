using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaForYou.Migrations
{
    public partial class ReservationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_MemberId1",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_MemberId1",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "MemberId1",
                table: "Reservations");

            migrationBuilder.AlterColumn<string>(
                name: "MemberId",
                table: "Reservations",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_MemberId",
                table: "Reservations",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_MemberId",
                table: "Reservations",
                column: "MemberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_MemberId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_MemberId",
                table: "Reservations");

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "Reservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MemberId1",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_MemberId1",
                table: "Reservations",
                column: "MemberId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_MemberId1",
                table: "Reservations",
                column: "MemberId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
