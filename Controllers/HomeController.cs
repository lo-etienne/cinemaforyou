using CinemaForYou.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaForYou.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CinemaForYouDbContext _context;

        public HomeController(ILogger<HomeController> logger, CinemaForYouDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<Movie> Movies = _context.Movies.ToList();
            foreach (Movie movie in Movies)
            {
                movie.Shows = _context.Shows.Where(s => s.MovieId == movie.Id).ToList();
                movie.Pegi = _context.Pegis.First(p => p.Id == movie.PegiId);
                movie.Image = _context.Images.First(i => i.MovieId == movie.Id);
                movie.Type = _context.MovieTypes.First(t => t.Id == movie.MovieTypeId);
                foreach (Show show in movie.Shows)
                {
                    show.Implantation = _context.Implantations.First(i => i.Id == show.ImplantationId);
                    show.Room = _context.Rooms.First(r => r.Id == show.RoomId);
                    show.Reservations = _context.Reservations.Where(r => r.ShowId == show.Id).ToList();
                }
            }
            IndexViewModel viewModel = new IndexViewModel()
            {
                Movies = Movies
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 60 * 60 * 25, Location = ResponseCacheLocation.Any, NoStore = false)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
