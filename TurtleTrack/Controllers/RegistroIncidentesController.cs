using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurtleTrack.Models;

namespace TurtleTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroIncidentesController : ControllerBase
    {
        private readonly TurtleTrackContext _context;

        public RegistroIncidentesController(TurtleTrackContext context)
        {
            _context = context;
        }

        // GET: api/RegistroIncidentes
        //If the [HttpGet] attribute has a route template (for example, [HttpGet('products')]), append that to the path.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistroIncidentes>>> GetRegistroIncidentes()
        {
            return await _context.RegistroIncidentes.ToListAsync();
        }

        // GET: api/RegistroIncidentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistroIncidentes>> GetRegistroIncidentes(long id)
        {
            var registroIncidentes = await _context.RegistroIncidentes.FindAsync(id);

            if (registroIncidentes == null)
            {
                return NotFound();
            }

            return registroIncidentes;
        }


        // PUT: api/RegistroIncidentes/5       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistroIncidentes(long id, RegistroIncidentes registroIncidentes)
        {
            if (id != registroIncidentes.Id)
            {
                return BadRequest();
            }

            _context.Entry(registroIncidentes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistoIncidentesExists(id))
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

        // POST: api/RegistroIncidentes      
        [HttpPost]
        public async Task<ActionResult<RegistroIncidentes>> PostRegistroIncidentes(RegistroIncidentes registroIncidentes)
        {
            _context.RegistroIncidentes.Add(registroIncidentes);
            await _context.SaveChangesAsync();

            //    return CreatedAtAction("PostRegistroIncidentes", new { id = registroIncidentes.Id }, registroIncidentes);
            return CreatedAtAction(nameof(PostRegistroIncidentes), new { id = registroIncidentes.Id }, registroIncidentes);
        }

        // DELETE: api/RegistroIncidentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistroIncidentes(long id)
        {
            var registroIncidentes = await _context.RegistroIncidentes.FindAsync(id);
            if (registroIncidentes == null)
            {
                return NotFound();
            }

            _context.RegistroIncidentes.Remove(registroIncidentes);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool RegistoIncidentesExists(long id)
        {
            return _context.RegistroIncidentes.Any(e => e.Id == id);
        }
    }
}
