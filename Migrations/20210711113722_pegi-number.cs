using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaForYou.Migrations
{
    public partial class peginumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Pegis",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Pegis",
                keyColumn: "Id",
                keyValue: 1,
                column: "Number",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Pegis",
                keyColumn: "Id",
                keyValue: 2,
                column: "Number",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Pegis",
                keyColumn: "Id",
                keyValue: 3,
                column: "Number",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Pegis",
                keyColumn: "Id",
                keyValue: 4,
                column: "Number",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Pegis",
                keyColumn: "Id",
                keyValue: 5,
                column: "Number",
                value: 18);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Pegis");
        }
    }
}
