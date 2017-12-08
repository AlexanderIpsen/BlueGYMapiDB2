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
    [Route("api/Tradeandskillqs")]
    public class TradeandskillqsController : Controller
    {
        private readonly bluegymContext _context;

        public TradeandskillqsController(bluegymContext context)
        {
            _context = context;
        }

        // GET: api/Tradeandskillqs
        [HttpGet]
        public IEnumerable<Tradeandskillq> GetTradeandskillq()
        {
            foreach (var item in _context.Tradeandskillq)
            {
                Console.WriteLine(item.Gqid);
            }
            return _context.Tradeandskillq;
        }

        // GET: api/Tradeandskillqs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTradeandskillq([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tradeandskillq = await _context.Tradeandskillq.SingleOrDefaultAsync(m => m.Gqid == id);

            if (tradeandskillq == null)
            {
                return NotFound();
            }

            return Ok(tradeandskillq);
        }

        // PUT: api/Tradeandskillqs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTradeandskillq([FromRoute] int id, [FromBody] Tradeandskillq tradeandskillq)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tradeandskillq.Gqid)
            {
                return BadRequest();
            }

            _context.Entry(tradeandskillq).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TradeandskillqExists(id))
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

        // POST: api/Tradeandskillqs
        [HttpPost]
        public async Task<IActionResult> PostTradeandskillq([FromBody] Tradeandskillq tradeandskillq)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tradeandskillq.Add(tradeandskillq);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TradeandskillqExists(tradeandskillq.Gqid))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTradeandskillq", new { id = tradeandskillq.Gqid }, tradeandskillq);
        }

        // DELETE: api/Tradeandskillqs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTradeandskillq([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tradeandskillq = await _context.Tradeandskillq.SingleOrDefaultAsync(m => m.Gqid == id);
            if (tradeandskillq == null)
            {
                return NotFound();
            }

            _context.Tradeandskillq.Remove(tradeandskillq);
            await _context.SaveChangesAsync();

            return Ok(tradeandskillq);
        }

        private bool TradeandskillqExists(int id)
        {
            return _context.Tradeandskillq.Any(e => e.Gqid == id);
        }
    }
}