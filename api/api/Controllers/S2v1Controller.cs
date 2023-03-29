using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class S2v1Controller : ControllerBase
    {
        private readonly kometaDBContext _context;

        public S2v1Controller(kometaDBContext context)
        {
            _context = context;
        }

        // GET: api/S2v1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<S2v1>>> GetS2v1s()
        {
            return await _context.S2v1s.ToListAsync();
        }

        // GET: api/S2v1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<S2v1>> GetS2v1(int id)
        {
            var s2v1 = await _context.S2v1s.FindAsync(id);

            if (s2v1 == null)
            {
                return NotFound();
            }

            return s2v1;
        }

        // PUT: api/S2v1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutS2v1(int id, S2v1 s2v1)
        {
            if (id != s2v1.Id)
            {
                return BadRequest();
            }

            _context.Entry(s2v1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!S2v1Exists(id))
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

        // POST: api/S2v1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<S2v1>> PostS2v1(S2v1 s2v1)
        {
            _context.S2v1s.Add(s2v1);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (S2v1Exists(s2v1.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetS2v1", new { id = s2v1.Id }, s2v1);
        }

        // DELETE: api/S2v1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<S2v1>> DeleteS2v1(int id)
        {
            var s2v1 = await _context.S2v1s.FindAsync(id);
            if (s2v1 == null)
            {
                return NotFound();
            }

            _context.S2v1s.Remove(s2v1);
            await _context.SaveChangesAsync();

            return s2v1;
        }

        private bool S2v1Exists(int id)
        {
            return _context.S2v1s.Any(e => e.Id == id);
        }
    }
}
