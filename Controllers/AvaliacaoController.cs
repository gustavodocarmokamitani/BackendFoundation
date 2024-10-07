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
        public async Task<ActionResult<List<Avaliacao>>> Post([FromBody] List<Avaliacao> avaliacoes)
        {
            if (avaliacoes == null || !avaliacoes.Any())
                return BadRequest("Dados inválidos.");

            var addedAvaliacoes = new List<Avaliacao>();

            foreach (var avaliacao in avaliacoes)
            {
                // Verifica se o ClienteId existe
                var cliente = await _dbContext.Usuarios.FindAsync(avaliacao.ClienteId);
                if (cliente == null)
                {
                    return BadRequest($"Cliente com ID {avaliacao.ClienteId} não encontrado.");
                }

                // Verifica se o FuncionarioId existe
                var cabeleireiro = await _dbContext.Funcionarios.FindAsync(avaliacao.FuncionarioId);
                if (cabeleireiro == null)
                {
                    return BadRequest($"Funcionário com ID {avaliacao.FuncionarioId} não encontrado.");
                }

                // Adiciona a avaliação
                _dbContext.Avaliacoes.Add(avaliacao);
                addedAvaliacoes.Add(avaliacao);
            }

            await _dbContext.SaveChangesAsync();

            // Retornar todas as avaliações adicionadas (ou algum detalhe relevante)
            return CreatedAtAction(nameof(Get), new { }, addedAvaliacoes);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Avaliacao avaliacao)
        {
            if (avaliacao == null || id != avaliacao.Id) return BadRequest("Dados inválidos.");

            // Verifica se a avaliação já existe
            var existingAvaliacao = await _dbContext.Avaliacoes.FindAsync(id);
            if (existingAvaliacao == null) return NotFound($"Avaliação com ID {id} não encontrada.");

            // Verifica se o ClienteId existe
            var cliente = await _dbContext.Usuarios.FindAsync(avaliacao.ClienteId);
            if (cliente == null)
            {
                return BadRequest($"Cliente com ID {avaliacao.ClienteId} não encontrado.");
            }

            // Verifica se o CabeleleiroId existe
            var cabeleireiro = await _dbContext.Funcionarios.FindAsync(avaliacao.FuncionarioId);
            if (cabeleireiro == null)
            {
                return BadRequest($"Funcionarios com ID {avaliacao.FuncionarioId} não encontrado.");
            }

            // Atualiza os valores da avaliação existente
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
