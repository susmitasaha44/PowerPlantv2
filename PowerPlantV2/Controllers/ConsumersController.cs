﻿using System;
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
    public class ConsumersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsumersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Consumers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Consumers.ToListAsync());
        }

        // GET: Consumers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumer = await _context.Consumers
                .FirstOrDefaultAsync(m => m.ConsumerID == id);
            if (consumer == null)
            {
                return NotFound();
            }

            return View(consumer);
        }

        // GET: Consumers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consumers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConsumerID,FirstName,LastName")] Consumer consumer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consumer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consumer);
        }

        // GET: Consumers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumer = await _context.Consumers.FindAsync(id);
            if (consumer == null)
            {
                return NotFound();
            }
            return View(consumer);
        }

        // POST: Consumers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ConsumerID,FirstName,LastName")] Consumer consumer)
        {
            if (id != consumer.ConsumerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consumer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsumerExists(consumer.ConsumerID))
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
            return View(consumer);
        }

        // GET: Consumers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumer = await _context.Consumers
                .FirstOrDefaultAsync(m => m.ConsumerID == id);
            if (consumer == null)
            {
                return NotFound();
            }

            return View(consumer);
        }

        // POST: Consumers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var consumer = await _context.Consumers.FindAsync(id);
            _context.Consumers.Remove(consumer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsumerExists(string id)
        {
            return _context.Consumers.Any(e => e.ConsumerID == id);
        }
    }
}
