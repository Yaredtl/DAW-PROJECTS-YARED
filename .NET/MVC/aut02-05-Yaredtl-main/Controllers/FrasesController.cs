using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AUT02_05.Data;
using AUT02_05.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;

namespace AUT02_05.Controllers
{
    public class FrasesController : Controller
    {
        private readonly DiccionarioContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        public FrasesController(DiccionarioContext context, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        // GET: Frases

        // GET: Frases/Details/5

        // GET: Frases/Create
        public async Task<IActionResult> Create(int id)
        {
            ViewBag.Termino = await _context.Espengs.Where(term => term.id == id).ToListAsync();
            ViewData["EspengID"] = id;
            return View();
        }

        // POST: Frases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("fraesp,fraing,EspengID")] Frase frase, int id)
        {
            if (ModelState.IsValid)
            {
                frase.EspengID = id;
                frase.IdUser = _signInManager.UserManager.GetUserId(User);
                _context.Add(frase);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Espengs", new { id = frase.EspengID });
            }
            ViewData["EspengID"] = new SelectList(_context.Espengs, "id", "id", frase.EspengID);
            return View(frase);
        }

        // GET: Frases/Edit/5
        [Authorize (Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Termino = await _context.Espengs.Where(term => term.id == id).ToListAsync();
            var frase = await _context.Frase.FindAsync(id);
            if (frase == null)
            {
                return NotFound();
            }
            ViewData["EspengID"] = frase.EspengID;
            return View(frase);
        }

        // POST: Frases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,fraesp,fraing,EspengID,IdUser")] Frase frase)
        {
            if (id != frase.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(frase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FraseExists(frase.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Espengs", new { id = frase.EspengID });
         
            }
            ViewData["EspengID"] = new SelectList(_context.Espengs, "id", "id", frase.EspengID);
            return View(frase);
        }

        // GET: Frases/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            var frase = await _context.Frase
                .Include(f => f.Espeng)
                .FirstOrDefaultAsync(m => m.id == id);
            
            if (frase == null)
            {
                return NotFound();
            }
            ViewData["EspengID"] = frase.EspengID;
            return View(frase);
        }

        // POST: Frases/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var frase = await _context.Frase.FindAsync(id);
            if (frase != null)
            {
                _context.Frase.Remove(frase);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Espengs", new { id = frase.EspengID });
        }

        private bool FraseExists(int id)
        {
            return _context.Frase.Any(e => e.id == id);
        }
    }
}
