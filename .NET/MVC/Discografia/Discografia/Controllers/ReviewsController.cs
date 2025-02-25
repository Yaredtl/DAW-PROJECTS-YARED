using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Discografia.Data;
using Discografia.Models;

namespace Discografia.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly ChinookContext _context;

        public ReviewsController(ChinookContext context)
        {
            _context = context;
        }

        // GET: Reviews/Create
        public IActionResult Create(int? id)
        {
            ViewData["id"] = id;
            ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "ArtistId");
            return View();
        }

        // POST: Reviews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,Points,ArtistId")] Review review, int id)
        {
            if (ModelState.IsValid)
            {
                review.ArtistId = id;
                _context.Add(review);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details","Artists", new {id = review.ArtistId});
            }
            ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "ArtistId", review.ArtistId);
            return View(review);
           
        }
        private bool ReviewExists(int id)
        {
            return _context.Review.Any(e => e.Id == id);
        }
    }
}
