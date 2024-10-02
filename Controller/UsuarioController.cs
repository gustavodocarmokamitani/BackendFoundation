using backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly SalaoContext _dbContext; // Atualizado para SalaoContext

        public UsuarioController(SalaoContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/usuario
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            var usuarios = _dbContext.Usuarios.ToList();
            return Ok(usuarios);
        }

        // GET: api/usuario/{id}
        [HttpGet("{id}")]
        public ActionResult<Usuario> GetById(int id)
        {
            var usuario = _dbContext.Usuarios.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // POST: api/usuario
        [HttpPost]
        public ActionResult<Usuario> Post([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest("Dados inválidos");
            }

            _dbContext.Usuarios.Add(usuario);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }

        // PUT: api/usuario/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Usuario usuario)
        {
            if (usuario == null || id != usuario.Id)
            {
                return BadRequest("Dados inválidos");
            }

            var existingUsuario = _dbContext.Usuarios.Find(id);

            if (existingUsuario == null)
            {
                return NotFound();
            }

            _dbContext.Entry(existingUsuario).CurrentValues.SetValues(usuario);
            _dbContext.SaveChanges();

            return NoContent();
        }

        // DELETE: api/usuario/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _dbContext.Usuarios.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _dbContext.Usuarios.Remove(usuario);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
