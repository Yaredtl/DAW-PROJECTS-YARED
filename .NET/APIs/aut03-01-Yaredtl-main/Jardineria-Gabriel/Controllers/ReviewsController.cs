using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Jardineria_Gabriel.Data;
using Jardineria_Gabriel.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Jardineria_Gabriel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReviewsController : ControllerBase
    {
        private readonly jardineriaContext _context;
        private readonly UserManager<JardinUser> _userManager;
        public ReviewsController(jardineriaContext context, UserManager<JardinUser> manager)
        {
            _context = context;
            _userManager = manager;
        }

        // GET: api/Reviews INDEX
        [HttpGet("ProductReviews/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Basic,Premium,Admin")]
        public async Task<ActionResult<IEnumerable<Review>>> GetReview(int id)
        {
            return await _context.Review.Where(x => x.ProductId == id).ToListAsync();
        }

        // GET: api/Reviews/5 DETALLES
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Premium,Admin")]
        public async Task<ActionResult<Review>> GetReviewId(int id)
        {
            var review = await _context.Review.Include(x => x.producto).Where(a => a.ReviewId == id).FirstOrDefaultAsync();

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }

        // PUT: api/Reviews/5 EDITAR
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Premium,Admin")]
        public async Task<IActionResult> PutReview(int id, [FromBody] Review review)
        {
            if (ModelState.IsValid) 
            {
                if (id != review.ReviewId)
                {
                    return BadRequest();
                }
                if (User.IsInRole("Admin"))
                {
                    _context.Entry(review).State = EntityState.Modified;
                }
                if (User.IsInRole("Premium")) 
                {
                    var iduser = User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
                    var user = await _userManager.FindByEmailAsync(iduser);
                    if (user.Id == review.UserId) 
                    {
                        _context.Entry(review).State = EntityState.Modified;
                    }
                    else
                    {
                        return Unauthorized("Chaval aunque seas premium, este no es tuyo ¡eh!");
                    }
                    
                }

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }
            return BadRequest("Socio no fufa");
        }

        // POST: api/Reviews CREAR
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Premium,Admin")]
        public async Task<ActionResult<Review>> PostReview([FromBody]Review review)
        {
            if (ModelState.IsValid) 
            {
                var iduser = User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
                var user = await _userManager.FindByEmailAsync(iduser);
                review.UserId = user.Id;
                _context.Review.Add(review);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetReview", new { id = review.ReviewId },review);
            }
            return BadRequest("Algo ha salido mal");
        }

        // DELETE: api/Reviews/5 DELETE
        [HttpDelete("{id}")]
        [Authorize(Roles = "Premium,Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await _context.Review.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            if (User.IsInRole("Admin")) 
            {
                _context.Review.Remove(review);
            }
            if (User.IsInRole("Premium")) 
            {
                var iduser = User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
                var user = await _userManager.FindByEmailAsync(iduser);
                if (user.Id == review.UserId)
                {
                    _context.Review.Remove(review);
                }
                else
                {
                    return Unauthorized("Chaval aunque seas premium, este no es tuyo ¡eh!");
                }
            }

            await _context.SaveChangesAsync();
            return Ok("Ha sido eliminado");
        }

        private bool ReviewExists(int id)
        {
            return _context.Review.Any(e => e.ReviewId == id);
        }
    }
}
