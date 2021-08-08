using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaForYou.Models;
using Microsoft.AspNetCore.Authorization;

namespace CinemaForYou.Controllers
{

    [Authorize(Roles = "Manager,User")]
    public class ReservationsController : Controller
    {
        private readonly CinemaForYouDbContext _context;

        public ReservationsController(CinemaForYouDbContext context)
        {
            _context = context;
        }

        // GET: Reservations
        public async Task<IActionResult> Index(string? memberId)
        {

            var cinemaForYouDbContext = _context.Reservations.Include(r => r.Show).Where(r => r.MemberId == memberId);
            return View(await cinemaForYouDbContext.ToListAsync());
        }

        public async Task<IActionResult> Confirmation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var reservation = await _context.Reservations
                .Include(r => r.Show)
                .Include(r => r.Spectators)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            reservation.Show.Movie = _context.Movies.FirstOrDefault(m => m.Id == reservation.Show.MovieId);
            reservation.Show.Movie.Image = _context.Images.FirstOrDefault(i => i.MovieId == reservation.Show.MovieId);

            return View(reservation);
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Show)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public IActionResult Create(int? id, int movieId)
        {

            Movie Movie =  _context.Movies.First(m => m.Id == movieId);
            Movie.Image = _context.Images.First(i => i.MovieId == Movie.Id);
            Movie.Pegi = _context.Pegis.First(p => p.Id == Movie.PegiId);
            Movie.Type = _context.MovieTypes.First(t => t.Id == Movie.MovieTypeId);

            Show show = _context.Shows.Find(id);
            show.Reservations = _context.Reservations.Where(r => r.ShowId == show.Id).ToList();
            Room room = _context.Rooms.FirstOrDefault(r => r.Id == show.RoomId);

            int seatsAvailable = room.Seats - show.Reservations.Count;

            ReservationMakerViewModel viewModel = new ReservationMakerViewModel()
            {
                Movie = Movie,
                ShowId = id,
                SeatsAvailable = seatsAvailable
            };


            return View(viewModel);
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservationMakerViewModel viewModel)
        {

            viewModel.Movie = _context.Movies.FirstOrDefault(m => m.Id == viewModel.Movie.Id);
            Pegi pegi = _context.Pegis.FirstOrDefault(p => p.Id == viewModel.Movie.PegiId);

            if (viewModel.Age != null)
            {
                int minimalAge = DateTime.Now.Year - _context.Members.Find(viewModel.Reservation.MemberId).Birthdate.Year;

                for (int i = 0; i < viewModel.Age.Count(); i++)
                {

                    if (DateTime.Now.Year - viewModel.Age.ElementAt(i).Year < minimalAge)
                    {
                        minimalAge = DateTime.Now.Year - viewModel.Age.ElementAt(i).Year;
                    }
                }

                if (minimalAge < pegi.Number)
                {
                    return RedirectToAction("Suggestions", "Movies", new { minimalAge = minimalAge });
                }
            }

            if (ModelState.IsValid)
            {
                 _context.Add(viewModel.Reservation);
                await _context.SaveChangesAsync();

                List<Spectator> spectators = new List<Spectator>();

                if (viewModel.Name != null)
                {
                    for (int i = 0; i < viewModel.Name.Count(); i++)
                    {
                        spectators.Add(new Spectator()
                        {
                            Name = viewModel.Name.ElementAt(i),
                            Surname = viewModel.Surname.ElementAt(i),
                            BirthDate = viewModel.Age.ElementAt(i),
                            ReservationId = viewModel.Reservation.Id
                        });
                    }
                }

               

                foreach (Spectator spectator in spectators)
                {
                    _context.Spectators.Add(spectator);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction("Confirmation", "Reservations", new {id = viewModel.Reservation.Id});
            }
            ViewData["ShowId"] = new SelectList(_context.Shows, "Id", "Id", viewModel.Reservation.ShowId);
            return View(viewModel);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            ViewData["ShowId"] = new SelectList(_context.Shows, "Id", "Id", reservation.ShowId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ShowId")] Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.Id))
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
            ViewData["ShowId"] = new SelectList(_context.Shows, "Id", "Id", reservation.ShowId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Show)
                .Include(r => r.Member)
                .Include(r => r.Spectators)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            ReservationCancellationViewModel viewModel = new ReservationCancellationViewModel()
            {
                Reservation = reservation
            };

            return View(viewModel);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(bool deleteEveryone, ReservationCancellationViewModel viewModel)
        {

            if (deleteEveryone)
            {
                var reservation = await _context.Reservations.FindAsync(viewModel.Reservation.Id);

                List<Spectator> spectators = _context.Spectators.Where(s => s.ReservationId == viewModel.Reservation.Id)
                    .ToList();
                if (spectators != null)
                {
                    foreach (Spectator spectator in spectators)
                    {
                        _context.Spectators.Remove(spectator);
                        await _context.SaveChangesAsync();
                    }
                }
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new {memberId = viewModel.Reservation.MemberId});
            }
            else
            {
                if (viewModel.SpectatorsId == null)
                {
                    return RedirectToAction("Index", new { memberId = viewModel.Reservation.MemberId });
                }

                foreach (int id in viewModel.SpectatorsId)
                {
                    var spectator = await _context.Spectators.FindAsync(id);
                    _context.Spectators.Remove(spectator);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction("Index", new { memberId = viewModel.Reservation.MemberId });
            }

            
           
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.Id == id);
        }
    }
}
