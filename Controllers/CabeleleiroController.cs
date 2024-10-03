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

            // Verifica se os IDs dos serviços são válidos
            var servicos = await _dbContext.Servicos
                                .Where(s => cabeleireiro.ServicosId.Contains(s.Id))
                                .ToListAsync();

            if (servicos.Count != cabeleireiro.ServicosId.Count)
            {
                return BadRequest("Um ou mais IDs de serviços são inválidos.");
            }

            // Associa os serviços ao cabeleireiro
            cabeleireiro.Servicos = servicos;

            // Adiciona o cabeleireiro ao banco de dados
            _dbContext.Cabeleleiros.Add(cabeleireiro);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = cabeleireiro.Id }, cabeleireiro);
        }

        // Atualizar um cabeleireiro existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Cabeleleiro cabeleireiro)
        {
            if (cabeleireiro == null || id != cabeleireiro.Id)
            {
                return BadRequest("Dados inválidos ou ID não corresponde.");
            }

            // Verifica se o cabeleireiro existe
            var cabeleireiroExistente = await _dbContext.Cabeleleiros
                .Include(c => c.Servicos)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cabeleireiroExistente == null)
            {
                return NotFound($"Cabeleireiro com ID {id} não encontrado.");
            }

            // Verifica se o UsuarioId existe
            var usuario = await _dbContext.Usuarios.FindAsync(cabeleireiro.UsuarioId);
            if (usuario == null)
            {
                return BadRequest($"Usuário com ID {cabeleireiro.UsuarioId} não encontrado.");
            }

            // Verifica se os IDs dos serviços são válidos
            var servicos = await _dbContext.Servicos
                                .Where(s => cabeleireiro.ServicosId.Contains(s.Id))
                                .ToListAsync();

            if (servicos.Count != cabeleireiro.ServicosId.Count)
            {
                return BadRequest("Um ou mais IDs de serviços são inválidos.");
            }

            // Atualiza as propriedades do cabeleireiro existente
            cabeleireiroExistente.UsuarioId = cabeleireiro.UsuarioId;
            cabeleireiroExistente.Servicos = servicos;

            // Salva as alterações no banco de dados
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CabeleleiroExists(id))
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

        // Funções
        private bool CabeleleiroExists(int id)
        {
            return _dbContext.Cabeleleiros.Any(e => e.Id == id);
        }

    }
}
