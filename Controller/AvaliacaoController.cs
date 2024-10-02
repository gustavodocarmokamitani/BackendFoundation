using backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly SalaoContext _dbContext;

        public AvaliacaoController(SalaoContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Avaliacao>> Get()
        {
            return Ok(_dbContext.Avaliacoes.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Avaliacao> GetById(int id)
        {
            var avaliacao = _dbContext.Avaliacoes.Find(id);
            if (avaliacao == null) return NotFound();
            return Ok(avaliacao);
        }

        [HttpPost]
        public ActionResult<Avaliacao> Post([FromBody] Avaliacao avaliacao)
        {
            if (avaliacao == null) return BadRequest("Dados inválidos");
            _dbContext.Avaliacoes.Add(avaliacao);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = avaliacao.Id }, avaliacao);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Avaliacao avaliacao)
        {
            if (avaliacao == null || id != avaliacao.Id) return BadRequest("Dados inválidos");
            var existingAvaliacao = _dbContext.Avaliacoes.Find(id);
            if (existingAvaliacao == null) return NotFound();
            _dbContext.Entry(existingAvaliacao).CurrentValues.SetValues(avaliacao);
            _dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var avaliacao = _dbContext.Avaliacoes.Find(id);
            if (avaliacao == null) return NotFound();
            _dbContext.Avaliacoes.Remove(avaliacao);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
