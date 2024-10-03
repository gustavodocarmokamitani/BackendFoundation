using backend.Models; 
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace backend.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly SalaoContext _dbContext;

        public TipoUsuarioController(SalaoContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/tiposusuario
        [HttpGet]
        public ActionResult<IEnumerable<TipoUsuario>> Get()
        {
            return Ok(_dbContext.TipoUsuarios.ToList());
        }

        // GET: api/tiposusuario/{id}
        [HttpGet("{id}")]
        public ActionResult<TipoUsuario> GetById(int id)
        {
            var TipoUsuario = _dbContext.TipoUsuarios.Find(id);
            if (TipoUsuario == null) return NotFound();
            return Ok(TipoUsuario);
        }

        // POST: api/tiposusuario
        [HttpPost]
        public ActionResult<TipoUsuario> Post([FromBody] TipoUsuario TipoUsuario)
        {
            if (TipoUsuario == null) return BadRequest("Dados inválidos");
            _dbContext.TipoUsuarios.Add(TipoUsuario);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = TipoUsuario.Id }, TipoUsuario);
        }

        // PUT: api/tiposusuario/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TipoUsuario TipoUsuario)
        {
            if (TipoUsuario == null || id != TipoUsuario.Id) return BadRequest("Dados inválidos");
            var existingTipoUsuario = _dbContext.TipoUsuarios.Find(id);
            if (existingTipoUsuario == null) return NotFound();
            _dbContext.Entry(existingTipoUsuario).CurrentValues.SetValues(TipoUsuario);
            _dbContext.SaveChanges();
            return NoContent();
        }

        // DELETE: api/tiposusuario/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var TipoUsuario = _dbContext.TipoUsuarios.Find(id);
            if (TipoUsuario == null) return NotFound();
            _dbContext.TipoUsuarios.Remove(TipoUsuario);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
