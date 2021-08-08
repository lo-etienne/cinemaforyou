using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaForYou.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace CinemaForYou.Controllers
{
    public class MoviesController : Controller
    {
        private readonly CinemaForYouDbContext _context;
        private IWebHostEnvironment _hostEnvironment;

        public MoviesController(CinemaForYouDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Movies
        public async Task<IActionResult> Index(string pegiOrder = "", string typeOrder = "", string implantationOrder = "", string title = "")
        {

            ViewBag.PegisList = new List<String>() {"", "3", "7", "12", "16", "18"};
            ViewBag.TypesList = new List<String>()
                {"", "Aventure", "Action", "Horreur", "Dessin Animé", "Science-Fiction"};
            ViewBag.ImlantationsList = new List<String>() {"", "Anvers", "Namur"};

            var movies = _context.Movies.Include(m => m.Pegi).Include(m => m.Type).Include(m => m.Image).Where(m => m.Title.Length > 0);
            if (!string.IsNullOrWhiteSpace(pegiOrder))
            {
                movies = movies.Where(m => m.Pegi.Number == int.Parse(pegiOrder));
            };
            if (!string.IsNullOrWhiteSpace(typeOrder))
            {
                movies = movies.Where(m => m.Type.Name == typeOrder);
            };




            return View(await movies.ToListAsync());
        }

        public IActionResult Suggestions(int minimalAge)
        {
            List<Pegi> pegis = _context.Pegis.Where(p => p.Number <= minimalAge).OrderByDescending(p => p.Number)
                .ToList();
            List<Movie> movies = _context.Movies.Include(m => m.Pegi).Include(m => m.Type).Include(m => m.Image).ToList();
            List<Movie> suggestions = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (movie.Pegi.Number <= pegis.ElementAt(0).Number)
                {
                   suggestions.Add(movie);
                }
            }
            return View(suggestions);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(m => m.Pegi)
                .Include(m => m.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            var image = await _context.Images.FirstOrDefaultAsync(i => i.MovieId == movie.Id);

            var Implantations =  _context.Implantations.ToList();
            Dictionary<Implantation, List<Show>> ShowsData = new Dictionary<Implantation, List<Show>>();
            foreach (Implantation implantation in Implantations)
            {
                List<Show> Shows = _context.Shows.Where(s => s.ImplantationId == implantation.Id && s.MovieId == id).ToList();
                foreach (Show show in Shows)
                {
                    show.Room = _context.Rooms.First(r => r.Id == show.RoomId);
                    show.Reservations = _context.Reservations.Include(r => r.Spectators).Where(r => r.ShowId == show.Id).ToList();
                }
                ShowsData.Add(implantation, Shows);
            }

            MovieDataViewModel viewModel = new MovieDataViewModel()
            {
                Movie = movie,
                Image = image,
                Shows = ShowsData
            };

            return View(viewModel);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            MovieCreatorViewModel viewModel = new MovieCreatorViewModel()
            {
                Pegis = new SelectList(_context.Pegis, "Id", "Number"),
                Types = new SelectList(_context.MovieTypes, "Id", "Name")
        };
            return View(viewModel);
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieCreatorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                string WwwRootPath = _hostEnvironment.WebRootPath;
                string imageName = Path.GetFileNameWithoutExtension(viewModel.Image.ImageFile.FileName);
                string extension = Path.GetExtension(viewModel.Image.ImageFile.FileName);
                viewModel.Image.ImageName = imageName = imageName + extension;
                viewModel.Image.ImagePath = Path.Combine(WwwRootPath + "/img/movie/", imageName);

                using (var fileStream = new FileStream(viewModel.Image.ImagePath, FileMode.Create))
                {
                    await viewModel.Image.ImageFile.CopyToAsync(fileStream);
                }

                _context.Add(viewModel.Movie);
                await _context.SaveChangesAsync();

                viewModel.Image.MovieId = viewModel.Movie.Id;
                _context.Images.Add(viewModel.Image);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["PegiId"] = new SelectList(_context.Pegis, "Id", "Id", viewModel.Movie.PegiId);
            ViewData["MovieTypeId"] = new SelectList(_context.MovieTypes, "Id", "Id", viewModel.Movie.MovieTypeId);
            return View(viewModel);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            SelectList pegis = new SelectList(_context.Pegis, "Id", "Number", movie.PegiId);
            SelectList types = new SelectList(_context.MovieTypes, "Id", "Name", movie.MovieTypeId);

            MovieCreatorViewModel viewModel = new MovieCreatorViewModel()
            {
                Movie = movie,
                Pegis = pegis,
                Types = types,

            };

            return View(viewModel);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MovieCreatorViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viewModel.Movie);
                    await _context.SaveChangesAsync();
                    var image = await _context.Images.FirstOrDefaultAsync(i => i.Id == viewModel.Movie.Id);
                    _context.Images.Remove(image);

                    string WwwRootPath = _hostEnvironment.WebRootPath;
                    string imageName = Path.GetFileNameWithoutExtension(viewModel.Image.ImageFile.FileName);
                    string extension = Path.GetExtension(viewModel.Image.ImageFile.FileName);
                    viewModel.Image.ImageName = imageName = imageName + extension;
                    viewModel.Image.ImagePath = Path.Combine(WwwRootPath + "/img/movie/", imageName);

                    using (var fileStream = new FileStream(viewModel.Image.ImagePath, FileMode.Create))
                    {
                        await viewModel.Image.ImageFile.CopyToAsync(fileStream);
                    }

                    viewModel.Image.MovieId = viewModel.Movie.Id;
                    _context.Images.Add(viewModel.Image);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(viewModel.Image.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            SelectList pegis = new SelectList(_context.Pegis, "Id", "Number", viewModel.Movie.PegiId);
            SelectList types = new SelectList(_context.MovieTypes, "Id", "Name", viewModel.Movie.PegiId);

            var img = await _context.Images.FirstOrDefaultAsync(i => i.MovieId == viewModel.Movie.PegiId);

            MovieCreatorViewModel vm = new MovieCreatorViewModel()
            {
                Movie = viewModel.Movie,
                Pegis = pegis,
                Types = types,
                Image = img

            };
            return View(vm);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(m => m.Pegi)
                .Include(m => m.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            var image = _context.Images.FirstOrDefault(i => i.MovieId == id);

            MovieCreatorViewModel viewModel = new MovieCreatorViewModel()
            {
                Movie = movie,
                Image = image
            };

            return View(viewModel);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var image = await _context.Images.FirstOrDefaultAsync(i => i.MovieId == id);
            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
