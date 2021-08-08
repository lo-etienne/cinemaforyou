using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaForYou.Migrations
{
    public partial class RoomOnDeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Rooms_RoomId",
                table: "Shows");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Rooms_RoomId",
                table: "Shows",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Rooms_RoomId",
                table: "Shows");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Rooms_RoomId",
                table: "Shows",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
