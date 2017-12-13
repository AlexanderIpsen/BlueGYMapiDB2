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
    [Route("api/TeamLogin")]
    public class TeamLoginController : Controller
    {
        private readonly bluegymContext _context;

        public TeamLoginController(bluegymContext context)
        {
            _context = context;
        }

        // GET: api/TeamLogin
        [HttpGet]
        public IEnumerable<Team> GetTeam()
        {
            foreach (var item in _context.Team)
            {
                Console.WriteLine(item.Teamid);
            }
            return _context.Team;
        }

        // GET: api/TeamLogin/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeam([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var team = await _context.Team.SingleOrDefaultAsync(m => m.Teamid == id);

            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }

        // PUT: api/TeamLogin/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam([FromRoute] int id, [FromBody] Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != team.Teamid)
            {
                return BadRequest();
            }

            _context.Entry(team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
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

        // POST: api/TeamLogin


        [HttpPost]
        public IActionResult PostTeam([FromBody] Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            
            Team test = _context.Team.Find(team.Teamid);
            try
            {
                if (test != null && team.Teampaas == test.Teampaas && team.Teamname.Equals(test.Teamname))
                {
                    //return new OkResult();
                    return Ok();
                    //make responce object to wpf app
                }
                // await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (TeamExists(team.Teamid) && (team.Teampaas == team.Teampaas))
                {
                    //add validation for above code here
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            //return _context.Team.Any(e => e.Teamid == id);
            //return CreatedAtAction("GetTeam", new { id = team.Teamid }, team);
            return Unauthorized();
        }

        // DELETE: api/TeamLogin/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var team = await _context.Team.SingleOrDefaultAsync(m => m.Teamid == id);
            if (team == null)
            {
                return NotFound();
            }

            _context.Team.Remove(team);
            await _context.SaveChangesAsync();

            return Ok(team);
        }

        private bool TeamExists(int id)
        {
            return _context.Team.Any(e => e.Teamid == id);
        }
    }
}