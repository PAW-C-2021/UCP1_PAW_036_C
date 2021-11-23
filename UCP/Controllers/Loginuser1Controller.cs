using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP.Models;

namespace UCP.Controllers
{
    public class Loginuser1Controller : Controller
    {
        private readonly perpustakaanContext _context;

        public Loginuser1Controller(perpustakaanContext context)
        {
            _context = context;
        }

        // GET: Loginuser1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Loginuser1s.ToListAsync());
        }

        // GET: Loginuser1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginuser1 = await _context.Loginuser1s
                .FirstOrDefaultAsync(m => m.IdLogin == id);
            if (loginuser1 == null)
            {
                return NotFound();
            }

            return View(loginuser1);
        }

        // GET: Loginuser1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Loginuser1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLogin,Username")] Loginuser1 loginuser1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loginuser1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loginuser1);
        }

        // GET: Loginuser1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginuser1 = await _context.Loginuser1s.FindAsync(id);
            if (loginuser1 == null)
            {
                return NotFound();
            }
            return View(loginuser1);
        }

        // POST: Loginuser1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLogin,Username")] Loginuser1 loginuser1)
        {
            if (id != loginuser1.IdLogin)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loginuser1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Loginuser1Exists(loginuser1.IdLogin))
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
            return View(loginuser1);
        }

        // GET: Loginuser1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginuser1 = await _context.Loginuser1s
                .FirstOrDefaultAsync(m => m.IdLogin == id);
            if (loginuser1 == null)
            {
                return NotFound();
            }

            return View(loginuser1);
        }

        // POST: Loginuser1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loginuser1 = await _context.Loginuser1s.FindAsync(id);
            _context.Loginuser1s.Remove(loginuser1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Loginuser1Exists(int id)
        {
            return _context.Loginuser1s.Any(e => e.IdLogin == id);
        }
    }
}
