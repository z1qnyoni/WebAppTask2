using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidentsController : ControllerBase
    {
        private readonly AppDBcontext _context;

        public ResidentsController(AppDBcontext context)
        {
            _context = context;
        }

        // GET: api/Residents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resident>>> GetResidents()
        {
            return await _context.Residents.ToListAsync();
        }

        // GET: api/Residents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Resident>> GetResident(int id)
        {
            var resident = await _context.Residents.FindAsync(id);

            if (resident == null)
            {
                return NotFound();
            }

            return resident;
        }

        // PUT: api/Residents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResident(int id, Resident resident)
        {
            if (id != resident.Id)
            {
                return BadRequest();
            }

            _context.Entry(resident).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResidentExists(id))
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

        // POST: api/Residents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Resident>> PostResident(Resident resident)
        {
            _context.Residents.Add(resident);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResident", new { id = resident.Id }, resident);
        }

        // DELETE: api/Residents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResident(int id)
        {
            var resident = await _context.Residents.FindAsync(id);
            if (resident == null)
            {
                return NotFound();
            }

            _context.Residents.Remove(resident);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResidentExists(int id)
        {
            return _context.Residents.Any(e => e.Id == id);
        }
    }
}
