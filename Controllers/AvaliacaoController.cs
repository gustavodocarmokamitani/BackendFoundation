using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<ActionResult<IEnumerable<Avaliacao>>> Get()
        {
            return Ok(await _dbContext.Avaliacoes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Avaliacao>> GetById(int id)
        {
            var avaliacao = await _dbContext.Avaliacoes.FindAsync(id);
            if (avaliacao == null) return NotFound();
            return Ok(avaliacao);
        }

        [HttpPost]
        public async Task<ActionResult<Avaliacao>> Post([FromBody] Avaliacao avaliacao)
        {
            if (avaliacao == null) return BadRequest("Dados inválidos");

            // Verifica se o CabeleleiroId existe
            var cabeleleiro = await _dbContext.Cabeleleiros.FindAsync(avaliacao.CabeleleiroId);
            if (cabeleleiro == null)
            {
                return BadRequest($"Cabeleleiro com ID {avaliacao.CabeleleiroId} não encontrado.");
            }

            // Adiciona a avaliação
            _dbContext.Avaliacoes.Add(avaliacao);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = avaliacao.Id }, avaliacao);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Avaliacao avaliacao)
        {
            if (avaliacao == null || id != avaliacao.Id) return BadRequest("Dados inválidos");

            var existingAvaliacao = await _dbContext.Avaliacoes.FindAsync(id);
            if (existingAvaliacao == null) return NotFound();

            _dbContext.Entry(existingAvaliacao).CurrentValues.SetValues(avaliacao);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var avaliacao = await _dbContext.Avaliacoes.FindAsync(id);
            if (avaliacao == null) return NotFound();

            _dbContext.Avaliacoes.Remove(avaliacao);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
