using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaForYou.Migrations
{
    public partial class model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pegi",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Members",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Implantations",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "ImplantationId",
                table: "Shows",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Shows",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Shows",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImplantationId",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieTypeId",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PegiId",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Birthdate",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Implantations",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(nullable: true),
                    ImageName = table.Column<string>(nullable: true),
                    MovieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pegis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    IllustrationPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pegis", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Implantations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Anvers" },
                    { 2, "Namur" }
                });

            migrationBuilder.InsertData(
                table: "MovieTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Aventure" },
                    { 3, "Horreur" },
                    { 4, "Science-Fiction" },
                    { 5, "Dessin Animé" }
                });

            migrationBuilder.InsertData(
                table: "Pegis",
                columns: new[] { "Id", "Description", "IllustrationPath" },
                values: new object[,]
                {
                    { 1, "Avec cette classification, le contenu du film est considéré comme adapté à toutes les classes d’âge. Le film ne doit pas comporter de sons ou d’images susceptibles d’effrayer ou de faire peur à de jeunes enfants. Les formes de violence très modérées dans un contexte comique ou enfantin sont acceptables. Le film ne doit faire entendre aucun langage grossier.", "wwwroot/img/pegi/p3.jpg" },
                    { 2, "Les contenus présentant des scènes ou sons potentiellement effrayants se retrouvent dans cette classe. Avec une classification PEGI 7 des scènes de violence très modérées (une violence implicite, non détaillée ou non réaliste) peuvent être autorisées.", "wwwroot/img/pegi/p7.jpg" },
                    { 3, "Des films montrant de la violence sous une forme plus graphique par rapport à des personnages imaginaires et/ou une violence non graphique envers des personnages à figure humaine entrent dans cette classe d’âge. Des insinuations à caractère sexuel ou des postures de type sexuelles peuvent être présentes, mais dans cette catégorie les grossièretés doivent rester légères.", "wwwroot/img/pegi/p12.jpg" },
                    { 4, "Cette classification s’applique lorsque la représentation de la violence (ou d’un contact sexuel) atteint un niveau semblable à celui que l’on retrouverait dans la réalité. Les films classés dans la catégorie 16 peuvent contenir un langage grossier plus extrême, des jeux de hasard, ainsi qu’une consommation de tabac, d’alcool ou de drogues.", "wwwroot/img/pegi/p16.jpg" },
                    { 5, "La classification destinée aux adultes s’applique lorsque le degré de violence atteint un niveau où il rejoint une représentation de violence crue, de meurtre apparemment sans motivation ou de violence contre des personnages sans défense. La glorification des drogues illégales et les contacts sexuels explicites entrent également dans cette tranche d’âge. ", "wwwroot/img/pegi/p18.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Duration", "MovieTypeId", "PegiId", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 6, 103, 5, 1, new DateTime(1985, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "L'age de Glace" },
                    { 7, 110, 1, 4, new DateTime(1985, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Top Gun" },
                    { 10, 131, 1, 3, new DateTime(1985, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Last Action Hero" },
                    { 5, 128, 3, 3, new DateTime(1985, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jurassic Park" },
                    { 3, 107, 3, 3, new DateTime(1985, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gremlins" },
                    { 8, 162, 4, 2, new DateTime(1985, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar" },
                    { 2, 116, 4, 2, new DateTime(1985, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Retour vers le Futur" },
                    { 1, 90, 3, 5, new DateTime(2003, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Massacre à la tronçonneuse" },
                    { 9, 117, 3, 5, new DateTime(1985, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alien, le huitième passager" },
                    { 4, 100, 5, 1, new DateTime(1985, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Le Monde de Némo" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "ImplantationId", "Number", "Seats" },
                values: new object[,]
                {
                    { 3, 2, 3, 8 },
                    { 2, 2, 2, 12 },
                    { 1, 2, 1, 12 },
                    { 7, 1, 4, 8 },
                    { 6, 1, 3, 12 },
                    { 5, 1, 2, 12 },
                    { 4, 1, 1, 14 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ImageName", "ImagePath", "MovieId" },
                values: new object[,]
                {
                    { 8, "nemo.jpg", "wwwroot/img/movie/nemo.jpg", 4 },
                    { 2, "alien.jpg", "wwwroot/img/movie/alien.jpg", 9 },
                    { 5, "jurassicpark.jpg", "wwwroot/img/movie/jurassicpark.jpg", 5 },
                    { 3, "avatar.jpg", "wwwroot/img/movie/avatar.jpg", 8 },
                    { 6, "lastactionhero.jpg", "wwwroot/img/movie/lastactionhero.jpg", 10 },
                    { 4, "gremlins.jpg", "wwwroot/img/movie/gremlins.jpg", 3 },
                    { 10, "topgun.jpg", "wwwroot/img/movie/topgun.jpg", 7 },
                    { 9, "retourverslefutur.jpg", "wwwroot/img/movie/retourverslefutur.jpg", 2 },
                    { 1, "agedeglace.jpg", "wwwroot/img/movie/agedeglace.jpg", 6 },
                    { 7, "massacretronconneuse.jpg", "wwwroot/img/movie/massacretronconneuse.jpg", 1 }
                });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "Date", "ImplantationId", "MovieId", "RoomId" },
                values: new object[,]
                {
                    { 13, new DateTime(2021, 8, 27, 20, 0, 0, 0, DateTimeKind.Unspecified), 2, 7, 2 },
                    { 25, new DateTime(2021, 8, 26, 17, 30, 0, 0, DateTimeKind.Unspecified), 1, 10, 4 },
                    { 24, new DateTime(2021, 8, 27, 20, 0, 0, 0, DateTimeKind.Unspecified), 1, 10, 4 },
                    { 6, new DateTime(2021, 8, 25, 17, 30, 0, 0, DateTimeKind.Unspecified), 2, 10, 2 },
                    { 14, new DateTime(2021, 8, 25, 22, 0, 0, 0, DateTimeKind.Unspecified), 2, 7, 3 },
                    { 2, new DateTime(2021, 8, 25, 20, 0, 0, 0, DateTimeKind.Unspecified), 2, 5, 3 },
                    { 16, new DateTime(2021, 8, 26, 22, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 4 },
                    { 18, new DateTime(2021, 8, 27, 22, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 6 },
                    { 5, new DateTime(2021, 8, 26, 20, 0, 0, 0, DateTimeKind.Unspecified), 2, 7, 1 },
                    { 4, new DateTime(2021, 8, 27, 20, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 1 },
                    { 23, new DateTime(2021, 8, 27, 14, 30, 0, 0, DateTimeKind.Unspecified), 1, 8, 6 },
                    { 22, new DateTime(2021, 8, 27, 17, 30, 0, 0, DateTimeKind.Unspecified), 1, 8, 6 },
                    { 20, new DateTime(2021, 8, 27, 17, 30, 0, 0, DateTimeKind.Unspecified), 1, 8, 7 },
                    { 26, new DateTime(2021, 8, 26, 22, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 6 },
                    { 17, new DateTime(2021, 8, 25, 20, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 6 },
                    { 15, new DateTime(2021, 8, 25, 17, 30, 0, 0, DateTimeKind.Unspecified), 1, 2, 4 },
                    { 1, new DateTime(2021, 8, 25, 17, 30, 0, 0, DateTimeKind.Unspecified), 2, 2, 1 },
                    { 10, new DateTime(2021, 8, 27, 17, 30, 0, 0, DateTimeKind.Unspecified), 2, 6, 3 },
                    { 9, new DateTime(2021, 8, 26, 14, 30, 0, 0, DateTimeKind.Unspecified), 2, 6, 2 },
                    { 7, new DateTime(2021, 8, 25, 14, 30, 0, 0, DateTimeKind.Unspecified), 2, 6, 2 },
                    { 27, new DateTime(2021, 8, 26, 14, 30, 0, 0, DateTimeKind.Unspecified), 1, 4, 4 },
                    { 21, new DateTime(2021, 8, 25, 14, 30, 0, 0, DateTimeKind.Unspecified), 1, 4, 7 },
                    { 12, new DateTime(2021, 8, 27, 14, 30, 0, 0, DateTimeKind.Unspecified), 2, 4, 3 },
                    { 11, new DateTime(2021, 8, 26, 17, 30, 0, 0, DateTimeKind.Unspecified), 2, 4, 3 },
                    { 3, new DateTime(2021, 8, 26, 22, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 2 },
                    { 19, new DateTime(2021, 8, 25, 22, 0, 0, 0, DateTimeKind.Unspecified), 1, 9, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shows_ImplantationId",
                table: "Shows",
                column: "ImplantationId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_MovieId",
                table: "Shows",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_RoomId",
                table: "Shows",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_ImplantationId",
                table: "Rooms",
                column: "ImplantationId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieTypeId",
                table: "Movies",
                column: "MovieTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_PegiId",
                table: "Movies",
                column: "PegiId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_MovieId",
                table: "Images",
                column: "MovieId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MovieTypes_MovieTypeId",
                table: "Movies",
                column: "MovieTypeId",
                principalTable: "MovieTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Pegis_PegiId",
                table: "Movies",
                column: "PegiId",
                principalTable: "Pegis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Implantations_ImplantationId",
                table: "Rooms",
                column: "ImplantationId",
                principalTable: "Implantations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Implantations_ImplantationId",
                table: "Shows",
                column: "ImplantationId",
                principalTable: "Implantations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Movies_MovieId",
                table: "Shows",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Rooms_RoomId",
                table: "Shows",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MovieTypes_MovieTypeId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Pegis_PegiId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Implantations_ImplantationId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Implantations_ImplantationId",
                table: "Shows");

            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Movies_MovieId",
                table: "Shows");

            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Rooms_RoomId",
                table: "Shows");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "MovieTypes");

            migrationBuilder.DropTable(
                name: "Pegis");

            migrationBuilder.DropIndex(
                name: "IX_Shows_ImplantationId",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_MovieId",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_RoomId",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_ImplantationId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Movies_MovieTypeId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_PegiId",
                table: "Movies");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Implantations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Implantations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "ImplantationId",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "ImplantationId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "MovieTypeId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "PegiId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Implantations");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Members",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Implantations",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "Pegi",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
