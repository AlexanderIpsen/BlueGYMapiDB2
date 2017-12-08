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
    [Route("api/BlueEvents")]
    public class BlueEventsController : Controller
    {
        private readonly bluegymContext _context;

        public BlueEventsController(bluegymContext context)
        {
           
            _context = context;
        }

        // GET: api/BlueEvents
        [HttpGet]
        public IEnumerable<BlueEvent> GetBlueEvent()
        {
            foreach (var item in _context.BlueEvent)
            {
                Console.WriteLine(item.Eventid);
            }
            return _context.BlueEvent;
        }

        // GET: api/BlueEvents/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlueEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blueEvent = await _context.BlueEvent.SingleOrDefaultAsync(m => m.Eventid == id);

            if (blueEvent == null)
            {
                return NotFound();
            }

            return Ok(blueEvent);
        }

        // PUT: api/BlueEvents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlueEvent([FromRoute] int id, [FromBody] BlueEvent blueEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != blueEvent.Eventid)
            {
                return BadRequest();
            }

            _context.Entry(blueEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlueEventExists(id))
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

        // POST: api/BlueEvents
        [HttpPost]
        public async Task<IActionResult> PostBlueEvent([FromBody] BlueEvent blueEvent)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BlueEvent.Add(blueEvent);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (BlueEventExists(blueEvent.Eventid))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    Console.WriteLine("post exception" + ex.Message);
                    throw;
                }
            }
            return CreatedAtAction("GetBlueEvent", new { id = blueEvent.Eventid }, blueEvent);
        }

        // DELETE: api/BlueEvents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlueEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blueEvent = await _context.BlueEvent.SingleOrDefaultAsync(m => m.Eventid == id);
            if (blueEvent == null)
            {
                return NotFound();
            }

            _context.BlueEvent.Remove(blueEvent);
            await _context.SaveChangesAsync();

            return Ok(blueEvent);
        }

        private bool BlueEventExists(int id)
        {
            return _context.BlueEvent.Any(e => e.Eventid == id);
        }
    }
}