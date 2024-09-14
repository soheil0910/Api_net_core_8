using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_net_core_8.Data;
using Api_net_core_8.Models.Pc;

namespace Api_net_core_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PCsController : ControllerBase
    {
        private readonly ApiContext _context;

        public PCsController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/PCs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PC>>> GetPc()
        {
            return await _context.Pc.Include(p=>p.Description).ThenInclude(p=>p.PcCpu).ThenInclude(p=>p.Fan).ToListAsync();
        }

        // GET: api/PCs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PC>> GetPC(int id)
        {
            var pC = await _context.Pc.FindAsync(id);

            if (pC == null)
            {
                return NotFound();
            }

            return pC;
        }

        // PUT: api/PCs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPC(int id, PC pC)
        {
            if (id != pC.Id)
            {
                return BadRequest();
            }

            _context.Entry(pC).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PCExists(id))
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

        // POST: api/PCs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PC>> PostPC(PC pC)
        {
            _context.Pc.Add(pC);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPC", new { id = pC.Id }, pC);
        }

        // DELETE: api/PCs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePC(int id)
        {
            var pC = await _context.Pc.FindAsync(id);
            if (pC == null)
            {
                return NotFound();
            }

            _context.Pc.Remove(pC);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PCExists(int id)
        {
            return _context.Pc.Any(e => e.Id == id);
        }
    }
}
