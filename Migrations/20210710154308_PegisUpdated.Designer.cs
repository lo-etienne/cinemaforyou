﻿// <auto-generated />
using System;
using CinemaForYou.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CinemaForYou.Migrations
{
    [DbContext(typeof(CinemaForYouDbContext))]
    [Migration("20210710154308_PegisUpdated")]
    partial class PegisUpdated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CinemaForYou.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieId")
                        .IsUnique();

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageName = "agedeglace.jpg",
                            ImagePath = "wwwroot/img/movie/agedeglace.jpg",
                            MovieId = 6
                        },
                        new
                        {
                            Id = 2,
                            ImageName = "alien.jpg",
                            ImagePath = "wwwroot/img/movie/alien.jpg",
                            MovieId = 9
                        },
                        new
                        {
                            Id = 3,
                            ImageName = "avatar.jpg",
                            ImagePath = "wwwroot/img/movie/avatar.jpg",
                            MovieId = 8
                        },
                        new
                        {
                            Id = 4,
                            ImageName = "gremlins.jpg",
                            ImagePath = "wwwroot/img/movie/gremlins.jpg",
                            MovieId = 3
                        },
                        new
                        {
                            Id = 5,
                            ImageName = "jurassicpark.jpg",
                            ImagePath = "wwwroot/img/movie/jurassicpark.jpg",
                            MovieId = 5
                        },
                        new
                        {
                            Id = 6,
                            ImageName = "lastactionhero.jpg",
                            ImagePath = "wwwroot/img/movie/lastactionhero.jpg",
                            MovieId = 10
                        },
                        new
                        {
                            Id = 7,
                            ImageName = "massacretronconneuse.jpg",
                            ImagePath = "wwwroot/img/movie/massacretronconneuse.jpg",
                            MovieId = 1
                        },
                        new
                        {
                            Id = 8,
                            ImageName = "nemo.jpg",
                            ImagePath = "wwwroot/img/movie/nemo.jpg",
                            MovieId = 4
                        },
                        new
                        {
                            Id = 9,
                            ImageName = "retourverslefutur.jpg",
                            ImagePath = "wwwroot/img/movie/retourverslefutur.jpg",
                            MovieId = 2
                        },
                        new
                        {
                            Id = 10,
                            ImageName = "topgun.jpg",
                            ImagePath = "wwwroot/img/movie/topgun.jpg",
                            MovieId = 7
                        });
                });

            modelBuilder.Entity("CinemaForYou.Models.Implantation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Implantations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Anvers"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Namur"
                        });
                });

            modelBuilder.Entity("CinemaForYou.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Birthdate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("CinemaForYou.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int?>("MovieTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("PegiId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MovieTypeId");

                    b.HasIndex("PegiId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Duration = 90,
                            MovieTypeId = 3,
                            PegiId = 5,
                            ReleaseDate = new DateTime(2003, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Massacre à la tronçonneuse"
                        },
                        new
                        {
                            Id = 2,
                            Duration = 116,
                            MovieTypeId = 4,
                            PegiId = 2,
                            ReleaseDate = new DateTime(1985, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Retour vers le Futur"
                        },
                        new
                        {
                            Id = 3,
                            Duration = 107,
                            MovieTypeId = 3,
                            PegiId = 3,
                            ReleaseDate = new DateTime(1985, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Gremlins"
                        },
                        new
                        {
                            Id = 4,
                            Duration = 100,
                            MovieTypeId = 5,
                            PegiId = 1,
                            ReleaseDate = new DateTime(1985, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Le Monde de Némo"
                        },
                        new
                        {
                            Id = 5,
                            Duration = 128,
                            MovieTypeId = 3,
                            PegiId = 3,
                            ReleaseDate = new DateTime(1985, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Jurassic Park"
                        },
                        new
                        {
                            Id = 6,
                            Duration = 103,
                            MovieTypeId = 5,
                            PegiId = 1,
                            ReleaseDate = new DateTime(1985, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "L'age de Glace"
                        },
                        new
                        {
                            Id = 7,
                            Duration = 110,
                            MovieTypeId = 1,
                            PegiId = 4,
                            ReleaseDate = new DateTime(1985, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Top Gun"
                        },
                        new
                        {
                            Id = 8,
                            Duration = 162,
                            MovieTypeId = 4,
                            PegiId = 2,
                            ReleaseDate = new DateTime(1985, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Avatar"
                        },
                        new
                        {
                            Id = 9,
                            Duration = 117,
                            MovieTypeId = 3,
                            PegiId = 5,
                            ReleaseDate = new DateTime(1985, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Alien, le huitième passager"
                        },
                        new
                        {
                            Id = 10,
                            Duration = 131,
                            MovieTypeId = 1,
                            PegiId = 3,
                            ReleaseDate = new DateTime(1985, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Last Action Hero"
                        });
                });

            modelBuilder.Entity("CinemaForYou.Models.MovieType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MovieTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Aventure"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Horreur"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Science-Fiction"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Dessin Animé"
                        });
                });

            modelBuilder.Entity("CinemaForYou.Models.Pegi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IllustrationPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pegis");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Avec cette classification, le contenu du film est considéré comme adapté à toutes les classes d’âge. Le film ne doit pas comporter de sons ou d’images susceptibles d’effrayer ou de faire peur à de jeunes enfants. Les formes de violence très modérées dans un contexte comique ou enfantin sont acceptables. Le film ne doit faire entendre aucun langage grossier.",
                            IllustrationPath = "img/pegi/p3.jpg"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Les contenus présentant des scènes ou sons potentiellement effrayants se retrouvent dans cette classe. Avec une classification PEGI 7 des scènes de violence très modérées (une violence implicite, non détaillée ou non réaliste) peuvent être autorisées.",
                            IllustrationPath = "img/pegi/p7.jpg"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Des films montrant de la violence sous une forme plus graphique par rapport à des personnages imaginaires et/ou une violence non graphique envers des personnages à figure humaine entrent dans cette classe d’âge. Des insinuations à caractère sexuel ou des postures de type sexuelles peuvent être présentes, mais dans cette catégorie les grossièretés doivent rester légères.",
                            IllustrationPath = "img/pegi/p12.jpg"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Cette classification s’applique lorsque la représentation de la violence (ou d’un contact sexuel) atteint un niveau semblable à celui que l’on retrouverait dans la réalité. Les films classés dans la catégorie 16 peuvent contenir un langage grossier plus extrême, des jeux de hasard, ainsi qu’une consommation de tabac, d’alcool ou de drogues.",
                            IllustrationPath = "img/pegi/p16.jpg"
                        },
                        new
                        {
                            Id = 5,
                            Description = "La classification destinée aux adultes s’applique lorsque le degré de violence atteint un niveau où il rejoint une représentation de violence crue, de meurtre apparemment sans motivation ou de violence contre des personnages sans défense. La glorification des drogues illégales et les contacts sexuels explicites entrent également dans cette tranche d’âge. ",
                            IllustrationPath = "img/pegi/p18.jpg"
                        });
                });

            modelBuilder.Entity("CinemaForYou.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("CinemaForYou.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ImplantationId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImplantationId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImplantationId = 2,
                            Number = 1,
                            Seats = 12
                        },
                        new
                        {
                            Id = 2,
                            ImplantationId = 2,
                            Number = 2,
                            Seats = 12
                        },
                        new
                        {
                            Id = 3,
                            ImplantationId = 2,
                            Number = 3,
                            Seats = 8
                        },
                        new
                        {
                            Id = 4,
                            ImplantationId = 1,
                            Number = 1,
                            Seats = 14
                        },
                        new
                        {
                            Id = 5,
                            ImplantationId = 1,
                            Number = 2,
                            Seats = 12
                        },
                        new
                        {
                            Id = 6,
                            ImplantationId = 1,
                            Number = 3,
                            Seats = 12
                        },
                        new
                        {
                            Id = 7,
                            ImplantationId = 1,
                            Number = 4,
                            Seats = 8
                        });
                });

            modelBuilder.Entity("CinemaForYou.Models.Show", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ImplantationId")
                        .HasColumnType("int");

                    b.Property<int?>("MovieId")
                        .HasColumnType("int");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImplantationId");

                    b.HasIndex("MovieId");

                    b.HasIndex("RoomId");

                    b.ToTable("Shows");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2021, 8, 25, 17, 30, 0, 0, DateTimeKind.Unspecified),
                            ImplantationId = 2,
                            MovieId = 2,
                            RoomId = 1
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2021, 8, 25, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            ImplantationId = 2,
                            MovieId = 5,
                            RoomId = 3
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2021, 8, 26, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            ImplantationId = 2,
                            MovieId = 3,
                            RoomId = 2
                        },
                        new
                        {
                            Id = 4,
                            Date = new DateTime(2021, 8, 27, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            ImplantationId = 2,
                            MovieId = 3,
                            RoomId = 1
                        },
                        new
                        {
                            Id = 5,
                            Date = new DateTime(2021, 8, 26, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            ImplantationId = 2,
                            MovieId = 7,
                            RoomId = 1
                        },
                        new
                        {
                            Id = 6,
                            Date = new DateTime(2021, 8, 25, 17, 30, 0, 0, DateTimeKind.Unspecified),
                            ImplantationId = 2,
                            MovieId = 10,
                            RoomId = 2
                        },
                        new
                        {
                            Id = 7,
                            Date = new DateTime(2021, 8, 25, 14, 30, 0, 0, DateTimeKind.Unspecified),
                            ImplantationId = 2,
                            MovieId = 6,
                            RoomId = 2
                        },
                        new
                        {
                            Id = 9,
                            Date = new DateTime(2021, 8, 26, 14, 30, 0, 0, DateTimeKind.Unspecified),
                            ImplantationId = 2,
                            MovieId = 6,
                            RoomId = 2
                        },
                        new
                        {
                            Id = 10,
                            Date = new DateTime(2021, 8, 27, 17, 30, 0, 0, DateTimeKind.Unspecified),
                            ImplantationId = 2,
                            MovieId = 6,
                            RoomId = 3
                        },
                        new
                        {
                            Id = 11,
                            Date = new DateTime(2021, 8, 26, 17, 30, 0, 0, DateTimeKind.Unspecified),
                            ImplantationId = 2,
                            MovieId = 4,
                            RoomId = 3
                        },
                        new
                        {
                            Id = 12,
                            Date = new DateTime(2021, 8, 27, 14, 30, 0, 0, DateTimeKind.Unspecified),
                            ImplantationId = 2,
                            MovieId = 4,
                            RoomId = 3
                        },
                        new
                        {
                            Id = 13,
                            Date = new DateTime(2021, 8, 27, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            ImplantationId = 2,
                            MovieId = 7,
                            RoomId = 2
                        },
                        new
                        {
                            Id = 14,
                            Date = new DateTime(2021, 8, 25, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            ImplantationId = 2,
                            MovieId = 7,
                            RoomId = 3
                        },
                        new
                        {
                            Id = 15,
                            Date = new DateTime(2021, 8, 25, 17, 30, 0, 0, DateTimeKind.Unspecified),
                            ImplantationId = 1,
                            MovieId = 2,
                            RoomId = 4
                        },
                        new
                        {
                            Id = 16,
                            Date = new DateTime(2021, 8, 26, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            ImplantationId = 1,
                            MovieId = 1,
                            RoomId = 4
                        },
                        new
                        {
                            Id = 17,
                            Date = new DateTime(2021, 8, 25, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            ImplantationId = 1,
                            MovieId = 2,
                            RoomId = 6
                        },
                        new
                        {
                            Id = 18,
                            Date = new DateTime(2021, 8, 27, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            ImplantationId = 1,
                            MovieId = 1,
                            RoomId = 6
                        },
                        new
                        {
                            Id = 19,
                            Date = new DateTime(2021, 8, 25, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            ImplantationId = 1,
                            MovieId = 9,
                            RoomId = 7
                        },
                        new
                        {
                            Id = 20,
                            Date = new DateTime(2021, 8, 27, 17, 30, 0, 0, DateTimeKind.Unspecified),
                            ImplantationId = 1,
                            MovieId = 8,
                            RoomId = 7
                        },
                        new
                        {
                            Id = 21,
                            Date = new DateTime(2021, 8, 25, 14, 30, 0, 0, DateTimeKind.Unspecified),
                            ImplantationId = 1,
                            MovieId = 4,
                            RoomId = 7
                        },
                        new
                        {
                            Id = 22,
                            Date = new DateTime(2021, 8, 27, 17, 30, 0, 0, DateTimeKind.Unspecified),
                            ImplantationId = 1,
                            MovieId = 8,
                            RoomId = 6
                        },
                        new
                        {
                            Id = 23,
                            Date = new DateTime(2021, 8, 27, 14, 30, 0, 0, DateTimeKind.Unspecified),
                            ImplantationId = 1,
                            MovieId = 8,
                            RoomId = 6
                        },
                        new
                        {
                            Id = 24,
                            Date = new DateTime(2021, 8, 27, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            ImplantationId = 1,
                            MovieId = 10,
                            RoomId = 4
                        },
                        new
                        {
                            Id = 25,
                            Date = new DateTime(2021, 8, 26, 17, 30, 0, 0, DateTimeKind.Unspecified),
                            ImplantationId = 1,
                            MovieId = 10,
                            RoomId = 4
                        },
                        new
                        {
                            Id = 26,
                            Date = new DateTime(2021, 8, 26, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            ImplantationId = 1,
                            MovieId = 2,
                            RoomId = 6
                        },
                        new
                        {
                            Id = 27,
                            Date = new DateTime(2021, 8, 26, 14, 30, 0, 0, DateTimeKind.Unspecified),
                            ImplantationId = 1,
                            MovieId = 4,
                            RoomId = 4
                        });
                });

            modelBuilder.Entity("CinemaForYou.Models.Image", b =>
                {
                    b.HasOne("CinemaForYou.Models.Movie", "Movie")
                        .WithOne("Image")
                        .HasForeignKey("CinemaForYou.Models.Image", "MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CinemaForYou.Models.Movie", b =>
                {
                    b.HasOne("CinemaForYou.Models.MovieType", "Type")
                        .WithMany("Movies")
                        .HasForeignKey("MovieTypeId");

                    b.HasOne("CinemaForYou.Models.Pegi", "Pegi")
                        .WithMany("Movies")
                        .HasForeignKey("PegiId");
                });

            modelBuilder.Entity("CinemaForYou.Models.Room", b =>
                {
                    b.HasOne("CinemaForYou.Models.Implantation", "Implantation")
                        .WithMany("Rooms")
                        .HasForeignKey("ImplantationId");
                });

            modelBuilder.Entity("CinemaForYou.Models.Show", b =>
                {
                    b.HasOne("CinemaForYou.Models.Implantation", "Implantation")
                        .WithMany("Shows")
                        .HasForeignKey("ImplantationId");

                    b.HasOne("CinemaForYou.Models.Movie", "Movie")
                        .WithMany("Shows")
                        .HasForeignKey("MovieId");

                    b.HasOne("CinemaForYou.Models.Room", "Room")
                        .WithMany("Shows")
                        .HasForeignKey("RoomId");
                });
#pragma warning restore 612, 618
        }
    }
}