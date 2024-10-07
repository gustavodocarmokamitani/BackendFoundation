using backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private readonly SalaoContext _dbContext;

        public AgendamentoController(SalaoContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Obter todos os agendamentos
        [HttpGet]
        public ActionResult<IEnumerable<Agendamento>> Get()
        {
            try
            {
                var agendamentos = _dbContext.Agendamentos.ToList();
                if (!agendamentos.Any()) return NotFound("Nenhum agendamento encontrado.");
                return Ok(agendamentos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        // Obter agendamento por ID
        [HttpGet("{id}")]
        public ActionResult<Agendamento> GetById(int id)
        {
            var agendamento = _dbContext.Agendamentos.Find(id);
            if (agendamento == null) return NotFound();
            return Ok(agendamento);
        }

        [HttpPost]
        public async Task<ActionResult<List<Agendamento>>> Post([FromBody] List<Agendamento> agendamentos)
        {
            if (agendamentos == null || !agendamentos.Any())
                return BadRequest("Dados inválidos.");

            var addedAgendamentos = new List<Agendamento>();

            foreach (var agendamento in agendamentos)
            {
                if (agendamento == null)
                    return BadRequest("Dados de agendamento inválidos.");

                // Verifica se o ClienteId (Usuário) existe
                var cliente = await _dbContext.Usuarios.FindAsync(agendamento.ClienteId);
                if (cliente == null)
                {
                    return BadRequest($"Cliente com ID {agendamento.ClienteId} não encontrado.");
                }

                // Verifica se o FuncionarioId é válido e é do tipo funcionario
                var cabeleireiro = await _dbContext.Usuarios.FindAsync(agendamento.FuncionarioId);
                if (cabeleireiro == null || cabeleireiro.TipoUsuarioId != 2) // Assumindo que 2 é o ID para funcionário
                {
                    return BadRequest($"Cabeleireiro com ID {agendamento.FuncionarioId} não encontrado ou não é um funcionário.");
                }

                // Verifica se todos os ServicoIds existem
                foreach (var servicoId in agendamento.ServicosId)
                {
                    var servico = await _dbContext.Servicos.FindAsync(servicoId);
                    if (servico == null)
                    {
                        return BadRequest($"Serviço com ID {servicoId} não encontrado.");
                    }
                }

                // Verifica se o StatusAgendamentoId é válido (1 Confirmado, 2 Cancelado, 3 Pendente)
                if (agendamento.StatusAgendamentoId < 1 || agendamento.StatusAgendamentoId > 3)
                {
                    return BadRequest("Status do agendamento inválido.");
                }

                // Se todos os IDs forem válidos, adiciona o agendamento
                _dbContext.Agendamentos.Add(agendamento);
                addedAgendamentos.Add(agendamento);
            }

            await _dbContext.SaveChangesAsync();

            // Alteração aqui para pegar apenas o primeiro ID ou ajustar conforme sua necessidade
            return CreatedAtAction(nameof(GetById), new { id = addedAgendamentos.First().Id }, addedAgendamentos);
        }

        // Atualizar um agendamento existente
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Agendamento agendamento)
        {
            if (agendamento == null || agendamento.Id != id)
            {
                return BadRequest("Dados inválidos.");
            }

            // Verifica se o agendamento existe
            var agendamentoExistente = await _dbContext.Agendamentos.FindAsync(id);
            if (agendamentoExistente == null)
            {
                return NotFound($"Agendamento com ID {id} não encontrado.");
            }

            // Verifica se o ClienteId (Usuário) existe
            var cliente = await _dbContext.Usuarios.FindAsync(agendamento.ClienteId);
            if (cliente == null)
            {
                return BadRequest($"Cliente com ID {agendamento.ClienteId} não encontrado.");
            }

            // Verifica se o CabeleleiroId existe
            var cabeleireiro = await _dbContext.Funcionarios.FindAsync(agendamento.FuncionarioId);
            if (cabeleireiro == null)
            {
                return BadRequest($"Cabeleireiro com ID {agendamento.FuncionarioId} não encontrado.");
            }

            // Verifica se o ServicoId existe
            var servico = await _dbContext.Servicos.FindAsync(agendamento.ServicosId);
            if (servico == null)
            {
                return BadRequest($"Serviço com ID {agendamento.ServicosId} não encontrado.");
            }

            // Verifica se o StatusAgendamentoId é válido (1 Confirmado, 2 Cancelado, 3 Pendente)
            if (agendamento.StatusAgendamentoId < 1 || agendamento.StatusAgendamentoId > 3)
            {
                return BadRequest("Status do agendamento inválido.");
            }

            // Atualiza os dados do agendamento existente
            agendamentoExistente.ClienteId = agendamento.ClienteId;
            agendamentoExistente.FuncionarioId = agendamento.FuncionarioId;
            agendamentoExistente.ServicosId = agendamento.ServicosId;
            agendamentoExistente.DataAgendamento = agendamento.DataAgendamento;
            agendamentoExistente.StatusAgendamentoId = agendamento.StatusAgendamentoId;

            // Salva as alterações no banco de dados
            _dbContext.Agendamentos.Update(agendamentoExistente);
            await _dbContext.SaveChangesAsync();

            return NoContent(); // Retorna 204 NoContent quando a atualização é bem-sucedida
        }

        // Deletar um agendamento
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var agendamento = _dbContext.Agendamentos.Find(id);
            if (agendamento == null) return NotFound();
            _dbContext.Agendamentos.Remove(agendamento);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
