using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using EAD2APIRepeat;
using EAD2APIRepeat.Data;

namespace EAD2APIRepeat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForecastsController : ControllerBase
    {
        private readonly EAD2RepeatContext _context;

        public ForecastsController(EAD2RepeatContext context)
        {
            _context = context;
        }

        // GET: api/Sellers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Forecasts>>> GetForecasts()
        {
            return await _context.forecasts.ToListAsync();
        }

        // GET: api/Forecasts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Forecasts>> GetForecasts(int id)
        {
            var forecasts = await _context.forecasts.FindAsync(id);

            if (forecasts == null)
            {
                return NotFound();
            }

            return forecasts;
        }

        // PUT: api/Sellers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutForecasts(int id, Forecasts forecasts)
        {
            if (id != forecasts.ID)
            {
                return BadRequest();
            }

            _context.Entry(forecasts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ForecastsExists(id))
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

        // POST: api/Forecasts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Forecasts>> PostForecasts(Forecasts forecasts)
        {
            _context.forecasts.Add(forecasts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetForecasts", new { id = forecasts.ID }, forecasts);
        }

        // DELETE: api/Forecasts/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteForecasts(int id)
        {
            var forecasts= await _context.forecasts.FindAsync(id);
            if (forecasts == null)
            {
                return NotFound();
            }

            _context.forecasts.Remove(forecasts);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ForecastsExists(int id)
        {
            return _context.forecasts.Any(e => e.ID == id);
        }
    }
}
