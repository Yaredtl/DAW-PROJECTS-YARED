using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AUT02_05.Data;
using AUT02_05.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AUT02_05.Controllers
{
    public class EspengsController : Controller
    {
        private readonly DiccionarioContext _context;
        public EspengsController(DiccionarioContext context)
        {
            _context = context;

        }

        // GET: Espengs
        public async Task<IActionResult> Index()
        {
            var espeng = await _context.Espengs.Include(f => f.frase)
                .OrderByDescending(e => e.ing)
                .Take(30).ToListAsync();
            return View(espeng);
        }

        // GET: Espengs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }
            var espeng = await _context.Espengs
              .FirstOrDefaultAsync(m => m.id == id);

            if (espeng == null)
            {
                return NotFound();
            }
            ViewData["Frases"] = await _context.Frase.Where(fr => fr.EspengID == id).ToListAsync();
            return View(espeng);
        }

        // GET: Espengs/Create
        [Authorize(Roles = ("Admin"))]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Espengs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,esp,ing")] Espeng espeng)
        {
            if (ModelState.IsValid)
            {
                _context.Add(espeng);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(espeng);
        }

        // GET: Espengs/Edit/5
        [Authorize(Roles = ("Admin"))]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var espeng = await _context.Espengs.FindAsync(id);
            if (espeng == null)
            {
                return NotFound();
            }
            return View(espeng);
        }

        // POST: Espengs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [Authorize(Roles = ("Admin"))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,esp,ing")] Espeng espeng)
        {
            if (id != espeng.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(espeng);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspengExists(espeng.id))
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
            return View(espeng);
        }

        // GET: Espengs/Delete/5
        [Authorize(Roles = ("Admin"))]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var espeng = await _context.Espengs
                .FirstOrDefaultAsync(m => m.id == id);
            if (espeng == null)
            {
                return NotFound();
            }

            return View(espeng);
        }

        // POST: Espengs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var espeng = await _context.Espengs.FindAsync(id);
            if (espeng != null)
            {
                _context.Espengs.Remove(espeng);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspengExists(int id)
        {
            return _context.Espengs.Any(e => e.id == id);
        }
    }
}
