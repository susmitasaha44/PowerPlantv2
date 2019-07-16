using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PowerPlantV2.Data;
using PowerPlantV2.Models;

namespace PowerPlantV2.Controllers
{
    public class PowerplantSitesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PowerplantSitesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PowerplantSites
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PowerplantSites.Include(p => p.Consumer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PowerplantSites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var powerplantSite = await _context.PowerplantSites
                .Include(p => p.Consumer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (powerplantSite == null)
            {
                return NotFound();
            }

            return View(powerplantSite);
        }

        // GET: PowerplantSites/Create
        public IActionResult Create()
        {
            ViewData["ConsumerID"] = new SelectList(_context.Consumers, "ConsumerID", "ConsumerID");
            return View();
        }

        // POST: PowerplantSites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sitename,Contactname,ContactPhone,ContactEmail,Capacity,UsefulLife,ProjectCost,Loan,ConsumerID")] PowerplantSite powerplantSite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(powerplantSite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConsumerID"] = new SelectList(_context.Consumers, "ConsumerID", "ConsumerID", powerplantSite.ConsumerID);
            return View(powerplantSite);
        }

        // GET: PowerplantSites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var powerplantSite = await _context.PowerplantSites.FindAsync(id);
            if (powerplantSite == null)
            {
                return NotFound();
            }
            ViewData["ConsumerID"] = new SelectList(_context.Consumers, "ConsumerID", "ConsumerID", powerplantSite.ConsumerID);
            return View(powerplantSite);
        }

        // POST: PowerplantSites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sitename,Contactname,ContactPhone,ContactEmail,Capacity,UsefulLife,ProjectCost,Loan,ConsumerID")] PowerplantSite powerplantSite)
        {
            if (id != powerplantSite.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(powerplantSite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PowerplantSiteExists(powerplantSite.Id))
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
            ViewData["ConsumerID"] = new SelectList(_context.Consumers, "ConsumerID", "ConsumerID", powerplantSite.ConsumerID);
            return View(powerplantSite);
        }

        // GET: PowerplantSites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var powerplantSite = await _context.PowerplantSites
                .Include(p => p.Consumer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (powerplantSite == null)
            {
                return NotFound();
            }

            return View(powerplantSite);
        }

        // POST: PowerplantSites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var powerplantSite = await _context.PowerplantSites.FindAsync(id);
            _context.PowerplantSites.Remove(powerplantSite);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PowerplantSiteExists(int id)
        {
            return _context.PowerplantSites.Any(e => e.Id == id);
        }
    }
}
