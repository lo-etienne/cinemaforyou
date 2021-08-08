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
    public class ImplantationsController : Controller
    {
        private readonly CinemaForYouDbContext _context;

        public ImplantationsController(CinemaForYouDbContext context)
        {
            _context = context;
        }

        // GET: Implantations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Implantations.ToListAsync());
        }

        // GET: Implantations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var implantation = await _context.Implantations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (implantation == null)
            {
                return NotFound();
            }

            List<Room> rooms = _context.Rooms.Where(r => r.ImplantationId == id).ToList();

            ImplantationManagerViewModel viewModel = new ImplantationManagerViewModel()
            {
                Implantation = implantation,
                Rooms = rooms
            };

            return View(viewModel);
        }

        // GET: Implantations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Implantations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Implantation implantation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(implantation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(implantation);
        }

        // GET: Implantations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var implantation = await _context.Implantations.FindAsync(id);
            if (implantation == null)
            {
                return NotFound();
            }
            return View(implantation);
        }

        // POST: Implantations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Implantation implantation)
        {
            if (id != implantation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(implantation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImplantationExists(implantation.Id))
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
            return View(implantation);
        }

        // GET: Implantations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var implantation = await _context.Implantations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (implantation == null)
            {
                return NotFound();
            }

            return View(implantation);
        }

        // POST: Implantations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var implantation = await _context.Implantations.FindAsync(id);
            _context.Implantations.Remove(implantation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImplantationExists(int id)
        {
            return _context.Implantations.Any(e => e.Id == id);
        }
    }
}
