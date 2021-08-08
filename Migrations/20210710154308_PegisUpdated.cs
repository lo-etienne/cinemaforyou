using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaForYou.Migrations
{
    public partial class PegisUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pegis",
                keyColumn: "Id",
                keyValue: 1,
                column: "IllustrationPath",
                value: "img/pegi/p3.jpg");

            migrationBuilder.UpdateData(
                table: "Pegis",
                keyColumn: "Id",
                keyValue: 2,
                column: "IllustrationPath",
                value: "img/pegi/p7.jpg");

            migrationBuilder.UpdateData(
                table: "Pegis",
                keyColumn: "Id",
                keyValue: 3,
                column: "IllustrationPath",
                value: "img/pegi/p12.jpg");

            migrationBuilder.UpdateData(
                table: "Pegis",
                keyColumn: "Id",
                keyValue: 4,
                column: "IllustrationPath",
                value: "img/pegi/p16.jpg");

            migrationBuilder.UpdateData(
                table: "Pegis",
                keyColumn: "Id",
                keyValue: 5,
                column: "IllustrationPath",
                value: "img/pegi/p18.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pegis",
                keyColumn: "Id",
                keyValue: 1,
                column: "IllustrationPath",
                value: "wwwroot/img/pegi/p3.jpg");

            migrationBuilder.UpdateData(
                table: "Pegis",
                keyColumn: "Id",
                keyValue: 2,
                column: "IllustrationPath",
                value: "wwwroot/img/pegi/p7.jpg");

            migrationBuilder.UpdateData(
                table: "Pegis",
                keyColumn: "Id",
                keyValue: 3,
                column: "IllustrationPath",
                value: "wwwroot/img/pegi/p12.jpg");

            migrationBuilder.UpdateData(
                table: "Pegis",
                keyColumn: "Id",
                keyValue: 4,
                column: "IllustrationPath",
                value: "wwwroot/img/pegi/p16.jpg");

            migrationBuilder.UpdateData(
                table: "Pegis",
                keyColumn: "Id",
                keyValue: 5,
                column: "IllustrationPath",
                value: "wwwroot/img/pegi/p18.jpg");
        }
    }
}
