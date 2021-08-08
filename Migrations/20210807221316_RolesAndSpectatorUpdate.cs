using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaForYou.Migrations
{
    public partial class RolesAndSpectatorUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Spectators");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Spectators",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Spectators");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Spectators",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
