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
    public class S1v1Controller : ControllerBase
    {
        private readonly kometaDBContext _context;

        public S1v1Controller(kometaDBContext context)
        {
            _context = context;
        }

        // GET: api/S1v1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<S1v1>>> GetS1v1s()
        {
            return await _context.S1v1s.ToListAsync();
        }

        // GET: api/S1v1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<S1v1>> GetS1v1(int id)
        {
            var s1v1 = await _context.S1v1s.FindAsync(id);

            if (s1v1 == null)
            {
                return NotFound();
            }

            return s1v1;
        }

        // PUT: api/S1v1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutS1v1(int id, S1v1 s1v1)
        {
            if (id != s1v1.Id)
            {
                return BadRequest();
            }

            _context.Entry(s1v1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!S1v1Exists(id))
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

        // POST: api/S1v1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<S1v1>> PostS1v1(S1v1 s1v1)
        {
            _context.S1v1s.Add(s1v1);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (S1v1Exists(s1v1.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetS1v1", new { id = s1v1.Id }, s1v1);
        }

        // DELETE: api/S1v1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<S1v1>> DeleteS1v1(int id)
        {
            var s1v1 = await _context.S1v1s.FindAsync(id);
            if (s1v1 == null)
            {
                return NotFound();
            }

            _context.S1v1s.Remove(s1v1);
            await _context.SaveChangesAsync();

            return s1v1;
        }

        private bool S1v1Exists(int id)
        {
            return _context.S1v1s.Any(e => e.Id == id);
        }
    }
}
