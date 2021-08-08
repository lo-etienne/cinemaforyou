using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaForYou.Models;

namespace CinemaForYou.Controllers
{
    public class ShowsController : Controller
    {
        private readonly CinemaForYouDbContext _context;

        public ShowsController(CinemaForYouDbContext context)
        {
            _context = context;
        }

        // GET: Shows
        public async Task<IActionResult> Index()
        {
            var cinemaForYouDbContext = _context.Shows.Include(s => s.Implantation).Include(s => s.Movie).Include(s => s.Room);
            return View(await cinemaForYouDbContext.ToListAsync());
        }

        // GET: Shows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Shows
                .Include(s => s.Implantation)
                .Include(s => s.Movie)
                .Include(s => s.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (show == null)
            {
                return NotFound();
            }

            show.Movie.Image = _context.Images.FirstOrDefault(i => i.MovieId == show.MovieId);
            show.Movie.Pegi = _context.Pegis.Find(show.Movie.PegiId);
            show.Movie.Type = _context.MovieTypes.Find(show.Movie.MovieTypeId);

            List<Reservation> reservations = _context.Reservations.Where(r => r.ShowId == show.Id).ToList();

            foreach (Reservation reservation in reservations)
            {
                reservation.Member = _context.Members.Find(reservation.MemberId);
                reservation.Spectators = _context.Spectators.Where(s => s.ReservationId == reservation.Id).ToList();
            }

            ShowDataViewModel viewModel = new ShowDataViewModel()
            {
                Show = show,
                Reservations = reservations
            };

            return View(viewModel);
        }

        // GET: Shows/Create
        public IActionResult Create(int? movieId, int? implantationId)
        {

            Movie movie =  _context.Movies.Find(movieId);
            Pegi pegi = _context.Pegis.Find(movie.PegiId);

            List<TimeSpan> hours = new List<TimeSpan>();

            switch (pegi.Number)
            {
                case 3:
                    hours.Add(new TimeSpan(14,30, 0));
                    hours.Add(new TimeSpan(17, 30, 0));
                    break;
                case 7:
                case 12:
                    hours.Add(new TimeSpan(14, 30, 0));
                    hours.Add(new TimeSpan(17, 30, 0));
                    hours.Add(new TimeSpan(20, 00, 0));
                    hours.Add(new TimeSpan(22, 00, 0));
                    break;
                case 16:
                case 18:
                    hours.Add(new TimeSpan(20, 00, 0));
                    hours.Add(new TimeSpan(22, 00, 0));
                    break;
            }

            ShowViewModel viewModel = new ShowViewModel()
            {
                Movie = movie,
                ImplantationId = (int) implantationId,
                Rooms = new SelectList(_context.Rooms.Where(r => r.ImplantationId == implantationId), "Id", "Number"),
                AvailableHours = new SelectList(hours)
            };
            return View(viewModel);
        }

        // POST: Shows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ShowViewModel viewModel)
        {
            viewModel.Show.Date = viewModel.Show.Date.Add(viewModel.StartingHours);
            viewModel.Show.ImplantationId = viewModel.ImplantationId;
            viewModel.Show.RoomId = viewModel.RoomId;
            viewModel.Show.MovieId = viewModel.Movie.Id;


            if (ModelState.IsValid)
            {
                _context.Add(viewModel.Show);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Movies", new {id = viewModel.Movie.Id});
            }

            // Retourner le viewmodel tel qu'il a été reçu ? 
            return View(viewModel);
        }

        // GET: Shows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Shows
                .Include(s => s.Implantation)
                .Include(s => s.Movie)
                .Include(s => s.Room)
                .FirstOrDefaultAsync(m => m.Id == id);


            if (show == null)
            {
                return NotFound();
            }

            show.Movie.Image = _context.Images.FirstOrDefault(i => i.MovieId == show.MovieId);
            show.Movie.Pegi = _context.Pegis.Find(show.Movie.PegiId);
            show.Movie.Type = _context.MovieTypes.Find(show.Movie.MovieTypeId);

            List<TimeSpan> hours = new List<TimeSpan>();

            switch (show.Movie.Pegi.Number)
            {
                case 3:
                    hours.Add(new TimeSpan(14, 30, 0));
                    hours.Add(new TimeSpan(17, 30, 0));
                    break;
                case 7:
                case 12:
                    hours.Add(new TimeSpan(14, 30, 0));
                    hours.Add(new TimeSpan(17, 30, 0));
                    hours.Add(new TimeSpan(20, 00, 0));
                    hours.Add(new TimeSpan(22, 00, 0));
                    break;
                case 16:
                case 18:
                    hours.Add(new TimeSpan(20, 00, 0));
                    hours.Add(new TimeSpan(22, 00, 0));
                    break;
            }

            ShowEditorViewModel viewModel = new ShowEditorViewModel()
            {
                Show = show,
                AvailableHours = new SelectList(hours)
            };
            return View(viewModel);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ShowEditorViewModel viewModel)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viewModel.Show);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowExists(viewModel.Show.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Movies", new {id = viewModel.Show.MovieId});
            }
            return View(viewModel);
        }

        // GET: Shows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Shows
                .Include(s => s.Implantation)
                .Include(s => s.Movie)
                .Include(s => s.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var show = await _context.Shows.FindAsync(id);
            _context.Shows.Remove(show);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowExists(int id)
        {
            return _context.Shows.Any(e => e.Id == id);
        }
    }
}
