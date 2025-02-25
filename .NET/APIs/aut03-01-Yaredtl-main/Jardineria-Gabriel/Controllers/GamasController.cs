using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Jardineria_Gabriel.Data;
using Jardineria_Gabriel.Models;
using Microsoft.AspNetCore.Authorization;

namespace Jardineria_Gabriel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GamasController : ControllerBase
    {
        private readonly jardineriaContext _context;

        public GamasController(jardineriaContext context)
        {
            _context = context;
        }

        // GET: api/Gamas INDEX
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "Basic,Premium,Admin")]
        public async Task<ActionResult<IEnumerable<gama_producto>>> Getgama_productos()
        {
            var lista = await _context.gama_productos.ToListAsync();
            return Ok(lista);
        }

        // GET: api/Gamas/5 DETALLES
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Basic,Premium,Admin")]
        public async Task<ActionResult<gama_producto>> Getgama_producto(string id)
        {
            var gama_producto = await _context.gama_productos
                .Include(x => x.productos)
                .Where(g=> g.gama == id)
                .FirstOrDefaultAsync();

            if (gama_producto == null)
            {
                return NotFound("Gama no encontrada");
            }

            return Ok(gama_producto);
        }

        // PUT: api/Gamas/5 EDITAR
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Putgama_producto(string id, [FromBody] gama_producto gama_producto)
        {
            if (ModelState.IsValid)
            {
                if (id != gama_producto.gama)
                {
                    return BadRequest();
                }

                _context.Entry(gama_producto).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!gama_productoExists(id))
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
            return BadRequest();
        }
            

        // POST: api/Gamas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<gama_producto>> Postgama_producto(gama_producto gama_producto)
        //{
        //    _context.gama_productos.Add(gama_producto);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (gama_productoExists(gama_producto.gama))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("Getgama_producto", new { id = gama_producto.gama }, gama_producto);
        //}

        // DELETE: api/Gamas/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Deletegama_producto(string id)
        //{
        //    var gama_producto = await _context.gama_productos.FindAsync(id);
        //    if (gama_producto == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.gama_productos.Remove(gama_producto);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool gama_productoExists(string id)
        {
            return _context.gama_productos.Any(e => e.gama == id);
        }
    }
}
