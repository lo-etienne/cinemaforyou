using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinemaForYou.Models
{
    public class CinemaForYouDbContext : IdentityDbContext
    {
        public CinemaForYouDbContext(DbContextOptions<CinemaForYouDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Room>().HasOne(r => r.Implantation).WithMany(i => i.Rooms).HasForeignKey(r => r.ImplantationId);
            modelBuilder.Entity<Show>().HasOne(s => s.Room).WithMany(r => r.Shows).HasForeignKey(s => s.RoomId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Show>().HasOne(s => s.Movie).WithMany(m => m.Shows).HasForeignKey(s => s.MovieId);
            modelBuilder.Entity<Movie>().HasOne(m => m.Pegi).WithMany(p => p.Movies).HasForeignKey(m => m.PegiId);
            modelBuilder.Entity<Movie>().HasOne(m => m.Type).WithMany(t => t.Movies).HasForeignKey(m => m.MovieTypeId);
            modelBuilder.Entity<Image>().HasOne(i => i.Movie).WithOne(m => m.Image);
            modelBuilder.Entity<Show>().HasOne(s => s.Implantation).WithMany(i => i.Shows).HasForeignKey(s => s.ImplantationId);
            modelBuilder.Entity<Reservation>().HasOne(r => r.Show).WithMany(s => s.Reservations).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Reservation>().HasOne(r => r.Member).WithMany(m => m.Reservations);
            modelBuilder.Entity<Spectator>().HasOne(s => s.Reservation).WithMany(r => r.Spectators).OnDelete(DeleteBehavior.Cascade);
            SeedDatabase(modelBuilder);
        }

        protected void SeedDatabase(ModelBuilder modelBuilder)
        {
            SeedMovieTypes(modelBuilder);
            SeedPegis(modelBuilder);
            SeedImplantations(modelBuilder);
            SeedRooms(modelBuilder);
            SeedMovies(modelBuilder);
            SeedImages(modelBuilder);
            SeedShows(modelBuilder);

        }

        private void SeedShows(ModelBuilder modelBuilder)
        {
            Show Show1 = new Show()
            {
                Id = 1,
                Date = new DateTime(2021, 8, 25),
                Heure = new TimeSpan(17, 30, 00),
                ImplantationId = 2,
                RoomId = 1,
                MovieId = 2
            };
            Show Show2 = new Show()
            {
                Id = 2,
                Date = new DateTime(2021, 8, 25),
                Heure = new TimeSpan(20, 00, 00),
                ImplantationId = 2,
                RoomId = 3,
                MovieId = 5
            };
            Show Show3 = new Show()
            {
                Id = 3,
                Date = new DateTime(2021, 8, 26),
                Heure = new TimeSpan(22, 00, 00),
                ImplantationId = 2,
                RoomId = 2,
                MovieId = 3 // Gremlins
            };
            Show Show4 = new Show()
            {
                Id = 4,
                Date = new DateTime(2021, 8, 27),
                Heure = new TimeSpan(20, 00, 00),
                ImplantationId = 2,
                RoomId = 1,
                MovieId = 3
            };
            Show Show5 = new Show()
            {
                Id = 5,
                Date = new DateTime(2021, 8, 26),
                Heure = new TimeSpan(20, 00, 00),
                ImplantationId = 2,
                RoomId = 1,
                MovieId = 7 // Top Gun
            };
            Show Show6 = new Show()
            {
                Id = 6,
                Date = new DateTime(2021, 8, 25),
                Heure = new TimeSpan(17, 30, 00),
                ImplantationId = 2,
                RoomId = 2,
                MovieId = 10 // Last Action Hero
            };
            Show Show7 = new Show()
            {
                Id = 7,
                Date = new DateTime(2021, 8, 25),
                Heure = new TimeSpan(14, 30, 00),
                ImplantationId = 2,
                RoomId = 2,
                MovieId = 6 // Age de Glace
            };
            Show Show8 = new Show()
            {
                Id = 9,
                Date = new DateTime(2021, 8, 26),
                Heure = new TimeSpan(14, 30, 00),
                ImplantationId = 2,
                RoomId = 2,
                MovieId = 6
            };
            Show Show9 = new Show()
            {
                Id = 10,
                Date = new DateTime(2021, 8, 27),
                Heure = new TimeSpan(17, 30, 00),
                ImplantationId = 2,
                RoomId = 3,
                MovieId = 6
            };
            Show Show10 = new Show()
            {
                Id = 11,
                Date = new DateTime(2021, 8, 26),
                Heure = new TimeSpan(17, 30, 00),
                ImplantationId = 2,
                RoomId = 3,
                MovieId = 4 // Le monde de Némo
            };
            Show Show11 = new Show()
            {
                Id = 12,
                Date = new DateTime(2021, 8, 27),
                Heure = new TimeSpan(14, 30, 00),
                ImplantationId = 2,
                RoomId = 3,
                MovieId = 4
            };
            Show Show12 = new Show()
            {
                Id = 13,
                Date = new DateTime(2021, 8, 27),
                Heure = new TimeSpan(20, 00, 00),
                ImplantationId = 2,
                RoomId = 2,
                MovieId = 7
            };
            Show Show13 = new Show()
            {
                Id = 14,
                Date = new DateTime(2021, 8, 25),
                Heure = new TimeSpan(22, 00, 00),
                ImplantationId = 2,
                RoomId = 3,
                MovieId = 7
            };
            Show Show14 = new Show()
            {
                Id = 15,
                Date = new DateTime(2021, 8, 25),
                Heure = new TimeSpan(17, 30, 00),
                ImplantationId = 1,
                RoomId = 4,
                MovieId = 2
            };
            Show Show15 = new Show()
            {
                Id = 16,
                Date = new DateTime(2021, 8, 26),
                Heure = new TimeSpan(22, 00, 00),
                ImplantationId = 1,
                RoomId = 4,
                MovieId = 1
            };
            Show Show16 = new Show()
            {
                Id = 17,
                Date = new DateTime(2021, 8, 25),
                Heure = new TimeSpan(20, 00, 00),
                ImplantationId = 1,
                RoomId = 6,
                MovieId = 2
            };
            Show Show17 = new Show()
            {
                Id = 18,
                Date = new DateTime(2021, 8, 27),
                Heure = new TimeSpan(22, 00, 00),
                ImplantationId = 1,
                RoomId = 6,
                MovieId = 1
            };
            Show Show18 = new Show()
            {
                Id = 19,
                Date = new DateTime(2021, 8, 25),
                Heure = new TimeSpan(22, 00, 00),
                ImplantationId = 1,
                RoomId = 7,
                MovieId = 9
            };
            Show Show19 = new Show()
            {
                Id = 20,
                Date = new DateTime(2021, 8, 27),
                Heure = new TimeSpan(17, 30, 00),
                ImplantationId = 1,
                RoomId = 7,
                MovieId = 8
            };
            Show Show20 = new Show()
            {
                Id = 21,
                Date = new DateTime(2021, 8, 25),
                Heure = new TimeSpan(14, 30, 00),
                ImplantationId = 1,
                RoomId = 7,
                MovieId = 4
            };
            Show Show21 = new Show()
            {
                Id = 22,
                Date = new DateTime(2021, 8, 27),
                Heure = new TimeSpan(17, 30, 00),
                ImplantationId = 1,
                RoomId = 6,
                MovieId = 8
            };
            Show Show22 = new Show()
            {
                Id = 23,
                Date = new DateTime(2021, 8, 27),
                Heure = new TimeSpan(14, 30, 00),
                ImplantationId = 1,
                RoomId = 6,
                MovieId = 8
            };
            Show Show23 = new Show()
            {
                Id = 24,
                Date = new DateTime(2021, 8, 27),
                Heure = new TimeSpan(20, 00, 00),
                ImplantationId = 1,
                RoomId = 4,
                MovieId = 10
            };
            Show Show24 = new Show()
            {
                Id = 25,
                Date = new DateTime(2021, 8, 26),
                Heure = new TimeSpan(17, 30, 00),
                ImplantationId = 1,
                RoomId = 4,
                MovieId = 10
            };
            Show Show25 = new Show()
            {
                Id = 26,
                Date = new DateTime(2021, 8, 26),
                Heure = new TimeSpan(22, 00, 00),
                ImplantationId = 1,
                RoomId = 6,
                MovieId = 2
            };
            Show Show26 = new Show()
            {
                Id = 27,
                Date = new DateTime(2021, 8, 26),
                Heure = new TimeSpan(14, 30, 00),
                ImplantationId = 1,
                RoomId = 4,
                MovieId = 4
            };

            modelBuilder.Entity<Show>().HasData(Show1);
            modelBuilder.Entity<Show>().HasData(Show2);
            modelBuilder.Entity<Show>().HasData(Show3);
            modelBuilder.Entity<Show>().HasData(Show4);
            modelBuilder.Entity<Show>().HasData(Show5);
            modelBuilder.Entity<Show>().HasData(Show6);
            modelBuilder.Entity<Show>().HasData(Show7);
            modelBuilder.Entity<Show>().HasData(Show8);
            modelBuilder.Entity<Show>().HasData(Show9);
            modelBuilder.Entity<Show>().HasData(Show10);
            modelBuilder.Entity<Show>().HasData(Show11);
            modelBuilder.Entity<Show>().HasData(Show12);
            modelBuilder.Entity<Show>().HasData(Show13);
            modelBuilder.Entity<Show>().HasData(Show14);
            modelBuilder.Entity<Show>().HasData(Show15);
            modelBuilder.Entity<Show>().HasData(Show16);
            modelBuilder.Entity<Show>().HasData(Show17);
            modelBuilder.Entity<Show>().HasData(Show18);
            modelBuilder.Entity<Show>().HasData(Show19);
            modelBuilder.Entity<Show>().HasData(Show20);
            modelBuilder.Entity<Show>().HasData(Show21);
            modelBuilder.Entity<Show>().HasData(Show22);
            modelBuilder.Entity<Show>().HasData(Show23);
            modelBuilder.Entity<Show>().HasData(Show24);
            modelBuilder.Entity<Show>().HasData(Show25);
            modelBuilder.Entity<Show>().HasData(Show26);
        }

        private void SeedMovies(ModelBuilder modelBuilder)
        {
            /*
             * PEGI 3 -> 1
             * PEGI 7 -> 2
             * PEGI 12 -> 3
             * PEGI 16 -> 4
             * PEGI 18 -> 5
             *
             * Action -> 1
             * Aventure -> 2
             * Horreur -> 3
             * Science-Fiction -> 4
             * Dessin Animé -> 5
             */
            Movie Movie1 = new Movie()
            {
                Id = 1,
                Title = "Massacre à la tronçonneuse",
                Description = "En 1973, lors d'une perquisition à la ferme de Thomas Hewitt, ancien employé de l'abattoir de Travis County, au Texas, la police découvrait les restes de 33 êtres humains. Cette effroyable trouvaille mit en émoi la population locale. Arborant les grotesques masques de chair de ses victimes et brandissant une tronçonneuse, le tueur fut macabrement surnommé Leatherface. Les autorités locales abattirent un homme portant un masque de cuir, mettant ainsi fin à l'affaire, mais au cours des années suivantes, plusieurs personnes accusèrent la police d'avoir bâclé l'enquête et d'avoir tué un innocent en toute connaissance de cause. Pour la première fois, la seule victime ayant survécu au massacre brise le silence et raconte ce qui est vraiment arrivé cette nuit - là, sur une route déserte du Texas, à cinq personnes qui sans le savoir, roulaient vers leur pire cauchemar.",
                ReleaseDate = new DateTime(2003, 10, 17),
                Duration = 90,
                PegiId = 5,
                MovieTypeId = 3
            };

            Movie Movie2 = new Movie()
            {
                Id = 2,
                Title = "Retour vers le Futur",
                Description = "1985. Le jeune Marty McFly mène une existence anonyme auprès de sa petite amie Jennifer, seulement troublée par sa famille en crise et un proviseur qui serait ravi de l'expulser du lycée. Ami de l'excentrique professeur Emmett Brown, il l'accompagne un soir tester sa nouvelle expérience : le voyage dans le temps via une DeLorean modifiée. La démonstration tourne mal : des trafiquants d'armes débarquent et assassinent le scientifique. Marty se réfugie dans la voiture et se retrouve transporté en 1955. Là, il empêche malgré lui la rencontre de ses parents, et doit tout faire pour les remettre ensemble, sous peine de ne pouvoir exister.",
                ReleaseDate = new DateTime(1985, 7, 3),
                Duration = 116,
                PegiId = 2,
                MovieTypeId = 4
            };

            Movie Movie3 = new Movie()
            {
                Id = 3,
                Title = "Gremlins",
                Description = "Rand Peltzer offre à son fils Billy un étrange animal : un mogwai. Son ancien propriétaire l'a bien mis en garde : il ne faut pas l'exposer à la lumiere, lui éviter tout contact avec l'eau, et surtout, surtout ne jamais le nourrir apres minuit... Sinon...",
                ReleaseDate = new DateTime(1985, 7, 3),
                Duration = 107,
                PegiId = 3,
                MovieTypeId = 3
            };

            Movie Movie4 = new Movie()
            {
                Id = 4,
                Title = "Le Monde de Némo",
                Description = "Dans les eaux tropicales de la Grande Barrière de corail, un poisson-clown du nom de Marin mène une existence paisible avec son fils unique, Nemo. Redoutant l'océan et ses risques imprévisibles, il fait de son mieux pour protéger son fils. Comme tous les petits poissons de son âge, celui-ci rêve pourtant d'explorer les mystérieux récifs. Lorsque Nemo disparaît, Marin devient malgré lui le héros d'une quête unique et palpitante. Le pauvre papa ignore que son rejeton à écailles a été emmené jusque dans l'aquarium d'un dentiste. Marin ne s'engagera pas seul dans l'aventure : la jolie Dory, un poisson-chirurgien bleu à la mémoire défaillante et au grand coeur, va se révéler d'une aide précieuse.Les deux poissons vont affronter d'innombrables dangers, mais l'optimisme de Dory va pousser Marin à surmonter toutes ses peurs.",
                ReleaseDate = new DateTime(1985, 7, 3),
                Duration = 100,
                PegiId = 1,
                MovieTypeId = 5
            };

            Movie Movie5 = new Movie()
            {
                Id = 5,
                Title = "Jurassic Park",
                Description = "Ne pas réveiller le chat qui dort... C'est ce que le milliardaire John Hammond aurait dû se rappeler avant de se lancer dans le clonage de dinosaures. C'est à partir d'une goutte de sang absorbée par un moustique fossilisé que John Hammond et son équipe ont réussi à faire renaître une dizaine d'espèces de dinosaures. Il s'apprête maintenant avec la complicité du docteur Alan Grant, paléontologue de renom, et de son amie Ellie, à ouvrir le plus grand parc à thème du monde. Mais c'était sans compter la cupidité et la malveillance de l'informaticien Dennis Nedry, et éventuellement des dinosaures, seuls maîtres sur l'île...",
                ReleaseDate = new DateTime(1985, 7, 3),
                Duration = 128,
                PegiId = 3,
                MovieTypeId = 3
            };

            Movie Movie6 = new Movie()
            {
                Id = 6,
                Title = "L'age de Glace",
                Description = "L'histoire se déroule au début d'une ère glaciaire. Un trio peu ordinaire, composé d'un mammouth, Manny, d'un paresseux, Sid, et d'un tigre à dents de sabre, Diego, se retrouve avec un bébé humain. Ils décident de le rendre à ses parents mais l'enfant est celui du chef d'une tribu préhistorique chasseuse de tigres. Diego est chargé par son clan d'attirer Manny et Sid dans un piège pour récupérer l'enfant.",
                ReleaseDate = new DateTime(1985, 7, 3),
                Duration = 103,
                PegiId = 1,
                MovieTypeId = 5
            };

            Movie Movie7 = new Movie()
            {
                Id = 7,
                Title = "Top Gun",
                Description = "Jeune as du pilotage et tête brûlée d'une école réservée à l'élite de l'aéronavale US (Top Gun), Pete Mitchell, dit Maverick, tombe sous le charme d'une instructrice alors qu'il est en compétition pour le titre du meilleur pilote...",
                ReleaseDate = new DateTime(1985, 7, 3),
                Duration = 110,
                PegiId = 4,
                MovieTypeId = 1
            };

            Movie Movie8 = new Movie()
            {
                Id = 8,
                Title = "Avatar",
                Description = "Malgré sa paralysie, Jake Sully, un ancien marine immobilisé dans un fauteuil roulant, est resté un combattant au plus profond de son être. Il est recruté pour se rendre à des années-lumière de la Terre, sur Pandora, où de puissants groupes industriels exploitent un minerai rarissime destiné à résoudre la crise énergétique sur Terre. Parce que l'atmosphère de Pandora est toxique pour les humains, ceux-ci ont créé le Programme Avatar, qui permet à des pilotes humains de lier leur esprit à un avatar, un corps biologique commandé à distance, capable de survivre dans cette atmosphère létale. Ces avatars sont des hybrides créés génétiquement en croisant l'ADN humain avec celui des Na'vi, les autochtones de Pandora. Sous sa forme d'avatar, Jake peut de nouveau marcher. On lui confie une mission d'infiltration auprès des Na'vi, devenus un obstacle trop conséquent à l'exploitation du précieux minerai.Mais tout va changer lorsque Neytiri, une très belle Na'vi, sauve la vie de Jake...",
                ReleaseDate = new DateTime(1985, 7, 3),
                Duration = 162,
                PegiId = 2,
                MovieTypeId = 4
            };

            Movie Movie9 = new Movie()
            {
                Id = 9,
                Title = "Alien, le huitième passager",
                Description = "Le vaisseau commercial Nostromo et son équipage, sept hommes et femmes, rentrent sur Terre avec une importante cargaison de minerai. Mais lors d'un arrêt forcé sur une planète déserte, l'officier Kane se fait agresser par une forme de vie inconnue, une arachnide qui étouffe son visage. Après que le docteur de bord lui retire le spécimen, l'équipage retrouve le sourire et dîne ensemble. Jusqu'à ce que Kane, pris de convulsions, voit son abdomen perforé par un corps étranger vivant, qui s'échappe dans les couloirs du vaisseau...",
                ReleaseDate = new DateTime(1985, 7, 3),
                Duration = 117,
                PegiId = 5,
                MovieTypeId = 3
            };

            Movie Movie10 = new Movie()
            {
                Id = 10,
                Title = "Last Action Hero",
                Description = "Grâce a un billet magique, Danny Madigan, un enfant de onze ans, peut vivre les aventures de son policier préferé, Slater, croisé des temps modernes. Ensemble ils affrontent force danger et triomphent toujours. Mais les choses se compliquent lorsque des personnes mal intentionnées s'emparent du billet magique et gagnent New York, ou le crime paie encore plus qu'au cinéma.",
                ReleaseDate = new DateTime(1985, 7, 3),
                Duration = 131,
                PegiId = 3,
                MovieTypeId = 1
            };

            modelBuilder.Entity<Movie>().HasData(Movie1);
            modelBuilder.Entity<Movie>().HasData(Movie2);
            modelBuilder.Entity<Movie>().HasData(Movie3);
            modelBuilder.Entity<Movie>().HasData(Movie4);
            modelBuilder.Entity<Movie>().HasData(Movie5);
            modelBuilder.Entity<Movie>().HasData(Movie6);
            modelBuilder.Entity<Movie>().HasData(Movie7);
            modelBuilder.Entity<Movie>().HasData(Movie8);
            modelBuilder.Entity<Movie>().HasData(Movie9);
            modelBuilder.Entity<Movie>().HasData(Movie10);
        }

        private void SeedImages(ModelBuilder modelBuilder)
        {
            Image Image1 = new Image()
            {
                Id = 1,
                ImageName = "agedeglace.jpg",
                ImagePath = "wwwroot/img/movie/agedeglace.jpg",
                MovieId = 6
            };
            Image Image2 = new Image()
            {
                Id = 2,
                ImageName = "alien.jpg",
                ImagePath = "wwwroot/img/movie/alien.jpg",
                MovieId = 9
            };
            Image Image3 = new Image()
            {
                Id = 3,
                ImageName = "avatar.jpg",
                ImagePath = "wwwroot/img/movie/avatar.jpg",
                MovieId = 8
            };
            Image Image4 = new Image()
            {
                Id = 4,
                ImageName = "gremlins.jpg",
                ImagePath = "wwwroot/img/movie/gremlins.jpg",
                MovieId = 3
            };
            Image Image5 = new Image()
            {
                Id = 5,
                ImageName = "jurassicpark.jpg",
                ImagePath = "wwwroot/img/movie/jurassicpark.jpg",
                MovieId = 5
            };
            Image Image6 = new Image()
            {
                Id = 6,
                ImageName = "lastactionhero.jpg",
                ImagePath = "wwwroot/img/movie/lastactionhero.jpg",
                MovieId = 10
            };
            Image Image7 = new Image()
            {
                Id = 7,
                ImageName = "massacretronconneuse.jpg",
                ImagePath = "wwwroot/img/movie/massacretronconneuse.jpg",
                MovieId = 1
            };
            Image Image8 = new Image()
            {
                Id = 8,
                ImageName = "nemo.jpg",
                ImagePath = "wwwroot/img/movie/nemo.jpg",
                MovieId = 4
            };
            Image Image9 = new Image()
            {
                Id = 9,
                ImageName = "retourverslefutur.jpg",
                ImagePath = "wwwroot/img/movie/retourverslefutur.jpg",
                MovieId = 2
            };
            Image Image10 = new Image()
            {
                Id = 10,
                ImageName = "topgun.jpg",
                ImagePath = "wwwroot/img/movie/topgun.jpg",
                MovieId = 7
            };

            modelBuilder.Entity<Image>().HasData(Image1);
            modelBuilder.Entity<Image>().HasData(Image2);
            modelBuilder.Entity<Image>().HasData(Image3);
            modelBuilder.Entity<Image>().HasData(Image4);
            modelBuilder.Entity<Image>().HasData(Image5);
            modelBuilder.Entity<Image>().HasData(Image6);
            modelBuilder.Entity<Image>().HasData(Image7);
            modelBuilder.Entity<Image>().HasData(Image8);
            modelBuilder.Entity<Image>().HasData(Image9);
            modelBuilder.Entity<Image>().HasData(Image10);
        }

        private void SeedRooms(ModelBuilder modelBuilder)
        {
            Room Room1 = new Room()
            {
                Id = 1,
                Number = 1,
                Seats = 12,
                ImplantationId = 2 // Namur
            };

            Room Room2 = new Room()
            {
                Id = 2,
                Number = 2,
                Seats = 12,
                ImplantationId = 2 // Namur
            };
            Room Room3 = new Room()
            {
                Id = 3,
                Number = 3,
                Seats = 8,
                ImplantationId = 2 // Namur
            };

            Room Room4 = new Room()
            {
                Id = 4,
                Number = 1,
                Seats = 14,
                ImplantationId = 1 // Anvers
            };

            Room Room5 = new Room()
            {
                Id = 5,
                Number = 2,
                Seats = 12,
                ImplantationId = 1 // Anvers
            };

            Room Room6 = new Room()
            {
                Id = 6,
                Number = 3,
                Seats = 12,
                ImplantationId = 1 // Anvers
            };

            Room Room7 = new Room()
            {
                Id = 7,
                Number = 4,
                Seats = 8,
                ImplantationId = 1 // Anvers
            };

            modelBuilder.Entity<Room>().HasData(Room1);
            modelBuilder.Entity<Room>().HasData(Room2);
            modelBuilder.Entity<Room>().HasData(Room3);
            modelBuilder.Entity<Room>().HasData(Room4);
            modelBuilder.Entity<Room>().HasData(Room5);
            modelBuilder.Entity<Room>().HasData(Room6);
            modelBuilder.Entity<Room>().HasData(Room7);
        }

        private void SeedImplantations(ModelBuilder modelBuilder)
        {
            Implantation Implantation1 = new Implantation()
            {
                Id = 1,
                Name = "Anvers"
            };
            Implantation Implantation2 = new Implantation()
            {
                Id = 2,
                Name = "Namur"
            };

            modelBuilder.Entity<Implantation>().HasData(Implantation1);
            modelBuilder.Entity<Implantation>().HasData(Implantation2);
        }

        private void SeedPegis(ModelBuilder modelBuilder)
        {
            Pegi Pegi3 = new Pegi()
            {
                Id = 1,
                Number = 3,
                Description =
                    "Avec cette classification, le contenu du film est considéré comme adapté à toutes les classes d’âge. Le film ne doit pas comporter de sons ou d’images susceptibles d’effrayer ou de faire peur à de jeunes enfants. Les formes de violence très modérées dans un contexte comique ou enfantin sont acceptables. Le film ne doit faire entendre aucun langage grossier.",
                IllustrationPath = "img/pegi/p3.jpg"
            };

            Pegi Pegi7 = new Pegi()
            {
                Id = 2,
                Number = 7,
                Description =
                    "Les contenus présentant des scènes ou sons potentiellement effrayants se retrouvent dans cette classe. Avec une classification PEGI 7 des scènes de violence très modérées (une violence implicite, non détaillée ou non réaliste) peuvent être autorisées.",
                IllustrationPath = "img/pegi/p7.jpg"
            };

            Pegi Pegi12 = new Pegi()
            {
                Id = 3,
                Number = 12,
                Description =
                    "Des films montrant de la violence sous une forme plus graphique par rapport à des personnages imaginaires et/ou une violence non graphique envers des personnages à figure humaine entrent dans cette classe d’âge. Des insinuations à caractère sexuel ou des postures de type sexuelles peuvent être présentes, mais dans cette catégorie les grossièretés doivent rester légères.",
                IllustrationPath = "img/pegi/p12.jpg"
            };

            Pegi Pegi16 = new Pegi()
            {
                Id = 4,
                Number = 16,
                Description =
                    "Cette classification s’applique lorsque la représentation de la violence (ou d’un contact sexuel) atteint un niveau semblable à celui que l’on retrouverait dans la réalité. Les films classés dans la catégorie 16 peuvent contenir un langage grossier plus extrême, des jeux de hasard, ainsi qu’une consommation de tabac, d’alcool ou de drogues.",
                IllustrationPath = "img/pegi/p16.jpg"
            };

            Pegi Pegi18 = new Pegi()
            {
                Id = 5,
                Number = 18,
                Description =
                    "La classification destinée aux adultes s’applique lorsque le degré de violence atteint un niveau où il rejoint une représentation de violence crue, de meurtre apparemment sans motivation ou de violence contre des personnages sans défense. La glorification des drogues illégales et les contacts sexuels explicites entrent également dans cette tranche d’âge. ",
                IllustrationPath = "img/pegi/p18.jpg"
            };

            modelBuilder.Entity<Pegi>().HasData(Pegi3);
            modelBuilder.Entity<Pegi>().HasData(Pegi7);
            modelBuilder.Entity<Pegi>().HasData(Pegi12);
            modelBuilder.Entity<Pegi>().HasData(Pegi16);
            modelBuilder.Entity<Pegi>().HasData(Pegi18);
        }

        private void SeedMovieTypes(ModelBuilder modelBuilder)
        {

            /*
             * Action -> 1
             * Aventure -> 2
             * Horreur -> 3
             * Science-Fiction -> 4
             * Dessin Animé -> 5
            */
            MovieType MovieType1 = new MovieType()
            {
                Id = 1,
                Name = "Action"
            };

            MovieType MovieType2 = new MovieType()
            {
                Id = 2,
                Name = "Aventure"
            };

            MovieType MovieType3 = new MovieType()
            {
                Id = 3,
                Name = "Horreur"
            };

            MovieType MovieType4 = new MovieType()
            {
                Id = 4,
                Name = "Science-Fiction"
            };

            MovieType MovieType5 = new MovieType()
            {
                Id = 5,
                Name = "Dessin Animé"
            };

            modelBuilder.Entity<MovieType>().HasData(MovieType1);
            modelBuilder.Entity<MovieType>().HasData(MovieType2);
            modelBuilder.Entity<MovieType>().HasData(MovieType3);
            modelBuilder.Entity<MovieType>().HasData(MovieType4);
            modelBuilder.Entity<MovieType>().HasData(MovieType5);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Implantation> Implantations { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Pegi> Pegis { get; set; }
        public DbSet<MovieType> MovieTypes { get; set; }
        public DbSet<Image> Images { get; set; }

        public DbSet<Spectator> Spectators { get; set; }
    }
}
