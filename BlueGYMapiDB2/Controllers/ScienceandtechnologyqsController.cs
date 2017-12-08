using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlueGYMapiDB2.Models;

namespace BlueGYMapiDB2.Controllers
{
    [Produces("application/json")]
    [Route("api/Scienceandtechnologyqs")]
    public class ScienceandtechnologyqsController : Controller
    {
        private readonly bluegymContext _context;

        public ScienceandtechnologyqsController(bluegymContext context)
        {
            _context = context;
        }

        // GET: api/Scienceandtechnologyqs
        [HttpGet]
        public IEnumerable<Scienceandtechnologyq> GetScienceandtechnologyq()
        {
            foreach (var item in _context.Scienceandtechnologyq)
            {
                Console.WriteLine(item.Gqid);
            }
            return _context.Scienceandtechnologyq;
        }

        // GET: api/Scienceandtechnologyqs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetScienceandtechnologyq([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var scienceandtechnologyq = await _context.Scienceandtechnologyq.SingleOrDefaultAsync(m => m.Gqid == id);

            if (scienceandtechnologyq == null)
            {
                return NotFound();
            }

            return Ok(scienceandtechnologyq);
        }

        // PUT: api/Scienceandtechnologyqs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScienceandtechnologyq([FromRoute] int id, [FromBody] Scienceandtechnologyq scienceandtechnologyq)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != scienceandtechnologyq.Gqid)
            {
                return BadRequest();
            }

            _context.Entry(scienceandtechnologyq).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScienceandtechnologyqExists(id))
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

        // POST: api/Scienceandtechnologyqs
        [HttpPost]
        public async Task<IActionResult> PostScienceandtechnologyq([FromBody] Scienceandtechnologyq scienceandtechnologyq)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Scienceandtechnologyq.Add(scienceandtechnologyq);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ScienceandtechnologyqExists(scienceandtechnologyq.Gqid))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetScienceandtechnologyq", new { id = scienceandtechnologyq.Gqid }, scienceandtechnologyq);
        }

        // DELETE: api/Scienceandtechnologyqs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScienceandtechnologyq([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var scienceandtechnologyq = await _context.Scienceandtechnologyq.SingleOrDefaultAsync(m => m.Gqid == id);
            if (scienceandtechnologyq == null)
            {
                return NotFound();
            }

            _context.Scienceandtechnologyq.Remove(scienceandtechnologyq);
            await _context.SaveChangesAsync();

            return Ok(scienceandtechnologyq);
        }

        private bool ScienceandtechnologyqExists(int id)
        {
            return _context.Scienceandtechnologyq.Any(e => e.Gqid == id);
        }
    }
}