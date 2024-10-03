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
    public class CabeleleiroController : ControllerBase
    {
        private readonly SalaoContext _dbContext;

        public CabeleleiroController(SalaoContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Obter todos os cabeleireiros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cabeleleiro>>> Get()
        {
            // Removendo a inclusão de especialidades
            var cabeleireiros = await _dbContext.Cabeleleiros.ToListAsync();
            return Ok(cabeleireiros);
        }

        // Obter cabeleireiro por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Cabeleleiro>> GetById(int id)
        {
            // Removendo a inclusão de especialidades
            var cabeleireiro = await _dbContext.Cabeleleiros.FirstOrDefaultAsync(c => c.Id == id);

            if (cabeleireiro == null) return NotFound();

            return Ok(cabeleireiro);
        }

        // Criar um novo cabeleireiro
        [HttpPost]
        public async Task<ActionResult<Cabeleleiro>> Post([FromBody] Cabeleleiro cabeleireiro)
        {
            if (cabeleireiro == null) return BadRequest("Dados inválidos.");

            // Verifica se o UsuarioId existe
            var usuario = await _dbContext.Usuarios.FindAsync(cabeleireiro.UsuarioId);
            if (usuario == null)
            {
                return BadRequest($"Usuário com ID {cabeleireiro.UsuarioId} não encontrado.");
            }

            // Adiciona o cabeleireiro
            _dbContext.Cabeleleiros.Add(cabeleireiro);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = cabeleireiro.Id }, cabeleireiro);
        }

        // Atualizar um cabeleireiro existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Cabeleleiro cabeleireiro)
        {
            if (cabeleireiro == null || id != cabeleireiro.Id) return BadRequest("Dados inválidos.");

            var existingCabeleleiro = await _dbContext.Cabeleleiros.FindAsync(id);
            if (existingCabeleleiro == null) return NotFound();

            // Atualiza os valores do cabeleireiro existente
            _dbContext.Entry(existingCabeleleiro).CurrentValues.SetValues(cabeleireiro);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        // Deletar um cabeleireiro
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cabeleireiro = await _dbContext.Cabeleleiros.FindAsync(id);
            if (cabeleireiro == null) return NotFound();

            _dbContext.Cabeleleiros.Remove(cabeleireiro);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
