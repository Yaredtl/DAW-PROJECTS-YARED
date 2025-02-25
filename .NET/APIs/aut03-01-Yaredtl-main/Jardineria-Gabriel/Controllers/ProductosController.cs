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
    public class ProductosController : ControllerBase
    {
        private readonly jardineriaContext _context;

        public ProductosController(jardineriaContext context)
        {
            _context = context;
        }

        // GET: api/Productos Index
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "Basic,Premium,Admin")]
        public async Task<ActionResult<IEnumerable<producto>>> Getproductos()
        {
            return await _context.productos
                .OrderBy(x => x.nombre)
                .Take(30)
                .ToListAsync();
        }

        // GET: api/Productos/5 Details
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Basic,Premium,Admin")]
        public async Task<ActionResult<producto>> Getproducto(int id)
        {
            var producto = await _context.productos.Include(x => x.Reviews)
                .Where(g => g.codigo_producto == id)
                .FirstOrDefaultAsync();

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        // PUT: api/Productos/5 EDIT
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Putproducto(int id,[FromBody] producto producto)
        {
            if (id != producto.codigo_producto)
            {
                return BadRequest();
            }

            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!productoExists(id))
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

        // POST: api/Productos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<producto>> Postproducto(producto producto)
        //{
        //    _context.productos.Add(producto);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("Getproducto", new { id = producto.codigo_producto }, producto);
        //}

        // DELETE: api/Productos/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Deleteproducto(int id)
        //{
        //    var producto = await _context.productos.FindAsync(id);
        //    if (producto == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.productos.Remove(producto);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool productoExists(int id)
        {
            return _context.productos.Any(e => e.codigo_producto == id);
        }
    }
}
