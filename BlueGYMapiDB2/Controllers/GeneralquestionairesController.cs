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
    [Route("api/Generalquestionaires")]
    public class GeneralquestionairesController : Controller
    {
        private readonly bluegymContext _context;

        public GeneralquestionairesController(bluegymContext context)
        {
            _context = context;
        }

        // GET: api/Generalquestionaires
        [HttpGet]
        public IEnumerable<Generalquestionaire> GetGeneralquestionaire()
        {
            foreach (var item in _context.Generalquestionaire)
            {
                Console.WriteLine(item.Gqid);
            }
            return _context.Generalquestionaire;
        }

        // GET: api/Generalquestionaires/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGeneralquestionaire([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var generalquestionaire = await _context.Generalquestionaire.SingleOrDefaultAsync(m => m.Gqid == id);

            if (generalquestionaire == null)
            {
                return NotFound();
            }

            return Ok(generalquestionaire);
        }

        // PUT: api/Generalquestionaires/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeneralquestionaire([FromRoute] int id, [FromBody] Generalquestionaire generalquestionaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != generalquestionaire.Gqid)
            {
                return BadRequest();
            }

            _context.Entry(generalquestionaire).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneralquestionaireExists(id))
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

        // POST: api/Generalquestionaires
        [HttpPost]
        public async Task<IActionResult> PostGeneralquestionaire([FromBody] Generalquestionaire generalquestionaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Generalquestionaire.Add(generalquestionaire);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GeneralquestionaireExists(generalquestionaire.Gqid))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGeneralquestionaire", new { id = generalquestionaire.Gqid }, generalquestionaire);
        }

        // DELETE: api/Generalquestionaires/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeneralquestionaire([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var generalquestionaire = await _context.Generalquestionaire.SingleOrDefaultAsync(m => m.Gqid == id);
            if (generalquestionaire == null)
            {
                return NotFound();
            }

            _context.Generalquestionaire.Remove(generalquestionaire);
            await _context.SaveChangesAsync();

            return Ok(generalquestionaire);
        }

        private bool GeneralquestionaireExists(int id)
        {
            return _context.Generalquestionaire.Any(e => e.Gqid == id);
        }
    }
}