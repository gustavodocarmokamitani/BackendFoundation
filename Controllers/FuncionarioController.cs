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
    public class FuncionarioController : ControllerBase
    {
        private readonly SalaoContext _dbContext;

        public FuncionarioController(SalaoContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Obter todos os funcionarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcionario>>> Get()
        {
            // Removendo a inclusão de especialidades
            var funcionarios = await _dbContext.Funcionarios.ToListAsync();
            return Ok(funcionarios);
        }

        // Obter cabeleireiro por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Funcionario>> GetById(int id)
        {
            // Removendo a inclusão de especialidades
            var cabeleireiro = await _dbContext.Funcionarios.FirstOrDefaultAsync(c => c.Id == id);

            if (cabeleireiro == null) return NotFound();

            return Ok(cabeleireiro);
        }

        // Criar novos funcionarios
        [HttpPost]
        public async Task<ActionResult<List<Funcionario>>> Post([FromBody] List<Funcionario> funcionarios)
        {
            if (funcionarios == null || !funcionarios.Any())
                return BadRequest("Dados inválidos.");

            var addedCabeleireiros = new List<Funcionario>();

            foreach (var cabeleireiro in funcionarios)
            {
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
                _dbContext.Funcionarios.Add(cabeleireiro);
                addedCabeleireiros.Add(cabeleireiro);
            }

            await _dbContext.SaveChangesAsync();

            // Retorna a lista de funcionarios adicionados com status 201 Created
            return CreatedAtAction(nameof(GetAll), null, addedCabeleireiros);
        }

        // Obter todos os funcionarios
        [HttpGet]
        [Route("api/funcionarios")]
        public async Task<ActionResult<List<Funcionario>>> GetAll()
        {
            var funcionarios = await _dbContext.Funcionarios.ToListAsync();
            return Ok(funcionarios);
        }


        // Atualizar um cabeleireiro existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Funcionario cabeleireiro)
        {
            if (cabeleireiro == null || id != cabeleireiro.Id)
            {
                return BadRequest("Dados inválidos ou ID não corresponde.");
            }

            // Verifica se o cabeleireiro existe
            var cabeleireiroExistente = await _dbContext.Funcionarios
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
            var cabeleireiro = await _dbContext.Funcionarios.FindAsync(id);
            if (cabeleireiro == null) return NotFound();

            _dbContext.Funcionarios.Remove(cabeleireiro);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        // Avaliacoes do cabeleleiro
        [HttpGet("{cabeleleiroId}/avaliacoes")]
        public async Task<ActionResult<IEnumerable<Avaliacao>>> GetAvaliacoesByCabeleleiro(int cabeleleiroId)
        {
            // Verifica se o CabeleleiroId existe
            var cabeleireiro = await _dbContext.Funcionarios.FindAsync(cabeleleiroId);
            if (cabeleireiro == null)
            {
                return NotFound($"Funcionarios com ID {cabeleleiroId} não encontrado.");
            }

            // Buscar todas as avaliações do cabeleireiro
            var avaliacoes = await _dbContext.Avaliacoes
                                             .Where(a => a.FuncionarioId == cabeleleiroId)
                                             .ToListAsync();

            return Ok(avaliacoes);
        }

        // Media das avaliacoes do cabeleleiro
        [HttpGet("{cabeleleiroId}/media-avaliacoes")]
        public async Task<ActionResult<double>> GetMediaAvaliacoesByCabeleleiro(int cabeleleiroId)
        {
            // Verifica se o CabeleleiroId existe
            var cabeleireiro = await _dbContext.Funcionarios.FindAsync(cabeleleiroId);
            if (cabeleireiro == null)
            {
                return NotFound($"Funcionarios com ID {cabeleleiroId} não encontrado.");
            }

            // Buscar todas as avaliações do cabeleireiro
            var avaliacoes = await _dbContext.Avaliacoes
                                             .Where(a => a.FuncionarioId == cabeleleiroId)
                                             .ToListAsync();

            if (!avaliacoes.Any())
            {
                return Ok(0); // Caso não tenha avaliações, retorna média 0
            }

            // Calcular a média das notas
            var mediaAvaliacoes = avaliacoes.Average(a => a.Nota); // Supondo que o campo da avaliação seja 'Nota'

            return Ok(mediaAvaliacoes);
        }

        // Funções
        private bool CabeleleiroExists(int id)
        {
            return _dbContext.Funcionarios.Any(e => e.Id == id);
        }
    }
}
