using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurtleTrack.Models;

namespace TurtleTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegiaoMonitoradaController : ControllerBase
    {
        private readonly TurtleTrackContext _context;

        public RegiaoMonitoradaController(TurtleTrackContext context)
        {
            _context = context;
        }

        // GET: api/RegiaoMonitorada
        //If the [HttpGet] attribute has a route template (for example, [HttpGet('products')]), append that to the path.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegiaoMonitorada>>> GetRegiaoMonitoradas()
        {
            return await _context.RegiaoMonitoradas.ToListAsync();
        }

        // GET: api/RegiaoMonitorada/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegiaoMonitorada>> GetRegiaoMonitorada(long id)
        {
            var regiaoMonitorada = await _context.RegiaoMonitoradas.FindAsync(id);

            if (regiaoMonitorada == null)
            {
                return NotFound();
            }

            return regiaoMonitorada;
        }

        // PUT: api/RegiaoMonitorada/5       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegiaoMonitorada(long id, RegiaoMonitorada regiaoMonitorada)
        {
            if (id != regiaoMonitorada.Id)
            {
                return BadRequest();
            }

            _context.Entry(regiaoMonitorada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegiaoMonitoradaExists(id))
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

        // POST: api/RegiaoMonitorada      
        [HttpPost]
        public async Task<ActionResult<RegiaoMonitorada>> PostRegiaoMonitorada(RegiaoMonitorada regiaoMonitorada)
        {
            _context.RegiaoMonitoradas.Add(regiaoMonitorada);
            await _context.SaveChangesAsync();

            //    return CreatedAtAction("PostRegiaoMonitorada", new { id = regiaoMonitorada.Id }, regiaoMonitorada);
            return CreatedAtAction(nameof(PostRegiaoMonitorada), new { id = regiaoMonitorada.Id }, regiaoMonitorada);
        }

        // DELETE: api/RegiaoMonitorada/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegiaoMonitorada(long id)
        {
            var regiaoMonitorada = await _context.RegiaoMonitoradas.FindAsync(id);
            if (regiaoMonitorada == null)
            {
                return NotFound();
            }

            _context.RegiaoMonitoradas.Remove(regiaoMonitorada);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegiaoMonitoradaExists(long id)
        {
            return _context.RegiaoMonitoradas.Any(e => e.Id == id);
        }

    }
}
