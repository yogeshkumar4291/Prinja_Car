using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prinja_Car.Data;
using Prinja_Car.Models;
using Microsoft.AspNetCore.Authorization;

namespace Prinja_Car.Controllers
{
    [Authorize]
    public class BuysController : Controller
    {
        private readonly Major_ProjectContext _context;

        public BuysController(Major_ProjectContext context)
        {
            _context = context;
        }

        // GET: Buys
        public async Task<IActionResult> Index()
        {
            var major_ProjectContext = _context.Buy.Include(b => b.Car).Include(b => b.Customer).Include(b => b.Staff).Include(b => b.Store);
            return View(await major_ProjectContext.ToListAsync());
        }

        // GET: Buys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buy = await _context.Buy
                .Include(b => b.Car)
                .Include(b => b.Customer)
                .Include(b => b.Staff)
                .Include(b => b.Store)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buy == null)
            {
                return NotFound();
            }

            return View(buy);
        }

        // GET: Buys/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Car, "Id", "Id");
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id");
            ViewData["StaffId"] = new SelectList(_context.Staff, "Id", "Id");
            ViewData["StoreId"] = new SelectList(_context.Store, "Id", "Id");
            return View();
        }

        // POST: Buys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,StaffId,StoreId,CarId")] Buy buy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Car, "Id", "Id", buy.CarId);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", buy.CustomerId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "Id", "Id", buy.StaffId);
            ViewData["StoreId"] = new SelectList(_context.Store, "Id", "Id", buy.StoreId);
            return View(buy);
        }

        // GET: Buys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buy = await _context.Buy.FindAsync(id);
            if (buy == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Car, "Id", "Id", buy.CarId);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", buy.CustomerId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "Id", "Id", buy.StaffId);
            ViewData["StoreId"] = new SelectList(_context.Store, "Id", "Id", buy.StoreId);
            return View(buy);
        }

        // POST: Buys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,StaffId,StoreId,CarId")] Buy buy)
        {
            if (id != buy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuyExists(buy.Id))
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
            ViewData["CarId"] = new SelectList(_context.Car, "Id", "Id", buy.CarId);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", buy.CustomerId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "Id", "Id", buy.StaffId);
            ViewData["StoreId"] = new SelectList(_context.Store, "Id", "Id", buy.StoreId);
            return View(buy);
        }

        // GET: Buys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buy = await _context.Buy
                .Include(b => b.Car)
                .Include(b => b.Customer)
                .Include(b => b.Staff)
                .Include(b => b.Store)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buy == null)
            {
                return NotFound();
            }

            return View(buy);
        }

        // POST: Buys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buy = await _context.Buy.FindAsync(id);
            _context.Buy.Remove(buy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuyExists(int id)
        {
            return _context.Buy.Any(e => e.Id == id);
        }
    }
}
