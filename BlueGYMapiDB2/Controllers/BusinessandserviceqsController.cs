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
    [Route("api/Businessandserviceqs")]
    public class BusinessandserviceqsController : Controller
    {
        private readonly bluegymContext _context;

        public BusinessandserviceqsController(bluegymContext context)
        {
            _context = context;
        }

        // GET: api/Businessandserviceqs
        [HttpGet]
        public IEnumerable<Businessandserviceq> GetBusinessandserviceq()
        {
            foreach (var item in _context.Businessandserviceq)
            {
                Console.WriteLine(item.Gqid);
            }
            return _context.Businessandserviceq;
        }

        // GET: api/Businessandserviceqs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBusinessandserviceq([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var businessandserviceq = await _context.Businessandserviceq.SingleOrDefaultAsync(m => m.Gqid == id);

            if (businessandserviceq == null)
            {
                return NotFound();
            }

            return Ok(businessandserviceq);
        }

        // PUT: api/Businessandserviceqs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusinessandserviceq([FromRoute] int id, [FromBody] Businessandserviceq businessandserviceq)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != businessandserviceq.Gqid)
            {
                return BadRequest();
            }

            _context.Entry(businessandserviceq).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessandserviceqExists(id))
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

        // POST: api/Businessandserviceqs
        [HttpPost]
        public async Task<IActionResult> PostBusinessandserviceq([FromBody] Businessandserviceq businessandserviceq)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Businessandserviceq.Add(businessandserviceq);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BusinessandserviceqExists(businessandserviceq.Gqid))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBusinessandserviceq", new { id = businessandserviceq.Gqid }, businessandserviceq);
        }

        // DELETE: api/Businessandserviceqs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusinessandserviceq([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var businessandserviceq = await _context.Businessandserviceq.SingleOrDefaultAsync(m => m.Gqid == id);
            if (businessandserviceq == null)
            {
                return NotFound();
            }

            _context.Businessandserviceq.Remove(businessandserviceq);
            await _context.SaveChangesAsync();

            return Ok(businessandserviceq);
        }

        private bool BusinessandserviceqExists(int id)
        {
            return _context.Businessandserviceq.Any(e => e.Gqid == id);
        }
    }
}