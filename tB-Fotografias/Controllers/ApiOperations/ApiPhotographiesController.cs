using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tB_Fotografias.Data;
using tB_Fotografias.Models;

namespace tB_Fotografias.Controllers.ApiOperations
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiPhotographiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ApiPhotographiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ApiPhotographies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Photography>>> GetPhotographies()
        {
            return await _context.Photographies.ToListAsync();
        }

        // GET: api/ApiPhotographies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Photography>> GetPhotography(int id)
        {
            var photography = await _context.Photographies.FindAsync(id);

            if (photography == null)
            {
                return NotFound();
            }

            return photography;
        }

        // PUT: api/ApiPhotographies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhotography(int id, Photography photography)
        {
            if (id != photography.Id)
            {
                return BadRequest();
            }

            _context.Entry(photography).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotographyExists(id))
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

        // POST: api/ApiPhotographies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Photography>> PostPhotography(Photography photography)
        {
            _context.Photographies.Add(photography);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhotography", new { id = photography.Id }, photography);
        }

        // DELETE: api/ApiPhotographies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhotography(int id)
        {
            var photography = await _context.Photographies.FindAsync(id);
            if (photography == null)
            {
                return NotFound();
            }

            _context.Photographies.Remove(photography);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhotographyExists(int id)
        {
            return _context.Photographies.Any(e => e.Id == id);
        }
    }
}
