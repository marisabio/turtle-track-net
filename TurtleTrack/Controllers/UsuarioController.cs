using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurtleTrack.Models;

namespace TurtleTrack.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly TurtleTrackContext _context;

        public UsuarioController(TurtleTrackContext context)
        {
            _context = context;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            return await _context.Usuarios.ToListAsync();
        }


        // GET: api/Usuario/
        [HttpGet("{login}")]
        public async Task<ActionResult<Usuario>> GetUsuario(String login)
        {
            var usuario = await _context.Usuarios.FindAsync(login);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuario/5       
        [HttpPut("{login}")]
        public async Task<IActionResult> PutUsuario(String login, Usuario usuario)
        {
            if (login != usuario.Login)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(login))
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

        // POST: api/Usuario      
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            //    return CreatedAtAction("PostUsuario", new { id = usuario.Id }, usuario);
            return CreatedAtAction(nameof(PostUsuario), new { login = usuario.Login }, usuario);
        }

        // DELETE: api/Usuario/
        [HttpDelete("{login}")]
        public async Task<IActionResult> DeleteUsuario(String login)
        {
            var usuario = await _context.Usuarios.FindAsync(login);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(String login)
        {
            return _context.Usuarios.Any(e => e.Login == login);
        }
    }
}
