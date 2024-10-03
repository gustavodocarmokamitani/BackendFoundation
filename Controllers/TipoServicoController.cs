using backend.Models; 
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace backend.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoServicoController : ControllerBase
    {
        private readonly SalaoContext _dbContext;

        public TipoServicoController(SalaoContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/tiposservico
        [HttpGet]
        public ActionResult<IEnumerable<TipoServico>> Get()
        {
            return Ok(_dbContext.TipoServicos.ToList());
        }

        // GET: api/tiposservico/{id}
        [HttpGet("{id}")]
        public ActionResult<TipoServico> GetById(int id)
        {
            var tipoServico = _dbContext.TipoServicos.Find(id);
            if (tipoServico == null) return NotFound();
            return Ok(tipoServico);
        }

        // POST: api/tiposservico
        [HttpPost]
        public ActionResult<TipoServico> Post([FromBody] TipoServico tipoServico)
        {
            if (tipoServico == null) return BadRequest("Dados inválidos");
            _dbContext.TipoServicos.Add(tipoServico);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = tipoServico.Id }, tipoServico);
        }

        // PUT: api/tiposservico/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TipoServico tipoServico)
        {
            if (tipoServico == null || id != tipoServico.Id) return BadRequest("Dados inválidos");
            var existingTipoServico = _dbContext.TipoServicos.Find(id);
            if (existingTipoServico == null) return NotFound();
            _dbContext.Entry(existingTipoServico).CurrentValues.SetValues(tipoServico);
            _dbContext.SaveChanges();
            return NoContent();
        }

        // DELETE: api/tiposservico/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tipoServico = _dbContext.TipoServicos.Find(id);
            if (tipoServico == null) return NotFound();
            _dbContext.TipoServicos.Remove(tipoServico);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
