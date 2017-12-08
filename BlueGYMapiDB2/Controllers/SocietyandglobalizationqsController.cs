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
    [Route("api/Societyandglobalizationqs")]
    public class SocietyandglobalizationqsController : Controller
    {
        private readonly bluegymContext _context;

        public SocietyandglobalizationqsController(bluegymContext context)
        {
            _context = context;
        }

        // GET: api/Societyandglobalizationqs
        [HttpGet]
        public IEnumerable<Societyandglobalizationq> GetSocietyandglobalizationq()
        {
            foreach (var item in _context.Societyandglobalizationq)
            {
                Console.WriteLine(item.Gqid);
            }
            return _context.Societyandglobalizationq;
        }

        // GET: api/Societyandglobalizationqs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocietyandglobalizationq([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var societyandglobalizationq = await _context.Societyandglobalizationq.SingleOrDefaultAsync(m => m.Gqid == id);

            if (societyandglobalizationq == null)
            {
                return NotFound();
            }

            return Ok(societyandglobalizationq);
        }

        // PUT: api/Societyandglobalizationqs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSocietyandglobalizationq([FromRoute] int id, [FromBody] Societyandglobalizationq societyandglobalizationq)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != societyandglobalizationq.Gqid)
            {
                return BadRequest();
            }

            _context.Entry(societyandglobalizationq).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SocietyandglobalizationqExists(id))
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

        // POST: api/Societyandglobalizationqs
        [HttpPost]
        public async Task<IActionResult> PostSocietyandglobalizationq([FromBody] Societyandglobalizationq societyandglobalizationq)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Societyandglobalizationq.Add(societyandglobalizationq);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SocietyandglobalizationqExists(societyandglobalizationq.Gqid))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSocietyandglobalizationq", new { id = societyandglobalizationq.Gqid }, societyandglobalizationq);
        }

        // DELETE: api/Societyandglobalizationqs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSocietyandglobalizationq([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var societyandglobalizationq = await _context.Societyandglobalizationq.SingleOrDefaultAsync(m => m.Gqid == id);
            if (societyandglobalizationq == null)
            {
                return NotFound();
            }

            _context.Societyandglobalizationq.Remove(societyandglobalizationq);
            await _context.SaveChangesAsync();

            return Ok(societyandglobalizationq);
        }

        private bool SocietyandglobalizationqExists(int id)
        {
            return _context.Societyandglobalizationq.Any(e => e.Gqid == id);
        }
    }
}